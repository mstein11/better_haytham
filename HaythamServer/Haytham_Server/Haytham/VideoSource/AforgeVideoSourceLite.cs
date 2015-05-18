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
	class AforgeVideoSourceLite : IVideoSource
	{
		public static void GetDevices(ref Dictionary<string, IVideoSource> deviceCache)
		{
			var videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
			if (videoDevices != null && videoDevices.Count > 0)
			{
				foreach (FilterInfo device in videoDevices)
				{
					lock (deviceCache)
					{
						if (deviceCache.ContainsKey(device.Name))
							continue;
						//else .. all other code

						try
						{
							var video = new VideoCaptureDeviceLite(device.MonikerString);
							// System.Diagnostics.Debug.WriteLine(device.MonikerString.ToString());
							//start video to get frame size from first frame
							video.Start();
							System.Threading.Thread.Sleep(100);
							video.WaitForStop();
							var dev = new AforgeVideoSourceLite(device.Name, video) { VideoSize = video.FrameSize ?? System.Drawing.Size.Empty };
							deviceCache.Add(device.Name, dev);
						}
						catch (Exception e)
						{
							System.Windows.Forms.MessageBox.Show(string.Join(Environment.NewLine, e.Message, "", e.Source, "", e.StackTrace));
						}
					}
				}
			}
		}
		public AforgeVideoSourceLite(string name_p, VideoCaptureDeviceLite dev)
		{
			this.name = name_p;
			this.videoDevice = dev;
		}

		public string Name
		{
			get { return this.name; }
		}
		public IEnumerable<DeviceCapabilityInfo> Capabilities
		{
			get { return capList; }
		}
		public DeviceCapabilityInfo SelectedCap { get; set; }
		public System.Drawing.Size VideoSize { get; private set; }
		public bool HasSettings
		{
			get { return true; }
		}
		public bool IsRunning { get; set; }
		public void ShowSettings()
		{
			this.videoDevice.DisplayPropertyPage(IntPtr.Zero);
		}

		public event AForge.Video.NewFrameEventHandler NewFrame;

		public void Start()
		{
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

			if (this.videoDevice != null)
				this.videoDevice.SignalToStop();
			this.IsRunning = false;
		}

		public override string ToString()
		{
			return this.Name;
		}

		private VideoCaptureDeviceLite videoDevice;
		private string name;
		private List<DeviceCapabilityInfo> capList = new List<DeviceCapabilityInfo>() { new DeviceCapabilityInfo(null, "Default") };
	}
}
