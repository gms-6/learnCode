using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace learncode.tools
{
    public class TcpServer
    {
        public TcpClient client;
        IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("172.17.51.94"), 8080);
        public TcpServer()
        {
            client = new TcpClient(ipe);
        }
        public void Connect(string server, string message)
        {
            try
            {
                if(!client.Connected)
                    client.Connect(ipe);
                byte[] data = Encoding.UTF8.GetBytes(message);
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);
                Console.WriteLine($"客户端发送信息：{message}");
                data = new byte[256];
                string responseData = string.Empty;
                int bytes = stream.Read(data, 0, data.Length);
                responseData = Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine($"客户端接收反馈：{responseData}");
                stream.Close();
                client.Close();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"ArgumentNullException:{ex.Message}");
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"SocketException:{ex.Message}");
            }
            Console.WriteLine("连接关闭");
        }
        public void Listen()
        {
            TcpListener server = null;
            Task.Run(() =>
            {
                try
                {
                    int port = 8080;
                    IPAddress localAddr = IPAddress.Parse("172.17.51.94");
                    IPEndPoint ipEndPoint = new IPEndPoint(localAddr, port);
                    server = new TcpListener(ipEndPoint);
                    server.Start();
                    byte[] bytes = new byte[256];
                    string data = null;
                    while (true)
                    {
                        Console.WriteLine("等待外部连接");
                        TcpClient client = server.AcceptTcpClient();
                        Console.WriteLine("连接成功");
                        NetworkStream stream = client.GetStream();
                        int i = stream.Read(bytes, 0, bytes.Length);
                        data = Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine($"服务器接收到的信息：{data}");
                        data = data.ToUpper();
                        byte[] msg = Encoding.ASCII.GetBytes(data);
                        stream.Write(msg, 0, msg.Length);
                        Console.WriteLine($"服务器返回信息：{data}");

                    }
                }
                catch (SocketException e)
                {
                    Console.WriteLine("异常" + e.Message);
                }
                finally
                {
                    server.Stop();
                }
                Console.WriteLine("监听结束");
            });
        }


    }
}
