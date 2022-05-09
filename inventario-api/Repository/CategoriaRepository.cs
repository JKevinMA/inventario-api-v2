using inventario_api.Models;
using inventario_api.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Repository
{
    public class CategoriaRepository: ICategoriaRepository
    {
        private Connection _bd;

        public Result<List<CategoriaModel>> obtenerCategorias(int empresaId)
        {
            _bd = new Connection();
            List<CategoriaModel> lista = new List<CategoriaModel>();
            Result<List<CategoriaModel>> r = new Result<List<CategoriaModel>>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.Categorias, con);
                    sqlCommand.Parameters.AddWithValue("@EMPRESAID", empresaId);
                    sqlCommand.Connection = con;
                    con.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new CategoriaModel
                            {
                                CategoriaId = int.Parse(reader["CategoriaId"].ToString()),
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
        public Result<List<CategoriaModel>> obtenerCategoriasMTM(int su)
        {
            _bd = new Connection();
            List<CategoriaModel> lista = new List<CategoriaModel>();
            Result<List<CategoriaModel>> r = new Result<List<CategoriaModel>>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.CategoriasMtm, con);
                    sqlCommand.Parameters.AddWithValue("@su", su);
                    sqlCommand.Connection = con;
                    con.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new CategoriaModel
                            {
                                CategoriaId = int.Parse(reader["CategoriaId"].ToString()),
                                Descripcion = reader["Descripcion"].ToString(),
                                EmpresaId = int.Parse(reader["EmpresaId"].ToString()),
                                Empresa = reader["Empresa"].ToString(),
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

        public Result<int> crearCategoriaMTM(CategoriaModel o)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.CrearCategoriaMtm, con);
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

        public Result<int> actualizarCategoriaMTM(CategoriaModel o)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.ActualizarCategoriaMtm, con);
                    sqlCommand.Parameters.AddWithValue("@DESCRIPCION", o.Descripcion);
                    sqlCommand.Parameters.AddWithValue("@EMPRESAID", o.EmpresaId);
                    sqlCommand.Parameters.AddWithValue("@CATEGORIAID", o.CategoriaId);
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

        public Result<int> eliminarCategoriaMTM(int id)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.EliminarCategoriaMtm, con);
                    sqlCommand.Parameters.AddWithValue("@CATEGORIAID", id);
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
