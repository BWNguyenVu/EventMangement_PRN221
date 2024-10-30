using BusinessObjects.Models;
using DAO;
using Repositories.Interfaces;


namespace Repositories
{
    public class EventRepository : IEventRepository
    {
        public List<Event> GetAllEvents() => EventDAO.Instance.GetAllEvents();
        public Event GetEventById(int EventId) => EventDAO.Instance.GetEventById(EventId);
        public void AddEvent(Event cls) => EventDAO.Instance.AddEvent(cls);
        public void UpdateEvent(Event cls) => EventDAO.Instance.UpdateEvent(cls);
        public void DeleteEvent(int EventId) => EventDAO.Instance.DeleteEvent(EventId);
    }
}