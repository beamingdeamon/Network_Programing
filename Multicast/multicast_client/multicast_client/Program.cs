using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace multicast_client
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket client = new Socket(AddressFamily.InterNetwork,
                SocketType.Dgram, ProtocolType.Udp);
            client.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, 2);
            IPAddress addr = IPAddress.Parse("224.5.5.5");

            client.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(addr));
            IPEndPoint endPoint = new IPEndPoint(addr, 1024);
            client.Connect(endPoint);

            Console.WriteLine("--введите сообщение: ");
            string message = Console.ReadLine();

            byte[] data = Encoding.Default.GetBytes(message);
            client.Send(data);
            client.Close();
        }
    }
}
