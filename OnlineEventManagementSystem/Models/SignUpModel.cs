using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineEventManagementSystem.Models
{
    public class SignUpModel
    {
        public string UserID { get; set; }

        //Validation for mail id
        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [MaxLength(64)]
        [Display(Name ="Mail Id")]
        public string UserMailId { get; set; }

        //validation for password
        [Required(ErrorMessage = "Please enter your password")]
        [RegularExpression("((?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()]).{6,15})", ErrorMessage = "Password must be at least 8 characters long, contain at least one number and have a mixture of uppercase and lowercase letters.")]
        [MaxLength(15)]
        [MinLength(6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string UserPassword { get; set; }

        //validation for confirming password
        [Required(ErrorMessage = "Please Re-enter your password")]
        [Display(Name = "Confirm Password")]
        [Compare("UserPassword", ErrorMessage = "Those password didn't match, Try again ")]
        public string ReenteredPassword { get; set; }

        //Validation for first name
        [Required(ErrorMessage = "Please enter your first name")]
        [MaxLength(35)]
        [RegularExpression("[A-Z][a-z][^(@#&<>~;$^%{}?][^0-9]{0,35}", ErrorMessage = "Please enter a valid first name")]
        [Display(Name = "First Name")]
        public string UserFirstName { get; set; }

        //Validation for last name
        [Required(ErrorMessage = "Please enter your last name")]
        [MaxLength(35)]
        [Display(Name = "Last Name")]
        public string UserLastName { get; set; }

        //Validation for mobile number
        [Required(ErrorMessage = "Please enter your mobile number")]
        [RegularExpression("^[6-9][0-9]{9}$", ErrorMessage = "Please enter a valid mobile number")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Please enter a valid mobile number")]
        [Display(Name = "Mobile Number")]
        public long UserMobileNumber { get; set; }

        //Validation for date of birth
        [Required(ErrorMessage = "Please enter your DOB")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime UserDOB { get; set; }

        //Validation for gender
        [Required(ErrorMessage = "Please select your gender")]
        [Display(Name = "Gender")]
        public string UserGender { get; set; }

    }
}