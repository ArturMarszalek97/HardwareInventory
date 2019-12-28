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

        public void RemoveItem(Guid key)
        {
            var itemToRemove = this.context.Item.SingleOrDefault(x => x.KeyForCache == key);

            if (itemToRemove != null)
            {
                this.context.Item.Remove(itemToRemove);
                this.context.SaveChanges();
            }
        }

        public void UpdateItem(Models.Models.Item item)
        {
            var itemToUpdate = this.context.Item.SingleOrDefault(x => x.KeyForCache == item.KeyForCache);

            var updatedItem = Helpers.Automapper.TransformItemForUpdateToDatabaseType(item);
            updatedItem.ItemID = itemToUpdate.ItemID;

            var listOfItemCategories = this.GetItemCategories();
            updatedItem.ItemCategory = listOfItemCategories.Where(x => x.CategoryName == item.Category).Single();
            updatedItem.CategoryID = listOfItemCategories.Where(x => x.CategoryName == item.Category).Single().CategoryID;

            updatedItem.PDFDocument = new PDFDocument();
            updatedItem.Picture = new Picture();

            if (itemToUpdate != null)
            {
                if (itemToUpdate.PDFDocument.PDFDocumentArray != null && itemToUpdate.PDFDocument.PDFDocumentName != null
                    && item.PDFDocument.SequenceEqual(itemToUpdate.PDFDocument.PDFDocumentArray) 
                    && item.PDFDocumentName == itemToUpdate.PDFDocument.PDFDocumentName)
                {
                    updatedItem.PDFDocument.DocumentID = itemToUpdate.PDFDocument.DocumentID;
                    updatedItem.DocumentID = itemToUpdate.PDFDocument.DocumentID;
                    updatedItem.PDFDocument.PDFDocumentName = itemToUpdate.PDFDocument.PDFDocumentName;
                    updatedItem.PDFDocument.PDFDocumentArray = itemToUpdate.PDFDocument.PDFDocumentArray;
                }
                else
                {
                    var checkIfDocumentExistInDatabase = this.context.PDFDocument.ToList().Where(x => x.PDFDocumentName == item.PDFDocumentName && x.PDFDocumentArray == item.PDFDocument).FirstOrDefault();

                    if (checkIfDocumentExistInDatabase == null)
                    {
                        var newPDFDocument = new PDFDocument() { PDFDocumentArray = item.PDFDocument, PDFDocumentName = item.PDFDocumentName };
                        this.context.PDFDocument.Add(newPDFDocument);
                        this.context.SaveChanges();
                    }
                    
                    var documentFromDataBase = this.context.PDFDocument.ToList().Where(x => x.PDFDocumentName == item.PDFDocumentName && x.PDFDocumentArray == item.PDFDocument).FirstOrDefault();
                    updatedItem.PDFDocument.DocumentID = documentFromDataBase.DocumentID;
                    updatedItem.DocumentID = documentFromDataBase.DocumentID;
                    updatedItem.PDFDocument.PDFDocumentName = documentFromDataBase.PDFDocumentName;
                    updatedItem.PDFDocument.PDFDocumentArray = documentFromDataBase.PDFDocumentArray;
                }

                if (updatedItem.Picture.PictureArray != null && updatedItem.Picture.PictureName != null
                    && updatedItem.Picture.PictureArray == itemToUpdate.Picture.PictureArray
                    && updatedItem.Picture.PictureName == itemToUpdate.Picture.PictureName)
                {
                    updatedItem.Picture.PictureID = itemToUpdate.Picture.PictureID;
                    updatedItem.PictureID = itemToUpdate.Picture.PictureID;
                    updatedItem.Picture.PictureName = itemToUpdate.Picture.PictureName;
                    updatedItem.Picture.PictureArray = itemToUpdate.Picture.PictureArray;
                }
                else
                {
                    var checkIfPictureExistInDatabase = this.context.Picture.ToList().Where(x => x.PictureName == item.PictureName && x.PictureArray.SequenceEqual(item.Picture)).FirstOrDefault();

                    if (checkIfPictureExistInDatabase == null)
                    {
                        var newPicture = new Picture() { PictureArray = item.Picture, PictureName = item.PictureName };
                        this.context.Picture.Add(newPicture);
                        this.context.SaveChanges();
                    }
                    
                    var pictureFromDatabase = this.context.Picture.ToList().Where(x => x.PictureName == item.PictureName && x.PictureArray.SequenceEqual(item.Picture)).FirstOrDefault();
                    updatedItem.Picture.PictureID = pictureFromDatabase.PictureID;
                    updatedItem.PictureID = pictureFromDatabase.PictureID;
                    updatedItem.Picture.PictureName = pictureFromDatabase.PictureName;
                    updatedItem.Picture.PictureArray = pictureFromDatabase.PictureArray;
                }

                this.context.Entry(itemToUpdate).CurrentValues.SetValues(updatedItem);
                this.context.SaveChanges();
            }
        }
    }

    public interface IDataProviderService
    {
        Task GetUsers();

        void AddUser(Users user);

        void AddItem(Item item);

        void RemoveItem(Guid key);

        void UpdateItem(Models.Models.Item item);

        void GetItems();

        List<Item> GetItemsList();

        List<ItemCategory> GetItemCategories();
    }
}
