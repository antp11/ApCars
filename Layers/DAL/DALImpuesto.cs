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

namespace UTN.WinForms.ApCars.Layers.BLL
{
    internal class DALImpuesto : IDALImpuesto
    {
        private static readonly ILog _myLogControlEventos = LogManager.GetLogger("MyControlEventos");

        public bool Delete(DateTime pId)
        {
            SqlCommand command = new SqlCommand();
            string msg = "";
            string sql = @"usp_DELETE_Impuesto_ByID";
            double row = 0;
            try
            {
                command.Parameters.AddWithValue("@IdFecha", pId);
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

        public List<Impuesto> GetAll()
        {
            IDataReader reader = null;
            List<Impuesto> lista = new List<Impuesto>();
            Impuesto oImpuesto = null;
            SqlCommand command = new SqlCommand();
            string msg = "";
            try
            {
                string sql = @"usp_SELECT_Impuesto_All";
                command.CommandText = sql;
                command.CommandType = CommandType.StoredProcedure;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);
                    // Si devolvió filas
                    while (reader.Read())
                    {
                        oImpuesto = new Impuesto();
                        oImpuesto.IdFecha = Convert.ToDateTime(reader["IdFecha"].ToString());
                        oImpuesto.Porcentaje = Convert.ToDouble(reader["Porcentaje"].ToString());


                        lista.Add(oImpuesto);
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

        public Impuesto GetById(DateTime pId)
        {
            string msg = "";
            IDataReader reader = null;
            Impuesto oImpuesto = null;
            SqlCommand command = new SqlCommand();
            string sql = @"usp_SELECT_Impuesto_ByID";

            try
            {
                command.Parameters.AddWithValue("@IdFecha", pId);
                command.CommandText = sql;
                command.CommandType = CommandType.StoredProcedure;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {

                        oImpuesto = new Impuesto();
                        oImpuesto.IdFecha = Convert.ToDateTime(reader["IdFecha"].ToString());
                        oImpuesto.Porcentaje = Convert.ToDouble(reader["Porcentaje"].ToString());


                    }
                }
                return oImpuesto;
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

        public Impuesto GetImpuesto()
        {
            IDataReader reader = null;
            SqlCommand command = new SqlCommand();
            Impuesto oImpuesto = new Impuesto();
            string sql = @" select  * from Impuesto WITH (HOLDLock)";
            string msg = "";
            try
            {
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        oImpuesto.IdFecha = Convert.ToDateTime(reader["IdFecha"].ToString());
                        oImpuesto.Porcentaje = Convert.ToDouble(reader["Porcentaje"].ToString());

                    }
                }


                return oImpuesto;
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

        public Impuesto Save(Impuesto pImpuesto)
        {
            string msg = "";
            SqlCommand command = new SqlCommand();
            Impuesto oImpuesto = null;

            try
            {
                string sql = @"usp_INSERT_Impuesto";

                command.Parameters.AddWithValue("@IdFecha", pImpuesto.IdFecha);
                command.Parameters.AddWithValue("@Porcentaje", pImpuesto.Porcentaje);


                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = sql;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    var row = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);

                    if (row > 0)
                        oImpuesto = GetById(pImpuesto.IdFecha);
                }
                return oImpuesto;

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

        public Impuesto Update(Impuesto pImpuesto)
        {
            string msg = "";
            SqlCommand command = new SqlCommand();
            Impuesto oImpuesto = null;

            try
            {
                string sql = @"usp_UPDATE_Impuesto";

                command.Parameters.AddWithValue("@IdFecha", pImpuesto.IdFecha);
                command.Parameters.AddWithValue("@Porcenteje", pImpuesto.Porcentaje);


                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = sql;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    var row = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);

                    if (row > 0)
                        oImpuesto = GetById(pImpuesto.IdFecha);
                }
                return oImpuesto;

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
