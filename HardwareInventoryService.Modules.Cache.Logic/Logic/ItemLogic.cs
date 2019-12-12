using HardwareInventoryService.Models.Models;
using HardwareInventoryService.Modules.Cache.Logic.Interfaces;
using HardwareInventoryService.Modules.Cache.Logic.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Modules.Cache.Logic.Logic
{
    public partial class CacheLogicService : IItemLogic
    {
        private IItemRepository _itemRepository;

        public void AddItem(Item item)
        {
            this._itemRepository.AddItem(item);
        }

        public List<Item> GetItems()
        {
            return this._itemRepository.GetItems();
        }
    }
}
