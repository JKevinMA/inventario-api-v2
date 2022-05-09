using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Models
{
    public class FamiliaModel
    {
        public int FamiliaId { get; set; }
        public string Descripcion { get; set; }
        public int EmpresaId { get; set; }
        public string Empresa { get; set; }
        public string Codigo { get; set; }
    }
}
