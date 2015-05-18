using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RoombaControl
{
    class Roomba
    {
        public delegate void SendToRoomba(byte[] buffer, int offset, int count);
        SendToRoomba sendCmd;
        bool recording = false;
        bool replaying = false;
        bool brushOn = false;
        RoombaRecording rr;
        SensorPacketGroup lastRequestedPacket;

        public Roomba (SendToRoomba s)
        {
            sendCmd = s;
        }

        private void Send (byte[] buf, int offset, int length)
        {
            if (recording)
            {
                RecordEntry(buf, offset, length);
            }
            sendCmd(buf, offset, length);
        }

        private void RecordEntry(byte[] buf, int offset, int length)
        {
            RoombaRecordingEntry rre = new RoombaRecordingEntry(buf, offset, length, DateTime.Now);
            rr.re.Add(rre);
        }

        public void InitROI()
        {
            byte[] buf = { 128, 131 };
            Send(buf, 0, buf.Length);
        }

        public void Drive_Direct(int rightWheelSpeed, int leftWheelSpeed)
        {
            byte rh = getHighByte (rightWheelSpeed); 
            byte rl = (byte)(rightWheelSpeed % 256);
            byte[] buf = { 145, rh, rl, getHighByte(leftWheelSpeed), (byte)(leftWheelSpeed % 256)};
            Send(buf, 0, buf.Length);
        }

        private byte getHighByte (int i)
        {
            byte b = (byte)(i / 256);
            if (b == 0 && i < 0) b = 255;
            return b;
        }

        public void Dock()
        {
            byte[] buf = { 143 };
            Send(buf, 0, buf.Length);
        }

        public void Clean()
        {
            byte[] buf = { 135 };
            Send(buf, 0, buf.Length);
        }

        internal void Leds_Raw(int p_1, int p_2, int p_3, int p_4)
        {
            byte[] buf = { 163, (byte)p_1, (byte)p_2, (byte)p_3, (byte)p_4 };
            Send(buf, 0, buf.Length);
        }

        public void RequestSensorData(int packetID)
        {
            byte[] buf = { 142, (byte)packetID };
            Send(buf, 0, buf.Length);
        }

        internal void SpotClean()
        {
            byte[] buf = { 134 };
            Send(buf, 0, buf.Length);
        }

        internal RoombaRecording StartRecording()
        {
            recording = true;
            rr = new RoombaRecording();
            return rr;
        }

        internal void StopRecording(RoombaRecording rr)
        {
            recording = false;
        }

        internal bool IsRecording()
        {
            return recording;
        }

        public void ReplayThread()
        {
            DateTime baseTime = ((RoombaRecordingEntry)rr.re[0]).t;

            foreach (RoombaRecordingEntry rre in rr.re)
            {
                Thread.Sleep((int)((rre.t - baseTime).TotalMilliseconds));
                Send(rre.buffer, 0, rre.buffer.Length);
                baseTime = rre.t;
                if (!replaying) break;
            }
            replaying = false;
        }

        internal void StartReplay(RoombaRecording rr)
        {
            Thread t = new Thread(new ThreadStart(ReplayThread));
            replaying = true;
            t.Start();
        }

        internal void StopReplay(RoombaRecording rr)
        {
            replaying = false;
        }

        internal bool IsReplaying()
        {
            return replaying;
        }

        internal void SendBytes(byte[] buffer, int offset, int count)
        {
            Send(buffer, offset, count);
        }

        internal void DriveStop()
        {
            byte[] buf = { 145, 0, 0, 0, 0 };
            Send(buf, 0, buf.Length);
        }

        public void StartBrush()
        {
            byte[] buf = { 138, 7 };
            Send(buf, 0, buf.Length);
            brushOn = true;
        }

        public void StopBrush()
        {
            byte[] buf = { 138, 0 };
            Send(buf, 0, buf.Length);
            brushOn = false;
        }

        internal bool AreBrushesOn()
        {
            return brushOn;
        }

        public void requestSensorPacket(SensorPacketGroup spg)
        {
            byte[] buf = { 142, (byte)(spg.packetID) };
            lastRequestedPacket = spg;
            Send(buf, 0, buf.Length);
        }

        internal void requestSensorStream(SensorPacketGroup spg)
        {
            byte[] buf = { 148, 1, (byte)(spg.packetID) };
            Send(buf, 0, buf.Length);
        }

        internal SensorPacketGroup lastPacketRequested()
        {
            return lastRequestedPacket;
        }
    }
}
