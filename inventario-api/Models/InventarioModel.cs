using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Models
{
    public class InventarioCabecera
    {
        public int InventarioId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; }
        public string ArchivoStock { get; set; }
        public int UsuarioId { get; set; }
        public int TipoInventarioId { get; set; }
        public int AreaId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaVisualizacion { get; set; }

        public List<InventarioDetalle> Detalles{ get; set; }

        // AUX

        public string TipoInventario { get; set; }
        public string Almacen { get; set; }
        public string Area { get; set; }


    }
    public class InventarioDetalle
    {
        public int InventarioId { get; set; }
        public int ArticuloId { get; set; }
        public int UsuarioIdValidado { get; set; }
        public double StockTeorico { get; set; }
        public double PrecioPromedio { get; set; }
        public double Cantidad { get; set; }
        public double Valor { get; set; }
        public double CantidadValidado { get; set; }
        public double ValorValidado { get; set; }
        public double Diferencia { get; set; }
        public double DiferenciaValor { get; set; }
        public bool Validado { get; set; }
        public bool Finalizado { get; set; }

        // aux
        public string Articulo { get; set; }
        public string Codigo { get; set; }
        public double AbsValDif{ get; set; }
        public double Faltante { get; set; }
        public string UnidadMedida { get; set; }

    }
}
