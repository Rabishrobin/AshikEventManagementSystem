using System.ComponentModel.DataAnnotations;

namespace OnlineEventManagementSystem.Models
{
    public class PackageModel
    {
        public int PackageId { get; set; }

        //Validation for package name
        [Required(ErrorMessage = "Please enter the package name")]
        [RegularExpression("[A-Z][a-z][^(@#&<>~;$^%{}?][^0-9]{0,35}", ErrorMessage = "Please enter a valid package name")]
        [Display(Name = "Package Name")]
        [MaxLength(20)]
        public string PackageName { get; set; }

        //Validation for event
        [Required(ErrorMessage = "Please select a event")]
        [Display(Name = "Event Name")]
        public int EventID { get; set; }

        //Validation for services
        [Required(ErrorMessage = "Please select a service")]
        [Display(Name = "Service Name")]
        public int ServiceID { get; set; }

    }
}