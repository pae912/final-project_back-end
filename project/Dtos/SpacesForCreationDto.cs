using System.ComponentModel.DataAnnotations;

namespace project.Dtos
{
    public class SpacesForCreationDto
    {
        [Required]
        public string S_id { get; set; }
        [Required]
        public string S_name { get; set; }
        [Required]
        public string S_type { get; set; }
       
    }
}
