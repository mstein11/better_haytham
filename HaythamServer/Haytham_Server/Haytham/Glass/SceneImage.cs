using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Emgu.CV.Structure;
using Emgu.CV;
using AForge.Imaging;
using AForge.Imaging.Filters;

namespace Haytham.Glass
{
    public class SceneImage
    {

        ImageProcessing_Emgu EmgImgProcssing;
        public Blob_Aforge boardBlob;

       public  System.Drawing.Image result_Image;
       public System.Drawing.Image temp_Image;

        Blob[] targets_blobs;

        private bool DetectCalibrationTargets(System.Drawing.Image img,int threshold, bool invertImg)
        {
            targets_blobs = null;


            Image<Gray, Byte> GrayImg = prepareImg3( img,threshold,invertImg);

           // 
            
            boardBlob = new Blob_Aforge(GrayImg.Bitmap, 10, 150, 10, 150, 0.3, 10);
temp_Image = GrayImg.Bitmap;

            List<Blob> filtered = new List<Blob>();

            foreach (Blob b in boardBlob.blobs_all)
            {
                 //double distToTopLeft = Math.Sqrt((Math.Pow(b.CenterOfGravity.X - 0, 2)) + (Math.Pow(b.CenterOfGravity.Y - 0, 2)));
                // double distToTopRight = Math.Sqrt((Math.Pow(b.CenterOfGravity.X - 0, 2)) + (Math.Pow(b.CenterOfGravity.Y - 0, 2)));
                int offs = 30;
                bool cond1=(b.CenterOfGravity.X < offs | b.CenterOfGravity.X>GrayImg.Width-offs);
                bool cond2=(b.CenterOfGravity.Y < offs | b.CenterOfGravity.Y>GrayImg.Height-offs);
 
                if (cond1|cond2)
                 {

                 }
                 else
                 {
                     filtered.Add(b);
                 }
            }
            boardBlob.blobs_all = filtered.ToArray();

            Image<Bgr, Byte> blankImg = new Image<Bgr, byte>(GrayImg.Width, GrayImg.Height);//GrayImg.Bitmap);

            //Image<Bgr, Byte> temp = EmgImgProcssing.ColoredMask((Bitmap)boardBlob.image, blankImg, new Bgr(System.Drawing.Color.DarkBlue), false);
            Image<Bgr, Byte> temp = new Image<Bgr, byte>((Bitmap)boardBlob.image);






            if (boardBlob.blobs_all.Count() == 1)
            {
                targets_blobs = new Blob[1];
                targets_blobs[0] = boardBlob.blobs_all[0];
            }
            else if (boardBlob.blobs_all.Count() == 4)
            {
                targets_blobs = getSorted_4blobs(boardBlob.blobs_all);
            }
            else if (boardBlob.blobs_all.Count() == 9)
            {
                targets_blobs = getSorted_9blobs(boardBlob.blobs_all);
            }
            else
            {
                result_Image = (Bitmap)temp.Bitmap.Clone();

                return false;
            }



            //Drawing
            int txt=1;
            foreach (AForge.Imaging.Blob b in targets_blobs)
            {
                EmgImgProcssing.DrawCircle(temp, (int)b.CenterOfGravity.X, (int)b.CenterOfGravity.Y, Color.Red);
                EmgImgProcssing.DrawText(temp, (int)b.CenterOfGravity.X, (int)b.CenterOfGravity.Y,txt.ToString(), Color.Red);
                txt++;
            }

            result_Image = (Bitmap)temp.Bitmap.Clone();


            return true;


            
        }

        private Image<Gray, Byte> prepareImg1(System.Drawing.Image img,int threshold, bool invertImg){



            Image<Gray, Byte> GrayImg = new Image<Gray, byte>((Bitmap)img);

            

            EmgImgProcssing = new ImageProcessing_Emgu();
            if (threshold == -1)
            {
                 GrayImg = EmgImgProcssing.Filter_PupilAdaptiveThreshold(GrayImg, 20, invertImg, -1).Dilate(5).Erode(3);             

            }

            else
            {
                GrayImg = EmgImgProcssing.Filter_Threshold(GrayImg, threshold, invertImg).Erode(1).Dilate(1);
            }


            return GrayImg;

         
        }
        private Image<Gray, Byte> prepareImg2(System.Drawing.Image img, int threshold, bool invertImg)
        {



            Image<Gray, Byte> GrayImg = new Image<Gray, byte>((Bitmap)img);

       
            EmgImgProcssing = new ImageProcessing_Emgu();
   

                // create the filter
                BradleyLocalThresholding filter2 = new BradleyLocalThresholding();
                // apply the filter
                filter2.ApplyInPlace(GrayImg.Bitmap);

                GrayImg=  GrayImg.Erode(1).Dilate(5).Erode(1) ;

              // create filter
              Invert filter3 = new Invert();
              // apply the filter
              filter3.ApplyInPlace(GrayImg.Bitmap);


              return GrayImg;

         
        }
        private Image<Gray, Byte> prepareImg3(System.Drawing.Image img, int threshold, bool invertImg)
        {



            // create filter
            ColorFiltering filter = new ColorFiltering();
            // set color ranges to keep
            filter.Red = new AForge.IntRange(80, 255);
            filter.Green = new AForge.IntRange(0, 50);
            filter.Blue = new AForge.IntRange(0, 90);

            // apply the filter
            Bitmap colorChannelImg = filter.Apply((Bitmap)img);


            temp_Image = colorChannelImg;
             Image<Gray, Byte> GrayImg = new Image<Gray, byte>((Bitmap)colorChannelImg);
             EmgImgProcssing = new ImageProcessing_Emgu();
             GrayImg = EmgImgProcssing.Filter_Threshold2(GrayImg, threshold, invertImg).Erode(1).Dilate(1);

            return GrayImg;

        }




        /// <summary>
        /// This function reurns the (x,y) position of the target number i in the image. 
        /// If there is only one blob in the image it returns that blob. in this case i must be <= 1
        /// If there are 4 blobs in the image it returns the blob number i. in this case i must be <= 4
        /// If there are 9 blobs in the image it returns the blob number i. in this case i must be <= 9
        /// 
        /// </summary>
        /// <param name="img"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public Point getCalibrationTarget(System.Drawing.Image img,int threshold, int i, bool invertImg)
        {


            if (DetectCalibrationTargets(img,threshold, invertImg))
      
            {
                switch (targets_blobs.Count())
                { 
                    case 1:
                        return new Point((int)targets_blobs[0].CenterOfGravity.X,(int)targets_blobs[0].CenterOfGravity.Y);
                        
                    case 4:
                        if (i > 4) break;
                        else return new Point((int)targets_blobs[i - 1].CenterOfGravity.X, (int)targets_blobs[i - 1].CenterOfGravity.Y);

                        
                    case 9:
                        if (i > 9) break;
                        else return new Point((int)targets_blobs[i - 1].CenterOfGravity.X, (int)targets_blobs[i - 1].CenterOfGravity.Y);

                       
                
                }


            }
                //Calibration targets NOT detected
                return new Point(-1, -1);
            
        }

        private Blob[] getSorted_4blobs(Blob[] blbs)
        {


            float Mean_X = 0;
            float Mean_Y = 0;
            Blob[] SortedBlobs_4 = new Blob[4];

            for (int i = 0; i < 4; i++)
            {
                Mean_X += blbs[i].CenterOfGravity.X;
                Mean_Y += blbs[i].CenterOfGravity.Y;

            }
            Mean_X /= (float)4.0;
            Mean_Y /= (float)4.0;

            //1    2
            //3    4
            for (int i = 0; i < 4; i++)
            {
                if (blbs[i].CenterOfGravity.X < Mean_X & blbs[i].CenterOfGravity.Y < Mean_Y) SortedBlobs_4[0] = blbs[i];
                if (blbs[i].CenterOfGravity.X > Mean_X & blbs[i].CenterOfGravity.Y < Mean_Y) SortedBlobs_4[1] = blbs[i];
                if (blbs[i].CenterOfGravity.X > Mean_X & blbs[i].CenterOfGravity.Y > Mean_Y) SortedBlobs_4[3] = blbs[i];
                if (blbs[i].CenterOfGravity.X < Mean_X & blbs[i].CenterOfGravity.Y > Mean_Y) SortedBlobs_4[2] = blbs[i];

            }
            return SortedBlobs_4;

        }


        private Blob[] getSorted_9blobs(Blob[] blbs)
        {


            // sort array by x
            Array.Sort(blbs, delegate(Blob blob1, Blob blob2)
            {
                return blob1.CenterOfGravity.X.CompareTo(blob2.CenterOfGravity.X);
            });



            //make columns
            Blob[] column_1 = new Blob[3];
            Array.Copy(blbs, 0, column_1, 0, 3);


            Blob[] column_2 = new Blob[3];
            Array.Copy(blbs, 3, column_2, 0, 3);


            Blob[] column_3 = new Blob[3];
            Array.Copy(blbs, 6, column_3, 0, 3);




            //sort columns by y value
            Array.Sort(column_1, delegate(Blob blob1, Blob blob2)
            {
                return blob1.CenterOfGravity.Y.CompareTo(blob2.CenterOfGravity.Y);
            });
            Array.Sort(column_2, delegate(Blob blob1, Blob blob2)
            {
                return blob1.CenterOfGravity.Y.CompareTo(blob2.CenterOfGravity.Y);
            });
            Array.Sort(column_3, delegate(Blob blob1, Blob blob2)
            {
                return blob1.CenterOfGravity.Y.CompareTo(blob2.CenterOfGravity.Y);
            });

            //debug
            //Console.WriteLine("1: " + column_1[0].X + "   2: " + column_2[0].X + "   3: " + column_3[0].X);
            //Console.WriteLine("4: " + column_1[1].X + "   5: " + column_2[1].X + "   6: " + column_3[1].X);
            //Console.WriteLine("7: " + column_1[2].X + "   8: " + column_2[2].X + "   9: " + column_3[2].X);

            blbs[0] = column_1[0];
            blbs[1] = column_2[0];
            blbs[2] = column_3[0];

            blbs[3] = column_1[1];
            blbs[4] = column_2[1];
            blbs[5] = column_3[1];

            blbs[6] = column_1[2];
            blbs[7] = column_2[2];
            blbs[8] = column_3[2];

            return blbs;

        }


    }
}
