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
using UTN.WinForms.ApCars.Layers.Entities.DTO;
using static log4net.Appender.ColoredConsoleAppender;

namespace UTN.WinForms.ApCars.Layers.DAL
{
    internal class DALVehiculo : IDALVehiculo
    {

        private static readonly ILog _myLogControlEventos = LogManager.GetLogger("MyControlEventos");

        public bool Delete(string pVin)
        {
            SqlCommand command = new SqlCommand();
            string msg = "";
            string sql = @"usp_DELETE_Vehiculo_ByID";
            double row = 0;
            try
            {
                command.Parameters.AddWithValue("@IdVIN", pVin);
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

        public List<Vehiculo> GetAll()
        {
            string msg = "";
            SqlCommand command = new SqlCommand();
            IDataReader reader = null;
            Vehiculo oVehiculo = null;
            List<Vehiculo> lista = new List<Vehiculo>();
            try
            {
                command.CommandText = @"usp_SELECT_Vehiculo_All";
                command.CommandType = CommandType.StoredProcedure;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        oVehiculo = new Vehiculo();
                        oVehiculo.IdVIN = reader["IdVIN"].ToString();
                        oVehiculo.IdMarca = int.Parse(reader["IdMarca"].ToString());
                        oVehiculo.IdEstilo = int.Parse(reader["IdEstilo"].ToString());
                        oVehiculo.DescripcionVehiculo = reader["DescripcionVehiculo"].ToString();
                        oVehiculo.Anno = int.Parse(reader["Anno"].ToString());
                        oVehiculo.CantidadPaasajero = int.Parse(reader["CantidadPaasajero"].ToString());
                        oVehiculo.TipoCombustible = int.Parse(reader["TipoCombustible"].ToString());
                        oVehiculo.Color = reader["Color"].ToString();
                        oVehiculo.TipoTransmision = int.Parse(reader["TipoTransmision"].ToString());
                        oVehiculo.Precio = double.Parse(reader["Precio"].ToString());
                        oVehiculo.Foto = (byte[])reader["Foto"];
                        oVehiculo.Documento = (byte[])reader["Documento"];
                        oVehiculo.Extras = reader["Extras"].ToString();


                        lista.Add(oVehiculo);
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

        public List<VehiculoMarcaEstiloDTO> GetAllDTO()
        {
            string msg = "";
            DataSet ds = null;
            List<VehiculoMarcaEstiloDTO> lista = new List<VehiculoMarcaEstiloDTO>();
            SqlCommand command = new SqlCommand();

            string sql = @"SELECT Estilo.*, TipoCombustible.*, Marca.*, TipoTransmision.*, Vehiculo.IdVIN, Vehiculo.DescripcionVehiculo, Vehiculo.Anno, Vehiculo.CantidadPaasajero, Vehiculo.Color, Vehiculo.Precio, Vehiculo.Foto, Vehiculo.Documento, Vehiculo.Extras
                  FROM     Estilo INNER JOIN
                  Vehiculo ON Estilo.IdEstilo = Vehiculo.IdEstilo INNER JOIN
                  Marca ON Vehiculo.IdMarca = Marca.IdMarca INNER JOIN
                  TipoCombustible ON Vehiculo.TipoCombustible = TipoCombustible.IdTipoCombustible INNER JOIN
                  TipoTransmision ON Vehiculo.TipoTransmision = TipoTransmision.IdTransmision";
            try
            {
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    ds = db.ExecuteReader(command, "query");
                }

                // Si devolvió filas
                if (ds.Tables[0].Rows.Count > 0)
                {

                    // Iterar en todas las filas y Mapearlas
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        VehiculoMarcaEstiloDTO oVehiculoMarcaEstiloDTO = new VehiculoMarcaEstiloDTO();
                        oVehiculoMarcaEstiloDTO.IdVIN = dr["IdVIN"].ToString();
                        oVehiculoMarcaEstiloDTO.IdMarca = int.Parse(dr["IdMarca"].ToString());
                        oVehiculoMarcaEstiloDTO.DescripcionMarca = dr["DescripcionMarca"].ToString();
                        oVehiculoMarcaEstiloDTO.Logo = (byte[])dr["Logo"];
                        oVehiculoMarcaEstiloDTO.IdEstilo = int.Parse(dr["IdEstilo"].ToString());
                        oVehiculoMarcaEstiloDTO.Descripcion = dr["Descripcion"].ToString();
                        oVehiculoMarcaEstiloDTO.DescripcionVehiculo = dr["DescripcionVehiculo"].ToString();
                        oVehiculoMarcaEstiloDTO.Anno = int.Parse(dr["Anno"].ToString());
                        oVehiculoMarcaEstiloDTO.CantidadPaasajero = int.Parse(dr["CantidadPaasajero"].ToString());
                        oVehiculoMarcaEstiloDTO.IdTipoCombustible = int.Parse(dr["IdTipoCombustible"].ToString());
                        oVehiculoMarcaEstiloDTO.DescripcionTipoCombustible = dr["DescripcionTipoCombustible"].ToString();
                        oVehiculoMarcaEstiloDTO.Color = dr["Color"].ToString();
                        oVehiculoMarcaEstiloDTO.IdTransmision = int.Parse(dr["IdTransmision"].ToString());
                        oVehiculoMarcaEstiloDTO.DescripcionTransmision = dr["DescripcionTransmision"].ToString();
                        oVehiculoMarcaEstiloDTO.Precio = double.Parse(dr["Precio"].ToString());
                        oVehiculoMarcaEstiloDTO.Foto = (byte[])dr["Foto"];
                        oVehiculoMarcaEstiloDTO.Documento = (byte[])dr["Documento"];
                        oVehiculoMarcaEstiloDTO.Extras = dr["Extras"].ToString();


                        lista.Add(oVehiculoMarcaEstiloDTO);
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

        public Vehiculo GetById(string pVin)
        {
            SqlCommand command = new SqlCommand();
            IDataReader reader = null;
            Vehiculo oVehiculo = null;
            string msg = "";
            try
            {
                command.CommandText = @"usp_SELECT_Vehiculo_ByID";
                command.Parameters.AddWithValue("@IdVin", pVin);

                command.CommandType = CommandType.StoredProcedure;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        oVehiculo = new Vehiculo();
                        oVehiculo.IdVIN = reader["IdVIN"].ToString();
                        oVehiculo.IdMarca = int.Parse(reader["IdMarca"].ToString());
                        oVehiculo.IdEstilo = int.Parse(reader["IdEstilo"].ToString());
                        oVehiculo.DescripcionVehiculo = reader["DescripcionVehiculo"].ToString();
                        oVehiculo.Anno = int.Parse(reader["Anno"].ToString());
                        oVehiculo.CantidadPaasajero = int.Parse(reader["CantidadPaasajero"].ToString());
                        oVehiculo.TipoCombustible = int.Parse(reader["TipoCombustible"].ToString());
                        oVehiculo.Color = reader["Color"].ToString();
                        oVehiculo.TipoTransmision = int.Parse(reader["TipoTransmision"].ToString());
                        oVehiculo.Precio = double.Parse(reader["Precio"].ToString());
                        oVehiculo.Foto = (byte[])reader["Foto"];
                        oVehiculo.Documento = (byte[])reader["Documento"];
                        oVehiculo.Extras = reader["Extras"].ToString();

                    }
                }

                return oVehiculo;
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

        public Vehiculo Save(Vehiculo pVehiculo)
        {
            string msg = "";
            SqlCommand command = new SqlCommand();
            Vehiculo oVehiculo = null;
            string sql = @"usp_INSERT_Vehiculo";
            double row = 0;
            try
            {
                command.Parameters.AddWithValue("@IdVIN", pVehiculo.IdVIN);
                command.Parameters.AddWithValue("@IdMarca", pVehiculo.IdMarca);
                command.Parameters.AddWithValue("@IdEstilo", pVehiculo.IdEstilo);
                command.Parameters.AddWithValue("@DescripcionVehiculo", pVehiculo.DescripcionVehiculo);
                command.Parameters.AddWithValue("@Anno", pVehiculo.Anno);
                command.Parameters.AddWithValue("@CantidadPaasajero", pVehiculo.CantidadPaasajero);
                command.Parameters.AddWithValue("@TipoCombustible", pVehiculo.TipoCombustible+1);
                command.Parameters.AddWithValue("@Color", pVehiculo.Color);
                command.Parameters.AddWithValue("@TipoTransmision", pVehiculo.TipoTransmision+1);
                command.Parameters.AddWithValue("@Precio", pVehiculo.Precio);
                command.Parameters.AddWithValue("@Foto", pVehiculo.Foto);
                command.Parameters.AddWithValue("@Documento", pVehiculo.Documento);
                command.Parameters.AddWithValue("@Extras", pVehiculo.Extras);


               


                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = sql;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    row = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
                }
                if (row > 0)
                    oVehiculo = GetById(pVehiculo.IdVIN);

                return oVehiculo;

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

        public Vehiculo Update(Vehiculo pVehiculo)
        {
            string msg = "";
            SqlCommand command = new SqlCommand();
            Vehiculo oVehiculo = null;
            string sql = @"usp_UPDATE_Vehiculo";
            double row = 0;
            try
            {
                command.Parameters.AddWithValue("@IdVIN", pVehiculo.IdVIN);
                command.Parameters.AddWithValue("@IdMarca", pVehiculo.IdMarca);
                command.Parameters.AddWithValue("@IdEstilo", pVehiculo.IdEstilo);
                command.Parameters.AddWithValue("@DescripcionVehiculo", pVehiculo.DescripcionVehiculo);
                command.Parameters.AddWithValue("@Anno", pVehiculo.Anno);
                command.Parameters.AddWithValue("@CantidadPaasajero", pVehiculo.CantidadPaasajero);
                command.Parameters.AddWithValue("@TipoCombustible", pVehiculo.TipoCombustible );
                command.Parameters.AddWithValue("@Color", pVehiculo.Color);
                command.Parameters.AddWithValue("@TipoTransmision", pVehiculo.TipoTransmision );
                command.Parameters.AddWithValue("@Precio", pVehiculo.Precio);
                command.Parameters.AddWithValue("@Foto", pVehiculo.Foto);
                command.Parameters.AddWithValue("@Documento", pVehiculo.Documento);
                command.Parameters.AddWithValue("@Extras", pVehiculo.Extras);

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = sql;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    row = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
                }
                if (row > 0)
                    oVehiculo = GetById(pVehiculo.IdVIN);

                return oVehiculo;

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
