using HardwareInventoryService.DAO;
using HardwareInventoryService.Modules.Cache.Logic.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Modules.Cache.Logic.Services
{
    public class DataProviderService : IDataProviderService
    {
        HardwareInventoryEntities context = new HardwareInventoryEntities();

        ISessionRepository _sessionRepository;

        IUserRepository _userRepository;

        IItemRepository _itemRepository;

        public DataProviderService(ISessionRepository sessionRepository, IUserRepository userRepository, IItemRepository itemRepository)
        {
            this._sessionRepository = sessionRepository;
            this._userRepository = userRepository;
            this._itemRepository = itemRepository;
        }

        public void AddItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void AddUser(Users user)
        {
            this.context.Users.Add(user);
            this.context.SaveChanges();
        }

        public async Task GetItems()
        {
            List<Item> items = new List<Item>();

            await Task.Run(() =>
            {
                items = this.context.Item.ToList();
            });

            var mappedItems = Helpers.Automapper.TransformItemsFromDataBase(items);

            mappedItems.ForEach(x => this._itemRepository.AddItem(x));
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
    }

    public interface IDataProviderService
    {
        Task GetUsers();

        void AddUser(Users user);

        void AddItem(Item item);

        Task GetItems();
    }
}
