using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace multicast_server
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 1024);
            server.Bind(endPoint);
            //224.5.5.5 потому что если выйдет за пределы с 224 - 239 не будет работать
            IPAddress ip = IPAddress.Parse("224.5.5.5");
            server.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(ip, IPAddress.Any));
            byte[] data = new byte[1024];
            server.Receive(data);

            string message = Encoding.UTF8.GetString(data);
            Console.WriteLine(message);
            server.Close();
        }
    }
}
