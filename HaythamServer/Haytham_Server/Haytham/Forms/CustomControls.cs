using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

using System.Runtime.InteropServices;
using System.IO;
namespace Haytham
{
    class TransparentTrackBar : TrackBar
    {
        protected override void OnCreateControl()
        {

            try
            {
                SetStyle(ControlStyles.SupportsTransparentBackColor, true);


                //if (Parent != null)
                //    BackColor = Parent.BackColor;

                //base.OnCreateControl();
            }
            catch (Exception e)
            { }
        }
    }


}

