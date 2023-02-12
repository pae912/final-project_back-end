using System.ComponentModel.DataAnnotations;

namespace project.Models
{
    public class DVD
    {
        [Key]
        public int D_id { get; set; }
        [Required]
        public string D_no { get; set; }
        [Required]
        public string D_name { get; set; }
        [Required]
        public string C_id { get; set; }
        [Required]
        public string D_introduction { get; set; }
        [Required]
        public string D_img { get; set; }
    }
}
