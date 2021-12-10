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
    public class InventariosController : ControllerBase
    {
        private readonly IInventarioRepository _repo;

        public InventariosController(IInventarioRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult PostInventario([FromBody] List<InventarioCabecera> invs)
        {
            try
            {
                var res = _repo.aperturarInventario(invs);
                return StatusCode(201, res);
            }
            catch (Exception ex)
            {
                Log.Save(this,ex.ToString());
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("validarInventarioAbierto")]
        public IActionResult PostValidarInventarioAbierto([FromBody] List<InventarioCabecera> invs)
        {
            try
            {
                var res = _repo.validarInventarioAbierto(invs);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                Log.Save(this, ex.ToString());
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("abiertos")]
        public IActionResult GetInventariosAbierto( int usuarioId, string estado)
        {
            try
            {
                var res = _repo.obtenerInventariosAbiertos(usuarioId, estado);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                Log.Save(this, ex.ToString());
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("finalizar")]
        public IActionResult PostFinalizarInventario(int inventarioId)
        {
            try
            {
                var res = _repo.finalizarInventario(inventarioId);
                return StatusCode(201, res);
            }
            catch (Exception ex)
            {
                Log.Save(this, ex.ToString());
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("detalles")]
        public IActionResult GetInventarioDetalle(int inventarioId)
        {
            try
            {
                var res = _repo.obtenerInventarioDetalle(inventarioId);
                return StatusCode(201, res);
            }
            catch (Exception ex)
            {
                Log.Save(this, ex.ToString());
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("validarCantidad")]
        public IActionResult PutValidarCantidad(List<InventarioDetalle> iDs)
        {
            try
            {
                var res = _repo.validarCantidad(iDs);
                return StatusCode(201, res);
            }
            catch (Exception ex)
            {
                Log.Save(this, ex.ToString());
                return StatusCode(500, ex.Message);
            }
        }

    }
}
