using AutoMapper;
using EWT_BLL.DTOs;
using EWT_DAL.EF.Models;
using EWT_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWT_BLL.Services
{
    public class OrderFoodService
    {
        public static List<OrderFoodDTO> Get()
        {
            var data = DataAccesser.OrderFoodDataAccess().Get();
            var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<OrderFood, OrderFoodDTO>());
            var mapper = new Mapper(config);
            var convertData = mapper.Map<List<OrderFoodDTO>>(data);
            return convertData;
        }
        //byid
        public static OrderFoodDTO Get(int id)
        {
            var data = DataAccesser.OrderFoodDataAccess().Get(id);
            var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<OrderFood, OrderFoodDTO>());
            var mapper = new Mapper(config);
            var convertData = mapper.Map<OrderFoodDTO>(data);
            return convertData;
        }
        //create
        public static bool Create(OrderFoodDTO orderfood)
        {
            if (orderfood == null)
                return false;
            else
            {
                var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<OrderFoodDTO, OrderFood>());
                var mapper = new Mapper(config);
                var convertData = mapper.Map<OrderFood>(orderfood);
                return DataAccesser.OrderFoodDataAccess().Create(convertData);

            }
        }
        //delete
        public static bool Delete(int id)
        {
            return DataAccesser.OrderFoodDataAccess().Delete(id);
        }
        //update
        public static bool Update(OrderFoodDTO orderfood)
        {
            if (orderfood == null)
                return false;
            else
            {
                var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<OrderFoodDTO, OrderFood>());
                var mapper = new Mapper(config);
                var convertData = mapper.Map<OrderFood>(orderfood);

                return DataAccesser.OrderFoodDataAccess().Update(convertData);

            }
        }
    }
   
}

    