using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UTN.WinForms.ApCars.Extensions;
using UTN.WinForms.ApCars.Interfaces;
using UTN.WinForms.ApCars.Layers.Entities;
using UTN.WinForms.ApCars.Layers.Entities.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UTN.WinForms.ApCars.Layers.DAL
{
    public class DALFactura : IDALFactura
    {
        private static readonly ILog _myLogControlEventos = LogManager.GetLogger("MyControlEventos");
        public int GetCurrentNumeroFactura()
        {

            DataSet ds = null;
            IDbCommand command = new SqlCommand();
            int numeroFactura = 0;
            string sql = @"SELECT current_value FROM sys.sequences WHERE name = 'SequenceNoFactura'";
            DataTable dt = null;
            string msg = "";
            try
            {

                command.CommandText = sql;
                command.CommandType = CommandType.Text;
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    ds = db.ExecuteReader(command, "query");
                }

                // Extraer la tabla 
                dt = ds.Tables[0];
                //Extraer el valor que viene en el DataTable 
                numeroFactura = int.Parse(dt.Rows[0][0].ToString());
                return numeroFactura;
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

        public int GetNextNumeroFactura()
        {
            DataSet ds = null;
            IDbCommand command = new SqlCommand();
            int numeroFactura = 0;
            string sql = @"select NEXT VALUE FOR   SequenceNoFactura ";
            string msg = "";
            DataTable dt = null;
            try
            {
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    ds = db.ExecuteReader(command, "query");
                }

                // Extraer la tabla 
                dt = ds.Tables[0];
                //Extraer el valor que viene en el DataTable 
                numeroFactura = int.Parse(dt.Rows[0][0].ToString());
                return numeroFactura;
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

        public FacturaEncabezado Save(FacturaEncabezado pFactura)
        {
            FacturaEncabezado oFacturaEncabezado = null;
            string sqlEncabezado = string.Empty;
            string sqlDetalle = string.Empty;
            string sqlVehiculo = string.Empty;
            SqlCommand cmdFacturaEncabezado = new SqlCommand();
            SqlCommand cmdFacturaDetalle = new SqlCommand();
            SqlCommand cmdVehiculo = new SqlCommand();
            List<IDbCommand> listaCommands = new List<IDbCommand>();
            double rows = 0;
            string msg = "";

            // Reenumerar
            pFactura.IdFactura = GetCurrentNumeroFactura();
            pFactura._ListaFacturaDetalle.ForEach(p => p.IdFactura = pFactura.IdFactura);

            sqlEncabezado = @"usp_INSERT_EncabezadoFactura";

            try
            {
                // Encabezado de factura
                cmdFacturaEncabezado.Parameters.AddWithValue("@IdFactura", pFactura.IdFactura);
                cmdFacturaEncabezado.Parameters.AddWithValue("@IdUsuario", pFactura.IdUsuario);
                cmdFacturaEncabezado.Parameters.AddWithValue("@IdTarjeta", pFactura.IdTarjeta);
                cmdFacturaEncabezado.Parameters.AddWithValue("@IdCliente", pFactura.IdCliente);
                cmdFacturaEncabezado.Parameters.AddWithValue("@TipoPago", pFactura.TipoPago);
                cmdFacturaEncabezado.Parameters.AddWithValue("@NoReferencia", pFactura.NoReferencia);
                cmdFacturaEncabezado.Parameters.AddWithValue("@Estado", pFactura.Estado);
                cmdFacturaEncabezado.Parameters.AddWithValue("@Fecha", pFactura.Fecha);
                cmdFacturaEncabezado.Parameters.AddWithValue("@XML", pFactura.XML);
                cmdFacturaEncabezado.Parameters.AddWithValue("@Firma", pFactura.Firma);
                cmdFacturaEncabezado.Parameters.AddWithValue("@TipoCambio", pFactura.TipoCambio);

                cmdFacturaEncabezado.CommandText = sqlEncabezado;
                cmdFacturaEncabezado.CommandType = CommandType.StoredProcedure;
                // Agregar a la lista de commands
                listaCommands.Add(cmdFacturaEncabezado);


                // Detalle de factura
                sqlDetalle = @"usp_INSERT_DetalleFactura";

                // Guardar el detalle de la factura y a la vez rebajar el saldo del producto en Electronico
                foreach (FacturaDetalle pFacturaDetalle in pFactura._ListaFacturaDetalle)
                {
                    cmdFacturaDetalle = new SqlCommand();

                    cmdFacturaDetalle.Parameters.AddWithValue("@IdFactura", pFacturaDetalle.IdFactura);
                    cmdFacturaDetalle.Parameters.AddWithValue("@Consecutivo", pFacturaDetalle.Consecutivo);
                    cmdFacturaDetalle.Parameters.AddWithValue("@IdVIN", pFacturaDetalle.IdVIN);
                    cmdFacturaDetalle.Parameters.AddWithValue("@MarcaVehiculo", pFacturaDetalle.Marca);
                    cmdFacturaDetalle.Parameters.AddWithValue("@DescripcionVehiculo", pFacturaDetalle.DescripcionVehiculo);
                    cmdFacturaDetalle.Parameters.AddWithValue("@PrecioColones", pFacturaDetalle.PrecioColones);
                    cmdFacturaDetalle.Parameters.AddWithValue("@PrecioDolares", pFacturaDetalle.PrecioDolares);
                    cmdFacturaDetalle.Parameters.AddWithValue("@ImpuestoColones", pFacturaDetalle.ImpuestoColones);
                    cmdFacturaDetalle.Parameters.AddWithValue("@ImpuestoDolares", pFacturaDetalle.ImpuestoDolares);

                    cmdFacturaDetalle.CommandText = sqlDetalle;
                    cmdFacturaDetalle.CommandType = CommandType.StoredProcedure;
                    // Agregar a la lista de comandos
                    listaCommands.Add(cmdFacturaDetalle);

                    // Rebajar 
                    cmdVehiculo = new SqlCommand();
                    cmdVehiculo.Parameters.AddWithValue("@IdVIN", pFacturaDetalle.IdVIN);
                    sqlVehiculo = @"Update Vehiculo 
                                   Set Estado ='Vendido'
                                   Where IdVIN =@IdVIN";
                    cmdVehiculo.CommandText = sqlVehiculo;
                    cmdVehiculo.CommandType = CommandType.Text;
                    listaCommands.Add(cmdVehiculo);
                }


                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {

                    rows = db.ExecuteNonQuery(listaCommands, IsolationLevel.ReadCommitted);
                }

                // Si devuelve filas quiere decir que se salvo entonces extraerlo

                if (rows == 0)
                {
                    throw new Exception("No se pudo salvar correctamente la factura");
                }
                else
                {
                    oFacturaEncabezado = GetFactura(pFactura.IdFactura);

                }

                // Crear un nuevo consecutivo de factura
                GetNextNumeroFactura();

                return oFacturaEncabezado;
            }
            catch (SqlException er)
            {
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(MethodBase.GetCurrentMethod(), er, cmdVehiculo));
                throw new CustomException(msg.ToSqlServerDetailError(er));
            }
            catch (Exception er)
            {
                msg = msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod());
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                throw;
            }
        }
        public FacturaEncabezado GetFactura(double pNumeroFactura)
        {
            string msg = "";
            FacturaEncabezado oFacturaEncabezado = new FacturaEncabezado();
            DataSet ds = null;
            IDALCliente dalCliente = new DALCliente();
            //  IDALTarjeta dalTarjeta = new DALTarjeta();
            SqlCommand command = new SqlCommand();

            string sql = @"  ";


            sql = @"SELECT EncabezadoFactura.IdFactura,EncabezadoFactura.IdUsuario,
                           EncabezadoFactura.IdTarjeta,EncabezadoFactura.IdCliente, 
	                       EncabezadoFactura.TipoPago,EncabezadoFactura.NoReferencia, EncabezadoFactura.Estado, 
                           EncabezadoFactura.Fecha, EncabezadoFactura.XML, EncabezadoFactura.Firma, EncabezadoFactura.TipoCambio, 
	                       DetalleFactura.Consecutivo, DetalleFactura.IdVIN, DetalleFactura.PrecioColones, DetalleFactura.ImpuestoColones, DetalleFactura.MarcaVehiculo,
                           DetalleFactura.PrecioDolares, DetalleFactura.ImpuestoDolares, Vehiculo.DescripcionVehiculo
                           FROM     DetalleFactura INNER JOIN
                           EncabezadoFactura ON DetalleFactura.IdFactura = EncabezadoFactura.IdFactura INNER JOIN
                           Vehiculo ON DetalleFactura.IdVIN = Vehiculo.IdVIN
				            WHERE (EncabezadoFactura.IdFactura=@IdFactura)";

            try
            {
                command.CommandText = sql;
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@IdFactura", pNumeroFactura);

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    ds = db.ExecuteReader(command, "query");
                }

                // Si devolvió filas
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    oFacturaEncabezado = new FacturaEncabezado();

                    oFacturaEncabezado.IdFactura = int.Parse(dr["IdFactura"].ToString());
                    oFacturaEncabezado.IdUsuario = dr["IdUsuario"].ToString();
                    oFacturaEncabezado.IdTarjeta = int.Parse(dr["IdTarjeta"].ToString());
                    oFacturaEncabezado.IdCliente = dr["IdCliente"].ToString();
                    oFacturaEncabezado.TipoPago = dr["TipoPago"].ToString();
                    oFacturaEncabezado.NoReferencia = dr["NoReferencia"].ToString();
                    oFacturaEncabezado.Estado = bool.Parse(dr["Estado"].ToString());
                    oFacturaEncabezado.Fecha = DateTime.Parse(dr["Fecha"].ToString());
                    oFacturaEncabezado.XML = dr["XML"].ToString();
                    oFacturaEncabezado.Firma = (byte[])dr["Firma"];
                    oFacturaEncabezado.TipoCambio = double.Parse(dr["TipoCambio"].ToString());




                    foreach (DataRow rowDetalle in ds.Tables[0].Rows)
                    {
                        FacturaDetalle oFacturaDetalle = new FacturaDetalle();

                        oFacturaDetalle.IdFactura = int.Parse(rowDetalle["IdFactura"].ToString());
                        oFacturaDetalle.Consecutivo = rowDetalle["Consecutivo"].ToString();
                        oFacturaDetalle.IdVIN = rowDetalle["IdVIN"].ToString();
                        oFacturaDetalle.PrecioColones = double.Parse(rowDetalle["PrecioColones"].ToString());
                        oFacturaDetalle.PrecioDolares = double.Parse(rowDetalle["PrecioDolares"].ToString());
                        oFacturaDetalle.ImpuestoColones = double.Parse(rowDetalle["ImpuestoColones"].ToString());
                        oFacturaDetalle.ImpuestoDolares = double.Parse(rowDetalle["ImpuestoDolares"].ToString());
                        oFacturaDetalle.Marca = rowDetalle["MarcaVehiculo"].ToString();
                        oFacturaDetalle.DescripcionVehiculo = rowDetalle["DescripcionVehiculo"].ToString();
                        // Agregar
                        oFacturaEncabezado.AddDetalle(oFacturaDetalle);
                    }
                }


                return oFacturaEncabezado;
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

        public async Task<IEnumerable<VentasDTO>> GetTotalVentasXFecha(DateTime pFechaInicial, DateTime pFechaFinal)
        {

            SqlCommand command = new SqlCommand();
            List<VentasDTO> lista = new List<VentasDTO>();
            string msg = "";
            try
            {

                string sql = @"SELECT year(EncabezadoFactura.Fecha) as Anno ,
                               sum((DetalleFactura.PrecioColones)+ DetalleFactura.ImpuestoColones) as TotalVentaColones,
						       sum((DetalleFactura.PrecioDolares)+ DetalleFactura.ImpuestoDolares) as TotalVentaDolares
                               FROM    DetalleFactura INNER JOIN
                                     EncabezadoFactura ON DetalleFactura.IdFactura = EncabezadoFactura.IdFactura 
                               WHERE EncabezadoFactura.Fecha between   @pFechaInicial  and @pFechaFinal
                               GROUP  BY  Year(EncabezadoFactura.Fecha)";


                command.CommandText = sql;
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@pFechaInicial", pFechaInicial);
                command.Parameters.AddWithValue("@pFechaFinal", new DateTime(pFechaFinal.Year, pFechaFinal.Month, pFechaFinal.Day, 23, 59, 59));

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {

                    DataTable dt = await db.ExecuteReaderAsync(command, "T");

                    // Iterar en todas las filas 
                    foreach (DataRow reader in dt.Rows)
                    {
                        // Mapearlas
                        VentasDTO oVentasDTO = new VentasDTO();
                        oVentasDTO.Anno = int.Parse(reader["Anno"].ToString());
                        oVentasDTO.TotalVentaColones = Convert.ToDouble(reader["TotalVentaColones"]);
                        oVentasDTO.TotalVentaDolares = Convert.ToDouble(reader["TotalVentaDolares"]);

                        lista.Add(oVentasDTO);
                    }

                    return lista;
                }
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
