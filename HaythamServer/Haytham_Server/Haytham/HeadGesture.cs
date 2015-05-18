
//<copyright file="HeadGesture.cs" company="ITU">
//This file is part of Haytham 
//Copyright (C) 2012 Diako Mardanbegi
// ------------------------------------------------------------------------
//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.

//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.

//You should have received a copy of the GNU General Public License
//along with this program.  If not, see <http://www.gnu.org/licenses/>.
// ------------------------------------------------------------------------
// </copyright>
// <author>Diako Mardanbegi</author>
// <email>dima@itu.dk</email>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;//point


namespace Haytham
{
    public class HeadGesture
    {


        /// <summary>
        /// Enum defining gesture directions.
        /// </summary>
        public enum GestureBasicCharacters
        {
            Unknown,
            NoMovement,
            Up,
            Right,
            Down,
            Left,
            UpRight,
            DownRight,
            DownLeft,
            UpLeft,
            TorsionRight,
            TorsionLeft
        }


        private Dictionary<List<GestureBasicCharacters>, string> gesturesDic = new Dictionary<List<GestureBasicCharacters>, string>();


        //...............................................Linear  Thresholds

        /// <summary>
        /// Maximum acceptable velocity of the pupil movements
        /// </summary>
        //Here we can differentiate between eye saccads and head movements
        //ATTENTION: this value is a function of camera frame rate
        //We only check the max speed because the min speed can always be 1 when we use a fast camera
        private const uint MaximumVelocity = 12;//

        /// <summary>
        /// Minimum acceptable velocity of the pupil movements
        /// </summary>
        //
        //ATTENTION: this value is a function of camera frame rate
        //Min speed should be larger when we use a fast camera
        private const uint MinimumVelocity = 2;// 1 is not good
        private const uint strokeLength_L = 3;



        //...............................................Torsion  Thresholds
        private const uint color_Thresh = 18;
        private const uint vel_D_Thresh =0;
        private const uint vel_HV_Thresh = 0;
        private const double majority =0.5;

        //.......................................................................
        private const Int32 longStopLength = 15;
        int sequenceSize = 600; 
        public List<GestureBasicCharacters> gestureSequenceLinear = new List<GestureBasicCharacters>();//MAx 500 frames 
        public List<GestureBasicCharacters> gestureSequenceTorsion = new List<GestureBasicCharacters>();//MAx 500 frames 
        public List<GestureBasicCharacters> gestureTestList = new List<GestureBasicCharacters>();//MAx 500 frames 

        /// <summary>
        /// put a set of predefined gestures into the gestureDic
        /// </summary>
        public void setGestureDic()
        {


            //U1

            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.Down, GestureBasicCharacters.Up }), "U_D");
            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.Down, GestureBasicCharacters.NoMovement, GestureBasicCharacters.Up }), "U_D");

            //R1


            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.Left, GestureBasicCharacters.Right }), "R_L");
            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.Left, GestureBasicCharacters.NoMovement, GestureBasicCharacters.Right }), "R_L");
            //D1

            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.Up, GestureBasicCharacters.Down }), "D_U");
            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.Up, GestureBasicCharacters.NoMovement, GestureBasicCharacters.Down }), "D_U");


            //L1

            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.Right, GestureBasicCharacters.Left }), "L_R");
            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.Right, GestureBasicCharacters.NoMovement, GestureBasicCharacters.Left }), "L_R");

            //UR1

            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.DownLeft, GestureBasicCharacters.UpRight }), "UR_DL");
            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.DownLeft, GestureBasicCharacters.NoMovement, GestureBasicCharacters.UpRight }), "UR_DL");



            //UL1

            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.DownRight, GestureBasicCharacters.UpLeft }), "UL_DR");
            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.DownRight, GestureBasicCharacters.NoMovement, GestureBasicCharacters.UpLeft }), "UL_DR");

            //DL1

            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.UpRight, GestureBasicCharacters.DownLeft }), "DL_UR");
            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.UpRight, GestureBasicCharacters.NoMovement, GestureBasicCharacters.DownLeft }), "DL_UR");
            //DR1

            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.UpLeft, GestureBasicCharacters.DownRight }), "DR_UL");
            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.UpLeft, GestureBasicCharacters.NoMovement, GestureBasicCharacters.DownRight }), "DR_UL");

            //U2

            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.Up, GestureBasicCharacters.Up }), "U_U");
            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.Up, GestureBasicCharacters.NoMovement, GestureBasicCharacters.Up }), "U_U");
            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.Down, GestureBasicCharacters.Up, GestureBasicCharacters.Up }), "U_U");


            //R2
            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.Right, GestureBasicCharacters.Right }), "R_R");
            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.Right, GestureBasicCharacters.NoMovement, GestureBasicCharacters.Right }), "R_R");
            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.Left, GestureBasicCharacters.Right, GestureBasicCharacters.Right }), "R_R");

            //D2
            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.Down, GestureBasicCharacters.Down }), "D_D");
            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.Down, GestureBasicCharacters.NoMovement, GestureBasicCharacters.Down }), "D_D");
            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.Up, GestureBasicCharacters.Down, GestureBasicCharacters.Down }), "D_D");

            //L2
            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.Left, GestureBasicCharacters.Left }), "L_L");
            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.Left, GestureBasicCharacters.NoMovement, GestureBasicCharacters.Left }), "L_L");
            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.Right, GestureBasicCharacters.Left, GestureBasicCharacters.Left }), "L_L");

            //UR2
            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.UpRight, GestureBasicCharacters.UpRight }), "UR_UR");
            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.UpRight, GestureBasicCharacters.NoMovement, GestureBasicCharacters.UpRight }), "UR_UR");
            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.UpLeft, GestureBasicCharacters.UpRight, GestureBasicCharacters.UpRight }), "UR_UR");

            //UL2
            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.UpLeft, GestureBasicCharacters.UpLeft }), "UL_UL");
            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.UpLeft, GestureBasicCharacters.NoMovement, GestureBasicCharacters.UpLeft }), "UL_UL");
            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.UpRight, GestureBasicCharacters.UpLeft, GestureBasicCharacters.UpLeft }), "UL_UL");

            //DL2
            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.DownLeft, GestureBasicCharacters.DownLeft }), "DL_DL");
            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.DownLeft, GestureBasicCharacters.NoMovement, GestureBasicCharacters.DownLeft }), "DL_DL");
            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.DownRight, GestureBasicCharacters.DownLeft, GestureBasicCharacters.DownLeft }), "DL_DL");

            //DR2
            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.DownRight, GestureBasicCharacters.DownRight }), "DR_DR");
            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.DownRight, GestureBasicCharacters.NoMovement, GestureBasicCharacters.DownRight }), "DR_DR");
            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.DownLeft, GestureBasicCharacters.DownRight, GestureBasicCharacters.DownRight }), "DR_DR");

            //TR

            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.TorsionLeft, GestureBasicCharacters.TorsionRight }), "TR");
            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.TorsionLeft, GestureBasicCharacters.NoMovement, GestureBasicCharacters.TorsionRight }), "TR");
           // gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.TorsionLeft, GestureBasicCharacters.TorsionRight, GestureBasicCharacters.TorsionLeft }), "TR");
            //TL

            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.TorsionRight, GestureBasicCharacters.TorsionLeft }), "TL");
            gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.TorsionRight, GestureBasicCharacters.NoMovement, GestureBasicCharacters.TorsionLeft }), "TL");
           // gesturesDic.Add(new List<GestureBasicCharacters>(new GestureBasicCharacters[] { GestureBasicCharacters.TorsionRight, GestureBasicCharacters.TorsionLeft, GestureBasicCharacters.TorsionRight }), "TL");


        }

        public int getLargerGestureLength()
        {
            int i = 0;
            foreach (var pair in gesturesDic)
            {
                if (pair.Value.Count() > i) i = pair.Value.Count();

            }
            return i;
        }


        /// <summary>
        /// Append a character to the gestureSequence
        /// </summary>
        /// <remarks>
        ///  unknown characters will be filtered out.
        /// </remarks>
        public void AddSegment(AForge.Point PCenter1F, AForge.Point PCenter0F)
        {
            Point PCenter0=new Point((int)PCenter0F.X,(int)PCenter0F.Y);
            Point PCenter1 = new Point((int)PCenter1F.X, (int)PCenter1F.Y);

            double segmentVelocity = GetDistance(PCenter1, PCenter0);

            #region continuous gesture
            GestureBasicCharacters direction = GetDirection(PCenter1, PCenter0, METState.Current.HowManyDirections4OR8);//4 OR 8

            if (segmentVelocity <= MaximumVelocity)
            {
               
                METState.Current.server.Send("Volume", new string[] { Convert.ToInt32( segmentVelocity).ToString(),direction.ToString() });

            }


            #endregion continuous gesture

            if (segmentVelocity < MinimumVelocity)
            {
                gestureSequenceLinear.Reverse();
                if (gestureSequenceLinear.Count() >= sequenceSize) gestureSequenceLinear.RemoveAt(0);
                gestureSequenceLinear.Add(GestureBasicCharacters.NoMovement);
                gestureSequenceLinear.Reverse();

                # region analyse 
                List<GestureBasicCharacters> sequence;

                    METState.Current.ProcessTimeEyeBranch.Timer("Linear gesture recog", "Start");
                    sequence = new List<GestureBasicCharacters>(gestureSequenceLinear);
                    bool gestureFound = analyseSequence(sequence);
                    METState.Current.ProcessTimeEyeBranch.Timer("Linear gesture recog", "Stop");
             
                # endregion 
            }
            else if (segmentVelocity >= MinimumVelocity && segmentVelocity <= MaximumVelocity)
            {



                if (direction != GestureBasicCharacters.Unknown)
                {
                    gestureSequenceLinear.Reverse();
                    if (gestureSequenceLinear.Count() >= sequenceSize) gestureSequenceLinear.RemoveAt(0);
                    gestureSequenceLinear.Add(direction);
                    //The range of the velocity [min max] is devided into 3 parts and for the higher velocities we add more items into the sequence

                    if (segmentVelocity >= (MinimumVelocity + ((MaximumVelocity - MinimumVelocity) / 3))) gestureSequenceLinear.Add(direction);
                    if (segmentVelocity >= (MinimumVelocity + 2 * ((MaximumVelocity - MinimumVelocity) / 3))) gestureSequenceLinear.Add(direction);
                    gestureSequenceLinear.Reverse();
                }
            }


        }

        /// <summary>
        /// Append a character to the gestureSequence
        /// </summary>
        /// <remarks>
        ///  unknown characters will be filtered out.
        /// </remarks>
        public void AddSegment(IrisPatch[] irisPatches)
        {


            #region color Control
            //checking if they are not covered by the eyelids
            if (irisPatches[4].patchAccepted & irisPatches[5].patchAccepted)
            {
                double MeanColorOf4And5 = (irisPatches[4].meanColor + irisPatches[5].meanColor) / 2;

                if (Math.Abs(irisPatches[2].meanColor - MeanColorOf4And5) > color_Thresh)
                {
                    irisPatches[2].patchAccepted = false;
                    irisPatches[2].Draw("Rejected");
                }
                if (Math.Abs(irisPatches[7].meanColor - MeanColorOf4And5) > color_Thresh)
                {
                    irisPatches[7].patchAccepted = false;
                    irisPatches[7].Draw("Rejected");
                }
                if (Math.Abs(irisPatches[1].meanColor - MeanColorOf4And5) > color_Thresh)
                {
                    irisPatches[1].patchAccepted = false;
                    irisPatches[1].Draw("Rejected");
                }
                if (Math.Abs(irisPatches[3].meanColor - MeanColorOf4And5) > color_Thresh)
                {
                    irisPatches[3].patchAccepted = false;
                    irisPatches[3].Draw("Rejected");
                }
                if (Math.Abs(irisPatches[6].meanColor - MeanColorOf4And5) > color_Thresh)
                {
                    irisPatches[6].patchAccepted = false;
                    irisPatches[6].Draw("Rejected");
                }
                if (Math.Abs(irisPatches[8].meanColor - MeanColorOf4And5) > color_Thresh)
                {
                    irisPatches[8].patchAccepted = false;
                    irisPatches[8].Draw("Rejected");
                }
            }

            #endregion color Control


            int RightTorsion = 0;
            int LeftTorsion = 0;
            int rightPoints = 0;
            int leftPoints = 0;
            float uniPoints = 0;
            float totalPoints = 0;


            #region Determine patch Direction

            ///DIRECTIONS
            ///         1
            ///     8       2
            /// 7               3
            ///     6       4
            ///         5


            if (irisPatches[1].patchAccepted)//Patch UpLeft
            {

                rightPoints = irisPatches[1].Histogram[2] + irisPatches[1].Histogram[1] + irisPatches[1].Histogram[3];
                leftPoints = irisPatches[1].Histogram[6] + irisPatches[1].Histogram[5] + irisPatches[1].Histogram[7];

                if (rightPoints > leftPoints)
                {
                    irisPatches[1].Direction = 2;
                    RightTorsion++;
                    uniPoints += rightPoints;
                }
                else if (rightPoints < leftPoints)
                {
                    irisPatches[1].Direction = 6;
                    LeftTorsion++;
                    uniPoints += leftPoints;
                }



            }
            if (irisPatches[3].patchAccepted)
            {
                rightPoints = irisPatches[3].Histogram[4] + irisPatches[3].Histogram[3] + irisPatches[3].Histogram[5];
                leftPoints = irisPatches[3].Histogram[8] + irisPatches[3].Histogram[1] + irisPatches[3].Histogram[7];

                if (rightPoints > leftPoints)
                {
                    irisPatches[3].Direction = 4;
                    RightTorsion++;
                    uniPoints += rightPoints;
                }
                else if (rightPoints < leftPoints)
                {
                    irisPatches[3].Direction = 8;
                    LeftTorsion++;
                    uniPoints += leftPoints;
                }


            }
            if (irisPatches[6].patchAccepted)
            {
                rightPoints = irisPatches[6].Histogram[1] + irisPatches[6].Histogram[8] + irisPatches[6].Histogram[7];
                leftPoints = irisPatches[6].Histogram[4] + irisPatches[6].Histogram[5] + irisPatches[6].Histogram[3];
                if (rightPoints > leftPoints)
                {
                    irisPatches[6].Direction = 8;
                    RightTorsion++;
                    uniPoints += rightPoints;
                }
                else if (rightPoints < leftPoints)
                {
                    irisPatches[6].Direction = 4;
                    LeftTorsion++;
                    uniPoints += leftPoints;
                }




            }
            if (irisPatches[8].patchAccepted)
            {
                rightPoints = irisPatches[8].Histogram[6] + irisPatches[8].Histogram[5] + irisPatches[8].Histogram[7];
                leftPoints = irisPatches[8].Histogram[1] + irisPatches[8].Histogram[2] + irisPatches[8].Histogram[3];
                if (rightPoints > leftPoints)
                {
                    irisPatches[8].Direction = 6;
                    RightTorsion++;
                    uniPoints += rightPoints;
                }
                else if (rightPoints < leftPoints)
                {
                    irisPatches[8].Direction = 2;
                    LeftTorsion++;
                    uniPoints += leftPoints;
                }




            }

            if (irisPatches[2].patchAccepted)
            {
                rightPoints = irisPatches[2].Histogram[2] + irisPatches[2].Histogram[3] + irisPatches[2].Histogram[4];
                leftPoints = irisPatches[2].Histogram[7] + irisPatches[2].Histogram[6] + irisPatches[2].Histogram[8];

                if (rightPoints > leftPoints)
                {
                    irisPatches[2].Direction = 3;
                    RightTorsion++;
                    uniPoints += rightPoints;
                }
                else if (rightPoints < leftPoints)
                {
                    irisPatches[2].Direction = 7;
                    LeftTorsion++;
                    uniPoints += leftPoints;
                }


            }
            if (irisPatches[4].patchAccepted)
            {
                rightPoints = irisPatches[4].Histogram[1] + irisPatches[4].Histogram[2] + irisPatches[4].Histogram[8];
                leftPoints = irisPatches[4].Histogram[4] + irisPatches[4].Histogram[5] + irisPatches[4].Histogram[6];


                if (rightPoints > leftPoints)
                {
                    irisPatches[4].Direction = 1;
                    RightTorsion++;
                    uniPoints += rightPoints;
                }
                else if (rightPoints < leftPoints)
                {
                    irisPatches[4].Direction = 5;
                    LeftTorsion++;
                    uniPoints += leftPoints;
                }






            }
            if (irisPatches[5].patchAccepted)
            {
                rightPoints = irisPatches[5].Histogram[4] + irisPatches[5].Histogram[5] + irisPatches[5].Histogram[6];
                leftPoints = irisPatches[5].Histogram[1] + irisPatches[5].Histogram[2] + irisPatches[5].Histogram[8];


                if (rightPoints > leftPoints)
                {
                    irisPatches[5].Direction = 5;
                    RightTorsion++;
                    uniPoints += rightPoints;
                }
                else if (rightPoints < leftPoints)
                {
                    irisPatches[5].Direction = 1;
                    LeftTorsion++;
                    uniPoints += leftPoints;
                }


            }
            if (irisPatches[7].patchAccepted)
            {
                rightPoints = irisPatches[7].Histogram[6] + irisPatches[7].Histogram[7] + irisPatches[7].Histogram[8];
                leftPoints = irisPatches[7].Histogram[2] + irisPatches[7].Histogram[3] + irisPatches[7].Histogram[4];

                if (rightPoints > leftPoints)
                {
                    irisPatches[7].Direction = 7;
                    RightTorsion++;
                    uniPoints += rightPoints;
                }
                else if (rightPoints < leftPoints)
                {
                    irisPatches[7].Direction = 3;
                    LeftTorsion++;
                    uniPoints += leftPoints;
                }


            }
            #endregion Determine patch Direction

#region update sequence

            int AcceptanceThresh = 0;//How many accepted patches
            for (int i = 1; i < 9; i++)
            {
                if (irisPatches[i].patchAccepted)
                {
                    AcceptanceThresh++;
                    totalPoints += irisPatches[i].vectorFieldX * irisPatches[i].vectorFieldY;

                }
            }

            // METState.Current.METCoreObject.SendToForm(uniPoints / totalPoints, "chartTest");



            gestureSequenceTorsion.Reverse();

            if (gestureSequenceTorsion.Count() >= sequenceSize) gestureSequenceTorsion.RemoveAt(0);

            if (RightTorsion == AcceptanceThresh)
            {
                if ((uniPoints / totalPoints) >= majority) gestureSequenceTorsion.Add(GestureBasicCharacters.TorsionRight);
                for (int i = 1; i < 9; i++) { if (irisPatches[i].patchAccepted) { irisPatches[i].Draw("Average"); } }




            }
            else if (LeftTorsion == AcceptanceThresh)
            {

                if ((uniPoints / totalPoints) >= majority) gestureSequenceTorsion.Add(GestureBasicCharacters.TorsionLeft);
                for (int i = 1; i < 9; i++) { if (irisPatches[i].patchAccepted) { irisPatches[i].Draw("Average"); } }

            }
            else gestureSequenceTorsion.Add(GestureBasicCharacters.NoMovement);


            gestureSequenceTorsion.Reverse();

            #endregion update sequence


            # region looking for gesture

            METState.Current.ProcessTimeEyeBranch.Timer("Torsion gesture recog", "Start");

            List<GestureBasicCharacters> sequence = new List<GestureBasicCharacters>(gestureSequenceTorsion);


            if (detectLongHeadStop(sequence))//Head is stoped (long stop) 
            {
                sequence = removeNoMovements(sequence);
                sequence = combineDuplicates(sequence);

                string foundGesture = searchSequence(sequence);

                if (foundGesture != "")
                {
                    GestureHandler temp = Gesture;
                    if (temp != null)
                    {
                        HeadGestureEventArgs args = new HeadGestureEventArgs(foundGesture,false);

                        gestureSequenceLinear.Clear();//linear movements sometimes occur while torsion 

                        temp(this, args);

                    }

                }

                //clear the main sequence 
                gestureSequenceTorsion.Clear();

            }


            METState.Current.ProcessTimeEyeBranch.Timer("Torsion gesture recog", "Stop");
            # endregion looking for gesture

        }




        public string sequenceToString(List<GestureBasicCharacters> sequence)
        {
            string g = "";

            sequence.Reverse();
            foreach(GestureBasicCharacters i in sequence )
            {
                switch (i)
                { 
                    case GestureBasicCharacters.Down:
                        g+="D_";
                        break;
                    case GestureBasicCharacters.Up:
                        g += "U_";
                        break;
                    case GestureBasicCharacters.Right:
                        g += "R_";
                        break;
                    case GestureBasicCharacters.Left:
                        g += "L_";
                        break;
                    case GestureBasicCharacters.UpLeft:
                        g += "UL_";
                        break;

                    case GestureBasicCharacters.UpRight:
                        g += "UR_";
                        break;
                    case GestureBasicCharacters.DownLeft:
                        g += "DL_";
                        break;
                    case GestureBasicCharacters.DownRight:
                        g += "DR_";
                        break;
                }

            }

           g= g.Remove(g.Count()-1,1);
            return g;
        
        }

        public bool analyseSequence(List<GestureBasicCharacters> sequence)
        {
            bool found = false ;

            sequence = filterStrokes(sequence);

            if (detectLongHeadStop(sequence))//Head is stoped (long stop) 
            {

               // sequence = combineNoMovements(sequence);
                sequence = removeNoMovements(sequence);
                if (sequence.Count() >= 1)
                {
                   // sequence.RemoveAt(0);
                   // if (sequence[sequence.Count() - 1] == GestureBasicCharacters.NoMovement) sequence.RemoveAt(sequence.Count() - 1);





                    #region record gesture
                    if (METState.Current.gestureRecording != "")//Recording the custom gesture
                    {


                        //Updating the gestureDic
                        for (int i = 0; i < gesturesDic.Count(); i++)
                        {
                            if (gesturesDic.ElementAt(i).Value == METState.Current.gestureRecording)
                            {
                                gesturesDic.Remove(gesturesDic.ElementAt(i).Key);
                                i--;
                            }
                        }

                        METState.Current.METCoreObject.SendToForm(sequenceToString(sequence), METState.Current.gestureRecording.ToString());
                        sequence.Reverse();
                        gesturesDic.Add(sequence, METState.Current.gestureRecording);
                        //stop recording
                        METState.Current.gestureRecording = "";


                    }
                    #endregion record gesture
                    #region find gesture
                    else
                    {

                        //search for gesture 

                        string foundGesture = searchSequence(sequence);
                        

                        if (foundGesture != "")
                        {
                           bool sr = HasBegining(foundGesture);
                            GestureHandler temp = Gesture;
                            if (temp != null)
                            {
                                found = true;
                                HeadGestureEventArgs args = new HeadGestureEventArgs(foundGesture,sr);

                                temp(this, args);

                            }


                        }
                    }
                    #endregion find gesture

                    gestureSequenceLinear.Clear();
                }

            }

            return found;
        }

        private bool HasBegining(string foundGesture)

        {
            bool ok = true;

            switch (foundGesture)
            {
                case "Blink":
                case "DbBlink":
                case "TR":
                case "TL":

                    ok = false;
                    break;
            }
            return ok;

        }


        public string searchSequence(List<GestureBasicCharacters> sequence)
        {
            string foundGesture = "";
            //cropping the sequence
            int n = getLargerGestureLength();
            if (sequence.Count() > n) sequence = sequence.GetRange(0, getLargerGestureLength());


            for (int i = 0; i < sequence.Count(); i++)
            {
                string temp = searchGestureDic(sequence);
                if (temp != "")
                {
                    foundGesture = temp;
                    break;
                }

                else
                {
                    if (sequence.Count() > 1) sequence.RemoveAt(sequence.Count() - 1);
                }
            }

            if (foundGesture == null) foundGesture = "";
            return foundGesture;

        }

        private string searchGestureDic(List<GestureBasicCharacters> sequence)
        {
            string ges = "";


            foreach (var pair in gesturesDic)
            {
                if (pair.Key.Count() == sequence.Count())
                {
                    bool equal = true;
                    for (int i = 0; i < sequence.Count(); i++)
                    {

                        if (sequence[i] != pair.Key[i])
                        {
                            equal = false;
                        }
                    }
                    if (equal)
                    {
                        ges = pair.Value;
                        break;
                    }

                }



            }


            return ges;


        }

        /// <summary>
        /// It returns Ture when the head is stoped for a long time
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        private bool detectLongHeadStop(List<GestureBasicCharacters> sequence)
        {
            bool stoped = false;

            int count = 1;
            for (int i = 0; i < (sequence.Count); i++)//start from the current frame
            {
                if (sequence[i] == GestureBasicCharacters.NoMovement)
                {
                    if (((i + 1) < sequence.Count()) && sequence[i] == sequence[i + 1])
                    {
                        count++;

                    }

                    else
                    {
                        if (count >= longStopLength)
                        {
                            stoped = true;

                        }

                        break;
                    }
                }

            }



            if (stoped)
            {
                METState.Current.eye.eyeData[0].tag = HeadGesture.GestureBasicCharacters.NoMovement.ToString();
                METState.Current.monitor.rectangleGazeData[0].tag = HeadGesture.GestureBasicCharacters.NoMovement.ToString();
                METState.Current.visualMarker.gazedMarkerHistory[0].tag = HeadGesture.GestureBasicCharacters.NoMovement.ToString();

            }
            return stoped;
        }


        /// <summary>
        /// This function replace the accepted strokes with a single character, and all short strokes with "NoMovement" characters
        /// The output of this function is the sequence of strokes or stops. 
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        private List<GestureBasicCharacters> filterStrokes(List<GestureBasicCharacters> sequence)
        {



                int count = 1;

                for (int i = 0; i < (sequence.Count); i++)//start from the current frame
                {

                    if (((i + 1) < sequence.Count) && sequence[i] == sequence[i + 1] && sequence[i] != GestureBasicCharacters.NoMovement)
                    {
                        count++;

                        //sequence.RemoveAt(i);
                        //i--;
                    }

                    else//It is not equal to the next one OR it is noMotion
                    {
                        if (count >= strokeLength_L)
                        {
                            //this stroke is long enough >> convert it to only one character
                            for (int j = 1; j < count; j++) sequence.RemoveAt(i - j);
                            i -= (count - 1);//correct i for the next iteration
                        }
                        else if (count == 1)
                        {
                            sequence[i] = GestureBasicCharacters.NoMovement;
                        }
                        else
                        {
                            //replace all the this short stroke with characters "NoMotion"
                            for (int j = 1; j < count; j++) sequence[i - j] = GestureBasicCharacters.NoMovement;
                            i -= (count - 1);//correctting the i for the next iteration
                        }

                        count = 1;

                    }




                }


            return sequence;
        }

        private List<GestureBasicCharacters> removeNoMovements(List<GestureBasicCharacters> sequence)
        {

            for (int i = 0; i < (sequence.Count); i++)//start from the current frame
            {
                if (sequence[i] == GestureBasicCharacters.NoMovement)
                {

                    sequence.RemoveAt(i);
                    i--;




                }



            }


            return sequence;
        }


        /// <summary>
        ///Replace noMevemetns with one character noMovement
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        private List<GestureBasicCharacters> combineNoMovements(List<GestureBasicCharacters> sequence)
        {


            for (int i = 0; i < (sequence.Count()); i++)//start from the current frame
            {
                if (sequence[i] == GestureBasicCharacters.NoMovement)
                {
                    if (((i + 1) < sequence.Count) && sequence[i] == sequence[i + 1])
                    {
                        sequence.RemoveAt(i);
                        i--;
                    }
                }
            }


            return sequence;
        }

        private List<GestureBasicCharacters> combineDuplicates(List<GestureBasicCharacters> sequence)
        {

        
            if (sequence.Count() > 2)
            {



                for (int i = 0; i < (sequence.Count); i++)//start from the current frame
                {
                   // if (sequence[i] != GestureBasicCharacters.NoMovement)
                    {
                        if (((i + 1) < sequence.Count) && sequence[i] == sequence[i + 1])
                        {
                           

                            sequence.RemoveAt(i);
                            i--;
                        }

                    }

                }


            }


            return sequence;
        }


        /// <summary>
        /// Calculates distance between 2 points
        /// </summary>
        /// <param name="p1">First point</param>
        /// <param name="p2">Second point</param>
        /// <returns>Distance between two points</returns>
        private static double GetDistance(Point p1, Point p2)
        {
            float dx = p1.X - p2.X;
            float dy = p1.Y - p2.Y;

            return Math.Sqrt(dx * dx + dy * dy);
        }

        /// <summary>
        /// Recognizes direction between two points
        /// </summary>
        /// <param name="deltaX">Length of movement in the horizontal direction</param>
        /// <param name="deltaY">Length of movement in the vertical direction</param>
        /// <returns>Gesture direction, if fails returns Unknown</returns>
        public GestureBasicCharacters GetDirection(Point start, Point end, int HowManyDirections)
        {
            float deltaX = end.X - start.X;
            float deltaY = end.Y - start.Y;

            //Be sure that  deltaX != 0 & deltaY != 0
            double angle = Math.Round(GetAngleOnDegree(deltaX, deltaY), 2);


            switch (HowManyDirections)
            {
                case 8:


                    if ((angle >= 0 & angle < 22.5) | (angle > 337.5 & angle <= 360))
                    {
                        return GestureBasicCharacters.Right;
                    }

                    else if ((angle >= 22.5 & angle <= 67.5))
                    {
                        return GestureBasicCharacters.UpRight;
                    }

                    else if ((angle > 67.5 & angle < 112.5))
                    {
                        return GestureBasicCharacters.Up;
                    }

                    else if ((angle >= 112.5 & angle <= 157.5))
                    {
                        return GestureBasicCharacters.UpLeft;
                    }
                    else if ((angle > 157.5 & angle < 202.5))
                    {
                        return GestureBasicCharacters.Left;
                    }
                    else if ((angle >= 202.5 & angle <= 247.5))
                    {
                        return GestureBasicCharacters.DownLeft;
                    }
                    else if ((angle > 247.5 & angle < 292.5))
                    {
                        return GestureBasicCharacters.Down;
                    }
                    else if ((angle >= 292.5 & angle <= 337.5))
                    {
                        return GestureBasicCharacters.DownRight;
                    }
                    else return GestureBasicCharacters.Unknown;

                    break;
                case 4:


                    if ((angle >= 0 & angle < 45) | (angle > 315 & angle <= 360))
                    {
                        return GestureBasicCharacters.Right;
                    }

                    else if ((angle > 45 & angle < 135))
                    {
                        return GestureBasicCharacters.Up;
                    }

                    else if ((angle > 135 & angle < 225))
                    {
                        return GestureBasicCharacters.Left;
                    }

                    else if ((angle > 225 & angle < 315))
                    {
                        return GestureBasicCharacters.Down;
                    }
                    else return GestureBasicCharacters.Unknown;

                    break;
                default:

                    return GestureBasicCharacters.Unknown;
                    break;
            }

        }

        public double GetAngleOnDegree(float deltaX, float deltaY)
        {

            double angle = 0;

            if (deltaX == 0 & deltaY > 0)
            {
                angle = 90;
            }
            if (deltaX > 0 & deltaY == 0)
            {
                angle = 0;
            }
            if (deltaX == 0 & deltaY < 0)
            {
                angle = 270;
            }
            if (deltaX < 0 & deltaY == 0)
            {
                angle = 180;
            }

            if (deltaX > 0 & deltaY > 0)
            {
                angle = Math.Atan(Math.Abs(deltaY) / Math.Abs(deltaX)) * (180 / Math.PI);
            }
            if (deltaX < 0 & deltaY > 0)
            {
                angle = 180 - Math.Atan(Math.Abs(deltaY) / Math.Abs(deltaX)) * (180 / Math.PI);
            }
            if (deltaX < 0 & deltaY < 0)
            {
                angle = Math.Atan(Math.Abs(deltaY) / Math.Abs(deltaX)) * (180 / Math.PI) + 180;
            }
            if (deltaX > 0 & deltaY < 0)
            {
                angle = 360 - Math.Atan(Math.Abs(deltaY) / Math.Abs(deltaX)) * (180 / Math.PI);
            }

            return angle;
        }

        /// <summary>
        /// Represents the method that will handle HeadGesture events.
        /// </summary>
        /// <param name="sender">The source of event.</param>
        /// <param name="start">A HeadGestureEventArgs that contains event data.</param>
        public delegate void GestureHandler(object sender, HeadGestureEventArgs e);

        /// <summary>
        /// Occurs whether valid head gesture is performed.
        /// </summary>
        public event GestureHandler Gesture;




    }
}
