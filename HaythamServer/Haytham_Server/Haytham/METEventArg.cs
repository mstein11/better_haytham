using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Emgu.CV.Structure;
using Emgu.CV;

namespace Haytham
{
    
    public class METEventArg:EventArgs
    {


        public METEventArg()
        { }
        private Image<Bgr, Byte> _image;
        public Image<Bgr, Byte> image
        {
            get { return _image; }
            set { _image = value; }
        }
        private string  _AdditionalArg;
        public string AdditionalArg
        {
            get { return _AdditionalArg; }
            set { _AdditionalArg = value; }
        }

    }
}
