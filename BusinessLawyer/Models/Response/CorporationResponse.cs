using System.ComponentModel.DataAnnotations;

namespace MigrateMap.Bal.Models.Response
{
    public class CorporationResponse : BaseCorporationResponse
    {
        [Required(ErrorMessage = "Name is required")]
        public int CorporationId { get; set; }
    }
    public class BaseCorporationResponse
    {
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
    }
}
