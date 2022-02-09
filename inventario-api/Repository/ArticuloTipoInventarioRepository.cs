using inventario_api.Models;
using inventario_api.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Repository
{
    public class ArticuloTipoInventarioRepository: IArticuloTipoInventarioRepository
    {
        private Connection _bd;
        public Result<List<ArticuloTipoInventarioModel>> obtenerArticulosTipoInventarioMTM(int su)
        {
            _bd = new Connection();
            List<ArticuloTipoInventarioModel> lista = new List<ArticuloTipoInventarioModel>();
            Result<List<ArticuloTipoInventarioModel>> r = new Result<List<ArticuloTipoInventarioModel>>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.ArticulosTipoInventarioMtm, con);
                    sqlCommand.Parameters.AddWithValue("@su", su);
                    sqlCommand.Connection = con;
                    con.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ArticuloTipoInventarioModel
                            {
                                ArticuloId = int.Parse(reader["ArticuloId"].ToString()),
                                AreaId = int.Parse(reader["AreaId"].ToString()),
                                TipoInventarioId = int.Parse(reader["TipoInventarioId"].ToString()),
                                Orden = int.Parse(reader["Orden"].ToString()),
                                Localizacion = reader["Localizacion"].ToString(),
                                Codigo = reader["Codigo"].ToString(),
                                Articulo = reader["Articulo"].ToString(),
                                Area = reader["Area"].ToString(),
                                Almacen = reader["Almacen"].ToString(),
                                AlmacenId = int.Parse(reader["AlmacenId"].ToString()),
                                Local = reader["Local"].ToString(),
                                LocalId = int.Parse(reader["LocalId"].ToString()),
                                Empresa = reader["Empresa"].ToString(),
                                EmpresaId = int.Parse(reader["EmpresaId"].ToString()),
                                TipoInventario = reader["TipoInventario"].ToString(),
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

        public Result<int> crearArticuloTipoInventarioMTM(ArticuloTipoInventarioModel o)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.CrearArticuloTipoInventarioMtm, con);
                    sqlCommand.Parameters.AddWithValue("@ArticuloId", o.ArticuloId);
                    sqlCommand.Parameters.AddWithValue("@AreaId", o.AreaId);
                    sqlCommand.Parameters.AddWithValue("@TipoInventarioId", o.TipoInventarioId);
                    sqlCommand.Parameters.AddWithValue("@Orden", o.Orden);
                    sqlCommand.Parameters.AddWithValue("@Localizacion", o.Localizacion);
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

        public Result<int> actualizarArticuloTipoInventarioMTM(ArticuloTipoInventarioModel o)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.ActualizarArticuloTipoInventarioMtm, con);
                    sqlCommand.Parameters.AddWithValue("@ArticuloId", o.ArticuloId);
                    sqlCommand.Parameters.AddWithValue("@AreaId", o.AreaId);
                    sqlCommand.Parameters.AddWithValue("@TipoInventarioId", o.TipoInventarioId);
                    sqlCommand.Parameters.AddWithValue("@Orden", o.Orden);
                    sqlCommand.Parameters.AddWithValue("@Localizacion", o.Localizacion);
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

        public Result<int> eliminarArticuloTipoInventarioMTM(int articuloId,int areaId,int tipoInventarioId)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.EliminarArticuloTipoInventarioMtm, con);
                    sqlCommand.Parameters.AddWithValue("@ArticuloId", articuloId);
                    sqlCommand.Parameters.AddWithValue("@AreaId", areaId);
                    sqlCommand.Parameters.AddWithValue("@TipoInventarioId", tipoInventarioId);
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
