using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Models
{
    public class UnidadMedidaModel
    {
        public int UnidadMedidaId { get; set; }
        public string Descripcion { get; set; }
        public string CodigoSunat { get; set; }
    }
}
