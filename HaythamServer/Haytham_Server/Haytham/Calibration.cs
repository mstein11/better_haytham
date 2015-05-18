using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using Emgu.CV;
namespace Haytham
{
    public class Calibration
    {
        public Boolean Calibrated;
        public enum calibration_type { calib_Polynomial, calib_Homography};
        public calibration_type CalibrationType;
        public int CalibrationTarget = 0;

        public List<AForge.Point> ScenePoints = new List<AForge.Point>();//Just used for drawing the points during calibration

        public Matrix<double> Destination = new Matrix<double>(2, 9);
        public Matrix<double> Source = new Matrix<double>(2, 9);
        public Matrix<double> PolynomialCoeffs;
        public Matrix<double> Homography = new Matrix<double>(3, 3);

        public float GazeErrorX = 0;
        public float GazeErrorY = 0;

        public void Calibrate()
        {
            switch (CalibrationType)
            {
                case Calibration.calibration_type.calib_Polynomial:
                    double X;
                    double Y;
                    Matrix<double> A = new Matrix<double>(9, 6);
                    double[] row = new double[6];
                    for (int i = 0; i < 9; i++)
                    {

                        X = Source[0, i];
                        Y = Source[1, i];

                        row[0] = 1;
                        row[1] = X;
                        row[2] = Y;
                        row[3] = X * Y;
                        row[4] = X * X;
                        row[5] = Y * Y;

                        for (int r = 0; r < 6; r++)
                        {
                            A[i, r] = row[r];
                        }
                    }

                    PolynomialCoeffs = new Matrix<double>(6, 2);
                    PolynomialCoeffs = SolveLeastSquares(A, Destination.Transpose());

                    //METState.Current.CalibrationTargetSound.Play();
                    // CvInvoke.cvSolve(AMatrix.Ptr, BMatrix.Ptr, coeffs.Ptr, 1);
                    //textBox1.Text += "\r\n Sx8= " + (B[8, 0]) + "   X8= " + row[1];
                    //textBox1.Text += "\r\n" + (B[8, 0] - (coeffs[0, 0] * row[0] + coeffs[1, 0] * row[1] + coeffs[2, 0] * row[2] + coeffs[3, 0] * row[3] + coeffs[4, 0] * row[4] + coeffs[5, 0] * row[5]));
                    //textBox1.Text += "\r\n" +( CvInvoke.cvDotProduct(roww.Ptr, coeffsY.Ptr) - SMatrix[8, 1]);
                    break;

                case Calibration.calibration_type.calib_Homography:


                    //    X = PupilMatrix[i, 0];
                    //    Y = PupilMatrix[i, 1];

                    Matrix<double> src = new Matrix<double>(2, 4);
                    Matrix<double> dst = new Matrix<double>(2, 4);

                    for (int i = 0; i < 4; i++)
                    {

                        //src[0, i] = (int)Convert.ChangeType(PupilMatrix[i, 0], typeof(int));
                        //dst[0, i] = (int)Convert.ChangeType(B[i, 0], typeof(int));
                        //src[1, i] = (int)Convert.ChangeType(PupilMatrix[i, 1], typeof(int));
                        //dst[1, i] = (int)Convert.ChangeType(B[i, 1], typeof(int));
                        src[0, i] = Source[0, i];
                        src[1, i] = Source[1, i];
                        dst[0, i] = Destination[0, i];
                        dst[1, i] = Destination[1, i];

                    }

                    IntPtr n = new IntPtr();
                    CvInvoke.cvFindHomography(src.Ptr, dst.Ptr, Homography.Ptr, Emgu.CV.CvEnum.HOMOGRAPHY_METHOD.DEFAULT,0,n);
                   // METState.Current.CalibrationTargetSound.Play();
                    break;
            }


            Calibrated = true;
        }

        static public Matrix<double> SolveLeastSquares(Matrix<double> A, Matrix<double> B)
        {
            int M = A.Rows;
            int N = A.Cols;

            Matrix<double> cof = new Matrix<double>(N, 2);

            Matrix<double> U = new Matrix<double>(M, M);
            Matrix<double> W = new Matrix<double>(M, N);
            Matrix<double> V = new Matrix<double>(N, N);

            Matrix<double> c = new Matrix<double>(M, 2);
            Matrix<double> y = new Matrix<double>(N, 2);

            CvInvoke.cvSVD(A.Ptr, W.Ptr, U.Ptr, V.Ptr, Emgu.CV.CvEnum.SVD_TYPE.CV_SVD_DEFAULT);


            c = U.Transpose().Mul(B);
            for (int i = 0; i < N; i++)
            {
                y[i, 0] = c[i, 0] / W[i, i];
                y[i, 1] = c[i, 1] / W[i, i];

            }

            cof = V.Mul(y);


            return cof;

        }

        public AForge.Point Map(float inputX, float inputY, float errorX, float errorY)
        {
            AForge.Point output = new AForge.Point();
            switch (CalibrationType)
            {
                case Calibration.calibration_type.calib_Polynomial:

                    Matrix<double> A = new Matrix<double>(1, 6);


                    double X = inputX;
                    double Y = inputY;

                    A[0, 0] = 1;
                    A[0, 1] = X;
                    A[0, 2] = Y;
                    A[0, 3] = X * Y;
                    A[0, 4] = X * X;
                    A[0, 5] = Y * Y;


                    output.X = (float)Convert.ChangeType(CvInvoke.cvDotProduct(A.Ptr, PolynomialCoeffs.GetCol(0).Transpose().Ptr), typeof(float));
                    output.Y = (float)Convert.ChangeType(CvInvoke.cvDotProduct(A.Ptr, PolynomialCoeffs.GetCol(1).Transpose().Ptr), typeof(float));
                    break;
                case Calibration.calibration_type.calib_Homography:


                    Matrix<double> src = new Matrix<double>(3, 1);
                    Matrix<double> dst = new Matrix<double>(3, 1);
                      

                        src[0, 0] = inputX;
                        src[1, 0] = inputY;
                        src[2, 0] = 1;
                        dst = Homography * src;

                        try
                        {
                            output.X = (float)Convert.ChangeType(dst[0, 0] / dst[2, 0], typeof(float));
                            output.Y = (float)Convert.ChangeType(dst[1, 0] / dst[2, 0], typeof(float));
                            // System.Diagnostics.Debug.WriteLine(gaze.X + "," + gaze.Y );
                        }
                        catch (Exception e) { }
                    break;

            }

            output.X -= errorX;
            output.Y -= errorY;

                     return output;
       }

  
    }
}
