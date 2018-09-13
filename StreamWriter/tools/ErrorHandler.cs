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
    }
}