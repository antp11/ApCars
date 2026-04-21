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
    internal class DALTarjeta : IDALTarjeta
    {
        private static readonly ILog _myLogControlEventos = LogManager.GetLogger("MyControlEventos");

        public IEnumerable<Tarjeta> GetAll()
        {
            List<Tarjeta> lista = new List<Tarjeta>();
            IDataReader reader = null;
            SqlCommand command = new SqlCommand();
            string msg = "";
            try
            {
                string sql = @"usp_SELECT_Tarjeta_All";
                command.CommandText = sql;
                command.CommandType = CommandType.StoredProcedure;


                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);
                    // Iterar en todas las filas 
                    while (reader.Read())
                    {

                        // Mapearlas
                        Tarjeta oTarjeta = new Tarjeta();
                        oTarjeta.IdTarjeta = Convert.ToInt32(reader["IdTarjeta"].ToString());
                        oTarjeta.DescripcionTarjeta = reader["DescripcionTarjeta"].ToString();

                        lista.Add(oTarjeta);
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
