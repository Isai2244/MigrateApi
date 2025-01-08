using DataAccessLawyer.Interfaces;
using DataAccessLawyer.Models;

namespace DataAccessLawyer.Repository
{
    public class UsersRepository : GenericRepository<users>, IUsersRepository
    {
        public UsersRepository(UserDBContext context) : base(context) { }

    }
}
