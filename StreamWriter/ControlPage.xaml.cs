﻿using System;
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
using System.Threading;
using Microsoft.VisualBasic;

namespace StreamWriter
{
    /// <summary>
    /// Interaction logic for ControlPage.xaml
    /// </summary>
    public partial class ControlPage : Page
    {

        public UserInput UInput { get; set; }
        private ISession session { get; set; }
        private IPackHandler Packet { get; set; }
        private MessageHandler message { get; set; }
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private string previousText { get; set; } 
        public ControlPage()
        {

            InitializeComponent();
            InitializeBackGroundWorker();
            InitializeSystem();
        }

        private void InitializeSystem()
        {
            UInput = new UserInput();
            Packet = Pack.createPack();
            session = Session.Create(51972, UInput.frequency);
            this.DataContext = UInput;
            message = new MessageHandler(UInput);
            message.Update("Simulator Ready to Use");
          

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

            UInput.UpdateFrequency(session);
            Packet.UpdateArrays(UInput);
            session.Start(Packet, message);

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
            UInput.outputMessage = "Starting the Simulation";


            if (backgroundWorker1.IsBusy != true)
            {
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

                session.Stop();
                backgroundWorker1.CancelAsync();
                stopButton.IsEnabled = false;
                startButton.IsEnabled = true;
            }
            else
            {
                Console.WriteLine("Nothing to stop at the moment");
            }
        }


        //This needs some more implementation, might be useful with another method to call which returns false on other wanted keypresses like tap, enter and backspace
        private void CharValidation(object sender, KeyEventArgs e)
        {

            if ((int)e.Key == 3)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = (int)e.Key >= 44 || (int)e.Key <= 34;
            }

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

    }
}