using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OnlineEventManagementSystem.Models
{
    public class LoginModel
    {
        //Validation for mail id
        [Required(ErrorMessage = "Please enter your email address")]
        [Display(Name = "User Mail Id")]
        public string UserMailId { get; set; }

        //Validation for password
        [Required(ErrorMessage = "Please enter your password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}