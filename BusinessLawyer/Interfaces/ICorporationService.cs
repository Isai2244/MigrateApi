using MigrateMap.Bal.Models.Response;

namespace MigrateMap.Bal.Interfaces
{
    public interface ICorporationService
    {
        #region Corporation
        Task<IEnumerable<CorporationResponse>> GetAllCorporations();
        Task<CorporationResponse> GetCorporationById(int corporationId);
        Task CreateCorporation(BaseCorporationResponse request);
        Task UpdateCorporation(CorporationResponse request);
        #endregion}
    }
}
