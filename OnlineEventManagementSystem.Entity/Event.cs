using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineEventManagementSystem.Entity
{
    public class Event
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("Event Id")]
        public int EventId { get; set; }

        [Required]
        [Column("Event Name")]
        [MaxLength(20)]
        public string EventName { get; set; }

        [Required]
        [Column("Event Type")]
        [MaxLength(20)]
        public string EventType { get; set; }

        public static int GenerateEventID(int id)
        {
            return int.Parse((int)'E' + DateTime.Now.Year.ToString().Substring(2, 2) + id.ToString().PadLeft(3, '0'));
        }
    }
}
