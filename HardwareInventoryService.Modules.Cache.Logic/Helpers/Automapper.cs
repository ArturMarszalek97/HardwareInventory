using AutoMapper;
using HardwareInventoryService.DAO;
using HardwareInventoryService.Models.Models.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareInventoryService.Modules.Cache.Logic.Helpers
{
    public static class Automapper
    {
        public static List<User> TransformsUsersFromDataBase(List<Users> list)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Users, User>()
                    .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                    .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                    .ForMember(dest => dest.AccountPhoto, opt => opt.MapFrom(src => src.Photo));
            });

            var mapper = config.CreateMapper();

            return mapper.Map<List<User>>(list);
        }

        public static List<HardwareInventoryService.Models.Models.Item> TransformItemsFromDataBase(List<Item> list)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Item, HardwareInventoryService.Models.Models.Item>()
                    .ForMember(dest => dest.ItemID, opt => opt.MapFrom(src => src.ItemID))
                    .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserID))
                    .ForMember(dest => dest.ItemName, opt => opt.MapFrom(src => src.ItemName))
                    .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                    .ForMember(dest => dest.DateOfPurchase, opt => opt.MapFrom(src => src.DateOfPurchase))
                    .ForMember(dest => dest.Shop, opt => opt.MapFrom(src => src.Shop))
                    .ForMember(dest => dest.Warranty, opt => opt.MapFrom(src => src.Warranty))
                    .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.ItemCategory.CategoryName))
                    .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.Note))
                    .ForMember(dest => dest.Return, opt => opt.MapFrom(src => src.DaysToReturn))
                    .ForMember(dest => dest.PDFDocumentName, opt => opt.MapFrom(src => src.PDFDocument.PDFDocumentName))
                    .ForMember(dest => dest.PDFDocument, opt => opt.MapFrom(src => src.PDFDocument.PDFDocumentArray))
                    .ForMember(dest => dest.PictureName, opt => opt.MapFrom(src => src.Picture.PictureName))
                    .ForMember(dest => dest.Picture, opt => opt.MapFrom(src => src.Picture.PictureArray));
            });

            var mapper = config.CreateMapper();

            return mapper.Map<List<HardwareInventoryService.Models.Models.Item>>(list);
        }

        public static Item TransformItemToDatabaseType(Models.Models.Item item)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Models.Models.Item, Item>()
                    .ForMember(dest => dest.ItemID, opt => opt.MapFrom(src => src.ItemID))
                    .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserID))
                    .ForMember(dest => dest.ItemName, opt => opt.MapFrom(src => src.ItemName))
                    .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                    .ForMember(dest => dest.DateOfPurchase, opt => opt.MapFrom(src => src.DateOfPurchase))
                    .ForMember(dest => dest.Shop, opt => opt.MapFrom(src => src.Shop))
                    .ForMember(dest => dest.Warranty, opt => opt.MapFrom(src => src.Warranty))
                    .ForMember(dest => dest.ItemCategory, opt => opt.MapFrom(src => new ItemCategory { CategoryName = src.Category }))
                    .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.Note))
                    .ForMember(dest => dest.DaysToReturn, opt => opt.MapFrom(src => src.Return))
                    .ForMember(dest => dest.PDFDocument, opt => opt.MapFrom(src => new PDFDocument { PDFDocumentName = src.PDFDocumentName, PDFDocumentArray = src.PDFDocument }))
                    .ForMember(dest => dest.Picture, opt => opt.MapFrom(src => new Picture { PictureName = src.PictureName, PictureArray = src.Picture }));
            });

            var mapper = config.CreateMapper();

            return mapper.Map<Item>(item);
        }
    }
}
