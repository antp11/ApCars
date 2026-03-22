using log4net;
using System;
using System.Collections;
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
    internal class DALMarca : IDALMarca
    {
        private static readonly ILog _myLogControlEventos = LogManager.GetLogger("MyControlEventos");


        public bool Delete(int pId)
        {
            SqlCommand command = new SqlCommand();
            string msg = "";
            string sql = @"usp_DELETE_Marca_ByID";
            double row = 0;
            try
            {
                command.Parameters.AddWithValue("@IdMarca", pId);
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

        public List<Marca> GetAll()
        {
            IDataReader reader = null;
            List<Marca> lista = new List<Marca>();
            Marca oMarca = null;
            SqlCommand command = new SqlCommand();
            string msg = "";
            try
            {
                string sql = @"usp_SELECT_Marca_All";
                command.CommandText = sql;
                command.CommandType = CommandType.StoredProcedure;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);
                    // Si devolvió filas
                    while (reader.Read())
                    {
                        oMarca = new Marca();
                        oMarca.IdMarca = int.Parse(reader["IdMarca"].ToString());
                        oMarca.DescripcionMarca = reader["DescripcionMarca"].ToString();
                        oMarca.Logo = (byte[])reader["Logo"];

                        lista.Add(oMarca);
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

        public Marca GetById(int pId)
        {
            string msg = "";
            IDataReader reader = null;
            Marca oMarca = null;
            SqlCommand command = new SqlCommand();
            string sql = @"usp_SELECT_Marca_ByID";

            try
            {
                command.Parameters.AddWithValue("@IdMarca", pId);
                command.CommandText = sql;
                command.CommandType = CommandType.StoredProcedure;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        oMarca = new Marca();
                        oMarca.IdMarca = int.Parse(reader["IdMarca"].ToString());
                        oMarca.DescripcionMarca = reader["DescripcionMarca"].ToString();
                        oMarca.Logo = (byte[])reader["Logo"];


                    }
                }
                return oMarca;
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

        public Marca Save(Marca pMarca)
        {
            string msg = "";
            SqlCommand command = new SqlCommand();
            Marca oMarca = null;

            try
            {
                string sql = @"usp_INSERT_Marca";

                command.Parameters.AddWithValue("@IdMarca", pMarca.IdMarca);
                command.Parameters.AddWithValue("@DescripcionMarca", pMarca.DescripcionMarca);
                command.Parameters.AddWithValue("@Logo", pMarca.Logo.ToArray());

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = sql;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    var row = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);

                    if (row > 0)
                        oMarca = GetById(pMarca.IdMarca);
                }
                return oMarca;

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

        public Marca Update(Marca pMarca)
        {
            string msg = "";
            SqlCommand command = new SqlCommand();
            Marca oMarca = null;
            string sql = @"usp_UPDATE_Marca";
            double row = 0;
            try
            {

                command.Parameters.AddWithValue("@IdMarca", pMarca.IdMarca);
                command.Parameters.AddWithValue("@DescripcionMarca", pMarca.DescripcionMarca);
                command.Parameters.AddWithValue("@Logo", pMarca.Logo.ToArray());

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = sql;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    row = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
                }
                if (row > 0)
                    oMarca = GetById(pMarca.IdMarca);

                return oMarca;

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
