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
        public static bool Create(PaymentDTO paymentDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PaymentDTO, Payment>();
            });
            var mapper = new Mapper(config);
            var paymentEntity = mapper.Map<Payment>(paymentDTO);

            return DataAccesser.PaymentDataAccess().Create(paymentEntity);
        }

        public static List<PaymentDTO> Get()
        {
            var data = DataAccesser.PaymentDataAccess().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Payment, PaymentDTO>();
            });
            var mapper = new Mapper(config);
            var convertedData = mapper.Map<List<PaymentDTO>>(data);
            return convertedData;
        }

        public static PaymentDTO Get(int id)
        {
            var data = DataAccesser.PaymentDataAccess().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Payment, PaymentDTO>();
            });
            var mapper = new Mapper(config);
            var convertedData = mapper.Map<PaymentDTO>(data);
            return convertedData;
        }

        public static bool Update(PaymentDTO paymentDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PaymentDTO, Payment>();
            });
            var mapper = new Mapper(config);
            var paymentEntity = mapper.Map<Payment>(paymentDTO);

            return DataAccesser.PaymentDataAccess().Update(paymentEntity);
        }

        public static bool Delete(int id)
        {
            return DataAccesser.PaymentDataAccess().Delete(id);
        }
    }
}