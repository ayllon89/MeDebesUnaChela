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
    public partial class Cliente_Modificacion : PantallasGenericas.Pantalla_Alta
    {
        String nombreNuevo;
        String apellidoNuevo;
        String dniNuevo;
        String mailNuevo;
        String telefonoNuevo;
        String direccionNuevo;
        String postalNuevo;
        String nacimientoNuevo;
        
        public Cliente_Modificacion()
        {
            InitializeComponent();
        }

        public Cliente_Modificacion(String dni)
        {
            InitializeComponent();

            //lleno los campos que el usuario quiere modificar
            texto_dni.Text = dni;
            dniNuevo = dni;

            query = String.Format("select c.cliente_apellido from gesda.Cliente c where c.cliente_dni='{0}'", dni);
            dp = new SqlDataAdapter(query, Utilidades.conexion);
            dp.Fill(ds);
            texto_apellido.Text = ds.Tables[0].Rows[0]["cliente_apellido"].ToString();
            apellidoNuevo = texto_apellido.Text;

            query = String.Format("select c.cliente_nombre from gesda.Cliente c where c.cliente_dni='{0}'", dni);
            dp = new SqlDataAdapter(query, Utilidades.conexion);
            ds = new DataSet();
            dp.Fill(ds);
            texto_nombre.Text = ds.Tables[0].Rows[0]["cliente_nombre"].ToString();
            nombreNuevo = texto_nombre.Text;

            query = String.Format("select c.cliente_mail from gesda.Cliente c where c.cliente_dni='{0}'", dni);
            dp = new SqlDataAdapter(query, Utilidades.conexion);
            ds = new DataSet();
            dp.Fill(ds);
            texto_mail.Text = ds.Tables[0].Rows[0]["cliente_mail"].ToString();
            mailNuevo = texto_mail.Text;

            query = String.Format("select c.cliente_telefono from gesda.Cliente c where c.cliente_dni='{0}'", dni);
            dp = new SqlDataAdapter(query, Utilidades.conexion);
            ds = new DataSet();
            dp.Fill(ds);
            texto_telefono.Text = ds.Tables[0].Rows[0]["cliente_telefono"].ToString();
            telefonoNuevo = texto_telefono.Text;

            query = String.Format("select c.cliente_direccion from gesda.Cliente c where c.cliente_dni='{0}'", dni);
            dp = new SqlDataAdapter(query, Utilidades.conexion);
            ds = new DataSet();
            dp.Fill(ds);
            texto_direccion.Text = ds.Tables[0].Rows[0]["cliente_direccion"].ToString();
            direccionNuevo = texto_direccion.Text;

            query = String.Format("select c.cliente_codigo_postal from gesda.Cliente c where c.cliente_dni='{0}'", dni);
            dp = new SqlDataAdapter(query, Utilidades.conexion);
            ds = new DataSet();
            dp.Fill(ds);
            texto_cp.Text = ds.Tables[0].Rows[0]["cliente_codigo_postal"].ToString();
            postalNuevo = texto_cp.Text;

            query = String.Format("select c.cliente_fecha_nacimiento from gesda.Cliente c where c.cliente_dni='{0}'", dni);
            dp = new SqlDataAdapter(query, Utilidades.conexion);
            ds = new DataSet();
            dp.Fill(ds);

            //Casteo y actualizo fecha
            String fechaString = ds.Tables[0].Rows[0]["cliente_fecha_nacimiento"].ToString();
            nacimientoNuevo = fechaString;
            DateTime fecha = Convert.ToDateTime(fechaString);
            dateTimePicker1.Value = fecha;

            query = String.Format("select c.cliente_estado from gesda.Cliente c where c.cliente_dni='{0}'", dni);
            dp = new SqlDataAdapter(query, Utilidades.conexion);
            ds = new DataSet();
            dp.Fill(ds);
            //texto_apellido.Text = ds.Tables[0].Rows[0]["cliente_apellido"].ToString();
            //apellidoNuevo = texto_apellido.Text; 

            if (ds.Tables[0].Rows[0]["cliente_estado"].ToString() == "1")
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }

        }

        
        private void modificar_nacimiento()
        {
            try
            {
                //llamo al procedure
                base.comando = new SqlCommand("GESDA.modificar_cliente_fecha_nac", Utilidades.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //declaro los parametros y seteo los parametros de entrada
                comando.Parameters.Add(new SqlParameter("@cliente_fecha_nac_nuevo", SqlDbType.DateTime, 88));
                comando.Parameters.Add(new SqlParameter("@cliente_dni", SqlDbType.Int, 88));
                comando.Parameters["@cliente_fecha_nac_nuevo"].Value = Convert.ToDateTime(dateTimePicker1.Value);
                comando.Parameters["@cliente_dni"].Value = Convert.ToInt32(texto_dni.Text);
                base.resultado = new SqlParameter("@resultado", SqlDbType.VarChar, 88);
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

        private void modificar_postal()
        {
            try
            {
                //llamo al procedure
                base.comando = new SqlCommand("GESDA.modificar_cliente_codigo_postal", Utilidades.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //declaro los parametros y seteo los parametros de entrada
                comando.Parameters.Add(new SqlParameter("@cliente_codigo_postal_nuevo", SqlDbType.Int, 88));
                comando.Parameters.Add(new SqlParameter("@cliente_dni", SqlDbType.Int, 88));
                comando.Parameters["@cliente_codigo_postal_nuevo"].Value = Convert.ToInt32(texto_cp.Text);
                comando.Parameters["@cliente_dni"].Value = Convert.ToInt32(texto_dni.Text);
                base.resultado = new SqlParameter("@resultado", SqlDbType.VarChar, 88);
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

        private void modificar_direccion()
        {
            try
            {
                //llamo al procedure
                base.comando = new SqlCommand("GESDA.modificar_cliente_direccion", Utilidades.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //declaro los parametros y seteo los parametros de entrada
                comando.Parameters.Add(new SqlParameter("@cliente_direccion_nuevo", SqlDbType.VarChar, 88));
                comando.Parameters.Add(new SqlParameter("@cliente_dni", SqlDbType.Int, 88));
                comando.Parameters["@cliente_direccion_nuevo"].Value = texto_direccion.Text;
                comando.Parameters["@cliente_dni"].Value = Convert.ToInt32(texto_dni.Text);
                base.resultado = new SqlParameter("@resultado", SqlDbType.VarChar, 88);
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

        private void modificar_telefono()
        {
            try
            {
                //llamo al procedure
                base.comando = new SqlCommand("GESDA.modificar_cliente_telefono", Utilidades.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //declaro los parametros y seteo los parametros de entrada
                comando.Parameters.Add(new SqlParameter("@cliente_telefono_nuevo", SqlDbType.Int, 88));
                comando.Parameters.Add(new SqlParameter("@cliente_dni", SqlDbType.Int, 88));
                comando.Parameters["@cliente_telefono_nuevo"].Value = Convert.ToInt32(texto_telefono.Text);
                comando.Parameters["@cliente_dni"].Value = Convert.ToInt32(texto_dni.Text);
                base.resultado = new SqlParameter("@resultado", SqlDbType.VarChar, 88);
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

        private void modificar_mail()
        {
            try
            {
                //llamo al procedure
                base.comando = new SqlCommand("GESDA.modificar_cliente_mail", Utilidades.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //declaro los parametros y seteo los parametros de entrada
                comando.Parameters.Add(new SqlParameter("@cliente_mail_nuevo", SqlDbType.VarChar, 88));
                comando.Parameters.Add(new SqlParameter("@cliente_dni", SqlDbType.Int, 88));
                comando.Parameters["@cliente_mail_nuevo"].Value = texto_mail.Text;
                comando.Parameters["@cliente_dni"].Value = Convert.ToInt32(texto_dni.Text);
                base.resultado = new SqlParameter("@resultado", SqlDbType.VarChar, 88);
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

        private void modificar_dni()
        {
            try
            {
                //llamo al procedure
                base.comando = new SqlCommand("GESDA.modificar_cliente_dni", Utilidades.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //declaro los parametros y seteo los parametros de entrada
                comando.Parameters.Add(new SqlParameter("@cliente_dni_nuevo", SqlDbType.Int, 88));
                comando.Parameters.Add(new SqlParameter("@cliente_dni", SqlDbType.Int, 88));
                comando.Parameters["@cliente_dni_nuevo"].Value = Convert.ToInt32(texto_dni.Text);
                comando.Parameters["@cliente_dni"].Value = Convert.ToInt32(this.dniNuevo);
                base.resultado = new SqlParameter("@resultado", SqlDbType.VarChar, 88);
                resultado.Direction = ParameterDirection.Output;
                comando.Parameters.Add(resultado);
                //ejecuto el comando 
                comando.ExecuteNonQuery();
                String resultadoString = comando.Parameters["@resultado"].Value.ToString();
                //muestro el resultado por pantalla
                MessageBox.Show(resultadoString);
                //actualizo el dni viejo
                this.dniNuevo = texto_dni.Text;
            }
            catch (Exception error)
            {
                MessageBox.Show("se produjo un error: " + error.ToString());
            }
        }

        private void modificar_apellido()
        {
            try
            {
                //llamo al procedure
                base.comando = new SqlCommand("GESDA.modificar_cliente_apellido", Utilidades.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //declaro los parametros y seteo los parametros de entrada
                comando.Parameters.Add(new SqlParameter("@cliente_apellido_nuevo", SqlDbType.VarChar, 88));
                comando.Parameters.Add(new SqlParameter("@cliente_dni", SqlDbType.Int, 88));
                comando.Parameters["@cliente_apellido_nuevo"].Value = texto_apellido.Text;
                comando.Parameters["@cliente_dni"].Value = Convert.ToInt32(texto_dni.Text);
                base.resultado = new SqlParameter("@resultado", SqlDbType.VarChar, 88);
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

        private void modificar_nombre()
        {
            try
            {
                //llamo al procedure
                base.comando = new SqlCommand("GESDA.modificar_cliente_nombre", Utilidades.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //declaro los parametros y seteo los parametros de entrada
                comando.Parameters.Add(new SqlParameter("@cliente_nombre_nuevo", SqlDbType.VarChar, 88));
                comando.Parameters.Add(new SqlParameter("@cliente_dni", SqlDbType.Int, 88));
                comando.Parameters["@cliente_nombre_nuevo"].Value = texto_nombre.Text;
                comando.Parameters["@cliente_dni"].Value = Convert.ToInt32(texto_dni.Text);
                base.resultado = new SqlParameter("@resultado", SqlDbType.VarChar, 88);
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

        private void boton_guardar_Click(object sender, EventArgs e)
        {
            base.errorValidar.Clear();

            if (this.validar())
            {
                try
                {
                    String nacimiento = Convert.ToString(dateTimePicker1.Value);

                    //modifico la fecha de nacimiento
                    if (nacimiento != nacimientoNuevo)
                    {
                        this.modificar_nacimiento();
                        nacimientoNuevo = nacimiento;
                    }

                    //modifico el codigo postal
                    if (texto_cp.Text != postalNuevo)
                    {
                        this.modificar_postal();
                        postalNuevo = texto_cp.Text;
                    }

                    //modifico la direccion
                    if (texto_direccion.Text != direccionNuevo)
                    {
                        this.modificar_direccion();
                        direccionNuevo = texto_direccion.Text;
                    }

                    //modifico el telefono
                    if (texto_telefono.Text != telefonoNuevo)
                    {
                        this.modificar_telefono();
                        telefonoNuevo = texto_telefono.Text;
                    }

                    //modifico el mail
                    if (texto_mail.Text != mailNuevo)
                    {
                        this.modificar_mail();
                        mailNuevo = texto_mail.Text;
                    }

                    //modifico dni
                    if (texto_dni.Text != dniNuevo)
                    {
                        this.modificar_dni();
                        dniNuevo = texto_dni.Text;
                    }

                    //modifico el apellido
                    if (texto_apellido.Text != apellidoNuevo)
                    {
                        this.modificar_apellido();
                        apellidoNuevo = texto_apellido.Text;
                    }

                    //modifico el nombre
                    if (texto_nombre.Text != nombreNuevo)
                    {
                        this.modificar_nombre();
                        nombreNuevo = texto_nombre.Text;
                    }
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

            if (texto_telefono.Text != String.Empty)
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

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                //habilito el cliente
                try
                {
                    //llamo al procedure
                    base.comando = new SqlCommand("GESDA.habilitar_cliente", Utilidades.conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    //declaro los parametros y seteo los parametros de entrada
                    comando.Parameters.Add(new SqlParameter("@cliente_dni", SqlDbType.Int, 88));
                    comando.Parameters["@cliente_dni"].Value = Convert.ToInt32(dniNuevo);
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
                //deshabilito el cliente
                try
                {
                    //llamo al procedure
                    base.comando = new SqlCommand("GESDA.deshabilitar_cliente", Utilidades.conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    //declaro los parametros y seteo los parametros de entrada
                    comando.Parameters.Add(new SqlParameter("@cliente_dni", SqlDbType.Int, 88));
                    comando.Parameters["@cliente_dni"].Value = Convert.ToInt32(dniNuevo);
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

    }
}
