using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace learncode.ThreadTest
{
    public class AutoResetEventTest
    {
        private AutoResetEvent resetEvent;
        public AutoResetEventTest()
        {
            resetEvent = new AutoResetEvent(false);
            Task.Factory.StartNew(Method1);
        }
        public void Method()
        {
            resetEvent.Set();
        }
        private void Method1()
        {
            while (true)
            {
                resetEvent.WaitOne();
                Console.WriteLine("线程已同步");
            }
        }
    }
}
