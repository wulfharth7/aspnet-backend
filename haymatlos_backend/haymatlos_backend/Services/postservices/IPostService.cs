using haymatlos_backend.Models;

namespace haymatlos_backend.Services.postservices
{
    public interface IPostService
    {
        Task<bool> CreatePost(PostModel post);
        Task<List<PostModel>> GetPostList();
//      Task<PostModel> UpdatePost(PostModel Post);
        Task<bool> DeletePost(string uuid);
        Task<PostModel> GetPost(string uuid);
    }
}
