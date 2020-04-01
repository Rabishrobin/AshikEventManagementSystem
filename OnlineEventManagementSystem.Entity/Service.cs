using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineEventManagementSystem.Entity
{
    public class Service
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("Service Id")]
        public int ServiceID { get; set; }

        [Required]
        [Column("Service Name")]
        [MaxLength(20)]
        public string ServiceName { get; set; }

        [Required]
        [Column("Event Type")]
        [MaxLength(20)]
        public string EventType { get; set; }

        public int CategoryID { get; set; }
        public ServiceCategory Category { get; set; }

        public static int GenerateServiceID(int id)
        {
            return int.Parse((int)'S' + DateTime.Now.Year.ToString().Substring(2, 2) + id.ToString().PadLeft(3, '0'));
        }
    }
}
