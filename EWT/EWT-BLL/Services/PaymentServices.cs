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
    public class PaymentServices
    {
        //add payment for card 
        //card is now temporay payment.cs 


        //add card details
        public static bool Create(PaymentDTO c)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PaymentDTO, Payment>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<Payment>(c);
            return DataAccesser.PaymentDataAccess().Create(converted);
        }

        public static List<PaymentDTO> Get()
        {
            var data = DataAccesser.PaymentDataAccess().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Payment, PaymentDTO>();
            });
            var mapper = new Mapper(config);
            var convertData = mapper.Map<List<PaymentDTO>>(data);
            return convertData;

        }

    }
}
