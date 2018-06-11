using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        //Add Phone Number property to Register viewmodel.
        [Required]
        [Display(Name = "Phone Number")]
        public string MobileNumber { get; set; }

        //Add Driving License property to Register viewmodel.
        [Required]
        [Display(Name = "Driving License")]
        public string DrivingLicense { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}