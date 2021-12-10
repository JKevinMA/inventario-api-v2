using inventario_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Repository.IRepository
{
    public interface IInventarioRepository
    {
        public Result<int> aperturarInventario(List<InventarioCabecera> inventarios);
        public Result<List<AreaModel>> validarInventarioAbierto(List<InventarioCabecera> inventarios);
        public Result<List<InventarioCabecera>> obtenerInventariosAbiertos(int usuarioId, string estado);
        public Result<int> finalizarInventario(int inventarioId);
        public Result<List<InventarioDetalle>> obtenerInventarioDetalle(int inventarioId);
        public Result<int> validarCantidad(List<InventarioDetalle> inventarios);
    }
}
