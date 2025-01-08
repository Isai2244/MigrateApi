using Npgsql;

namespace MigrateMap.CrateDal
{
    public class GenericRepository
    {
        public async Task GetData()
        {
            var str = new List<string>();
            var connString = "Host=cratedb-test.aks1.eastus2.azure.cratedb.net;Port=5432;Username=admin;Password=R))4nF2Gy,cTG742XP1)3m!v;Database=crate";

            var dataSourceBuilder = new NpgsqlDataSourceBuilder(connString);
            var dataSource = dataSourceBuilder.Build();

            var conn = await dataSource.OpenConnectionAsync();
            // Retrieve all rows
            //await using (var cmd = new NpgsqlCommand("SELECT * FROM \"doc\".\"air_quality_data\"",
            //conn))
            //await using (var cmd = new NpgsqlCommand("SELECT * FROM doc.air_quality_data;",conn))
            await using (var cmd = new NpgsqlCommand("SELECT table_schema, table_name, table_type FROM information_schema.tables ORDER BY table_schema ASC, table_name ASC limit 100;", conn))
            await using (var reader = await cmd.ExecuteReaderAsync())
            {
                if (reader.HasRows)
                    while (await reader.ReadAsync())
                    {
                        str.Add(reader.GetValue(1).ToString());
                    };

                //var schema = reader.GetSchemaTable();
                //foreach (DataRow row in schema.Rows)
                //{
                //    Debug.WriteLine(row["ColumnName"] + " - " + row["DataTypeName"]);
                //}
            }
        }
    }
}
