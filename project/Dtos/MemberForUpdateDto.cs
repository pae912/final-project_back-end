using System.ComponentModel.DataAnnotations;

namespace project.Dtos
{
    public class MemberForUpdateDto
    {
   
        [Required]
        public String M_name { get; set; }
        [Required]
        public String M_phone { get; set; }
        [Required]
        public String M_sex { get; set; }
        [Required]
        public String M_add { get; set; }
        [Required]
        public String M_date { get; set; }
        [Required]
        public String M_mail { get; set; }
    }
}
