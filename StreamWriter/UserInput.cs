using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Interop;
using StreamWriter.Annotations;
using StreamWriter.Interfaces;

namespace StreamWriter
{
    public class UserInput : INotifyPropertyChanged
    {
        private int _frequency;
        private string _outputMessage;
        private ushort[] _numPeak;
        private bool _errorState;
        private int _eSensor;
        private bool _isUiEnabled;

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
                eSensorMaxValue();

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




        public bool errorState
        {
            get { return _errorState; }
            set
            {
                _errorState = value;
                OnPropertyChanged("errorState");
                _controlPage.errorModeExpander.IsExpanded = value;
            }
        }

        public int eSensor
        {
            get { return _eSensor; }
            set
            {
                _eSensor = ValidateeSensor(value);
                OnPropertyChanged("eSensor");

            }
        }
   

        public int eTime { get; set; }
       

        private ControlPage _controlPage { get; set; }

        public bool isUIEnabled
        {
            get { return _isUiEnabled; }
            set
            {
                _isUiEnabled = value;
                OnPropertyChanged("isUIEnabled");

            }
        }

        public int eChannel { get; set; }
        //private IError Error { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        /// Constructor
        /// </summary>
        public UserInput(ControlPage _cPage)
        {
           frequency = 100;
           numPeak = new ushort[16];
            _controlPage = _cPage;
            isUIEnabled = true;

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
        /// <summary>
        /// Validates the Sensor data and makes sure it doesn't exceed the user inputted number
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private int ValidateeSensor(int value)
        {
            var numPeakSum = 0;
            foreach (var item in numPeak)
            {
                numPeakSum = numPeakSum + item;
            }

            if (value >= numPeakSum)
            {
                return numPeakSum;
            }
            else
            {
                return value;
            }
        }

        private void eSensorMaxValue()
        {
            var numPeakSum = 0;
            foreach (var item in numPeak)
            {
                numPeakSum = numPeakSum + item;
            }

            if (_eSensor >= numPeakSum)
            {
                eSensor = numPeakSum;
            }
            else
            {
            }
        }

        public ushort[] getNumPeak()
        {
            return _numPeak;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            //Console.WriteLine("Property Changed event handler called by {0}", propertyName);
        }

    }

}
