using LoginRegister.Models;
using LoginRegister.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LoginRegister.Services
{
    public class UserService : IUserService
    {
        public SQLiteAsyncConnection _database;
        public string StatusMessage { get; set; } //agregado al ultimo

        public UserService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<UserModel>().Wait();
        }

        //Insert y Update
        public async Task<bool> AddUserAsync(UserModel userModel)
        {
            if (userModel.UserId > 0)
            {
                string encryptpassword = Encrypt.GetSHA256(userModel.Password);
                userModel.Password = encryptpassword;
                await _database.UpdateAsync(userModel);
            }
            else
            {
                try
                {
                    string encryptpassword = Encrypt.GetSHA256(userModel.Password);
                    userModel.Password = encryptpassword;

                    await _database.InsertAsync(userModel);
                    StatusMessage = string.Format($"Registro agregado"); 
                }
                catch(Exception ex)
                {
                    StatusMessage = $"Error:{ex.Message}";
                }
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            await _database.DeleteAsync<UserModel>(id);
            return await Task.FromResult(true);
        }

        public Task<bool> UpdateUserAsync(UserModel userModel)
        {
            throw new NotImplementedException();
        }
        
        public async Task<UserModel> GetUserAsync(int id)
        {
            return await _database.Table<UserModel>().Where(p => p.UserId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<UserModel>> GetUserAsync()
        {
            return await Task.FromResult(await _database.Table<UserModel>().ToListAsync());
        }

        public async Task<bool>Login(string userName, string password)
        {
            string encryptpassword = Encrypt.GetSHA256(password);

            var myquery = await _database.Table<UserModel>().Where(u => u.Usuario.Equals(userName) && u.Password.Equals(encryptpassword)).FirstOrDefaultAsync();
            if (myquery != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<UserModel> GetUserByUserNameAsync(string userName)
        {
            return await _database.Table<UserModel>().Where(p => p.Usuario == userName).FirstOrDefaultAsync();
        }
    }
}