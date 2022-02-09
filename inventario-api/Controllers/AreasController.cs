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
    public class AreasController : ControllerBase
    {
        private readonly IAreaRepository _repo;

        public AreasController(IAreaRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("almacen")]
        public IActionResult GetAreas(int almacenId)
        {
            try
            {
                var res = _repo.obtenerAreas(almacenId);
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
                var res = _repo.obtenerAreasMTM(su);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult PostMTM([FromBody] AreaModel o)
        {
            try
            {
                var res = _repo.crearAreaMTM(o);
                return StatusCode(201, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        public IActionResult PutMTM([FromBody] AreaModel o)
        {
            try
            {
                var res = _repo.actualizarAreaMTM(o);
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
                var res = _repo.eliminarAreaMTM(id);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
