using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreamWriter
{
    public interface ISession
    {
        int frequency { get; set; }
        void Start(IPackHandler Packet, MessageHandler m);
        void Stop();
    }
}