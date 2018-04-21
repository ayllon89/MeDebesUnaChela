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

namespace PagoAgilFrba.AbmSucursal
{
    public partial class Alta_Sucursal : PantallasGenericas.Pantalla_Alta
    {
        String mensaje;
        public Alta_Sucursal()
        {
            InitializeComponent();
        }

        public bool validar()
        {
            bool noHayError = true;

            if (textBox_nombre.Text == String.Empty)
            {
                errorValidar.SetError(textBox_nombre, "Por favor complete este campo");
                noHayError = false;
            }
            if (textBox_direccion.Text == String.Empty)
            {
                errorValidar.SetError(textBox_direccion, "Por favor complete este campo");
                noHayError = false;
            }
            if (textBox_codigo_postal.Text == String.Empty)
            {
                errorValidar.SetError(textBox_codigo_postal, "Por favor complete este campo");
                noHayError = false;
            }
            else
            {
                try
                {
                    //como el campo no es vacio, verifico si el dato que ingresaron es del tipo numerico
                    int i = Convert.ToInt32(textBox_codigo_postal.Text);
                }
                catch
                {
                    errorValidar.SetError(textBox_codigo_postal, "Por favor ingrese valores numericos");
                    noHayError = false;
                }

            }

            return noHayError;
        }

        private void boton_guardar_Click(object sender, EventArgs e)
        {
            
            this.errorValidar.Clear();
           
            if (this.validar())
            {
                try
                {
                    base.comando = new SqlCommand("GESDA.alta_sucursal", Utilidades.conexion);
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar, 88));
                    comando.Parameters.Add(new SqlParameter("@direccion", SqlDbType.NVarChar, 88));
                    comando.Parameters.Add(new SqlParameter("@codigoPostal", SqlDbType.NVarChar, 88));

                    comando.Parameters["@nombre"].Value = textBox_nombre.Text;
                    comando.Parameters["@direccion"].Value = textBox_direccion.Text;
                    comando.Parameters["@codigoPostal"].Value = textBox_codigo_postal.Text;

                    SqlParameter resultado = new SqlParameter("@resultado", SqlDbType.VarChar, 88);
                    resultado.Direction = ParameterDirection.Output;
                    comando.Parameters.Add(resultado);
                   
                    comando.ExecuteNonQuery();
                    String resultadoString = comando.Parameters["@resultado"].Value.ToString();
                    mensaje = resultadoString;
                    MessageBox.Show(resultadoString);

                }
                catch (Exception error)
                {
                    MessageBox.Show("se produjo un error: " + error.ToString());
                }
                if (mensaje == "Se creo la sucursal correctamente")
                {
                    this.limpiarDatos();
                }
            }
        }

        private void boton_limpiar_Click(object sender, EventArgs e)
        {
            this.limpiarDatos();
        }
        private void limpiarDatos()
        {
            textBox_nombre.Text = "";
            textBox_direccion.Text = "";
            textBox_codigo_postal.Text = "";
        }
    }
}
