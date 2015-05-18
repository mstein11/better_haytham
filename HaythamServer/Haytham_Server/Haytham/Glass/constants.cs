using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myGlass
{
    public static class constants
    {
        public const int MSG_SIZE = 12;//byteArray[12]


        public const int CHUNK_SIZE = 4192;//???What is best?
        public  const string HEADER_MSB = "0x10";
        public  const string HEADER_LSB = "0x55";
        public  const string NAME = "ANDROID-BTXFR";
        public const string UUID_STRING = "fa87c0d0-afac-11de-8a39-0800200c9a66";
        public const int display_W=640;
        public const int display_H = 360;

             public const int  SERVER_PORT =  4444;
             public const int SERVER_PORT_UDP = 4343;
             public const int SERVER_PORT_UDP_GAZE = 4545;


    }
}
