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
    public class UsuariosAreaController : ControllerBase
    {
        private readonly IUsuarioAreaRepository _repo;

        public UsuariosAreaController(IUsuarioAreaRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetMTM(int su)
        {
            try
            {
                var res = _repo.obtenerUsuariosAreaMTM(su);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult PostMTM([FromBody] UsuarioAreaModel o)
        {
            try
            {
                var res = _repo.crearUsuarioAreaMTM(o);
                return StatusCode(201, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteMTM(int usuarioId,int areaId)
        {
            try
            {
                var res = _repo.eliminarUsuarioAreaMTM(usuarioId, areaId);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
