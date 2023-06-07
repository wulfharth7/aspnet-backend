using haymatlos_backend.Models;

namespace haymatlos_backend.Hubs
{
    public interface IUserHub
    {
        Task ShowAllUserswithSignalR(List<UserModel>? users);
    }
}
