using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Repository
{
    public class Queries
    {
        public static string Login = "Select * from USUARIO where USUARIO = @USUARIO and CLAVE = @CLAVE";
        
        //Apertura
        
        public static string TiposInventario = "Select * from TIPOINVENTARIO";
        public static string Articulos = "Select A.ARTICULOID,A.CODIGO,A.DESCRIPCION from ARTICULOTIPOINVENTARIO ATI INNER JOIN ARTICULO A ON ATI.ARTICULOID = A.ARTICULOID WHERE ATI.TIPOINVENTARIOID = @TIPOINVENTARIOID AND ATI.AREAID = @AREAID AND A.HABILITADO = 1 ORDER BY A.DESCRIPCION";
        public static string CrearInventarioCabecera = "INSERT INTO INVENTARIOCABECERA(FECHAINICIO,ESTADO,ARCHIVOSTOCK,USUARIOID,TIPOINVENTARIOID,AREAID) VALUES (GETDATE(),@ESTADO,@ARCHIVOSTOCK,@USUARIOID,@TIPOINVENTARIOID,@AREAID)";
        public static string CrearInventarioDetalle = "INSERT INTO INVENTARIODETALLE(INVENTARIOID,ARTICULOID,STOCKTEORICO,PRECIOPROMEDIO,CANTIDAD,VALOR,VALIDADO,FINALIZADO) VALUES (@INVENTARIOID,@ARTICULOID,@STOCKTEORICO,@PRECIOPROMEDIO,0,@STOCKTEORICO * @PRECIOPROMEDIO,0,0)";
        public static string ValidarInventarioAbierto = "SELECT A.AREAID,A.DESCRIPCION FROM INVENTARIOCABECERA I INNER JOIN AREA A ON I.AREAID = A.AREAID AND I.AREAID = @AREAID AND I.ESTADO = 'APERTURADO'";

        //Toma
        public static string InventariosAbiertos = "select ic.INVENTARIOID,IC.FECHAINICIO,ISNULL(IC.FECHAFIN,GETDATE()) AS FECHAFIN,IC.TIPOINVENTARIOID,IC.AREAID,AL.DESCRIPCION AS ALMACEN,a.DESCRIPCION as AREA, ti.DESCRIPCION as TIPOINVENTARIO,ic.ARCHIVOSTOCK from INVENTARIOCABECERA ic inner join USUARIOAREA ua ON ua.AREAID = ic.AREAID inner join TIPOINVENTARIO ti on ic.TIPOINVENTARIOID = ti.TIPOINVENTARIOID INNER JOIN AREA A ON IC.AREAID = A.AREAID INNER JOIN ALMACEN AL ON A.ALMACENID = AL.ALMACENID where ua.USUARIOID = @USUARIOID and IC.ESTADO = @ESTADO  order by IC.FECHAFIN desc";
        public static string ValidarInicioInventario = "USP_VALIDARINICIOINVENTARIO";
        public static string TraerTomaInventario = "USP_INICIARTOMAINVENTARIO";
        public static string GuardaToma = "UPDATE TOMAINVENTARIODETALLE SET CANTIDAD=@CANTIDAD,BLANCO = @BLANCO WHERE TOMAINVENTARIOID = @TOMAINVENTARIOID AND ARTICULOID = @ARTICULOID ";
        public static string CerrarToma = "UPDATE TOMAINVENTARIOCABECERA SET CERRADO = 1, FECHAFIN = GETDATE() WHERE TOMAINVENTARIOID = @TOMAINVENTARIOID";

        //Finalizacion
        public static string CerrarYObtenerTomaUsuarios = "USP_CERRAROBTENERTOMAS";
        public static string ObtenerTomaUsuarioDetalle = "select tid.*,a.CODIGO, a.DESCRIPCION as articulo,u.DESCRIPCION as unidadmedida from TOMAINVENTARIODETALLE tid INNER JOIN ARTICULO a ON a.ARTICULOID = tid.ARTICULOID INNER JOIN UNIDADMEDIDA u on a.UNIDADMEDIDAID = u.UNIDADMEDIDAID where tid.TOMAINVENTARIOID = @TOMAINVENTARIOID";
        public static string ObtenerInventarioDetalle = "SELECT  ID.INVENTARIOID,A.ARTICULOID,a.CODIGO, A.DESCRIPCION AS ARTICULO,ID.STOCKTEORICO,U.DESCRIPCION AS UNIDADMEDIDA,ID.CANTIDAD,id.PrecioPromedio,(ID.STOCKTEORICO-ID.CANTIDAD) AS FALTANTE ,ABS((ID.STOCKTEORICO-ID.CANTIDAD)*ID.PRECIOPROMEDIO) AS ABSVALDIF,isnull(id.CANTIDADVALIDADO,0) as CANTIDADVALIDADO FROM INVENTARIODETALLE ID INNER JOIN ARTICULO A ON ID.ARTICULOID = A.ARTICULOID INNER JOIN UNIDADMEDIDA U ON U.UNIDADMEDIDAID = A.UNIDADMEDIDAID WHERE ID.INVENTARIOID = @INVENTARIOID order by ABS((ID.STOCKTEORICO-ID.CANTIDAD)*ID.PRECIOPROMEDIO) desc ";
        public static string ValidarCantidad = "UPDATE INVENTARIODETALLE SET CANTIDADVALIDADO = @CANTIDADVALIDADO,VALORVALIDADO =PRECIOPROMEDIO*@CANTIDADVALIDADO , USUARIOIDVALIDADO=@USUARIOIDVALIDADO,DIFERENCIA=@DIFERENCIA,DIFERENCIAVALOR=PRECIOPROMEDIO*@DIFERENCIA,VALIDADO=@VALIDADO,FINALIZADO=1 WHERE INVENTARIOID= @INVENTARIOID AND ARTICULOID = @ARTICULOID";
        public static string FinalizarInventario = "UPDATE INVENTARIOCABECERA SET FECHAFIN = GETDATE(), ESTADO='FINALIZADO' WHERE INVENTARIOID = @INVENTARIOID";

        //Mantenimiento
        //Empresas
        public static string EmpresasMtm = "Select * from EMPRESA where su = @su order by descripcion ";
        public static string CrearEmpresaMtm = "Insert into EMPRESA (descripcion,su) values (@DESCRIPCION,@SU)";
        public static string ActualizarEmpresaMtm = "Update EMPRESA set descripcion = @DESCRIPCION where empresaId = @EMPRESAID";
        public static string EliminarEmpresaMtm = "Delete from EMPRESA where empresaid =  @EMPRESAID";

        //Articulos
        public static string ArticulosPorEmpresa = "Select a.*,e.descripcion as empresa,c.descripcion as categoria,f.descripcion as familia,um.descripcion as unidadmedida from ARTICULO a inner join empresa e on e.empresaid = a.empresaid inner join categoria c on a.categoriaid=c.categoriaid inner join familia f on a.familiaid = f.familiaid inner join unidadmedida um on a.unidadmedidaid = um.unidadmedidaid WHERE a.empresaId = @empresaId order by a.descripcion";
        public static string ArticulosMtm = "Select a.*,e.descripcion as empresa,c.descripcion as categoria,f.descripcion as familia,um.descripcion as unidadmedida from ARTICULO a inner join empresa e on e.empresaid = a.empresaid inner join categoria c on a.categoriaid=c.categoriaid inner join familia f on a.familiaid = f.familiaid inner join unidadmedida um on a.unidadmedidaid = um.unidadmedidaid where e.su = @su  order by a.descripcion,a.empresaid";
        public static string CrearArticuloMtm = "Insert into ARTICULO (codigo,descripcion,barcode,empresaid,categoriaid,familiaid,unidadmedidaid,habilitado) values (@CODIGO,@DESCRIPCION,@BARCODE,@EMPRESAID,@CATEGORIAID,@FAMILIAID,@UNIDADMEDIDAID,@HABILITADO)";
        public static string ActualizarArticuloMtm = "Update ARTICULO set  codigo = @codigo,descripcion = @descripcion,barcode = @barcode,empresaid = @empresaid,categoriaid = @categoriaid,familiaid = @familiaid,unidadmedidaid = @unidadmedidaid, habilitado = @habilitado where articuloid = @articuloid";
        public static string EliminarArticuloMtm = "Delete from ARTICULO where articuloid =  @ARTICULOID";

        //Categorias
        public static string Categorias = "Select * from CATEGORIA where EMPRESAID = @EMPRESAID";
        public static string CategoriasMtm = "Select c.*, e.descripcion as empresa from CATEGORIA c inner join empresa e on c.empresaid = e.empresaid where e.su = @su ";
        public static string CrearCategoriaMtm = "Insert into CATEGORIA (DESCRIPCION,EMPRESAID,CODIGO) values (@DESCRIPCION,@EMPRESAID,@CODIGO)";
        public static string ActualizarCategoriaMtm = "Update CATEGORIA set DESCRIPCION = @DESCRIPCION,EMPRESAID=@EMPRESAID,CODIGO=@CODIGO where CATEGORIAID = @CATEGORIAID";
        public static string EliminarCategoriaMtm = "Delete from CATEGORIA where CATEGORIAID =  @CATEGORIAID";

        //Familias
        public static string Familias = "Select * from FAMILIA where EMPRESAID = @EMPRESAID";
        public static string FamiliasMtm = "Select f.*, e.descripcion as empresa from FAMILIA f inner join empresa e on f.empresaid = e.empresaid where e.su = @su";
        public static string CrearFamiliaMtm = "Insert into FAMILIA (DESCRIPCION,EMPRESAID,CODIGO) values (@DESCRIPCION,@EMPRESAID,@CODIGO)";
        public static string ActualizarFamiliaMtm = "Update FAMILIA set DESCRIPCION = @DESCRIPCION,EMPRESAID=@EMPRESAID,CODIGO=@CODIGO   where FAMILIAID = @FAMILIAID";
        public static string EliminarFamiliaMtm = "Delete from FAMILIA where FAMILIAID =  @FAMILIAID";

        //Unidades de Medida
        public static string UnidadesMedidaMtm = "Select * from UNIDADMEDIDA";
        public static string CrearUnidadMedidaMtm = "Insert into UNIDADMEDIDA (DESCRIPCION,CODIGOSUNAT) values (@DESCRIPCION,@CODIGOSUNAT)";
        public static string ActualizarUnidadMedidaMtm = "Update UNIDADMEDIDA set DESCRIPCION = @DESCRIPCION,CODIGOSUNAT=@CODIGOSUNAT  where UNIDADMEDIDAID = @UNIDADMEDIDAID";
        public static string EliminarUnidadMedidaMtm = "Delete from UNIDADMEDIDA where UNIDADMEDIDAID =  @UNIDADMEDIDAID";

        //Locales
        public static string Locales = "Select * from LOCAL where EMPRESAID = @EMPRESAID and habilitado = 1";
        public static string LocalesMtm = "Select l.*, e.descripcion as empresa from LOCAL l inner join empresa e on l.empresaid = e.empresaid and e.su = @su";
        public static string CrearLocalMtm = "Insert into LOCAL (DESCRIPCION,EMPRESAID,HABILITADO) values (@DESCRIPCION,@EMPRESAID,@HABILITADO)";
        public static string ActualizarLocalMtm = "Update LOCAL set DESCRIPCION = @DESCRIPCION,EMPRESAID=@EMPRESAID,HABILITADO=@HABILITADO  where LOCALID = @LOCALID";
        public static string EliminarLocalMtm = "Delete from LOCAL where LOCALID =  @LOCALID";

        //Tipos de Inventario
        public static string TiposInventarioMtm = "Select * from TIPOINVENTARIO";
        public static string CrearTipoInventarioMtm = "Insert into TIPOINVENTARIO (DESCRIPCION) values (@DESCRIPCION)";
        public static string ActualizarTipoInventarioMtm = "Update TIPOINVENTARIO set DESCRIPCION = @DESCRIPCION where TIPOINVENTARIOID = @TIPOINVENTARIOID";
        public static string EliminarTipoInventarioMtm = "Delete from TIPOINVENTARIO where TIPOINVENTARIOID =  @TIPOINVENTARIOID";

        //Usuarios
        public static string Usuarios = "Select * from USUARIO where EMPRESAID = @EMPRESAID";
        public static string UsuariosMtm = "Select u.*, e.descripcion as empresa from USUARIO u inner join empresa e on u.empresaid = e.empresaid where u.su = @su";
        public static string CrearUsuarioMtm = "Insert into USUARIO (NOMBRE,USUARIO,CLAVE,ADMINISTRADOR,SUPERVISOR,INVENTARIO,EMPRESAID,SU) values (@NOMBRE,@USUARIO,@CLAVE,@ADMINISTRADOR,@SUPERVISOR,@INVENTARIO,@EMPRESAID,@SU)";
        public static string ActualizarUsuarioMtm = "Update USUARIO set NOMBRE = @NOMBRE,USUARIO = @USUARIO,CLAVE=@CLAVE,ADMINISTRADOR=@ADMINISTRADOR,SUPERVISOR=@SUPERVISOR,INVENTARIO=@INVENTARIO,EMPRESAID=@EMPRESAID where USUARIOID = @USUARIOID";
        public static string EliminarUsuarioMtm = "Delete from USUARIO where USUARIOID =  @USUARIOID";

        //Usuario Area
        public static string UsuariosAreaMtm = "Select ua.*,u.nombre,u.usuario,a.descripcion as area,al.almacenid,al.descripcion as almacen,l.localid,l.descripcion as local,e.empresaid,e.descripcion as empresa from USUARIOAREA ua INNER JOIN usuario u on u.usuarioid = ua.usuarioid inner join area a on a.areaid = ua.areaid inner join almacen al on al.almacenid = a.almacenid inner join local l on l.localid = al.localid inner join empresa e on e.empresaid = l.empresaid where e.su = @su";
        public static string CrearUsuarioAreaMtm = "Insert into USUARIOAREA (USUARIOID,AREAID) values (@USUARIOID,@AREAID)";
        public static string EliminarUsuarioAreaMtm = "Delete from USUARIOAREA where USUARIOID =  @USUARIOID AND  AREAID =  @AREAID";

        //Areas
        public static string Areas = "Select * from AREA where ALMACENID = @ALMACENID AND HABILITADO = 1 ";
        public static string AreasMtm = "Select a.*, al.descripcion as almacen,l.localid,l.descripcion as local,e.empresaid,e.descripcion as empresa from AREA a inner join ALMACEN al on al.almacenid = a.almacenid inner join local l on l.localid = al.localid inner join empresa e on e.empresaid = l.empresaid and e.su = @su ";
        public static string CrearAreaMtm = "Insert into AREA (DESCRIPCION,ALMACENID,HABILITADO) values (@DESCRIPCION,@ALMACENID,@HABILITADO)";
        public static string ActualizarAreaMtm = "Update AREA set DESCRIPCION = @DESCRIPCION,ALMACENID=@ALMACENID,HABILITADO=@HABILITADO  where AREAID = @AREAID";
        public static string EliminarAreaMtm = "Delete from AREA where AREAID =  @AREAID";

        //Almacenes
        public static string Almacenes = "Select * from ALMACEN where LOCALID = @LOCALID AND HABILITADO = 1 ";
        public static string AlmacenesMtm = "Select al.*,l.descripcion as local,e.empresaid,e.descripcion as empresa from ALMACEN al inner join local l on l.localid = al.localid inner join empresa e on e.empresaid = l.empresaid and e.su = @su ";
        public static string CrearAlmacenMtm = "Insert into ALMACEN (DESCRIPCION,LOCALID,HABILITADO) values (@DESCRIPCION,@LOCALID,@HABILITADO)";
        public static string ActualizarAlmacenMtm = "Update ALMACEN set DESCRIPCION = @DESCRIPCION,LOCALID=@LOCALID,HABILITADO=@HABILITADO where ALMACENID = @ALMACENID";
        public static string EliminarAlmacenMtm = "Delete from ALMACEN where ALMACENID =  @ALMACENID";

        //Articulos Tipo Inventario
        public static string ArticulosTipoInventarioMtm = "select at.*,ar.CODIGO,ar.DESCRIPCION as articulo,a.DESCRIPCION as area,al.almacenid,al.DESCRIPCION as almacen,l.localid, l.DESCRIPCION as local,e.empresaid,e.DESCRIPCION as empresa,ti.descripcion as tipoinventario from ARTICULOTIPOINVENTARIO at inner join AREA a on a.AREAID = at.AREAID inner join ALMACEN al on al.ALMACENID = a.ALMACENID inner join LOCAL l on l.LOCALID = al.LOCALID inner join EMPRESA e  on e.EMPRESAID=l.EMPRESAID inner join TIPOINVENTARIO ti on ti.TIPOINVENTARIOID = at.TIPOINVENTARIOID inner join ARTICULO ar on ar.ARTICULOID = at.ARTICULOID where e.su = @su";
        public static string CrearArticuloTipoInventarioMtm = "Insert into ARTICULOTIPOINVENTARIO (ARTICULOID,AREAID,TIPOINVENTARIOID,ORDEN,LOCALIZACION) values (@ARTICULOID,@AREAID,@TIPOINVENTARIOID,@ORDEN,@LOCALIZACION)";
        public static string ActualizarArticuloTipoInventarioMtm = "Update ARTICULOTIPOINVENTARIO set ORDEN = @ORDEN,LOCALIZACION=@LOCALIZACION where ARTICULOID = @ARTICULOID AND AREAID = @AREAID AND TIPOINVENTARIOID = @TIPOINVENTARIOID";
        public static string EliminarArticuloTipoInventarioMtm = "Delete from ARTICULOTIPOINVENTARIO where ARTICULOID = @ARTICULOID AND AREAID = @AREAID AND TIPOINVENTARIOID = @TIPOINVENTARIOID";
    }
}
