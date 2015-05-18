
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
    public partial class RemoteCalibration : Form
    {


        public Dictionary<int, Point> calibPoints = new Dictionary<int, Point>();

        AnimatedCursor mycursor;

        public  int ScreenWidth;
        public  int ScreenHeight;
        public AForge.Point   ScreenTopLeft;

        private void setPoints(int n, int m)// grid of n*m points
        {
            int offset = 100; //pixel offset from the borders of the screen

             ScreenHeight = Screen.FromHandle(this.Handle).Bounds.Height;
             ScreenWidth = Screen.FromHandle(this.Handle).Bounds.Width;




            int count = 1;
            for (int i = 0; i < n; i++)
            {


                for (int j = 0; j < m; j++)
                {
                    calibPoints[count] = new Point(((ScreenWidth - 2 * offset) / (m-1)) * j + offset, ((ScreenHeight - 2 * offset )/ (n-1)) * i + offset);

                    calibPoints[count] = Point.Add(calibPoints[count], new Size(this.Left,this.Top ));

                    count++;
                }

            }



        }
        public RemoteCalibration(int n, int m, Rectangle rect)
        {
            InitializeComponent();

            ScreenWidth = rect.Width;
            ScreenHeight = rect.Height;
            ScreenTopLeft = new AForge.Point((float)rect.Left, (float)rect.Top);
            
            ChangeForm(rect, "this");
            setPoints(n, m);

        }
        private void RemoteCalibration_Load(object sender, EventArgs e)
        {

            mycursor = new AnimatedCursor();
            mycursor.coordinates = calibPoints[1];
            mycursor.ShowDialog();
            Cursor.Hide();
        }

        private void RemoteCalibration_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cursor.Show();

        }


        public void finish()
        {
            Cursor.Show();

            //mycursor.Dispose();
            mycursor.Hide();

            this.Hide();
           
        }

        // delegate that allows method DisplayMessage to be called
        // in the thread that creates and maintains the GUI
        private delegate void ChangeFormDelegate(object message, string control);
        // method DisplayMessage sets displayTextBox's Text property
        // in a thread-safe manner
        public void ChangeForm(object message, string control)
        {

            switch(control)
            {
                case "this":
                // if modifying displayTextBox is not thread safe
                if (this.InvokeRequired)Invoke(new ChangeFormDelegate(ChangeForm), new object[] { message, control });

                else // OK to modify displayTextBox in current thread
                {

                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    this.WindowState = FormWindowState.Normal;

                    this.Left = ((Rectangle)message).Left;
                    this.Top = ((Rectangle)message).Top;

                    this.Width = ((Rectangle)message).Width;
                    this.Height = ((Rectangle)message).Height;


                    this.FormBorderStyle = FormBorderStyle.None;
                    this.WindowState = FormWindowState.Maximized;
                }
                break;
}
        }// end method DisplayMessage

    }
}
