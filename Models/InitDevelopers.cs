using System.ComponentModel.DataAnnotations;

namespace NoResume.Models
{
    public class InitDevelopers
    {
        [Key]
        public string DevId { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        public string DevEmail { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Choose a password")]
        public string DevPassword { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("DevPassword",ErrorMessage = "Both Passwords Don't Match")]
        public string DevConfirmPassword { get; set; }
    }
}