using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace StreamWriter
{
    public class TCPSocket
    {
       
        IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
        static IPAddress ipAddress = IPAddress.Any;
        IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 51972);


        public TCPSocket(byte[] byteBuffer)
        {


            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(localEndPoint);
            socket.Listen(100);

            socket.BeginAccept(new AsyncCallback(AcceptReceiveCallback), socket);

            socket.Send(byteBuffer, byteBuffer.Length, SocketFlags.None);


        }

        private void AcceptReceiveCallback(IAsyncResult ar)
        {

            // Get the socket that handles the client request.
            Socket listener = (Socket)ar.AsyncState;

            // End the operation and display the received data on the console.
            byte[] Buffer;
            int bytesTransferred;
            Socket handler = listener.EndAccept(out Buffer, out bytesTransferred, ar);
            string stringTransferred = Encoding.ASCII.GetString(Buffer, 0, bytesTransferred);

            Console.WriteLine(stringTransferred);
            Console.WriteLine("Size of data transferred is {0}", bytesTransferred);

            //// Create the state object for the asynchronous receive.
            //StateObject state = new StateObject();
            //state.workSocket = handler;
            //handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
            //new AsyncCallback(ReadCallback), state);


        }

    }
}