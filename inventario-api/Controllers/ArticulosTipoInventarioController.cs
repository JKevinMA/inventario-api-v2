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
    public class ArticulosTipoInventarioController : ControllerBase
    {
        private readonly IArticuloTipoInventarioRepository _repo;

        public ArticulosTipoInventarioController(IArticuloTipoInventarioRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetMTM(int su)
        {
            try
            {
                var res = _repo.obtenerArticulosTipoInventarioMTM(su);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult PostMTM([FromBody] ArticuloTipoInventarioModel o)
        {
            try
            {
                var res = _repo.crearArticuloTipoInventarioMTM(o);
                return StatusCode(201, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult PutMTM([FromBody] ArticuloTipoInventarioModel o)
        {
            try
            {
                var res = _repo.actualizarArticuloTipoInventarioMTM(o);
                return StatusCode(201, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete]
        public IActionResult DeleteArticuloMTM(int articuloId,int areaId,int tipoInventarioId)
        {
            try
            {
                var res = _repo.eliminarArticuloTipoInventarioMTM(articuloId, areaId, tipoInventarioId);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
