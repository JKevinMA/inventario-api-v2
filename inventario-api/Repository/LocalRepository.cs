using inventario_api.Models;
using inventario_api.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Repository
{
    public class LocalRepository: ILocalRepository
    {
        private Connection _bd;
        public Result<List<LocalModel>> obtenerLocales(int empresaId)
        {
            _bd = new Connection();
            List<LocalModel> lista = new List<LocalModel>();
            Result<List<LocalModel>> r = new Result<List<LocalModel>>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.Locales, con);
                    sqlCommand.Parameters.AddWithValue("@empresaid", empresaId);
                    sqlCommand.Connection = con;
                    con.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add( new LocalModel
                            {
                                LocalId = int.Parse(reader["LocalId"].ToString()),
                                EmpresaId = int.Parse(reader["EmpresaId"].ToString()),
                                Descripcion = reader["Descripcion"].ToString(),
                                Habilitado = bool.Parse(reader["habilitado"].ToString())
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

        public Result<List<LocalModel>> obtenerLocalesMTM(int su)
        {
            _bd = new Connection();
            List<LocalModel> lista = new List<LocalModel>();
            Result<List<LocalModel>> r = new Result<List<LocalModel>>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.LocalesMtm, con);
                    sqlCommand.Parameters.AddWithValue("@su", su);

                    sqlCommand.Connection = con;
                    con.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new LocalModel
                            {
                                LocalId = int.Parse(reader["LocalId"].ToString()),
                                EmpresaId = int.Parse(reader["EmpresaId"].ToString()),
                                Descripcion = reader["Descripcion"].ToString(),
                                Empresa = reader["Empresa"].ToString(),
                                Habilitado = bool.Parse(reader["habilitado"].ToString())
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

        public Result<int> crearLocalMTM(LocalModel o)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.CrearLocalMtm, con);
                    sqlCommand.Parameters.AddWithValue("@DESCRIPCION", o.Descripcion);
                    sqlCommand.Parameters.AddWithValue("@EMPRESAID", o.EmpresaId);
                    sqlCommand.Parameters.AddWithValue("@HABILITADO", o.Habilitado);
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

        public Result<int> actualizarLocalMTM(LocalModel o)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.ActualizarLocalMtm, con);
                    sqlCommand.Parameters.AddWithValue("@DESCRIPCION", o.Descripcion);
                    sqlCommand.Parameters.AddWithValue("@EMPRESAID", o.EmpresaId);
                    sqlCommand.Parameters.AddWithValue("@LOCALID", o.LocalId);
                    sqlCommand.Parameters.AddWithValue("@HABILITADO", o.Habilitado);
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

        public Result<int> eliminarLocalMTM(int id)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.EliminarLocalMtm, con);
                    sqlCommand.Parameters.AddWithValue("@LOCALID", id);
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
