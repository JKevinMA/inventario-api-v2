using inventario_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Repository.IRepository
{
    public interface ITipoInventarioRepository
    {
        public Result<List<TipoInventarioModel>> obtenerTiposInventario();

        public Result<List<TipoInventarioModel>> obtenerTiposInventarioMTM();
        public Result<int> crearTipoInventarioMTM(TipoInventarioModel o);
        public Result<int> actualizarTipoInventarioMTM(TipoInventarioModel o);
        public Result<int> eliminarTipoInventarioMTM(int id);
        
    }
}
