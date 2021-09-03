using LoginRegister.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegister.Services
{
    public class MovimientoService : IMovimientoService
    {
        public SQLiteAsyncConnection _database;
        public string StatusMessage { get; set; } //agregado al ultimo

        public MovimientoService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<MovimientoModel>();
        }


        //Insert y Update
        public async Task<bool> AddMovimientoAsync(MovimientoModel movimientoModel)
        {
            if (movimientoModel.Id > 0)
            {
                await _database.UpdateAsync(movimientoModel);
            }
            else
            {
                try
                {
                    string fechaActual = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    movimientoModel.FechaCarga = fechaActual;
                    Console.WriteLine("Fecha actual " + movimientoModel.FechaCarga);
                    await _database.InsertAsync(movimientoModel);
                    StatusMessage = string.Format($"Registro agregado"); //agregadi ak ultimo
                }
                catch (Exception ex)
                {
                    StatusMessage = $"Error:{ex.Message}";
                }
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteMovimientoAsync(int id)
        {
            await _database.DeleteAsync<MovimientoModel>(id);
            return await Task.FromResult(true);
        }

        public Task<bool> UpdateMovimientoAsync(MovimientoModel movimientoModel)
        {
            throw new NotImplementedException();
        }

        public async Task<MovimientoModel> GetMovimientoAsync(int id)
        {
            return await _database.Table<MovimientoModel>().Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<MovimientoModel>> GetMovimientoAsync()
        {
            return await Task.FromResult(await _database.Table<MovimientoModel>().ToListAsync());
        }



        //public bool login(string userName, string password)
        //{
        //    var myquery = _database.Table<UserModel>().Where(u => u.Usuario.Equals(userName) && u.Password.Equals(password)).FirstOrDefaultAsync();
        //    if (myquery != null)
        //    {
        //        App.Current.MainPage = new NavigationPage(new HomePage());
        //        return (true);
        //    }
        //    else
        //    {
        //        //Device.BeginInvokeOnMainThread(async () =>
        //        //{
        //        //    var result = await this.DisplayAlert("Error", "Clave o Contraseña Incorrecta", "Si", "Cancelar");

        //        //    if (result)
        //        //    {
        //        //        await App.Current.MainPage.Navigation.PushAsync(new HomePage());
        //        //    }
        //        //    else
        //        //    {
        //        //        await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
        //        //    }
        //        //});
        //        return (false);
        //    }
        //}
    }
}
