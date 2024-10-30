
using BusinessObjects.Models;

namespace Services.Interfaces
{
    public interface IEventService
    {
        List<Event> GetAllEvents();
        Event GetEventById(int classId);
        void AddEvent(Event cls);
        void UpdateEvent(Event cls);
        void DeleteEvent(int classId);
    }
}
