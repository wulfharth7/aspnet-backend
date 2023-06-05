using haymatlos_backend.Models;

namespace haymatlos_backend.Services.userservices
{
    public interface IUserService
    {      
            Task<bool> CreateUser(UserModel User);
            Task<List<UserModel>> GetUserList();
            Task<UserModel> UpdateUser(UserModel User);
            Task<bool> DeleteUser(int key);
            Task<UserModel> GetUser(int id);
        }
}
