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
    public class ArticuloRepository : IArticuloRepository
    {
        private Connection _bd;
        public Result<List<ArticuloModel>> obtenerArticulos(int tipoInventarioId,int areaId)
        {
            _bd = new Connection();
            List<ArticuloModel> lista = new List<ArticuloModel>();
            Result<List<ArticuloModel>> r = new Result<List<ArticuloModel>>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.Articulos, con);
                    sqlCommand.Parameters.AddWithValue("@TIPOINVENTARIOID", tipoInventarioId);
                    sqlCommand.Parameters.AddWithValue("@AREAID", areaId);
                    sqlCommand.Connection = con;
                    con.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ArticuloModel
                            {
                                ArticuloId = int.Parse(reader["ArticuloId"].ToString()),
                                Codigo = reader["Codigo"].ToString(),
                                Descripcion = reader["Descripcion"].ToString()
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

        public Result<List<ArticuloModel>> obtenerArticulosPorEmpresa(int empresaId)
        {
            _bd = new Connection();
            List<ArticuloModel> lista = new List<ArticuloModel>();
            Result<List<ArticuloModel>> r = new Result<List<ArticuloModel>>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.ArticulosPorEmpresa, con);
                    sqlCommand.Parameters.AddWithValue("@EMPRESAID", empresaId);
                    sqlCommand.Connection = con;
                    con.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ArticuloModel
                            {
                                ArticuloId = int.Parse(reader["ArticuloId"].ToString()),
                                Codigo = reader["Codigo"].ToString(),
                                Descripcion = reader["Descripcion"].ToString(),
                                Habilitado = bool.Parse(reader["Habilitado"].ToString())
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

        public Result<List<ArticuloModel>> obtenerArticulosMTM(int su)
        {
            _bd = new Connection();
            List<ArticuloModel> lista = new List<ArticuloModel>();
            Result<List<ArticuloModel>> r = new Result<List<ArticuloModel>>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.ArticulosMtm, con);
                    sqlCommand.Parameters.AddWithValue("@su", su);
                    sqlCommand.Connection = con;
                    con.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ArticuloModel
                            {
                                ArticuloId = int.Parse(reader["ArticuloId"].ToString()),
                                Codigo = reader["Codigo"].ToString(),
                                Descripcion = reader["Descripcion"].ToString(),
                                Barcode = reader["Barcode"].ToString(),
                                EmpresaId = int.Parse(reader["EmpresaId"].ToString()),
                                CategoriaId = int.Parse(reader["CategoriaId"].ToString()),
                                FamiliaId = int.Parse(reader["FamiliaId"].ToString()),
                                UnidadMedidaId = int.Parse(reader["UnidadMedidaId"].ToString()),
                                Empresa = reader["Empresa"].ToString(),
                                Categoria = reader["Categoria"].ToString(),
                                Familia = reader["Familia"].ToString(),
                                UnidadMedida = reader["UnidadMedida"].ToString(),
                                Habilitado = bool.Parse(reader["Habilitado"].ToString())
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

        public Result<int> crearArticuloMTM(ArticuloModel o)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.CrearArticuloMtm, con);
                    sqlCommand.Parameters.AddWithValue("@Codigo", o.Codigo);
                    sqlCommand.Parameters.AddWithValue("@Descripcion", o.Descripcion);
                    sqlCommand.Parameters.AddWithValue("@Barcode", o.Barcode);
                    sqlCommand.Parameters.AddWithValue("@EmpresaId", o.EmpresaId);
                    sqlCommand.Parameters.AddWithValue("@CategoriaId", o.CategoriaId);
                    sqlCommand.Parameters.AddWithValue("@FamiliaId", o.FamiliaId);
                    sqlCommand.Parameters.AddWithValue("@UnidadMedidaId", o.UnidadMedidaId);
                    sqlCommand.Parameters.AddWithValue("@Habilitado", o.Habilitado);
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

        public Result<int> actualizarArticuloMTM(ArticuloModel o)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.ActualizarArticuloMtm, con);
                    sqlCommand.Parameters.AddWithValue("@Codigo", o.Codigo);
                    sqlCommand.Parameters.AddWithValue("@Descripcion", o.Descripcion);
                    sqlCommand.Parameters.AddWithValue("@Barcode", o.Barcode);
                    sqlCommand.Parameters.AddWithValue("@EmpresaId", o.EmpresaId);
                    sqlCommand.Parameters.AddWithValue("@CategoriaId", o.CategoriaId);
                    sqlCommand.Parameters.AddWithValue("@FamiliaId", o.FamiliaId);
                    sqlCommand.Parameters.AddWithValue("@UnidadMedidaId", o.UnidadMedidaId);
                    sqlCommand.Parameters.AddWithValue("@ArticuloId", o.ArticuloId);
                    sqlCommand.Parameters.AddWithValue("@Habilitado", o.Habilitado);
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

        public Result<int> eliminarArticuloMTM(int id)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.EliminarArticuloMtm, con);
                    sqlCommand.Parameters.AddWithValue("@articuloId", id);
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

        public Result<int> cargarArticulosMTM(List<ArticuloModel> articulos)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();
            int res = 0;

            SqlConnection con = _bd.sqlConnection;
            foreach (var articulo in articulos)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(Queries.CrearArticuloMtm, con);
                    cmd.Parameters.Add("@Descripcion", SqlDbType.NVarChar).Value = articulo.Descripcion;
                    cmd.Parameters.Add("@Codigo", SqlDbType.NVarChar).Value = articulo.Codigo;
                    cmd.Parameters.Add("@Barcode", SqlDbType.NVarChar).Value = articulo.Barcode;
                    cmd.Parameters.Add("@EmpresaId", SqlDbType.Int).Value = articulo.EmpresaId;
                    cmd.Parameters.Add("@CategoriaId", SqlDbType.Int).Value = articulo.CategoriaId;
                    cmd.Parameters.Add("@FamiliaId", SqlDbType.Int).Value = articulo.FamiliaId;
                    cmd.Parameters.Add("@UnidadMedidaId", SqlDbType.Int).Value = articulo.UnidadMedidaId;
                    cmd.Parameters.Add("@Habilitado", SqlDbType.Bit).Value = articulo.Habilitado;
                    res = cmd.ExecuteNonQuery();
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

        
    }
}
