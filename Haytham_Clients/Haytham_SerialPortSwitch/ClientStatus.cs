using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Drawing;


namespace Haytham_Client
{

    public static class ClientStatus
    {
        //network
        public static Thread inputoutputThread; // Thread for receiving data from server
        public static IPAddress serverip;

        public static TcpClient client = new TcpClient();  // client to establish connection
        public static BinaryWriter writer; // facilitates writing to the stream
        public static BinaryReader reader; // facilitates reading from the strea  
        public static NetworkStream stream; // network data stream

        //
        public static string clientName;
        public static int clientIndex;

        public static int ScreenWidth;
        public static int ScreenHeight;
        public static Point ScreenTopLeft;
        public static Point gazePoint;

        public static Dictionary<string, string> userData = new Dictionary<string, string>();

        public static string   type="SerialPortSwitch";




        private static Dictionary<string, Boolean> status = new Dictionary<string, Boolean>()
	{

	            {"_Commands", false},
        	    {"_VisualMarker", false},

	};



  
        public static bool Commands { get { return status["_Commands"]; } set { status["_Commands"] = value;  if (client.Connected)writer.Write("Status_Commands"); writer.Write(status["_Commands"].ToString());} }

        public static bool VisualMarker { get { return status["_VisualMarker"]; } set { status["_VisualMarker"] = value; if (client.Connected)writer.Write("Status_VisualMarker"); writer.Write(status["_VisualMarker"].ToString()); } }




        public static void sendUserData(string key)
        {
            if (client.Connected)
            {
                writer.Write("UserData|" + key + "|" + userData[key] + "|");
            }
        }



        public static void UpdateServer()
        {

            if (client.Connected) { foreach (KeyValuePair<string, string> usrdataitem in userData) sendUserData(usrdataitem.Key); }
                Commands = Commands;
                VisualMarker = VisualMarker;

                
    
        }

        public static void Reconnect()
        {
            bool connected = false;

            do
            {
                try
                {
                    client = new TcpClient();

                    client.Connect(serverip, 50000);
                    stream = client.GetStream();
                    writer = new BinaryWriter(stream);
                    reader = new BinaryReader(stream);

                    //send name and type
                    writer.Write(type.ToString());//type
                    writer.Write(clientName);//name





                    clientName = reader.ReadString();//get approved name

                    UpdateServer();
                    connected = true;

                } // end try
                catch (Exception)
                {

                }
            } while ((!connected & clientName != "PauseReconnect"));
            if (clientName == "PauseReconnect")
            {
                client.Close();

                inputoutputThread.Abort();
            }

        }
        public static void Connect()
        {

            stream = client.GetStream();
            writer = new BinaryWriter(stream);
            reader = new BinaryReader(stream);


            //send name and type
            writer.Write(type.ToString());//type
            writer.Write("?");//name

            clientName = reader.ReadString();//get approved name
            clientIndex = int.Parse(clientName.Remove(0, type.ToString().Length));//"remove Monitor"
            


        }


    }

}
