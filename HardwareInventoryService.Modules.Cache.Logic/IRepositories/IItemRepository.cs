using HardwareInventoryService.Models.Models;
using HardwareInventoryService.Modules.Cache.Logic.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Modules.Cache.Logic.IRepositories
{
    public interface IItemRepository
    {
        HashSet<CacheObject<Item>> Objects { get; set; }

        void AddItem(Item item);

        void RemoveItem(Item item);

        void UpdateItem(Item item);

        List<Item> GetItems();
    }
}
