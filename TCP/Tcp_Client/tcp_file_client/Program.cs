using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace tcp_file_client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TcpClient client = new TcpClient();
                client.Connect(IPAddress.Parse("127.0.0.1"), 11000);
                client.SendBufferSize = 200000;
                Console.WriteLine("--введите путь к файлу --");
                string path = Console.ReadLine();

                if (!string.IsNullOrEmpty(path))
                    Console.WriteLine("вы не указали путь к файлу");
                else
                {
                    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        byte[] bytes = new byte[fs.Length];
                        fs.Read(bytes, 0, bytes.Length);

                        using (NetworkStream nfs = client.GetStream())
                        {
                            nfs.Write(bytes, 0, bytes.Length);
                        }
                    }
                    Console.WriteLine("файл успешно отправлен в {0:HH:mm}", DateTime.Now);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
