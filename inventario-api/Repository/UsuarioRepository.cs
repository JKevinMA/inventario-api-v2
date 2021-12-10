using inventario_api.Models;
using inventario_api.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Repository
{
    public class UsuarioRepository: IUsuarioRepository
    {
        private Connection _bd;
        public Result<UsuarioModel> Login(UsuarioLogin u)
        {
            _bd = new Connection();
            UsuarioModel usuario = null;
            Result<UsuarioModel> r = new Result<UsuarioModel>();
            
            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.Login, con);
                    sqlCommand.Parameters.AddWithValue("@usuario", u.Usuario);
                    sqlCommand.Parameters.AddWithValue("@clave", u.Clave);
                    sqlCommand.Connection = con;
                    con.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuario = new UsuarioModel()
                            {
                                UsuarioId = int.Parse(reader["UsuarioId"].ToString()),
                                EmpresaId = int.Parse(reader["EmpresaId"].ToString()),
                                Nombre = reader["Nombre"].ToString(),
                                Usuario = reader["Usuario"].ToString(),
                                Clave = reader["Clave"].ToString(),
                                Administrador = bool.Parse(reader["Administrador"].ToString()),
                                Supervisor = bool.Parse(reader["Supervisor"].ToString()),
                                Inventario = bool.Parse(reader["Inventario"].ToString()),
                            };
                        }
                        r.Success = true;
                        r.Response = usuario;
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

        public Result<List<UsuarioModel>> obtenerUsuariosMTM()
        {
            _bd = new Connection();
            List<UsuarioModel> lista = new List<UsuarioModel>();
            Result<List<UsuarioModel>> r = new Result<List<UsuarioModel>>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.UsuariosMtm, con);
                    sqlCommand.Connection = con;
                    con.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new UsuarioModel
                            {
                                UsuarioId = int.Parse(reader["UsuarioId"].ToString()),
                                EmpresaId = int.Parse(reader["EmpresaId"].ToString()),
                                Nombre = reader["Nombre"].ToString(),
                                Usuario = reader["Usuario"].ToString(),
                                Clave = reader["Clave"].ToString(),
                                Empresa = reader["Empresa"].ToString(),
                                Administrador = bool.Parse(reader["Administrador"].ToString()),
                                Supervisor = bool.Parse(reader["Supervisor"].ToString()),
                                Inventario = bool.Parse(reader["Inventario"].ToString()),
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

        public Result<List<UsuarioModel>> obtenerUsuariosEmpresa(int empresaId)
        {
            _bd = new Connection();
            List<UsuarioModel> lista = new List<UsuarioModel>();
            Result<List<UsuarioModel>> r = new Result<List<UsuarioModel>>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.Usuarios, con);
                    sqlCommand.Parameters.AddWithValue("@empresaId", empresaId);
                    sqlCommand.Connection = con;
                    con.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new UsuarioModel
                            {
                                UsuarioId = int.Parse(reader["UsuarioId"].ToString()),
                                EmpresaId = int.Parse(reader["EmpresaId"].ToString()),
                                Nombre = reader["Nombre"].ToString(),
                                Usuario = reader["Usuario"].ToString(),
                                Clave = reader["Clave"].ToString(),
                                Administrador = bool.Parse(reader["Administrador"].ToString()),
                                Supervisor = bool.Parse(reader["Supervisor"].ToString()),
                                Inventario = bool.Parse(reader["Inventario"].ToString()),
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

        public Result<int> crearUsuarioMTM(UsuarioModel o)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.CrearUsuarioMtm, con);
                    sqlCommand.Parameters.AddWithValue("@Nombre", o.Nombre);
                    sqlCommand.Parameters.AddWithValue("@Usuario", o.Usuario);
                    sqlCommand.Parameters.AddWithValue("@Clave", o.Clave);
                    sqlCommand.Parameters.AddWithValue("@Administrador", o.Administrador);
                    sqlCommand.Parameters.AddWithValue("@Supervisor", o.Supervisor);
                    sqlCommand.Parameters.AddWithValue("@Inventario", o.Inventario);
                    sqlCommand.Parameters.AddWithValue("@EmpresaId", o.EmpresaId);
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

        public Result<int> actualizarUsuarioMTM(UsuarioModel o)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.ActualizarUsuarioMtm , con);
                    sqlCommand.Parameters.AddWithValue("@Nombre", o.Nombre);
                    sqlCommand.Parameters.AddWithValue("@Usuario", o.Usuario);
                    sqlCommand.Parameters.AddWithValue("@Clave", o.Clave);
                    sqlCommand.Parameters.AddWithValue("@Administrador", o.Administrador);
                    sqlCommand.Parameters.AddWithValue("@Supervisor", o.Supervisor);
                    sqlCommand.Parameters.AddWithValue("@Inventario", o.Inventario);
                    sqlCommand.Parameters.AddWithValue("@EmpresaId", o.EmpresaId);
                    sqlCommand.Parameters.AddWithValue("@UsuarioId", o.UsuarioId);
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

        public Result<int> eliminarUsuarioMTM(int id)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.EliminarUsuarioMtm, con);
                    sqlCommand.Parameters.AddWithValue("@UsuarioId", id);
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
