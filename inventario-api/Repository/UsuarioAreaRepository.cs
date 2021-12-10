using inventario_api.Models;
using inventario_api.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Repository
{
    public class UsuarioAreaRepository: IUsuarioAreaRepository
    {
        private Connection _bd;
        public Result<List<UsuarioAreaModel>> obtenerUsuariosAreaMTM()
        {
            _bd = new Connection();
            List<UsuarioAreaModel> lista = new List<UsuarioAreaModel>();
            Result<List<UsuarioAreaModel>> r = new Result<List<UsuarioAreaModel>>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.UsuariosAreaMtm, con);
                    sqlCommand.Connection = con;
                    con.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new UsuarioAreaModel
                            {
                                UsuarioId = int.Parse(reader["UsuarioId"].ToString()),
                                AreaId = int.Parse(reader["AreaId"].ToString()),
                                AlmacenId = int.Parse(reader["AlmacenId"].ToString()),
                                LocalId = int.Parse(reader["LocalId"].ToString()),
                                EmpresaId = int.Parse(reader["EmpresaId"].ToString()),
                                Usuario = reader["Usuario"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Area = reader["Area"].ToString(),
                                Almacen = reader["Almacen"].ToString(),
                                Local =reader["Local"].ToString(),
                                Empresa = reader["Empresa"].ToString(),
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

        public Result<int> crearUsuarioAreaMTM(UsuarioAreaModel o)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.CrearUsuarioAreaMtm, con);
                    sqlCommand.Parameters.AddWithValue("@UsuarioId", o.UsuarioId);
                    sqlCommand.Parameters.AddWithValue("@AreaId", o.AreaId);
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

        public Result<int> eliminarUsuarioAreaMTM(int usuarioId,int areaId)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.EliminarUsuarioAreaMtm, con);
                    sqlCommand.Parameters.AddWithValue("@USUARIOID", usuarioId);
                    sqlCommand.Parameters.AddWithValue("@AREAID", areaId);
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
