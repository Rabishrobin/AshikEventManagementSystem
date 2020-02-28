using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEventManagementSystem.Entity
{
    public class UserManager
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

        //[Required]
        //[Display(Name = "Date of Birth")]
        //public DateTime UserDOB { get; set; }Migration Column


        [Required]
        [Column("Gender")]
        public string UserGender { get; set; }
        public void Signup()
        {

        }
        public void Login(string mailId, string password)
        {

        }
        //public bool VerifyMailId(string mailId)
        //{
        //    bool isExist = true;
        //    foreach (var User in UserDatabase)
        //    {
        //        if (User.UserMailId.Equals(mailId))
        //        {
        //            return false;
        //        }
        //    }
        //    return isExist;
        //}
        //public bool ValidateAccount(string mailId, string password)
        //{
        //    bool isMatched = false;
        //    foreach (var User in UserDatabase)
        //    {
        //        if (User.UserMailId.Equals(mailId) && User.UserPassword.Equals(password))
        //        {
        //            isMatched = true;
        //            break;
        //        }
        //    }
        //    return isMatched;
        //}
        public string GenerateUserID(string name, long mobileNumber)
        {
            string UserId = "C" + name.Substring(0, 3).ToUpper() + mobileNumber.ToString().Substring(0, 4);
            return UserId;
        }
    }
}
