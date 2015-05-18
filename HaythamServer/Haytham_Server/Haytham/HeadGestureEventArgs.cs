
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Haytham
{

        public class HeadGestureEventArgs : EventArgs
        {

            private string gesture;
            private bool hasBegining;

            /// <summary>
            /// Initializes new instance of HeadGestureEventArgs
            /// </summary>
            /// <param name="gesture">The gesture performed.</param>
            public HeadGestureEventArgs(string foundGesture, bool s)
        
            {
                gesture = foundGesture;
                hasBegining = s;
            }


            public string Gesture
            {
                get { return gesture; }
               // set { gesture = value; }
            }
            public bool HasBegining
            {
                get { return hasBegining; }
                // set { gesture = value; }
            }
        }
    
}
