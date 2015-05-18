
//<copyright file="RemoteCalibration.cs" company="ITU">
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Haytham
{
    public  class RemoteCalibration 
    {

        public Timer timerSpeed = new Timer();
        public Dictionary<int, Point> calibPoints = new Dictionary<int, Point>();

        public AnimatedCursor mycursor;


        public Rectangle PresentationScreen;

        private void setPoints(int n, int m)// grid of n*m points
        {
            int offset = 100; //pixel offset from the borders of the screen




            int count = 1;
            for (int i = 0; i < n; i++)
            {


                for (int j = 0; j < m; j++)
                {
                    calibPoints[count] = new Point(((PresentationScreen.Width - 2 * offset) / (m - 1)) * j + offset, ((PresentationScreen.Height - 2 * offset) / (n - 1)) * i + offset);

                    calibPoints[count] = Point.Add(calibPoints[count], new Size(PresentationScreen.Left, PresentationScreen.Top));

                    count++;
                }

            }



        }
        public RemoteCalibration(int n, int m, Rectangle rect)
        {

            PresentationScreen = rect;
            setPoints(n, m);

  

            System.Threading.Thread run_thread = new System.Threading.Thread(new System.Threading.ThreadStart(Run));
            run_thread.Start();


    

        }

        void Run()
        {

            mycursor = new AnimatedCursor();
            mycursor.coordinates = calibPoints[1];

            if (METState.Current.remoteOrMobile == METState.RemoteOrMobile.GoogleGalss && METState.Current.GlassServer.client.myGlassReady_State == myGlass.Client.Ready_State.Yes)
            {
                METState.Current.GlassServer.client.myGlassReady_State = myGlass.Client.Ready_State.No;
                METState.Current.GlassServer.Send(myGlass.MessageType.toGLASS_Calibrate_Display, mycursor.coordinates);
            }

            METState.Current.mCursor.CursorShown = false;//hide cursor

            timerSpeed.Interval = 50;
            timerSpeed.Enabled = true;
            timerSpeed.Tick += new EventHandler(timerSpeed_Tick);
            mycursor.ShowDialog();

        }

        void timerSpeed_Tick(object sender, EventArgs e)
        {
            if (METState.Current.remoteOrMobile == METState.RemoteOrMobile.GoogleGalss
                &&( !Haytham.METState.Current.GlassServer.client.tcpClient.Connected
                || METState.Current.GlassServer.client.myGlassReady_State == myGlass.Client.Ready_State.Finished))
            {

                finish();

                timerSpeed.Enabled = false;
                return;
            }
              bool temp = mycursor.updatePointerImage();
                if (temp) getSample();
            

        }

        public void getSample()
        {

            if (METState.Current.remoteOrMobile == METState.RemoteOrMobile.GoogleGalss )
            {

     


                METState.Current.EyeToRemoteDisplay_Mapping.Destination[0, METState.Current.EyeToRemoteDisplay_Mapping.CalibrationTarget] = mycursor.coordinates.X;
                METState.Current.EyeToRemoteDisplay_Mapping.Destination[1, METState.Current.EyeToRemoteDisplay_Mapping.CalibrationTarget] = mycursor.coordinates.Y;

                METState.Current.EyeToRemoteDisplay_Mapping.Source[0, METState.Current.EyeToRemoteDisplay_Mapping.CalibrationTarget] = METState.Current.eyeFeature.X;
                METState.Current.EyeToRemoteDisplay_Mapping.Source[1, METState.Current.EyeToRemoteDisplay_Mapping.CalibrationTarget] = METState.Current.eyeFeature.Y;

                if (calibPoints.Count >= (METState.Current.EyeToRemoteDisplay_Mapping.CalibrationTarget + 2))
                {
                    mycursor.coordinates = calibPoints[METState.Current.EyeToRemoteDisplay_Mapping.CalibrationTarget + 2];
                    METState.Current.EyeToRemoteDisplay_Mapping.CalibrationTarget++;

                    
                    METState.Current.GlassServer.Send(myGlass.MessageType.toGLASS_Calibrate_Display, mycursor.coordinates);

                }
                else
                {
                   
                    METState.Current.GlassServer.Send(myGlass.MessageType.toGLASS_Calibrate_Display, new Point(-2, -2));


                    METState.Current.EyeToRemoteDisplay_Mapping.Calibrate();
                    METState.Current.EyeToRemoteDisplay_Mapping.Calibrated = true;


                    finish();

                    timerSpeed.Enabled = false;
                }
            
            }
            else if (METState.Current.remoteOrMobile == METState.RemoteOrMobile.RemoteEyeTracking) {

                METState.Current.EyeToRemoteDisplay_Mapping.Destination[0, METState.Current.EyeToRemoteDisplay_Mapping.CalibrationTarget] = mycursor.coordinates.X;
                METState.Current.EyeToRemoteDisplay_Mapping.Destination[1, METState.Current.EyeToRemoteDisplay_Mapping.CalibrationTarget] = mycursor.coordinates.Y;

                METState.Current.EyeToRemoteDisplay_Mapping.Source[0, METState.Current.EyeToRemoteDisplay_Mapping.CalibrationTarget] = METState.Current.eyeFeature.X;
                METState.Current.EyeToRemoteDisplay_Mapping.Source[1, METState.Current.EyeToRemoteDisplay_Mapping.CalibrationTarget] = METState.Current.eyeFeature.Y;

                if (calibPoints.Count >= (METState.Current.EyeToRemoteDisplay_Mapping.CalibrationTarget + 2))
                {
                    mycursor.coordinates = calibPoints[METState.Current.EyeToRemoteDisplay_Mapping.CalibrationTarget + 2];
                    METState.Current.EyeToRemoteDisplay_Mapping.CalibrationTarget++;

                  

                }
                else
                {
                   


                    METState.Current.EyeToRemoteDisplay_Mapping.Calibrate();
                    METState.Current.EyeToRemoteDisplay_Mapping.Calibrated = true;


                    finish();

                    timerSpeed.Enabled = false;
                }
            
            }


        
        }
        public void finish()
        {
            METState.Current.mCursor.CursorShown = true;
            //mycursor.Dispose();
            mycursor.Hide();


        }

      

    }
}
