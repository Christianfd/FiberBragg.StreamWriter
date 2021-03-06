using System;
using StreamWriter.tools;

namespace StreamWriter.Interfaces
{
    public interface IPackHandler

    {
        byte status { get; }
        byte option { get; }
        UInt16 messageLength { get; }
        UInt32 contentLength { get; set; }
        ushort? messageString { get; }
        UInt16 headerLength { get; }
        UInt16 headerVersion { get; }
        UInt32 reserved { get; }
        UInt64 serialNumber { get; }
        UInt32 timeStampSec { get; }
        UInt32 timeStampNanoSec { get; }
        UInt16[] numPeak { get; set; }
        double[] arrayOfPeaks { get; }

        void GeneratePeaks();
        void UpdateTime();
        void UpdateArrays(UserInput UInput);
        void RemovePeak(int peakNumber);
        void RemovePeak(int peakNumber, MessageHandler m);
        byte[] ToByteArray();

    }
}