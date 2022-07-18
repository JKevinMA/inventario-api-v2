using inventario_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Repository.IRepository
{
    public interface IMovimientoRepository
    {
        public Result<MovimientoCabecera> verificarRegistroMovimiento(string tipoMovimiento, string fecha, int areaId);
        public Result<List<MovimientoDetalle>> iniciarRegistroMovimiento(string tipoMovimiento, string fecha, int areaId);
        public Result<List<MovimientoDetalle>> traerMovimientoDetalle(int movimientoId);
        public Result<int> guardarMovimientoDetalle(List<MovimientoDetalle> mD);
        public Result<List<IngresoSalidaConsolidada>> traerIngresoSalidaConsolidada(string fechaAnterior, string fechaActual, int areaId);
    }
}
