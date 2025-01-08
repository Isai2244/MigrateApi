using MigrateMap.Bal;
using Npgsql;

namespace Crate.MigrateMap.CrateDal
{
    public class MapperRepository
    {
        private string _connectionString { get { return "Host=cratedb-test.aks1.eastus2.azure.cratedb.net;Port=5432;Username=admin;Password=R))4nF2Gy,cTG742XP1)3m!v;Database=doc"; } }
        private NpgsqlDataSource _dataSource;
        private NpgsqlConnection _conn;

        public MapperRepository()
        {
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(_connectionString);
            _dataSource = dataSourceBuilder.Build();
        }
        public async Task<List<string>> GetAvailableTables()
        {
            var str = new List<string>();

            _conn = await _dataSource.OpenConnectionAsync();

            await using (var cmd = new NpgsqlCommand("SELECT table_schema, table_name, table_type FROM information_schema.tables ORDER BY table_schema ASC, table_name ASC;", _conn))
            {
                await using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            str.Add(reader.GetValue(1).ToString());
                        };
                    }
                }
            }
            return str;
        }

        public async Task<List<string>> GetCorpMappingDB()
        {
            var str = new List<string>();

            _conn = await _dataSource.OpenConnectionAsync();

            await using (var cmd = new NpgsqlCommand("SELECT corpmappingdbid, corporationid, mappingdbid, description FROM corpmappingdb;", _conn))
            {
                await using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            str.Add(reader.GetValue(1).ToString());
                        };
                    }
                }
            }
            return str;
        }
        public async Task<List<MapperResponse>> GetAvailableTableColumns(string tableName)
        {
            var str = new List<MapperResponse>();

            _conn = await _dataSource.OpenConnectionAsync();

            await using (var cmd = new NpgsqlCommand("select column_name,data_type from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME=@table_name;", _conn))
            {
                cmd.Parameters.AddWithValue("@table_name", tableName);
                await using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            str.Add(new MapperResponse { ColumnName = reader.GetValue(0).ToString(), ColumnDataType = reader.GetValue(1).ToString() });
                        };
                    }
                }
            }
            return str;
        }
        public async Task Dispose()
        {
            await _conn.CloseAsync();
        }
    }
}
