using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Models
{
    public class UsuarioAreaModel
    {
        public int UsuarioId { get; set; }
        public int AreaId { get; set; }
        public string Area { get; set; }
        public int AlmacenId { get; set; }
        public string Almacen { get; set; }
        public int LocalId { get; set; }
        public string Local { get; set; }
        public int EmpresaId { get; set; }
        public string Empresa { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
    }
}
