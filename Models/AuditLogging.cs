using System;
using System.ComponentModel.DataAnnotations;

namespace NoResume.Models
{
    public class AuditLogging
    {
        [Key]
        [Required]
        public string AuditId { get; set; }
        
        [Required]
        public string AuditDescription { get; set; }
        
        [Required] 
        public bool IsExceptionThrown { get; set; }
        
        [Required] 
        public string DeveloperOrAnonymous { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime TimeOfAction { get; set; }

        [Required]
        public string InternetProtocol { get; set; }
        
        [Required] 
        public string Country { get; set; }
        
        [Required]
        public string CountryCode { get; set; }

        [Required]
        public string Latitude { get; set; }

        [Required]
        public string Longitude { get; set; }
    }
}