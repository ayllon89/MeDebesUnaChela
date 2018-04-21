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
    public partial class Alta_Factura : PantallasGenericas.Pantalla_Alta
    {

        string idFactura;
        string mensaje;

        public Alta_Factura()
        {
            InitializeComponent();

            //lleno el combo con CUITs de empresas
            base.comando = new SqlCommand("SELECT empresa_cuit FROM GESDA.Empresa ORDER BY empresa_cuit", Utilidades.conexion);
            base.datos = base.comando.ExecuteReader();
            while (datos.Read())
            {
                comboBox_empresa.Items.Add(datos["empresa_cuit"].ToString());
            }
            datos.Close();
            //Inicializo el DataGridView

            //Elimina la fila en blanco que se crea por defecto
            dataGridView1.AllowUserToAddRows = false;
            //Agrego las columnas del DataGridView
            dataGridView1.Columns.Add("factura_detalle_monto", "Monto");
            dataGridView1.Columns.Add("factura_detalle_cantidad", "Cantidad");
            dataGridView1.Columns.Add("factura_detalle_descripcion", "Descripcion");
            //Bloqueo que se puedadn ingresar datos desde el DataGridView
            dataGridView1.Columns["factura_detalle_monto"].ReadOnly = true;
            dataGridView1.Columns["factura_detalle_cantidad"].ReadOnly = true;
            dataGridView1.Columns["factura_detalle_descripcion"].ReadOnly = true;

            //inicializo el textbox total en cero
            textBox_total.Text = "0";
            //Seteo las fechas
            dateTimePicker_fecha_alta.Value = Utilidades.fecha;
            dateTimePicker_frcha_venc.Value = Utilidades.fecha;
        }

        private void boton_limpiar_Click(object sender, EventArgs e)
        {
            this.limpiar_pantalla();
        }

        private void boton_guardar_Click(object sender, EventArgs e)
        {
            this.errorValidar.Clear();

            if (this.validar_factura())
            {
                try
                {
                    //llamo al procedure
                    base.comando = new SqlCommand("GESDA.guardar_factura", Utilidades.conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    //declaro y seteo los parametros de entrada
                    comando.Parameters.Add(new SqlParameter("@mail_cliente", SqlDbType.VarChar, 88));
                    comando.Parameters.Add(new SqlParameter("@cuit_empresa", SqlDbType.VarChar, 88));
                    comando.Parameters.Add(new SqlParameter("@numero_factura", SqlDbType.Int, 88));
                    comando.Parameters.Add(new SqlParameter("@fecha_alta", SqlDbType.DateTime, 88));
                    comando.Parameters.Add(new SqlParameter("@fecha_vencimiento", SqlDbType.DateTime, 88));
                    comando.Parameters.Add(new SqlParameter("@total", SqlDbType.Decimal, 88));
                    comando.Parameters["@mail_cliente"].Value = textBox_mail.Text;
                    comando.Parameters["@cuit_empresa"].Value = comboBox_empresa.SelectedItem.ToString();
                    comando.Parameters["@numero_factura"].Value = Convert.ToInt32(textBox_num_factura.Text);
                    comando.Parameters["@fecha_alta"].Value = Convert.ToDateTime(dateTimePicker_fecha_alta.Text);
                    comando.Parameters["@fecha_vencimiento"].Value = Convert.ToDateTime(dateTimePicker_frcha_venc.Text);
                    comando.Parameters["@total"].Value = Convert.ToDecimal(textBox_total.Text, CultureInfo.CreateSpecificCulture("en-US"));

                    resultado = new SqlParameter("@resultado", SqlDbType.VarChar, 88);
                    resultado.Direction = ParameterDirection.Output;
                    comando.Parameters.Add(resultado);
                    //ejecuto el comando 
                    comando.ExecuteNonQuery();
                    String resultadoString = comando.Parameters["@resultado"].Value.ToString();
                    //guardo el mensaje del resultado
                    mensaje = resultadoString;
                    if (mensaje == "La factura se pudo dar de alta")
                    {
                     
                        //Obtengo el id_factura
                        ds.Clear();
                        query = String.Format("SELECT MAX(id_factura) ultimoId from GESDA.Factura");
                        dp = new SqlDataAdapter(query, Utilidades.conexion);
                        dp.Fill(ds);
                        idFactura = ds.Tables[0].Rows[0]["ultimoId"].ToString();


                        //Agrego los items a la tabla factura_detalle
                        for (int i = 0; i < dataGridView1.RowCount; i++)
                        {
                            //Capturo los datos de la fila del datGridView
                            decimal itemMonto = Convert.ToDecimal(dataGridView1.Rows[i].Cells[0].Value, CultureInfo.CreateSpecificCulture("en-US"));
                            int itemCantidad = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                            string itemDescripcion = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);
                            //llamo al procedure
                            base.comando = new SqlCommand("GESDA.agregar_item", Utilidades.conexion);
                            comando.CommandType = CommandType.StoredProcedure;
                            //declaro y seteo los parametros de entrada
                            comando.Parameters.Add(new SqlParameter("@id_factura", SqlDbType.Int, 88));
                            comando.Parameters.Add(new SqlParameter("@monto", SqlDbType.Decimal, 88));
                            comando.Parameters.Add(new SqlParameter("@cantidad", SqlDbType.Int, 88));
                            comando.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.VarChar, 88));

                            comando.Parameters["@id_factura"].Value = Convert.ToInt32(idFactura);
                            comando.Parameters["@monto"].Value = Convert.ToDecimal(itemMonto, CultureInfo.CreateSpecificCulture("en-US"));
                            comando.Parameters["@cantidad"].Value = Convert.ToInt32(itemCantidad);
                            comando.Parameters["@descripcion"].Value = itemDescripcion;

                            SqlParameter resultado2 = new SqlParameter("@resultado", SqlDbType.VarChar, 88);
                            resultado2.Direction = ParameterDirection.Output;
                            comando.Parameters.Add(resultado2);
                            //ejecuto el comando 
                            comando.ExecuteNonQuery();
                            String resultadoString2 = comando.Parameters["@resultado"].Value.ToString();
                        }
                        //limpiar pantalla
                        this.limpiar_pantalla();
                    }

                    //muestro el mensaje de retorno
                    MessageBox.Show(resultadoString);
           
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
            if ((comboBox_empresa.SelectedIndex < 0))
            {
                //al error provider le paso el combo box que no cumple la validacion
                errorValidar.SetError(comboBox_empresa, "Por favor selecione un item");
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

            if (dateTimePicker_frcha_venc.Value.Date <= dateTimePicker_fecha_alta.Value.Date)
            {
                //al error provider le paso el texbox o boton que no cumple la validacion
                errorValidar.SetError(dateTimePicker_frcha_venc, "Por favor seleccione una fecha mayor al alta");
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

        private void button_agregar_Click(object sender, EventArgs e)
        {
            this.errorValidar.Clear();
            //verifico que ingrese datos en descripcion, monto y cantidad
            //y que monto y cantidad sean numericos
            if (this.validar_item())
            {   
                //agrego el item al datagridview
                dataGridView1.Rows.Add(textBox_monto.Text, textBox_cantidad.Text, textBox_descripcion.Text);
                //Actualizo el total
                this.sumar_total(textBox_monto.Text);
                //limpio los textbox de item
                this.limpiar_textBox_item();
            }                
        }

        private void button_quitar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount >0)
            {
                //obtengo el valor antes de borrar el registro
                String monto = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);
                //quito el item seleccionado del dataGridView
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                //resto el monto en el total
                this.restar_total(monto);
            }
        }
        public void limpiar_textBox_item()
        {
            textBox_descripcion.Text = "";
            textBox_monto.Text = "";
            textBox_cantidad.Text = "";
        }
        public bool validar_item()
        {
            bool noHayError = true;

            if (textBox_monto.Text == String.Empty)
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

        private void sumar_total(string valor)
        {
            decimal total = Convert.ToDecimal(textBox_total.Text,CultureInfo.CreateSpecificCulture("en-US")) + Convert.ToDecimal(valor,CultureInfo.CreateSpecificCulture("en-US"));
            textBox_total.Text = Convert.ToString(total,CultureInfo.CreateSpecificCulture("en-US"));
        }

        private void restar_total(string valor)
        {
            decimal total = Convert.ToDecimal(textBox_total.Text, CultureInfo.CreateSpecificCulture("en-US")) - Convert.ToDecimal(valor, CultureInfo.CreateSpecificCulture("en-US"));
            textBox_total.Text = Convert.ToString(total, CultureInfo.CreateSpecificCulture("en-US")); 
        }

        private void obtener_id_factura()
        {
            //Obtengo el id_factura
            query = String.Format("SELECT TOP 1 id_factura from GESDA.Factura ORDER BY id_factura DESC");
            dp = new SqlDataAdapter(query, Utilidades.conexion);
            dp.Fill(ds);
            idFactura = ds.Tables[0].Rows[0]["id_factura"].ToString();
        }

        private void limpiar_pantalla()
        {
            textBox_mail.Text = "";
            comboBox_empresa.SelectedItem = null;
            textBox_num_factura.Text = "";
            textBox_monto.Text = "";
            textBox_cantidad.Text = "";
            textBox_total.Text = "0";
            //Quito los warning
            this.errorValidar.Clear();
            //Elimina las filas del DataGridView
            dataGridView1.Rows.Clear();
            //Seteo las fechas
            dateTimePicker_fecha_alta.Value = Utilidades.fecha;
            dateTimePicker_frcha_venc.Value = Utilidades.fecha;
        }
        //controla que el monto sea numerico y que solo permita una coma
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
