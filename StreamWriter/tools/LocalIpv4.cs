using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Windows;

namespace StreamWriter.tools
{
    public class LocalIpv4
    {
        public static string GetLocalIPv4(NetworkInterfaceType _type)
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }
                    }
                }
            }
            return output;
        }


        public static string GetEternet()
        {
            return GetLocalIPv4(NetworkInterfaceType.Ethernet);
        }

        /// <summary>
        /// This utility function displays all the IP (v4, not v6) addresses of the local computer.
        /// </summary>
        public static void DisplayIPAddresses()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Make sure [ 10.0.0.55 (Local Area Connect) ] is the only active connection");
            sb.AppendLine();
            sb.AppendLine("Active Connections(One Should be useable as target IP):");

           // Get a list of all network interfaces (usually one per network card, dialup, and VPN connection)
           NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface network in networkInterfaces)
            {
                // Read the IP configuration for each network
                IPInterfaceProperties properties = network.GetIPProperties();

                // Each network interface may have multiple IP addresses
                foreach (IPAddressInformation address in properties.UnicastAddresses)
                {
                    // We're only interested in IPv4 addresses for now
                    if (address.Address.AddressFamily != AddressFamily.InterNetwork)
                        continue;

                    // Ignore loopback addresses (e.g., 127.0.0.1)
                    if (IPAddress.IsLoopback(address.Address))
                        continue;
                   
                    sb.AppendLine(address.Address.ToString() + " (" + network.Name + ")");
                }
            }

            MessageBox.Show(sb.ToString());
        }
    }
}