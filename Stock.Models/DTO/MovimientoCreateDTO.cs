using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Models.DTO
{
    public class MovimientoCreateDTO
    {
        public int Producto_id { get; set; }
        public string Tipo { get; set; }
        public string Cantidad { get; set; }
        public string Observacion { get; set; }
    }
}