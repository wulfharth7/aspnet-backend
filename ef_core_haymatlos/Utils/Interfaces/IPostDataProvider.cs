using ef_core_haymatlos.Models;

namespace ef_core_haymatlos.Utils.Interfaces
{
    public interface IPostDataProvider
    {
        void AddPost(Post post);
        void RemovePost(string uuid);
        void UpdatePost(Post post);
        Post GetSinglePost(string uuid);
        List<Post> GetAllPosts();
    }
}
