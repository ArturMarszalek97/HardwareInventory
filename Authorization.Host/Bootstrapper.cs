using Authorization.Logic;
using Autofac;
using Cache.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorization.Host
{
    public static class Bootstrapper
    {
        public static ContainerBuilder RegisterContainerBuilder()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<CacheService>().As<ICacheService>();
            builder.RegisterType<AuthService>().As<IAuthService>();

            return builder;
        }
    }
}
