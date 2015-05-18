using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace Haytham
{
    public class TextFile
    {
        StreamWriter SW;

        /// <summary>
        /// some temporary variables for using when calling writeLine (e.g., gestures...)
        /// </summary>
        private string _temp1 = "";//
        private string _temp2 = "";//
        private string _temp3 = "";//
        private string _temp4 = "";

        /// <summary>
        /// for blink
        /// </summary>
        public string temp1
        {
            get
            {
                string t = _temp1;
                _temp1 = "";
                return t;
              
            }
            set
            {
                _temp1 = value;
            }
        }
        /// <summary>
        /// for DbBlink
        /// </summary>
        public string temp2
        {
            get
            {
                string t = _temp2;
                _temp2 = "";
                return t;

            }
            set
            {
                _temp2 = value;
            }
        }
        /// <summary>
        /// for head gestures
        /// </summary>
        public string temp3
        {
            get
            {
                string t = _temp3;
                _temp3 = "";
                return t;

            }
            set
            {
                _temp3 = value;
            }
        }
        public string temp4
        {
            get
            {
                string t = _temp4;
                _temp4 = "";
                return t;

            }
            set
            {
                _temp4 = value;
            }
        }

        public  string filenamewithoutextension; 

        public  TextFile(string filename)
        {
            CreateFile(filename);
        }

        private void CreateFile(string filename)
        {
            filenamewithoutextension = filename;

            SW = File.CreateText(filename +  ".txt");


        }
        public void CloseFile()
        {
            SW.Close();

        }

        public void WriteLine(string text)
        {
            SW.WriteLine(text);

        }
        public void Write(string text)
        {
            SW.Write(text);

        }
    }
}