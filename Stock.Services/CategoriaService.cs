using Newtonsoft.Json;
using Stock.Models;
using Stock.Models.DTO;
using Stock.Services.Handlers;
using Stock.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Services
{
    public class CategoriaService : ICategoriaRepository
    {
        public async Task<List<Categoria>> GetCategorias()
        {
            string query = "SELECT * FROM categorias;";
            string json = SqliteHandler.GetJson(query);
            List<Categoria> list = JsonConvert.DeserializeObject<List<Categoria>>(json);

            return list;
        }
        public async Task<bool> CreateCategoria(CategoriaDTO categoria)
        {
            if (string.IsNullOrEmpty(categoria.Nombre))
            {
                return false;
            }
            string query = $"INSERT INTO categorias VALUES (null,'{categoria.Nombre}')";
            return SqliteHandler.Exec(query);
        }
        public async Task<bool> EditCategoria(Categoria categoria)
        {
            //TO DO: validar categoria con query
            if (string.IsNullOrEmpty(categoria.Nombre)||categoria.Id<1)
            {
                return false;
            }
            string query = $"UPDATE categorias SET nombre='{categoria.Nombre}' WHERE id={categoria.Id}";
            return SqliteHandler.Exec(query);
        }
        public async Task<bool> DeleteCategoria(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }
            string query = $"DELETE FROM categorias WHERE id={id}";
            return SqliteHandler.Exec(query);
        }
    }
}
