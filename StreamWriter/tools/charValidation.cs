using System;

namespace StreamWriter.tools
{
    public static class charValidation
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


        //public static T[] RemoveAt<T>(this T[] source, int index)
        //{
        //    T[] dest = new T[source.Length - 1];
        //    if (index > 0)
        //        Array.Copy(source, 0, dest, 0, index);

        //    if (index < source.Length - 1)
        //        Array.Copy(source, index + 1, dest, index, source.Length - index - 1);

        //    return dest;
        //}

    }



   
}