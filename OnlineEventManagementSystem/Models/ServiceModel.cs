using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineEventManagementSystem.Models
{
    public class ServiceModel
    {
        public int ServiceId { get; set; }

        //Validation for service name
        [Required(ErrorMessage = "Please enter the service name")]
        [RegularExpression("[A-Z][a-z][^(@#&<>~;$^%{}?][^0-9]{0,35}", ErrorMessage = "Please enter the service name in correct format")]
        [Display(Name = "Service Name")]
        [MaxLength(20)]
        public string ServiceName { get; set; }

        //Validation for service category
        [Required]
        [Display(Name = "Service Category")]
        public int CategoryID { get; set; }

        //Validaton for the event type where the service is used
        [Required]
        [Display(Name = "Event Type")]
        public string EventType { get; set; }
    }
}