using System;
using System.Collections.Generic;

namespace EGaze.Source.Image
{

    public delegate void ImageFrameReadyHandler(Object sender, ImageFrameReadyEventArgs eventArgs);

    public class ImageFrameReadyEventArgs : EventArgs
    {
        public ImageFrame ImageFrame { get; set; }
    }
}
