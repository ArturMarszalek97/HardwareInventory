using HardwareInventoryService.Models;
using HardwareInventoryService.Models.Models.Authorization;
using HardwareInventoryService.Modules.Cache.Logic.IRepositories;
using HardwareInventoryService.Modules.Cache.Logic.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Modules.Cache.Logic.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly object _usersSetLock = new object();

        public HashSet<CacheObject<IUserCacheModel>> _usersSet;

        public HashSet<CacheObject<IUserCacheModel>> Objects
        {
            get
            {
                lock (this._usersSetLock)
                {
                    return this._usersSet;
                }
            }
            set
            {
                lock (this._usersSetLock)
                {
                    this._usersSet = value;
                }
            }
        }

        public UserRepository()
        {
            this._usersSet = new HashSet<CacheObject<IUserCacheModel>>();
        }

        public void AddUser(User user)
        {
            lock (this._usersSetLock)
            {
                this._usersSet.RemoveWhere(x => x.Object.Username == user.Username);
                this._usersSet.AddExtension(user);
            }
        }

        public User GetUserByUsername(string username)
        {
            lock (this._usersSetLock)
            {
                return this._usersSet.FirstOrDefault(x => x.Object.Username == username)?.Object as User ?? throw new NotFoundException();
            }
        }
    }
}
