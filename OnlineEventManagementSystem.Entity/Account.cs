using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEventManagementSystem.Entity
{
    public class Account
    {
        [Key]
        [Column("User Id")]
        public string UserID { get; set; }

        [Required]
        [Column("Mail Id")]
        public string UserMailId { get; set; }

        [Required]
        [Column("Password")]
        public string UserPassword { get; set; }

        [Required]
        [Column("First Name")]
        public string UserFirstName { get; set; }

        [Required]
        [Column("Last Name")]
        public string UserLastName { get; set; }

        [Required]
        [Column("Mobile Number")]
        public long UserMobileNumber { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime UserDOB { get; set; }


        [Required]
        [Column("Gender")]
        public string UserGender { get; set; }
        public void Signup()
        {

        }

        public string GenerateUserID(string name, long mobileNumber)
        {
            string UserId = "C" + name.Substring(0, 3).ToUpper() + mobileNumber.ToString().Substring(0, 4);
            return UserId;
        }
    }
}
