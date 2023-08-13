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
    public class AdminService
    {
        public static List<AdminDTO> Get()
        {
            var data = DataAccesser.AdminDataAccess().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(config);
            var convertedData = mapper.Map<List<AdminDTO>>(data);
            return convertedData;
        }

        public static AdminDTO Get(int id)
        {
            var data = DataAccesser.AdminDataAccess().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(config);
            var convertedData = mapper.Map<AdminDTO>(data);
            return convertedData;
        }

        public static bool Create(AdminDTO c)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AdminDTO, Admin>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<Admin>(c);
            return DataAccesser.AdminDataAccess().Create(converted);
        }

        public static bool Delete(int id)
        {
            return DataAccesser.AdminDataAccess().Delete(id);
        }

        public static bool Update(AdminDTO c)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AdminDTO, Admin>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<Admin>(c);
            return DataAccesser.AdminDataAccess().Update(converted);
        }
    }
}
