using inventario_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Repository.IRepository
{
    public interface IAlmacenRepository
    {
        public Result<List<AlmacenModel>> obtenerAlmacenes(int localId);

        public Result<List<AlmacenModel>> obtenerAlmacenesMTM(int su);
        public Result<int> crearAlmacenMTM(AlmacenModel o);
        public Result<int> actualizarAlmacenMTM(AlmacenModel o);
        public Result<int> eliminarAlmacenMTM(int id);
    }
}
