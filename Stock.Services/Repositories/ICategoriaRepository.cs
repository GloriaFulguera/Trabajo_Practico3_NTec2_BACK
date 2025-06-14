using Stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Services.Repositories
{
    public interface ICategoriaRepository
    {
        public Task<List<Categoria>> GetCategorias();
    }
}
