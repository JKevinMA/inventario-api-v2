using inventario_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Repository.IRepository
{
    public interface IArticuloTipoInventarioRepository
    {
        public Result<List<ArticuloTipoInventarioModel>> obtenerArticulosTipoInventarioMTM();


        public Result<int> crearArticuloTipoInventarioMTM(ArticuloTipoInventarioModel o);


        public Result<int> actualizarArticuloTipoInventarioMTM(ArticuloTipoInventarioModel o);


        public Result<int> eliminarArticuloTipoInventarioMTM(int articuloId, int areaId, int tipoInventarioId);
       
    }
}
