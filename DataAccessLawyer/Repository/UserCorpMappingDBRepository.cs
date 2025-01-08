using DataAccessLawyer.Interfaces;
using DataAccessLawyer.Models;

namespace DataAccessLawyer.Repository
{
    public class UserCorpMappingDBRepository : GenericRepository<UserCorpMappingDB>, IUserCorpMappingDBRepository
    {
        public UserCorpMappingDBRepository(UserDBContext context) : base(context) { }

    }
}
