using inventario_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Repository.IRepository
{
    public interface IUsuarioAreaRepository
    {
        public Result<List<UsuarioAreaModel>> obtenerUsuariosAreaMTM(int su);

        public Result<int> crearUsuarioAreaMTM(UsuarioAreaModel o);

        public Result<int> eliminarUsuarioAreaMTM(int usuarioId, int areaId);
        
    }
}
