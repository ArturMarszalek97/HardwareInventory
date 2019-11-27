using HardwareInventoryService.Models.Models.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Modules.Cache.Logic.Interfaces
{
    public interface ISessionsLogic
    {
        void AddSession(Session session);

        void UpdateSession(Session session);

        Session GetSessionByUsername(string username);

        Session[] GetSessionsByUsernamesArray(string[] username);

        IEnumerable<Session> GetSessions();

        void RemoveSessionByUsername(string username);

        IEnumerable<Session> GetLoggedSessions();
    }
}
