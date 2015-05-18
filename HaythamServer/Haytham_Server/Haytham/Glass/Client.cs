
namespace myGlass
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Net.Sockets;
    using System.Windows.Forms;
    using System.Text;
    using System.Net;
    using System.Net.Sockets;
    using System.ComponentModel;
    using System.Data;
    using Haytham;
    using System.Linq;
    
    using System.Threading;
    using Newtonsoft.Json;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    using System.Web.Script.Serialization;
    using System.Collections.Generic;
    using System.Collections;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;


    using System.Security.Cryptography;

    /// <summary>
    /// </summary>
    public class Client
    {
        #region Fields

        byte[] headerBytes = new byte[22];
        byte[] digest = new byte[16];
        public double progressData_Total = 0;
        public double progressData_Remaining = 0;
        public ImageProcessing_Emgu EmgImgProcssing = new ImageProcessing_Emgu();

        int headerIndex = 0;

        //byte[] buf = new byte[8192];
        byte[] result = new byte[1];
        int count = 0;

        System.IO.MemoryStream dataOutputStream = new MemoryStream();

        public int numberOfPictures = 0;
        public Image bitmap;
        enum Mode : int { none = 0, mainLoop = 1, waitingForHeader = 2, waitingForpicture = 3 ,waitingForJSON_size=5,waitingForJSON=6};
        Mode mode = Mode.mainLoop;

        public enum Ready_State : int { No = 0, Yes = 1 ,Finished=-1};
        public Ready_State myGlassReady_State = Ready_State.No;

        private int failedBlobDetectionCount = 0;
        private int failedBlobDetectionCount_Max = 2;
        private int snapshot = 0;





        /// <summary>
        ///   Socket for accepting a connection
        /// </summary>
        public readonly TcpClient tcpClient;

        /// <summary>
        ///   The socket network data stream
        /// </summary>
        public readonly NetworkStream socketStream;

        /// <summary>
        ///   The reference to server
        /// </summary>
        private readonly Server server;
        public string glassIP = "";
        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="socket">
        /// The socket.
        /// </param>
        /// <param name="serverValue">
        /// The server value.
        /// </param>
        public Client(TcpClient socket, Server serverValue)
        {

   this.server = serverValue;
       
     finish("New Connection established!");
            this.tcpClient = socket;

            // create NetworkStream object for Socket
            this.socketStream = this.tcpClient.GetStream();

         



        }

        #endregion


        public void serverThread()
        {


            try
            {
                System.Net.Sockets.UdpClient udpClient = new System.Net.Sockets.UdpClient(constants.SERVER_PORT_UDP);
                IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);

                byte[] data = new byte[1024];
                data = udpClient.Receive(ref sender);
                udpClient.Close();
                string stringData = Encoding.ASCII.GetString(data, 0, data.Length);


                server.GlassIP = sender.Address.ToString();

                server.udpServer = new UdpClient(constants.SERVER_PORT_UDP_GAZE);
                server.remoteEP = new IPEndPoint(IPAddress.Parse(server.GlassIP), constants.SERVER_PORT_UDP_GAZE);
                server.sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                METState.Current.METCoreObject.SendToForm("Glass IP: " + server.GlassIP + "\r\n", "tbOutput");


            }
            catch (Exception e){ }

        }

        /// <summary>
        ///   Runs this instance.
        /// </summary>
        public void Run()
        {

            METState.Current.METCoreObject.SendToForm(0, "progressbar");

            ////UDP
            int cnt = 0;
            byte[] message;
            string msg = "";
            byte[] received;

            METState.Current.GlassServer.Send(myGlass.MessageType.toGLASS_WHAT_IS_YOUR_IP);
                            
            Thread thdUDPServer = new Thread(new ThreadStart(serverThread));
            thdUDPServer.Start();


            Thread.Sleep(500);

            do
            {
                try
                {

                    switch (mode)
                    {
                        case Mode.mainLoop:
                            {


                                received = new byte[constants.MSG_SIZE];
                                //socketStream.ReadTimeout = 10000;
                                int tmp = socketStream.Read(received, 0, received.Length);


                                if (tmp <= 0)
                                {
                                    cnt++;
                                    break;

                                }
                                else if (tmp == 12)
                                {


                                    //msg = System.Text.Encoding.UTF8.GetString(received, 0, tmp);//.TrimEnd('\0');



                                    //String received_MSG = myGlass.MessageType.commands.SingleOrDefault(x => x.Value == GetIndicator(received)).Key;
                                    //METState.Current.METCoreObject.SendToForm("Received msg: " + received_MSG, "tbOutput");


                                    interpretMSG(received);
                                }
                            }
                            break;
   
                        case Mode.waitingForJSON_size:
                            {
                                byte[] buffer = new byte[4];
                                //updateUI("Waiting for data.  Expecting " + progressData_Remaining + " more bytes.");
                                int bytesRead = METState.Current.GlassServer.client.socketStream.Read(buffer, 0, buffer.Length);
                                if (bytesRead == 4)
                                {
                                    progressData_Total = byteArrayToInt(buffer);
                                    progressData_Remaining = progressData_Total;
                                    dataOutputStream = new MemoryStream();
                    
                                    mode = Mode.waitingForJSON;


                                } 
                            else mode = Mode.mainLoop;

                            }
                            break;
                        case Mode.waitingForJSON:
                            {
                                int prg = getJson();

                                if (prg == 1)
                                {
                                    METState.Current.GlassServer.Send( MessageType.toGLASS_DataReceived);
                                   
                                    mode = Mode.mainLoop;
                                
                                }
                                else if (prg == -1)
                                {

                                    mode = Mode.mainLoop;
                                }



                            }
                            break;
                        case Mode.waitingForHeader:
                            {
                                int prg = getHeader();

                                if (prg == -1)
                                {
                                    mode = Mode.mainLoop;
                                    //Calibration terminated!
                                    server.Send(myGlass.MessageType.toGLASS_Calibrate_Scene, new Point(-3, -3));//point x (th) of y (total)

                                }

                                else if (prg == 1)
                                    mode = Mode.waitingForpicture;
                            }
                            break;
                        case Mode.waitingForpicture:
                            {
                                int prg = getPicture();

                                if (prg == 1)
                                {
                                    if (snapshot == 1)
                                    {
                                        mode = Mode.mainLoop;

                                        #region Draw gaze cross on image
                                        if (METState.Current.ShowGaze) EmgImgProcssing.DrawCross((Bitmap)bitmap,

                                            Convert.ToInt32(METState.Current.Gaze_SnapShot_Glass.X), Convert.ToInt32(METState.Current.Gaze_SnapShot_Glass.Y), System.Drawing.Color.Red);
                                        #endregion Draw gaze cross on image

                                       // myGlass.fullScreenImage mFull_Img = new fullScreenImage((Bitmap)bitmap);
                                       // mFull_Img.ShowDialog();

                                        METState.Current.METCoreObject.SendToForm(bitmap, "imScene");
                                                                        

                                        METState.Current.GlassFrontView_Resolution = new Size(bitmap.Width, bitmap.Height);
                                        
                                        

                                        snapshot = 0;
                                    }
                                    else
                                    {
                                        mode = Mode.mainLoop;

                                        METState.Current.GlassFrontView_Resolution = new Size(bitmap.Width, bitmap.Height);

                                        Point result = processImg(bitmap, METState.Current.EyeToScene_Mapping.CalibrationTarget + 1);// this function should be able to detect one or n points otherwise it returns -1
                                        // Point result = processImg(bitmap, numberOfPictures);// this function should be able to detect one or n points otherwise it returns -1


                                        if (result.X != -1 && result.Y != -1)//if !(-1,-1) :if target is detected in the image
                                        {



                                            METState.Current.EyeToScene_Mapping.GazeErrorX = 0;
                                            METState.Current.EyeToScene_Mapping.GazeErrorY = 0;

                                            if (METState.Current.EyeToScene_Mapping.CalibrationTarget < numberOfPictures)
                                            {

                                                failedBlobDetectionCount = 0;

                                                METState.Current.EyeToScene_Mapping.ScenePoints.Add(new AForge.Point(result.X, result.Y));
                                                METState.Current.EyeToScene_Mapping.Destination[0, METState.Current.EyeToScene_Mapping.CalibrationTarget] = result.X;///METState.Current.Kw_SceneImg;
                                                METState.Current.EyeToScene_Mapping.Destination[1, METState.Current.EyeToScene_Mapping.CalibrationTarget] = result.Y;///METState.Current.Kh_SceneImg;



                                                METState.Current.EyeToScene_Mapping.CalibrationTarget++;


                                                if (METState.Current.EyeToScene_Mapping.CalibrationTarget == numberOfPictures)
                                                {
                                                    server.Send(myGlass.MessageType.toGLASS_Calibrate_Scene, new Point(-2, -2));//point x (th) of y (total)

                                                    METState.Current.EyeToScene_Mapping.CalibrationTarget = 0;
                                                    METState.Current.EyeToScene_Mapping.Calibrate();


                                                    METState.Current.EyeToScene_Mapping.Calibrated = true;


                                                }
                                                else
                                                {
                                                    //tell the user to look at the next target
                                                    server.Send(myGlass.MessageType.toGLASS_Calibrate_Scene, new Point(-4, -4));//point x (th) of y (total)

                                                    //wait between points
                                                    Thread.Sleep(wait);//??

                                                    //take picture
                                                    server.Send(myGlass.MessageType.toGLASS_Calibrate_Scene, new Point(METState.Current.EyeToScene_Mapping.CalibrationTarget + 1, numberOfPictures));//point x (th) of y (total)
                                                    //get eye sample
                                                    METState.Current.EyeToScene_Mapping.Source[0, METState.Current.EyeToScene_Mapping.CalibrationTarget] = METState.Current.eyeFeature.X;
                                                    METState.Current.EyeToScene_Mapping.Source[1, METState.Current.EyeToScene_Mapping.CalibrationTarget] = METState.Current.eyeFeature.Y;
                                                }

                                            }

                                        }
                                        else if (result.X == -1 && result.Y == -1)
                                        {
                                            failedBlobDetectionCount++;

                                            if (failedBlobDetectionCount <= failedBlobDetectionCount_Max)
                                            {
                                                //tell the user to look at the next target
                                                server.Send(myGlass.MessageType.toGLASS_Calibrate_Scene, new Point(-5, -5));//point x (th) of y (total)

                                                //wait between points
                                                Thread.Sleep(wait);

                                                //take the sample again
                                                //take picture
                                                server.Send(myGlass.MessageType.toGLASS_Calibrate_Scene, new Point(METState.Current.EyeToScene_Mapping.CalibrationTarget + 1, numberOfPictures));//point x (th) of y (total)
                                                //get eye sample
                                                METState.Current.EyeToScene_Mapping.Source[0, METState.Current.EyeToScene_Mapping.CalibrationTarget] = METState.Current.eyeFeature.X;
                                                METState.Current.EyeToScene_Mapping.Source[1, METState.Current.EyeToScene_Mapping.CalibrationTarget] = METState.Current.eyeFeature.Y;

                                            }
                                            else
                                            {
                                                failedBlobDetectionCount = 0;
                                                //Calibration terminated!
                                                server.Send(myGlass.MessageType.toGLASS_Calibrate_Scene, new Point(-3, -3));//point x (th) of y (total)


                                            }
                                        }
                                        //
                                    }
                                }
                                else if (prg == -1)
                                {

                                    mode = Mode.mainLoop;
                                }



                            }
                            break;
                    }


                }
                catch (IOException exception)
                {

                    break;

                }
            }
            while (cnt==0 && !msg.StartsWith("CLIENT>>> TERMINATE") && tcpClient.Client.Connected); //cnt < 10 &&

            // close the socket connection
            finish( "Client has disconnected!!!!");
             
                METState.Current.METCoreObject.SendToForm("*********************************************\r\n", "tbOutput");


        }

        private void finish(String msg)
        {
            try
            {
                METState.Current.METCoreObject.SendToForm( msg , "tbOutput");


                
                //server.remoteEP = null;
               // server.sendSocket.Disconnect(true);
                //server.sendSocket.Close();
                server.udpServer.Close();
               // server.udpServer = null;

            }
            catch (Exception e)
            { }

            try { 
            tcpClient.Client.Close();
           // socketStream.Close();
            tcpClient.Close();
            }
            catch (Exception e)
            { }
        }
            int wait = 4000;
        private void interpretMSG(byte[] msg)
        {
            // we can insure that this is a correct msg by if(GetIndicator(msg)==GetX(msg))
            int indicator=GetIndicator(msg);
            switch (indicator)
            {

                case MessageType.toHAYTHAM_READY:

                    {
                        myGlassReady_State = Ready_State.Yes;
                    }

                    break;
                case MessageType.toHAYTHAM_Calibrate_Display_Finished:
                    {
                        myGlassReady_State = Ready_State.Finished;

                    }

                    break;
                case MessageType.toHAYTHAM_SceneCalibrationReady://The client reurns this msg after it received "Calibrate scene" from Haytham and when the user is ready
                    {
                        // calibratingScene_State = CalibratingScene_State.none;//We wait for an msg from the client saying that the picture is ready to send to the Haytham


                        //wait for the user to fixate on the first target
                        Thread.Sleep(wait);

                        //get eye sample
                        METState.Current.EyeToScene_Mapping.Source[0, METState.Current.EyeToScene_Mapping.CalibrationTarget] = METState.Current.eyeFeature.X;
                        METState.Current.EyeToScene_Mapping.Source[1, METState.Current.EyeToScene_Mapping.CalibrationTarget] = METState.Current.eyeFeature.Y;


                        //take the first picture 
                        server.Send(myGlass.MessageType.toGLASS_Calibrate_Scene, new Point(METState.Current.EyeToScene_Mapping.CalibrationTarget + 1, numberOfPictures));//point x (th) of y (total)





                    }
                    break;
                case MessageType.toHAYTHAM_Calibrate_Scene_4:
                    {



                        METState.Current.GlassServer.client.numberOfPictures = 4;
                        METState.Current.EyeToScene_Mapping.CalibrationType = Calibration.calibration_type.calib_Homography;


                        METState.Current.EyeToScene_Mapping.ScenePoints = new List<AForge.Point>();
                        METState.Current.EyeToScene_Mapping.GazeErrorX = 0;
                        METState.Current.EyeToScene_Mapping.GazeErrorY = 0;


                        METState.Current.EyeToScene_Mapping.CalibrationTarget = 0;
                        METState.Current.EyeToScene_Mapping.Calibrated = false;// ta click rooye scene noghtegiri shavad na eslah

                        METState.Current.GlassServer.Send(myGlass.MessageType.toGLASS_Calibrate_Scene, new Point(-1, -1));
                        Thread.Sleep(2000);//??

                    }
                    break;
                case MessageType.toHAYTHAM_Calibrate_Display_4:
                    {

                        int n = 2;
                        METState.Current.EyeToRemoteDisplay_Mapping.CalibrationType = Calibration.calibration_type.calib_Homography;


                        METState.Current.GlassServer.Send(myGlass.MessageType.toGLASS_Calibrate_Display, new Point(-1, -1));//only show the msg to the user not the point
                        Thread.Sleep(3000);//??


                        METState.Current.EyeToRemoteDisplay_Mapping.GazeErrorX = 0;
                        METState.Current.EyeToRemoteDisplay_Mapping.GazeErrorY = 0;


                        METState.Current.EyeToRemoteDisplay_Mapping.CalibrationTarget = 0;
                        METState.Current.EyeToRemoteDisplay_Mapping.Calibrated = false;



                        ///Set the METState.Current.RemoteOrHeadMount 
                        Rectangle rect = new Rectangle(0, 0, myGlass.constants.display_W, myGlass.constants.display_H);

   

                        METState.Current.remoteCalibration = new RemoteCalibration(n, n, rect); ;

                        //...Here you can send some commands to HMD if you want to show something there
                        // METState.Current.remoteCalibration.ShowDialog();


                    }
                    break;
                case MessageType.toHAYTHAM_Calibrate_Display_Correct:
                    {

                        if (METState.Current.EyeToRemoteDisplay_Mapping.Calibrated)
                        {

                            METState.Current.GlassServer.Send(myGlass.MessageType.toGLASS_Calibrate_Display, new Point(-3, -3));//Look at the white circle


                            Thread.Sleep(4000);//??

                            AForge.Point Gaze = METState.Current.EyeToRemoteDisplay_Mapping.Map(METState.Current.eyeFeature.X, METState.Current.eyeFeature.Y, 320, 180);

                            METState.Current.EyeToRemoteDisplay_Mapping.GazeErrorX = Gaze.X;// / METState.Current.Kw_SceneImg);
                            METState.Current.EyeToRemoteDisplay_Mapping.GazeErrorY = Gaze.Y;// / METState.Current.Kh_SceneImg);


                            METState.Current.GlassServer.Send(myGlass.MessageType.toGLASS_Calibrate_Display, new Point(-3, -4));//done!
                        }
                        else
                        {
                            METState.Current.GlassServer.Send(myGlass.MessageType.toGLASS_ERROR_NOTCalibrated);

                        }

                    }
                    break;
                case MessageType.toHAYTHAM_SnapshotComming:
                    {
                        METState.Current.Gaze_SnapShot_Glass = METState.Current.Gaze_HMGT;
                        #region ready to get the picture
                        snapshot = 1;


                        #endregion

                    }
                    break;
                case MessageType.toHAYTHAM_JsonComming:
                    {
                        #region ready to get the picture
                        
                        METState.Current.METCoreObject.SendToForm(0, "progressbar");

                        dataOutputStream = new MemoryStream();

                        mode = Mode.waitingForJSON_size;

                        #endregion

                    }
                    break;
                case MessageType.toHAYTHAM_HeadderComming:
                    {
                        #region ready to get the picture
                        ////Reset varables
                        headerBytes = new byte[22];
                        digest = new byte[16];
                        headerIndex = 0;
                        result = new byte[1];
                        count = 0;
                        METState.Current.METCoreObject.SendToForm(0, "progressbar");

                        dataOutputStream = new MemoryStream();
                        //message = Encoding.ASCII.GetBytes("PauseGeneralReceive");
                        //socketStream.Write(message,0,message.Length);

                        mode = Mode.waitingForHeader;

                        #endregion

                    }
                    break;
                case MessageType.toHAYTHAM_StreamGaze_RGT_START:
                    {
                        METState.Current.GlassServer.gazeStream_RGT = myGlass.Server.GazeStream.RGT;
                    }
                    break;
                case MessageType.toHAYTHAM_StreamGaze_HMGT_START:
                    {
                        METState.Current.GlassServer.gazeStream_HMGT = myGlass.Server.GazeStream.HMGT;
                    }
                    break;
                case MessageType.toHAYTHAM_StreamGaze_HMGT_STOP:
                    {
                        METState.Current.GlassServer.gazeStream_HMGT = myGlass.Server.GazeStream.NoStreaming;
                    }
                    break;
                case MessageType.toHAYTHAM_StreamGaze_RGT_STOP:
                    {
                        METState.Current.GlassServer.gazeStream_RGT = myGlass.Server.GazeStream.NoStreaming;
                    }
                    break;
                default:
                    {

                        
                            

                    }
                    break;
            }




        }
        private Point processImg(Image img, int num)
        {




            Haytham.Glass.SceneImage test = new Haytham.Glass.SceneImage();

            Point testPoint = test.getCalibrationTarget(img, 200, num, false);

            METState.Current.METCoreObject.SendToForm(test.result_Image, "imScene");

            return testPoint;
        }

        private int getHeader()
        {
            int progress = 0;//0:progress 1:successfuly finished  -1:Failed

            try
            {
                //handle server connection
                byte[] received = new byte[1];
                socketStream.Read(received, 0, received.Length);

                headerBytes[headerIndex] = received[0];


                METState.Current.METCoreObject.SendToForm("Header Received: " + headerIndex + "bytes", "tbOutput");
                headerIndex = headerIndex + 1;
                if (headerIndex >= 22)
                {
                    if ((ToHex(headerBytes[0]) == constants.HEADER_MSB) && (ToHex(headerBytes[1]) == constants.HEADER_LSB))
                    {


                        GetProgressData(headerBytes);

                        digest = GetDigest(headerBytes);

                        METState.Current.METCoreObject.SendToForm("Total ProgressData:" + progressData_Total, "tbOutput");

                        progress = 1;
                    }
                    else
                    {
                        progress = -1;
                        METState.Current.METCoreObject.SendToForm("Did not receive correct header.  Closing socket", "tbOutput");

                        //Handle invalid header hear. 
                        // message = Encoding.ASCII.GetBytes(MessageType.INVALID_HEADER);
                        //mStream.Write(message, 0, message.Length);

                    }


                }


            }
            catch (IOException e)
            {
                progress = -1;

            }
            return progress;
        }

        private int getPicture()
        {
            int progress = 0;//0:progress 1:successfuly finished  -1:Failed

            try
            {
                //// Read the data from the stream in chunks
                byte[] buffer = new byte[constants.CHUNK_SIZE];
                //updateUI("Waiting for data.  Expecting " + progressData_Remaining + " more bytes.");
                int bytesRead = socketStream.Read(buffer, 0, buffer.Length);

                count++;
                int prg = 100 - (int)((progressData_Remaining / progressData_Total) * 100.0);

                METState.Current.METCoreObject.SendToForm("(" + prg + "%) : Read " + bytesRead + " bytes into buffer", "tbOutput");
                METState.Current.METCoreObject.SendToForm(prg, "progressbar");


                dataOutputStream.Write(buffer, 0, bytesRead);

                //dataOutputStream.WriteByte(buffer);


                progressData_Remaining -= bytesRead;

                if (progressData_Remaining <= 0)
                {
                    // check the integrity of the data
                    byte[] data = dataOutputStream.ToArray();

                    byte[] receivedDigest = GetMd5Hash(data);
                    socketStream.Write(receivedDigest, 0, receivedDigest.Length);
                    socketStream.Flush();

                    // check the integrity of the data
                    if (digestMatch(receivedDigest, digest))
                    {

                        METState.Current.METCoreObject.SendToForm("Picture received", "tbOutput");
                        METState.Current.METCoreObject.SendToForm(0, "progressbar");

                        bitmap = Image.FromStream(dataOutputStream);

                     

                        string folder = @"fromGlass\Images\";

                        if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

                        String photoTime = DateTime.Now.ToString("mm.ss");
                        String SuspiciousPath = Path.Combine(folder, photoTime + ".jpg");
                        // bitmap.Save(SuspiciousPath);

    
                        dataOutputStream.Flush();
                        dataOutputStream.Close();
                        progress = 1;


                    }
                    else
                    {

                        METState.Current.METCoreObject.SendToForm("Data NOT received completely!", "tbOutput");

                        progress = -1;
                    }


                }
            }
            catch (IOException e)
            {
                progress = -1;
            }
            return progress;
        }

        private int getJson()
        {
            int progress = 0;//0:progress 1:successfuly finished  -1:Failed

            try
            {
                //// Read the data from the stream in chunks
                byte[] buffer = new byte[constants.CHUNK_SIZE];
                //updateUI("Waiting for data.  Expecting " + progressData_Remaining + " more bytes.");
                int bytesRead = socketStream.Read(buffer, 0, buffer.Length);

                
                int prg = 100 - (int)((progressData_Remaining / progressData_Total) * 100.0);

                METState.Current.METCoreObject.SendToForm("(" + prg + "%) : Read " + bytesRead + " bytes into buffer", "tbOutput");
                METState.Current.METCoreObject.SendToForm(prg, "progressbar");

                progressData_Remaining -= bytesRead;

                if (progressData_Remaining>=0) dataOutputStream.Write(buffer, 0, bytesRead);
                else dataOutputStream.Write(buffer, 0, (int)(bytesRead - Math.Abs(progressData_Remaining)));

                //dataOutputStream.WriteByte(buffer);


               
                if (progressData_Remaining <= 0)
                {
                    // check the integrity of the data
                    byte[] data = dataOutputStream.ToArray();

                    String jsonString = Encoding.UTF8.GetString(data);//didn't help     .TrimEnd('\0');                    

                    var json_serializer = new JavaScriptSerializer();

                    string folder = @"fromGlass\Jsons\";
                    if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

                    {
           
                    }{
                  
                    }{
                        myJsonClass mjson = new myJsonClass();
                        mjson = json_serializer.Deserialize<myJsonClass>(jsonString);
                        if (mjson.img != null)
                        {
                            String SuspiciousPath = Path.Combine(folder, mjson.name + ".jpg");
                            mjson.img.Save(SuspiciousPath);
                        }
                        myJsonClass_test temp = new myJsonClass_test(mjson);
                        System.Web.Script.Serialization.JavaScriptSerializer jSearializer =
                        new System.Web.Script.Serialization.JavaScriptSerializer();
                        String s = jSearializer.Serialize(temp);
                        System.IO.File.WriteAllText(Path.Combine(folder, temp.name + ".txt"), s);

                        METState.Current.METCoreObject.SendToForm(mjson.img, "imScene");
                        METState.Current.METCoreObject.SendToForm("", "Update Glass Picturebox");

                    }

                    METState.Current.METCoreObject.SendToForm("Picture received", "tbOutput");
                    METState.Current.METCoreObject.SendToForm(0, "progressbar");



                    dataOutputStream.Flush();
                    dataOutputStream.Close();
                    progress = 1;



                }
            }
            catch (IOException e)
            {
                progress = -1;
            }
            return progress;
        }


        public int GetIndicator(byte[] a)
        {
            byte[] ret = new byte[4];
            Array.Copy(a, 0, ret, 0, 4);
            return byteArrayToInt(ret);
        }
        public int GetX(byte[] a)
        {
            byte[] ret = new byte[4];
            Array.Copy(a, 4, ret, 0, 4);
            return byteArrayToInt(ret);
        }

        public int GetY(byte[] a)
        {
            byte[] ret = new byte[4];
            Array.Copy(a, 8, ret, 0, 4);
            return byteArrayToInt(ret);
        }
        public int GetIP(byte[] a)
        {
            byte[] ret = new byte[8];
            Array.Copy(a, 4, ret, 0, 8);
            return byteArrayToInt(ret);
        }

        public int byteArrayToInt(byte[] b)
        {
            if (BitConverter.IsLittleEndian) Array.Reverse(b);

            return BitConverter.ToInt32(b, 0);
        }
        public bool digestMatch(byte[] digestData2, byte[] digestData)
        {
            return Enumerable.SequenceEqual(digestData2, digestData);
        }
        public byte[] GetMd5Hash(byte[] input)
        {
            MD5 md5Hash = MD5.Create();
            // Convert the input string to a byte array and compute the hash.
            byte[] digest = md5Hash.ComputeHash(input);

            return digest;
        }
        private void GetProgressData(byte[] received)
        {
            var subset = new byte[6 - 2];
            Array.Copy(received, 2, subset, 0, 6 - 2);
            Array.Reverse(subset);
            progressData_Total = BitConverter.ToInt32(subset, 0);
            progressData_Remaining = BitConverter.ToInt32(subset, 0);
            Console.WriteLine(progressData_Total);
        }
        private byte[] GetDigest(byte[] received)
        {
            var subset = new byte[22 - 6];
            Array.Copy(received, 6, subset, 0, 22 - 6);
            //Array.Reverse(subset);
            return subset;


        }

        private static string ToHex(int value)
        {
            return String.Format("0x{0:X}", value);
        }

        private static int IDFromHex(string HexID)
        {
            return int.Parse(HexID, System.Globalization.NumberStyles.HexNumber);
        }


    }
}