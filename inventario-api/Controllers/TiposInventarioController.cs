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
    public class TiposInventarioController : ControllerBase
    {
        private readonly ITipoInventarioRepository _repo;

        public TiposInventarioController(ITipoInventarioRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetMTM()
        {
            try
            {
                var res = _repo.obtenerTiposInventarioMTM();
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult PostMTM([FromBody] TipoInventarioModel o)
        {
            try
            {
                var res = _repo.crearTipoInventarioMTM(o);
                return StatusCode(201, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        public IActionResult PutMTM([FromBody] TipoInventarioModel o)
        {
            try
            {
                var res = _repo.actualizarTipoInventarioMTM(o);
                return StatusCode(201, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMTM(int id)
        {
            try
            {
                var res = _repo.eliminarTipoInventarioMTM(id);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
