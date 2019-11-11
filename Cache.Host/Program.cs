using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Cache.Host
{
    class Program
    {
        static void Main()
        {
            ServiceHost cacheHost = new ServiceHost(typeof(Cache.Logic.CacheService));

            cacheHost.Open();
            Console.WriteLine("Host started " + DateTime.Now.ToString());
            Console.ReadLine();
        }
    }
}
