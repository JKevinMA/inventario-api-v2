using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Models
{
    public class CategoriaModel
    {
        public int CategoriaId { get; set; }
        public string Descripcion { get; set; }
        public int EmpresaId { get; set; }
        public string Empresa { get; set; }
    }
}
