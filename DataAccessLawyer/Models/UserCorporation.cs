namespace DataAccessLawyer.Models
{
    public class UserCorporation
    {
        public int usercorporationid { get; set; }
        public int userid { get; set; }
        public int corporationid { get; set; }
        public string description { get; set; }
        public bool isactive { get; set; }
    }
}
