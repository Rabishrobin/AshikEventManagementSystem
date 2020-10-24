using System.ComponentModel.DataAnnotations;

namespace OnlineEventManagementSystem.Models
{
    public class EventModel
    {
        public int EventId { get; set; }

        //Validation for event name
        [Required(ErrorMessage ="Please enter the event name")]
        [RegularExpression("[A-Z][a-z][^(@#&<>~;$^%{}?][^0-9]{0,35}", ErrorMessage = "Please enter a valid event name")]
        [Display(Name ="Event Name")]
        [MaxLength(20)]
        public string EventName { get; set; }

        //Validation for the event type
        [Required(ErrorMessage ="Please select a event type")]
        [Display(Name ="Event Type")]
        public string EventType { get; set; }
    }
}