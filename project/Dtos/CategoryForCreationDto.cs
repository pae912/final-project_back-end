using System.ComponentModel.DataAnnotations;

namespace project.Dtos
{
    public class CategoryForCreationDto
    {
        [Required]
        public string C_id { get; set; }
        [Required]
        public string C_name { get; set; }
    }
}
