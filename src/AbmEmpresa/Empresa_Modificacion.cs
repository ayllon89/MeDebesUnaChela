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
    public partial class Empresa_Modificacion : PantallasGenericas.Pantalla_Alta
    {
        String nombreActual;
        String cuitActual;
        String direccionActual;
        String rubroActual;

        public Empresa_Modificacion(String cuit)
        {
            InitializeComponent();
            try
            {

                texto_cuit.Text = cuit;
                cuitActual = cuit;

                //averiguo el nombre
                base.query = String.Format("select e.empresa_nombre from gesda.Empresa e where e.empresa_cuit='{0}'", cuit);
                base.dp = new SqlDataAdapter(query, Utilidades.conexion);
                base.dp.Fill(ds);
                texto_nombre.Text = ds.Tables[0].Rows[0]["empresa_nombre"].ToString();
                nombreActual = texto_nombre.Text;

                //averiguo la direccion
                base.query = String.Format("select e.empresa_direccion from gesda.Empresa e where e.empresa_cuit='{0}'", cuit);
                base.dp = new SqlDataAdapter(query, Utilidades.conexion);
                ds = new DataSet();
                base.dp.Fill(ds);
                texto_direccion.Text = ds.Tables[0].Rows[0]["empresa_direccion"].ToString();
                direccionActual = texto_direccion.Text;

                //averiguo el rubro
                base.query = String.Format("select r.rubro_descripcion from gesda.Empresa e join gesda.Rubro r on (r.id_rubro=e.id_rubro) where e.empresa_cuit='{0}' union all select distinct rubro_descripcion from gesda.Rubro", cuit);
                base.comando = new SqlCommand(query, Utilidades.conexion);
                base.datos = base.comando.ExecuteReader();
                while (datos.Read())
                {
                    combo_rubro.Items.Add(datos["rubro_descripcion"].ToString());
                }
                //selecciono el primer elemento del combo box
                combo_rubro.SelectedIndex = 0;
                rubroActual = combo_rubro.SelectedItem.ToString();
                datos.Close();

                //averiguo si la empresa esta dada de baja
                query = String.Format("select e.empresa_estado from GESDA.Empresa e where e.empresa_cuit='{0}'", cuit);
                dp = new SqlDataAdapter(query, Utilidades.conexion);
                ds = new DataSet();
                dp.Fill(ds);

                if (ds.Tables[0].Rows[0]["empresa_estado"].ToString() == "1")
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

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                //habilito la empresa
                try
                {
                    //llamo al procedure
                    base.comando = new SqlCommand("GESDA.habilitar_empresa", Utilidades.conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    //declaro los parametros y seteo los parametros de entrada
                    comando.Parameters.Add(new SqlParameter("@empresa_cuit", SqlDbType.VarChar, 88));
                    comando.Parameters["@empresa_cuit"].Value = cuitActual;
                    SqlParameter resultado = new SqlParameter("@resultado", SqlDbType.VarChar, 200);
                    resultado.Direction = ParameterDirection.Output;
                    comando.Parameters.Add(resultado);
                    //ejecuto el comando 
                    comando.ExecuteNonQuery();
                    String resultadoString = comando.Parameters["@resultado"].Value.ToString();
                    //muestro el resultado por pantalla
                    MessageBox.Show(resultadoString);

                    if (resultadoString != "Se habilito empresa correctamente")
                    {
                        checkBox1.Checked = false;
                    }

                }
                catch (Exception error)
                {
                    MessageBox.Show("se produjo un error: " + error.ToString());
                }

            }
            else
            {
                //deshabilito la empresa
                try
                {
                    //llamo al procedure
                    base.comando = new SqlCommand("GESDA.deshabilitar_empresa", Utilidades.conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    //declaro los parametros y seteo los parametros de entrada
                    comando.Parameters.Add(new SqlParameter("@empresa_cuit", SqlDbType.VarChar, 88));
                    comando.Parameters["@empresa_cuit"].Value = cuitActual;
                    SqlParameter resultado = new SqlParameter("@resultado", SqlDbType.VarChar, 88);
                    resultado.Direction = ParameterDirection.Output;
                    comando.Parameters.Add(resultado);
                    //ejecuto el comando 
                    comando.ExecuteNonQuery();
                    String resultadoString = comando.Parameters["@resultado"].Value.ToString();
                    //muestro el resultado por pantalla
                    MessageBox.Show(resultadoString);

                    if (resultadoString != "Se deshabilito empresa correctamente")
                    {
                        checkBox1.Checked = true;
                    }

                }
                catch (Exception error)
                {
                    MessageBox.Show("se produjo un error: " + error.ToString());
                }
            }
        }

        private void boton_guardar_Click(object sender, EventArgs e)
        {
            base.errorValidar.Clear();

            if (this.validar())
            {
                try
                {
                    //modifico el nombre
                    if (texto_nombre.Text != nombreActual)
                    {
                        this.modificar_nombre();
                        //actualizo el modelo
                        nombreActual = texto_nombre.Text;
                    }
                    //modifico el cuit
                    if (texto_cuit.Text != cuitActual)
                    {
                        this.modificar_cuit();
                        //actualizo la patente
                        cuitActual = texto_cuit.Text;
                    }
                    //modifico la direccion
                    if (texto_direccion.Text != direccionActual)
                    {
                        this.modificar_direccion();
                        //actualizo la patente
                        direccionActual = texto_direccion.Text;
                    }
                    //modifico el rubro
                    if (combo_rubro.SelectedItem.ToString() != rubroActual)
                    {
                        this.modificar_rubro();
                        //actualizo la marca
                        rubroActual = combo_rubro.SelectedItem.ToString();
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("se produjo un error: " + error.ToString());
                }
            }
        }

        private void modificar_nombre()
        {
            try
            {
                //llamo al procedure
                base.comando = new SqlCommand("GESDA.modificar_empresa_nombre", Utilidades.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //declaro los parametros y seteo los parametros de entrada
                comando.Parameters.Add(new SqlParameter("@empresa_nombre_nuevo", SqlDbType.VarChar, 88));
                comando.Parameters.Add(new SqlParameter("@empresa_cuit", SqlDbType.VarChar, 88));
                comando.Parameters["@empresa_nombre_nuevo"].Value = texto_nombre.Text;
                comando.Parameters["@empresa_cuit"].Value = cuitActual;
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

        private void modificar_cuit()
        {
            try
            {
                //llamo al procedure
                base.comando = new SqlCommand("GESDA.modificar_empresa_cuit", Utilidades.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //declaro los parametros y seteo los parametros de entrada
                comando.Parameters.Add(new SqlParameter("@empresa_cuit_nuevo", SqlDbType.VarChar, 88));
                comando.Parameters.Add(new SqlParameter("@empresa_cuit", SqlDbType.VarChar, 88));
                comando.Parameters["@empresa_cuit_nuevo"].Value = texto_cuit.Text;
                comando.Parameters["@empresa_cuit"].Value = cuitActual;
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
                base.comando = new SqlCommand("GESDA.modificar_empresa_direccion", Utilidades.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //declaro los parametros y seteo los parametros de entrada
                comando.Parameters.Add(new SqlParameter("@empresa_direccion_nuevo", SqlDbType.VarChar, 88));
                comando.Parameters.Add(new SqlParameter("@empresa_cuit", SqlDbType.VarChar, 88));
                comando.Parameters["@empresa_direccion_nuevo"].Value = texto_direccion.Text;
                comando.Parameters["@empresa_cuit"].Value = cuitActual;
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

        private void modificar_rubro()
        {
            try
            {
                //llamo al procedure
                base.comando = new SqlCommand("GESDA.modificar_empresa_rubro", Utilidades.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //declaro los parametros y seteo los parametros de entrada
                comando.Parameters.Add(new SqlParameter("@empresa_rubro_nuevo", SqlDbType.VarChar, 88));
                comando.Parameters.Add(new SqlParameter("@empresa_cuit", SqlDbType.VarChar, 88));
                comando.Parameters["@empresa_rubro_nuevo"].Value = combo_rubro.SelectedItem.ToString();
                comando.Parameters["@empresa_cuit"].Value = cuitActual;
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

            if (combo_rubro.Text == String.Empty)
            {
                //al error provider le paso el texbox o boton que no cumple la validacion
                errorValidar.SetError(combo_rubro, "Por favor complete este campo");
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
