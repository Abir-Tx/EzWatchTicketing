using EWT_DAL.EF;

namespace EWT_DAL.Repos
{
    internal class Repo
    {
        protected EWTContext db;

        internal Repo()
        {
            db = new EWTContext();
        }
    }
}
