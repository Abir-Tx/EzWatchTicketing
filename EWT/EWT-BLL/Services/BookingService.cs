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
    public class BookingService
    {
        public static List<BookingDTO> Get()
        {
            var data = DataAccesser.BookingDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Booking, BookingDTO>());
            var mapper = new Mapper(config);
            var convertData = mapper.Map<List<BookingDTO>>(data);
            return convertData;
        }

        public static BookingDTO Get(int id)
        {
            var data = DataAccesser.BookingDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Booking, BookingDTO>());
            var mapper = new Mapper(config);
            var convertData = mapper.Map<BookingDTO>(data);
            return convertData;
        }

        public static bool Create(BookingDTO booking)
        {
            if (booking == null)
                return false;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookingDTO, Booking>());
            var mapper = new Mapper(config);
            var convertData = mapper.Map<Booking>(booking);

            return DataAccesser.BookingDataAccess().Create(convertData);
        }


        public static bool Update(BookingDTO booking)
        {
            if (booking == null)
                return false;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookingDTO, Booking>());
            var mapper = new Mapper(config);
            var convertData = mapper.Map<Booking>(booking);

            return DataAccesser.BookingDataAccess().Update(convertData);
        }

        public static bool Delete(int id)
        {
            return DataAccesser.BookingDataAccess().Delete(id);
        }
    }
}
