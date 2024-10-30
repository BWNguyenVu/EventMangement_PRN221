using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Event
    {
        public Event()
        {
            UserEvents = new HashSet<UserEvent>();
        }

        public int EventId { get; set; }
        public string EventName { get; set; } = null!;
        public string Location { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public string? ImageUrl { get; set; }

        public virtual ICollection<UserEvent> UserEvents { get; set; }
    }
}
