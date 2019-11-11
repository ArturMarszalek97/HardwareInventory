using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Autofac;
using Cache.Logic;
using Autofac.Integration.Wcf;
using Authorization.Logic;

namespace Authorization.Host
{
    class Program
    {
        static void Main()
        {
            using(IContainer container = Bootstrapper.RegisterContainerBuilder().Build())
            {
                ServiceHost host = new ServiceHost(typeof(Authorization.Logic.AuthService));
                ServiceHost cacheHost = new ServiceHost(typeof(Cache.Logic.CacheService));

                host.AddDependencyInjectionBehavior<IAuthService>(container);
                cacheHost.AddDependencyInjectionBehavior<ICacheService>(container);

                host.Open();
                cacheHost.Open();

                Console.WriteLine("Host started " + DateTime.Now.ToString());
                Console.ReadLine();

                host.Close();
                Environment.Exit(0);
            }
        }
    }
}
