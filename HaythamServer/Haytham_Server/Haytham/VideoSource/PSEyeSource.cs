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

using AForge.Video;
using EGaze.Source.Image;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

// This implementation relies on Codelaboratories SDK for the Sony Playstation Eye Camera.
// The code used to capture the image is a slighly modfied version of the:
// WPF C# CLEyeMulticamWPFTest Sample Application distributed with the CL SDK
// 
// All credits goes to Code Laboratories and Alex Popovich
// http://codelaboratories.com


namespace Haytham.VideoSource
{
	public class PSEyeSource : IVideoSource
	{

		public static void GetDevices(ref Dictionary<string, IVideoSource> deviceCache)
		{
			for (int i = 0; i < PSEyeSource.CameraCount; i++)
			{
				var camName = string.Format("PsEye_{0}", i + 1);

				lock (deviceCache)
				{
					if (deviceCache.ContainsKey(camName))
						continue;
					//else .. all other code

					try
					{
						var video = new PSEyeSource(PSEyeSource.CameraUUID(i)) { Name = camName };

						deviceCache.Add(camName, video);
					}
					catch (Exception e)
					{
						System.Windows.Forms.MessageBox.Show(string.Join(Environment.NewLine, e.Message, "", e.Source, "", e.StackTrace));
					}
				}
			}


		}


		#region Enums Camera Parameters

		// camera color mode
		public enum CLEyeCameraColorMode
		{
			CLEYE_MONO_PROCESSED,
			CLEYE_COLOR_PROCESSED,
			CLEYE_MONO_RAW,
			CLEYE_COLOR_RAW,
			CLEYE_BAYER_RAW
		};

		// camera resolution
		public enum CLEyeCameraResolution
		{
			CLEYE_QVGA,
			CLEYE_VGA
		};

		// camera parameters
		public enum CLEyeCameraParameter
		{
			// camera sensor parameters
			CLEYE_AUTO_GAIN,			// [false, true]
			CLEYE_GAIN,					// [0, 79]
			CLEYE_AUTO_EXPOSURE,		// [false, true]
			CLEYE_EXPOSURE,				// [0, 511]
			CLEYE_AUTO_WHITEBALANCE,	// [false, true]
			CLEYE_WHITEBALANCE_RED,		// [0, 255]
			CLEYE_WHITEBALANCE_GREEN,	// [0, 255]
			CLEYE_WHITEBALANCE_BLUE,	// [0, 255]
			// camera linear transform parameters
			CLEYE_HFLIP,				// [false, true]
			CLEYE_VFLIP,				// [false, true]
			CLEYE_HKEYSTONE,			// [-500, 500]
			CLEYE_VKEYSTONE,			// [-500, 500]
			CLEYE_XOFFSET,				// [-500, 500]
			CLEYE_YOFFSET,				// [-500, 500]
			CLEYE_ROTATION,				// [-500, 500]
			CLEYE_ZOOM,					// [-500, 500]
			// camera non-linear transform parameters
			CLEYE_LENSCORRECTION1,		// [-500, 500]
			CLEYE_LENSCORRECTION2,		// [-500, 500]
			CLEYE_LENSCORRECTION3,		// [-500, 500]
			CLEYE_LENSBRIGHTNESS		// [-500, 500]
		};

		#endregion

		#region Driver imports (CLEyeMulticam)
		[DllImport("CLEyeMulticam.dll")]
		public static extern int CLEyeGetCameraCount();
		[DllImport("CLEyeMulticam.dll")]
		public static extern Guid CLEyeGetCameraUUID(int camId);
		[DllImport("CLEyeMulticam.dll")]
		public static extern IntPtr CLEyeCreateCamera(Guid camUUID, CLEyeCameraColorMode mode, CLEyeCameraResolution res, float frameRate);
		[DllImport("CLEyeMulticam.dll")]
		public static extern bool CLEyeDestroyCamera(IntPtr camera);
		[DllImport("CLEyeMulticam.dll")]
		public static extern bool CLEyeCameraStart(IntPtr camera);
		[DllImport("CLEyeMulticam.dll")]
		public static extern bool CLEyeCameraStop(IntPtr camera);
		[DllImport("CLEyeMulticam.dll")]
		public static extern bool CLEyeCameraLED(IntPtr camera, bool on);
		[DllImport("CLEyeMulticam.dll")]
		public static extern bool CLEyeSetCameraParameter(IntPtr camera, CLEyeCameraParameter param, int value);
		[DllImport("CLEyeMulticam.dll")]
		public static extern int CLEyeGetCameraParameter(IntPtr camera, CLEyeCameraParameter param);
		[DllImport("CLEyeMulticam.dll")]
		public static extern bool CLEyeCameraGetFrameDimensions(IntPtr camera, ref int width, ref int height);
		[DllImport("CLEyeMulticam.dll")]
		public static extern bool CLEyeCameraGetFrame(IntPtr camera, IntPtr pData, int waitTimeout);

		[DllImport("kernel32.dll", SetLastError = true)]
		static extern IntPtr CreateFileMapping(IntPtr hFile, IntPtr lpFileMappingAttributes, uint flProtect, uint dwMaximumSizeHigh, uint dwMaximumSizeLow, string lpName);
		[DllImport("kernel32.dll", SetLastError = true)]
		static extern IntPtr MapViewOfFile(IntPtr hFileMappingObject, uint dwDesiredAccess, uint dwFileOffsetHigh, uint dwFileOffsetLow, uint dwNumberOfBytesToMap);
		[DllImport("kernel32.dll", SetLastError = true)]
		static extern bool UnmapViewOfFile(IntPtr hMap);
		[DllImport("kernel32.dll", SetLastError = true)]
		static extern bool CloseHandle(IntPtr hHandle);
		#endregion

		#region Static properties

		public static int CameraCount
		{
			get
			{
				int count = 0;
				try
				{
					count = CLEyeGetCameraCount();
				}
				catch (DllNotFoundException)
				{
					count = 0;
				}
				return count;
			}
		}

		public static Guid CameraUUID(int idx)
		{
			return CLEyeGetCameraUUID(idx);
		}
		#endregion

		#region Get/Set properties

		public float Framerate { get; set; }
		public CLEyeCameraColorMode ColorMode { get; set; }
		public CLEyeCameraResolution Resolution { get; set; }

		public bool AutoGain
		{
			get
			{
				if (_camera == null) return false;
				return CLEyeGetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_AUTO_GAIN) != 0;
			}
			set
			{
				if (_camera == null) return;
				CLEyeSetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_AUTO_GAIN, value ? 1 : 0);
			}
		}
		public int Gain
		{
			get
			{
				if (_camera == null) return 0;
				return CLEyeGetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_GAIN);
			}
			set
			{
				if (_camera == null) return;
				CLEyeSetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_GAIN, value);
			}
		}
		public bool AutoExposure
		{
			get
			{
				if (_camera == null) return false;
				return CLEyeGetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_AUTO_EXPOSURE) != 0;
			}
			set
			{
				if (_camera == null) return;
				CLEyeSetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_AUTO_EXPOSURE, value ? 1 : 0);
			}
		}
		public int Exposure
		{
			get
			{
				if (_camera == null) return 0;
				return CLEyeGetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_EXPOSURE);
			}
			set
			{
				if (_camera == null) return;
				CLEyeSetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_EXPOSURE, value);
			}
		}
		public bool AutoWhiteBalance
		{
			get
			{
				if (_camera == null) return true;
				return CLEyeGetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_AUTO_WHITEBALANCE) != 0;
			}
			set
			{
				if (_camera == null) return;
				CLEyeSetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_AUTO_WHITEBALANCE, value ? 1 : 0);
			}
		}
		public int WhiteBalanceRed
		{
			get
			{
				if (_camera == null) return 0;
				return CLEyeGetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_WHITEBALANCE_RED);
			}
			set
			{
				if (_camera == null) return;
				CLEyeSetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_WHITEBALANCE_RED, value);
			}
		}
		public int WhiteBalanceGreen
		{
			get
			{
				if (_camera == null) return 0;
				return CLEyeGetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_WHITEBALANCE_GREEN);
			}
			set
			{
				if (_camera == null) return;
				CLEyeSetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_WHITEBALANCE_GREEN, value);
			}
		}
		public int WhiteBalanceBlue
		{
			get
			{
				if (_camera == null) return 0;
				return CLEyeGetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_WHITEBALANCE_BLUE);
			}
			set
			{
				if (_camera == null) return;
				CLEyeSetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_WHITEBALANCE_BLUE, value);
			}
		}
		public bool HorizontalFlip
		{
			get
			{
				if (_camera == null) return false;
				return CLEyeGetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_HFLIP) != 0;
			}
			set
			{
				if (_camera == null) return;
				CLEyeSetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_HFLIP, value ? 1 : 0);
			}
		}
		public bool VerticalFlip
		{
			get
			{
				if (_camera == null) return false;
				return CLEyeGetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_VFLIP) != 0;
			}
			set
			{
				if (_camera == null) return;
				CLEyeSetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_VFLIP, value ? 1 : 0);
			}
		}
		public int HorizontalKeystone
		{
			get
			{
				if (_camera == null) return 0;
				return CLEyeGetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_HKEYSTONE);
			}
			set
			{
				if (_camera == null) return;
				CLEyeSetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_HKEYSTONE, value);
			}
		}
		public int VerticalKeystone
		{
			get
			{
				if (_camera == null) return 0;
				return CLEyeGetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_VKEYSTONE);
			}
			set
			{
				if (_camera == null) return;
				CLEyeSetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_VKEYSTONE, value);
			}
		}
		public int XOffset
		{
			get
			{
				if (_camera == null) return 0;
				return CLEyeGetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_XOFFSET);
			}
			set
			{
				if (_camera == null) return;
				CLEyeSetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_XOFFSET, value);
			}
		}
		public int YOffset
		{
			get
			{
				if (_camera == null) return 0;
				return CLEyeGetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_YOFFSET);
			}
			set
			{
				if (_camera == null) return;
				CLEyeSetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_YOFFSET, value);
			}
		}
		public int Rotation
		{
			get
			{
				if (_camera == null) return 0;
				return CLEyeGetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_ROTATION);
			}
			set
			{
				if (_camera == null) return;
				CLEyeSetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_ROTATION, value);
			}
		}
		public int Zoom
		{
			get
			{
				if (_camera == null) return 0;
				return CLEyeGetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_ZOOM);
			}
			set
			{
				if (_camera == null) return;
				CLEyeSetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_ZOOM, value);
			}
		}
		public int LensCorrection1
		{
			get
			{
				if (_camera == null) return 0;
				return CLEyeGetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_LENSCORRECTION1);
			}
			set
			{
				if (_camera == null) return;
				CLEyeSetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_LENSCORRECTION1, value);
			}
		}
		public int LensCorrection2
		{
			get
			{
				if (_camera == null) return 0;
				return CLEyeGetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_LENSCORRECTION2);
			}
			set
			{
				if (_camera == null) return;
				CLEyeSetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_LENSCORRECTION2, value);
			}
		}
		public int LensCorrection3
		{
			get
			{
				if (_camera == null) return 0;
				return CLEyeGetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_LENSCORRECTION3);
			}
			set
			{
				if (_camera == null) return;
				CLEyeSetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_LENSCORRECTION3, value);
			}
		}
		public int LensBrightness
		{
			get
			{
				if (_camera == null) return 0;
				return CLEyeGetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_LENSBRIGHTNESS);
			}
			set
			{
				if (_camera == null) return;
				CLEyeSetCameraParameter(_camera, CLEyeCameraParameter.CLEYE_LENSBRIGHTNESS, value);
			}
		}
		#endregion

		private ImageFrame _CurrentFrame;
		private bool _Active;

		private IntPtr _map = IntPtr.Zero;
		private IntPtr _section = IntPtr.Zero;
		private IntPtr _camera = IntPtr.Zero;
		private int w = 0, h = 0;
		private bool _running;
		private Thread _workerThread;
		private Guid _cameraGuid;

		public event ImageFrameReadyHandler OnImageFrame;
		public event EventHandler OnStateChanged;


		public ImageFrame CurrentFrame
		{
			get { return _CurrentFrame; }
			set { _CurrentFrame = value; }
		}

		public bool Active
		{
			get { return _Active; }
			set
			{
				if (_Active != value)
				{
					_Active = value;
					if (OnStateChanged != null)
						OnStateChanged(this, null);
				}
			}
		}

        private string monikorString;
        public string MonikorString
        {
            get { return this.monikorString; }
        }
		public string Name
		{
			get;
			private set;
		}

		public PSEyeSource(Guid cameraGuid)
		{
			Framerate = 75;
			ColorMode = CLEyeCameraColorMode.CLEYE_MONO_PROCESSED;
			Resolution = CLEyeCameraResolution.CLEYE_VGA;
			_cameraGuid = cameraGuid;
		}

		ImageFrameReadyEventArgs eArgs = new ImageFrameReadyEventArgs();
		void _VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
		{
			this.CurrentFrame.Bitmap = (System.Drawing.Bitmap)eventArgs.Frame.Clone();
			this.CurrentFrame.Height = this.CurrentFrame.Bitmap.Height;
			this.CurrentFrame.Width = this.CurrentFrame.Bitmap.Width;
			this.CurrentFrame.Timestamp = DateTime.Now.Ticks;
			eArgs.ImageFrame = this.CurrentFrame;

			if (OnImageFrame != null)
				OnImageFrame(this, eArgs);
		}



		public void Init()
		{
			this._CurrentFrame = new ImageFrame();
			this._CurrentFrame.Format = System.Drawing.Imaging.ImageFormat.MemoryBmp;


			// Create camera
			_camera = CLEyeCreateCamera(_cameraGuid, ColorMode, Resolution, Framerate);

			if (_camera == IntPtr.Zero)
				return;

			// Get width and hight of the images
			CLEyeCameraGetFrameDimensions(_camera, ref w, ref h);
			uint imageSize = (uint)w * (uint)h;

			// create memory section and map
			_section = CreateFileMapping(new IntPtr(-1), IntPtr.Zero, 0x04, 0, imageSize, null);
			_map = MapViewOfFile(_section, 0xF001F, 0, 0, imageSize);
		}

		public void Run()
		{
			_running = true;
			_workerThread = new Thread(new ThreadStart(CaptureThread));
			_workerThread.Start();
			this.Active = true;
		}

		public void Stop()
		{
			this.NewFrame = null;
			this.OnImageFrame -= PSEyeSource_OnImageFrame;

			if (!_running) return;

			_running = false;
			_workerThread.Join(1000);
			this.Active = false;
		}

		public void Pause()
		{

		}

		public void Exit()
		{
			if (_map != IntPtr.Zero)
			{
				UnmapViewOfFile(_map);
				_map = IntPtr.Zero;
			}
			if (_section != IntPtr.Zero)
			{
				CloseHandle(_section);
				_section = IntPtr.Zero;
			}

		}

		private void CaptureThread()
		{
			CLEyeCameraStart(_camera);
			int i = 0;

			while (_running)
			{
				if (CLEyeCameraGetFrame(_camera, _map, 300))
				{
					if (!_running) break;

					if (_map != IntPtr.Zero)
					{

						this.CurrentFrame.Bitmap = new Emgu.CV.Image<Gray, byte>(w, h, w, _map).Bitmap;
						this.CurrentFrame.Height = this.CurrentFrame.Bitmap.Height;
						this.CurrentFrame.Width = this.CurrentFrame.Bitmap.Width;
						this.CurrentFrame.Timestamp = DateTime.Now.Ticks;
						eArgs.ImageFrame = this.CurrentFrame;

						if (OnImageFrame != null)
							OnImageFrame(this, eArgs);
					}

					i++;
				}
			}
			CLEyeCameraStop(_camera);
			CLEyeDestroyCamera(_camera);
		}



		private int _Width;
		public int Width
		{
			get { return _Width; }
			set { _Width = value; }
		}

		private int _Height;
		public int Height
		{
			get { return _Height; }
			set { _Height = value; }
		}

		private int _OffsetX;
		public int OffsetX
		{
			get { return _OffsetX; }
			set { _OffsetX = value; }
		}

		private int _OffsetY;
		public int OffsetY
		{
			get { return _OffsetY; }
			set { _OffsetY = value; }
		}




		public IEnumerable<DeviceCapabilityInfo> Capabilities
		{
			get { return System.Linq.Enumerable.Empty<DeviceCapabilityInfo>(); }
		}

		public DeviceCapabilityInfo SelectedCap
		{
			get;
			set;
		}

		public System.Drawing.Size VideoSize
		{
			get { return new System.Drawing.Size(this.Width, this.Height); }
		}

		public bool HasSettings
		{
			get { return false; }
		}

		public bool IsRunning
		{
			get { return this.Active; }
		}

		public void ShowSettings()
		{
			throw new NotImplementedException();
		}

		public void Start()
		{
			this.OnImageFrame += PSEyeSource_OnImageFrame;
			this.Run();
		}

		void PSEyeSource_OnImageFrame(object sender, ImageFrameReadyEventArgs eventArgs)
		{
			if (this.NewFrame != null)
				this.NewFrame(this, new NewFrameEventArgs(eventArgs.ImageFrame.Bitmap));
		}

		public event NewFrameEventHandler NewFrame;
	}
}
