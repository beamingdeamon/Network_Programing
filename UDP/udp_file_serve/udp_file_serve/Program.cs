using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace udp_file_serve
{
    class Program
    {
        public class FileInfo
        {
            public string filetype { get; set; }

            public long filesize { get; set; }
        }
        public static UdpClient server = new UdpClient(5002);
        public static IPEndPoint endPoint = null;
        public static byte[] reciveBytes = new byte[0];

        static void Main(string[] args)
        {
            Console.WriteLine("--ожидание файлов--");
            reciveBytes = server.Receive(ref endPoint);

            FileStream fs = new FileStream("file.jpg", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
            fs.Write(reciveBytes, 0, reciveBytes.Length);

            fs.Close();
            server.Close();
            Console.ReadLine();
        }
    }
}
