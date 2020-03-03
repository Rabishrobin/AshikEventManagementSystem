using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineEventManagementSystem.Entity
{
    public class Event
    {
        [Key]
        [Required]
        [Column("Event Id")]
        public string EventId { get; set; }

        [Required]
        [Column("Event Name")]
        [MaxLength(20)]
        public string EventName { get; set; }

        [Required]
        [Column("Event Type")]
        [MaxLength(20)]
        public string EventType { get; set; }
    }
}
