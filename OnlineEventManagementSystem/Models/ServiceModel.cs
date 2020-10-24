using System.ComponentModel.DataAnnotations;

namespace OnlineEventManagementSystem.Models
{
    public class ServiceModel
    {
        public int ServiceId { get; set; }

        //Validation for service name
        [Required(ErrorMessage = "Please enter the service name")]
        [RegularExpression("[A-Z][a-z][^(@#&<>~;$^%{}?][^0-9]{0,35}", ErrorMessage = "Please enter a valid service name")]
        [Display(Name = "Service Name")]
        [MaxLength(20)]
        public string ServiceName { get; set; }

        //Validation for service category
        [Required(ErrorMessage ="Please select a category")]
        [Display(Name = "Service Category")]
        public int CategoryID { get; set; }

        //Validaton for the event type where the service is used
        [Required(ErrorMessage ="Please select a event type")]
        [Display(Name = "Event Type")]
        public string EventType { get; set; }
    }
}