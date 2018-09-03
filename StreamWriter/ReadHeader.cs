//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace StreamWriter
//{
//    public class ReadHeader
//    {

//        public byte status { get; set; }
//        public byte option { get; set; }
//        public UInt16 messageLength { get; set; }
//        public UInt32 contentLength { get; set; }
//        public ushort? messageString { get; set; }
        

//        public ReadHeader()
//        {
//            status = 0;
//            option = 0;
//            messageLength = 0;
//            messageString = null;
//            contentLength = 56; //56 is the total byte needed before the double[] array. and should be updated.
//        }
//    }
//}
