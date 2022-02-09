using inventario_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Repository.IRepository
{
    public interface ICategoriaRepository
    {
        public Result<List<CategoriaModel>> obtenerCategorias(int empresaId);
        public Result<List<CategoriaModel>> obtenerCategoriasMTM(int su);
        public Result<int> crearCategoriaMTM(CategoriaModel o);
        public Result<int> actualizarCategoriaMTM(CategoriaModel o);
        public Result<int> eliminarCategoriaMTM(int id);
    }
}
