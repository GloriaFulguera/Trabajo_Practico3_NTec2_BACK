using Microsoft.AspNetCore.Mvc;
using Stock.Models.DTO;
using Stock.Services.Repositories;

namespace Stock.Api.Controllers
{
    [Route("api/movimientos")]
    [ApiController]
    public class MovimientoController:ControllerBase
    {
        private readonly IMovimientoRepository _movimientoService;

        public MovimientoController(IMovimientoRepository movimientoService)
        {
            _movimientoService = movimientoService;
        }
        [HttpGet("GetMovimientos")]
        public async Task<List<MovimientoDTO>> GetMovimientos()
        {
            return await Task.Run(()=>_movimientoService.GetMovimientos());
        }
        [HttpPost("CreateMovimiento")]
        public async Task<bool> CreateMovimiento(MovimientoCreateDTO movimiento)
        {
            return await Task.Run(() => _movimientoService.CreateMovimiento(movimiento));
        }
    }
}
