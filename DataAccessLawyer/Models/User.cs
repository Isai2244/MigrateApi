using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLawyer.Models
{
    [Table("users")]
    public class users
    {
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string role { get; set; }
        public string organisation { get; set; }
        public DateTime created_at { get; set; }
        public bool isactive { get; set; }
    }

}
