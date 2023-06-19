using ef_core_haymatlos.Models;

namespace ef_core_haymatlos.Utils.Interfaces
{
    public interface IUserDataProvider
    {
        void AddUser(User user);
        void RemoveUser(string uuid);
        void UpdateUser(User user);
        User GetSingleUser(string uuid);
        List<User> GetAllUsers();
    }
}
