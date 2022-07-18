using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Models
{
    public class IngresoSalidaConsolidada
    {
        public string Codigo { get; set; }
        public string Articulo { get; set; }
        public string UnidadMedida { get; set; }
        public int StockInicial { get; set; }
        public double Ingreso { get; set; }
        public double Salida { get; set; }
        public int Inventario { get; set; }
    }
}
