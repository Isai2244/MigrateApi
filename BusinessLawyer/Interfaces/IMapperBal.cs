namespace MigrateMap.Bal.Interfaces
{
    public interface IMapperBal
    {
        Task<List<string>> GetAvailableTables();
        Task<List<MapperResponse>> GetAvailableTableColumns(string tableName);
    }
}
