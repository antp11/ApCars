using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using UTN.WinForms.ApCars.Interfaces;

namespace UTN.WinForms.ApCars.Layers.BLL
{
    public class BLLDolar : IBLLDolar
    {
        /// <summary>
        /// Metodo Que devuelve el tipo de cambio del dolar 
        /// </summary>
        /// <returns></returns>
        public double GetVentaDolar()
        {
            string correoRegistrado = "antperez1101@gmail.com";
            string token = "1O20P3PEMA";
            string nombreRegistrado = "Anthony Perez Alvarez";
            try
            {
                // Habilitar TLS12
                System.Net.ServicePointManager.SecurityProtocol =
                                              SecurityProtocolType.Tls12;
                // wsindicadoreseconomicosSoap12 Binding tomado del app.Config
                Agente.wsindicadoreseconomicosSoapClient cliente =
                     new Agente.wsindicadoreseconomicosSoapClient("wsindicadoreseconomicosSoap12");

                DataSet ds = cliente.ObtenerIndicadoresEconomicos("318",    /* 317 Compra / 318 Venta */
                                                                  DateTime.Now.ToString("dd/MM/yyyy"),      /* Fecha Inicial */
                                                                   DateTime.Now.ToString("dd/MM/yyyy"),      /* Fecha Final */
                                                                  nombreRegistrado,  /* Su Nombre Registrado   BCCR */
                                                                  "N",
                                                                  correoRegistrado, /* Correo Registrado BCCR */
                                                                  token             /* Token enviado por el BCCR */
                                                                 );

                DataTable table = ds.Tables[0];

                return Convert.ToDouble(table.Rows[0]["NUM_VALOR"].ToString());
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return 0;
            }


        }
    }
}

