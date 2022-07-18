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
    public class MovimientosController : ControllerBase
    {
        private readonly IMovimientoRepository movimientoRepo;

        public MovimientosController(IMovimientoRepository movimientoRepo)
        {
            this.movimientoRepo = movimientoRepo;
        }

        [HttpGet("verificar-registro-movimiento")]
        public IActionResult VerificarRegistroMovimiento(string tipoMovimiento,string fecha, int areaId)
        {
            try
            {
                var res = movimientoRepo.verificarRegistroMovimiento(tipoMovimiento, fecha, areaId);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                Log.Save(this, ex.ToString());
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("iniciar-registro-movimiento")]
        public IActionResult IniciarRegistroMovimiento(string tipoMovimiento, string fecha, int areaId)
        {
            try
            {
                var res = movimientoRepo.iniciarRegistroMovimiento(tipoMovimiento, fecha, areaId);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                Log.Save(this, ex.ToString());
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("traer-movimiento-detalle")]
        public IActionResult TraerMovimientoDetalle(int movimientoId)
        {
            try
            {
                var res = movimientoRepo.traerMovimientoDetalle(movimientoId);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                Log.Save(this, ex.ToString());
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("ingreso-salida-consolidada")]
        public IActionResult TraerIngresoSalidaConsolidad(string fechaAnterior, string fechaActual,int areaId)
        {
            try
            {
                var res = movimientoRepo.traerIngresoSalidaConsolidada(fechaAnterior, fechaActual, areaId);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                Log.Save(this, ex.ToString());
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("movimiento-detalle")]
        public IActionResult PostMovimiendoDetalle(List<MovimientoDetalle> md)
        {
            try
            {
                var res = movimientoRepo.guardarMovimientoDetalle(md);
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
