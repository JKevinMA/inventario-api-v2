using inventario_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Repository.IRepository
{
    public interface IAreaRepository
    {
        public Result<List<AreaModel>> obtenerAreas(int almacenId);

        public Result<List<AreaModel>> obtenerAreasMTM(int su);
        public Result<int> crearAreaMTM(AreaModel o);
        public Result<int> actualizarAreaMTM(AreaModel o);
        public Result<int> eliminarAreaMTM(int id);
    }
}
