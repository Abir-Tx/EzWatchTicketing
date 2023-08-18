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
    public class HallService
    {
        public static List<HallDTO> Get()
        {
            var data=DataAccesser.HallDataAceess().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Hall, HallDTO>();
            });
            var mapper = new Mapper(config);
            var convertData=mapper.Map<List<HallDTO>>(data);
            return convertData;

        }
        public static bool Create(HallDTO c)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<HallDTO, Hall>();
            });
            var mapper=new Mapper(config);
            var converted = mapper.Map<Hall>(c);
            return DataAccesser.HallDataAceess().Create(converted);
        }
        public static bool Delete(int id) 
        { 
            return DataAccesser.HallDataAceess().Delete(id);

        }
        public static bool Update(HallDTO c)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<HallDTO, Hall>();
            });
            var mapper = new Mapper(config);
            var converted=mapper.Map<Hall>(c);
            return DataAccesser.HallDataAceess().Update(converted);

        }

        public static HallDTO Get(int id)
        {
            var data=DataAccesser.HallDataAceess().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Hall, HallDTO>();
                cfg.CreateMap<Hall,HallSeatDTO>();
            });
            var mapper=new Mapper(config);  
            var convertedData=mapper.Map<HallDTO>(data);
            
            return convertedData;
        }
        //needs modification
        public static HallSeatDTO GetSeatByHall(int id)
        {
            var data = DataAccesser.HallDataAceess().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                
                cfg.CreateMap<Hall, HallSeatDTO>();
            });
            var mapper = new Mapper(config);
            var convertedData = mapper.Map<HallSeatDTO>(data);

            return convertedData;
        }

     
    }
}
