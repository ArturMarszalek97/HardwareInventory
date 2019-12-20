using HardwareInventoryService.DAO;
using HardwareInventoryService.Modules.Cache.Logic.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Modules.Cache.Logic.Services
{
    public class DataProviderService : IDataProviderService
    {
        public HardwareInventoryEntities context; 

        ISessionRepository _sessionRepository;

        IUserRepository _userRepository;

        IItemRepository _itemRepository;

        public DataProviderService(ISessionRepository sessionRepository, IUserRepository userRepository, IItemRepository itemRepository)
        {
            this.context = new HardwareInventoryEntities();
            this._sessionRepository = sessionRepository;
            this._userRepository = userRepository;
            this._itemRepository = itemRepository;
        }

        public void AddItem(Item item)
        {
            try
            {
                this.context.Item.Add(item);
                this.context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var x = 1;
            }
            catch (Exception e)
            {
                var x = 1;
                throw;
            }
            
        }

        public void AddUser(Users user)
        {
            this.context.Users.Add(user);
            this.context.SaveChanges();
        }

        public List<ItemCategory> GetItemCategories()
        {
            return this.context.ItemCategory.ToList();
        }

        public void GetItems()
        {
            List<Item> items = new List<Item>();

            items = this.context.Item.ToList();

            var mappedItems = Helpers.Automapper.TransformItemsFromDataBase(items);

            mappedItems.ForEach(x => this._itemRepository.AddItem(x));
        }

        public List<Item> GetItemsList()
        {
            return this.context.Item.ToList();
        }

        public async Task GetUsers()
        {
            List<Users> users = new List<Users>();

            await Task.Run(() =>
            {
                users = this.context.Users.ToList();
            });

            var mappedUsers = Helpers.Automapper.TransformsUsersFromDataBase(users);

            mappedUsers.ForEach(x => this._userRepository.AddUser(x));
        }

        public void RemoveItem(Item item)
        {
            this.context.Item.Remove(item);
            this.context.SaveChanges();
        }
    }

    public interface IDataProviderService
    {
        Task GetUsers();

        void AddUser(Users user);

        void AddItem(Item item);

        void RemoveItem(Item item);

        void GetItems();

        List<Item> GetItemsList();

        List<ItemCategory> GetItemCategories();
    }
}
