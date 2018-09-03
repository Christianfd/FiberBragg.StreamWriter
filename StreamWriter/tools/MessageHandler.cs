using System;
using System.Linq.Expressions;
using System.Windows.Controls;

namespace StreamWriter.tools
{
    public class  MessageHandler
    {

        private UserInput UInput{ get; set; }


        public MessageHandler(UserInput UI)
        {
            UInput = UI;
        }


        public void Update(string s)
        {
            UInput.outputMessage = " [" + TimeStamp() + "] " + s;

        }

        public void Add(string s)
        {
            UInput.outputMessage = " [" + TimeStamp() + "] " + s + "\n" + UInput.outputMessage;

        }

        public string TimeStamp()
        {
            return DateTime.UtcNow.ToLongTimeString();
        }
    }
}