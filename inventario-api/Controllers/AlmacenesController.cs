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
    public class AlmacenesController : ControllerBase
    {
        private readonly IAlmacenRepository _repo;

        public AlmacenesController(IAlmacenRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("local")]
        public IActionResult GetTiposInventario(int localId)
        {
            try
            {
                var res = _repo.obtenerAlmacenes(localId);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetMTM(int su)
        {
            try
            {
                var res = _repo.obtenerAlmacenesMTM(su);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult PostMTM([FromBody] AlmacenModel o)
        {
            try
            {
                var res = _repo.crearAlmacenMTM(o);
                return StatusCode(201, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        public IActionResult PutMTM([FromBody] AlmacenModel o)
        {
            try
            {
                var res = _repo.actualizarAlmacenMTM(o);
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
                var res = _repo.eliminarAlmacenMTM(id);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
