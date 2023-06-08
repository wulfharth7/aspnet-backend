using haymatlos_backend.Models;
using haymatlos_backend.Services.dbservices;
using System;

namespace haymatlos_backend.Services.postservices
{
    public class PostService : IPostService
    {
        private readonly IdatabaseService databaseService_;

        public PostService(IdatabaseService dbService)
        {
            databaseService_ = dbService;
        }

        public async Task<bool> CreatePost(PostModel post)
        {
            post.Uuid = Guid.NewGuid().ToString();
            var result =
                 await databaseService_.EditData(
                     "INSERT INTO public.posts (owner, title, text , image , uuid) VALUES (@Owner, @Title, @Text, @Image, @Uuid)",
                     post);
            return true;

        }

        public async Task<List<PostModel>> GetPostList()
        {
            var postList = await databaseService_.GetAll<PostModel>("SELECT * FROM public.posts", new { });
            return postList;
        }

        public async Task<bool> DeletePost(string uuid)
        {
            var deleteEmployee = await databaseService_.EditData("DELETE FROM public.posts WHERE uuid=@Uuid", new { uuid });
            return true;
        }

        public async Task<PostModel> GetPost(string uuid)
        {
            var postList = await databaseService_.GetAsync<PostModel>("SELECT * FROM public.posts where uuid=@Uuid", new { uuid });
            return postList;
        }

        public async Task<PostModel> GetPostOfOwner(string OwnerUuid)
        {
            var postList = await databaseService_.GetAsync<PostModel>("SELECT * FROM public.posts where owner=@Uuid", new { OwnerUuid });
            return postList;
        }

    }
}
