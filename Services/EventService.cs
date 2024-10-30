using Repositories.Interfaces;
using Repositories;
using Services.Interfaces;
using BusinessObjects.Models;

namespace Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository eventRepository;

        public EventService()
        {
            this.eventRepository = new EventRepository();
        }

        public void AddEvent(Event cls) => eventRepository.AddEvent(cls);
        public void DeleteEvent(int EventId) => eventRepository.DeleteEvent(EventId);
        public List<Event> GetAllEvents() => eventRepository.GetAllEvents();
        public Event GetEventById(int EventId) => eventRepository.GetEventById(EventId);
        public void UpdateEvent(Event cls) => eventRepository.UpdateEvent(cls);

    }
}
