using AutoMapper;
using DataAccessLawyer.Interfaces;
using DataAccessLawyer.Models;
using MigrateMap.Bal.Interfaces;
using MigrateMap.Bal.Models.Response;

namespace MigrateMap.Bal.Implementation
{
    public class MappingDBService : IMappingDBService
    {

        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MappingDBService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #region MappingDB
        public async Task<IEnumerable<MappingDBResponse>> GetAllMappingDB()
        {
            var mapDb = _unitOfWork.MappingDB.GetAll().Where(a => a.isactive.Equals(true));
            var map = _mapper.Map<List<MappingDBResponse>>(mapDb);
            return map;
        }
        public async Task<MappingDBResponse> GetMappingDBById(int mappingdbid)
        {
            var mapDb = _unitOfWork.MappingDB.Find(a => a.mappingdbid.Equals(mappingdbid)).First();
            var corpMap = _mapper.Map<MappingDBResponse>(mapDb);
            return corpMap;
        }
        public async Task CreateMappingDB(BaseMappingDBResponse request)
        {
            var map = _unitOfWork.MappingDB.GetAll().Max(a => a.mappingdbid);
            var dbMap = _mapper.Map<MappingDB>(request);
            dbMap.mappingdbid = map + 1;
            _unitOfWork.MappingDB.Add(dbMap);
            _unitOfWork.Save();
        }
        public async Task UpdateMappingDB(MappingDBRequest request)
        {
            var dbMap = _mapper.Map<MappingDB>(request);
            _unitOfWork.MappingDB.Update(dbMap);
            _unitOfWork.Save();
        }
        #endregion
    }
}
