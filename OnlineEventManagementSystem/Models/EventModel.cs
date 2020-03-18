using System.ComponentModel.DataAnnotations;

namespace OnlineEventManagementSystem.Models
{
    public class EventModel
    {
        public string EventId { get; set; }

        //Validation for event name
        [Required(ErrorMessage ="Please enter the event name")]
        [RegularExpression("[A-Z][a-z][^(@#&<>~;$^%{}?][^0-9]{0,35}", ErrorMessage = "Please enter the event name in correct format")]
        [Display(Name ="Event Name")]
        [MaxLength(20)]
        public string EventName { get; set; }

        //Validation for the event type
        [Required]
        [Display(Name ="Event Type")]
        public string EventType { get; set; }
    }
}