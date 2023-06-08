using haymatlos_backend.Models;
using Microsoft.AspNetCore.SignalR;

namespace haymatlos_backend.Hubs
{
    public class PostHub : Hub
    {
        public async Task showRelatedPosts(List<PostModel> posts_)
        {
            await Clients.All.SendAsync("showRelatedPosts", posts_);
        }
    }
}
