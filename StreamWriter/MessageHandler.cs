using System.Linq.Expressions;
using System.Windows.Controls;

namespace StreamWriter
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
            UInput.outputMessage = s;

        }

        public void Add(string s)
        {
            UInput.outputMessage = UInput.outputMessage + "&#10;" + s;

        }
    }
}