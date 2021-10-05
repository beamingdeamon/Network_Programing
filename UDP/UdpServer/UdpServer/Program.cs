using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient server = new UdpClient(5001);

            IPEndPoint remoteEp = null;
            try
            {
                Console.WriteLine("-- группа переписки --");
                while (true)
                {
                    byte[] recieveBytes = 
                        server.Receive(ref remoteEp);
                    string recieveMsg = 
                        Encoding.UTF8.GetString(recieveBytes);

                    string str = string.Format("--> ({0}): ({1})", remoteEp.Address, recieveMsg);
                }
            }
            catch(SocketException ex)
            {
                Console.WriteLine("Возникла ошибка: " + ex.Message);
            }
        }
    }
}

