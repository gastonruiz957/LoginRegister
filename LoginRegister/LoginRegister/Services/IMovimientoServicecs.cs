using LoginRegister.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegister.Services
{
    public interface IMovimientoService
    {
        Task<bool> AddMovimientoAsync(MovimientoModel movimiento);

        Task<bool> UpdateMovimientoAsync(MovimientoModel movimientoModel);
        Task<bool> DeleteMovimientoAsync(int id);
        Task<MovimientoModel> GetMovimientoAsync(int id);
        Task<IEnumerable<MovimientoModel>> GetMovimientoAsync();
    }
}
