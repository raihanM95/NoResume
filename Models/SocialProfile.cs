using System.ComponentModel.DataAnnotations;

namespace NoResume.Models
{
    public class SocialProfile
    {
        [Key]
        [Required]
        public string DeveloperId { get; set; }

        [Display(Name = "LinkedIn Username")]
        public string LinkedInUsername { get; set; }

        [Display(Name = "Facebook Username")]
        public string FacebookUsername { get; set; }
        
        [Display(Name = "Twitter Username")]
        public string TwitterUsername { get; set; }
    }
}