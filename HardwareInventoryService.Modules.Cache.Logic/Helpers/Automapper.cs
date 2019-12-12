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
                    .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.Note));
            });

            var mapper = config.CreateMapper();

            return mapper.Map<List<HardwareInventoryService.Models.Models.Item>>(list);
        }
    }
}
