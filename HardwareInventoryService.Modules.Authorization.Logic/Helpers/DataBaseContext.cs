using HardwareInventoryService.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Modules.Authorization.Logic.Helpers
{
    public static class DataBaseContext
    {
        public static HardwareInventoryEntities Context { get; set; }
    }
}
