using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;


namespace myGlass
{


    [DataContract]
    //[Serializable()]
    public  class myJsonClass
    {
        [DataMember(Name = "name", IsRequired = false)]
        public string name { get; set; }

        [DataMember(Name = "image", IsRequired = false)]
        public string image
        {
            set
            {

                byte[] array = Convert.FromBase64String(value);

                System.IO.MemoryStream dataOutputStream = new System.IO.MemoryStream();
                dataOutputStream.Write(array, 0, array.Length);
                img = Image.FromStream(dataOutputStream);


                //byte[] array = Encoding.ASCII.GetBytes(value);

                //ImageConverter ic = new ImageConverter();
                //img = (Image)ic.ConvertFrom(array);



            }
        }

        [DataMember(Name = "texts", IsRequired = false)]
        public List<String> texts { get; set; }

        [DataMember(Name = "text", IsRequired = false)]
        public String text { get; set; }

        public Image img;

        public myJsonClass()
        {
            img = null;
            texts = new List<string>();
            text = "";
        }
    }



    public class myJsonClass_test
    {

        public string name { get; set; }
        public String text { get; set; }


        public myJsonClass_test(myJsonClass mjson)
        {
            name = mjson.name;
            text = mjson.text;
        }

    }
}
