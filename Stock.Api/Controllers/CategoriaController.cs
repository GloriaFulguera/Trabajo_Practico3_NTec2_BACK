using Microsoft.AspNetCore.Mvc;
using Stock.Models;
using Stock.Models.DTO;
using Stock.Services.Repositories;

namespace Stock.Api.Controllers
{
    [Route("api/categorias")]
    [ApiController]
    public class CategoriaController:ControllerBase
    {
        private readonly ICategoriaRepository _categoriaService;

        public CategoriaController(ICategoriaRepository categoriaService)
        {
            _categoriaService = categoriaService;
        }
        [HttpGet("GetCategorias")]
        public async Task<List<Categoria>> GetCategorias()
        {
            return await Task.Run(()=>_categoriaService.GetCategorias());
        }
        [HttpPost("CreateCategoria")]
        public async Task<bool> CreateCategoria(CategoriaDTO categoria)
        {
            return await Task.Run(() => _categoriaService.CreateCategoria(categoria));
        }
        [HttpPut("EditCategoria")]
        public async Task<bool> EditCategoria(Categoria categoria)
        {
            return await Task.Run(() => _categoriaService.EditCategoria(categoria));
        }
        [HttpDelete("DeleteCategoria")]
        public async Task<bool>DeleteCategoria(string id)
        {
            return await Task.Run(() => _categoriaService.DeleteCategoria(id));
        }
    }
}
