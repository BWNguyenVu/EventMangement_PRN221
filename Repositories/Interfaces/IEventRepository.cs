using BusinessObjects.Models;


namespace Repositories.Interfaces
{
    public interface IEventRepository
    {
        List<Event> GetAllEvents();
        Event GetEventById(int eventId);
        void AddEvent(Event cls);
        void UpdateEvent(Event cls);
        void DeleteEvent(int eventId);
    }
}
