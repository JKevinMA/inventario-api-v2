using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Models
{
    public class ArticuloTipoInventarioModel
    {
        public int ArticuloId { get; set; }
        public int TipoInventarioId { get; set; }
        public int AreaId { get; set; }
        public int Orden { get; set; }
        public string Localizacion { get; set; }

        public string Articulo { get; set; }
        public string Codigo { get; set; }
        public string TipoInventario { get; set; }
        public string Area { get; set; }
        public int AlmacenId { get; set; }
        public string Almacen { get; set; }
        public int LocalId { get; set; }
        public string Local { get; set; }
        public int EmpresaId { get; set; }
        public string Empresa { get; set; }
        public bool Habilitado { get; set; }

    }
}
