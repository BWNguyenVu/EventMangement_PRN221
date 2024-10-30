using BusinessObjects.Models;
using DAO;
using Repositories.Interfaces;


namespace Repositories
{
    public class UserEventRepository : IUserEventRepository
    {
        public List<UserEvent> GetAllUserEvents() => UserEventDAO.Instance.GetAllUserEvents();
        public UserEvent GetUserEventById(int userClassId) => UserEventDAO.Instance.GetUserEventById(userClassId);
        public UserEvent GetUserEventByUserIdAndEventId(int userId, int classId) => UserEventDAO.Instance.GetUserEventByUserIdAndEventId(userId, classId);
        public void AddUserEvent(UserEvent userClass) => UserEventDAO.Instance.AddUserEvent(userClass);
        public void UpdateUserEvent(UserEvent userClass) => UserEventDAO.Instance.UpdateUserEvent(userClass);
        public void DeleteUserEvent(int userClassId) => UserEventDAO.Instance.DeleteUserEvent(userClassId);
    }
}
