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
    }
}
