using inventario_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Repository.IRepository
{
    public interface IUnidadMedidaRepository
    {
        public Result<List<UnidadMedidaModel>> obtenerUnidadesMedidaMTM();
        public Result<int> crearUnidadMedidaMTM(UnidadMedidaModel o);
        public Result<int> actualizarUnidadMedidaMTM(UnidadMedidaModel o);
        public Result<int> eliminarUnidadMedidaMTM(int id);
    }
}
