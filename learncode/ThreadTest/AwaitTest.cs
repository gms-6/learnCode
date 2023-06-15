using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace learncode.ThreadTest
{
    internal class AwaitTest
    {

        public void Method()
        {
            Console.WriteLine("调用前");
            Method1(1,2);
            Console.WriteLine("调用后");
        }
        private async Task Method1(int a,int b)
        {
            Console.WriteLine("方法执行开始");
            //int num=await Task.Factory.StartNew(() =>
            //{
            //    Thread.Sleep(3000);
            //    return a + b;
            //});
            await Task.Delay(2000);
            
            
            Console.WriteLine("方法执行结束");
        }
    }
}
