using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UTN.WinForms.ApCars.Enums;
using UTN.WinForms.ApCars.Extensions;
using UTN.WinForms.ApCars.Interfaces;
using UTN.WinForms.ApCars.Layers.Entities;

namespace UTN.WinForms.ApCars.Layers.DAL
{

    internal class DALCliente : IDALCliente
    {
        private static readonly ILog _myLogControlEventos = LogManager.GetLogger("MyControlEventos");
        public async Task<bool> Delete(string IdCliente)
        {
            SqlCommand command = new SqlCommand();
            string msg = "";
            string sql = @"usp_DELETE_Cliente_ByID";
            double row = 0;
            try
            {
                command.Parameters.AddWithValue("@IdCliente", IdCliente);
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

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            string msg = "";
            SqlCommand command = new SqlCommand();
            List<Cliente> lista = new List<Cliente>();
            try
            {
                command.CommandText = @"usp_SELECT_Cliente_All";
                command.CommandType = CommandType.StoredProcedure;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    using (SqlDataReader reader = await db.ExecuteReaderAsync(command))
                    {
                        // Iterar en todas las filas 
                        while (await reader.ReadAsync())
                        {
                            Cliente oCliente = new Cliente();
                            oCliente.IdCliente = reader["IdCliente"].ToString();
                            oCliente.IdProvincia = int.Parse(reader["IdProvincia"].ToString());
                            oCliente.TipoCliente = (TipoCliente)Enum.Parse(typeof(TipoCliente), reader["TipoCliente"].ToString());
                            oCliente.Nombre = reader["Nombre"].ToString();
                            oCliente.Apellido1 = reader["Apellido1"].ToString();
                            oCliente.Apellido2 = reader["Apellido2"].ToString();
                            oCliente.Sexo = int.Parse(reader["Sexo"].ToString());
                            oCliente.Correo = reader["Correo"].ToString();
                            oCliente.Direccion = reader["Direccion"].ToString();
                            oCliente.Telefono = reader["Telefono"].ToString();
                            oCliente.Foto = (byte[])reader["Foto"];

                            lista.Add(oCliente);
                        }
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


        public Cliente GetById(string IdCliente)
        {

            SqlCommand command = new SqlCommand();
            IDataReader reader = null;
            Cliente oCliente = null;
            string msg = "";
            try
            {
                command.CommandText = @"usp_SELECT_Cliente_ByID";
                command.Parameters.AddWithValue("@IdCliente", IdCliente);

                command.CommandType = CommandType.StoredProcedure;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        oCliente = new Cliente();
                        oCliente.IdCliente = reader["IdCliente"].ToString();
                        oCliente.IdProvincia = int.Parse(reader["IdProvincia"].ToString());
                        oCliente.TipoCliente = (TipoCliente)Enum.Parse(typeof(TipoCliente), reader["TipoCliente"].ToString());
                        oCliente.Nombre = reader["Nombre"].ToString();
                        oCliente.Apellido1 = reader["Apellido1"].ToString();
                        oCliente.Apellido2 = reader["Apellido2"].ToString();
                        oCliente.Sexo = int.Parse(reader["Sexo"].ToString());
                        oCliente.Correo = reader["Correo"].ToString();
                        oCliente.Direccion = reader["Direccion"].ToString();
                        oCliente.Telefono = reader["Telefono"].ToString();
                        oCliente.Foto = (byte[])reader["Foto"];

                    }
                }

                return oCliente;
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

        public async Task<Cliente> Save(Cliente pCliente)
        {

            string msg = "";
            SqlCommand command = new SqlCommand();
            Cliente oCliente = null;
            string sql = @"usp_INSERT_Cliente";

            try
            {
                command.Parameters.AddWithValue("@IdCliente", pCliente.IdCliente);
                command.Parameters.AddWithValue("@IdProvincia", pCliente.IdProvincia);
                command.Parameters.AddWithValue("@TipoCliente", pCliente.TipoCliente);
                command.Parameters.AddWithValue("@Nombre", pCliente.Nombre);
                command.Parameters.AddWithValue("@Apellido1", pCliente.Apellido1);
                command.Parameters.AddWithValue("@Apellido2", pCliente.Apellido2);
                command.Parameters.AddWithValue("@Sexo", pCliente.Sexo);
                command.Parameters.AddWithValue("@Correo", pCliente.Correo);
                command.Parameters.AddWithValue("@Direccion", pCliente.Direccion);
                command.Parameters.AddWithValue("@Telefono", pCliente.Telefono);
                command.Parameters.AddWithValue("@Foto", pCliente.Foto);

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = sql;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    var rows = await db.ExecuteNonQueryAsync(command, IsolationLevel.ReadCommitted);

                    // Si devuelve filas quiere decir que se salvo entonces extraerlo
                    if (rows > 0)
                        oCliente = this.GetById(pCliente.IdCliente);
                }
                return oCliente;

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

        public async Task<Cliente> Update(Cliente pCliente)
        {

            string msg = "";
            SqlCommand command = new SqlCommand();
            Cliente oCliente = null;
            int rows = 0;
            string sql = @"usp_UPDATE_Cliente";

            try
            {
                command.Parameters.AddWithValue("@IdCliente", pCliente.IdCliente);
                command.Parameters.AddWithValue("@IdProvincia", pCliente.IdProvincia);
                command.Parameters.AddWithValue("@TipoCliente", pCliente.TipoCliente);
                command.Parameters.AddWithValue("@Nombre", pCliente.Nombre);
                command.Parameters.AddWithValue("@Apellido1", pCliente.Apellido1);
                command.Parameters.AddWithValue("@Apellido2", pCliente.Apellido2);
                command.Parameters.AddWithValue("@Sexo", pCliente.Sexo);
                command.Parameters.AddWithValue("@Correo", pCliente.Correo);
                command.Parameters.AddWithValue("@Direccion", pCliente.Direccion);
                command.Parameters.AddWithValue("@Telefono", pCliente.Telefono);
                command.Parameters.AddWithValue("@Foto", pCliente.Foto);

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = sql;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    rows = await db.ExecuteNonQueryAsync(command, IsolationLevel.ReadCommitted);
                }
                if (rows > 0)
                    oCliente = GetById(oCliente.IdCliente);

                return oCliente;

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
