using System;
using StreamWriter.tools;

namespace StreamWriter.Interfaces
{
    public interface IErrorSimulator
    {
       bool ErrorTimeCheck(TimeSpan time);
       void Updater(UserInput UI);

        void SimulateMissingPeak(IPackHandler packet, MessageHandler m);
    }
}