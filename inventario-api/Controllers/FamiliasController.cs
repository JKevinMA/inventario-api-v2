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
    public class FamiliasController : ControllerBase
    {
        private readonly IFamiliaRepository _repo;

        public FamiliasController(IFamiliaRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("empresa")]
        public IActionResult GetMTM(int empresaId)
        {
            try
            {
                var res = _repo.obtenerFamilias(empresaId);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetFamiliasMTM(int su)
        {
            try
            {
                var res = _repo.obtenerFamiliasMTM(su);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult PostMTM([FromBody] FamiliaModel o)
        {
            try
            {
                var res = _repo.crearFamiliaMTM(o);
                return StatusCode(201, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        public IActionResult PutMTM([FromBody] FamiliaModel o)
        {
            try
            {
                var res = _repo.actualizarFamiliaMTM(o);
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
                var res = _repo.eliminarFamiliaMTM(id);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
