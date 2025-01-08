using AutoMapper;
using DataAccessLawyer.Interfaces;
using DataAccessLawyer.Models;
using MigrateMap.Bal.Interfaces;
using MigrateMap.Bal.Models.Response;

namespace MigrateMap.Bal.Implementation
{
    public class CorporationService: ICorporationService
    {

        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CorporationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #region Corporation
        public async Task<IEnumerable<CorporationResponse>> GetAllCorporations()
        {
            var corp = _unitOfWork.Corporation.GetAll().Where(a => a.isactive.Equals(true));
            var corpMap = _mapper.Map<List<CorporationResponse>>(corp);
            return corpMap;
        }
        public async Task<CorporationResponse> GetCorporationById(int corporationId)
        {
            var corp = _unitOfWork.Corporation.Find(a => a.corporationid.Equals(corporationId)).First();
            var corpMap = _mapper.Map<CorporationResponse>(corp);
            return corpMap;
        }
        public async Task CreateCorporation(BaseCorporationResponse request)
        {
            var corp = _unitOfWork.Corporation.GetAll().Max(a => a.corporationid);
            var dbCorp = _mapper.Map<Corporation>(request);
            dbCorp.corporationid = corp + 1;
            _unitOfWork.Corporation.Add(dbCorp);
            _unitOfWork.Save();
        }
        public async Task UpdateCorporation(CorporationResponse request)
        {
            var dbCorp = _mapper.Map<Corporation>(request);
            _unitOfWork.Corporation.Update(dbCorp);
            _unitOfWork.Save();
        }
        #endregion
    }
}
