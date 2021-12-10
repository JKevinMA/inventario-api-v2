using inventario_api.Helpers;
using inventario_api.Models;
using inventario_api.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Repository
{
    public class InventarioRepository: IInventarioRepository
    {
        private Connection _bd;
        
        public Result<int> aperturarInventario(List<InventarioCabecera> inventarios)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();
            int res=0;

            SqlConnection con = _bd.sqlConnection;
            foreach (var inventario in inventarios)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(Queries.CrearInventarioCabecera, con);
                    cmd.Parameters.Add("@estado", SqlDbType.NVarChar).Value = inventario.Estado;
                    cmd.Parameters.Add("@areaid", SqlDbType.Int).Value = inventario.AreaId;
                    cmd.Parameters.Add("@tipoinventarioid", SqlDbType.Int).Value = inventario.TipoInventarioId;
                    cmd.Parameters.Add("@archivostock", SqlDbType.NVarChar).Value = inventario.ArchivoStock;
                    cmd.Parameters.Add("@usuarioid", SqlDbType.Int).Value = inventario.UsuarioId;
                    res = cmd.ExecuteNonQuery();
                    con.Close();

                    if (res > 0)
                    {
                        int inventarioId = 0;
                        cmd = new SqlCommand("Select IDENT_CURRENT('INVENTARIOCABECERA') as Id", con);
                        cmd.Connection = con;
                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                inventarioId = int.Parse(reader["Id"].ToString());
                            }
                        }
                        con.Close();

                        foreach (var detalle in inventario.Detalles)
                        {
                            con.Open();
                            cmd = new SqlCommand(Queries.CrearInventarioDetalle, con); 
                            cmd.Parameters.Add("@inventarioid", SqlDbType.Int).Value = inventarioId;
                            cmd.Parameters.Add("@articuloid", SqlDbType.Int).Value = detalle.ArticuloId;
                            cmd.Parameters.Add("@stockteorico", SqlDbType.Real).Value = detalle.StockTeorico;
                            cmd.Parameters.Add("@preciopromedio", SqlDbType.Real).Value = detalle.PrecioPromedio;
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }

                }
                catch (Exception ex)
                {
                    r.Success = false;
                    r.Message = ex.Message;
                    r.Response = 0;
                    return r;
                }
                finally
                {
                    con.Close();
                }
                res++;
            }
            r.Success = true;
            r.Response = res;
            return r;
        }
        public Result<List<AreaModel>> validarInventarioAbierto(List<InventarioCabecera> inventarios)
        {
            _bd = new Connection();
            Result<List<AreaModel>> r = new Result<List<AreaModel>>();
            List<AreaModel> areas = new List<AreaModel>();
            SqlConnection con = _bd.sqlConnection;

            foreach (var inventario in inventarios)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(Queries.ValidarInventarioAbierto, con);
                    cmd.Parameters.Add("@areaid", SqlDbType.Int).Value = inventario.AreaId;
                    cmd.Connection = con;
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            areas.Add(new AreaModel
                            {
                                AreaId = int.Parse(reader["AreaId"].ToString()),
                                Descripcion = reader["Descripcion"].ToString(),
                            });
                            break;
                        }
                    }

                }
                catch (Exception ex)
                {
                    r.Success = false;
                    r.Message = ex.Message;
                    return r;
                }
                finally
                {
                    con.Close();
                }
            }
            r.Success = true;
            r.Response = areas;
            return r;
        }

        public Result<List<InventarioCabecera>> obtenerInventariosAbiertos(int usuarioId,string estado)
        {
            _bd = new Connection();
            List<InventarioCabecera> lista = new List<InventarioCabecera>();
            Result<List<InventarioCabecera>> r = new Result<List<InventarioCabecera>>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.InventariosAbiertos, con);
                    sqlCommand.Parameters.Add("@usuarioid", SqlDbType.Int).Value = usuarioId;
                    sqlCommand.Parameters.Add("@estado", SqlDbType.NVarChar).Value = estado;
                    sqlCommand.Connection = con;
                    con.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new InventarioCabecera
                            {
                                InventarioId = int.Parse(reader["InventarioId"].ToString()),
                                TipoInventarioId = int.Parse(reader["TipoInventarioId"].ToString()),
                                AreaId = int.Parse(reader["AreaId"].ToString()),
                                FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString()),
                                FechaFin = DateTime.Parse(reader["FechaFin"].ToString()),
                                ArchivoStock = reader["ArchivoStock"].ToString(),
                                Almacen = reader["Almacen"].ToString(),
                                Area = reader["Area"].ToString(),
                                TipoInventario= reader["TipoInventario"].ToString()
                            });
                        }
                        r.Success = true;
                        r.Response = lista;
                    }
                }
                catch (Exception ex)
                {
                    r.Success = false;
                    r.Message = ex.Message;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }

            return r;
        }


        public Result<List<InventarioDetalle>> obtenerInventarioDetalle(int inventarioId)
        {
            _bd = new Connection();
            List<InventarioDetalle> lista = new List<InventarioDetalle>();
            Result<List<InventarioDetalle>> r = new Result<List<InventarioDetalle>>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.ObtenerInventarioDetalle, con);
                    sqlCommand.Parameters.Add("@inventarioId", SqlDbType.Int).Value = inventarioId;
                    sqlCommand.Connection = con;
                    con.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new InventarioDetalle
                            {
                                InventarioId = int.Parse(reader["InventarioId"].ToString()),
                                ArticuloId = int.Parse(reader["ArticuloId"].ToString()),
                                Codigo = reader["Codigo"].ToString(),
                                Articulo = reader["Articulo"].ToString(),
                                StockTeorico = double.Parse(reader["StockTeorico"].ToString()),
                                Cantidad = double.Parse(reader["Cantidad"].ToString()),
                                PrecioPromedio = double.Parse(reader["PrecioPromedio"].ToString()),
                                Faltante = double.Parse(reader["Faltante"].ToString()),
                                AbsValDif = double.Parse(reader["AbsValDif"].ToString())
                            });
                        }
                        r.Success = true;
                        r.Response = lista;
                    }
                }
                catch (Exception ex)
                {
                    r.Success = false;
                    r.Message = ex.Message;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }

            return r;
        }

        public Result<int> validarCantidad(List<InventarioDetalle> inventarios)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();
            int res = 0;

            SqlConnection con = _bd.sqlConnection;
            foreach (var inventario in inventarios)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(Queries.ValidarCantidad, con);
                    cmd.Parameters.Add("@CantidadValidado", SqlDbType.Real).Value = inventario.CantidadValidado;
                    cmd.Parameters.Add("@UsuarioIdValidado", SqlDbType.Int).Value = inventario.UsuarioIdValidado;
                    cmd.Parameters.Add("@Diferencia", SqlDbType.Real).Value = inventario.Diferencia;
                    cmd.Parameters.Add("@Validado", SqlDbType.Bit).Value = inventario.Validado;
                    cmd.Parameters.Add("@InventarioId", SqlDbType.Int).Value = inventario.InventarioId;
                    cmd.Parameters.Add("@ArticuloId", SqlDbType.Int).Value = inventario.ArticuloId;
                    res = cmd.ExecuteNonQuery();
                    con.Close();

                }
                catch (Exception ex)
                {
                    r.Success = false;
                    r.Message = ex.Message;
                    r.Response = 0;
                    Log.Save(this,ex.ToString()) ;
                    return r;
                }
                finally
                {
                    con.Close();
                }
                res++;
            }
            r.Success = true;
            r.Response = res;
            return r;
        }
        public Result<int> finalizarInventario(int inventarioId)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();
            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.FinalizarInventario, con);
                    sqlCommand.Parameters.Add("@inventarioId", SqlDbType.Int).Value = inventarioId;
                    sqlCommand.Connection = con;
                    con.Open();

                    int res = sqlCommand.ExecuteNonQuery();

                    r.Success = true;
                    r.Response = res;
                }
                catch (Exception ex)
                {
                    r.Success = false;
                    r.Message = ex.Message;
                    r.Response = 0;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
            return r;
        }
    }
}
