using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace learncode.tools
{
    public class Http
    {
        //域名或ip
        HttpListener listener = new HttpListener();
        public bool HttpPostRequest_1(string url,string postDataStr)
        {
            byte[] postMsg = Encoding.UTF8.GetBytes(postDataStr);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength =postMsg.Length;
            Stream requestWriter = request.GetRequestStream();
            requestWriter.Write(postMsg,0,postMsg.Length);
            Console.WriteLine("客户端发送消息成功：" + postDataStr);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream reader = response.GetResponseStream();
            StreamReader sr = new StreamReader(reader,Encoding.UTF8);
            string res = sr.ReadToEnd();

            return true;
        }
        public bool HttpPostRequest(string url,string postDataStr,out string sResponse)
        {
            
            sResponse = string.Empty;
            try
            {
                byte[] postBytes = Encoding.UTF8.GetBytes(postDataStr);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = postBytes.Length;
                request.Host = "localhost";
                
                Stream myRequestStream = request.GetRequestStream();
                myRequestStream.Write(postBytes, 0, postBytes.Length);
                Console.WriteLine("客户端发送消息成功："+ postDataStr);
                myRequestStream.Close();
                HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = webResponse.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
                sResponse = myStreamReader.ReadToEnd();
                Console.WriteLine("客户端收到反馈信息"+sResponse);
                myStreamReader.Close();
                myResponseStream.Close();
                return true;
            }
            catch
            { 
                return false;
            }
        }

        public bool HttpServer(string localUrl,string romoteUrl="")
        {
            listener=new HttpListener();
            try
            {
                listener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
                listener.Prefixes.Add(localUrl);
                listener.Start();

            }
            catch (Exception ex)
            {
                return false;
            }
            Task.Run(()=>Listen());
            return true;
        }
        private void Listen()
        {
            ThreadPool.SetMinThreads(1,1);
            ThreadPool.SetMinThreads(500,500);
            while(true)
            {
                HttpListenerContext httpListener = listener.GetContext();
                string response = string.Empty;
                string requestUrl = httpListener.Request.RemoteEndPoint.Address.ToString();
                httpListener.Response.StatusCode = 200;
                Stream stream = httpListener.Request.InputStream;
                StreamReader reader = new StreamReader(stream);
                string body = reader.ReadToEnd();
                Console.WriteLine($"服务器收到Http请求信息："+body);
                string srcData = body;
                string responseMsg = "success";
                string[] uri = httpListener.Request.RawUrl.Split('/');
                httpListener.Response.ContentType = "application/json";
                using (StreamWriter writer=new StreamWriter(httpListener.Response.OutputStream))
                {
                    writer.Write(responseMsg);
                    Console.WriteLine("服务器返回信息："+ responseMsg);
                    writer.Close();
                    httpListener.Response.Close();
                }

            }
        }
    }
}
