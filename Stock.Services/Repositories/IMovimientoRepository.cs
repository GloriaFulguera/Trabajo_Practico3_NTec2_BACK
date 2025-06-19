using Stock.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Services.Repositories
{
    public interface IMovimientoRepository
    {
        public Task<List<MovimientoDTO>> GetMovimientos();
        public Task<bool> CreateMovimiento(MovimientoCreateDTO movimiento);
    }
}
