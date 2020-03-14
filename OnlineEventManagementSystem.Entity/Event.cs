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

        public static string GenerateEventID(string eventName, string eventType)
        {
            string eventId = "E" + eventType[0] + eventName.Length + eventName.Substring(0, 4).ToUpper();
            return eventId;
        }
    }
}
