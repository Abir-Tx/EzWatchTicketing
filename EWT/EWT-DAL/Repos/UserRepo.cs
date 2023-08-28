using EWT_DAL.EF.Models;
using EWT_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWT_DAL.Repos
{
    internal class UserRepo : Repo, IRepo<User, int, bool>, IAuth<User>
    {
        public User Authenticate(string username, string password)
        {
            var data = from user in db.Users
                       where user.Username.Equals(username)
                       && user.Password.Equals(password)
                       select user;
            return data.SingleOrDefault();
        }

        public bool Create(User obj)
        {
            var role = db.Roles.FirstOrDefault(r => r.RoleName == "User");
            if (role != null)
            {
               obj.Role = role;
                db.Users.Add(obj);
            }
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var userToDelete = db.Users.FirstOrDefault(user => user.Id == id);
            if (userToDelete != null)
            {
                db.Users.Remove(userToDelete);
                return db.SaveChanges() > 0;
            }

            return false;

        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public bool Update(User obj)
        {
            var UserToUpdate = db.Users.Find(obj.Id);
            if (UserToUpdate == null)
            {
                return false;
            }

            UserToUpdate.Id = obj.Id;
            UserToUpdate.Name = obj.Name;
            UserToUpdate.Email = obj.Email;
            UserToUpdate.Password = obj.Password;

            db.Users.AddOrUpdate(UserToUpdate);
            return db.SaveChanges() > 0;

        }
    }
}
