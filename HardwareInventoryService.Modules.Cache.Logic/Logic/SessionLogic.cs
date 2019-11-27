using HardwareInventoryService.Models;
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
    public partial class CacheLogicService : ICacheLogicService
    {
        private ISessionRepository _sessionRepo;

        public void AddSession(Session session)
        {
            this._sessionRepo.Add(session);
        }

        public void UpdateSession(Session session)
        {
            this._sessionRepo.Update(session);
        }

        public Session GetSessionByUsername(string username)
        {
            return this._sessionRepo.GetByUsername(username);
        }

        public Session[] GetSessionsByUsernamesArray(string[] username)
        {
            List<Session> sessions = new List<Session>();
            foreach (var id in username)
            {
                var op = this._sessionRepo.GetByUsername(id);
                sessions.Add(op);
            }
            return sessions.ToArray();
        }

        public IEnumerable<Session> GetSessions()
        {
            var data = this._sessionRepo.Objects.Select(x => x.Object).Cast<Session>();
            if (data != null && data.Count() != 0)
            {
                return data;
            }
            throw new NotFoundException();
        }

        public void RemoveSessionByUsername(string username)
        {
            this._sessionRepo.DeleteByUsername(username);
        }

        public IEnumerable<Session> GetLoggedSessions()
        {
            var data = this._sessionRepo.Objects.Select(z => z.Object).Where(x => !string.IsNullOrEmpty(x.Token) && x.TokenValidity > DateTime.UtcNow)
                .Cast<Session>();
            if (data != null && data.Count() != 0)
            {
                return data;
            }
            throw new NotFoundException();
        }
    }
}
