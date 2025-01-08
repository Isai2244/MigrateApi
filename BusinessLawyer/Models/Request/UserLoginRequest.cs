using System.ComponentModel.DataAnnotations;

namespace MigrateMap.Bal.Models.Request
{
    public class UserLoginRequest
    {
        [Required(ErrorMessage ="Username is required")]
        //[MinLength(1,ErrorMessage ="Min lenght 1")]
        //[MaxLength(3,ErrorMessage = "Max length 3")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
