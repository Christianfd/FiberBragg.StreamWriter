using System;
using StreamWriter.Interfaces;

namespace StreamWriter.tools
{
    public class ErrorSimulator : IErrorSimulator
    {

        private bool errorState { get; set; }
        private int errorTime { get; set; }
        private int errorSensor { get; set; }



        public static IErrorSimulator Create()
        {
            return new ErrorSimulator();
        }

        public void Updater(UserInput UI)
        {
            errorState = UI.errorState;
            errorTime = UI.eTime;
            errorSensor = UI.eSensor;
        }

        /// <summary>
        /// Is it time for the error? Needs curent time
        /// </summary>
        /// <returns>Return true if enough time has passed, else is false</returns>
        public bool ErrorTimeCheck(TimeSpan time)
        {
            var errortimecheckString = errorTime < time.TotalSeconds && errorState;
            Console.WriteLine(time.TotalSeconds.ToString() + "    " + errortimecheckString );
           
            return errorTime < time.TotalSeconds && errorState;
        }
    }
}