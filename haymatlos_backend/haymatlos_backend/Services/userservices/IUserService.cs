using haymatlos_backend.Models;
using System;

namespace haymatlos_backend.Services.userservices
{
    public interface IUserService
    {      
            Task<bool> CreateUser(UserModel User);
            Task<List<UserModel>> GetUserList();
            Task<UserModel> UpdateUser(string userId, UserModel User);
            Task<bool> DeleteUser(string uuid);
            Task<UserModel> GetUser(string uuid);
        }
}
