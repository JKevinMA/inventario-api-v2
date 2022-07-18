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
    public class TomasInventarioController : ControllerBase
    {
        private readonly ITomaInventarioRepository _repo;

        public TomasInventarioController(ITomaInventarioRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("iniciado")]
        public IActionResult GetValidarInicioInventario(int inventarioId, int usuarioId)
        {
            try
            {
                var res = _repo.validarInicioInventario(inventarioId, usuarioId);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                Log.Save(this, ex.ToString());
                return StatusCode(500, ex.Message);
            }
        } 

        [HttpGet]
        public IActionResult GetTomaInventario(int inventarioId, int usuarioId)
        {
            try
            {
                var res = _repo.obtenerTomaInventario(inventarioId, usuarioId);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                Log.Save(this, ex.ToString());
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("cerrarYCabeceras")]
        public IActionResult GetTomasInventarioUsuario(int inventarioId)
        {
            try
            {
                var res = _repo.cerrarYObtenerTomasUsuarioCabecera(inventarioId);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                Log.Save(this, ex.ToString());
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("detalles")]
        public IActionResult GetTomaInventarioUsuarioDetalle(int tomaInventarioId)
        {
            try
            {
                var res = _repo.obtenerTomaUsuarioDetalle(tomaInventarioId);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                Log.Save(this, ex.ToString());
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("toma")]
        public IActionResult PostToma(TomaInventarioDetalle tid)
        {
            try
            {
                var res = _repo.guardaToma(tid);
                return StatusCode(201, res);
            }
            catch (Exception ex)
            {
                Log.Save(this, ex.ToString());
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPut("cerrar")]
        public IActionResult PutCerrar(TomaInventarioCabecera tic)
        {
            try
            {
                var res = _repo.cerrarToma(tic);
                return StatusCode(201, res);
            }
            catch (Exception ex)
            {
                Log.Save(this, ex.ToString());
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("tomaconsolidadacabecera")]
        public IActionResult GetTomasConsolidadaCabecera(string fecha,string tipo)
        {
            try
            {
                var res = _repo.obtenerTomaInventarioConsolidadaCabecera(fecha,tipo);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                Log.Save(this, ex.ToString());
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("tomaconsolidadadetalle")]
        public IActionResult GetTomasConsolidadaDetalle(string fecha, string tipo,int tipoInventarioId,int id)
        {
            try
            {
                var res = _repo.obtenerTomaInventarioConsolidadaDetalle(fecha, tipo, tipoInventarioId,id);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                Log.Save(this, ex.ToString());
                return StatusCode(500, ex.Message);
            }
        }
    }
}
