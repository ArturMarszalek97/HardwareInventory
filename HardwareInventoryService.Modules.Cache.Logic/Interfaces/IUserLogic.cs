using HardwareInventoryService.Models.Models.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Modules.Cache.Logic.Interfaces
{
    public interface IUserLogic
    {
        void AddUser(User user);

        void UpdateUser(User user);

        User GetUserByUsername(string username);

        User[] GetUsersByUsernamesArray(string[] username);

        IEnumerable<User> GetUsers();

        void RemoveUserByUsername(string username);
    }
}
