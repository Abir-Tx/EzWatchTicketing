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
    public class EmployeeService
    {
        public static List<EmployeeDTO> Get()
        {
            var data = DataAccesser.EmployeeDataAccess().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(config);
            var convertedData = mapper.Map<List<EmployeeDTO>>(data);
            return convertedData;
        }

        public static bool Create(EmployeeDTO employeeDTO)
        { 
        var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeDTO, Employee>();
            });
            var mapper = new Mapper(config);

            var employeeEntity = mapper.Map<Employee>(employeeDTO);
            var createdEmployeeEntity = DataAccesser.EmployeeDataAccess().Create(employeeEntity);
            return createdEmployeeEntity;
        }

        public static EmployeeDTO Get(int id)
        {
            var data  = DataAccesser.EmployeeDataAccess().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(config);
            var entity = mapper.Map<EmployeeDTO>(data);
            return entity;
        }
    }
}
