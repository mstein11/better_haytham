// ------------------------------------------------------------------------
// <copyright file="Client.cs" company="ITU">
// This file is part of Haytham 
// Copyright (C) 2012 Diako Mardanbegi
// ------------------------------------------------------------------------
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.

// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.

// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
// ------------------------------------------------------------------------
// </copyright>
// <author>Diako Mardanbegi</author>
// <email>dima@itu.dk</email>
// <modifiedby>Adrian Voßkühler (adrian@.net)</modifiedby>
// ------------------------------------------------------------------------
namespace Haytham
{
  using System;
  using System.Collections.Generic;
  using System.Drawing;
  using System.IO;
  using System.Net.Sockets;
  using System.Windows.Forms;

  using Haytham.ExtData.Service;

  /// <summary>
  /// </summary>
  public class Client
  {
    #region Fields

    /// <summary>
    ///   Socket for accepting a connection
    /// </summary>
    private readonly Socket connection;

    /// <summary>
    ///   The reader facilitates reading from the stream
    /// </summary>
    private readonly BinaryReader reader;

    /// <summary>
    ///   The reference to server
    /// </summary>
    private readonly Server server;

    /// <summary>
    ///   The socket network data stream
    /// </summary>
    private readonly NetworkStream socketStream;

    /// <summary>
    ///   The screen to display calibration and track gaze data on.
    /// </summary>
    private Screen presentationScreen;

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
    public Client(Socket socket, Server serverValue)
    {
      this.connection = socket;
      this.UserData = new Dictionary<string, string>();
      this.Status = new Dictionary<string, bool>
                      {
                        { "_Commands", false }, 
                        { "_Gaze", false }, 
                        { "_Eye", false }, 
                        { "_Volume", false }, 
                        { "_VisualMarker", false }
                      };

      // create NetworkStream object for Socket
      this.socketStream = new NetworkStream(this.connection);

      // create Streams for reading/writing bytes
      this.Writer = new BinaryWriter(this.socketStream);
      this.reader = new BinaryReader(this.socketStream);
      this.server = serverValue;

      try
      {
        this.ClientType = this.reader.ReadString();
        this.ClientName = this.reader.ReadString();

        this.ClientName = this.server.DetermineClientName(this.ClientName, this.ClientType);
      }
      catch (Exception)
      {
        this.ClientName = string.Empty;
      }

      if (this.ClientName == string.Empty)
      {
        this.Writer.Write("ERROR");
      }
    }

    #endregion

    #region Public Properties

    /// <summary>
    ///   Gets or sets the client name
    /// </summary>
    public string ClientName { get; set; }

    /// <summary>
    ///   Gets or sets the client type
    /// </summary>
    public string ClientType { get; set; }

    /// <summary>
    ///   Gets or sets the height of the screen
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    ///   Gets or sets the status
    /// </summary>
    public Dictionary<string, bool> Status { get; set; }

    /// <summary>
    ///   Gets or sets the user data
    /// </summary>
    public Dictionary<string, string> UserData { get; set; }

    /// <summary>
    ///   Gets or sets the width of the screen
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    ///   Gets or sets the writer that facilitates writing to the stream
    /// </summary>
    public BinaryWriter Writer { get; set; }

    #endregion

    #region Public Methods and Operators

    /// <summary>
    ///   Runs this instance.
    /// </summary>
    public void Run()
    {
      this.Writer.Write(this.ClientName);

      string theReply;
      do
      {
        try
        {
          // read the string sent to the server
          // wait for message
          theReply = this.reader.ReadString();

          if (theReply == "Status_Commands")
          {
            this.Status["_Commands"] = Convert.ToBoolean(this.reader.ReadString());
          }

          if (theReply == "Status_Gaze")
          {
            this.Status["_Gaze"] = Convert.ToBoolean(this.reader.ReadString());
          }

          if (theReply == "Status_Eye")
          {
            this.Status["_Eye"] = Convert.ToBoolean(this.reader.ReadString());
          }

          if (theReply == "Status_Volume")
          {
            this.Status["_Volume"] = Convert.ToBoolean(this.reader.ReadString());
          }

          if (theReply == "Status_VisualMarker")
          {
            this.Status["_VisualMarker"] = Convert.ToBoolean(this.reader.ReadString());
          }

          if (theReply.StartsWith("UserData"))
          {
            this.GetUserData(theReply);
          }

          if (theReply == "Size")
          {
            this.Width = this.reader.ReadInt32();
            this.Height = this.reader.ReadInt32();
            this.server.DisplayMessage(
              "\r\n resolution of " + this.ClientName + ": " + this.Width + "x" + this.Height + "\r\n");
          }

          if (theReply == "Calibrate")
          {
            string method = this.reader.ReadString();
            var methodreal = Enum.Parse(typeof(CalibrationMethod), method);

            this.Calibrate((CalibrationMethod)methodreal);
          }

          if (theReply == "PresentationScreen")
          {
            bool screenIsPrimary = this.reader.ReadBoolean();

            if (screenIsPrimary)
            {
              this.presentationScreen = Screen.PrimaryScreen;
            }
            else
            {
              foreach (Screen screen in Screen.AllScreens)
              {
                if (screen.Primary == false)
                {
                  this.presentationScreen = screen;
                }
              }
            }

          }
        }
        catch (Exception)
        {
          // handle exception if error reading data
          break;
        }
      }
      while (theReply != "CLIENT>>> TERMINATE" && this.connection.Connected);

      // close the socket connection
      this.Writer.Close();
      this.reader.Close();
      this.socketStream.Close();
      this.connection.Close();
      this.server.DisplayMessage("\r\n" + this.ClientName + " disconnected \r\n");
      this.server.DisplayMessage("*********************************************\r\n");
      this.server.RemoveClient(this.ClientName);
    }

    #endregion

    #region Methods

    /// <summary>
    /// Calls the correct calibration method.
    /// </summary>
    /// <param name="method">
    /// One of the calibraton methods.
    /// </param>
    private void Calibrate(CalibrationMethod method)
    {
      switch (METState.Current.remoteOrMobile)
      {
        case METState.RemoteOrMobile.RemoteEyeTracking:
          this.CalibrateRemote(method);
          break;
        case METState.RemoteOrMobile.MobileEyeTracking:
          this.CalibrateMobile(method);
          break;
        case METState.RemoteOrMobile.GoogleGalss:
          this.CalibrateGlass(method);
          break;
      }
    }

    /// <summary>
    /// Calls calibration for mobile tracking mode
    /// </summary>
    /// <param name="method">
    /// One of the calibraton methods.
    /// </param>
    private void CalibrateMobile(CalibrationMethod method)
    {
      METState.Current.EyeToScene_Mapping.ScenePoints = new List<AForge.Point>();
      METState.Current.EyeToScene_Mapping.GazeErrorX = 0;
      METState.Current.EyeToScene_Mapping.GazeErrorY = 0;
      METState.Current.EyeToScene_Mapping.CalibrationTarget = 0;
      METState.Current.EyeToScene_Mapping.Calibrated = false;

      switch (method)
      {
        case CalibrationMethod.Point4:
          MessageBox.Show(
            "Click on 4 points in the scene image while the user is looking at the corresponding points in the field of view");
          METState.Current.EyeToScene_Mapping.CalibrationType = Calibration.calibration_type.calib_Homography;
          break;
        case CalibrationMethod.Point9:
          MessageBox.Show(
            "Click on 9 points in the scene image while the user is looking at the corresponding points in the field of view");
          METState.Current.EyeToScene_Mapping.CalibrationType = Calibration.calibration_type.calib_Polynomial;
          break;
      }
    }

    /// <summary>
    /// Calls calibration for remote tracking mode
    /// </summary>
    /// <param name="method">
    /// One of the calibraton methods.
    /// </param>
    private void CalibrateGlass(CalibrationMethod method)
    {
        METState.Current.EyeToRemoteDisplay_Mapping.GazeErrorX = 0;
        METState.Current.EyeToRemoteDisplay_Mapping.GazeErrorY = 0;
      METState.Current.EyeToRemoteDisplay_Mapping.CalibrationTarget = 0;
      METState.Current.EyeToRemoteDisplay_Mapping.Calibrated = false;

      switch (method)
      {
        case CalibrationMethod.Point4:
          METState.Current.EyeToRemoteDisplay_Mapping.CalibrationType = Calibration.calibration_type.calib_Homography;
          METState.Current.remoteCalibration = new RemoteCalibration(2, 2, this.presentationScreen.Bounds);
          break;
        case CalibrationMethod.Point9:
          METState.Current.EyeToRemoteDisplay_Mapping.CalibrationType = Calibration.calibration_type.calib_Polynomial;
          METState.Current.remoteCalibration = new RemoteCalibration(3, 3, this.presentationScreen.Bounds);
          break;
      }

     // METState.Current.remoteCalibration.ShowDialog();
      this.Writer.Write("CalibrationFinished");
    }
    private void CalibrateRemote(CalibrationMethod method)
    {
        METState.Current.EyeToRemoteDisplay_Mapping.GazeErrorX = 0;
        METState.Current.EyeToRemoteDisplay_Mapping.GazeErrorY = 0;
        METState.Current.EyeToRemoteDisplay_Mapping.CalibrationTarget = 0;
        METState.Current.EyeToRemoteDisplay_Mapping.Calibrated = false;

        switch (method)
        {
            case CalibrationMethod.Point4:
                METState.Current.EyeToRemoteDisplay_Mapping.CalibrationType = Calibration.calibration_type.calib_Homography;
                METState.Current.remoteCalibration = new RemoteCalibration(2, 2, this.presentationScreen.Bounds);
                break;
            case CalibrationMethod.Point9:
                METState.Current.EyeToRemoteDisplay_Mapping.CalibrationType = Calibration.calibration_type.calib_Polynomial;
                METState.Current.remoteCalibration = new RemoteCalibration(3, 3, this.presentationScreen.Bounds);
                break;
        }

        
        this.Writer.Write("CalibrationFinished");
    }
    /// <summary>
    /// Gets the user data.
    /// </summary>
    /// <param name="msg">
    /// The MSG.
    /// </param>
    private void GetUserData(string msg)
    {
      // var xxx = msg.Split('|').Skip(1);
      string temp = string.Empty;
      var msgArr = new List<string>();

      foreach (char t in msg)
      {
        if (t == '|')
        {
          msgArr.Add(temp);
          temp = string.Empty;
        }
        else
        {
          temp += t;
        }
      }

      msgArr.RemoveAt(0); // remove the keyword from the begining

      if (this.UserData.ContainsKey(msgArr[0]))
      {
        this.UserData[msgArr[0]] = msgArr[1];
      }
      else
      {
        this.UserData.Add(msgArr[0], msgArr[1]);
      }
    }

    #endregion
  }
}