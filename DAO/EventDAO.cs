using BusinessObjects.Models;

namespace DAO
{
    public class EventDAO
    {
        private EventManagementDBContext _context;
        private static EventDAO instance;

        public static EventDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EventDAO();
                }
                return instance;
            }
        }

        public EventDAO()
        {
            _context = new EventManagementDBContext();
        }

        public List<Event> GetAllEvents()
        {
            try
            {
                return _context.Events.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving events: {ex.Message}");
                return new List<Event>(); 
            }
        }

        public Event GetEventById(int EventId)
        {
            try
            {
                return _context.Events.Find(EventId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving Event with ID {EventId}: {ex.Message}");
                return null; 
            }
        }

        public void AddEvent(Event cls)
        {
            try
            {
                _context.Events.Add(cls);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding Event: {ex.Message}");
            }
        }

        public void UpdateEvent(Event cls)
        {
            try
            {
                _context.Events.Update(cls);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating Event: {ex.Message}");
            }
        }

        public void DeleteEvent(int EventId)
        {
            try
            {
                var cls = _context.Events.Find(EventId);
                if (cls != null)
                {
                    _context.Events.Remove(cls);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting Event with ID {EventId}: {ex.Message}");
            }
        }
    }
}
