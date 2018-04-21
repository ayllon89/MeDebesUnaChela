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

namespace PagoAgilFrba.AbmCliente
{
    public partial class Cliente_Alta : PantallasGenericas.Pantalla_Alta
    {
        public Cliente_Alta()
        {
            InitializeComponent();
        }

        public bool validar()
        {

            bool noHayError = true;
            //valido que el campo uno no este vacio
            if (texto_nombre.Text == String.Empty)
            {
                //al error provider le paso el texbox o boton que no cumple la validacion
                errorValidar.SetError(texto_nombre, "Por favor complete este campo");
                noHayError = false;
            }

            //valido que el campo uno no este vacio
            if (texto_dni.Text == String.Empty)
            {
                //al error provider le paso el texbox o boton que no cumple la validacion
                errorValidar.SetError(texto_dni, "Por favor complete este campo");
                noHayError = false;
            }
            else
            {
                try
                {
                    //como el campo no es vacio, verifico si el dato que ingresaron es del tipo numerico
                    int i = Convert.ToInt32(texto_dni.Text);
                }
                catch
                {
                    errorValidar.SetError(texto_dni, "Por favor introdusca un campo numerico");
                    noHayError = false;
                }
            }

            //valido que el campo uno no este vacio
            if (texto_apellido.Text == String.Empty)
            {
                //al error provider le paso el texbox o boton que no cumple la validacion
                errorValidar.SetError(texto_apellido, "Por favor complete este campo");
                noHayError = false;
            }

            if (texto_direccion.Text == String.Empty)
            {
                //al error provider le paso el texbox o boton que no cumple la validacion
                errorValidar.SetError(texto_direccion, "Por favor complete este campo");
                noHayError = false;
            }

            if (texto_telefono.Text == String.Empty)
            {
                //al error provider le paso el texbox o boton que no cumple la validacion
                errorValidar.SetError(texto_telefono, "Por favor complete este campo");
                noHayError = false;
            }
            else
            {
                try
                {
                    //como el campo no es vacio, verifico si el dato que ingresaron es del tipo numerico
                    int i = Convert.ToInt32(texto_telefono.Text);
                }
                catch
                {
                    errorValidar.SetError(texto_telefono, "Por favor introdusca un campo numerico");
                    noHayError = false;
                }
            }

            if (texto_mail.Text == String.Empty)
            {
                //al error provider le paso el texbox o boton que no cumple la validacion
                errorValidar.SetError(texto_mail, "Por favor complete este campo");
                noHayError = false;
            }

            if (texto_cp.Text == String.Empty)
            {
                //al error provider le paso el texbox o boton que no cumple la validacion
                errorValidar.SetError(texto_cp, "Por favor complete este campo");
                noHayError = false;
            }
            else
            {
                try
                {
                    //como el campo no es vacio, verifico si el dato que ingresaron es del tipo numerico
                    int i = Convert.ToInt32(texto_cp.Text);
                }
                catch
                {
                    errorValidar.SetError(texto_cp, "Por favor introdusca un campo numerico");
                    noHayError = false;
                }
            }

            return noHayError;

        }

        private void boton_limpiar_Click(object sender, EventArgs e)
        {
            texto_nombre.Text = "";
            texto_apellido.Text = "";
            texto_dni.Text = "";
            texto_mail.Text = "";
            texto_telefono.Text = "";
            texto_direccion.Text = "";
            texto_cp.Text = "";
        }

        private void boton_guardar_Click(object sender, EventArgs e)
        {
            base.errorValidar.Clear();

            if (this.validar())
            {
                try
                {
                    //llamo al procedure que crea el cliente
                    base.comando = new SqlCommand("GESDA.sp_alta_cliente", Utilidades.conexion);
                    comando.CommandType = CommandType.StoredProcedure;

                    //declaro y seteo los parametros de entrada
                    comando.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 88));
                    comando.Parameters.Add(new SqlParameter("@apellido", SqlDbType.VarChar, 88));
                    comando.Parameters.Add(new SqlParameter("@dni", SqlDbType.Int, 88));
                    comando.Parameters.Add(new SqlParameter("@mail", SqlDbType.VarChar, 88));
                    comando.Parameters.Add(new SqlParameter("@telefono", SqlDbType.Int, 88));
                    comando.Parameters.Add(new SqlParameter("@direccion", SqlDbType.VarChar, 88));
                    comando.Parameters.Add(new SqlParameter("@codigoPostal", SqlDbType.Int, 88));
                    comando.Parameters.Add(new SqlParameter("@fec_nac", SqlDbType.DateTime, 88));
                    comando.Parameters["@nombre"].Value = texto_nombre.Text;
                    comando.Parameters["@apellido"].Value = texto_apellido.Text;
                    comando.Parameters["@dni"].Value = Convert.ToInt32(texto_dni.Text);
                    comando.Parameters["@mail"].Value = texto_mail.Text;
                    comando.Parameters["@telefono"].Value = Convert.ToInt32(texto_telefono.Text);
                    comando.Parameters["@direccion"].Value = texto_direccion.Text;
                    comando.Parameters["@codigoPostal"].Value = Convert.ToInt32(texto_cp.Text);
                    comando.Parameters["@fec_nac"].Value = Convert.ToDateTime(dateTimePicker1.Value);
                    resultado = new SqlParameter("@resultado", SqlDbType.VarChar, 88);
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
    }
}
