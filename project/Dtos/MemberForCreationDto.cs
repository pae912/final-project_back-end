using System.ComponentModel.DataAnnotations;

namespace project.Dtos
{
    public class MemberForCreationDto
    {
        [Required]
        public string M_name { get; set; }
        [Required]
        public string M_phone { get; set; }
        [Required]
        public string M_sex { get; set; }
        [Required]
        public string M_add { get; set; }
        [Required]
        public string M_date { get; set; }
        [Required]
        public string M_mail { get; set; }

    }
}
