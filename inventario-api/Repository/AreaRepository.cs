using inventario_api.Models;
using inventario_api.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Repository
{
    public class AreaRepository: IAreaRepository
    {
        private Connection _bd;
        public Result<List<AreaModel>> obtenerAreas(int almacenId)
        {
            _bd = new Connection();
            List<AreaModel> lista = new List<AreaModel>();
            Result<List<AreaModel>> r = new Result<List<AreaModel>>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.Areas, con);
                    sqlCommand.Parameters.AddWithValue("@almacenid", almacenId);
                    sqlCommand.Connection = con;
                    con.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new AreaModel
                            {
                                AreaId = int.Parse(reader["AreaId"].ToString()),
                                AlmacenId = int.Parse(reader["AlmacenId"].ToString()),
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

        public Result<List<AreaModel>> obtenerAreasMTM(int su)
        {
            _bd = new Connection();
            List<AreaModel> lista = new List<AreaModel>();
            Result<List<AreaModel>> r = new Result<List<AreaModel>>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.AreasMtm, con);
                    sqlCommand.Parameters.AddWithValue("@su", su);
                    sqlCommand.Connection = con;
                    con.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new AreaModel
                            {
                                AreaId = int.Parse(reader["AreaId"].ToString()),
                                Descripcion = reader["Descripcion"].ToString(),
                                AlmacenId = int.Parse(reader["AlmacenId"].ToString()),
                                Almacen = reader["Almacen"].ToString(),
                                LocalId = int.Parse(reader["LocalId"].ToString()),
                                Local = reader["Local"].ToString(),
                                EmpresaId = int.Parse(reader["EmpresaId"].ToString()),
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

        public Result<int> crearAreaMTM(AreaModel o)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.CrearAreaMtm, con);
                    sqlCommand.Parameters.AddWithValue("@Descripcion", o.Descripcion);
                    sqlCommand.Parameters.AddWithValue("@AlmacenId", o.AlmacenId);
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

        public Result<int> actualizarAreaMTM(AreaModel o)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.ActualizarAreaMtm, con);
                    sqlCommand.Parameters.AddWithValue("@Descripcion", o.Descripcion);
                    sqlCommand.Parameters.AddWithValue("@AlmacenId", o.AlmacenId);
                    sqlCommand.Parameters.AddWithValue("@AreaId", o.AreaId);
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

        public Result<int> eliminarAreaMTM(int id)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.EliminarAreaMtm, con);
                    sqlCommand.Parameters.AddWithValue("@AreaId", id);
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
