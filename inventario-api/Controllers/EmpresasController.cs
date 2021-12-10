using inventario_api.Models;
using inventario_api.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly IEmpresaRepository _repo;

        public EmpresasController(IEmpresaRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetEmpresasMTM()
        {
            try
            {
                var res = _repo.obtenerEmpresasMTM();
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult PostEmpresaMTM([FromBody] EmpresaModel o)
        {
            try
            {
                var res = _repo.crearEmpresaMTM(o);
                return StatusCode(201, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        public IActionResult PutEmpresaMTM([FromBody] EmpresaModel o)
        {
            try
            {
                var res = _repo.actualizarEmpresaMTM(o);
                return StatusCode(201, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEmpresaMTM(int id)
        {
            try
            {
                var res = _repo.eliminarEmpresaMTM(id);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
