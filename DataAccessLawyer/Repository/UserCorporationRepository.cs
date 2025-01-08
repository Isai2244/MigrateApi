using DataAccessLawyer.Interfaces;
using DataAccessLawyer.Models;

namespace DataAccessLawyer.Repository
{
    public class UserCorporationRepository : GenericRepository<UserCorporation>, IUserCorporationRepository
    {
        public UserCorporationRepository(UserDBContext context) : base(context) { }

    }
}
