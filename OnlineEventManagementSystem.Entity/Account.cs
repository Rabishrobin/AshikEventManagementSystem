using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineEventManagementSystem.Entity
{
    public class Account
    {
        [Key]
        [Column("User Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }

        [Required]
        [Column("Mail Id")]
        [MaxLength(64)]
        [Index(IsUnique=true)]
        public string UserMailId { get; set; }

        [Required]
        [Column("Password")]
        [MaxLength(15)]
        public string UserPassword { get; set; }

        [Required]
        [Column("First Name")]
        [MaxLength(35)]
        public string UserFirstName { get; set; }

        [Required]
        [Column("Last Name")]
        [MaxLength(35)]
        public string UserLastName { get; set; }

        [Required]
        [Column("Mobile Number")]
        public long UserMobileNumber { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [Column("Date of Birth")]
        public DateTime UserDOB { get; set; }


        [Required]
        [Column("Gender")]
        [MaxLength(10)]
        public string UserGender { get; set; }

        [Required]
        [Column("Roles")]
        [MaxLength(10)]
        public string Roles { get; set; }

        public static int GenerateUserID(int id)
        {
            return int.Parse((int)'C'+ DateTime.Now.Year.ToString().Substring(2,2)+id.ToString().PadLeft(3,'0'));
        }
    }
}
