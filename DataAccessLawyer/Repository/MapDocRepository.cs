using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLawyer.Interfaces;
using DataAccessLawyer.Models;
using static DataAccessLawyer.Repository.MapDocRepository;

namespace DataAccessLawyer.Repository
{
        public class MapDocRepository : GenericRepository<MapDoc>, IMapDocRepository
        {
            public MapDocRepository(UserDBContext context) : base(context) { }

        }
}
