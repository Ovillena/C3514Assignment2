using System;
using System.ComponentModel.DataAnnotations;

namespace SpeakerLibrary
{
    public class Speaker
    {
        public string SpeakerId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        [MaxLength(40)]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(40)]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        [MaxLength(200)]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Mobile Number")]
        [MaxLength(15)]
        public string MobileNumber { get; set; }
        [Required]
        [Display(Name = "Area of Specialization")]
        [MaxLength(40)]
        public string Specialization { get; set; }
        [Required]
        [Display(Name = "City of Residence")]
        [MaxLength(40)]
        public string City { get; set; }
        [Required]
        [Display(Name = "Province of Residence")]
        [MaxLength(2)]
        public string Province { get; set; }
        [Required]
        [MaxLength(40)]
        public string Employer { get; set; }
    }

}
