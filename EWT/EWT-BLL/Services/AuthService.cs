using AutoMapper;
using EWT_BLL.DTOs;
using EWT_DAL;
using EWT_DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWT_BLL.Services
{
    public class AuthService
    {
        public static bool IsTokenValid(string token)
        {
            var tk = (from t in DataAccesser.TokenDataAccess().Get()
                      where t.TokenKey.Equals(token)
                      && t.ExpiredAt == null
                      select t).SingleOrDefault();
            if (tk != null)
            {
                return true;
            }
            return false;
        }

        public static TokenDTO Login(string username, string password)
        {
            var data = DataAccesser.AuthDataAccess().Authenticate(username, password);
            var token = new Token();

            token.Username = username;
            token.TokenKey = Guid.NewGuid().ToString();
            token.CreatedAt = DateTime.Now;
            token.ExpiredAt = null;
            var tk = DataAccesser.TokenDataAccess().Create(token);

            // conver to dto using automapper
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Token, TokenDTO>();
            });
            var mapper = new Mapper(config);
            var convertedData = mapper.Map<TokenDTO>(tk);
            return convertedData;
        }
    }
}
