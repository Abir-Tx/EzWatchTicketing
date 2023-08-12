using EWT_DAL.EF.Models;
using EWT_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EWT_DAL.Repos
{
    internal class MovieRepo : Repo, IRepo<Movie, int, bool>
    {
        public bool Create(Movie obj)
        {
            db.Movies.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var movie = db.Movies.Find(id);
            if (movie == null) return false;
            db.Movies.Remove(movie);
            return db.SaveChanges() > 0;
        }

        public List<Movie> Get()
        {
            return db.Movies.ToList();
        }

        public Movie Get(int id)
        {
            return db.Movies.Find(id);
        }

        public bool Update(Movie obj)
        {
            throw new NotImplementedException();
        }
    }
}
