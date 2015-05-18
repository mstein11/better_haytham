using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoombaControl
{
    class RoombaRecordingEntry
    {
        public byte[] buffer;
        public DateTime t;

        public RoombaRecordingEntry(byte [] buf, int offset, int length, DateTime rt)
        {
            buffer = new byte[length];
            for (int i = offset; i < offset + length; i++) buffer[i] = buf[i];

            t = rt;
        }
    }
}
