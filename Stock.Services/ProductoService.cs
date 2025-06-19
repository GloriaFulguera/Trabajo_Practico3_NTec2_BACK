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
    public class ProductoService:IProductoRepository
    {
        public async Task<List<Producto>> GetProductos()
        {
            string query = "SELECT * FROM productos";
            string json=SqliteHandler.GetJson(query);
            
            List<Producto> productos=JsonConvert.DeserializeObject<List<Producto>>(json);
            return productos;
        }
        public async Task<bool> CreateProducto(Producto prod)
        {
            string query = $"INSERT INTO productos(id,nombre,descripcion,stock,precio,categoria_id)" +
                $"VALUES (null,'{prod.Nombre}','{prod.Descripcion}','{prod.Stock}','{prod.Precio}',{prod.Categoria_id})";
            return SqliteHandler.Exec(query);
        }
        public async Task<bool> EditProducto(ProductoDTO prod)
        {
            string query = $"UPDATE productos SET stock='{prod.Stock}',precio='{prod.Precio}' WHERE id={prod.Id}";
            return SqliteHandler.Exec(query);
        }
        public async Task<bool> DeleteProducto(string id)
        {
            string query = $"DELETE FROM productos WHERE id={id}";
            return SqliteHandler.Exec(query);
        }
    }
}
