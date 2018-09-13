using System;
using System.IO;
using System.Windows;
using System.Linq;
using StreamWriter.Interfaces;

namespace StreamWriter.tools
{
    public class ByteArray 
    {
        
        public static byte[] GenerateArray(IPackHandler packet)
        {
          

            using (var stream = new MemoryStream())
            {
                using (var writer = new BinaryWriter(stream))
                {



                    
                    writer.Write(packet.status);
                    writer.Write(packet.option);
                    writer.Write(packet.messageLength);
                    writer.Write(packet.contentLength);
                    if (packet.messageString != null) //null checker
                    {
                        writer.Write((ushort)packet.messageString);
                    }

                    writer.Write(packet.headerLength);
                    writer.Write(packet.headerVersion);
                    writer.Write(new byte[4]);
                    writer.Write(packet.serialNumber);
                    writer.Write(packet.timeStampSec);
                    writer.Write(packet.timeStampNanoSec);

                    foreach (var t in packet.numPeak)
                    {
                        writer.Write(t);
                    }

                    foreach (var t in packet.arrayOfPeaks)
                    {
                        writer.Write(t);
                    }



                    return stream.ToArray();
                }


               

            }
        }



    }
}