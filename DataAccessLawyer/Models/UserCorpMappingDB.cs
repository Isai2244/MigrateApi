namespace DataAccessLawyer.Models
{
    public class UserCorpMappingDB
    {
        public int usercorpmappingdbid { get; set; }
        public int userid { get; set; }
        public int corpmappingdbid { get; set; }
        public string description { get; set; }
        public bool isactive { get; set; }
    }
}
