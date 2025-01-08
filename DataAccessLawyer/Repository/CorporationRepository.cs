using DataAccessLawyer.Interfaces;
using DataAccessLawyer.Models;

namespace DataAccessLawyer.Repository
{
    public class CorporationRepository : GenericRepository<Corporation>, ICorporationRepository
    {
        public CorporationRepository(UserDBContext context) : base(context) { }

    }
}
