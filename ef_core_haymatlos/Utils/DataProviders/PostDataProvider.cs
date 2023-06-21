using ef_core_haymatlos.Data;
using ef_core_haymatlos.Models;
using ef_core_haymatlos.Utils.Interfaces;

namespace ef_core_haymatlos.Utils.DataProviders
{
    public class PostDataProvider : IPostDataProvider
    {
        private readonly PostgresContext _context;
        public PostDataProvider(PostgresContext context)
        {
            _context = context;
        }
        public void AddPost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }
        public void RemovePost(string uuid)
        {
            var entity = _context.Posts.FirstOrDefault(x => x.Uuid == uuid);
            if (entity != null)
            {
                _context.Posts.Remove(entity);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("The post you've tried to find doesn't exist.");
            }

        }
        public void UpdatePost(Post post)
        {
            _context.Posts.Update(post);
            _context.SaveChanges();
        }
        public Post GetSinglePost(string uuid)
        {
            var entity = _context.Posts.FirstOrDefault(x => x.Uuid == uuid);
            Console.WriteLine(entity);
            if (entity == null)
            {
                throw new Exception("The post you've tried to find doesn't exist.");
            }
            return entity;
        }
        public List<Post> GetAllPosts()
        {
            Console.WriteLine("eee");
            return _context.Posts.ToList();
        }
    }
}
