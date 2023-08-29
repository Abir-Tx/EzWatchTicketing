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
    public class FoodService
    {
        public static List<FoodDTO> Get()
        {
            var data= DataAccesser.FoodDataAccess().Get();
            var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<Food, FoodDTO>());
            var mapper = new Mapper(config);
            var convertData=mapper.Map<List<FoodDTO>>(data);    
            return convertData; 
        }
        //byid
        public static FoodDTO Get(int id)
        {
            var data = DataAccesser.FoodDataAccess().Get(id);
            var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<Food, FoodDTO>());
            var mapper = new Mapper(config);
            var convertData = mapper.Map<FoodDTO>(data);
            return convertData;
        }
        //create
        public static bool create(FoodDTO food)
        {
            if (food==null)
                return false;
            else
            {
                var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<FoodDTO, Food>());
                var mapper = new Mapper(config);
                var convertData = mapper.Map<Food>(food);
                return DataAccesser.FoodDataAccess().Create(convertData);

            }
        }
        //delete
        public static bool Delete(int id)
        {
            return DataAccesser.FoodDataAccess().Delete(id);    
        }
        //update
        public static bool update(FoodDTO food)
        {
            if (food == null)
                return false;
            else
            {
                var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<FoodDTO, Food>());
                var mapper = new Mapper(config);
                var convertData = mapper.Map<Food>(food);

                return DataAccesser.FoodDataAccess().Update(convertData);

            }

        }

    }
}
