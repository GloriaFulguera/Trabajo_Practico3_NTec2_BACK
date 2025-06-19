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
    public class MovimientoService:IMovimientoRepository
    {
        public async Task<List<MovimientoDTO>> GetMovimientos()
        {
            string query = "SELECT * FROM movimientos";
            string json=SqliteHandler.GetJson(query);

            string select = "SELECT id,nombre FROM productos";
            string res = SqliteHandler.GetJson(select);

            List<Producto> productos = JsonConvert.DeserializeObject<List<Producto>>(res);
            var productosDict = productos.ToDictionary(p => p.Id, p => p.Nombre);


            List<Movimiento> list=JsonConvert.DeserializeObject<List<Movimiento>>(json);
            List<MovimientoDTO> movimientos = list.Select(m => new MovimientoDTO
            {
                Id = m.Id,
                Producto = productosDict.ContainsKey(m.Producto_id) ? productosDict[m.Producto_id] : "Desconocido",
                Tipo = m.Tipo,
                Cantidad = m.Cantidad,
                Fecha = m.Fecha,
                Observacion = m.Observacion
            }).ToList();
            return movimientos;
        }
        public async Task<bool> CreateMovimiento(MovimientoCreateDTO movimiento)
        {
            string select = "SELECT id FROM productos WHERE id=" + movimiento.Producto_id;
            string existe = SqliteHandler.GetScalar(select);
            if (string.IsNullOrEmpty(existe) || string.IsNullOrEmpty(movimiento.Tipo) || string.IsNullOrEmpty(movimiento.Cantidad)||string.IsNullOrEmpty(movimiento.Observacion))
            {
                return false;
            }
            string query = $"INSERT INTO movimientos(id,producto_id,tipo,cantidad,fecha,observacion)" +
                $"VALUES (null,{movimiento.Producto_id},'{movimiento.Tipo}','{movimiento.Cantidad}','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}','{movimiento.Observacion}')";
            return SqliteHandler.Exec(query);
        }
    }
}
