using System.ComponentModel.DataAnnotations;

namespace project.Models
{
    public class Spaces
    {
        [Key]
        public string S_id { get; set; }
        [Required]
        public string S_name { get; set; }
        [Required]
        public string S_type { get; set; }

    }
}
