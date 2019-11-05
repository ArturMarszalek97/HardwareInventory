using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Authorization.Logic
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AuthService" in both code and config file together.
    public class AuthService : IAuthService
    {
        public int Authorize(int x, int y)
        {
            return x + y;
        }
    }
}
