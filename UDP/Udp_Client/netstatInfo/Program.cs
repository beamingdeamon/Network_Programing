using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace netstatInfo
{
    class Program
    {
        static void Main(string[] args)
        {
                Ping ping = new Ping();
                PingOptions options = new PingOptions(64, true);
                string address = "192.168.110.213";

                ping.PingCompleted +=
                    new PingCompletedEventHandler(Ping_PingCompleted);
                byte[] bufer = Encoding.ASCII.GetBytes("ooooooooooo");

                ping.SendAsync(address, 100, bufer, options, null);

            
            Console.ReadLine();

            IPGlobalProperties properties =
                IPGlobalProperties.GetIPGlobalProperties();

            IPEndPoint[] endPoints = properties.GetActiveUdpListeners();

            foreach (IPEndPoint point in endPoints)
            {
                Console.Write("address: " + point.Address);
                Console.Write(" / {0}", point.Port);
                Console.WriteLine("\n\n");
            }
        }

        private static void Ping_PingCompleted(object sender, PingCompletedEventArgs e)
        {
            Console.WriteLine("address: "+e.Reply.Address);
            Console.WriteLine("status: " + e.Reply.Status);
        }
    }
}
