using HardwareInventoryService.Models.Models.Authorization;
using HardwareInventoryService.Modules.Cache.Logic.Interfaces;
using HardwareInventoryService.Modules.Cache.Logic.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Modules.Cache.Logic.Logic
{
    public partial class CacheLogicService : IUserLogic
    {
        private IUserRepository _userRepository;

        public void AddUser(User user)
        {
            this._userRepository.AddUser(user);
        }

        public User GetUserByUsername(string username)
        {
            return this._userRepository.GetUserByUsername(username);
        }

        public IEnumerable<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public User[] GetUsersByUsernamesArray(string[] username)
        {
            throw new NotImplementedException();
        }

        public void RemoveUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
