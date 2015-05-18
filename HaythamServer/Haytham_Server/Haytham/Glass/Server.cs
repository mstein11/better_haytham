

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Drawing;
using Haytham;
namespace myGlass
{
    public class Server
    {


        public void RequestStop()
        {
            _shouldStop_getClient = true;
        }
        // Volatile is used as hint to the compiler that this data
        // member will be accessed by multiple threads.
        private volatile bool _shouldStop_getClient;
        private volatile bool _shouldStop_AcceptSocket;

        public bool connected
        {
            get
            {

                if (client != null) return client.tcpClient.Connected;
                else return false;
            }

        }



        public string GlassIP="";


        public Client client;
        public Thread clientThread;
        private TcpListener tcpListener; // listen for client connection
       

        //UDP
        public UdpClient udpServer;
        public IPEndPoint remoteEP;
        public Socket sendSocket;

        private Thread getClientThread;

        public  enum GazeStream { HMGT, RGT, NoStreaming}
        public GazeStream gazeStream_HMGT = GazeStream.NoStreaming;
        public GazeStream gazeStream_RGT = GazeStream.NoStreaming;


       // public _SendToForm SendToForm;
        //public delegate void _METState.Current.METCoreObject.SendToForm(object message, string controlName);
        public enum State { connecting, connected}
        public State state = State.connecting;
        EndPoint tempRemoteEP;


        private MainForm mainForm;

        // initialize variables and thread for receiving clients
        public Server( MainForm m)
        {
            mainForm = m;
            // accept connections on a different thread
            getClientThread = new Thread(new ThreadStart(getClient2));
            getClientThread.Start();
        }//end Server



        public void setState(State s)
        {
            state = s;
            METState.Current.METCoreObject.SendToForm("state changed to " + s, "tbOutput");
        }


        private void getClient2()
        {



            Thread.Sleep(1000);
            string ip = getip();
            METState.Current.METCoreObject.SendToForm("Server IP : " + ip + "\r\n", "tbOutput");
            setState(State.connecting);

            ////TCP
            /// set up Socket
            IPAddress localip = IPAddress.Parse(ip);
            tcpListener = new TcpListener(localip, constants.SERVER_PORT);
            tcpListener.Start();



            //Start server
           
            //mSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            METState.Current.METCoreObject.SendToForm("Running server...", "tbOutput");
            METState.Current.METCoreObject.SendToForm("Waiting....\r\n", "tbOutput");
         

                            //client.tcpClient.Close();
                            //client = null;
            _shouldStop_getClient = false;




            while (!_shouldStop_getClient)
                            {
                                try
                                {



                                    ///////...........................
                                    //if (!tcpListener.Pending())
                                    //{
                                    //    //Thread.Sleep(500); // choose a number (in milliseconds) that makes sense
                                    //    continue; // skip to next iteration of loop
                                    //}
                                    //else // Enter here only if have pending clients
                                    //{


                                    //????????????????????????????
                                    //if (clientThread != null)
                                    //{
                                    //    client.tcpClient.Client.Disconnect(false);
                                    //    clientThread = null;
                                    //    METState.Current.METCoreObject.SendToForm("previous client closed!", "tbOutput");
                                    //    METState.Current.METCoreObject.SendToForm("*********************************************\r\n", "tbOutput");
                                    //}
                                    //????????????????????


                                   // Thread.Sleep(500);

                                    Thread.Sleep(500);
                                    Client tempClient;
                                    tempClient = new Client(tcpListener.AcceptTcpClient(), this);


                                    client = tempClient;
                                    clientThread = new Thread(new ThreadStart(client.Run));
                                    clientThread.Start();




                                    METState.Current.METCoreObject.SendToForm("Glass connected", "tbOutput");
                                    METState.Current.METCoreObject.SendToForm("Hide", "IPform");
                                    
                                    
                                    

                                


                                }

                                catch (IOException ex)
                                {

                                    continue; // skip to next iteration of loop
                                }

                            }

        }




        public string getip()
        {
            string localIP = "?";

            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();

                }
            }



            return localIP;

        }//end getip



        public void Close()
        {

            RequestStop();
            System.Environment.Exit(System.Environment.ExitCode);

        }



        //..................................................................................................
        private string MakeMessageString(string[] msg)
        {
            string m = "";
            foreach (string i in msg)
            {
                m += "|" + i;
            }
            m += "|";
            return m;
        }
        



        public void Send(int indicator, Point pnt)
    {
        if (connected)
        {
            try
            {
                byte[] i = BitConverter.GetBytes(indicator);
                byte[] x = BitConverter.GetBytes(pnt.X);
                byte[] y = BitConverter.GetBytes(pnt.Y);

                byte[] packed = new byte[constants.MSG_SIZE];//[indicator,x,x,x,x,y,y,y,y]

                Array.Copy(i, 0, packed, 0, i.Length);
                Array.Copy(x, 0, packed, 4, x.Length);
                Array.Copy(y, 0, packed, 8, y.Length);

                client.socketStream.Write(packed, 0, packed.Length);

                client.socketStream.Flush();
            }
            catch (Exception e)
            { 
            
            }
        }

    }

        public void SendGaze_via_UDP(int indicator, Point pnt)
        {
            if (connected)
            {
                try
                {

                    byte[] i = BitConverter.GetBytes(indicator);
                    byte[] x = BitConverter.GetBytes(pnt.X);
                    byte[] y = BitConverter.GetBytes(pnt.Y);

                    byte[] packed = new byte[constants.MSG_SIZE];//[indicator,x,x,x,x,y,y,y,y]

                    Array.Copy(i, 0, packed, 0, i.Length);
                    Array.Copy(x, 0, packed, 4, x.Length);
                    Array.Copy(y, 0, packed, 8, y.Length);




                    udpServer.Send(packed, packed.Length, remoteEP);
                    //sendSocket.Disconnect(true);
                    //sendSocket.Close();
                   // udpServer.Close();

                }
                catch (Exception e)
                {

                }
            }

        }


        public void Send(int indicator)
        {
            if (connected)
            {
                try
                {
                    byte[] i = BitConverter.GetBytes(indicator);


                    byte[] packed = new byte[constants.MSG_SIZE];//[i,i,i,i,x,x,x,x,y,y,y,y]

                    Array.Copy(i, 0, packed, 0, i.Length);
                    Array.Copy(i, 0, packed, 4, i.Length);
                    Array.Copy(i, 0, packed, 8, i.Length);

                    client.socketStream.Write(packed, 0, packed.Length);

                    client.socketStream.Flush();
                }
                catch (Exception e)
                {

                }
            }

        } 
        //public void Send(string message)
        //{
        //    if (connected)
        //    {
        //        ////method 1
        //        try
        //        {
        //            byte[] array = Encoding.ASCII.GetBytes(message);
        //            client.socketStream.Write(array, 0, array.Length);

        //            client.socketStream.Flush();
        //        }
        //        catch (IOException e)
        //        { 
                  
        //        }

        //        //// method 2

        //        //int toSendLen = System.Text.Encoding.ASCII.GetByteCount(message);
        //        //byte[] toSendBytes = System.Text.Encoding.ASCII.GetBytes(message);
        //        //byte[] toSendLenBytes = System.BitConverter.GetBytes(toSendLen);
        //        //mSocket.Send(toSendLenBytes);
        //        //mSocket.Send(toSendBytes);

        //    }
        //}


    }
}
