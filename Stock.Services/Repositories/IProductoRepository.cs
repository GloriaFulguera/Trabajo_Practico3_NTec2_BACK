using Stock.Models;
using Stock.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Services.Repositories
{
    public interface IProductoRepository
    {
        public Task<List<Producto>> GetProductos();
        public Task<bool> CreateProducto(Producto producto);
        public Task<bool> EditProducto(ProductoDTO producto);
        public Task<bool> DeleteProducto(string id);
    }
}
