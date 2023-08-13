using EWT_DAL.EF.Models;

namespace EWT_DAL.Repos
{
    internal interface IUserRepo
    {
        bool Create(User obj);
        bool Delete(string id);
    }
}