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
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaRepository _repo;

        public CategoriasController(ICategoriaRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("empresa")]
        public IActionResult GetMTM(int empresaId)
        {
            try
            {
                var res = _repo.obtenerCategorias(empresaId);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetCategoriasMTM(int su)
        {
            try
            {
                var res = _repo.obtenerCategoriasMTM(su);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult PostMTM([FromBody] CategoriaModel o)
        {
            try
            {
                var res = _repo.crearCategoriaMTM(o);
                return StatusCode(201, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        public IActionResult PutMTM([FromBody] CategoriaModel o)
        {
            try
            {
                var res = _repo.actualizarCategoriaMTM(o);
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
                var res = _repo.eliminarCategoriaMTM(id);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
