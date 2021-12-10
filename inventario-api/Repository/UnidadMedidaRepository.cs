using inventario_api.Models;
using inventario_api.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace inventario_api.Repository
{
    public class UnidadMedidaRepository: IUnidadMedidaRepository
    {
        private Connection _bd;

        public Result<List<UnidadMedidaModel>> obtenerUnidadesMedidaMTM()
        {
            _bd = new Connection();
            List<UnidadMedidaModel> lista = new List<UnidadMedidaModel>();
            Result<List<UnidadMedidaModel>> r = new Result<List<UnidadMedidaModel>>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.UnidadesMedidaMtm, con);
                    sqlCommand.Connection = con;
                    con.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new UnidadMedidaModel
                            {
                                UnidadMedidaId = int.Parse(reader["UnidadMedidaId"].ToString()),
                                Descripcion = reader["Descripcion"].ToString(),
                                CodigoSunat = reader["CodigoSunat"].ToString()
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

        public Result<int> crearUnidadMedidaMTM(UnidadMedidaModel o)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.CrearUnidadMedidaMtm, con);
                    sqlCommand.Parameters.AddWithValue("@DESCRIPCION", o.Descripcion);
                    sqlCommand.Parameters.AddWithValue("@CODIGOSUNAT", o.CodigoSunat);
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

        public Result<int> actualizarUnidadMedidaMTM(UnidadMedidaModel o)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.ActualizarUnidadMedidaMtm, con);
                    sqlCommand.Parameters.AddWithValue("@DESCRIPCION", o.Descripcion);
                    sqlCommand.Parameters.AddWithValue("@CODIGOSUNAT", o.CodigoSunat);
                    sqlCommand.Parameters.AddWithValue("@UNIDADMEDIDAID", o.UnidadMedidaId);
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

        public Result<int> eliminarUnidadMedidaMTM(int id)
        {
            _bd = new Connection();
            Result<int> r = new Result<int>();

            using (SqlConnection con = _bd.sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(Queries.EliminarUnidadMedidaMtm, con);
                    sqlCommand.Parameters.AddWithValue("@UNIDADMEDIDAID", id);
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
