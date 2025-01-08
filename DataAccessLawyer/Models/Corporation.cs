using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLawyer.Models
{
    [Table("Corporation")]
    public class Corporation
    {
        public int corporationid { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool isactive { get; set; }
    }
}
