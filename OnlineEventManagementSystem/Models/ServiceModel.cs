using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineEventManagementSystem.Models
{
    public class ServiceModel
    {
        public string ServiceId { get; set; }

        [Required(ErrorMessage = "Please enter the service name")]
        [RegularExpression("[A-Z][a-z][^(@#&<>~;$^%{}?][^0-9]{0,35}", ErrorMessage = "Please enter the service name in correct format")]
        [Display(Name = "Service Name")]
        [MaxLength(20)]
        public string ServiceName { get; set; }

        [Required]
        [Display(Name = "Service Category")]
        public string ServiceCategory { get; set; }
    }
}