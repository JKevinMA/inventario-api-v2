using inventario_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Repository.IRepository
{
    public interface IArticuloRepository
    {
        public Result<List<ArticuloModel>> obtenerArticulos(int tipoInventarioId, int areaId);
        public Result<List<ArticuloModel>> obtenerArticulosPorEmpresa(int empresaId);
        public Result<List<ArticuloModel>> obtenerArticulosMTM(int su);
        public Result<int> crearArticuloMTM(ArticuloModel o);
        public Result<int> actualizarArticuloMTM(ArticuloModel o);
        public Result<int> eliminarArticuloMTM(int id);
        public Result<int> cargarArticulosMTM(List<ArticuloModel> articulos);
    }
}
