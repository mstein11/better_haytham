using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Haytham.VideoSource
{
	class FileVideoSource : IVideoSource
	{
		public static void GetDevices(ref Dictionary<string, IVideoSource> deviceCache)
		{
			var dev = new FileVideoSource();
			if (!deviceCache.ContainsKey(dev.Name))
				deviceCache.Add(dev.Name, dev);
		}

		public string Name
		{
			get { return "Video file"; }
		}
		public IEnumerable<DeviceCapabilityInfo> Capabilities
		{
			get { return Enumerable.Empty<DeviceCapabilityInfo>(); }
		}
		public DeviceCapabilityInfo SelectedCap { get; set; }
		public System.Drawing.Size VideoSize { get { return System.Drawing.Size.Empty; } }
		public bool HasSettings
		{
			get { return true; }
		}
		public bool IsRunning { get; set; }
		public void ShowSettings()
		{
			this.showSettings();
		}
		private bool showSettings()
		{
			var openFileDialog = new OpenFileDialog();
			// OpenFileDialog.Filter = "AVI File|*.avi|All Files|*.*";

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				// create video source
				this.videoFile = new AForge.Video.DirectShow.FileVideoSource(openFileDialog.FileName);
				this.videoFile.NewFrame += videoFile_NewFrame;
				return true;
			}
			return false;
		}

		public event AForge.Video.NewFrameEventHandler NewFrame;

		public void Start()
		{
			var isSet = this.videoFile != null;
			//try to set up video file
			if (!isSet)
				isSet = showSettings();
			
			//when video file is set
			if (isSet)
			{
				this.videoFile.Start();
				this.IsRunning = true;
			}
		}
		void videoFile_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
		{
			if (this.NewFrame != null)
				this.NewFrame(this, eventArgs);
		}

		public void Stop()
		{
			if (this.videoFile != null)
				this.videoFile.SignalToStop();
			
			this.IsRunning = false;
			this.NewFrame = null;
		}

		private AForge.Video.DirectShow.FileVideoSource videoFile;

		public override string ToString()
		{
			return this.Name;
		}

	}
}
