using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoombaControl
{
    class SensorDescription
    {
        public int packet;
        public String name;
        public int numBytes;
        public int offset;
        public bool signed;

        public SensorDescription(int p, String n, int b, bool s)
        {
            packet = p;
            name = n;
            numBytes = b;
            signed = s;
        }

    }
}
