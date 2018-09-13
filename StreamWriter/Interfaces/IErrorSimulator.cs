using System;

namespace StreamWriter.Interfaces
{
    public interface IErrorSimulator
    {
       bool ErrorTimeCheck(TimeSpan time);
        void Updater(UserInput UI);
    }
}