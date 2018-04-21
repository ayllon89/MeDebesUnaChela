using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PagoAgilFrba.Devolucion
{
    public partial class Devolucion : PantallasGenericas.Pantalla_Alta
    {
        private string factura_numero;
        private string empresa_cuit;

        public Devolucion()
        {
            InitializeComponent();
        }

        public Devolucion(string numero_factura,string empresa_cuit)
        {
            InitializeComponent();
            this.factura_numero = numero_factura;
            this.empresa_cuit = empresa_cuit;

            texto_factura.Text = numero_factura;
            texto_empresa.Text = empresa_cuit;

        }

        private void boton_guardar_Click(object sender, EventArgs e)
        {
            //borro los errores anteriores
            this.errorValidar.Clear();

            if (this.validar())
            {
                try
                {
                    //llamo al procedure que devuelve la factura
                    base.comando = new SqlCommand("GESDA.devolver_factura", Utilidades.conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    //declaro y seteo los parametros de entrada
                    comando.Parameters.Add(new SqlParameter("@factura_numero", SqlDbType.Int, 88));
                    comando.Parameters.Add(new SqlParameter("@empresa_cuit", SqlDbType.VarChar, 255));
                    comando.Parameters.Add(new SqlParameter("@motivo_devolucion", SqlDbType.VarChar, 255));
                    comando.Parameters["@factura_numero"].Value = this.factura_numero;
                    comando.Parameters["@empresa_cuit"].Value = this.empresa_cuit;
                    comando.Parameters["@motivo_devolucion"].Value = texto_motivo.Text;

                    SqlParameter resultado = new SqlParameter("@resultado", SqlDbType.VarChar, 88);
                    resultado.Direction = ParameterDirection.Output;
                    comando.Parameters.Add(resultado);
                    //ejecuto el comando 
                    comando.ExecuteNonQuery();
                    String resultadoString = comando.Parameters["@resultado"].Value.ToString();

                    MessageBox.Show(resultadoString);
                }
                catch (Exception error)
                {
                    MessageBox.Show("se produjo un error: " + error.ToString());
                }
            }
        }

        private void boton_limpiar_Click(object sender, EventArgs e)
        {
            texto_motivo.Text = "";
        }

        public bool validar()
        {
            bool noHayError = true;

            if (texto_motivo.Text == String.Empty)
            {
                //al error provider le paso el texbox que tiene el campo vacio
                errorValidar.SetError(texto_motivo, "Por favor debe ingresar un motivo de devolucion");
                noHayError = false;
            }
            else
            {
                if (texto_motivo.TextLength >= 255)
                {
                    errorValidar.SetError(texto_motivo, "La cantidad maxima de caracteres es de 255, ingrese menos por favor");
                    noHayError = false;
                }
            }
            return noHayError;
        }
    }
}
