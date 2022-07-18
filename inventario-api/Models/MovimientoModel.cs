using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Models
{
    public class MovimientoCabecera
    {
        public int MovimientoId { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoMovimiento { get; set; }
        public int AreaId { get; set; }
        public string Estado { get; set; }

        public List<MovimientoDetalle> Detalles { get; set; }
    }
    public class MovimientoDetalle
    {
        public int MovimientoId { get; set; }
        public int ArticuloId { get; set; }
        public string Codigo { get; set; }
        public string Articulo { get; set; }
        public string UnidadMedida { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

    }
}
