using Stock.Models;
using Stock.Models.DTO;
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
        public Task<bool> CreateCategoria(CategoriaDTO categoria);
        public Task<bool> EditCategoria(Categoria categoria);
        public Task<bool> DeleteCategoria(string id);
    }
}
