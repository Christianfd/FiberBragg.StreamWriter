using System;
using System.Linq;
using StreamWriter.tools;

namespace StreamWriter
{
    public class Pack : IPackHandler
    {
        public byte status { get; set; }
        public byte option { get; set; }
        public UInt16 messageLength { get; set; }
        public UInt32 contentLength { get; set; }
        public ushort? messageString { get; set; }
        public UInt16 headerLength { get; set; }
        public UInt16 headerVersion { get; set; }
        public UInt32 reserved { get; set; }
        public UInt64 serialNumber { get; set; }
        public UInt32 timeStampSec { get; set; }
        public UInt32 timeStampNanoSec { get; set; }
        public UInt16[] numPeak { get; set; }
        public double[] arrayOfPeaks { get; set; }
        private double vMax { get; set; }
        private double vMin { get; set; }
        private int peakRange { get; set; }
        private double a { get; set; }

        private int total { get; set; }

        //This might need to become a double[] array so that each channel can be normalized and show correct data
        private double peakValue { get; set; }
        private int numberOfPeaks { get; set; }


        public static IPackHandler createPack()
        {
            return new Pack();
        }

        public Pack()
        {
            status = 0;
            option = 0;
            messageLength = 0;
            messageString = null;
            headerLength = 56; //This is a placeholder value
            contentLength = 56; //56 is the total byte needed before the double[] array. and should be updated.
            headerVersion = 100;
            reserved = 0;
            serialNumber = 0; //This is done so it can increment each loop.
            timeStampSec = 12345; //placeholder number
            timeStampNanoSec = (uint)12345.12345; //placeholdernumber
            numPeak = new UInt16[] { 5, 2, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            peakValue = 1400;
            peakRange = 200;
            foreach (var peak in numPeak)
            {
                numberOfPeaks += peak;
            }

            arrayOfPeaks = new double[numberOfPeaks];
        }

        public void UpdateArrays(UserInput UInput)
        {

            numPeak = UInput.numPeak;
            foreach (var peak in numPeak)
            {
                numberOfPeaks += peak;
            }

            arrayOfPeaks = new double[numberOfPeaks];
        }
        public void GeneratePeaks()
        {
            //Below code will generate a data set where each peak gets a realistic value, with a realistic range, and a realisitc median value based on the index of it.

            total = 0;
            Random r = new Random();

            foreach (var j in numPeak)
            {
                if (j != 0)
                {
                    a = 200 / (j * 2);
                }
                else
                {
                    a = 0;
                }

                var k = 0;
                for (int i = total; i < j + total ; i++)
                {
                    double rnd = r.NextDouble();
                    double currentIndexValue = (double)i / 10;
                    vMin = (peakValue + (2 * a * k)) * 0.99;
                    vMax = peakValue + (a + 3 * a * k);
                    arrayOfPeaks[i] = ((rnd * (vMax - vMin)) + vMin);
                    k++;
                }
                 total = total + j;
            }

            //for (int i = 0; i < numPeak.Length; i++)
            //{
            //    arrayOfPeaks[i] = peakValue;
            //}

            contentLength = (uint)(56 + (arrayOfPeaks.Length * 8));
        }

      
            public void UpdateTime()
            {
                //Do math and change the timeSpan variables
                TimeSpan timeElapsed = DateTime.Now.Subtract(new DateTime(1970,1,1,0,0,0));
                timeStampSec = Convert.ToUInt32(timeElapsed.TotalSeconds);
                timeStampNanoSec = Convert.ToUInt32((timeElapsed.TotalSeconds - (int)timeElapsed.TotalSeconds) * 1e09);
                serialNumber++;
            }
        /// <summary>
        /// This will return a ByteArray with the interface objects properties
        /// Data type is byte[]
        /// </summary>
        public byte[] ToByteArray()
        {
            return ByteArray.GenerateArray(this);
        }
    }
}