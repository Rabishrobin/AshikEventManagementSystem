using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineEventManagementSystem.Entity
{
    public class Service
    {
        [Key]
        [Required]
        [Column("Service Id")]
        public string ServiceID { get; set; }

        [Required]
        [Column("Service Name")]
        [MaxLength(20)]
        public string ServiceName { get; set; }

        [Required]
        [Column("Service Type")]
        [MaxLength(20)]
        public string ServiceCategory { get; set; }

        public static string GenerateServiceID(string serviceName)
        {
            string eventId = "S" + DateTime.Now.ToString("dd/mm/yyyy").Substring(3, 2) + serviceName.Substring(0, 4).ToUpper() + DateTime.Now.Year.ToString().Substring(2, 2);
            return eventId;
        }
    }
}
