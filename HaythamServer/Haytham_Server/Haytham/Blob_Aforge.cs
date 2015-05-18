// Blobs Browser sample application
// AForge.NET framework
// http://www.aforgenet.com/framework/
//
// Copyright © Andrew Kirillov, 2007-2009
// andrew.kirillov@aforgenet.com
//

//Code has been changed by Diako Mardanbegi, 2012
//dima@itu.dk

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;

using System.Data;
using System.Text;
using System.Windows.Forms;

using AForge;
using AForge.Imaging;
using AForge.Math.Geometry;

namespace Haytham
{
    public delegate void BlobSelectionHandler(object sender, Blob blob);

    public class Blob_Aforge
    {

        private int _imageWidth;
        public int imageWidth
        { get { return _imageWidth; } }
        private int _imageHeight;
        public int imageHeight
        { get { return _imageHeight; } }

        private double fullness;
        public Graphics g;
        public Bitmap image = null;

        private BlobCounter blobCounter = new BlobCounter();

        public Blob[] blobs_all;
        public Blob SelectedBlob;

        public List<Blob> blobs_Filtered = new List<Blob>();
        SimpleShapeChecker shapeChecker = new SimpleShapeChecker();

        Dictionary<int, List<IntPoint>> leftEdges = new Dictionary<int, List<IntPoint>>();
        Dictionary<int, List<IntPoint>> rightEdges = new Dictionary<int, List<IntPoint>>();
        Dictionary<int, List<IntPoint>> topEdges = new Dictionary<int, List<IntPoint>>();
        Dictionary<int, List<IntPoint>> bottomEdges = new Dictionary<int, List<IntPoint>>();

        public Dictionary<int, List<IntPoint>> hulls = new Dictionary<int, List<IntPoint>>();



        /// <summary>
        /// Detect Blobs in the bitmap image
        /// </summary>
        /// <param name="inputImage">Input bitmap image (Gray or RGB)</param>
        /// <param name="minFullness"> 0 if you don't want a fullness filter</param>
        /// <param name="maxNumOfFilteredBlobs"> How many filtered blob do you want be save in blobs_filter list</param>
        /// 
        /// <returns></returns>
        public Blob_Aforge(Bitmap inputImage, int minWidth, int maxWidth, int minHeight, int maxHeight, double minFullness, int maxNumOfFilteredBlobs)
        {
            try
            {
                leftEdges.Clear();
                rightEdges.Clear();
                topEdges.Clear();
                bottomEdges.Clear();
                hulls.Clear();
                //quadrilaterals.Clear();

                ///Get Image
                this.image = AForge.Imaging.Image.Clone(inputImage, PixelFormat.Format24bppRgb);//

                _imageWidth = this.image.Width;
                _imageHeight = this.image.Height;




                ///Size Filter
                blobCounter.FilterBlobs = true;
                blobCounter.MinHeight = minHeight;
                blobCounter.MinWidth = minWidth;
                blobCounter.MaxHeight = maxHeight;
                blobCounter.MaxWidth = maxWidth;
                blobCounter.ObjectsOrder = ObjectsOrder.Area;


                ///Detection
                ///
                blobCounter.ProcessImage(this.image);
                blobs_all = blobCounter.GetObjectsInformation();


                GrahamConvexHull grahamScan = new GrahamConvexHull();

                foreach (Blob blob in blobs_all)
                {
                    fullness = blob.Fullness;



                    if (fullness > minFullness & blobs_Filtered.Count < maxNumOfFilteredBlobs)///Fullness Filter
                    {

                                                     
                

                        List<IntPoint> leftEdge = new List<IntPoint>();
                        List<IntPoint> rightEdge = new List<IntPoint>();
                        //  List<IntPoint> topEdge = new List<IntPoint>();
                        //  List<IntPoint> bottomEdge = new List<IntPoint>();

                        // collect edge points
                        blobCounter.GetBlobsLeftAndRightEdges(blob, out leftEdge, out rightEdge);
                        //  blobCounter.GetBlobsTopAndBottomEdges(blob, out topEdge, out bottomEdge);

                        leftEdges.Add(blob.ID, leftEdge);
                        rightEdges.Add(blob.ID, rightEdge);
                        //   topEdges.Add(blob.ID, topEdge);
                        //  bottomEdges.Add(blob.ID, bottomEdge);

                        // find convex hull
                        List<IntPoint> edgePoints = new List<IntPoint>();
                        edgePoints.AddRange(leftEdge);
                        edgePoints.AddRange(rightEdge);

                        shapeChecker.MinAcceptableDistortion=(float)0.5;
                        shapeChecker.RelativeDistortionLimit = (float)0.15;

                        if (shapeChecker.IsCircle(edgePoints))
                        {
                            blobs_Filtered.Add(blob);
                            List<IntPoint> hull = grahamScan.FindHull(edgePoints);
                            hulls.Add(blobs_Filtered.Count - 1, hull);//sinchronized with blobs_filtered items



                        }



                    }
                }



               DrawBlobImage();
                  
            }
            catch (Exception error)
            {
                //System.Windows.Forms.MessageBox.Show(error.ToString());
                // METState.Current.ErrorSound.Play();
            }
        }

        
        public void DrawBlobImage()
        {


            // create convex hull searching algorithm
            //GrahamConvexHull hullFinder = new GrahamConvexHull();


            // lock image to draw on it
            BitmapData data = this.image.LockBits(new Rectangle(0, 0, this._imageWidth, this._imageHeight), ImageLockMode.ReadWrite, this.image.PixelFormat);

            // process each blob

            for (int i = 0; i < blobs_Filtered.Count; i++)
            {

                Drawing.Polygon(data, hulls[i], Color.Red);

            }

            this.image.UnlockBits(data);
        }

        public AForge.Point[] GetBlobBorder(Blob blob, Rectangle   transferROI,Size fullImageSize, out bool somePointsAreOnROIBorder)
        {
            bool temp = false;
            List<IntPoint> edgePoints = new List<IntPoint>();

            List<IntPoint> leftEdge = new List<IntPoint>();
            List<IntPoint> rightEdge = new List<IntPoint>();

            blobCounter.GetBlobsLeftAndRightEdges(blob, out leftEdge, out rightEdge);

            // collect edge points
            edgePoints.AddRange(leftEdge);
            edgePoints.AddRange(rightEdge);



            // Convert list of AForge.NET's IntPoint to array of .NET's Point

            AForge.Point[] border = new AForge.Point[edgePoints.Count];

            int fromBorders=3;

            for (int i = 0, n = edgePoints.Count; i < n; i++)
            {

                border[i] = new AForge.Point(edgePoints[i].X+transferROI.X , edgePoints[i].Y+transferROI.Y );

                if ((border[i].X < fromBorders || border[i].X > fullImageSize.Width - fromBorders) || (border[i].Y < fromBorders || border[i].Y > fullImageSize.Height - fromBorders)) temp = true;

            }





            ////..........................................................................test

            //  // lock image to draw on it
            //  BitmapData data = this.image.LockBits(new Rectangle(0, 0, this._imageWidth, this._imageHeight), ImageLockMode.ReadWrite, this.image.PixelFormat);

            //  // process each blob



            //      Drawing.Polygon(data, edgePoints, Color.Black);


            //  this.image.UnlockBits(data);
            ////.......................................................................




            somePointsAreOnROIBorder = temp;

            return border;


        }

    }

}
