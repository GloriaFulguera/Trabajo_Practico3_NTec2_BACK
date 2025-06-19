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
        public async Task<List<Producto>> GetProductosPorCategoria(string id)
        {
            string query = "SELECT * FROM productos WHERE categoria_id="+id;
            string json=SqliteHandler.GetJson(query);
            
            List<Producto> productos = JsonConvert.DeserializeObject<List<Producto>>(json);
            return productos;
        }
        public async Task<bool> CreateProducto(Producto prod)
        {
            string select = "SELECT id FROM categorias WHERE id=" + prod.Categoria_id;
            string existe = SqliteHandler.GetScalar(select);
            if (string.IsNullOrEmpty(existe)||string.IsNullOrEmpty(prod.Nombre)||string.IsNullOrEmpty(prod.Stock)||string.IsNullOrEmpty(prod.Precio))
            {
                return false;
            }

            string query = $"INSERT INTO productos(id,nombre,descripcion,stock,precio,categoria_id)" +
                $"VALUES (null,'{prod.Nombre}','{prod.Descripcion}','{prod.Stock}','{prod.Precio}',{prod.Categoria_id})";
            return SqliteHandler.Exec(query);
        }
        public async Task<bool> EditProducto(ProductoDTO prod)
        {
            string select = "SELECT id FROM productos WHERE id=" + prod.Id;
            string existe = SqliteHandler.GetScalar(select);
            if (string.IsNullOrEmpty(existe) || string.IsNullOrEmpty(prod.Stock) || string.IsNullOrEmpty(prod.Precio))
            {
                return false;
            }
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
