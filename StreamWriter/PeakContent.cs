//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace StreamWriter
//{
//    public class PeakContent
//    {
        
//        public UInt16 headerLength { get; set; }
//        public UInt16 headerVersion { get; set; }
//        public UInt64 serialNumber { get; set; }
//        public UInt32 timeStampSec { get; set; }
//        public UInt32 timeStampNanoSec { get; set; }
//        public ushort[] numPeak { get; set; }
//        public double[] arrayOfPeaks { get; set; }
//        public double peakValue { get; set; }

//        public PeakContent() //placeholder for testing
//        {

//            timeStampSec = 12345; //placeholder number
//            timeStampNanoSec = (uint) 12345.12345; //placeholdernumber
//            headerVersion = 100;
//            serialNumber = 1; //This is done so it can increment each loop.
//            numPeak = new UInt16[] { 180, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
//            headerLength = 1; //This is a placeholder value
//            peakValue = 1;

//        }

//        public void GeneratePeaks()
//        {
//           arrayOfPeaks = new double[180];
//            for (int i = 0; i < 180; i++)
//            {
//                arrayOfPeaks[i] = peakValue;
//            }
//        }

//        public void Update(DateTime startTime, ReadHeader ReadHeader)
//        {
//            //Do math and change the timeSpan variables
//            TimeSpan timeElapsed = DateTime.Now - startTime;
//            timeStampSec = Convert.ToUInt32(timeElapsed.TotalSeconds);
//            timeStampNanoSec = Convert.ToUInt32((timeElapsed.TotalSeconds - timeElapsed.Seconds) * 1e9 );
//            serialNumber++;

//            Random r = new Random();
            
//            //Attempt at randomising the peak values while maintaining structure (like a real world scenario)
//            for (int i = 0; i < arrayOfPeaks.Length; i++)
//            {
//                double rnd = r.NextDouble();
//                double currentIndexValue = (double)i / 10;
//                double minValue = peakValue + currentIndexValue;
//                double maxValue = peakValue + (i + 0.9) / 2;
               
//                arrayOfPeaks[i] = ((rnd * (maxValue)) + minValue);
//            }

//            //Mabye this should be moved and accessed through an interface
//            ReadHeader.contentLength = (uint) (56 + arrayOfPeaks.Length*8);

//        }

//    }
//}