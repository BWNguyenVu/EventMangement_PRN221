using Repositories.Interfaces;
using Repositories;
using Services.Interfaces;
using BusinessObjects.Models;

namespace Services
{
    public class UserEventService : IUserEventService
    {
        private readonly IUserEventRepository userEventRepository;

        public UserEventService()
        {
            this.userEventRepository = new UserEventRepository();
        }

        public void AddUserEvent(UserEvent UserEvent) => userEventRepository.AddUserEvent(UserEvent);
        public void DeleteUserEvent(int UserEventId) => userEventRepository.DeleteUserEvent(UserEventId);
        public List<UserEvent> GetAllUserEvents() => userEventRepository.GetAllUserEvents();
        public UserEvent GetUserEventById(int UserEventId) => userEventRepository.GetUserEventById(UserEventId);
        public UserEvent GetUserEventByUserIdAndEventId(int userId, int classId) => userEventRepository.GetUserEventByUserIdAndEventId(userId, classId);
        public void UpdateUserEvent(UserEvent UserEvent) => userEventRepository.UpdateUserEvent(UserEvent);
    }
}