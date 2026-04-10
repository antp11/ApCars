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
    internal class DALTipoCombustible : IDALTipoCombustible
    {
        private static readonly ILog _myLogControlEventos = LogManager.GetLogger("MyControlEventos");
        public List<TipoCombustible> GetAll()
        {
            StringBuilder conexion = new StringBuilder();

            IDataReader reader = null;
            List<TipoCombustible> lista = new List<TipoCombustible>();
            SqlCommand command = new SqlCommand();
            string msg = "";

            string sql = @"usp_SELECT_TipoCombustible_All";
            command.CommandText = sql;
            command.CommandType = CommandType.StoredProcedure;

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        TipoCombustible oTipoCombustible = new TipoCombustible();
                        oTipoCombustible.IdTipoCombustible = int.Parse(reader["IdTipoCombustible"].ToString());
                        oTipoCombustible.DescripcionTipoCombustible = reader["DescripcionTipoCombustible"].ToString();

                        lista.Add(oTipoCombustible);
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
    }
}

