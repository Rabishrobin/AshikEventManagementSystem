using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OnlineEventManagementSystem.Models
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = "Please enter your email address")]
        [Display(Name = "Username")]
        public string UserMailId { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public SignInViewModel()
        {

        }
    }
}