using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace broadcast_server
{
    class Program
    {
        static void Main(string[] args)
        {

            Socket server = new Socket(AddressFamily.InterNetwork,
            SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 9050);
            server.Bind(endPoint);
            while (true)
            {

                Console.WriteLine("--ожидание сообщения--");

                byte[] data = new byte[1024];
                EndPoint ep = (EndPoint)endPoint;
                int recv = server.ReceiveFrom(data, ref ep);

                string message = Encoding.UTF8.GetString(data);
                Console.WriteLine("полученно сообщение {0} от {1}", message, ep.ToString());

                if (message.IndexOf("break")>-1)
                {
                    break;
                    server.Close();
                }
            }
        }
    }
}
