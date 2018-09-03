using System.Net.NetworkInformation;
using System.Net.Sockets;

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
    }
}