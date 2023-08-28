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

        public static bool Create(UserDTO userDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, User>();
            });

            var mapper = new Mapper(config);
            var userEntity = mapper.Map<User>(userDTO);
            var createdUserEntity = DataAccesser.UserDataAccess().Create(userEntity);
            return createdUserEntity;

        }


        public static bool Delete(int id)
        {
            var user = DataAccesser.UserDataAccess().Get(id);
            if (user == null)
                return false;
            return DataAccesser.UserDataAccess().Delete(id);

        }

        public static bool Update(UserDTO user)
        {
            if (user == null)
                return false;
            else
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<User, UserDTO>();
                });

                var mapper = new Mapper(config);
                var userEntity = mapper.Map<User>(user);
                return DataAccesser.UserDataAccess().Update(userEntity);
            }
        }
    }
}
