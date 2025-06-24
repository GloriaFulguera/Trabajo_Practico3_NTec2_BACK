using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Models
{
    public class Login
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string Rol { get; set; }
        public string FechaAlta { get; set; }
        public string FechaUltLogin { get; set; }
        public string Estado { get; set; }
    }
}
