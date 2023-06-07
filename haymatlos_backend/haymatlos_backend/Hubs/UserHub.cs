using haymatlos_backend.Models;
using haymatlos_backend.Services.userservices;
using Microsoft.AspNetCore.SignalR;

namespace haymatlos_backend.Hubs
{
    public class UserHub : Hub
    {
        private readonly IUserService userService;
        public UserHub(IUserService userService)
        {
            this.userService = userService;
        }
        public async Task ShowAllUserswithSignalR(List<UserModel> users_)
        {
            await Clients.All.SendAsync("ShowAllUserswithSignalR", users_);
        }
    }
}
