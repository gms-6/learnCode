using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learncode.tools.EventLearn
{
    public class EventTest
    {
        private int value;

        public delegate void MyDelegate();
        public event MyDelegate MyEvent;
        protected virtual void OnChanged()
        {
            if (MyEvent != null)
                MyEvent();
            else
            {
                Console.WriteLine("无事件,回车继续");
                Console.ReadKey();
            }
        }
        public EventTest()
        {
            int n = 5;
            SetValue(n);
        }
        public void SetValue(int n)
        {
            if(value!=n)
            {
                value = n;
                OnChanged();
            }
        }
    }
    public class SubscribEvent
    {
        public void Show()
        {
            Console.WriteLine("触发事件");
            Console.ReadKey();
        }
    }

    public class Teacher//发布者教师类
    {
        private string tname;
        public delegate void delegateType();
        public event delegateType ClassEvent;//声明一个上课事件
        public Teacher(string name)//有参构造函数
        { this.tname = name; }
        public void Start()//定义引发事件的方法
        {
            Console.WriteLine(tname + " 教师宣布开始上课：");
            if (ClassEvent != null) ClassEvent();
        }
    }
    public class Student//订阅者学生类
    {
        private string sname;
        public Student(string name)
        { this.sname = name; }
        //事件处理方法`在这里插入代码片`
        public void Listener()
        { Console.WriteLine(" 学生" + sname + "正在认真听课"); }
        public void Record()
        { Console.WriteLine(" 学生" + sname + "正在做笔记"); }
        public void Reading()
        { Console.WriteLine(" 学生" + sname + "正在认真做笔记"); }
    }
}
