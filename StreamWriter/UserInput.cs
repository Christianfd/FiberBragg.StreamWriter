using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Interop;
using StreamWriter.Annotations;

namespace StreamWriter
{
    public class UserInput : INotifyPropertyChanged
    {
        private int _frequency;
        private string _outputMessage;

        private ushort[] _numPeak;


        public ushort[] numPeak
        {
            get { return _numPeak; }
            set
            {
                _numPeak = value;
             

            }
        }

        [IndexerName("tempNumPeak")]
        public ushort this[int index]
        {
            get { return _numPeak[index]; }

            set
            {
                _numPeak[index] = ValidateNumPeak(value); ;
                OnPropertyChanged("Item[]");
            }
        }


        public string outputMessage
        {
            get { return _outputMessage; }
            set
            {
                _outputMessage = value;
                OnPropertyChanged("outputMessage");
            }
        }

        public int frequency
        {
            get { return _frequency; }
            set
            {
                _frequency = ValidateFrequency(value);
 
                OnPropertyChanged("frequency");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;



        public bool error { get; set; }
        public int eTime { get; set; }
        public int eChannel { get; set; }
        public int eSensor { get; set; }
       // private IError Error { get; set; }

/// <summary>
/// Constructor
/// </summary>
        public UserInput()
        {
            frequency = 100;
            
           numPeak = new ushort[16];
    

        }



        private int ValidateFrequency(int value)
        {
            if (value >= 1000)
            {
                return 1000;
            }
            else if (value <= 0)
            {
                return (int)1;
            }
            else
            {
                return (int)value;
            }
        }

        private ushort ValidateNumPeak(ushort value)
        {

            if (value >= 255)
            {
           
                return value = 255;
            }


            return value;

        }


private void numPeak_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Observable Object changed");
        }



        public void UpdateFrequency(ISession session)
        {
            session.frequency = this.frequency;
        }

       

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            //Console.WriteLine("Property Changed event handler called by {0}", propertyName);
        }
    }

}
