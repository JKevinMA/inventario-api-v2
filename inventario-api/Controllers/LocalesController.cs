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
    public class LocalesController : ControllerBase
    {
        private readonly ILocalRepository _repo;

        public LocalesController(ILocalRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("empresa")]
        public IActionResult GetLocales( int empresaId)
        {
            try
            {
                var res = _repo.obtenerLocales(empresaId);
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
                var res = _repo.obtenerLocalesMTM( su );
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult PostMTM([FromBody] LocalModel o)
        {
            try
            {
                var res = _repo.crearLocalMTM(o);
                return StatusCode(201, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        public IActionResult PutMTM([FromBody] LocalModel o)
        {
            try
            {
                var res = _repo.actualizarLocalMTM(o);
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
                var res = _repo.eliminarLocalMTM(id);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
