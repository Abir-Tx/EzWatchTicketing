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
            var Config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            var convertedData = Mapper.Map<List<UserDTO>>(DataAccesser);
            return convertedData;


        }

        public static UserDTO Get(int id)
        {
            return DataAccesser.UserDataAccess().Get(id);
        }
    }
}
