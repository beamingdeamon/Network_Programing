using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace newUdp_client
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                UdpClient client = new UdpClient();

                IPEndPoint endPoint =
                    new IPEndPoint(IPAddress.Parse("192.168.110.213"), 5001);

                try
                {
                    
                    Console.WriteLine("Enter nickname : ");
                    string nickname = Console.ReadLine();
                    string message = Console.ReadLine();
                    User user_data = new User(nickname, DateTime.Now, message);
                    user_data.

                    client.Send(bytes, bytes.Length, endPoint);
                }
                catch (SocketException ex)
                {
                    Console.WriteLine("Возникла ошибка :" + ex.Message);
                }
                finally
                {
                    client.Close();
                }
            }
        }
    }
}
