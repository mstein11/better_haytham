using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace RoombaControl
{
    class RoombaRecording
    {
        public ArrayList re; // recording entries

        public RoombaRecording()
        {
            re = new ArrayList();
        }

        internal void AppendEntry(RoombaRecordingEntry rre)
        {
            re.Add(rre);
        }

        public override string ToString()
        {
            String s = "Roomba recording\n";

            DateTime baseTime = ((RoombaRecordingEntry)re[0]).t;

            foreach (RoombaRecordingEntry rre in re)
            {
                s = s + (rre.t - baseTime).TotalMilliseconds + ": ";
                for (int i = 0; i < rre.buffer.Length; i++) s = s + rre.buffer[i] + " ";
                s = s + "\n";
            }
            
            return s;
        }
    }
}
