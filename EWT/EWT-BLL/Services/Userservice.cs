using AutoMapper;
using EWT_BLL.DTOs;
using EWT_DAL;
using EWT_DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace EWT_BLL.Services
{
    public class UserService
    {
        public static List<UserDTO> Get()
        {

            var data = DataAccesser.UserDataAccess().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            var convertedData = mapper.Map<List<UserDTO>>(data);
            return convertedData;


        }

        public static UserDTO Get(int id)
        {
            var data = DataAccesser.UserDataAccess().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            var entity = mapper.Map<UserDTO>(data);
            return entity;
        }
    }
}
