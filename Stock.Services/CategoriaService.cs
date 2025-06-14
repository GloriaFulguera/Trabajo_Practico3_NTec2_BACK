using Newtonsoft.Json;
using Stock.Models;
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
            string json=SqliteHandler.GetJson(query);
            List<Categoria> list=JsonConvert.DeserializeObject<List<Categoria>>(json);

            return list;
        }
    }
}
