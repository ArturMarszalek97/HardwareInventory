using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Cache.Logic
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICacheService" in both code and config file together.
    [ServiceContract]
    public interface ICacheService
    {
        [OperationContract]
        int DoWork();
    }
}
