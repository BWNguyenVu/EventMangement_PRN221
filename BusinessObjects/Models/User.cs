using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class User
    {
        public User()
        {
            UserEvents = new HashSet<UserEvent>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int RoleId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Password { get; set; } = null!;

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<UserEvent> UserEvents { get; set; }
    }
}
