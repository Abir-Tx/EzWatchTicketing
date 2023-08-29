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
    public class HallSeatService
    {
        public static List<SeatDTO> Get()
        {
            var data = DataAccesser.SeatDataAccess().Get();
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<Seat, SeatDTO>());
            var mapper = new Mapper(config);
            var convertData = mapper.Map<List<SeatDTO>>(data);
            return convertData;
        }

        public static HallSeatDTO Get(int id)
        {
            var data = DataAccesser.SeatDataAccess().Get(id);
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<Seat, SeatDTO>());
            var mapper = new Mapper(config);
            var convertData = mapper.Map<HallSeatDTO>(data);
            return convertData;
        }

        public static bool Create(SeatDTO seat)
        {
            if (seat == null)
                return false;
            else
            {
                var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<HallSeatDTO, Seat>());
                var mapper = new Mapper(config);
                var convertData = mapper.Map<Seat>(seat);
                return DataAccesser.SeatDataAccess().Create(convertData);
            }
        }

        public static bool Delete(int id)
        {
            return DataAccesser.SeatDataAccess().Delete(id);
        }

        public static bool Update(SeatDTO seat)
        {
            if (seat == null)
                return false;
            else
            {
                var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<SeatDTO, Seat>());
                var mapper = new Mapper(config);
                var convertData = mapper.Map<Seat>(seat);
                return DataAccesser.SeatDataAccess().Update(convertData);
            }
        }
    }

}
