
using LoginRegister.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegister.Services
{
    public interface IUserService
    {
        Task<bool> AddUserAsync(UserModel userModel);
        Task<bool> UpdateUserAsync(UserModel userModel);
        Task<bool> DeleteUserAsync(int id);
        Task<UserModel> GetUserAsync(int id);
        Task<IEnumerable<UserModel>> GetUserAsync();
        Task <bool>Login(string userName, string password);

    }
}
