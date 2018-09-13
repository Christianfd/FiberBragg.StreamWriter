using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Globalization;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using Microsoft.VisualBasic;
using StreamWriter.Interfaces;
using StreamWriter.tools;

namespace StreamWriter
{
    /// <summary>
    /// Interaction logic for ControlPage.xaml
    /// </summary>
    public partial class ControlPage : Page
    {

        public UserInput UInput { get; set; }
        private ISession Session { get; set; }
        private IPackHandler Packet { get; set; }
        private MessageHandler Message { get; set; }
        private IErrorSimulator ErrorSim { get; set; }
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private string userName { get; set;} 

        public ControlPage()
        {
            InitializeComponent();
            InitializeBackGroundWorker();
            InitializeSystem();
        }



        private void InitializeSystem()
        {
            UInput = new UserInput(this);
            this.DataContext = UInput;
            Message = new MessageHandler(UInput);
            Packet = Pack.createPack();
            Session = StreamWriter.Session.Create(51972, UInput.frequency);
            ErrorSim = ErrorSimulator.Create();

            userName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Environment.UserName);
            Message.Update("Hello " + userName +" The Simulator is ready to Use");
        }

        private void InitializeBackGroundWorker()
        {
            backgroundWorker1 = new BackgroundWorker();
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork +=
                new DoWorkEventHandler(backgroundWorker1_DoWork);
        
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            foreach (var item in UInput.numPeak)
            {
                Console.WriteLine(item);
            }

            UInput.UpdateFrequency(Session);
            Packet.UpdateArrays(UInput);
            ErrorSim.Updater(UInput);
            Session.Start(Packet, Message, ErrorSim);

            //Used for learning and testing background worker initially
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine(i);
            //    Thread.Sleep(1000);
            //    if (backgroundWorker1.CancellationPending)
            //    {
            //        break;
            //    }
            //}
        }


        private void StartButton_OnClick(object sender, RoutedEventArgs e)
        {
          


            if (backgroundWorker1.IsBusy != true)
            {
                Message.Add("Starting the Simulation");
                backgroundWorker1.RunWorkerAsync();
                stopButton.IsEnabled = true;
                startButton.IsEnabled = false;

            }
            else
            {
                Console.WriteLine("You already started the simulator");
            }
        }

        private void StopButton_OnClick(object sender, RoutedEventArgs e)
        {

            if (backgroundWorker1.IsBusy == true && backgroundWorker1.WorkerSupportsCancellation)
            {

                Session.Stop();
                backgroundWorker1.CancelAsync();
                stopButton.IsEnabled = false;
                startButton.IsEnabled = true;
                if (backgroundWorker1.IsBusy != true)
                {
                    Message.Add("Simulator Ready to Use");
                }
            }
            else
            {
                Console.WriteLine("Nothing to stop at the moment");
            }
        }


        //This needs some more implementation, might be useful with another method to call which returns false on other wanted keypresses like tap, enter and backspace
        private void CharValidation(object sender, KeyEventArgs e)
        {
             var key = (int) e.Key;
            // message.Update(key.ToString());

            if (key == 6 || key == 85)
            {
                StartButton_OnClick(startButton,e);
            }
            e.Handled = charValidation.Validate(key);
        }



        //Relevant for point 14.f.i.1/2
        //private void charValidation(object sender, TextChangedEventArgs textChangedEventArgs)
        //{

        //    if (string.IsNullOrEmpty(((TextBox) sender).Text))
        //        previousText = "";
        //    else
        //    {
        //        double num = 0;
        //        bool success = double.TryParse(((TextBox) sender).Text, out num);
        //        if (success & num >= 0)
        //        {
        //            ((TextBox) sender).Text.Trim();
        //            previousText = ((TextBox) sender).Text;
        //        }
        //        else
        //        {
        //            ((TextBox) sender).Text = previousText;
        //            ((TextBox) sender).SelectionStart = ((TextBox) sender).Text.Length;
        //        }

        //    }
        //}

        private void Internet_MessageBox(object sender, RoutedEventArgs e)
        {
            LocalIpv4.DisplayIPAddresses();
        }
    }
}
