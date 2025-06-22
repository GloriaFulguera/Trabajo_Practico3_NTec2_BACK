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
            int newStock=0;

            if(Convert.ToInt32(movimiento.Cantidad)<1)
                return false;
            string query = "SELECT stock FROM productos WHERE id=" + movimiento.Producto_id;
            if (string.IsNullOrEmpty(query) || string.IsNullOrEmpty(movimiento.Tipo) || string.IsNullOrEmpty(movimiento.Cantidad) || string.IsNullOrEmpty(movimiento.Observacion))
            {
                return false;
            }

            if (movimiento.Tipo.ToUpper() == "ENTRADA")
            {
                newStock=Convert.ToInt32(SqliteHandler.GetScalar(query))+Convert.ToInt32(movimiento.Cantidad);
            }
            else if (movimiento.Tipo.ToUpper() == "SALIDA")
            {
                if(Convert.ToInt32(SqliteHandler.GetScalar(query))< Convert.ToInt32(movimiento.Cantidad))
                    return false;
                else
                    newStock = Convert.ToInt32(SqliteHandler.GetScalar(query)) - Convert.ToInt32(movimiento.Cantidad);
            }
            string update = $"UPDATE productos SET stock='{newStock}' WHERE id={movimiento.Producto_id}";

            if (!SqliteHandler.Exec(update))
                return false;

            string insert = $"INSERT INTO movimientos(id,producto_id,tipo,cantidad,fecha,observacion)" +
                $"VALUES (null,{movimiento.Producto_id},'{movimiento.Tipo}','{movimiento.Cantidad}','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}','{movimiento.Observacion}')";
            return SqliteHandler.Exec(insert);
        }
    }
}
