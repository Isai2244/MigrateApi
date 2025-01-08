using DataAccessLawyer.Interfaces;
using DataAccessLawyer.Models;

namespace DataAccessLawyer.Repository
{
    public class MappingDBRepository : GenericRepository<MappingDB>, IMappingDBRepository
    {
        public MappingDBRepository(UserDBContext context) : base(context) { }

    }
}
