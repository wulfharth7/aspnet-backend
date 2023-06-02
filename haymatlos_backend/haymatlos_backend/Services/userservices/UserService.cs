using haymatlos_backend.Models;
using haymatlos_backend.Services.dbservices;

namespace haymatlos_backend.Services.userservices
{
    public class UserService : IUserService
    {
        private readonly IdatabaseService _dbService;

        public UserService(IdatabaseService dbService)
        {
            _dbService = dbService;
        }

        public async Task<bool> CreateUser(UserModel user)
        {
            var result =
                await _dbService.EditData(
                    "INSERT INTO public.user (id,nickname, password) VALUES (@id, @nickname, @password)",
                    user);
            return true;
        }

        public async Task<List<UserModel>> GetUserList()
        {
            var userList = await _dbService.GetAll<UserModel>("SELECT * FROM public.user", new { });
            return userList;
        }


       /* public async Task<UserModel> GetUser(int id)
        {
            var userList = await _dbService.GetAsync<UserModel>("SELECT * FROM public.user where id=@id", new { id });
            return userList;
        }*/

        public async Task<UserModel> UpdateUser(UserModel User)
        {
            var updateEmployee =
                await _dbService.EditData(
                    "UPDATE public.user SET name=@nickname, password=@password WHERE id=@id",
                    User);
            return User;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var deleteEmployee = await _dbService.EditData("DELETE FROM public.user WHERE id=@id", new { id });
            return true;
        }
    }
}
