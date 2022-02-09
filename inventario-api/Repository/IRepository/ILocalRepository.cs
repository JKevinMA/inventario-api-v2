using inventario_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Repository.IRepository
{
    public interface ILocalRepository
    {
        public Result<List<LocalModel>> obtenerLocales(int empresaId);

        public Result<List<LocalModel>> obtenerLocalesMTM(int su);


        public Result<int> crearLocalMTM(LocalModel o);


        public Result<int> actualizarLocalMTM(LocalModel o);


        public Result<int> eliminarLocalMTM(int id);
        
    }
}
