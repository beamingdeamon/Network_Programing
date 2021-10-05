using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace upd_file_client
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient client = new UdpClient();
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("192.168.110.213"), 5002);

            Console.WriteLine("Введите путь к картинке: ");
            string pathImg = Console.ReadLine();

            FileStream fs = new FileStream(pathImg, FileMode.Open, FileAccess.Read);

            byte[] fileByte = new byte[fs.Length];
            fs.Read(fileByte, 0, fileByte.Length);

            client.Send(fileByte, fileByte.Length, endPoint);

            fs.Close();
            client.Close();
        }
    }
}
