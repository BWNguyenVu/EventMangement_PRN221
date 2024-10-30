using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;


namespace DAO
{
    public class UserEventDAO
    {
        private EventManagementDBContext _context;
        private static UserEventDAO instance;

        public static UserEventDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserEventDAO();
                }
                return instance;
            }
        }

        public UserEventDAO()
        {
            _context = new EventManagementDBContext();
        }

        public List<UserEvent> GetAllUserEvents()
        {
            try
            {
                return _context.UserEvents
                    .Include(u => u.User)
                    .Include(cls => cls.Event)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<UserEvent>();
            }
        }

        public UserEvent GetUserEventById(int UserEventId)
        {
            try
            {
                return _context.UserEvents.Find(UserEventId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        public UserEvent GetUserEventByUserIdAndEventId(int userId, int eventId)
        {
            try
            {
                return _context.UserEvents
                    .Include(u => u.User)
                    .Include(cls => cls.Event)
                    .Where(uc => uc.UserId == userId && uc.EventId == eventId)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        public void AddUserEvent(UserEvent UserEvent)
        {
            try
            {
                _context.UserEvents.Add(UserEvent);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void UpdateUserEvent(UserEvent UserEvent)
        {
            try
            {
                _context.UserEvents.Update(UserEvent);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void DeleteUserEvent(int UserEventId)
        {
            try
            {
                var UserEvent = _context.UserEvents.Find(UserEventId);
                if (UserEvent != null)
                {
                    _context.UserEvents.Remove(UserEvent);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
