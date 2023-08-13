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
    public class TicketService
    {
        public static List<TicketDTO> Get()
        {
            var data = DataAccesser.TicketDataAccess().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Ticket, TicketDTO>();
            });
            var mapper = new Mapper(config);
            var convertedData = mapper.Map<List<TicketDTO>>(data);
            return convertedData;
        }

        public static TicketDTO Get(int id)
        {
            var data = DataAccesser.TicketDataAccess().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Ticket, TicketDTO>();
            });
            var mapper = new Mapper(config);
            var convertedData = mapper.Map<TicketDTO>(data);
            return convertedData;
        }

        public static bool Create(TicketDTO c)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TicketDTO, Ticket>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<Ticket>(c);
            return DataAccesser.TicketDataAccess().Create(converted);
        }

        public static bool Delete(int id)
        {
            return DataAccesser.TicketDataAccess().Delete(id);
        }

        public static bool Update(TicketDTO c)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TicketDTO, Ticket>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<Ticket>(c);
            return DataAccesser.TicketDataAccess().Update(converted);
        }
    }
}
