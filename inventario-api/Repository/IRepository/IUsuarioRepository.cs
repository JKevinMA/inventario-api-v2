using inventario_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Repository.IRepository
{
    public interface IUsuarioRepository
    {
        public Result<UsuarioModel> Login(UsuarioLogin u);

        public Result<List<UsuarioModel>> obtenerUsuariosMTM();


        public Result<int> crearUsuarioMTM(UsuarioModel o);


        public Result<int> actualizarUsuarioMTM(UsuarioModel o);


        public Result<int> eliminarUsuarioMTM(int id);
        public Result<List<UsuarioModel>> obtenerUsuariosEmpresa(int empresaId);



    }
}
