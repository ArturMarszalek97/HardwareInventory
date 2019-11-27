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
    public class SessionRepository : ISessionRepository
    {
        private readonly object _sessionsSetLock = new object();

        public HashSet<CacheObject<IAuthCacheModel>> _sessionsSet;

        public HashSet<CacheObject<IAuthCacheModel>> Objects
        {
            get
            {
                lock (this._sessionsSetLock)
                {
                    return this._sessionsSet;
                }
            }
            set
            {
                lock (this._sessionsSetLock)
                {
                    this._sessionsSet = value;
                }
            }
        }

        public SessionRepository()
        {
            this._sessionsSet = new HashSet<CacheObject<IAuthCacheModel>>();
        }

        public void Add(Session session)
        {
            lock (this._sessionsSetLock)
            {
                this._sessionsSet.RemoveWhere(x => x.Object.Username == session.Username);
                this._sessionsSet.AddExtension(session);
            }
        }

        public void AddSaved(Session session)
        {
            lock (this._sessionsSetLock)
            {
                this._sessionsSet.RemoveWhere(x => x.Object.Username == session.Username);
                this._sessionsSet.AddSavedExtension(session);
            }
        }

        public void DeleteByUsername(string username)
        {
            lock (this._sessionsSetLock)
            {
                var result = this._sessionsSet.RemoveWhere(x => x.Object.Username == username);
                if (result == 0)
                {
                    throw new NotFoundException();
                }
            }
        }

        public Session GetByUsername(string username)
        {
            lock (this._sessionsSetLock)
            {
                return this._sessionsSet.FirstOrDefault(x => x.Object.Username == username)?.Object as Session ?? throw new NotFoundException();
            }
        }

        public void Update(Session session)
        {
            lock (this._sessionsSetLock)
            {
                var ses = this._sessionsSet.FirstOrDefault(x => x.Object.Username == session.Username) ?? throw new NotFoundException();
                ses.Object = session;
            }
        }
    }
}
