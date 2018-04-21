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

namespace PagoAgilFrba.AbmEmpresa
{
    public partial class Empresa_Alta : PantallasGenericas.Pantalla_Alta
    {
        public Empresa_Alta()
        {
            InitializeComponent();

            //lleno el combo de rubros
            base.comando = new SqlCommand("select r.rubro_descripcion rubro from gesda.Rubro r", Utilidades.conexion);
            base.datos = base.comando.ExecuteReader();
            while (datos.Read())
            {
                combo_rubro.Items.Add(datos["rubro"].ToString());
            }
            datos.Close();
        }

        private void boton_guardar_Click(object sender, EventArgs e)
        {
            //dejo en blanco los errores de validacion anteriores, si es que tenia
            base.errorValidar.Clear();
            //Verifico que no quede campos sin completar
            if (this.validar())
            {
                try
                {
                    //llamo al procedure que crea empresa

                    base.comando = new SqlCommand("GESDA.alta_empresa", Utilidades.conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    //declaro y seteo los parametros de entrada
                    comando.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 88));
                    comando.Parameters.Add(new SqlParameter("@cuit", SqlDbType.VarChar, 88));
                    comando.Parameters.Add(new SqlParameter("@direccion", SqlDbType.VarChar, 88));
                    comando.Parameters.Add(new SqlParameter("@nombreRubro", SqlDbType.VarChar, 88));
                    comando.Parameters["@nombre"].Value = texto_nombre.Text;
                    comando.Parameters["@cuit"].Value = texto_cuit.Text;
                    comando.Parameters["@direccion"].Value = texto_direccion.Text;
                    comando.Parameters["@nombreRubro"].Value = combo_rubro.SelectedItem.ToString();

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

        public bool validar()
        {
            bool noHayError = true;
            //valido que el nombre no este vacio
            if (texto_nombre.Text == String.Empty)
            {
                //al error provider le paso el texbox o boton que no cumple la validacion
                errorValidar.SetError(texto_nombre, "Por favor complete este campo");
                noHayError = false;
            }
            if ((combo_rubro.SelectedIndex < 0))
            {
                //al error provider le paso el combo box que no cumple la validacion
                errorValidar.SetError(combo_rubro, "Por favor selecione un item");
                noHayError = false;
            }
            if (texto_direccion.Text == String.Empty)
            {
                //al error provider le paso el texbox o boton que no cumple la validacion
                errorValidar.SetError(texto_direccion, "Por favor complete este campo");
                noHayError = false;
            }


            if (texto_cuit.Text == String.Empty)
            {
                //al error provider le paso el texbox o boton que no cumple la validacion
                errorValidar.SetError(texto_cuit, "Por favor complete este campo");
                noHayError = false;
            }
            else
            {
                try
                {
                    //como el campo no es vacio, verifico si el dato que ingresaron es del tipo numerico
                    long i = Convert.ToInt64(texto_cuit.Text);
                }
                catch
                {
                    errorValidar.SetError(texto_cuit, "Por favor introduzca un campo numerico");

                    noHayError = false;
                }
                if (texto_cuit.Text.Length < 11)
                {
                    errorValidar.SetError(texto_cuit, "Tiene que tener como minimo 11 caracteres numericos");
                    noHayError = false;
                }
            }

            return noHayError;
        }

        private void boton_limpiar_Click(object sender, EventArgs e)
        {
            combo_rubro.SelectedItem = null;
            texto_direccion.Text = "";
            texto_cuit.Text = "";
            texto_nombre.Text = "";
        }

        private void texto_cuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            //Esto valida el ingreso de espacios, por eso lo quitamos
            //else if (Char.IsSeparator(e.KeyChar))
            //{
            //    e.Handled = false;
            //}
            else
            {
                e.Handled = true;
            }
        }
    }
}
