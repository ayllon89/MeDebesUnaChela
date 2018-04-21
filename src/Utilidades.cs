using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace PagoAgilFrba
{
    class Utilidades
    {
        public static SqlConnection conexion;
        public static DateTime fecha;

        public static void establecerConexion()
        {
            try
            {
                //obtengo los datos de conexion del archivo configuracion
                string server = ConfigurationManager.AppSettings["server"].ToString();
                string user = ConfigurationManager.AppSettings["user"].ToString();
                string password = ConfigurationManager.AppSettings["password"].ToString();
                string miBase = ConfigurationManager.AppSettings["base"].ToString();
                //inicio la conexion
                conexion = new SqlConnection();
                conexion.ConnectionString = "SERVER=" + server + ";DATABASE=" + miBase + ";UID=" + user + ";PASSWORD=" + password + ";";
                conexion.Open();
            }
            catch (Exception error)
            {
                MessageBox.Show("se produjo un error: " + error.ToString());
            }

        }

        public static void establecerFecha()
        {
            fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["fecha"].ToString());
        }
    }
}
