using haymatlos_backend.Models;
using Microsoft.AspNetCore.SignalR;

namespace haymatlos_backend.Hubs
{
    public class UserHub : Hub<IUserHub>
    {
      public async Task AddUser(UserModel user)
        {
            await Clients.All.AddUser(user);
        }
    }
}
