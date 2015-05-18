using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Haytham
{
	/// <summary>
	/// Haytham external data handler main class
	/// </summary>
	public class ExtDataHandler : ExtData.IExtDataService
	{
		#region Variables

		private List<DataObject> Objects;
		private List<ImageInfo> Images;
		private ExtData.Host Host;
		private int? BackgroundHeight;
		private System.Drawing.Font Font;
		private System.Drawing.Brush BgBrush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(0xAA, System.Drawing.Color.Black));
		private System.Drawing.Image Ico = Haytham.Properties.Resources.appbar_connect;
		private System.Drawing.SolidBrush IcoBlue = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(0xFF, 0x00, 0x49, 0xBD));
		private DataObject timeObject;

		public bool IsEnabled { get; set; }
		public string LogFileName { get; set; }
		private System.IO.StreamWriter logWriter;
		private int logCounter = 0;
		private float fontSize;
		public float FontSize
		{
			get { return fontSize; }
			set
			{
				fontSize = value;
				this.Font = new System.Drawing.Font("Segoe UI", this.fontSize);
			}
		}

		#endregion Variables

		/// <summary>
		/// Constructor
		/// </summary>
		public ExtDataHandler()
		{
			this.Objects = new List<DataObject>();
			this.Images = new List<ImageInfo>();
			this.FontSize = 10f;	//set font
			this.timeObject = new DataObject()
			{
				Abbrevation = "T",
				Id = 0,
				Name = "Time",
				Position = new System.Drawing.Rectangle(20, 0, 94, 22)
			};
			this.Objects.Add(timeObject);

			//init web host
			System.Threading.Tasks.Task.Factory.StartNew(() =>
				{
					this.Host = new ExtData.Host().StartHost();
					this.Host.Reciever.Handler = this;
				});
		}

		#region IExtDataService
		public int Register(string name, string abbr, Guid clientId)
		{
			var obj = new DataObject()
			{
				Name = name,
				Abbrevation = abbr,
				ClientId = clientId
			};

			int id = -1;
			lock (this.Objects)
			{
				id = this.Objects.Count;
				this.Objects.Add(obj);
			}
			obj.Id = id;
			return id;
		}
		public void Reset(Guid clientId)
		{
			lock (this.Objects)
				this.Objects.RemoveAll(o => o.ClientId == clientId);
		}
		public void UnRegister(int id)
		{
			foreach (var o in this.Objects.Where(o => o.Id == id))
				o.IsRemoved = true;
		}
		public int? LoadImage(string fullPath)
		{
			if (!System.IO.File.Exists(fullPath))
				return null;

			var obj = new ImageInfo()
			{
				Fullpath = fullPath
			};

			int id = -1;
			lock (this.Images)
			{
				id = this.Images.Count;
				this.Images.Add(obj);
			}
			obj.Id = id;
			obj.Img = System.Drawing.Bitmap.FromFile(obj.Fullpath);

			return id;
		}
		public void SetPosition(int id, int x, int y, int width, int height)
		{
			var currObj = this.Objects[id];
			lock (currObj)
				currObj.Position = new System.Drawing.Rectangle(x, y, width, height);

			this.BackgroundHeight = null;
		}
		public void PushData(int id, string valueString, int? imgId)
		{
			var currObj = this.Objects[id];
			lock (currObj)
			{
				currObj.ValueString = valueString;
				currObj.ImageId = imgId;
			}
		}
		#endregion IExtDataService

		/// <summary>
		/// Main draw method used tu draw external data on image
		/// </summary>
		/// <param name="image"></param>
		public void Draw(ref Emgu.CV.Image<Bgr, byte> image)
		{
			if (!IsEnabled) return;

#if !DEBUG
			if (!this.Objects.Any()) return;
#endif

			//draw elements
			var gr = System.Drawing.Graphics.FromImage(image.Bitmap);


			if (this.BackgroundHeight == null)
			{
				int maxW = image.Bitmap.Width;
				int x; int y = 0;

				//set X
				x = 20;
				foreach (var item in this.Objects)
				{
					item.Position = new System.Drawing.Rectangle(x, 0, item.Position.Width, item.Position.Height);
					x += item.Position.Width;
				}

				//set lines
				List<DataObject> objects;
				do
				{
					objects = this.Objects.Where(o => o.Position.Right > maxW && o.Position.Left > 0).ToList();
					y += 22;
					x = 20;
					foreach (var o in objects)
					{
						o.Position = new System.Drawing.Rectangle(x, y, o.Position.Width, o.Position.Height);
						x += o.Position.Width;
					}
				} while (objects.Any() && y < 200);

				this.BackgroundHeight = this.Objects.GroupBy(o => o.Position.Y).Select(g => g.Max(go => go.Position.Height)).Sum();
			}

			var positionTop = image.Height - this.BackgroundHeight.Value;
			gr.FillRectangle(this.BgBrush, 0, positionTop, image.Width, this.BackgroundHeight.Value);
			gr.FillRectangle(this.IcoBlue, 0, positionTop, 22, this.BackgroundHeight.Value);
			gr.DrawImage(this.Ico, new System.Drawing.Rectangle(1, positionTop + 1, 20, 20));
			this.timeObject.ValueString = DateTime.Now.ToString(@"HH:mm:ss\.fff");

			int l = 2;
			lock (this.Objects)
				foreach (var item in this.Objects)
				{
					//skip removed items
					if (item.IsRemoved) continue;

					if (item.ImageId != null)
					{
						gr.DrawImage(this.Images[item.ImageId.Value].Img, item.Position.X + 2, positionTop + item.Position.Y + 2, 16, 16);
						l = 20;
					}
					else
						l = 2;

					gr.DrawString(string.Format("{0}: {1}", item.Abbrevation, item.ValueString), this.Font, System.Drawing.Brushes.White, item.Position.X + l, positionTop + item.Position.Y + 2);
				}

			gr.Flush();
			gr.Dispose();

		}

		/// <summary>
		/// Clear cache from haytham GUI
		/// </summary>
		public void Clear()
		{
			this.BackgroundHeight = null;
			lock (this.Objects)
			{
				this.Objects.Clear();
				this.Objects.Add(timeObject);
			}
		}

		#region Write LOG.csv
		public void OpenLog(string fileName)
		{
			this.logCounter = 0;
			this.CloseLog();
			this.logWriter = new System.IO.StreamWriter(fileName, false);
			this.logWriter.WriteLine(this.CsvHeader);
		}
		public void CloseLog()
		{
			if (this.logWriter != null)
			{
				this.logWriter.Close();
				this.logWriter.Dispose();
				this.logWriter = null;
			}
		}
		public void WriteLog()
		{
			if (this.IsEnabled)
			{
				this.logWriter.WriteLine(this.CsvLine);
				if ((++logCounter) >= 30)
				{
					this.logWriter.Flush();
					this.logCounter = 0;
				}
			}
		}

		private string CsvHeader
		{
			get { return string.Join(";", this.Objects.Select(o => string.Format("\"{0}\"", o.Name))); }
		}
		private string CsvLine
		{
			get { return string.Join(";", this.Objects.Select(o => o.ValueString)); }
		}
		#endregion Write LOG.csv
	}
}
