using System;
using StreamWriter.Interfaces;

namespace StreamWriter.tools
{
    public class ErrorSimulator : IErrorSimulator
    {

        private bool errorState { get; set; }
        private int errorTime { get; set; }
        private int errorSensor { get; set; }
        private bool userInformedAboutErrorSimulation { get; set; }


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
            //var errortimecheckString = errorTime < time.TotalSeconds && errorState;
            //Console.WriteLine(time.TotalSeconds.ToString() + "    " + errortimecheckString );
           
            return errorTime < time.TotalSeconds && errorState;
        }

        /// <summary>
        /// Starts the process of simulating a peak disappearing 
        /// </summary>
        /// <param name="packet"></param>
        public void SimulateMissingPeak(IPackHandler packet)
        {
          
                packet.RemovePeak(errorSensor);
            
            
            
        }

        public void SimulateMissingPeak(IPackHandler packet, MessageHandler m)
        {

            if (packet.arrayOfPeaks.Length > 0 && errorSensor != 0)
            {

                var eSensor = errorSensor - 1;
                packet.RemovePeak(eSensor, m);
                if (userInformedAboutErrorSimulation) return;
                m.Add("Error Simulation has started and removed Sensor #" + errorSensor);
                userInformedAboutErrorSimulation = true;
            }
            else
            {
                if (userInformedAboutErrorSimulation) return;
                m.Add("Please Input a peak array size or Sensor to remove");
                m.Add("Error Mode can't simulate a removal of non-existant peaks");
                userInformedAboutErrorSimulation = true;
            }
        }
    }
}