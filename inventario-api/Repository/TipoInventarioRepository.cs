using inventario_api.Models;
using inventario_api.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Repository
{
    public class TipoInventarioRepository: ITipoInventarioRepository
    {
        private Connection _bd;
        public Result<List<TipoInventarioModel>> obtenerTiposInventario()
        {
            _bd = new Connection();
            List<TipoInventarioModel> lista = new List<TipoInventarioModel>();
            Result<List<TipoInventarioModel>> r = new Result<List<TipoInventarioModel>>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.TiposInventario, con);
                    sqlCommand.Connection = con;
                    con.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new TipoInventarioModel
                            {
                                TipoInventarioId = int.Parse(reader["TipoInventarioId"].ToString()),
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

        public Result<List<TipoInventarioModel>> obtenerTiposInventarioMTM()
        {
            _bd = new Connection();
            List<TipoInventarioModel> lista = new List<TipoInventarioModel>();
            Result<List<TipoInventarioModel>> r = new Result<List<TipoInventarioModel>>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.TiposInventarioMtm, con);
                    sqlCommand.Connection = con;
                    con.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new TipoInventarioModel
                            {
                                TipoInventarioId = int.Parse(reader["TipoInventarioId"].ToString()),
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

        public Result<int> crearTipoInventarioMTM(TipoInventarioModel o)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.CrearTipoInventarioMtm, con);
                    sqlCommand.Parameters.AddWithValue("@DESCRIPCION", o.Descripcion);
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

        public Result<int> actualizarTipoInventarioMTM(TipoInventarioModel o)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.ActualizarTipoInventarioMtm, con);
                    sqlCommand.Parameters.AddWithValue("@DESCRIPCION", o.Descripcion);
                    sqlCommand.Parameters.AddWithValue("@TIPOINVENTARIOID", o.TipoInventarioId);
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

        public Result<int> eliminarTipoInventarioMTM(int id)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.EliminarTipoInventarioMtm, con);
                    sqlCommand.Parameters.AddWithValue("@TIPOINVENTARIOID", id);
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
