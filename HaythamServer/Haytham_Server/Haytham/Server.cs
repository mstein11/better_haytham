
//<copyright file="Server.cs" company="ITU">
//This file is part of Haytham 
//Copyright (C) 2012 Diako Mardanbegi
// ------------------------------------------------------------------------
//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.

//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.

//You should have received a copy of the GNU General Public License
//along with this program.  If not, see <http://www.gnu.org/licenses/>.
// ------------------------------------------------------------------------
// </copyright>
// <author>Diako Mardanbegi</author>
// <email>dima@itu.dk</email>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace Haytham
{
    public class Server
    {


        public void RequestStop()
        {
            _shouldStop = true;
        }
        // Volatile is used as hint to the compiler that this data
        // member will be accessed by multiple threads.
        private volatile bool _shouldStop;


        public Dictionary<string, Client> clients = new Dictionary<string, Client>();
        public Dictionary<string, Thread> clientThreads = new Dictionary<string, Thread>();

        // private Client[] clients;
        // private Thread[] clientThreads; // Threads for client interaction
        private TcpListener listener; // listen for client connection
        private Thread getClientThread;
        internal bool disconnected = false; // true if the server closes
        public string activeScreen = "";
        public string ForcedActiveScreen = "";

        //delete

        public bool connected = false;


        // initialize variables and thread for receiving clients
        public Server()
        {

            // clients = new Client[2];
            //clientThreads = new Thread[2];

            // accept connections on a different thread
            getClientThread = new Thread(new ThreadStart(getClient));
            getClientThread.Start();
        }//end Server

        public void DisplayMessage(string message)
        {
            try
            {
                METState.Current.METCoreObject.SendToForm(message, "TextBoxServer");
            }
            catch (Exception e) { }

        } //end displayMessage

        private void getClient()
        {
            Thread.Sleep(2000);
            string ip = getip();

            METState.Current.ip = ip;

            METState.Current.METCoreObject.SendToForm("Server IP : " + ip, "lblIP");

            DisplayMessage("Server IP : " + ip + "\r\n");
            DisplayMessage("Waiting for connection\r\n");

            // set up Socket
            IPAddress localip = IPAddress.Parse(getip());//"192.168.50.176"

            listener = new TcpListener(localip, 50000);
            listener.Start();
            DisplayMessage("Waiting....\r\n");

            while (!_shouldStop)
            {

                Client tempClient;

                tempClient = new Client(listener.AcceptSocket(), this);

                if (tempClient.ClientName != "")
                {

                    //make a known client
                    if (clients.ContainsKey(tempClient.ClientName)) { clients[tempClient.ClientName] = tempClient; }
                    else { clients.Add(tempClient.ClientName, tempClient); }

                    //make a thread for this client
                    if (clientThreads.ContainsKey(tempClient.ClientName))
                    {
                        //stop previous thread!!
                        //
                        clientThreads[tempClient.ClientName] = new Thread(new ThreadStart(clients[tempClient.ClientName].Run));
                    }
                    else { clientThreads.Add(tempClient.ClientName, new Thread(new ThreadStart(clients[tempClient.ClientName].Run))); }
                    clientThreads[tempClient.ClientName].Start();
                    //DisplayMessage("one client connected \r\n");
                    DisplayMessage(tempClient.ClientName + "  is conected");
                    // DisplayMessage(tempClient.Width + "x" + tempClient.Height + "\r\n");
                    METState.Current.METCoreObject.SendToForm(tempClient.ClientName, "PanelClients_Add");
                }

            }
        }//end getClient

        public string DetermineClientName(string msg, string type)
        {
            string name = "";


            if (msg.StartsWith("?"))
            {
                for (int i = 1; i < 10; i++)
                {
                    if (clients.ContainsKey(type + i) == true)
                    {

                    }
                    else
                    {
                        name = type + i;
                        break;
                    }
                }
            }
            else
            {
                name = msg;
            }
           

            ///This version does not support multiple SerialPortSwitch, TV, and roomba
            if (name.StartsWith("SerialPortSwitch") && !name.StartsWith("SerialPortSwitch1")) name = "";
            if (name.StartsWith("TV") && !name.StartsWith("TV1")) name = "";
            if (name.StartsWith("Roomba") && !name.StartsWith("Roomba1")) name = "";  

            return name;
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

        public void RemoveClient(string name)
        {
            if (clients.ContainsKey(name))
            {

                METState.Current.METCoreObject.SendToForm(name, "PanelClients_Remove");

                clients[name] = null;
                clients.Remove(name);
                //clientThreads[name].Suspend();
                clientThreads.Remove(name);
                Thread.CurrentThread.Abort();//??????????????????????????????????????????????????????????
            }
        }//end RemoveClient


        public void Close()
        {

            RequestStop();

            //if (getClientThread.IsAlive) { getClientThread.Join(); }//getClientThread.Abort();
            //foreach (var pair in clientThreads)
            //{
            //    pair.Value.Join();//pair.Value.Abort();
            //}
            System.Environment.Exit(System.Environment.ExitCode);

        }


        public int CountMonitorClients()
        {
            int i = 0;
            foreach (KeyValuePair<string, Client> kvp in clients)
            {
                if (kvp.Value.ClientType == "Monitor") i++;
            }
            return i;
        }

        public int CountTVClients()
        {
            int i = 0;
            foreach (KeyValuePair<string, Client> kvp in clients)
            {
                if (kvp.Value.ClientType == "TV") i++;
            }
            return i;
        }
        public bool DoWeNeedToDetectVisualMarker()
        {
            bool yes=false;
            foreach (KeyValuePair<string, Client> kvp in clients)
            {
                if (kvp.Value.Status["_VisualMarker"])
                {
                    yes = true;
                    break;
                }
            }
            return yes;

        }

        public Dictionary<string, string> GetVisualMarkerNames()
        {
             Dictionary<string, string> MarkerNames = new Dictionary<string, string>();

            foreach (KeyValuePair<string, Client> kvp in clients)
            {
                if (kvp.Value.Status["_VisualMarker"])
                {

                    foreach (KeyValuePair<string, string> usrdataitem in kvp.Value.UserData)
                    {
                        if (usrdataitem.Key.StartsWith("Marker_6_"))
                        {
                            if (MarkerNames.ContainsKey(usrdataitem.Key)) MarkerNames[usrdataitem.Key] +=("["+ usrdataitem.Value+ "]");
                            else MarkerNames[usrdataitem.Key] = "[" + usrdataitem.Value + "]";

                        }
                    }
                
                }
            }
            return MarkerNames;
        
        
        }


        public bool GetCondition(string clientName, string condition)
        {
            bool temp = false;

            if (clients.Count() > 0)
            {

                condition = "_" + condition;
                if (clients.ContainsKey(clientName))
                {
                    temp = clients[clientName].Status.ContainsKey(condition) ? clients[clientName].Status[condition] : false;
                }
            }
            return temp;
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="msg"></param>
        public void Send(string key, string[] msg)
        {
            try
            {
                ///the message will be sent with a format similar to: "Gaze-125-156"
                string message = (key + MakeMessageString(msg));

                switch (key)
                {
                    case "Glyph":
                        foreach (KeyValuePair<string, Client> kvp in METState.Current.server.clients)
                        {
                            if (kvp.Value.ClientType == "Monitor")
                            {
                                clients[kvp.Value.ClientName].Writer.Write(message);

                            }
                        }
                        break;
                    case "Commands":
                        foreach (KeyValuePair<string, Client> kvp in METState.Current.server.clients)
                        {
                            if (GetCondition(kvp.Value.ClientName, key))
                            {
                                clients[kvp.Value.ClientName].Writer.Write(message);

                            }
                        }

                        break;
                    case "Gaze":
                        if (METState.Current.remoteOrMobile == METState.RemoteOrMobile.MobileEyeTracking)
                        {
                            if (activeScreen!="" && clients.ContainsKey(activeScreen) && GetCondition(activeScreen, key)) clients[activeScreen].Writer.Write(message);
                            else if (activeScreen != "" && clients.ContainsKey("TV1") && GetCondition("TV1", key)) clients["TV1"].Writer.Write(message);
                        }
                        else if (METState.Current.remoteOrMobile == METState.RemoteOrMobile.RemoteEyeTracking)
                        {
                            foreach (KeyValuePair<string, Client> kvp in METState.Current.server.clients)
                            {
                                if (kvp.Value.ClientType == "Monitor" && kvp.Value.Status["_Gaze"]) clients[kvp.Value.ClientName].Writer.Write(message);
                            }
                        }
                        break;
                    case "GazeInScene":
                       
                            foreach (KeyValuePair<string, Client> kvp in METState.Current.server.clients)
                            {
                                if (kvp.Value.ClientType == "Monitor" && kvp.Value.Status["_Gaze"]) clients[kvp.Value.ClientName].Writer.Write(message);
                            }
                        
                        break;
                    case "Eye":
                        if (METState.Current.remoteOrMobile == METState.RemoteOrMobile.MobileEyeTracking)
                        {
                          if (activeScreen != "" && clients.ContainsKey(activeScreen) && GetCondition(activeScreen, key)) clients[activeScreen].Writer.Write(message);
                          else if (activeScreen != "" && clients.ContainsKey("TV1") && GetCondition("TV1", key)) clients["TV1"].Writer.Write(message);
                        }
                        else if (METState.Current.remoteOrMobile == METState.RemoteOrMobile.RemoteEyeTracking)
                        {
                          foreach (KeyValuePair<string, Client> kvp in METState.Current.server.clients)
                          {
                            if (kvp.Value.ClientType == "Monitor" && kvp.Value.Status["_Eye"]) clients[kvp.Value.ClientName].Writer.Write(message);
                            }
                        }
                        break;
                    case "VisualMarker":
                    case "Volume":
                        foreach (KeyValuePair<string, Client> kvp in METState.Current.server.clients)
                        {
                            if (GetCondition(kvp.Value.ClientName, key))
                            {
                                clients[kvp.Value.ClientName].Writer.Write(message);

                            }
                        }

                        break;
                }
            }
            catch (Exception e)
            { }
        }


        /// <summary>
        /// Send a message to a specific client
        /// </summary>
        /// <param name="clientName"></param>Specify the client Name
        /// <param name="message"></param>Provide the message in a right format e.g.: "Gaze-121-203" OR "Commands-D_U"
        public void Send(string clientName, string message)
        {
            clients[clientName].Writer.Write((string)message);
        }




    }
}
