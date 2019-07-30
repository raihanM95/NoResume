using System.ComponentModel.DataAnnotations;

namespace NoResume.Models
{
    public class AuthenticateDevelopers
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string DevEmail { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Choose a password")]
        public string DevPassword { get; set; }
    }
}