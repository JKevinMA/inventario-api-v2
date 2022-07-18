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
    public class MovimientoRepository: IMovimientoRepository
    {
        private Connection _bd;
        public Result<MovimientoCabecera> verificarRegistroMovimiento(string tipoMovimiento,string fecha, int areaId)
        {
            _bd = new Connection();
            Result<MovimientoCabecera> r = new Result<MovimientoCabecera>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.VerificarRegistroMovimiento, con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.Add("@tipoMovimiento", SqlDbType.NVarChar).Value = tipoMovimiento;
                    sqlCommand.Parameters.Add("@fecha", SqlDbType.NVarChar).Value = fecha;
                    sqlCommand.Parameters.Add("@areaId", SqlDbType.Int).Value = areaId;
                    sqlCommand.Connection = con;
                    con.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            r.Response = new MovimientoCabecera
                            {
                                MovimientoId = int.Parse(reader["MovimientoId"].ToString()),
                                Estado = reader["Estado"].ToString(),
                            };
                        }
                        r.Success = true;
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
        public Result<List<MovimientoDetalle>> iniciarRegistroMovimiento(string tipoMovimiento, string fecha, int areaId)
        {
            _bd = new Connection();
            List<MovimientoDetalle> lista = new List<MovimientoDetalle>();
            Result<List<MovimientoDetalle>> r = new Result<List<MovimientoDetalle>>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.IniciarRegistroMovimiento, con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.Add("@tipoMovimiento", SqlDbType.NVarChar).Value = tipoMovimiento;
                    sqlCommand.Parameters.Add("@fecha", SqlDbType.NVarChar).Value = fecha;
                    sqlCommand.Parameters.Add("@areaId", SqlDbType.Int).Value = areaId;
                    sqlCommand.Connection = con;
                    con.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        r.Success = true;
                        while (reader.Read())
                        {
                            lista.Add(new MovimientoDetalle
                            {
                                MovimientoId = int.Parse(reader["MovimientoId"].ToString()),
                                ArticuloId = int.Parse(reader["ArticuloId"].ToString()),
                                Articulo = reader["Articulo"].ToString(),
                                Cantidad = decimal.Parse(reader["Cantidad"].ToString()),
                                PrecioUnitario = decimal.Parse(reader["PrecioUnitario"].ToString()),
                                UnidadMedida = reader["UnidadMedida"].ToString(),
                                Codigo = reader["Codigo"].ToString()
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
        public Result<List<MovimientoDetalle>> traerMovimientoDetalle(int movimientoId)
        {
            _bd = new Connection();
            List<MovimientoDetalle> lista = new List<MovimientoDetalle>();
            Result<List<MovimientoDetalle>> r = new Result<List<MovimientoDetalle>>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.TraerMovimientoDetalle, con);
                    sqlCommand.Parameters.Add("@movimientoId", SqlDbType.Int).Value = movimientoId;
                    sqlCommand.Connection = con;
                    con.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        r.Success = true;
                        while (reader.Read())
                        {
                            lista.Add(new MovimientoDetalle
                            {
                                MovimientoId = int.Parse(reader["MovimientoId"].ToString()),
                                ArticuloId = int.Parse(reader["ArticuloId"].ToString()),
                                Articulo = reader["Articulo"].ToString(),
                                Cantidad = decimal.Parse(reader["Cantidad"].ToString()),
                                PrecioUnitario = decimal.Parse(reader["PrecioUnitario"].ToString()),
                                UnidadMedida = reader["UnidadMedida"].ToString(),
                                Codigo = reader["Codigo"].ToString()
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

        public Result<int> guardarMovimientoDetalle(List<MovimientoDetalle> mD)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();
            int res = 0;

            SqlConnection con = _bd.sqlConnection;
            foreach (var md in mD)
            {
                try
                {
                    con.Open();
                    SqlCommand sqlCommand = new SqlCommand(Queries.GuardarMovimientoDetalle, con);
                    sqlCommand.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = md.Cantidad;
                    sqlCommand.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal).Value = md.PrecioUnitario;
                    sqlCommand.Parameters.Add("@MovimientoId", SqlDbType.Int).Value = md.MovimientoId;
                    sqlCommand.Parameters.Add("@ArticuloId", SqlDbType.Int).Value = md.ArticuloId;
                    sqlCommand.Connection = con;
                    res = sqlCommand.ExecuteNonQuery();
                    con.Close();

                }
                catch (Exception ex)
                {
                    r.Success = false;
                    r.Message = ex.Message;
                    r.Response = 0;
                    Log.Save(this, ex.ToString());
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

        public Result<List<IngresoSalidaConsolidada>> traerIngresoSalidaConsolidada(string fechaAnterior, string fechaActual, int areaId)
        {
            _bd = new Connection();
            List<IngresoSalidaConsolidada> lista = new List<IngresoSalidaConsolidada>();
            Result<List<IngresoSalidaConsolidada>> r = new Result<List<IngresoSalidaConsolidada>>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.TraerIngresoSalidaConsolidada, con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.Add("@fechaAnterior", SqlDbType.NVarChar).Value = fechaAnterior;
                    sqlCommand.Parameters.Add("@fechaActual", SqlDbType.NVarChar).Value = fechaActual;
                    sqlCommand.Parameters.Add("@areaId", SqlDbType.Int).Value = areaId;
                    sqlCommand.Connection = con;
                    con.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        r.Success = true;
                        while (reader.Read())
                        {
                            lista.Add(new IngresoSalidaConsolidada
                            {
                                Codigo = reader["Codigo"].ToString(),
                                Articulo = reader["Articulo"].ToString(),
                                UnidadMedida = reader["UnidadMedida"].ToString(),
                                StockInicial = int.Parse(reader["StockInicial"].ToString()),
                                Ingreso = double.Parse(reader["Ingreso"].ToString()),
                                Salida = double.Parse(reader["Salida"].ToString()),
                                Inventario = int.Parse(reader["Inventario"].ToString()),
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
    }
}
