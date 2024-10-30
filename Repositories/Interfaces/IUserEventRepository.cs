

using BusinessObjects.Models;

namespace Repositories.Interfaces
{
    public interface IUserEventRepository
    {
        List<UserEvent> GetAllUserEvents();
        UserEvent GetUserEventById(int userEventId);
        UserEvent GetUserEventByUserIdAndEventId(int userId, int eventId);
        void AddUserEvent(UserEvent userEvent);
        void UpdateUserEvent(UserEvent userEvent);
        void DeleteUserEvent(int userEventId);
        
    }
}
