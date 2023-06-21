using ef_core_haymatlos.DbContext;
using ef_core_haymatlos.Models;
using ef_core_haymatlos.Utils.Interfaces;

namespace ef_core_haymatlos.Utils.DataProviders
{
    public class UserDataProvider : IUserDataProvider
    {
        private readonly PostgresContext _context;
        public UserDataProvider(PostgresContext context)
        {
            _context = context;
        }
        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public void RemoveUser(string uuid) 
        { 
            var entity = _context.Users.FirstOrDefault(x => x.Uuid == uuid);
            if(entity != null)
            {
                _context.Users.Remove(entity);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("The user you've tried to find doesn't exist.");
            }

        }
        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
        public User GetSingleUser(string uuid)
        {
            var entity = _context.Users.FirstOrDefault(x => x.Uuid == uuid);
            if (entity == null)
            {
                throw new Exception("The user you've tried to find doesn't exist.");
            }
            return entity;
        }
        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
    }
}
