using inventario_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Repository.IRepository
{
    public interface ITomaInventarioRepository
    {
        public Result<ValidarInicioInventario> validarInicioInventario(int inventarioId, int usuarioId);
        public Result<List<TomaInventarioDetalle>> obtenerTomaInventario(int inventarioId, int usuarioId);
        public Result<int> guardaToma(TomaInventarioDetalle toma);
        public Result<int> cerrarToma(TomaInventarioCabecera toma);
        public Result<List<TomaInventarioCabecera>> cerrarYObtenerTomasUsuarioCabecera(int inventarioId);
        public Result<List<TomaInventarioDetalle>> obtenerTomaUsuarioDetalle(int tomaInventarioId);
    }
}
