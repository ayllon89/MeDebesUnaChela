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
using System.Globalization;


namespace PagoAgilFrba.AbmFactura
{
    
    public partial class Modificacion_Factura : PantallasGenericas.Pantalla_Alta
    {
        String mailNuevo;
        String cuitNuevo;
        String nroFactNuevo;
        String fechaAltaNuevo;
        String fechaVencNuevo;
        Decimal totalNuevo;
        String id_Factura_Nuevo;
        public DataTable dataTable = new DataTable();
        String mensaje;
        String mensaje1;
        String mensaje2;
        int filas_recorridas;

        public Modificacion_Factura()
        {
            InitializeComponent();
        }
        public Modificacion_Factura(String id_factura, String mail, String cuit, String numfact, Decimal total)
        {
            try
            {
                InitializeComponent();
                
                id_Factura_Nuevo = id_factura;

                textBox_mail.Text = mail;
                mailNuevo = mail;

                //Elimina la fila en blanco que se crea por defecto
                dataGridView1.AllowUserToAddRows = false;
                //Obtengo y agrego el cuit a textbox
                base.query = String.Format("SELECT empresa_cuit FROM GESDA.Empresa WHERE empresa_cuit = '{0}' UNION ALL SELECT empresa_cuit FROM GESDA.Empresa", cuit);
                base.comando = new SqlCommand(query, Utilidades.conexion);
                base.datos = base.comando.ExecuteReader();
                while (datos.Read())
                {
                    comboBox_cuit.Items.Add(datos["empresa_cuit"].ToString());
                }
                datos.Close();
                //selecciono el primer elemento del comboBox
                comboBox_cuit.SelectedIndex = 0;
                cuitNuevo = comboBox_cuit.SelectedItem.ToString();
                datos.Close();

                textBox_num_factura.Text = numfact;
                nroFactNuevo = numfact;

                query = String.Format("SELECT factura_fecha_alta FROM GESDA.Factura WHERE id_factura ='{0}'", id_factura);
                dp = new SqlDataAdapter(query, Utilidades.conexion);
                dp.Fill(ds);
                dateTimePicker_fecha_alta.Text = ds.Tables[0].Rows[0]["factura_fecha_alta"].ToString();
                fechaAltaNuevo = ds.Tables[0].Rows[0]["factura_fecha_alta"].ToString();
                
                ds.Clear();
                query = String.Format("SELECT factura_fecha_vencimiento FROM GESDA.Factura WHERE id_factura ='{0}'", id_factura);
                dp = new SqlDataAdapter(query, Utilidades.conexion);
                dp.Fill(ds);
                dateTimePicker_fecha_venc.Text = ds.Tables[0].Rows[0]["factura_fecha_vencimiento"].ToString();
                fechaVencNuevo = ds.Tables[0].Rows[0]["factura_fecha_vencimiento"].ToString();
                
                //lleno el dataGridView
                this.mostrar_datagridview();

                //Agrego el total al textBox
                textBox_total.Text = Convert.ToString(total, CultureInfo.CreateSpecificCulture("en-US"));
                totalNuevo = Convert.ToDecimal(total, CultureInfo.CreateSpecificCulture("en-US"));

                //averiguo el estado de la factura
                query = String.Format("SELECT factura_estado FROM GESDA.factura WHERE id_factura='{0}'", id_Factura_Nuevo);
                dp = new SqlDataAdapter(query, Utilidades.conexion);
                ds = new DataSet();
                dp.Fill(ds);
                
                //Le paso el estado de la factura
                if (ds.Tables[0].Rows[0]["factura_estado"].ToString() == "1")
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

        private void button_agregar_Click(object sender, EventArgs e)
        {
            this.errorValidar.Clear();
            //verifico que ingrese datos en descripcion, monto y cantidad
            //y que monto y cantidad sean numericos
            if (this.validar_item())
            {
                //Opcion mejorada. Solo actualiza el datagridview y se aplican lo cambios en la tabla a precionar confirmar

                //Agrego el item 
                DataRow row = dataTable.NewRow();
                row["monto"] = Convert.ToDecimal(textBox_monto.Text, CultureInfo.CreateSpecificCulture("en-US"));
                row["cantidad"] = Convert.ToInt32(textBox_cantidad.Text, CultureInfo.CreateSpecificCulture("en-US")); ;
                row["descripcion"] = textBox_descripcion.Text;
                dataTable.Rows.Add(row);
                //Actualizo el total
                this.sumar_total(textBox_monto.Text);
                //limpio los textbox de item
                this.limpiar_textBox_item();

            }
        }

        private void mostrar_datagridview()
        {
            if (dataGridView1.RowCount > 0)
            {
                dataTable.Clear();
                base.query = String.Format("SELECT factura_detalle_monto AS monto, factura_detalle_cantidad AS cantidad, factura_detalle_descripcion AS descripcion FROM  GESDA.Factura_Detalle WHERE id_factura = '{0}'", id_Factura_Nuevo);
                base.dp = new SqlDataAdapter(query, Utilidades.conexion);
                base.dp.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            else
            {
                dataTable.Clear();
                base.query = String.Format("SELECT factura_detalle_monto AS monto, factura_detalle_cantidad AS cantidad, factura_detalle_descripcion AS descripcion FROM  GESDA.Factura_Detalle WHERE id_factura = '{0}'", id_Factura_Nuevo);
                base.dp = new SqlDataAdapter(query, Utilidades.conexion);
                base.dp.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void agregar_item()
        {
            try
            {
                //llamo al procedure
                base.comando = new SqlCommand("GESDA.agregar_item_modificacion", Utilidades.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //declaro y seteo los parametros de entrada
                comando.Parameters.Add(new SqlParameter("@id_factura", SqlDbType.Int, 88));
                comando.Parameters.Add(new SqlParameter("@monto", SqlDbType.Decimal, 88));
                comando.Parameters.Add(new SqlParameter("@cantidad", SqlDbType.Int, 88));
                comando.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.VarChar, 88));

                comando.Parameters["@id_factura"].Value = Convert.ToInt32(id_Factura_Nuevo);
                comando.Parameters["@monto"].Value = Convert.ToDecimal(textBox_monto.Text);
                comando.Parameters["@cantidad"].Value = Convert.ToInt32(textBox_cantidad.Text);
                comando.Parameters["@descripcion"].Value = textBox_descripcion.Text;

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

        public bool validar_item()
        {
            bool noHayError = true;

            if (textBox_descripcion.Text == String.Empty)
            {
                //al error provider le paso el texbox o boton que no cumple la validacion
                errorValidar.SetError(textBox_descripcion, "Por favor complete este campo");
                noHayError = false;
            }
            if (textBox_monto.Text == String.Empty)
            {
                //al error provider le paso el texbox o boton que no cumple la validacion
                errorValidar.SetError(textBox_monto, "Por favor complete este campo");
                noHayError = false;
            }
            else
            {
                if (Convert.ToDecimal(textBox_monto.Text, CultureInfo.CreateSpecificCulture("en-US")) <= 0)
                {
                    errorValidar.SetError(textBox_monto, "No se permite monto cero");
                    noHayError = false;
                }
            }
            if (textBox_cantidad.Text == String.Empty)
            {
                //al error provider le paso el texbox o boton que no cumple la validacion
                errorValidar.SetError(textBox_cantidad, "Por favor complete este campo");
                noHayError = false;
            }
            else
            {
                if (Convert.ToInt32(textBox_cantidad.Text) <= 0)
                {
                    errorValidar.SetError(textBox_cantidad, "No se permite cantidad cero");
                    noHayError = false;
                }
            }

            return noHayError;
        }

        public void limpiar_textBox_item()
        {
            textBox_descripcion.Text = "";
            textBox_monto.Text = "";
            textBox_cantidad.Text = "";
        }

        private void button_quitar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                //obtengo el valor del monto antes de borrar el registro
                String monto = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value, CultureInfo.CreateSpecificCulture("en-US"));
                //quito el item seleccionado del dataGridView
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                //resto el monto en el total
                this.restar_total(monto);
            }
        }
        private void restar_total(string valor)
        {
            if (textBox_total.Text == "")
            {
                textBox_total.Text = Convert.ToString("0.0", CultureInfo.CreateSpecificCulture("en-US"));
            }
            else
            {
                if (Convert.ToDecimal(textBox_total.Text, CultureInfo.CreateSpecificCulture("en-US")) < Convert.ToDecimal(valor, CultureInfo.CreateSpecificCulture("en-US")))
                {
                    textBox_total.Text = Convert.ToString("0.0", CultureInfo.CreateSpecificCulture("en-US"));
                }
                else
                {
                    decimal total = Convert.ToDecimal(textBox_total.Text, CultureInfo.CreateSpecificCulture("en-US")) - Convert.ToDecimal(valor, CultureInfo.CreateSpecificCulture("en-US"));
                    textBox_total.Text = Convert.ToString(total, CultureInfo.CreateSpecificCulture("en-US"));
                }
            }
        }

        private void sumar_total(string valor)
        {
            decimal total = Convert.ToDecimal(textBox_total.Text, CultureInfo.CreateSpecificCulture("en-US")) + Convert.ToDecimal(valor, CultureInfo.CreateSpecificCulture("en-US"));        
            textBox_total.Text = Convert.ToString(total, CultureInfo.CreateSpecificCulture("en-US"));
        }
        //controla que el monto sea numerico y que solo permita un punto
        private void textBox_monto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < textBox_monto.Text.Length; i++)
            {
                if (textBox_monto.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }

            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }
        //Controla que la cantidad sea numerico y entero. Lo uso para la cantidad
        private void textBox_cantidad_KeyPress(object sender, KeyPressEventArgs e)
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
            else
            {
                e.Handled = true;
            }
        }

        private void boton_guardar_Click(object sender, EventArgs e)
        {
            this.errorValidar.Clear();
            filas_recorridas = 0;

            if (this.validar_factura())
            {
                try
                {
                    //Obtengo la suma de los montos de todos los items de la factura
                    decimal sumatoria = 0;
                    foreach(DataGridViewRow row in dataGridView1.Rows)
                    {
                        sumatoria += Convert.ToDecimal(row.Cells["monto"].Value, CultureInfo.CreateSpecificCulture("en-US"));    
                    }
                    decimal sumMonto = Convert.ToDecimal(sumatoria,CultureInfo.CreateSpecificCulture("en-US"));

                    if (sumMonto == Convert.ToDecimal(textBox_total.Text, CultureInfo.CreateSpecificCulture("en-US")))
                    {
                        //verifico si los datos de mail cuit nrofact y fechas fueron modificados
                        if (mailNuevo == textBox_mail.Text && nroFactNuevo == textBox_num_factura.Text && fechaAltaNuevo == dateTimePicker_fecha_alta.Text && fechaVencNuevo == dateTimePicker_fecha_venc.Text)
                        {
                            //Ho hago cambios en la tabla factura
                            mensaje2 = "Los datos iniciales de la factura se mantuvieron iguales";
                            MessageBox.Show(mensaje2);
                        }
                        else
                        {
                            if (textBox_num_factura.Text == nroFactNuevo)
                            {
                                //hago cambios en la tabla factura

                                //llamo al procedure
                                base.comando = new SqlCommand("GESDA.guardar_factura_modificada_nro_factura_igual", Utilidades.conexion);
                                comando.CommandType = CommandType.StoredProcedure;
                                //declaro y seteo los parametros de entrada
                                comando.Parameters.Add(new SqlParameter("@id_factura", SqlDbType.Int, 88));
                                comando.Parameters.Add(new SqlParameter("@mail_cliente", SqlDbType.VarChar, 88));
                                comando.Parameters.Add(new SqlParameter("@cuit_empresa", SqlDbType.VarChar, 88));
                                comando.Parameters.Add(new SqlParameter("@numero_factura", SqlDbType.Int, 88));
                                comando.Parameters.Add(new SqlParameter("@fecha_alta", SqlDbType.DateTime, 88));
                                comando.Parameters.Add(new SqlParameter("@fecha_vencimiento", SqlDbType.DateTime, 88));
                                comando.Parameters.Add(new SqlParameter("@total", SqlDbType.Decimal, 88));
                                comando.Parameters["@id_factura"].Value = Convert.ToInt32(id_Factura_Nuevo);
                                comando.Parameters["@mail_cliente"].Value = textBox_mail.Text;
                                comando.Parameters["@cuit_empresa"].Value = comboBox_cuit.Text;
                                comando.Parameters["@numero_factura"].Value = Convert.ToInt32(textBox_num_factura.Text);
                                comando.Parameters["@fecha_alta"].Value = Convert.ToDateTime(dateTimePicker_fecha_alta.Text);
                                comando.Parameters["@fecha_vencimiento"].Value = Convert.ToDateTime(dateTimePicker_fecha_venc.Text);
                                comando.Parameters["@total"].Value = Convert.ToDecimal(textBox_total.Text, CultureInfo.CreateSpecificCulture("en-US"));

                                resultado = new SqlParameter("@resultado", SqlDbType.VarChar, 88);
                                resultado.Direction = ParameterDirection.Output;
                                comando.Parameters.Add(resultado);
                                //ejecuto el comando 
                                comando.ExecuteNonQuery();
                                String resultadoString = comando.Parameters["@resultado"].Value.ToString();
                                //guardo el mensaje del resultado
                                mensaje = resultadoString;
                                MessageBox.Show(resultadoString);
                            }
                            else
                            {
                                //hago cambios en la tabla factura

                                //llamo al procedure
                                base.comando = new SqlCommand("GESDA.guardar_factura_modificada_nro_factura_distinto", Utilidades.conexion);
                                comando.CommandType = CommandType.StoredProcedure;
                                //declaro y seteo los parametros de entrada
                                comando.Parameters.Add(new SqlParameter("@id_factura", SqlDbType.Int, 88));
                                comando.Parameters.Add(new SqlParameter("@mail_cliente", SqlDbType.VarChar, 88));
                                comando.Parameters.Add(new SqlParameter("@cuit_empresa", SqlDbType.VarChar, 88));
                                comando.Parameters.Add(new SqlParameter("@numero_factura", SqlDbType.Int, 88));
                                comando.Parameters.Add(new SqlParameter("@fecha_alta", SqlDbType.DateTime, 88));
                                comando.Parameters.Add(new SqlParameter("@fecha_vencimiento", SqlDbType.DateTime, 88));
                                comando.Parameters.Add(new SqlParameter("@total", SqlDbType.Decimal, 88));
                                comando.Parameters["@id_factura"].Value = Convert.ToInt32(id_Factura_Nuevo);
                                comando.Parameters["@mail_cliente"].Value = textBox_mail.Text;
                                comando.Parameters["@cuit_empresa"].Value = comboBox_cuit.Text;
                                comando.Parameters["@numero_factura"].Value = Convert.ToInt32(textBox_num_factura.Text);
                                comando.Parameters["@fecha_alta"].Value = Convert.ToDateTime(dateTimePicker_fecha_alta.Text);
                                comando.Parameters["@fecha_vencimiento"].Value = Convert.ToDateTime(dateTimePicker_fecha_venc.Text);
                                comando.Parameters["@total"].Value = Convert.ToDecimal(textBox_total.Text, CultureInfo.CreateSpecificCulture("en-US"));

                                resultado = new SqlParameter("@resultado", SqlDbType.VarChar, 88);
                                resultado.Direction = ParameterDirection.Output;
                                comando.Parameters.Add(resultado);
                                //ejecuto el comando 
                                comando.ExecuteNonQuery();
                                String resultadoString = comando.Parameters["@resultado"].Value.ToString();
                                //guardo el mensaje del resultado
                                mensaje1 = resultadoString;
                                MessageBox.Show(resultadoString);
                            }
                        }


                        //Si la factura se pudo modificar o no se realizaron cambios, continuo con lo items
                        if (mensaje == "La factura se modifico" || mensaje == "Los datos iniciales de la factura se mantuvieron iguales" || mensaje1 == "La factura se modifico")
                        {
                            //Agrego los items a la tabla factura_detalle si estos no estan
                            for (int i = 0; i < dataGridView1.RowCount; i++)
                            {
                                //Capturo los datos de la fila del datGridView
                                decimal itemMonto = Convert.ToDecimal(dataGridView1.Rows[i].Cells[0].Value, CultureInfo.CreateSpecificCulture("en-US"));
                                int itemCantidad = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                                string itemDescripcion = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);
                                //llamo al procedure
                                base.comando = new SqlCommand("GESDA.agregar_item_modificacion", Utilidades.conexion);
                                comando.CommandType = CommandType.StoredProcedure;
                                //declaro y seteo los parametros de entrada
                                comando.Parameters.Add(new SqlParameter("@id_factura", SqlDbType.Int, 88));
                                comando.Parameters.Add(new SqlParameter("@monto", SqlDbType.Decimal, 88));
                                comando.Parameters.Add(new SqlParameter("@cantidad", SqlDbType.Int, 88));
                                comando.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.VarChar, 88));

                                comando.Parameters["@id_factura"].Value = id_Factura_Nuevo;
                                comando.Parameters["@monto"].Value = itemMonto;
                                comando.Parameters["@cantidad"].Value = itemCantidad;
                                comando.Parameters["@descripcion"].Value = itemDescripcion;

                                SqlParameter resultado2 = new SqlParameter("@resultado", SqlDbType.VarChar, 88);
                                resultado2.Direction = ParameterDirection.Output;
                                comando.Parameters.Add(resultado2);
                                //ejecuto el comando 
                                comando.ExecuteNonQuery();
                                String resultadoString2 = comando.Parameters["@resultado"].Value.ToString();
                                filas_recorridas = i;

                            }
                        }
                        if (dataGridView1.RowCount == filas_recorridas)
                        {
                            MessageBox.Show("Los items se actualizaron");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El total difiere con la suma de los items, vuelva a revisar los datos");
                    }      
                }
                catch (Exception error)
                {
                    MessageBox.Show("se produjo un error: " + error.ToString());
                }
            }
        }
        
        public bool validar_factura()
        {
            bool noHayError = true;

            //valido que el campo uno no este vacio
            if (textBox_mail.Text == String.Empty)
            {

                //al error provider le paso el texbox o boton que no cumple la validacion
                errorValidar.SetError(textBox_mail, "Por favor complete este campo");
                noHayError = false;
            }
            if ((comboBox_cuit.SelectedIndex < 0))
            {
                //al error provider le paso el combo box que no cumple la validacion
                errorValidar.SetError(comboBox_cuit, "Por favor selecione un item");
                noHayError = false;
            }
            if (textBox_num_factura.Text == String.Empty)
            {
                //al error provider le paso el texbox o boton que no cumple la validacion
                errorValidar.SetError(textBox_num_factura, "Por favor complete este campo");
                noHayError = false;
            }
            else
            {
                try
                {
                    //como el campo no es vacio, verifico si el dato que ingresaron es del tipo numerico
                    int i = Convert.ToInt32(textBox_num_factura.Text);
                }
                catch
                {
                    errorValidar.SetError(textBox_num_factura, "Por favor introdusca un campo numerico");
                    noHayError = false;
                }
            }
            if (dateTimePicker_fecha_venc.Value.Date <= dateTimePicker_fecha_alta.Value.Date)
            {
                //al error provider le paso el texbox o boton que no cumple la validacion
                errorValidar.SetError(dateTimePicker_fecha_venc, "Por favor seleccione una fecha mayor al alta");
                noHayError = false;
            }
            if (textBox_total.Text == String.Empty)
            {
                errorValidar.SetError(textBox_total, "Por favor complete este campo");
                noHayError = false;
            }
            //Verifico que la factura tenga items
            if (dataGridView1.RowCount == 0)
            {
                errorValidar.SetError(dataGridView1, "Por favor agregue items a la factura");
                noHayError = false;
            }
            return noHayError;
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                //habilito la facutra
                try
                {
                    //llamo al procedure
                    base.comando = new SqlCommand("GESDA.habilitar_factura", Utilidades.conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    //declaro los parametros y seteo los parametros de entrada
                    comando.Parameters.Add(new SqlParameter("@id_factura", SqlDbType.Int, 88));
                    comando.Parameters["@id_factura"].Value = id_Factura_Nuevo;
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
                //deshabilito la factura
                try
                {
                    //llamo al procedure
                    base.comando = new SqlCommand("GESDA.deshabilitar_factura", Utilidades.conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    //declaro los parametros y seteo los parametros de entrada
                    comando.Parameters.Add(new SqlParameter("@id_factura", SqlDbType.Int, 88));
                    comando.Parameters["@id_factura"].Value = id_Factura_Nuevo;
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

        private void textBox_total_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            //incluyo el punto
            if (textBox_total.Text.Contains('.'))
            {
                if(!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else
            {
                if(!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if(e.KeyChar=='.')
                {
                    e.Handled = false;
                }
            }
            //incluyo el retroceso
            if (textBox_total.Text.Contains('.'))
            {
                if(!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
            else
            {
                if(!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if(e.KeyChar=='.' || e.KeyChar=='\b')
                {
                    e.Handled = false;
                }
            }            
        }

        private void button_suma_de_montos_Click(object sender, EventArgs e)
        {
            decimal sumatoria1 = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                sumatoria1 += Convert.ToDecimal(row.Cells["monto"].Value, CultureInfo.CreateSpecificCulture("en-US"));
            }
            decimal sumMonto1 = Convert.ToDecimal(sumatoria1, CultureInfo.CreateSpecificCulture("en-US"));

            textBox_total.Text = Convert.ToString(sumMonto1, CultureInfo.CreateSpecificCulture("en-US"));
        }
           
    }
}
