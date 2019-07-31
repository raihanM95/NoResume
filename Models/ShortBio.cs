using System.ComponentModel.DataAnnotations;

namespace NoResume.Models
{
    public class ShortBio
    {
        [Key]
        [Required]
        public string DeveloperId { get; set; }
        
        [DataType(DataType.Html)]
        [MinLength(25)]
        [MaxLength(2048)]
        [Display(Name = "Short Description about your goals")]
        public string ShortDescription { get; set; }
        
        [Display(Name = "Your Current State/Country")]
        public string CurrentCity { get; set; }
        
        [Display(Name = "Are you available for a job? ")]
        public bool IsAvailableForJob { get; set; }
        
        public WorkingProfile Profile { get; set; }
    }
}