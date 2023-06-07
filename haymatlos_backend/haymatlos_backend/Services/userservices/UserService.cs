using haymatlos_backend.Models;
using haymatlos_backend.Services.dbservices;
using Microsoft.AspNetCore.Identity;
using System;

namespace haymatlos_backend.Services.userservices
{
    public class UserService : IUserService
    {
        private readonly IdatabaseService _dbService;
        private readonly string _pepper;
        private string PasswordSalt;
        private readonly int _iteration = 3;

        public UserService(IdatabaseService dbService)
        {
            _dbService = dbService;
            _pepper = "IReallyLovePeppersAndTheChiliOnes.."; //Environment.GetEnvironmentVariable("PasswordHashExamplePepper"); for now because its a learning project im not using the env, but basically on PROD this should be used.
        }

        public async Task<bool> CreateUser(UserModel user)
        {
            user.Uuid = Guid.NewGuid().ToString();
            PasswordSalt = HashingPassword.GenerateSalt();
            user.Password = HashingPassword.ComputeHash(user.Password, PasswordSalt, _pepper, _iteration);

            var result =
                await _dbService.EditData(
                    "INSERT INTO public.user (nickname, password, uuid) VALUES (@Nickname, @Password, @Uuid)",
                    user);
            return true;
        }

        public async Task<List<UserModel>> GetUserList()
        {
            var userList = await _dbService.GetAll<UserModel>("SELECT * FROM public.user", new { });
            return userList;
        }


        public async Task<UserModel> GetUser(string uuid)
        {
            var userList = await _dbService.GetAsync<UserModel>("SELECT * FROM public.user where uuid=@Uuid", new { uuid });
            return userList;
        }

        public async Task<UserModel> UpdateUser(UserModel User)
        {
            var updateEmployee =
                await _dbService.EditData(
                    "UPDATE public.user SET name=@Nickname, password=@Password WHERE id=@Id",
                    User);
            return User;
        }

        public async Task<bool> DeleteUser(string uuid)
        {
            var deleteEmployee = await _dbService.EditData("DELETE FROM public.user WHERE uuid=@Uuid", new { uuid });
            return true;
        }
    }
}
