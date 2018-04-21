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
    public partial class Modificacion_Sucursal : PantallasGenericas.Pantalla_Alta
    {
        String codigoPostalNuevo;
        String nombreNuevo;
        String direccionNuevo;
        String resultadoString1;
        String resultadoString2;
        String resultadoString3;

        public Modificacion_Sucursal()
        {
            InitializeComponent();
        }
        public Modificacion_Sucursal(String nombre, String direccion, String codigoPostal)
        {
            try
            {
                InitializeComponent();
                
                textBox_nombre.Text = nombre;
                nombreNuevo = nombre;

                textBox_direccion.Text = direccion;
                direccionNuevo = direccion;
                
                textBox_codigo_postal.Text = codigoPostal;
                codigoPostalNuevo = codigoPostal;
                
                //averiguo si la sucursal esta dado de baja
                query = String.Format("SELECT sucursal_estado FROM GESDA.sucursal WHERE sucursal_codigo_postal='{0}'", codigoPostal);
                dp = new SqlDataAdapter(query, Utilidades.conexion);
                ds = new DataSet();
                dp.Fill(ds);
                
                if (ds.Tables[0].Rows[0]["sucursal_estado"].ToString() == "1")
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("se produjo un error: " + error.ToString());
            }
        }

        private void boton_guardar_Click(object sender, EventArgs e)
        {
            this.errorValidar.Clear();

            if (this.validar())
            {
                if (textBox_nombre.Text != nombreNuevo)
                {
                    this.modificar_nombre();
                    //actualizo el nombre
                    nombreNuevo = textBox_nombre.Text;
                }
                //modifico el direccion
                if (textBox_direccion.Text != direccionNuevo)
                {
                    this.modificar_direccion();
                    //actualizo direccion
                    direccionNuevo = textBox_direccion.Text;
                }
                //modifico el codigo_postal
                if (textBox_codigo_postal.Text != codigoPostalNuevo)
                {
                    this.modificar_codigo_postal();
                }
                if (resultadoString1 == "El nombre se modifico" || resultadoString2 == "La direccion se modifico" || resultadoString3 == "El codigo postal se modifico")
                {
                    MessageBox.Show("La sucursal se modifico");
                }
            }
        }

        private void modificar_nombre()
        {
            try
            {
                //llamo al procedure
                base.comando = new SqlCommand("GESDA.modificar_nombre_sucursal", Utilidades.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //declaro los parametros y seteo los parametros de entrada
                comando.Parameters.Add(new SqlParameter("@codigo_postal", SqlDbType.VarChar, 88));
                comando.Parameters.Add(new SqlParameter("@nombre_nuevo", SqlDbType.VarChar, 88));
                comando.Parameters["@codigo_postal"].Value = textBox_codigo_postal.Text;
                comando.Parameters["@nombre_nuevo"].Value = textBox_nombre.Text;
                base.resultado = new SqlParameter("@resultado", SqlDbType.VarChar, 88);
                resultado.Direction = ParameterDirection.Output;
                comando.Parameters.Add(resultado);
                //ejecuto el comando 
                comando.ExecuteNonQuery();
                resultadoString1 = comando.Parameters["@resultado"].Value.ToString();
                
            }
            catch (Exception error)
            {
                MessageBox.Show("se produjo un error: " + error.ToString());
            }
        }

        private void modificar_direccion()
        {
            try
            {
                //llamo al procedure
                base.comando = new SqlCommand("GESDA.modificar_direccion_sucursal", Utilidades.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //declaro los parametros y seteo los parametros de entrada
                comando.Parameters.Add(new SqlParameter("@codigo_postal", SqlDbType.VarChar, 88));
                comando.Parameters.Add(new SqlParameter("@direccion_nuevo", SqlDbType.VarChar, 88));
                comando.Parameters["@codigo_postal"].Value = textBox_codigo_postal.Text;
                comando.Parameters["@direccion_nuevo"].Value = textBox_direccion.Text;
                base.resultado = new SqlParameter("@resultado", SqlDbType.VarChar, 88);
                resultado.Direction = ParameterDirection.Output;
                comando.Parameters.Add(resultado);
                //ejecuto el comando 
                comando.ExecuteNonQuery();
                resultadoString2 = comando.Parameters["@resultado"].Value.ToString();

            }
            catch (Exception error)
            {
                MessageBox.Show("se produjo un error: " + error.ToString());
            }
        }

        private void modificar_codigo_postal()
        {
            try
            {
                //llamo al procedure
                base.comando = new SqlCommand("GESDA.modificar_cosdigo_postal_sucursal", Utilidades.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //declaro los parametros y seteo los parametros de entrada
                comando.Parameters.Add(new SqlParameter("@codigo_postal", SqlDbType.VarChar, 88));
                comando.Parameters.Add(new SqlParameter("@codigo_postal_nuevo", SqlDbType.VarChar, 88));
                comando.Parameters["@codigo_postal"].Value = codigoPostalNuevo;
                comando.Parameters["@codigo_postal_nuevo"].Value = textBox_codigo_postal.Text;
                base.resultado = new SqlParameter("@resultado", SqlDbType.VarChar, 88);
                resultado.Direction = ParameterDirection.Output;
                comando.Parameters.Add(resultado);
                //ejecuto el comando 
                comando.ExecuteNonQuery();
                resultadoString3 = comando.Parameters["@resultado"].Value.ToString();

            }
            catch (Exception error)
            {
                MessageBox.Show("se produjo un error: " + error.ToString());
            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                //habilito la sucursal
                try
                {
                    //llamo al procedure
                    base.comando = new SqlCommand("GESDA.habilitar_sucursal", Utilidades.conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    //declaro los parametros y seteo los parametros de entrada
                    comando.Parameters.Add(new SqlParameter("@codigo_postal", SqlDbType.VarChar, 88));
                    comando.Parameters["@codigo_postal"].Value = textBox_codigo_postal.Text;
                    SqlParameter resultado = new SqlParameter("@resultado", SqlDbType.VarChar, 88);
                    resultado.Direction = ParameterDirection.Output;
                    comando.Parameters.Add(resultado);
                    //ejecuto el comando 
                    comando.ExecuteNonQuery();
                    String resultadoString = comando.Parameters["@resultado"].Value.ToString();
                    //muestro el resultado por pantalla
                    MessageBox.Show(resultadoString);

                }
                catch (Exception error)
                {
                    MessageBox.Show("se produjo un error: " + error.ToString());
                }


            }
            else
            {
                //deshabilito la sucursal
                try
                {
                    //llamo al procedure
                    base.comando = new SqlCommand("GESDA.deshabilitar_sucursal", Utilidades.conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    //declaro los parametros y seteo los parametros de entrada
                    comando.Parameters.Add(new SqlParameter("@codigo_postal", SqlDbType.VarChar, 88));
                    comando.Parameters["@codigo_postal"].Value = textBox_codigo_postal.Text;
                    SqlParameter resultado = new SqlParameter("@resultado", SqlDbType.VarChar, 88);
                    resultado.Direction = ParameterDirection.Output;
                    comando.Parameters.Add(resultado);
                    //ejecuto el comando 
                    comando.ExecuteNonQuery();
                    String resultadoString = comando.Parameters["@resultado"].Value.ToString();
                    //muestro el resultado por pantalla
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
            textBox_nombre.Text = "";
            textBox_direccion.Text = "";
            textBox_codigo_postal.Text = "";
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
    }
}
