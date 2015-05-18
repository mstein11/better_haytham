using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoombaControl
{
    class Sensors
    {

        public enum SensorID { 
            Bumps_WheelDrops	    =  0,
            Wall                        ,
            Cliff_Left                  ,
            Cliff_Front_Left            ,
            Cliff_Front_Right           ,
            Cliff_Right                 ,
            Virtual_Wall                ,
            Overcurrents                ,
            Dirt_Detect                 ,
            Unused_1                    ,
            Ir_Opcode                   ,
            Buttons                     ,
            Distance                    ,
            Angle                       ,
            Charging_State              ,
            Voltage                     ,
            Current                     ,
            Temperature                 ,
            Battery_Charge              ,
            Battery_Capacity            ,
            Wall_Signal                 ,
            Cliff_Left_Signal           ,
            Cliff_Front_Left_Signal     ,
            Cliff_Front_Right_Signal    ,
            Cliff_Right_Signal          ,
            Unused_2                    ,
            Unused_3                    ,
            Charger_Available           ,
            Open_Interface_Mode         ,
            Song_Number                 ,
            Song_Playing                ,
            Oi_Stream_Num_Packets       ,
            Velocity                    ,
            Radius                      ,
            Velocity_Right              ,
            Velocity_Left               ,
            Encoder_Counts_Left         ,
            Encoder_Counts_Right        ,
            Light_Bumper                ,
            Light_Bump_Left             ,
            Light_Bump_Front_Left       ,
            Light_Bump_Center_Left      ,
            Light_Bump_Center_Right     ,
            Light_Bump_Front_Right      ,
            Light_Bump_Right            ,
            Ir_Opcode_Left              ,
            Ir_OpCode_Right             ,
            Left_Motor_Current          ,
            Right_Motor_Current         ,
            Main_Brush_Current          ,
            Side_brush_Current          ,
            Stasis                      
        };

        static public SensorPacketGroup[] sp =
        {
            new SensorPacketGroup(  0, "Group0" , 0, 20),
            new SensorPacketGroup(  1, "Group1" , 0, 10),
            new SensorPacketGroup(  2, "Group2" , 10, 4),
            new SensorPacketGroup(  3, "Group3" , 14,6),
            new SensorPacketGroup(  4, "Group4" , 20, 8),
            new SensorPacketGroup(  5, "Group5" , 28,8),
            new SensorPacketGroup(  6, "Group6" , 0, 36),
            new SensorPacketGroup(100, "Group100" , 0,52),
            new SensorPacketGroup(101, "Group101" , 36,16),
            new SensorPacketGroup(106, "Group106" , 39,6),
            new SensorPacketGroup(107, "Group107" , 47,5)

        };


        static public SensorDescription[] sd = {

            new SensorDescription(  7, "Bumps WheelDrops" , 1 , false),
            new SensorDescription(  8, "Wall" , 1 , false),
            new SensorDescription(  9, "Cliff Left" , 1 , false),
            new SensorDescription( 10, "Cliff Front Left" , 1 , false),
            new SensorDescription( 11, "Cliff Front Right" , 1 , false),
            new SensorDescription( 12, "Cliff Right" , 1 , false),
            new SensorDescription( 13, "Virtual Wall" , 1 , false),
            new SensorDescription( 14, "Overcurrents" , 1 , false),
            new SensorDescription( 15, "Dirt Detect" , 1 , false),
            new SensorDescription( 16, "Unused 1" , 1 , false),
            new SensorDescription( 17, "Ir Opcode" , 1 , false),
            new SensorDescription( 18, "Buttons" , 1 , false),
            new SensorDescription( 19, "Distance" , 2,  true),
            new SensorDescription( 20, "Angle" , 2,  true),
            new SensorDescription( 21, "Charging State" , 1 , false),
            new SensorDescription( 22, "Voltage" , 2 , false),
            new SensorDescription( 23, "Current" , 2 , false),
            new SensorDescription( 24, "Temperature" , 1 , false),
            new SensorDescription( 25, "Battery Charge" , 2 , false),
            new SensorDescription( 26, "Battery Capacity" , 2 , false),
            new SensorDescription( 27, "Wall Signal" , 2 , false),
            new SensorDescription( 28, "Cliff Left Signal" , 2 , false),
            new SensorDescription( 29, "Cliff Front Left Signal" , 2 , false),
            new SensorDescription( 30, "Cliff Front Right Signal" , 2 , false),
            new SensorDescription( 31, "Cliff Right Signal" , 2 , false),
            new SensorDescription( 32, "Unused 2" , 1 , false),
            new SensorDescription( 33, "Unused 3" , 2 , false),
            new SensorDescription( 34, "Charger Available" , 1 , false),
            new SensorDescription( 35, "Open Interface Mode" , 1 , false),
            new SensorDescription( 36, "Song Number" , 1 , false),
            new SensorDescription( 37, "Song Playing?" , 1 , false),
            new SensorDescription( 38, "Oi Stream Num Packets" , 1 , false),
            new SensorDescription( 39, "Velocity" , 2 , false),
            new SensorDescription( 40, "Radius" , 2 , false),
            new SensorDescription( 41, "Velocity Right" , 2 , false),
            new SensorDescription( 42, "Velocity Left" , 2 , false),
            new SensorDescription( 43, "Encoder Counts Left" , 2 , false),
            new SensorDescription( 44, "Encoder Counts Right" , 2 , false),
            new SensorDescription( 45, "Light Bumper" , 1 , false),
            new SensorDescription( 46, "Light Bump Left" , 2 , false),
            new SensorDescription( 47, "Light Bump Front Left" , 2 , false),
            new SensorDescription( 48, "Light Bump Center Left" , 2 , false),
            new SensorDescription( 49, "Light Bump Center Right" , 2 , false),
            new SensorDescription( 50, "Light Bump Front Right" , 2 , false),
            new SensorDescription( 51, "Light Bump Right" , 2 , false),
            new SensorDescription( 52, "Ir Opcode Left" , 1 , false),
            new SensorDescription( 53, "Ir OpCode Right" , 1 , false),
            new SensorDescription( 54, "Left Motor Current" , 2 , false),
            new SensorDescription( 55, "Right Motor Current" , 2 , false),
            new SensorDescription( 56, "Main Brush Current" , 2 , false),
            new SensorDescription( 57, "Side brush Current" , 2 , false),
            new SensorDescription( 58, "Stasis" , 1,  false)
        };

        byte[] bytes;
        bool valid;
        SensorPacketGroup spGroup;


        static Sensors () 
        {
            // add byte offsets to sensor description array
            int byteIdx=0;
            for (int i = 0; i < sd.Length; i++)
            {
                sd[i].offset = byteIdx;
                byteIdx += sd[i].numBytes;
            }

            //add byte count to sensor packet group
            foreach (SensorPacketGroup spg in sp)
            {
                spg.numBytes = 0;
                for (int i=0;i<spg.numItems;i++)
                {
                    spg.numBytes += sd[spg.offsetInSensorDesc + i].numBytes;
                }
            }
        }


        public Sensors(byte[] buf)
        {
            bytes = buf;
            valid = (bytes.Length == 80);
        }

        public Sensors(byte[] buf, SensorPacketGroup spg)
        {
            bytes = buf;
            if (spg != null)
            {
                valid = (bytes.Length == spg.numBytes);
                spGroup = spg;
            }
            else
            {
                valid = false;
            }
        }

        public int GetValue(SensorID sensorID)
        {
            int value = 0;
            int i = (int)sensorID;
            if (i >= spGroup.offsetInSensorDesc && i < spGroup.offsetInSensorDesc + spGroup.numItems)
            {
                int offsetInBytes = sd[i].offset - sd[spGroup.offsetInSensorDesc].offset;
                if (sd[i].numBytes == 1)
                {
                    value = (int) bytes[offsetInBytes];
                }
                else if (sd[i].numBytes == 2)
                {
                    Int16 value16 = (Int16)(bytes[offsetInBytes] * 256 + bytes[offsetInBytes + 1]);
                    value = (int) value16;
                }

            }
            // else invalid return

            return value;
        }

        public override String ToString()
        {
            String s = "";
            int byteIdx=0;
            int value;
            if (valid)
            {
                for (int i = 0; i < spGroup.numItems; i++)
                {
                    value = (sd[i+spGroup.offsetInSensorDesc].numBytes == 1) ? bytes[byteIdx] : (bytes[byteIdx] * 256 + bytes[byteIdx + 1]);
                    s = s + sd[i + spGroup.offsetInSensorDesc].name + ": " + value + "\n";
                    byteIdx += sd[i + spGroup.offsetInSensorDesc].numBytes;
                }
            }
            else
            {
                s = "Invalid: only " + bytes.Length + " bytes";
            }
            return s;
        }

        internal bool IsValid()
        {
            return valid;
        }
    }
}
