
// Glyph Recognition Studio
// http://www.aforgenet.com/projects/gratf/
//// Copyright © Andrew Kirillov, 2010
// andrew.kirillov@aforgenet.com
//
//Code has been changed by Diako Mardanbegi, 2012
//dima@itu.dk

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

//using AForge;
using AForge.Math.Geometry;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Vision.GlyphRecognition;
//using AForge;

namespace Haytham
{
    public class GlyphImageProcessor
    {

        public struct GazedMarkerData
        {

            public string tag { get; set; }
            public AForge.Point gaze { get; set; }
            public Point markerCenter { get; set; }
            public string name { get; set; }

        }
        public GazedMarkerData[] gazedMarkerHistory = new GazedMarkerData[500];
        public List<ExtractedGlyphData> foundGlyphs;

        // glyph recognizer to use for glyph recognition in video
        public GlyphRecognizer recognizer = new GlyphRecognizer(5);

        // quadrilateral transformation used to put image in place of glyph
        public BackwardQuadrilateralTransformation quadrilateralTransformation = new BackwardQuadrilateralTransformation();

        // default pen and color to highlight glyphs
        private Pen defaultPen = new Pen( Color.Red, 3 );
        private Font defaultFont = new Font( FontFamily.GenericSerif, 15, FontStyle.Bold );

        public GlyphImageProcessor(int size)
        {
            recognizer = new GlyphRecognizer(size);

            GlyphVisualizationData visualizationData;
            byte[,] data;
            GlyphDatabase gDB= new GlyphDatabase(5);



            if (size == 5)
            {
                #region Monitors

                //Monitor 1

                data = new byte[5, 5];
                data[0, 0] = 0;
                data[0, 1] = 0;
                data[0, 2] = 0;
                data[0, 3] = 0;
                data[0, 4] = 0;

                data[1, 0] = 0;
                data[1, 1] = 1;
                data[1, 2] = 1;
                data[1, 3] = 0;
                data[1, 4] = 0;

                data[2, 0] = 0;
                data[2, 1] = 0;
                data[2, 2] = 1;
                data[2, 3] = 0;
                data[2, 4] = 0;

                data[3, 0] = 0;
                data[3, 1] = 0;
                data[3, 2] = 0;
                data[3, 3] = 1;
                data[3, 4] = 0;

                data[4, 0] = 0;
                data[4, 1] = 0;
                data[4, 2] = 0;
                data[4, 3] = 0;
                data[4, 4] = 0;


                Glyph S1 = new Glyph("Monitor1", data);
                visualizationData = new GlyphVisualizationData(Color.Red);
                S1.UserData = visualizationData;

                //Monitor 2

                data = new byte[5, 5];
                data[0, 0] = 0;
                data[0, 1] = 0;
                data[0, 2] = 0;
                data[0, 3] = 0;
                data[0, 4] = 0;

                data[1, 0] = 0;
                data[1, 1] = 1;
                data[1, 2] = 0;
                data[1, 3] = 1;
                data[1, 4] = 0;

                data[2, 0] = 0;
                data[2, 1] = 0;
                data[2, 2] = 1;
                data[2, 3] = 0;
                data[2, 4] = 0;

                data[3, 0] = 0;
                data[3, 1] = 0;
                data[3, 2] = 0;
                data[3, 3] = 1;
                data[3, 4] = 0;

                data[4, 0] = 0;
                data[4, 1] = 0;
                data[4, 2] = 0;
                data[4, 3] = 0;
                data[4, 4] = 0;


                Glyph S2 = new Glyph("Monitor2", data);
                visualizationData = new GlyphVisualizationData(Color.Red);
                S2.UserData = visualizationData;

                //Monitor 3

                data = new byte[5, 5];
                data[0, 0] = 0;
                data[0, 1] = 0;
                data[0, 2] = 0;
                data[0, 3] = 0;
                data[0, 4] = 0;

                data[1, 0] = 0;
                data[1, 1] = 1;
                data[1, 2] = 0;
                data[1, 3] = 0;
                data[1, 4] = 0;

                data[2, 0] = 0;
                data[2, 1] = 1;
                data[2, 2] = 1;
                data[2, 3] = 0;
                data[2, 4] = 0;

                data[3, 0] = 0;
                data[3, 1] = 0;
                data[3, 2] = 0;
                data[3, 3] = 1;
                data[3, 4] = 0;

                data[4, 0] = 0;
                data[4, 1] = 0;
                data[4, 2] = 0;
                data[4, 3] = 0;
                data[4, 4] = 0;


                Glyph S3 = new Glyph("Monitor3", data);
                visualizationData = new GlyphVisualizationData(Color.Red);
                S3.UserData = visualizationData;

                //Monitor 4

                data = new byte[5, 5];
                data[0, 0] = 0;
                data[0, 1] = 0;
                data[0, 2] = 0;
                data[0, 3] = 0;
                data[0, 4] = 0;

                data[1, 0] = 0;
                data[1, 1] = 1;
                data[1, 2] = 1;
                data[1, 3] = 1;
                data[1, 4] = 0;

                data[2, 0] = 0;
                data[2, 1] = 0;
                data[2, 2] = 1;
                data[2, 3] = 0;
                data[2, 4] = 0;

                data[3, 0] = 0;
                data[3, 1] = 0;
                data[3, 2] = 0;
                data[3, 3] = 1;
                data[3, 4] = 0;

                data[4, 0] = 0;
                data[4, 1] = 0;
                data[4, 2] = 0;
                data[4, 3] = 0;
                data[4, 4] = 0;


                Glyph S4 = new Glyph("Monitor4", data);
                visualizationData = new GlyphVisualizationData(Color.Red);
                S4.UserData = visualizationData;

                //Monitor 5

                data = new byte[5, 5];
                data[0, 0] = 0;
                data[0, 1] = 0;
                data[0, 2] = 0;
                data[0, 3] = 0;
                data[0, 4] = 0;

                data[1, 0] = 0;
                data[1, 1] = 1;
                data[1, 2] = 0;
                data[1, 3] = 1;
                data[1, 4] = 0;

                data[2, 0] = 0;
                data[2, 1] = 0;
                data[2, 2] = 1;
                data[2, 3] = 1;
                data[2, 4] = 0;

                data[3, 0] = 0;
                data[3, 1] = 0;
                data[3, 2] = 0;
                data[3, 3] = 1;
                data[3, 4] = 0;

                data[4, 0] = 0;
                data[4, 1] = 0;
                data[4, 2] = 0;
                data[4, 3] = 0;
                data[4, 4] = 0;


                Glyph S5 = new Glyph("Monitor5", data);
                visualizationData = new GlyphVisualizationData(Color.Red);
                S5.UserData = visualizationData;

                //Monitor 6

                data = new byte[5, 5];
                data[0, 0] = 0;
                data[0, 1] = 0;
                data[0, 2] = 0;
                data[0, 3] = 0;
                data[0, 4] = 0;

                data[1, 0] = 0;
                data[1, 1] = 1;
                data[1, 2] = 0;
                data[1, 3] = 1;
                data[1, 4] = 0;

                data[2, 0] = 0;
                data[2, 1] = 0;
                data[2, 2] = 1;
                data[2, 3] = 1;
                data[2, 4] = 0;

                data[3, 0] = 0;
                data[3, 1] = 1;
                data[3, 2] = 0;
                data[3, 3] = 1;
                data[3, 4] = 0;

                data[4, 0] = 0;
                data[4, 1] = 0;
                data[4, 2] = 0;
                data[4, 3] = 0;
                data[4, 4] = 0;


                Glyph S6 = new Glyph("Monitor6", data);
                visualizationData = new GlyphVisualizationData(Color.Red);
                S6.UserData = visualizationData;

                //Monitor 7

                data = new byte[5, 5];
                data[0, 0] = 0;
                data[0, 1] = 0;
                data[0, 2] = 0;
                data[0, 3] = 0;
                data[0, 4] = 0;

                data[1, 0] = 0;
                data[1, 1] = 1;
                data[1, 2] = 0;
                data[1, 3] = 1;
                data[1, 4] = 0;

                data[2, 0] = 0;
                data[2, 1] = 0;
                data[2, 2] = 1;
                data[2, 3] = 0;
                data[2, 4] = 0;

                data[3, 0] = 0;
                data[3, 1] = 0;
                data[3, 2] = 0;
                data[3, 3] = 1;
                data[3, 4] = 0;

                data[4, 0] = 0;
                data[4, 1] = 0;
                data[4, 2] = 0;
                data[4, 3] = 0;
                data[4, 4] = 0;


                Glyph S7 = new Glyph("Monitor7", data);
                visualizationData = new GlyphVisualizationData(Color.Red);
                S7.UserData = visualizationData;

                //Monitor 8

                data = new byte[5, 5];
                data[0, 0] = 0;
                data[0, 1] = 0;
                data[0, 2] = 0;
                data[0, 3] = 0;
                data[0, 4] = 0;

                data[1, 0] = 0;
                data[1, 1] = 1;
                data[1, 2] = 1;
                data[1, 3] = 1;
                data[1, 4] = 0;

                data[2, 0] = 0;
                data[2, 1] = 0;
                data[2, 2] = 0;
                data[2, 3] = 1;
                data[2, 4] = 0;

                data[3, 0] = 0;
                data[3, 1] = 1;
                data[3, 2] = 1;
                data[3, 3] = 1;
                data[3, 4] = 0;

                data[4, 0] = 0;
                data[4, 1] = 0;
                data[4, 2] = 0;
                data[4, 3] = 0;
                data[4, 4] = 0;


                Glyph S8 = new Glyph("Monitor8", data);
                visualizationData = new GlyphVisualizationData(Color.Red);
                S8.UserData = visualizationData;

                //Monitor 9

                data = new byte[5, 5];
                data[0, 0] = 0;
                data[0, 1] = 0;
                data[0, 2] = 0;
                data[0, 3] = 0;
                data[0, 4] = 0;

                data[1, 0] = 0;
                data[1, 1] = 0;
                data[1, 2] = 1;
                data[1, 3] = 0;
                data[1, 4] = 0;

                data[2, 0] = 0;
                data[2, 1] = 1;
                data[2, 2] = 0;
                data[2, 3] = 1;
                data[2, 4] = 0;

                data[3, 0] = 0;
                data[3, 1] = 0;
                data[3, 2] = 1;
                data[3, 3] = 1;
                data[3, 4] = 0;

                data[4, 0] = 0;
                data[4, 1] = 0;
                data[4, 2] = 0;
                data[4, 3] = 0;
                data[4, 4] = 0;


                Glyph S9 = new Glyph("Monitor9", data);
                visualizationData = new GlyphVisualizationData(Color.Red);
                S9.UserData = visualizationData;

                //Monitor 10

                data = new byte[5, 5];
                data[0, 0] = 0;
                data[0, 1] = 0;
                data[0, 2] = 0;
                data[0, 3] = 0;
                data[0, 4] = 0;

                data[1, 0] = 0;
                data[1, 1] = 1;
                data[1, 2] = 1;
                data[1, 3] = 1;
                data[1, 4] = 0;

                data[2, 0] = 0;
                data[2, 1] = 1;
                data[2, 2] = 0;
                data[2, 3] = 0;
                data[2, 4] = 0;

                data[3, 0] = 0;
                data[3, 1] = 1;
                data[3, 2] = 0;
                data[3, 3] = 1;
                data[3, 4] = 0;

                data[4, 0] = 0;
                data[4, 1] = 0;
                data[4, 2] = 0;
                data[4, 3] = 0;
                data[4, 4] = 0;


                Glyph S10 = new Glyph("Monitor10", data);
                visualizationData = new GlyphVisualizationData(Color.Red);
                S10.UserData = visualizationData;




                #endregion Monitors

                #region Roomba glyph
                //Roomba

                data = new byte[5, 5];
                data[0, 0] = 0;
                data[0, 1] = 0;
                data[0, 2] = 0;
                data[0, 3] = 0;
                data[0, 4] = 0;

                data[1, 0] = 0;
                data[1, 1] = 1;
                data[1, 2] = 0;
                data[1, 3] = 1;
                data[1, 4] = 0;

                data[2, 0] = 0;
                data[2, 1] = 1;
                data[2, 2] = 1;
                data[2, 3] = 1;
                data[2, 4] = 0;

                data[3, 0] = 0;
                data[3, 1] = 1;
                data[3, 2] = 1;
                data[3, 3] = 1;
                data[3, 4] = 0;

                data[4, 0] = 0;
                data[4, 1] = 0;
                data[4, 2] = 0;
                data[4, 3] = 0;
                data[4, 4] = 0;
                Glyph roomba = new Glyph("Roomba", data);
                visualizationData = new GlyphVisualizationData(Color.Yellow);
                roomba.UserData = visualizationData;
                #endregion Roomba glyph
                gDB = new GlyphDatabase(5);
                gDB.Add(S1);
                gDB.Add(S2);
                gDB.Add(S3);
                gDB.Add(S4);
                gDB.Add(S5);
                gDB.Add(S6);
                gDB.Add(S7);
                gDB.Add(S8);
                gDB.Add(S9);
                gDB.Add(S10);
                gDB.Add(roomba);
            }
            else if (size == 6)
            {

                Color MarkerColor = Color.GreenYellow;
                #region Objects 6*6 glype

                data = new byte[6, 6];
                data[0, 0] = 0;
                data[0, 1] = 0;
                data[0, 2] = 0;
                data[0, 3] = 0;
                data[0, 4] = 0;
                data[0, 5] = 0;

                data[1, 0] = 0;
                data[1, 1] = 0;
                data[1, 2] = 1;
                data[1, 3] = 0;
                data[1, 4] = 1;
                data[1, 5] = 0;

                data[2, 0] = 0;
                data[2, 1] = 1;
                data[2, 2] = 0;
                data[2, 3] = 1;
                data[2, 4] = 0;
                data[2, 5] = 0;

                data[3, 0] = 0;
                data[3, 1] = 0;
                data[3, 2] = 1;
                data[3, 3] = 0;
                data[3, 4] = 1;
                data[3, 5] = 0;

                data[4, 0] = 0;
                data[4, 1] = 1;
                data[4, 2] = 0;
                data[4, 3] = 1;
                data[4, 4] = 1;
                data[4, 5] = 0;

                data[5, 0] = 0;
                data[5, 1] = 0;
                data[5, 2] = 0;
                data[5, 3] = 0;
                data[5, 4] = 0;
                data[5, 5] = 0;

                Glyph o1 = new Glyph("Marker_6_1", data);
                visualizationData = new GlyphVisualizationData(MarkerColor);
                o1.UserData = visualizationData;



                data = new byte[6, 6];
                data[0, 0] = 0;
                data[0, 1] = 0;
                data[0, 2] = 0;
                data[0, 3] = 0;
                data[0, 4] = 0;
                data[0, 5] = 0;

                data[1, 0] = 0;
                data[1, 1] = 1;
                data[1, 2] = 0;
                data[1, 3] = 0;
                data[1, 4] = 1;
                data[1, 5] = 0;

                data[2, 0] = 0;
                data[2, 1] = 0;
                data[2, 2] = 0;
                data[2, 3] = 1;
                data[2, 4] = 0;
                data[2, 5] = 0;

                data[3, 0] = 0;
                data[3, 1] = 0;
                data[3, 2] = 1;
                data[3, 3] = 0;
                data[3, 4] = 1;
                data[3, 5] = 0;

                data[4, 0] = 0;
                data[4, 1] = 1;
                data[4, 2] = 0;
                data[4, 3] = 0;
                data[4, 4] = 1;
                data[4, 5] = 0;

                data[5, 0] = 0;
                data[5, 1] = 0;
                data[5, 2] = 0;
                data[5, 3] = 0;
                data[5, 4] = 0;
                data[5, 5] = 0;

                Glyph o2 = new Glyph("Marker_6_2", data);
                visualizationData = new GlyphVisualizationData(MarkerColor);
                o2.UserData = visualizationData;



                data = new byte[6, 6];
                data[0, 0] = 0;
                data[0, 1] = 0;
                data[0, 2] = 0;
                data[0, 3] = 0;
                data[0, 4] = 0;
                data[0, 5] = 0;

                data[1, 0] = 0;
                data[1, 1] = 0;
                data[1, 2] = 1;
                data[1, 3] = 1;
                data[1, 4] = 0;
                data[1, 5] = 0;

                data[2, 0] = 0;
                data[2, 1] = 0;
                data[2, 2] = 1;
                data[2, 3] = 0;
                data[2, 4] = 1;
                data[2, 5] = 0;

                data[3, 0] = 0;
                data[3, 1] = 1;
                data[3, 2] = 0;
                data[3, 3] = 0;
                data[3, 4] = 0;
                data[3, 5] = 0;

                data[4, 0] = 0;
                data[4, 1] = 0;
                data[4, 2] = 1;
                data[4, 3] = 1;
                data[4, 4] = 0;
                data[4, 5] = 0;

                data[5, 0] = 0;
                data[5, 1] = 0;
                data[5, 2] = 0;
                data[5, 3] = 0;
                data[5, 4] = 0;
                data[5, 5] = 0;

                Glyph o3 = new Glyph("Marker_6_3", data);
                visualizationData = new GlyphVisualizationData(MarkerColor);
                o3.UserData = visualizationData;

                data = new byte[6, 6];
                data[0, 0] = 0;
                data[0, 1] = 0;
                data[0, 2] = 0;
                data[0, 3] = 0;
                data[0, 4] = 0;
                data[0, 5] = 0;

                data[1, 0] = 0;
                data[1, 1] = 1;
                data[1, 2] = 0;
                data[1, 3] = 1;
                data[1, 4] = 0;
                data[1, 5] = 0;

                data[2, 0] = 0;
                data[2, 1] = 0;
                data[2, 2] = 1;
                data[2, 3] = 1;
                data[2, 4] = 0;
                data[2, 5] = 0;

                data[3, 0] = 0;
                data[3, 1] = 0;
                data[3, 2] = 1;
                data[3, 3] = 1;
                data[3, 4] = 0;
                data[3, 5] = 0;

                data[4, 0] = 0;
                data[4, 1] = 1;
                data[4, 2] = 0;
                data[4, 3] = 0;
                data[4, 4] = 1;
                data[4, 5] = 0;

                data[5, 0] = 0;
                data[5, 1] = 0;
                data[5, 2] = 0;
                data[5, 3] = 0;
                data[5, 4] = 0;
                data[5, 5] = 0;

                Glyph o4 = new Glyph("Marker_6_4", data);
                visualizationData = new GlyphVisualizationData(MarkerColor);
                o4.UserData = visualizationData;


                data = new byte[6, 6];
                data[0, 0] = 0;
                data[0, 1] = 0;
                data[0, 2] = 0;
                data[0, 3] = 0;
                data[0, 4] = 0;
                data[0, 5] = 0;

                data[1, 0] = 0;
                data[1, 1] = 1;
                data[1, 2] = 0;
                data[1, 3] = 0;
                data[1, 4] = 1;
                data[1, 5] = 0;

                data[2, 0] = 0;
                data[2, 1] = 1;
                data[2, 2] = 1;
                data[2, 3] = 0;
                data[2, 4] = 1;
                data[2, 5] = 0;

                data[3, 0] = 0;
                data[3, 1] = 1;
                data[3, 2] = 0;
                data[3, 3] = 1;
                data[3, 4] = 0;
                data[3, 5] = 0;

                data[4, 0] = 0;
                data[4, 1] = 0;
                data[4, 2] = 0;
                data[4, 3] = 0;
                data[4, 4] = 1;
                data[4, 5] = 0;

                data[5, 0] = 0;
                data[5, 1] = 0;
                data[5, 2] = 0;
                data[5, 3] = 0;
                data[5, 4] = 0;
                data[5, 5] = 0;

                Glyph o5 = new Glyph("Marker_6_5", data);
                visualizationData = new GlyphVisualizationData(MarkerColor);
                o5.UserData = visualizationData;

                data = new byte[6, 6];
                data[0, 0] = 0;
                data[0, 1] = 0;
                data[0, 2] = 0;
                data[0, 3] = 0;
                data[0, 4] = 0;
                data[0, 5] = 0;

                data[1, 0] = 0;
                data[1, 1] = 1;
                data[1, 2] = 0;
                data[1, 3] = 0;
                data[1, 4] = 1;
                data[1, 5] = 0;

                data[2, 0] = 0;
                data[2, 1] = 0;
                data[2, 2] = 0;
                data[2, 3] = 1;
                data[2, 4] = 1;
                data[2, 5] = 0;

                data[3, 0] = 0;
                data[3, 1] = 0;
                data[3, 2] = 1;
                data[3, 3] = 0;
                data[3, 4] = 1;
                data[3, 5] = 0;

                data[4, 0] = 0;
                data[4, 1] = 1;
                data[4, 2] = 0;
                data[4, 3] = 0;
                data[4, 4] = 0;
                data[4, 5] = 0;

                data[5, 0] = 0;
                data[5, 1] = 0;
                data[5, 2] = 0;
                data[5, 3] = 0;
                data[5, 4] = 0;
                data[5, 5] = 0;

                Glyph o6 = new Glyph("Marker_6_6", data);
                visualizationData = new GlyphVisualizationData(MarkerColor);
                o6.UserData = visualizationData;

                data = new byte[6, 6];
                data[0, 0] = 0;
                data[0, 1] = 0;
                data[0, 2] = 0;
                data[0, 3] = 0;
                data[0, 4] = 0;
                data[0, 5] = 0;

                data[1, 0] = 0;
                data[1, 1] = 0;
                data[1, 2] = 1;
                data[1, 3] = 0;
                data[1, 4] = 0;
                data[1, 5] = 0;

                data[2, 0] = 0;
                data[2, 1] = 1;
                data[2, 2] = 1;
                data[2, 3] = 1;
                data[2, 4] = 0;
                data[2, 5] = 0;

                data[3, 0] = 0;
                data[3, 1] = 0;
                data[3, 2] = 0;
                data[3, 3] = 1;
                data[3, 4] = 1;
                data[3, 5] = 0;

                data[4, 0] = 0;
                data[4, 1] = 1;
                data[4, 2] = 0;
                data[4, 3] = 0;
                data[4, 4] = 0;
                data[4, 5] = 0;

                data[5, 0] = 0;
                data[5, 1] = 0;
                data[5, 2] = 0;
                data[5, 3] = 0;
                data[5, 4] = 0;
                data[5, 5] = 0;

                Glyph o7 = new Glyph("Marker_6_7", data);
                visualizationData = new GlyphVisualizationData(MarkerColor);
                o7.UserData = visualizationData;


                data = new byte[6, 6];
                data[0, 0] = 0;
                data[0, 1] = 0;
                data[0, 2] = 0;
                data[0, 3] = 0;
                data[0, 4] = 0;
                data[0, 5] = 0;

                data[1, 0] = 0;
                data[1, 1] = 1;
                data[1, 2] = 1;
                data[1, 3] = 0;
                data[1, 4] = 0;
                data[1, 5] = 0;

                data[2, 0] = 0;
                data[2, 1] = 0;
                data[2, 2] = 1;
                data[2, 3] = 0;
                data[2, 4] = 0;
                data[2, 5] = 0;

                data[3, 0] = 0;
                data[3, 1] = 0;
                data[3, 2] = 1;
                data[3, 3] = 1;
                data[3, 4] = 1;
                data[3, 5] = 0;

                data[4, 0] = 0;
                data[4, 1] = 0;
                data[4, 2] = 1;
                data[4, 3] = 0;
                data[4, 4] = 0;
                data[4, 5] = 0;

                data[5, 0] = 0;
                data[5, 1] = 0;
                data[5, 2] = 0;
                data[5, 3] = 0;
                data[5, 4] = 0;
                data[5, 5] = 0;

                Glyph o8 = new Glyph("Marker_6_8", data);
                visualizationData = new GlyphVisualizationData(MarkerColor);
                o8.UserData = visualizationData;

                data = new byte[6, 6];
                data[0, 0] = 0;
                data[0, 1] = 0;
                data[0, 2] = 0;
                data[0, 3] = 0;
                data[0, 4] = 0;
                data[0, 5] = 0;

                data[1, 0] = 0;
                data[1, 1] = 1;
                data[1, 2] = 0;
                data[1, 3] = 0;
                data[1, 4] = 1;
                data[1, 5] = 0;

                data[2, 0] = 0;
                data[2, 1] = 0;
                data[2, 2] = 1;
                data[2, 3] = 1;
                data[2, 4] = 0;
                data[2, 5] = 0;

                data[3, 0] = 0;
                data[3, 1] = 1;
                data[3, 2] = 0;
                data[3, 3] = 1;
                data[3, 4] = 0;
                data[3, 5] = 0;

                data[4, 0] = 0;
                data[4, 1] = 0;
                data[4, 2] = 1;
                data[4, 3] = 0;
                data[4, 4] = 1;
                data[4, 5] = 0;

                data[5, 0] = 0;
                data[5, 1] = 0;
                data[5, 2] = 0;
                data[5, 3] = 0;
                data[5, 4] = 0;
                data[5, 5] = 0;

                Glyph o9 = new Glyph("Marker_6_9", data);
                visualizationData = new GlyphVisualizationData(MarkerColor);
                o9.UserData = visualizationData;

                data = new byte[6, 6];
                data[0, 0] = 0;
                data[0, 1] = 0;
                data[0, 2] = 0;
                data[0, 3] = 0;
                data[0, 4] = 0;
                data[0, 5] = 0;

                data[1, 0] = 0;
                data[1, 1] = 0;
                data[1, 2] = 1;
                data[1, 3] = 0;
                data[1, 4] = 1;
                data[1, 5] = 0;

                data[2, 0] = 0;
                data[2, 1] = 1;
                data[2, 2] = 1;
                data[2, 3] = 1;
                data[2, 4] = 1;
                data[2, 5] = 0;

                data[3, 0] = 0;
                data[3, 1] = 0;
                data[3, 2] = 1;
                data[3, 3] = 1;
                data[3, 4] = 0;
                data[3, 5] = 0;

                data[4, 0] = 0;
                data[4, 1] = 1;
                data[4, 2] = 0;
                data[4, 3] = 1;
                data[4, 4] = 1;
                data[4, 5] = 0;

                data[5, 0] = 0;
                data[5, 1] = 0;
                data[5, 2] = 0;
                data[5, 3] = 0;
                data[5, 4] = 0;
                data[5, 5] = 0;

                Glyph o10 = new Glyph("Marker_6_10", data);
                visualizationData = new GlyphVisualizationData(MarkerColor);
                o10.UserData = visualizationData;


                data = new byte[6, 6];
                data[0, 0] = 0;
                data[0, 1] = 0;
                data[0, 2] = 0;
                data[0, 3] = 0;
                data[0, 4] = 0;
                data[0, 5] = 0;

                data[1, 0] = 0;
                data[1, 1] = 1;
                data[1, 2] = 0;
                data[1, 3] = 0;
                data[1, 4] = 1;
                data[1, 5] = 0;

                data[2, 0] = 0;
                data[2, 1] = 1;
                data[2, 2] = 0;
                data[2, 3] = 0;
                data[2, 4] = 1;
                data[2, 5] = 0;

                data[3, 0] = 0;
                data[3, 1] = 1;
                data[3, 2] = 0;
                data[3, 3] = 0;
                data[3, 4] = 1;
                data[3, 5] = 0;

                data[4, 0] = 0;
                data[4, 1] = 1;
                data[4, 2] = 1;
                data[4, 3] = 1;
                data[4, 4] = 1;
                data[4, 5] = 0;

                data[5, 0] = 0;
                data[5, 1] = 0;
                data[5, 2] = 0;
                data[5, 3] = 0;
                data[5, 4] = 0;
                data[5, 5] = 0;

                Glyph o11 = new Glyph("Marker_6_11", data);
                visualizationData = new GlyphVisualizationData(MarkerColor);
                o11.UserData = visualizationData;
                #endregion objects 6*6 glyph


                gDB = new GlyphDatabase(6);
                gDB.Add(o1);
                gDB.Add(o2);
                gDB.Add(o3);
                gDB.Add(o4);
                gDB.Add(o5);
                gDB.Add(o6);
                gDB.Add(o7);
                gDB.Add(o8);
                gDB.Add(o9);
                gDB.Add(o10);
                gDB.Add(o11);
            }




            GlyphDatabase = gDB;

        }

        // Database of glyphs to recognize
        public GlyphDatabase GlyphDatabase
        {
            get { return recognizer.GlyphDatabase; }
            set
            {
                lock ( this )
                {
                    recognizer.GlyphDatabase = value;
                }
            }
        }

        // Glyphs' visualization type
        public VisualizationType VisualizationType
        {
            get { return visualizationType; }
            set
            {
                lock ( this )
                {
                    visualizationType = value;
                }
            }
        }
        public VisualizationType visualizationType = VisualizationType.Name;


    
        public void VisualizeGlyph(Bitmap bitmap,Dictionary<string, string> names)
        {
            
            lock ( this )
            {


                if (foundGlyphs.Count > 0)
                {
                 
                    if ( ( visualizationType == VisualizationType.BorderOnly ) ||
                         ( visualizationType == VisualizationType.Name ) )
                    {
                        Graphics g = Graphics.FromImage( bitmap );

                        // highlight each found glyph
                        foreach (ExtractedGlyphData glyphData in foundGlyphs)
                        {
                           
                            if ( ( glyphData.RecognizedGlyph == null ) || ( glyphData.RecognizedGlyph.UserData == null ) )
                            {
                                // highlight with default pen
                                g.DrawPolygon( defaultPen, ToPointsArray( glyphData.Quadrilateral ) );

                            }
                            else
                            {
                                GlyphVisualizationData visualization =
                                    (GlyphVisualizationData) glyphData.RecognizedGlyph.UserData;

                                Pen pen = new Pen( visualization.Color, 3 );

                                // highlight border
                                g.DrawPolygon( pen, ToPointsArray( glyphData.Quadrilateral ) );

                                // show glyph's name
                                if ( visualizationType == VisualizationType.Name )
                                {
                                    // get glyph's center point
                                   AForge.IntPoint minXY, maxXY;
                                    PointsCloud.GetBoundingRectangle( glyphData.Quadrilateral, out minXY, out maxXY );
                                    AForge.IntPoint center  = (minXY + maxXY) / 2;


                                     string GyphName="";
                                    if( names.ContainsKey(glyphData.RecognizedGlyph.Name)) GyphName=names[glyphData.RecognizedGlyph.Name];

                                    // glyph's name size
                                     SizeF nameSize = g.MeasureString(GyphName, defaultFont);

                                    // paint the name
                                    Brush brush = new SolidBrush( visualization.Color );

                                    g.DrawString(GyphName, defaultFont, brush,
                                        new Point( center.X - (int) nameSize.Width / 2, center.Y - (int) nameSize.Height / 2 ) );

                                    brush.Dispose( );
                                }

                                pen.Dispose( );
                            }
                        }
                    }
                    
                }
            }

        }
        public bool DetectGlyph(Bitmap bitmap)
        {
            bool found = false;
            foundGlyphs= recognizer.FindGlyphs(bitmap);
            if (foundGlyphs.Count > 0) found = true;
            return found;

        }

        /// <summary>
        /// output examples: "Marker_6_1|Marker_6_2" Or ""
        /// </summary>
        /// <returns></returns>
        public string GetDetectedGlyphsString()
        {
            string st="";
        if (foundGlyphs.Count == 0) st = "Nothing";
        else
        {
            foreach (ExtractedGlyphData glyphData in foundGlyphs)
            {

                st += glyphData.RecognizedGlyph.Name + "|";
            }
            st.Remove(st.Length-1 ,1);
        }
        return st;
        }


        /// <summary>
        /// example output: "Marker_6_11|dis|angle|Marker_6_1|dis|angle"
        /// </summary>
        /// <param name="gaze"></param>
        /// <returns></returns>
        public string GetDetectedGlyphsDistanceAngleString(AForge.Point gaze)
        {
            string st = "";
            if (foundGlyphs.Count == 0) st = "Nothing";
            else
            {
                foreach (ExtractedGlyphData glyphData in foundGlyphs)
                {

                  st += glyphData.RecognizedGlyph.Name + "|" + getGazeDistance(glyphData, gaze) + "|" + getGazeAngle(glyphData, gaze) + "|";
                }
                st.Remove(st.Length - 1, 1);
            }
            return st;
        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="glyphs"></param>
        /// <param name="gaze"></param>
        /// <param name="diameter"></param>in percent (e.g. 150% of marker size)
        /// <returns></returns>
        public string GetGazedGlyph( AForge.Point gaze, double diameter)
        {

            ExtractedGlyphData myGlyph = null; //foundGlyphs[0];

            double min = 100000;
            AForge.IntPoint minXY, maxXY;
            AForge.IntPoint center;

            foreach (ExtractedGlyphData glyphData in foundGlyphs)
            {
                // get glyph's center point

                PointsCloud.GetBoundingRectangle(glyphData.Quadrilateral, out minXY, out maxXY);
                center = (minXY + maxXY) / 2;
                double dis = GetDistance(new Point(center.X, center.Y), new Point((int)gaze.X, (int)gaze.Y));
                if (dis < min)
                {
                    myGlyph = glyphData;
                    min = dis;
                  
                }
            }

            if (myGlyph != null)
            {
                PointsCloud.GetBoundingRectangle(myGlyph.Quadrilateral, out minXY, out maxXY);
                double glyphDiameter = Math.Sqrt(2) * ((maxXY - minXY).X);


                double acceptedDis = (diameter * (glyphDiameter / 2));

                if (min > acceptedDis) myGlyph = null;
            }

            gazedMarkerHistory_Update(myGlyph, gaze);

            string name="";
            if (myGlyph!=null )name=myGlyph.RecognizedGlyph.Name;

            return  name;
        }


        /// <summary>
        /// distance is metured in Marker diameter unit. e.g. 1 diameter 2 diameter ....
        /// </summary>
        /// <param name="glyph"></param>
        /// <param name="gaze"></param>
        /// <returns></returns>
        public double  getGazeDistance(ExtractedGlyphData glyph, AForge.Point gaze)
        {
            double  dis = 0;
            AForge.IntPoint minXY, maxXY;
            PointsCloud.GetBoundingRectangle(glyph.Quadrilateral, out minXY, out maxXY);
            AForge.IntPoint center = (minXY + maxXY) / 2;
             dis = GetDistance(new Point(center.X, center.Y),new Point((int)gaze.X,(int)gaze.Y));


             PointsCloud.GetBoundingRectangle(glyph.Quadrilateral, out minXY, out maxXY);
             double glyphDiameter = Math.Sqrt(2) * ((maxXY - minXY).X);


              dis = dis / glyphDiameter;

            return dis;
        
        }
        /// <summary>
        ///  anglebetween gazepoint, glyph center and top point of the glyph
        /// </summary>
        /// <param name="glyph"></param>
        /// <param name="gaze"></param>
        /// <returns></returns>
        public int getGazeAngle(ExtractedGlyphData glyph, AForge.Point gaze)
        {
            int angle = 0;
            //gaze
            AForge.IntPoint g = new AForge.IntPoint(Convert.ToInt32( gaze.X),Convert.ToInt32( gaze.Y));

            //top point
            Point topCenter = new Point(0, 0);
            int i = 0, j = 1;
            topCenter.X = (glyph.Quadrilateral[i].X + glyph.Quadrilateral[j].X) / 2;
            topCenter.Y = (glyph.Quadrilateral[i].Y + glyph.Quadrilateral[j].Y) / 2;
            AForge.IntPoint top = new AForge.IntPoint(topCenter.X, topCenter.Y);

            //center
            AForge.IntPoint minXY, maxXY;
            PointsCloud.GetBoundingRectangle(glyph.Quadrilateral, out minXY, out maxXY);
            AForge.IntPoint center = (minXY + maxXY) / 2;
            AForge.IntPoint cnt = new AForge.IntPoint(center.X, center.Y);

            angle = (int)(AForge.Math.Geometry.GeometryTools.GetAngleBetweenVectors(cnt, g, top));

            int direc = 1;

            if ((cnt.X - top.X) != 0 && (g.Y - cnt.Y - ((cnt.Y - top.Y) / (cnt.X - top.X)) * (g.X - cnt.X)) < 0) direc = -1;

           // if (top.X < cnt.X) direc *= -1;

            angle *= direc;


            return angle;

        }
        public void gazedMarkerHistory_Update(ExtractedGlyphData glyph, AForge.Point  gaze)
        {
            gazedMarkerHistory_Shift();

            gazedMarkerHistory[0].name = "";
            gazedMarkerHistory[0].tag = "";

            if (glyph != null)
            {
                AForge.IntPoint minXY, maxXY;
                PointsCloud.GetBoundingRectangle(glyph.Quadrilateral, out minXY, out maxXY);
                 AForge.IntPoint center = (minXY + maxXY) / 2;
                gazedMarkerHistory[0].tag = "";
                gazedMarkerHistory[0].gaze = gaze;
                gazedMarkerHistory[0].markerCenter = new Point(center.X,center.Y );
                gazedMarkerHistory[0].name =glyph.RecognizedGlyph!=null? glyph.RecognizedGlyph.Name:"" ;
            }

            
        }

        public void gazedMarkerHistory_Shift()
        {

            for (int i = gazedMarkerHistory.Length - 1; i > 0; i--) { gazedMarkerHistory[i] = gazedMarkerHistory[i - 1]; }


        }

        public string GetGazedMarkerBeforeGesture(out int index, out bool found)
        {
            bool firstStop = true;
            string m = "";
            index = 0;
            found = false;

            for (int i = 0; i < gazedMarkerHistory.Length; i++)
            {
                if (firstStop)
                {
                    if (gazedMarkerHistory[i].tag != HeadGesture.GestureBasicCharacters.NoMovement.ToString()) firstStop = false;
                }
                else
                {
                    if (gazedMarkerHistory[i].tag == HeadGesture.GestureBasicCharacters.NoMovement.ToString())
                    {
                       m = gazedMarkerHistory[i].name;
                        index = i;
                        found = true;
                        break;
                    }
                }
            }

            return m;


        }

        #region Helper methods
        // Convert list of AForge.NET framework's points to array of .NET's points
        private Point[] ToPointsArray(List<AForge.IntPoint> points)
        {
            int count = points.Count;
            Point[] pointsArray = new Point[count];

            for ( int i = 0; i < count; i++ )
            {
                pointsArray[i] = new Point( points[i].X, points[i].Y );
            }

            return pointsArray;
        }
        /// <summary>
        /// Calculates distance between 2 points
        /// </summary>
        /// <param name="p1">First point</param>
        /// <param name="p2">Second point</param>
        /// <returns>Distance between two points</returns>
        private double GetDistance(Point p1, Point p2)
        {
            double dx = p1.X - p2.X;
            double dy = p1.Y - p2.Y;

            return Math.Sqrt(dx * dx + dy * dy);
        }
        #endregion
    }
    struct GlyphVisualizationData
    {
        // Color to use for highlight and glyph name
        public Color Color;
        // Image to show in the quadrilateral of recognized glyph
        public string ImageName;

        public GlyphVisualizationData(Color color)
        {
            Color = color;
            ImageName = null;
        }
    }
    // Enumeration of visualization types
   public enum VisualizationType
    {
        // Hightlight glyph with border only
        BorderOnly,
        // Hightlight glyph with border and put its name in the center
        Name,
        // Substitue glyph with its image
        Image
    }


      



}
