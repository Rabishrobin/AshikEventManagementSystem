using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineEventManagementSystem.Models
{
    public class ServiceCategoryModel
    {
        public int CategoryId { get; set; }

        //Validation for service category
        [Required(ErrorMessage = "Please enter the service category")]
        [RegularExpression("[A-Z][a-z][^(@#&<>~;$^%{}?][^0-9]{0,35}", ErrorMessage = "Please enter a valid service category")]
        [Display(Name = "Service Category")]
        [MaxLength(20)]
        public string CategoryName { get; set; }
    }
}