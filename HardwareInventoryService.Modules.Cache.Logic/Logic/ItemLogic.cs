using HardwareInventoryService.Models.Models;
using HardwareInventoryService.Modules.Cache.Logic.Interfaces;
using HardwareInventoryService.Modules.Cache.Logic.IRepositories;
using System.Collections.Generic;
using System.Linq;
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
            var listOfItemCategories = this._dataProviderService.GetItemCategories();
            transformedItem.ItemCategory = listOfItemCategories.Where(x => x.CategoryName == item.Category).Single();

            this._dataProviderService.AddItem(transformedItem);
        }

        public void UpdateItem(Item item)
        {
            this._itemRepository.UpdateItem(item);
            this._dataProviderService.UpdateItem(item);
        }

        public List<Item> GetItems()
        {
            return this._itemRepository.GetItems();
        }

        public void RemoveItem(Item item)
        {
            this._itemRepository.RemoveItem(item);
            this._dataProviderService.RemoveItem(item.KeyForCache);
        }
    }
}
