using inventario_api.Models;
using inventario_api.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Repository
{
    public class FamiliaRepository: IFamiliaRepository
    {
        private Connection _bd;

        public Result<List<FamiliaModel>> obtenerFamilias(int empresaId)
        {
            _bd = new Connection();
            List<FamiliaModel> lista = new List<FamiliaModel>();
            Result<List<FamiliaModel>> r = new Result<List<FamiliaModel>>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.Familias, con);
                    sqlCommand.Parameters.AddWithValue("@EMPRESAID", empresaId);
                    sqlCommand.Connection = con;
                    con.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new FamiliaModel
                            {
                                FamiliaId = int.Parse(reader["FamiliaId"].ToString()),
                                Descripcion = reader["Descripcion"].ToString(),
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
        public Result<List<FamiliaModel>> obtenerFamiliasMTM(int su)
        {
            _bd = new Connection();
            List<FamiliaModel> lista = new List<FamiliaModel>();
            Result<List<FamiliaModel>> r = new Result<List<FamiliaModel>>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.FamiliasMtm, con);
                    sqlCommand.Parameters.AddWithValue("@su", su);
                    sqlCommand.Connection = con;
                    con.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new FamiliaModel
                            {
                                FamiliaId = int.Parse(reader["FamiliaId"].ToString()),
                                Descripcion = reader["Descripcion"].ToString(),
                                Empresa = reader["Empresa"].ToString(),
                                EmpresaId = int.Parse(reader["EmpresaId"].ToString()),
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

        public Result<int> crearFamiliaMTM(FamiliaModel o)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.CrearFamiliaMtm, con);
                    sqlCommand.Parameters.AddWithValue("@DESCRIPCION", o.Descripcion);
                    sqlCommand.Parameters.AddWithValue("@EMPRESAID", o.EmpresaId);
                    sqlCommand.Parameters.AddWithValue("@CODIGO", o.Codigo);
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

        public Result<int> actualizarFamiliaMTM(FamiliaModel o)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.ActualizarFamiliaMtm, con);
                    sqlCommand.Parameters.AddWithValue("@DESCRIPCION", o.Descripcion);
                    sqlCommand.Parameters.AddWithValue("@EMPRESAID", o.EmpresaId);
                    sqlCommand.Parameters.AddWithValue("@FAMILIAID", o.FamiliaId);
                    sqlCommand.Parameters.AddWithValue("@CODIGO", o.Codigo);
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

        public Result<int> eliminarFamiliaMTM(int id)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.EliminarFamiliaMtm, con);
                    sqlCommand.Parameters.AddWithValue("@FAMILIAID", id);
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
