using HardwareInventoryService.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Modules.Cache.Logic.Interfaces
{
    public interface IItemLogic
    {
        void AddItem(Item item);

        void RemoveItem(Item item);

        void UpdateItem(Item item);

        List<Item> GetItems();
    }
}
