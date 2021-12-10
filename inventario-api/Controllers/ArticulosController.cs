using inventario_api.Helpers;
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
    public class ArticulosController : ControllerBase
    {
        private readonly IArticuloRepository _repo;

        public ArticulosController(IArticuloRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetArticulos(int tipoInventarioId,int areaId)
        {
            try
            {
                var res = _repo.obtenerArticulos(tipoInventarioId,areaId);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("mtm")]
        public IActionResult GetArticulosMTM()
        {
            try
            {
                var res = _repo.obtenerArticulosMTM();
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("empresa")]
        public IActionResult GetArticulosPorEmpresa(int empresaId)
        {
            try
            {
                var res = _repo.obtenerArticulosPorEmpresa(empresaId);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult PostArticuloMTM([FromBody] ArticuloModel o)
        {
            try
            {
                var res = _repo.crearArticuloMTM(o);
                return StatusCode(201, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("carga")]
        public IActionResult PostCargaArticulosMTM([FromBody] List<ArticuloModel> lo)
        {
            try
            {
                var res = _repo.cargarArticulosMTM(lo);
                return StatusCode(201, res);
            }
            catch (Exception ex)
            {
                Log.Save(this,ex.ToString());
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult PutArticuloMTM([FromBody] ArticuloModel o)
        {
            try
            {
                var res = _repo.actualizarArticuloMTM(o);
                return StatusCode(201, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteArticuloMTM(int id)
        {
            try
            {
                var res = _repo.eliminarArticuloMTM(id);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
