using System;
using System.Collections.Generic;

namespace EGaze.Source.Image
{
    public class ImageFrame
    {
        public int FrameNumber { get; set; }
        public long Timestamp { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
		public System.Drawing.Imaging.ImageFormat Format { get; set; }
        public System.Drawing.Bitmap Bitmap { get; set; }
    }
}
