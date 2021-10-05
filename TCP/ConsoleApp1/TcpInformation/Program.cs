using System;
using System.Net.NetworkInformation;
using System.Text;

namespace TcpInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            IPGlobalProperties globalProp = 
                IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] connections =
                globalProp.GetActiveTcpConnections();

            foreach (TcpConnectionInformation item in connections)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Local endpoint: \t" 
                    + item.LocalEndPoint.Address.ToString());
                sb.Append("\nRemotePort: "
                    + item.RemoteEndPoint.Port.ToString());
                sb.Append("\nState:\t\t" 
                    + item.State.ToString());
                Console.WriteLine(sb.ToString());
            }
        }
    }
}
