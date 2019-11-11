using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Cache.Logic
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CacheService" in both code and config file together.
    public class CacheService : ICacheService
    {
        public int DoWork()
        {
            return 5;
        }
    }
}
