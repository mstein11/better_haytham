using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoombaControl
{
    class SensorPacketGroup
    {
        public String name;
        public int packetID;
        public int offsetInSensorDesc;
        public int numItems;
        public int numBytes;

        public SensorPacketGroup(int id, String n, int o, int num)
        {
            name = n;
            packetID = id;
            offsetInSensorDesc = o;
            numItems = num;
        }

        public override string ToString()
        {
            return name + "  (" + numItems + " items)";
        }
    }
}
