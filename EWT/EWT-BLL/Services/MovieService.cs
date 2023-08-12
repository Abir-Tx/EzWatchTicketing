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
    public class MovieService
    {
        public static List<MovieDTO> Get()
        {
            var data = DataAccesser.MovieDataAccess().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Movie, MovieDTO>();
            });
            var mapper = new Mapper(config);
            var convertedData = mapper.Map<List<MovieDTO>>(data);
            return convertedData;
        }

        public static MovieDTO Get(int id)
        {
            var data  = DataAccesser.MovieDataAccess().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Movie, MovieDTO>();
            });
            var mapper = new Mapper(config);
            var singleMovie = mapper.Map<MovieDTO>(data);
            return singleMovie;
        }

        public static bool Create(MovieDTO movie)
        {
            if (movie == null)
            {
                return false;
            }
            else
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<MovieDTO, Movie>();
                });
                var mapper = new Mapper(config);
                var movieEntity = mapper.Map<Movie>(movie);
                return DataAccesser.MovieDataAccess().Create(movieEntity);
            }
        }

        public static bool Delete(int id)
        {
            return DataAccesser.MovieDataAccess().Delete(id);
        }

        public static bool Update(MovieDTO movie)
        {
            if (movie == null)
            {
                return false;
            }
            else
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<MovieDTO, Movie>();
                });
                var mapper = new Mapper(config);
                var movieEntity = mapper.Map<Movie>(movie);
                return DataAccesser.MovieDataAccess().Update(movieEntity);
            }
        }
    }
}
