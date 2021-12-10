using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Models
{
    public class TomaInventarioCabecera
    {
        public int TomaInventarioId { get; set; }
        public bool Cerrado { get; set; }
        public int UsuarioId { get; set; }
        public int InventarioId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public List<TomaInventarioDetalle> Detalles { get; set; }

        //aux
        public string Usuario { get; set; }
        public string Nombre { get; set; }
    }
    public class TomaInventarioDetalle
    {
        public int TomaInventarioId { get; set; }
        public double Cantidad { get; set; }
        public bool Blanco { get; set; }
        public int ArticuloId { get; set; }

        //aux
        public string Articulo { get; set; }
        public string Categoria { get; set; }
        public string Familia { get; set; }
        public int CategoriaId { get; set; }
        public int FamiliaId { get; set; }
        public int Orden { get; set; }
        public string Localizacion { get; set; }

        public string UnidadMedida { get; set; }
        public string Codigo { get; set; }
    }

    public class ValidarInicioInventario
    {
        public int Total { get; set; }
        public bool Cerrado { get; set; }

    }
}
