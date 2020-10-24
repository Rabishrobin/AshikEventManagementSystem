using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineEventManagementSystem.Entity
{
    public class Package
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("Package Id")]
        public int PackageID { get; set; }

        [Required]
        [Column("Package Name")]
        [MaxLength(20)]
        public string PackageName { get; set; }

        [Required]
        [Column("Package Type")]
        [MaxLength(20)]
        public string PackageType { get; set; }

        public int EventID { get; set; }

        public Event Event { get; set; }

        public int SerivceID { get; set; }

        public Service Service { get; set; }
    }
}
