using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace broadcast_client
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Socket client = new Socket(AddressFamily.InterNetwork,
                    SocketType.Dgram, ProtocolType.Udp);
                IPEndPoint endPoint1 = new IPEndPoint(IPAddress.Broadcast, 9050);
                IPEndPoint endPoint2 = new IPEndPoint(IPAddress.Parse("192.168.110.110"), 9050);
                Console.WriteLine("--введите сообщение:");
                string message = Console.ReadLine();

                byte[] data = Encoding.UTF8.GetBytes(message);
                client.SetSocketOption(SocketOptionLevel.Socket,
                    SocketOptionName.Broadcast, 1);

                client.SendTo(data, endPoint1);
                client.Close();
                if (message.IndexOf("<eof>") > -1)
                {
                    break;
                }
            }
        }
    }
}
