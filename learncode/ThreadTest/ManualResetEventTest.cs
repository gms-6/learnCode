using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace learncode.ThreadTest
{
    public class ManualResetEventTest
    {
        public ManualResetEvent[] manual;
        public ManualResetEventTest()
        {
            manual = new ManualResetEvent[3];
            for(int i=0; i < 3;i++)
                manual[i] = new ManualResetEvent(false);
            Task.Factory.StartNew(Method1);
            Task.Factory.StartNew(Method2);
            Task.Factory.StartNew(Method3);
        }
        public void SetMethod(int index)
        {
            manual[index-1].Set();
            manual[index-1].Reset();
        }
        private void Method1()
        {

            manual[0].WaitOne();
            Console.WriteLine("方法1线程变为非阻塞");
        }
        public void SetMethod2()
        {
            manual[0].Set();
            manual[0].Reset();
        }
        private void Method2()
        {

            manual[1].WaitOne();
            Console.WriteLine("方法2线程变为非阻塞");
        }
        public void SetMethod3()
        {
            manual[0].Set();
            manual[0].Reset();
        }
        private void Method3()
        {
            manual[2].WaitOne();
            Console.WriteLine("方法3线程变为非阻塞");
        }

    }
}
