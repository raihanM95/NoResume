using System.ComponentModel.DataAnnotations;

namespace NoResume.Models
{
    public class WorkingProfile
    {
        [Key]
        [Required]
        public string DeveloperId { get; set; }
        
        [Display(Name = "Your GitHub username")]
        public string GithubUsername { get; set; }
        
        [Display(Name = "Do you wish to make GitHub private?")]
        public bool PrivacyForGithub { get; set; }
        
        [Display(Name = "Your Codeforces handler")]
        public string CodeforcesUsername { get; set; }
        
        [Display(Name = "Do you wish to make codeforces private?")]
        public bool PrivacyForCodeforces { get; set; }
        
        [Display(Name = "Your UVA OJ username")]
        public string UhuntUsername { get; set; }
        
        [Display(Name = "Do you wish to make UVA private?")]
        public bool PrivacyForUhunt { get; set; }

        public ShortBio ShortBio { get; set; }
    }
}