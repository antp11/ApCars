using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UTN.WinForms.ApCars.Extensions;
using UTN.WinForms.ApCars.Interfaces;
using UTN.WinForms.ApCars.Layers.Entities;

namespace UTN.WinForms.ApCars.Layers.DAL
{
    internal class DALUsuario : IDALUsuario
    {
        private static readonly ILog _myLogControlEventos = LogManager.GetLogger("MyControlEventos");

        public bool Delete(string pLogin)
        {
            SqlCommand command = new SqlCommand();
            string msg = "";
            string sql = @"usp_DELETE_Usuario_ByID";
            double row = 0;
            try
            {
                command.Parameters.AddWithValue("@Login", pLogin);
                command.CommandText = sql;
                command.CommandType = CommandType.StoredProcedure;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    row = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
                }


                return row > 0 ? true : false;
            }
            catch (SqlException er)
            {
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(MethodBase.GetCurrentMethod(), er, command));
                throw new CustomException(msg.ToSqlServerDetailError(er));
            }
            catch (Exception er)
            {
                msg = msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod());
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }
        

        public IEnumerable<Usuario> GetAll()
        {
            string msg = "";
            SqlCommand command = new SqlCommand();
            IDataReader reader = null;
            Usuario oUsuario = null;
            IList<Usuario> lista = new List<Usuario>();
            try
            {
                command.CommandText = @"usp_SELECT_Usuario_All";
                command.CommandType = CommandType.StoredProcedure;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        oUsuario = new Usuario();
                        oUsuario.IdUsuario = reader["IdUsuario"].ToString();
                        oUsuario.IdRol = int.Parse(reader["IdRol"].ToString());
                        oUsuario.Nombre = reader["Nombre"].ToString();
                        oUsuario.Apellido1 = reader["Apellido1"].ToString();
                        oUsuario.Apellido2 = reader["Apellido2"].ToString();
                        oUsuario.Contrasenna = reader["Contrasenna"].ToString();
                        oUsuario.Estado = bool.Parse(reader["Estado"].ToString());
                        oUsuario.Foto = (byte[])reader["Foto"];

                        lista.Add(oUsuario);
                    }
                }

                return lista;
            }
            catch (SqlException er)
            {
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(MethodBase.GetCurrentMethod(), er, command));
                throw new CustomException(msg.ToSqlServerDetailError(er));
            }
            catch (Exception er)
            {
                msg = msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod());
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }

        public Usuario GetById(string pLogin)
        {
            SqlCommand command = new SqlCommand();
            IDataReader reader = null;
            Usuario oUsuario = null;
            string msg = "";
            try
            {
                command.CommandText =@"usp_SELECT_Usuario_ByID";
                command.Parameters.AddWithValue("@IdUsuario", pLogin);

                command.CommandType = CommandType.StoredProcedure;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        oUsuario = new Usuario();
                        oUsuario.IdUsuario = reader["IdUsuario"].ToString();
                        oUsuario.IdRol = int.Parse(reader["IdRol"].ToString());
                        oUsuario.Nombre = reader["Nombre"].ToString();
                        oUsuario.Apellido1 = reader["Apellido1"].ToString();
                        oUsuario.Apellido2 = reader["Apellido2"].ToString();
                        oUsuario.Contrasenna = reader["Contrasenna"].ToString();
                        oUsuario.Estado = bool.Parse(reader["Estado"].ToString());
                        oUsuario.Foto = (byte[])reader["Foto"];

                    }
                }

                return oUsuario;
            }
            catch (SqlException er)
            {
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(MethodBase.GetCurrentMethod(), er, command));
                throw new CustomException(msg.ToSqlServerDetailError(er));
            }
            catch (Exception er)
            {
                msg = msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod());
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }

        public Usuario Login(string pLogin, string pPassword)
        {
            SqlCommand command = new SqlCommand();
            IDataReader reader = null;
            Usuario oUsuario = null;
            string msg = "";
            try
            {
                command.CommandText = @"SELECT * FROM dbo.Usuario WITH (ROWLOCK) WHERE IdUsuario = @IdUsuario AND Contrasenna = @Contrasenna";
                command.Parameters.AddWithValue("@IdUsuario", pLogin);
                command.Parameters.AddWithValue("@Contrasenna", pPassword);
                command.CommandType = CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        oUsuario = new Usuario();
                        oUsuario.IdUsuario = reader["IdUsuario"].ToString();
                        oUsuario.IdRol = int.Parse(reader["IdRol"].ToString());
                        oUsuario.Nombre = reader["Nombre"].ToString();
                        oUsuario.Apellido1 = reader["Apellido1"].ToString();
                        oUsuario.Apellido2 = reader["Apellido2"].ToString();
                        oUsuario.Contrasenna = reader["Contrasenna"].ToString();
                        oUsuario.Estado = bool.Parse(reader["Estado"].ToString());
                        oUsuario.Foto = (byte[])reader["Foto"];
                    }
                }

                return oUsuario;
            }
            catch (SqlException er)
            {
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(MethodBase.GetCurrentMethod(), er, command));
                throw new CustomException(msg.ToSqlServerDetailError(er));
            }
            catch (Exception er)
            {
                msg = msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod());
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }

        public Usuario Save(Usuario pUsuario)
        {

            string msg = "";
            SqlCommand command = new SqlCommand();
            Usuario oUsuario = null;
            string sql = @"usp_INSERT_Usuario";
            double row = 0;
            try
            {

                command.Parameters.AddWithValue("@IdUsuario", pUsuario.IdUsuario);
                command.Parameters.AddWithValue("@IdRol", Convert.ToInt32(pUsuario.IdRol));
                command.Parameters.AddWithValue("@Nombre", pUsuario.Nombre);
                command.Parameters.AddWithValue("@Apellido1", pUsuario.Apellido1);
                command.Parameters.AddWithValue("@Apellido2", pUsuario.Apellido2);
                command.Parameters.AddWithValue("@Contrasenna", pUsuario.Contrasenna);
                command.Parameters.AddWithValue("@Estado", (bool)pUsuario.Estado);
                command.Parameters.AddWithValue("@Foto", pUsuario.Foto.ToArray());
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = sql;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    row = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
                }
                if (row > 0)
                    oUsuario = GetById(pUsuario.IdUsuario);

                return oUsuario;

            }
            catch (SqlException er)
            {
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(MethodBase.GetCurrentMethod(), er, command));
                throw new CustomException(msg.ToSqlServerDetailError(er));
            }
            catch (Exception er)
            {
                msg = msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod());
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }

        }

        public Usuario Update(Usuario pUsuario)
        {
            string msg = "";
            SqlCommand command = new SqlCommand();
            Usuario oUsuario = null;
            string sql = @"usp_UPDATE_Usuario";
            double row = 0;
            try
            {

                command.Parameters.AddWithValue("@IdUsuario", pUsuario.IdUsuario);
                command.Parameters.AddWithValue("@IdRol", pUsuario.IdRol);
                command.Parameters.AddWithValue("@Nombre", pUsuario.Nombre);
                command.Parameters.AddWithValue("@Apellido1", pUsuario.Apellido1);
                command.Parameters.AddWithValue("@Apellido2", pUsuario.Apellido2);
                command.Parameters.AddWithValue("@Contrasenna", pUsuario.Contrasenna);
                command.Parameters.AddWithValue("@Estado", (bool)pUsuario.Estado);
                command.Parameters.AddWithValue("@Foto", pUsuario.Foto.ToArray());
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = sql;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    row = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
                }
                if (row > 0)
                    oUsuario = GetById(pUsuario.IdUsuario);

                return oUsuario;

            }
            catch (SqlException er)
            {
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(MethodBase.GetCurrentMethod(), er, command));
                throw new CustomException(msg.ToSqlServerDetailError(er));
            }
            catch (Exception er)
            {
                msg = msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod());
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }
    }
}
