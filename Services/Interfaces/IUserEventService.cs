
using BusinessObjects.Models;

namespace Services.Interfaces
{
    public interface IUserEventService
    {
        List<UserEvent> GetAllUserEvents();
        UserEvent GetUserEventById(int userClassId);
        UserEvent GetUserEventByUserIdAndEventId(int userId, int classId);
        void AddUserEvent(UserEvent userClass);
        void UpdateUserEvent(UserEvent userClass);
        void DeleteUserEvent(int userClassId);
    }
}
