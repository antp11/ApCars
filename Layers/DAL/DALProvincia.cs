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
    internal class DALProvincia : IDALProvincia
    {
        private static readonly ILog _myLogControlEventos = LogManager.GetLogger("MyControlEventos");

        public bool Delete(int pId)
        {

            SqlCommand command = new SqlCommand();
            string msg = "";
            string sql = @"usp_DELETE_Provincia_ByID";
            double row = 0;
            try
            {
                command.Parameters.AddWithValue("@IdProvincia", pId);
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

        public List<Provincia> GetAll()
        {
            string msg = "";
            IDataReader reader = null;
            List<Provincia> lista = new List<Provincia>();
            SqlCommand command = new SqlCommand();

            string sql = @"usp_SELECT_Provincia_All";
            command.CommandText = sql;
            command.CommandType = CommandType.StoredProcedure;

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        // Mapping 
                        Provincia oProvincia = new Provincia();
                        oProvincia.IdProvincia = int.Parse(reader["IdProvincia"].ToString());
                        oProvincia.Descripcion = reader["DescripcionProvincia"].ToString();

                        lista.Add(oProvincia);
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

        public Provincia GetById(int pId)
        {
            string msg = "";
            IDataReader reader = null;
            Provincia oProvincia = null;
            SqlCommand command = new SqlCommand();

            string sql = @"usp_SELECT_Provincia_ByID";
            command.Parameters.AddWithValue("@IdProvincia", pId);
            command.CommandText = sql;
            command.CommandType = CommandType.StoredProcedure;

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        // Mapping 
                        oProvincia = new Provincia();
                        oProvincia.IdProvincia = int.Parse(reader["IdProvincia"].ToString());
                        oProvincia.Descripcion = reader["DescripcionProvincia"].ToString();


                    }
                }

                return oProvincia;
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

        public Provincia Save(Provincia pProvincia)
        {
           
            string msg = "";
            SqlCommand command = new SqlCommand();
            Provincia oProvincia = null;

            try
            {
                string sql = @"usp_INSERT_Provincia";

                command.Parameters.AddWithValue("@IdProvincia", pProvincia.IdProvincia);
                command.Parameters.AddWithValue("@DescripcionProvincia", pProvincia.Descripcion);

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = sql;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    var row = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);

                    if (row > 0)
                        oProvincia = GetById(pProvincia.IdProvincia);
                }
                return oProvincia;

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

        public Provincia Update(Provincia pProvincia)
        {

            string msg = "";
            SqlCommand command = new SqlCommand();
            Provincia oProvincia = null;

            try
            {
                string sql = @"usp_UPDATE_Provincia";

                command.Parameters.AddWithValue("@IdProvincia", pProvincia.IdProvincia);
                command.Parameters.AddWithValue("@DescripcionProvincia", pProvincia.Descripcion);

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = sql;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    var row = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);

                    if (row > 0)
                        oProvincia = GetById(pProvincia.IdProvincia);
                }
                return oProvincia;

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

