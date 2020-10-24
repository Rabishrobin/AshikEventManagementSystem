using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineEventManagementSystem.Entity
{
    public class ServiceCategory
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("Category Id")]
        public int CategoryID { get; set; }

        [Required]
        [MaxLength(30)]
        [Column("Category Name")]
        public string CategoryName { get; set; }

        public ICollection<Service> Services { get; set; }

    }
}
