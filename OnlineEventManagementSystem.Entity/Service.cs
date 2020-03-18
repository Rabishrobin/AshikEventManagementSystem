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
        [Column("Service Category")]
        [MaxLength(20)]
        public string ServiceCategory { get; set; }

        [Required]
        [Column("Event Type")]
        [MaxLength(20)]
        public string EventType { get; set; }

        public static string GenerateServiceID(string serviceName, string serviceCategory)
        {
            string eventId = "E" + serviceCategory[0] + serviceName.Length + serviceName.Substring(0, 4).ToUpper();     //Generating service id
            return eventId;
        }
    }
}
