using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;

namespace learncode.Ioc
{
    public class IoC
    {
        private static IContainer container;
        private static ContainerBuilder builder;


      

        public static void RegisterDependencies()
        {
            builder = new ContainerBuilder();

            builder.RegisterType<Service>().Named<IService>(nameof(Service));
            builder.RegisterType<Service1>().Named<IService>(nameof(Service1));

            container = builder.Build();
        }

        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }

    }






    public interface IService
    {
        void DoSomething();
    }
    public class Service : IService
    {
        public void DoSomething()
        {
            Console.WriteLine("DoSomething");
        }
    }
    public class Service1:IService
    {
        public void DoSomething()
        {
            Console.WriteLine("DoSomething1");
        }
    }
}
