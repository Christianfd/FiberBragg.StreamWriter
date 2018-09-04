using System;

namespace StreamWriter.tools
{
    public class charValidation
    {
        public static bool Validate(int key)
        {

            //var numPad = new Int16[];

            if (key == 3)
            {
                return false;
            }
            else if (key >= 74 && key <= 83)
            {
                return false;
            }
            else
            {
                return (key >= 44 || key <= 33);
            }
        }
    }



   
}