using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace learncode.ThreadTest
{
    public class SemaphoreTest
    {
        private Semaphore semap;
        public SemaphoreTest()
        {
            semap=new Semaphore(0, 100);
            Task.Factory.StartNew(Method);
        }
        public void ReleaseMehtod()
        {
            semap.Release();
        }
        public void Method()
        {
            semap.WaitOne();
            Console.WriteLine("线程变为非阻塞，执行方法");
        }

    }
}
