using HardwareInventoryService.Models.Models;
using HardwareInventoryService.Models.Models.Authorization;
using HardwareInventoryService.Modules.Cache.Host.Interfaces;
using HardwareInventoryService.Modules.Cache.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Modules.Cache.Host.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class CacheWCFContract : ICacheWCFContract
    {
        private readonly ICacheLogicService _cacheLogicService;

        public CacheWCFContract()
        {

        }

        public CacheWCFContract(ICacheLogicService cacheLogicService)
        {
            this._cacheLogicService = cacheLogicService;
        }

        public void AddItem(Item item)
        {
            this._cacheLogicService.AddItem(item);
        }

        public List<Item> GetItems()
        {
            return this._cacheLogicService.GetItems();
        }

        public virtual void AddUser(User user)
        {
            this._cacheLogicService.AddUser(user);
        }

        public virtual void AddSession(Session session)
        {
            this._cacheLogicService.AddSession(session);
        }

        public User GetUserByUsername(string username)
        {
            return this._cacheLogicService.GetUserByUsername(username);
        }

        public virtual IEnumerable<Session> GetLoggedSessions()
        {
            return this._cacheLogicService.GetLoggedSessions();
        }

        public virtual Session GetSessionByUsername(string username)
        {
            return this._cacheLogicService.GetSessionByUsername(username);
        }

        public virtual IEnumerable<Session> GetSessions()
        {
            return this._cacheLogicService.GetSessions();
        }

        public virtual Session[] GetSessionsByUsernamesArray(string[] username)
        {
            return this._cacheLogicService.GetSessionsByUsernamesArray(username);
        }

        public virtual void RemoveSessionByUsername(string username)
        {
            this._cacheLogicService.RemoveSessionByUsername(username);
        }

        public virtual void UpdateSession(Session session)
        {
            this._cacheLogicService.UpdateSession(session);
        }

        public void RemoveItem(Item item)
        {
            this._cacheLogicService.RemoveItem(item);
        }

        public void UpdateItem(Item item)
        {
            this._cacheLogicService.UpdateItem(item);
        }
    }
}
