using MigrateMap.Bal.Models.Response;

namespace MigrateMap.Bal.Interfaces
{
    public interface IMappingDBService
    {
        #region MappingDB
        Task<IEnumerable<MappingDBResponse>> GetAllMappingDB();
        Task<MappingDBResponse> GetMappingDBById(int mappingdbid);
        Task CreateMappingDB(BaseMappingDBResponse request);
        Task UpdateMappingDB(MappingDBRequest request);
        #endregion
    }
}
