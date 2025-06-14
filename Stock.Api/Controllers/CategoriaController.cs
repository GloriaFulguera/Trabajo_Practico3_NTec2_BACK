using Microsoft.AspNetCore.Mvc;
using Stock.Models;
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
    }
}
