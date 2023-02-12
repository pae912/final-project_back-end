using System.ComponentModel.DataAnnotations;

namespace project.Dtos
{
    public class DVDForUpdateDto
    {
        [Required]
        public int D_id { get; set; }
        [Required]
        public string D_no { get; set; }
        [Required]
        public string D_name { get; set; }
        [Required]
        public string C_id { get; set; }
    }
}
