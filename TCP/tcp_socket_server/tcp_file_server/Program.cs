using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace tcp_file_server
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = null;
            try
            {
                server = new TcpListener(IPAddress.Parse("127.0.0.1"), 11000);
                server.Start();
                Console.WriteLine("ожидаем приема файлов .....");

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    byte[] bytes = new byte[1024];
                    client.ReceiveBufferSize = int.MaxValue;
                    var stream = client.GetStream();

                    do
                    {
                        stream.Read(bytes,0,bytes.Length);
                    } while (stream.DataAvailable);

                    string fileName = string.Format("{0}.jpg", Guid.NewGuid().ToString());
                    using (FileStream fs = new FileStream(fileName, 
                        FileMode.Create,
                        FileAccess.ReadWrite,
                        FileShare.ReadWrite))
                    {
                        fs.Write(bytes, 0 ,bytes.Length);
                    }
                    Console.WriteLine("файл {0} принят и сохранен!", fileName);

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
