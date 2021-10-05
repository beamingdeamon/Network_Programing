using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace tcp_server
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = null;
            try
            {
                server = new TcpListener(IPAddress.Parse("127.0.0.1"), 5001);
                server.Start();
                Console.WriteLine("--ожидаем подключеня---");
                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    byte[] data = new byte[1024];
                    StringBuilder responce = new StringBuilder();

                    var stream = client.GetStream();
                    do
                    {
                        int bytes = stream.Read(data, 0, data.Length);
                        responce.Append(Encoding.UTF8.GetString(data, 0, data.Length));

                    } while (stream.DataAvailable);

                    Console.WriteLine();
                    stream.Close();
                    client.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
