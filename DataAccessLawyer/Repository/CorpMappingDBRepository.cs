using DataAccessLawyer.Interfaces;
using DataAccessLawyer.Models;

namespace DataAccessLawyer.Repository
{
    public class CorpMappingDBRepository : GenericRepository<CorpMappingDB>, ICorpMappingDBRepository
    {
        public CorpMappingDBRepository(UserDBContext context) : base(context) { }

    }
}
