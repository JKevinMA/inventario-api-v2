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
    public class TomaInventarioRepository: ITomaInventarioRepository
    {
        private Connection _bd;
        public Result<ValidarInicioInventario> validarInicioInventario(int inventarioId, int usuarioId)
        {
            _bd = new Connection();
            Result<ValidarInicioInventario> r = new Result<ValidarInicioInventario>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.ValidarInicioInventario, con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.Add("@inventarioId", SqlDbType.Int).Value = inventarioId;
                    sqlCommand.Parameters.Add("@usuarioId", SqlDbType.Int).Value = usuarioId;
                    sqlCommand.Connection = con;
                    con.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            r.Response = new ValidarInicioInventario
                            {
                                Total = int.Parse(reader["Total"].ToString()),
                                Cerrado = bool.Parse(reader["Cerrado"].ToString())
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

        public Result<List<TomaInventarioDetalle>> obtenerTomaInventario(int inventarioId, int usuarioId)
        {
            _bd = new Connection();
            List<TomaInventarioDetalle> lista = new List<TomaInventarioDetalle>();
            Result<List<TomaInventarioDetalle>> r = new Result<List<TomaInventarioDetalle>>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.TraerTomaInventario, con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.Add("@inventarioId", SqlDbType.Int).Value = inventarioId;
                    sqlCommand.Parameters.Add("@usuarioId", SqlDbType.Int).Value = usuarioId;
                    sqlCommand.Connection = con;
                    con.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        r.Success = true;
                        while (reader.Read())
                        {
                            lista.Add(new TomaInventarioDetalle
                            {
                                TomaInventarioId = int.Parse(reader["TomaInventarioId"].ToString()),
                                ArticuloId = int.Parse(reader["ArticuloId"].ToString()),
                                CategoriaId = int.Parse(reader["CategoriaId"].ToString()),
                                FamiliaId = int.Parse(reader["FamiliaId"].ToString()),
                                Orden = int.Parse(reader["Orden"].ToString()),
                                Cantidad = double.Parse(reader["Cantidad"].ToString()),
                                Blanco = bool.Parse(reader["Blanco"].ToString()),
                                Articulo = reader["Articulo"].ToString(),
                                Categoria = reader["Categoria"].ToString(),
                                Familia = reader["Familia"].ToString(),
                                Localizacion = reader["Localizacion"].ToString(),
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

        public Result<int> guardaToma(TomaInventarioDetalle toma)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();
            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.GuardaToma, con);
                    sqlCommand.Parameters.Add("@Cantidad", SqlDbType.Real).Value = toma.Cantidad;
                    sqlCommand.Parameters.Add("@Blanco", SqlDbType.Bit).Value = toma.Blanco;
                    sqlCommand.Parameters.Add("@tomaInventarioId", SqlDbType.Int).Value = toma.TomaInventarioId;
                    sqlCommand.Parameters.Add("@articuloId", SqlDbType.Int).Value = toma.ArticuloId;
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
                    Log.Save(this,ex.ToString());
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
            return r;
        }

        public Result<int> cerrarToma(TomaInventarioCabecera toma)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();
            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.CerrarToma, con);
                    sqlCommand.Parameters.Add("@tomaInventarioId", SqlDbType.Int).Value = toma.TomaInventarioId;
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
                    Log.Save(this, ex.ToString());
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
            return r;
        }

        public Result<List<TomaInventarioCabecera>> cerrarYObtenerTomasUsuarioCabecera(int inventarioId)
        {
            _bd = new Connection();
            List<TomaInventarioCabecera> lista = new List<TomaInventarioCabecera>();
            Result<List<TomaInventarioCabecera>> r = new Result<List<TomaInventarioCabecera>>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.CerrarYObtenerTomaUsuarios, con)
                    {
                        CommandType=CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.Add("@inventarioId", SqlDbType.Int).Value = inventarioId;
                    sqlCommand.Connection = con;
                    con.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        r.Success = true;
                        while (reader.Read())
                        {
                            lista.Add(new TomaInventarioCabecera
                            {
                                TomaInventarioId = int.Parse(reader["TomaInventarioId"].ToString()),
                                InventarioId = int.Parse(reader["InventarioId"].ToString()),
                                UsuarioId = int.Parse(reader["UsuarioId"].ToString()),
                                Usuario = reader["Usuario"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString()),
                                FechaFin = DateTime.Parse(reader["FechaFin"].ToString()),
                                Cerrado = bool.Parse(reader["Cerrado"].ToString())
                            });
                        }
                        r.Success = true;
                        r.Response = lista;
                    }
                }
                catch (Exception ex)
                {
                    r.Success = false;
                    r.Message = ex.ToString();
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }

            return r;
        }

        public Result<List<TomaInventarioDetalle>> obtenerTomaUsuarioDetalle(int tomaInventarioId)
        {
            _bd = new Connection();
            List<TomaInventarioDetalle> lista = new List<TomaInventarioDetalle>();
            Result<List<TomaInventarioDetalle>> r = new Result<List<TomaInventarioDetalle>>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.ObtenerTomaUsuarioDetalle, con);
                    sqlCommand.Parameters.Add("@tomaInventarioId", SqlDbType.Int).Value = tomaInventarioId;
                    sqlCommand.Connection = con;
                    con.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        r.Success = true;
                        while (reader.Read())
                        {
                            lista.Add(new TomaInventarioDetalle
                            {
                                TomaInventarioId = int.Parse(reader["TomaInventarioId"].ToString()),
                                ArticuloId = int.Parse(reader["ArticuloId"].ToString()),
                                Codigo = reader["Codigo"].ToString(),
                                Articulo = reader["Articulo"].ToString(),
                                UnidadMedida = reader["UnidadMedida"].ToString(),
                                Cantidad = double.Parse(reader["Cantidad"].ToString()),
                                Blanco = bool.Parse(reader["Blanco"].ToString())
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
        public Result<List<TomaInventarioConsolidadaCabecera>> obtenerTomaInventarioConsolidadaCabecera(string fecha, string tipo)
        {
            _bd = new Connection();
            List<TomaInventarioConsolidadaCabecera> lista = new List<TomaInventarioConsolidadaCabecera>();
            Result<List<TomaInventarioConsolidadaCabecera>> r = new Result<List<TomaInventarioConsolidadaCabecera>>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.TomaConsolidadaCabecera, con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.Add("@fecha", SqlDbType.NVarChar).Value = fecha;
                    sqlCommand.Parameters.Add("@tipo", SqlDbType.NVarChar).Value = tipo;
                    sqlCommand.Connection = con;
                    con.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        r.Success = true;
                        while (reader.Read())
                        {
                            lista.Add(new TomaInventarioConsolidadaCabecera
                            {
                                Tipo = reader["Tipo"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Id = int.Parse(reader["Id"].ToString()),
                                TipoInventarioId = int.Parse(reader["TipoInventarioId"].ToString()),
                                TipoInventario = reader["TipoInventario"].ToString(),
                                Fecha = reader["Fecha"].ToString(),
                                CantidadInventarios = int.Parse(reader["CantidadInventarios"].ToString())
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
        public Result<List<TomaInventarioConsolidadaDetalle>> obtenerTomaInventarioConsolidadaDetalle(string fecha, string tipo,int tipoInventarioId, int id)
        {
            _bd = new Connection();
            List<TomaInventarioConsolidadaDetalle> lista = new List<TomaInventarioConsolidadaDetalle>();
            Result<List<TomaInventarioConsolidadaDetalle>> r = new Result<List<TomaInventarioConsolidadaDetalle>>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.TomaConsolidadaDetalle, con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.Add("@fecha", SqlDbType.NVarChar).Value = fecha;
                    sqlCommand.Parameters.Add("@tipo", SqlDbType.NVarChar).Value = tipo;
                    sqlCommand.Parameters.Add("@tipoInventarioId", SqlDbType.Int).Value = tipoInventarioId;
                    sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    sqlCommand.Connection = con;
                    con.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        r.Success = true;
                        while (reader.Read())
                        {
                            lista.Add(new TomaInventarioConsolidadaDetalle
                            {
                                ArticuloId = int.Parse(reader["ArticuloId"].ToString()),
                                Articulo = reader["Articulo"].ToString(),
                                Cantidad = double.Parse(reader["Cantidad"].ToString()),
                                UnidadMedida = reader["UnidadMedida"].ToString(),
                                Codigo = reader["Codigo"].ToString(),
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
