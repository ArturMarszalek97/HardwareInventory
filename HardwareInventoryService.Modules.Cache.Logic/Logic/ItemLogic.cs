using HardwareInventoryService.Models.Models;
using HardwareInventoryService.Modules.Cache.Logic.Interfaces;
using HardwareInventoryService.Modules.Cache.Logic.IRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HardwareInventoryService.Modules.Cache.Logic.Logic
{
    public partial class CacheLogicService : IItemLogic
    {
        private IItemRepository _itemRepository;

        public void AddItem(Item item)
        {
            this._itemRepository.AddItem(item);

            var transformedItem = Helpers.Automapper.TransformItemToDatabaseType(item);
            //transformedItem.= 999999999;
            //transformedItem.PictureID = 999999999;
            this._dataProviderService.AddItem(transformedItem);
        }

        public void UpdateItem(Item item)
        {
            this._itemRepository.UpdateItem(item);
        }

        public List<Item> GetItems()
        {
            return this._itemRepository.GetItems();
        }

        public void RemoveItem(Item item)
        {
            this._itemRepository.RemoveItem(item);
        }
    }
}
