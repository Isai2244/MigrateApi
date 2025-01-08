namespace DataAccessLawyer.Models
{
    public class CorpMappingDB
    {
        public int corpmappingdbid { get; set; }
        public int corporationid { get; set; }
        public int mappingdbid { get; set; }
        public string connectionstring { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public bool isactive { get; set; }
    }
}
