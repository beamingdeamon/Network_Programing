using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Tcp_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress adress = IPAddress.Parse("192.168.110.213");
            int port = 5001;
            try
            {
                TcpClient client = new TcpClient();
                client.Connect("192.168.110.213", port);

                NetworkStream stream = client.GetStream();
                string message = Console.ReadLine();
                byte[] data = 
                    Encoding.UTF8.GetBytes(message + "<eof>");
                stream.Write(data, 0, data.Length);
                stream.Close();
            }
            catch(SocketException sex)
            {
                Console.WriteLine(sex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
