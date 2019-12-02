using HardwareInventoryService.DAO;
using HardwareInventoryService.Modules.Cache.Logic.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Modules.Cache.Logic.Services
{
    public class DataProviderService
    {
        HardwareInventoryEntities context = new HardwareInventoryEntities();

        ISessionRepository sessionRepository;

        public async Task GetUsers()
        {
            //return await Task.Run(() =>
            //{
            //    var users = this.context.Users.ToList();
            //    //users.ForEach(x => this.sessionRepository.AddSaved(x));
            //});
        }
    }
}
