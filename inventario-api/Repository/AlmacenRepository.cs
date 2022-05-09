using inventario_api.Models;
using inventario_api.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Repository
{
    public class AlmacenRepository: IAlmacenRepository
    {
        private Connection _bd;
        public Result<List<AlmacenModel>> obtenerAlmacenes(int localId)
        {
            _bd = new Connection();
            List<AlmacenModel> lista = new List<AlmacenModel>();
            Result<List<AlmacenModel>> r = new Result<List<AlmacenModel>>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.Almacenes, con);
                    sqlCommand.Parameters.AddWithValue("@LOCALID", localId);
                    sqlCommand.Connection = con;
                    con.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new AlmacenModel
                            {
                                AlmacenId = int.Parse(reader["AlmacenId"].ToString()),
                                Descripcion = reader["Descripcion"].ToString(),
                                LocalId = int.Parse(reader["LocalId"].ToString()),
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
        public Result<List<AlmacenModel>> obtenerAlmacenesMTM(int su)
        {
            _bd = new Connection();
            List<AlmacenModel> lista = new List<AlmacenModel>();
            Result<List<AlmacenModel>> r = new Result<List<AlmacenModel>>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.AlmacenesMtm, con);
                    sqlCommand.Parameters.AddWithValue("@su", su);
                    sqlCommand.Connection = con;
                    con.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new AlmacenModel
                            {
                                AlmacenId = int.Parse(reader["AlmacenId"].ToString()),
                                Descripcion = reader["Descripcion"].ToString(),
                                LocalId = int.Parse(reader["LocalId"].ToString()),
                                EmpresaId = int.Parse(reader["EmpresaId"].ToString()),
                                Local = reader["Local"].ToString(),
                                Empresa = reader["Empresa"].ToString(),
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

        public Result<int> crearAlmacenMTM(AlmacenModel o)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.CrearAlmacenMtm, con);
                    sqlCommand.Parameters.AddWithValue("@Descripcion", o.Descripcion);
                    sqlCommand.Parameters.AddWithValue("@LocalId", o.LocalId);
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

        public Result<int> actualizarAlmacenMTM(AlmacenModel o)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.ActualizarAlmacenMtm, con);
                    sqlCommand.Parameters.AddWithValue("@AlmacenId", o.AlmacenId);
                    sqlCommand.Parameters.AddWithValue("@Descripcion", o.Descripcion);
                    sqlCommand.Parameters.AddWithValue("@LocalId", o.LocalId);
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

        public Result<int> eliminarAlmacenMTM(int id)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.EliminarAlmacenMtm, con);
                    sqlCommand.Parameters.AddWithValue("@AlmacenId", id);
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
