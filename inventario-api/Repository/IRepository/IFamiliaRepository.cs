using inventario_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Repository.IRepository
{
    public interface IFamiliaRepository
    {
        public Result<List<FamiliaModel>> obtenerFamilias(int empresaId);
        public Result<List<FamiliaModel>> obtenerFamiliasMTM(int su);
        public Result<int> crearFamiliaMTM(FamiliaModel o);
        public Result<int> actualizarFamiliaMTM(FamiliaModel o);
        public Result<int> eliminarFamiliaMTM(int id);
    }
}
