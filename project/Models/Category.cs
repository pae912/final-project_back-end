using System.ComponentModel.DataAnnotations;

namespace project.Models
{
    public class Category
    {
        [Key]
        public string C_id { get; set; }
        [Required]
        public string C_name { get; set; }
    }
}
