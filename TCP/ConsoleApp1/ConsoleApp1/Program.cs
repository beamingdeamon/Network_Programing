using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = ipHost.AddressList[0];
            IPEndPoint iPEndPoint = new IPEndPoint(ipAddress, 5001);

            Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("Ожидаем сообщение клиента");
            while (true)
            {
                Socket handler = listener.Accept();
                try
                {
                    listener.Bind(iPEndPoint);
                    listener.Listen(10);

                
                        string data = null;
                        byte[] bytes = new byte[1024];

                        int bytesRec = handler.Receive(bytes);

                        data += Encoding.UTF8.GetString(bytes, 0, bytesRec);

                        Console.WriteLine("recieve: " + data + "\n\n");
                        string reply = "Данные получены" + DateTime.Today;

                        byte[] replyMsg = Encoding.UTF8.GetBytes(reply);

                        handler.Send(replyMsg);

                        if (data.IndexOf("<eof>") > -1)
                        {
                            Console.WriteLine("Сервер завершил соединение с клиентом");
                            break;
                        }
                        handler.Shutdown(SocketShutdown.Both);
                
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    handler.Close();
                }
            }
        }

        //27.09.2021
        static public void Example_01()
        {
            WebClient client = new WebClient();
            Stream data = client.OpenRead("http://www.google.com");
            using (StreamReader reader = new StreamReader(data))
            {
                string str = reader.ReadToEnd();
                Console.WriteLine(str);
            }

            data.Close();
        }
        static public void Example_02(string url, string data)
        {
            byte[] postArr = Encoding.ASCII.GetBytes(data);

            WebClient client = new WebClient();
            Stream stream = client.OpenWrite(url);
            stream.Write(postArr, 0, postArr.Length);

            stream.Close();
        }
        static public void Example_03(string url, string data)
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string result = client.UploadString(url, data);

            Console.WriteLine(result);
        }
        static public void Example_04()
        {
            WebRequest request = WebRequest.Create("http://www.google.com");

            request.Timeout = 10000;
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Console.WriteLine(response.StatusDescription);

            StreamReader reader = new StreamReader(response.GetResponseStream());
            Console.WriteLine(reader.ReadToEnd());
        }
        static public void Example_05()
        {
            WebRequest request = WebRequest.Create("https://randomuser.me/api/?nat=us&randomapi");
            request.Method = "GET";
            request.Timeout = 10000;
            request.Credentials = CredentialCache.DefaultCredentials;


            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Console.WriteLine(response.StatusDescription);

            StreamReader reader = new StreamReader(response.GetResponseStream());
            Console.WriteLine(reader.ReadToEnd());
        }
        //28.09.2021


    }
}
