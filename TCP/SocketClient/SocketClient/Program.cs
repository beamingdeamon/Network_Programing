using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
namespace SocketClient
{
    class Program
    {
        static void Main(string[] args)
        {
            SendMessageFromSocket(5001);
        }

        static void SendMessageFromSocket(int port)
        {

            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = IPAddress.Parse("192.168.110.213"); //ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, port);

            Socket sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            sender.Connect(ipEndPoint);
            Console.WriteLine("Введите сообщение: ");
            string msg = Console.ReadLine();

            byte[] sendMsg = Encoding.UTF8.GetBytes(msg);
            int bytesSent = sender.Send(sendMsg);
            byte[] bytes = new byte[1024];
            int byteRec = sender.Receive(bytes);
            Console.WriteLine("ответ сервера: " + Encoding.UTF8.GetString(bytes));
            if (msg.IndexOf("<eof>")== -1)
            {
                SendMessageFromSocket(port);
            }

            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }
    }
}
