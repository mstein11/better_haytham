//<copyright file="IVideoSource.cs" company="ITU">
//This file is part of Haytham 
//Copyright (C) 2014 Peter Jurnecka
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
// <author>Peter Jurnecka</author>
// <email>ijurnecka@fit.vutbr.cz</email>

using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Haytham.VideoSource
{
	class AforgeVideoSource : IVideoSource
	{
		/// <summary>
		/// Static func that performs search for devices and adds them to referenced device cache
		/// </summary>
		/// <param name="deviceCache"></param>
		public static void GetDevices(ref Dictionary<string, IVideoSource> deviceCache)
		{
			var videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
			if (videoDevices != null && videoDevices.Count > 0)
			{
				foreach (FilterInfo device in videoDevices)
				{
					lock (deviceCache)
					{
                        if (deviceCache.ContainsKey(device.MonikerString))
                        {
                           


                            continue;
                        } 
                        
                        //else .. all other code

                        try
                        {
                            var video = new VideoCaptureDevice(device.MonikerString);

                            var capList = video.VideoCapabilities.Select(cap => new DeviceCapabilityInfo(cap)).ToList();

                            // System.Diagnostics.Debug.WriteLine(device.MonikerString.ToString());
                            var dev = new AforgeVideoSource(device.Name, capList, video);

                            deviceCache.Add(device.MonikerString, dev); 
                            
                        }
                        catch (Exception e)
                        {
                            System.Windows.Forms.MessageBox.Show(string.Join(Environment.NewLine, e.Message, "", e.Source, "", e.StackTrace));
                        }
					}
				}
			}
		}
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="name_p"></param>
		/// <param name="caps_p"></param>
		/// <param name="dev"></param>
		public AforgeVideoSource(string name_p, List<DeviceCapabilityInfo> caps_p, VideoCaptureDevice dev)
		{
			this.name = name_p;
			this.capabilities = caps_p;
			this.videoDevice = dev;
		}

		public string Name
		{
			get { return this.name; }
		}
		public IEnumerable<DeviceCapabilityInfo> Capabilities
		{
			get { return this.capabilities; }
		}


		public DeviceCapabilityInfo SelectedCap
		{
			get
			{
				return this.selectedCap;
			}
			set
			{
				this.selectedCap = value;
				if (this.videoDevice != null)
					this.videoDevice.VideoResolution = value.origCap;
			}
		}
		public System.Drawing.Size VideoSize
		{
			get
			{
				if (this.selectedCap == null)
					return System.Drawing.Size.Empty;
				return this.selectedCap.FrameSize;
			}
		}
		/// <summary>
		/// Used on main form to show settings button
		/// </summary>
		public bool HasSettings
		{
			get { return true; }
		}
		public bool IsRunning { get; set; }
		/// <summary>
		/// Called from mainForm, with settingsBtn.Click
		/// </summary>
		public void ShowSettings()
		{
			this.videoDevice.DisplayPropertyPage(IntPtr.Zero);
		}

		public event AForge.Video.NewFrameEventHandler NewFrame;

		public void Start()
		{
			//start LED if it is islim camera
            
			if (this.name.StartsWith("iSlim") )
			{
				this.videoDevice.SetCameraProperty(CameraControlProperty.Focus, 1, CameraControlFlags.Manual);
			}

			this.videoDevice.NewFrame -= videoFile_NewFrame;
			this.videoDevice.NewFrame += videoFile_NewFrame;
			this.videoDevice.Start();
			this.IsRunning = true;
		}
		void videoFile_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
		{
			if (this.NewFrame != null)
				this.NewFrame(this, eventArgs);
		}

		public void Stop()
		{
			this.NewFrame = null;

			//stop LED if it is islim camera
			if (this.name.StartsWith("iSlim"))
			{
				this.videoDevice.SetCameraProperty(CameraControlProperty.Focus, 0, CameraControlFlags.Manual);
			}

			if (this.videoDevice != null)
				this.videoDevice.SignalToStop();
			this.IsRunning = false;
		}

		public override string ToString()
		{
			return this.Name;
		}

		//local variables
		private VideoCaptureDevice videoDevice;
		private List<DeviceCapabilityInfo> capabilities;
		private string name;
		DeviceCapabilityInfo selectedCap;
 
	}
}
