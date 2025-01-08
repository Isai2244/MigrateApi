namespace MigrateMap.Bal.Models.Response
{
    public class MappingDBResponse: BaseMappingDBResponse
    {
        public int MappingdbId { get; set; }

    }
    public class BaseMappingDBResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
