using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using StreamWriter.Interfaces;
using StreamWriter.tools;

namespace StreamWriter
{
    public class Session : ISession
    {
        private int port { get; set; }
        public int frequency { get; set; }
        private TcpListener ServerListener { get; set; }
        private TcpClient clientSocket { get; set; }
        private bool seekConnection { get; set; }
        private IPackHandler Packet { get; set; }
        private DateTime startTime { get; set; }
        private MessageHandler message{ get; set; }



        private Session(int p, int f=50)
        {
            port = p;
            frequency = f;
        }

  ~Session()
        {
            // throw new System.NotImplementedException();
            
        }

        /// <summary>
        /// This Creates an interface for Session allowing for more control of what's accessible
        /// </summary>
        /// <param name="port">51972 is the go to port</param>
        /// <returns></returns>
        public static ISession Create(int port = 51972, int frequency=50)
        {
            return new Session(port, frequency);
        }


        /// <summary>
        /// Sets up the the socket and passes the Packet information
        /// </summary>
        /// <param name="Packet"></param>
        public void Start(IPackHandler p, MessageHandler m)
        {
            Packet = p;
            message = m;

            Packet.GeneratePeaks();

            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = IPAddress.Any;
            //
            seekConnection = true;


            //Try with IPAddress.any instead of the variable "ipAddress"
            ServerListener = new TcpListener(IPAddress.Any, port);
            clientSocket = default(TcpClient);

            while (true)
            {
                this.TryToConnect(ipAddress);
                if (seekConnection != true)
                {
                    var s = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Environment.UserName);
                    message.Update("Connection terminated by " + s);
                    message.Add("Simulator should be ready to use");
                    break;
                }
            }
        }

        /// <summary>
        /// Starts searching for a client, when found it connects and start sending data immediatly
        /// </summary>
        /// <param name="Packet"></param>
        /// <param name="ServerListener"></param>
        /// <param name="clientSocket"></param>
        public void TryToConnect(IPAddress ipAddress)
        {
            try
            {
                ServerListener.Start();

                Console.WriteLine("Simulator awaiting connection..");
                Console.WriteLine(ipAddress);
                message.Add("Simulator awaiting Connection..");
               // message.Add("Using IP adress " + ServerListener.Server.LocalEndPoint.ToString());
               // message.Add("Sending with a Frquency of:" + this.frequency);
               // Console.WriteLine("Sending with a Frquency of: {0}", this.frequency);

                clientSocket = ServerListener.AcceptTcpClient();

                Console.WriteLine("Connection Made!");
                message.Add("Connection Made!");
                startTime = DateTime.Now;
                this.OnConnect();
            }
            catch (Exception e)
            {
                var c = "An established connection was aborted by the software in your host machine";
                var a = "A blocking operation was interrupted by a call to WSACancelBlockingCall";
                var b = "An existing connection was forcibly closed by the remote host";
            
               //Could be a CASE, however a good instance of improvised code as more problems come up
                if (e.Message == a)
                {
                  
                    Console.WriteLine("...");
                    Console.WriteLine("Connection terminated by User");
                    Console.WriteLine("...");

                } else if (e.Message == b)
                {
                    message.Add("Connection was lost from Remote Host");
                    Console.WriteLine("...");
                    Console.WriteLine("Connection was lost from Remote Host");
                    Console.WriteLine("...");

                } else if (e.Message == c)
                {
                    message.Add("Connection was lost from by Software on Host");
                    Console.WriteLine("...");
                    Console.WriteLine("Connection was lost from by Software on Host");
                    Console.WriteLine("...");
                }
                else
                {
                    message.Update("Unknown Exception:");
                    message.Add(e.ToString());
                    Console.WriteLine("Unknown Exception:");
                    Console.WriteLine(e.ToString());
                }
                {

                }

            }
        }

 


        /// <summary>
        /// When the connection is made this sends the data at a max rate of 1khz.
        /// </summary>
        /// <param name="Packet"></param>
        /// <param name="startTime"></param>
        /// <param name="clientSocket"></param>
        private void OnConnect()
        {
            Packet.UpdateTime();
            message.Add("Sending Data to Remote Host");
            Console.WriteLine("Sending Data to Remote Host");
            while (true)
            {
                //Sets the timeElapsed for calculating weather or not it should update the packet before sending. -- should work due to Thread.Sleep(1) but without it it would still update too often
                TimeSpan timeElapsed = DateTime.Now - startTime;
                var b = timeElapsed.Milliseconds;
                int a = 1000 / frequency;
                if (b/a == (int)b/a)
                {
                    Packet.GeneratePeaks();
                    
                }
                Packet.UpdateTime();
                var byteBuffer = Packet.ToByteArray();
                //Sends the packet as byte array
                Send(byteBuffer);
                if (seekConnection != true)
                {
                    //Console.WriteLine("Sending data was stopped by {0}", s);
                    break;
                }
                Thread.Sleep(1);
            }
        }


        public void Send(byte[] byteBuffer)
        {
            clientSocket.Client.Send(byteBuffer, byteBuffer.Length, SocketFlags.None);
        }


        public void Stop()
        {
            this.seekConnection = false;
            ServerListener.Stop();
            
            
        }


    }
}
