using Microsoft.AspNetCore.Mvc;
using Stock.Models;
using Stock.Models.DTO;
using Stock.Services.Repositories;

namespace Stock.Api.Controllers
{
    [Route("api/productos")]
    [ApiController]
    public class ProductoController:ControllerBase
    {
        private readonly IProductoRepository _productoService;

        public ProductoController(IProductoRepository productoService)
        {
            _productoService = productoService;
        }
        [HttpGet("GetProductos")]
        public async Task<List<Producto>> GetProductos()
        {
            return await Task.Run(()=>_productoService.GetProductos());
        }
        [HttpGet("GetProductosPorCategoria")]
        public async Task<List<Producto>> GetProductosPorCategoria(string id)
        {
            return await Task.Run(() => _productoService.GetProductosPorCategoria(id));
        }
        [HttpPost("CreateProducto")]
        public async Task<bool> CreateProducto(Producto producto)
        {
            return await Task.Run(() => _productoService.CreateProducto(producto));
        }
        [HttpPut("EditProducto")]
        public async Task<bool> EditProducto(ProductoDTO producto)
        {
            return await Task.Run(() => _productoService.EditProducto(producto));
        }
        [HttpDelete("DeleteProducto")]
        public async Task<bool> DeleteProducto(string id)
        {
            return await Task.Run(()=>_productoService.DeleteProducto(id));
        }
    }
}
