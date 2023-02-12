using System.ComponentModel.DataAnnotations;

namespace project.Dtos
{
    public class OnSiteForCreationDto
    {
        [Required]
        public int On_no { get; set; }
        [Required]
        public int D_id { get; set; }
        [Required]
        public Guid BrrowM_id { get; set; }
        [Required]
        public String S_id { get; set; }
        [Required]
        public String Brrow_date { get; set; }
        [Required]
        public String Return_date { get; set; }
    }
}
