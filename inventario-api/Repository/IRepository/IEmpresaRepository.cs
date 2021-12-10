using inventario_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Repository.IRepository
{
    public interface IEmpresaRepository
    {
        public Result<List<EmpresaModel>> obtenerEmpresasMTM();
        public Result<int> crearEmpresaMTM(EmpresaModel o);
        public Result<int> actualizarEmpresaMTM(EmpresaModel o);
        public Result<int> eliminarEmpresaMTM(int id);
    }
}
