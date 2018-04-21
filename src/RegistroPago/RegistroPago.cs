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

namespace PagoAgilFrba.RegistroPago
{
    public partial class RegistroPago : PantallasGenericas.Pantalla_Inicial
    {
        private String sucursal;
        private int total=0;
        public RegistroPago(String sucursalSeleccionada)
        {
            this.sucursal = sucursalSeleccionada;

            InitializeComponent();

            //lleno el combobox de forma de pago
            base.comando = new SqlCommand("Select forma_pago_descripcion FROM GESDA.Forma_Pago", Utilidades.conexion);
            base.datos = base.comando.ExecuteReader();
            while (datos.Read())
            {
                cbFormaPago.Items.Add(datos["forma_pago_descripcion"].ToString());
            }
            datos.Close();

            //lleno el combobox de empresas
            base.comando = new SqlCommand("Select empresa_nombre FROM GESDA.Empresa", Utilidades.conexion);
            base.datos = base.comando.ExecuteReader();
            while (datos.Read())
            {
                cbEmpresa.Items.Add(datos["empresa_nombre"].ToString());
            }
            datos.Close();

            //seteo la fecha
            dtpFechaCobro.Value = Utilidades.fecha;
        }

        private void bAgregarFactura_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbNumeroFactura.Text) && solo_numeros(tbNumeroFactura.Text) && cbEmpresa.SelectedItem != null)
            {
                try
                {
                    if (!factura_ya_ingresada())
                    {
                        //verifico la factura
                        base.comando = new SqlCommand("GESDA.verificarFacturaAPagar", Utilidades.conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@factura_numero", SqlDbType.Int, 88));
                        comando.Parameters["@factura_numero"].Value = tbNumeroFactura.Text;
                        comando.Parameters.Add(new SqlParameter("@empresa_nombre", SqlDbType.VarChar, 88));
                        comando.Parameters["@empresa_nombre"].Value = cbEmpresa.SelectedItem;
                        comando.Parameters.Add(new SqlParameter("@fecha_actual", SqlDbType.DateTime, 88));
                        comando.Parameters["@fecha_actual"].Value = dtpFechaCobro.Value;
                        SqlParameter resultado = new SqlParameter("@resultado", SqlDbType.VarChar, 88);
                        resultado.Direction = ParameterDirection.Output;
                        comando.Parameters.Add(resultado);
                        comando.ExecuteNonQuery();
                        String resultadoString = comando.Parameters["@resultado"].Value.ToString();

                        if (resultadoString == "La factura se puede pagar")
                        {
                            //agrego la factura al datagridview
                            base.query = String.Format
                            ("SELECT factura_numero AS 'Numero de factura', empresa_nombre AS 'Empresa', cliente_nombre+' '+cliente_apellido AS 'Cliente',factura_fecha_vencimiento 'Fecha de vencimiento',factura_total 'Importe' FROM GESDA.Factura AS F JOIN GESDA.Empresa AS E ON (F.id_empresa=E.id_empresa) JOIN GESDA.Cliente AS C ON (F.id_cliente=C.id_cliente) WHERE factura_numero = '{0}' AND empresa_nombre = '{1}'", tbNumeroFactura.Text, cbEmpresa.SelectedItem);
                            base.dp = new SqlDataAdapter(query, Utilidades.conexion);
                            base.dp.Fill(ds);
                            dgvFacAPagar.DataSource = ds.Tables[0];

                            //esto para el total
                            total += Convert.ToInt32(dgvFacAPagar.Rows[dgvFacAPagar.RowCount - 1].Cells[4].Value);
                            tbTotal.Text = total.ToString();
                        }
                        else
                        {
                            MessageBox.Show(resultadoString);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Factura ya ingresada");
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("se produjo un error: " + error.ToString());
                }
            }
            else 
            {
                MessageBox.Show("Debe ingresar el número de la factura y seleccionar la empresa de la misma");
            }
         }

        private void bBorrarFact_Click(object sender, EventArgs e)
        {
            if (dgvFacAPagar.RowCount > 0)
            {
                //esto para el total nuevo sin la factura a borrar
                total -= Convert.ToInt32(dgvFacAPagar.Rows[dgvFacAPagar.CurrentRow.Index].Cells[4].Value);
                tbTotal.Text = total.ToString();

                //aca borra la factura
                dgvFacAPagar.Rows.RemoveAt(dgvFacAPagar.CurrentRow.Index);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bRegistrarPago_Click(object sender, EventArgs e)
        {
            if (registro_pago_verificar_campos())
            {

                try
                {
                    base.comando = new SqlCommand("GESDA.CrearPago", Utilidades.conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@sucursal_nombre", SqlDbType.VarChar, 88));
                    comando.Parameters["@sucursal_nombre"].Value = sucursal;
                    comando.Parameters.Add(new SqlParameter("@forma_pago_descripcion", SqlDbType.VarChar, 88));
                    comando.Parameters["@forma_pago_descripcion"].Value = cbFormaPago.Text;
                    comando.Parameters.Add(new SqlParameter("@cliente_dni", SqlDbType.VarChar, 88));
                    comando.Parameters["@cliente_dni"].Value = tbClienteDNI.Text;
                    comando.Parameters.Add(new SqlParameter("@pago_fecha", SqlDbType.DateTime, 88));
                    comando.Parameters["@pago_fecha"].Value = dtpFechaCobro.Value;
                    comando.Parameters.Add(new SqlParameter("@total", SqlDbType.Float, 88));
                    comando.Parameters["@total"].Value = tbTotal.Text;
                    SqlParameter resultado = new SqlParameter("@resultado", SqlDbType.VarChar, 88);
                    resultado.Direction = ParameterDirection.Output;
                    comando.Parameters.Add(resultado);
                    comando.ExecuteNonQuery();
                    String resultadoString = comando.Parameters["@resultado"].Value.ToString();

                    int idPago = 0;
                    base.query = ("SELECT TOP 1 id_pago FROM GESDA.Pago order by id_pago DESC");
                    base.comando = new SqlCommand(query, Utilidades.conexion);
                    base.datos = comando.ExecuteReader();
                    if (datos.Read())
                    {
                        idPago = Convert.ToInt32(datos["id_Pago"].ToString());
                    }
                    datos.Close();


                    //voy insertando en pago detalle y si era una factura devuelta modifica la tabla devolucion
                    string nombreempresa;
                    int facturaNumero;
                    for (int i = 0; i < dgvFacAPagar.RowCount; ++i)
                    {
                        facturaNumero = Convert.ToInt32(dgvFacAPagar.Rows[i].Cells[0].Value);
                        nombreempresa = Convert.ToString(dgvFacAPagar.Rows[i].Cells[1].Value);

                        base.comando = new SqlCommand("GESDA.InsertarItemPago", Utilidades.conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@id_pago", SqlDbType.Int, 88));
                        comando.Parameters["@id_pago"].Value = idPago;
                        comando.Parameters.Add(new SqlParameter("@factura_numero", SqlDbType.Int, 88));
                        comando.Parameters["@factura_numero"].Value = facturaNumero;
                        comando.Parameters.Add(new SqlParameter("@empresa_nombre", SqlDbType.VarChar, 88));
                        comando.Parameters["@empresa_nombre"].Value = nombreempresa;
                        SqlParameter resultado2 = new SqlParameter("@resultado", SqlDbType.VarChar, 88);
                        resultado2.Direction = ParameterDirection.Output;
                        comando.Parameters.Add(resultado2);
                        comando.ExecuteNonQuery();
                        String resultadoString2 = comando.Parameters["@resultado"].Value.ToString();
                        if (!String.IsNullOrEmpty(resultadoString2))
                        {
                            resultadoString = comando.Parameters["@resultado"].Value.ToString();
                        }
                    }

                    MessageBox.Show(resultadoString);
                    limpiar_todo();
                }
                catch (Exception error)
                {
                    MessageBox.Show("se produjo un error: " + error.ToString());
                }
            }
        }

        private bool registro_pago_verificar_campos() { 
            bool resultado = true;

            string falta = "Faltan los siguientes campos o acciones:";

            if(string.IsNullOrEmpty(tbClienteDNI.Text))
            {
                falta = falta + "\n DNI";
                resultado = false;
            }
            if(string.IsNullOrEmpty(tbNombreCli.Text)|| string.IsNullOrEmpty(tbApellidoCli.Text) || string.IsNullOrEmpty(tbSucursal.Text))
            {
                falta = falta + "\n Verificar el cliente";
                resultado = false;
            }
            if (cbFormaPago.SelectedItem == null)
            {
                falta = falta + "\n Forma de pago";
                resultado = false;
            }
            if (dgvFacAPagar.Rows.Count == 0 || string.IsNullOrEmpty(tbTotal.Text))
            {
                falta = falta + "\n Agregar factura/s";
                resultado = false;
            }
            if (resultado == false)
            {

                MessageBox.Show(falta);
            }
            return resultado;
        }

        private void bLimpiar_Click(object sender, EventArgs e)
        {
            limpiar_todo();
        }
        private void limpiar_todo()
        {
            tbClienteDNI.Text = "";
            tbNombreCli.Text = "";
            tbApellidoCli.Text = "";
            tbSucursal.Text = "";
            tbNumeroFactura.Text = "";
            tbTotal.Text = "";
            tbClienteDNI.Enabled = true;
            tbNumeroFactura.Enabled = false;
            total = 0;
            if (dgvFacAPagar.RowCount > 0)
            {
                base.dt = (DataTable)dgvFacAPagar.DataSource;
                base.dt.Clear();
            }
            cbFormaPago.SelectedItem = null;
            cbEmpresa.SelectedItem = null;
        }

        public bool solo_numeros(string texto)
        {
            int numero;
            bool canConvert = int.TryParse(texto, out numero);
            if (canConvert == true)
                return true;
            else
                return false;
        }

        public bool factura_ya_ingresada()
        {
                for (int i = 0; i < dgvFacAPagar.RowCount; ++i)
                {
                    if (Convert.ToString(tbNumeroFactura.Text) == Convert.ToString(dgvFacAPagar.Rows[i].Cells[0].Value) && Convert.ToString(cbEmpresa.SelectedItem) == Convert.ToString(dgvFacAPagar.Rows[i].Cells[1].Value))
                    {
                        return true;
                    }

                }
                return false;
        }


        private void bVerificarCliente_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbClienteDNI.Text) && solo_numeros(tbClienteDNI.Text))
            {
                try
                {
                    base.comando = new SqlCommand("GESDA.verificarCliente", Utilidades.conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@cliente_dni", SqlDbType.VarChar, 88));
                    comando.Parameters["@cliente_dni"].Value = tbClienteDNI.Text;
                    SqlParameter resultado = new SqlParameter("@resultado", SqlDbType.VarChar, 88);
                    resultado.Direction = ParameterDirection.Output;
                    comando.Parameters.Add(resultado);
                    comando.ExecuteNonQuery();
                    String resultadoString = comando.Parameters["@resultado"].Value.ToString();

                    MessageBox.Show(resultadoString);
                    if (resultadoString == "El Cliente está habilitado")
                    {
                        
                        int dni = int.Parse(tbClienteDNI.Text);

                        //pongo el nombre y apellido del cliente
                        base.query = ("SELECT cliente_nombre, cliente_apellido FROM gesda.cliente WHERE cliente_dni=" + dni);
                        base.comando = new SqlCommand(query, Utilidades.conexion);
                        base.datos = comando.ExecuteReader();
                        if (datos.Read())
                        {
                            tbNombreCli.Text = datos["cliente_nombre"].ToString();
                            tbApellidoCli.Text = datos["cliente_apellido"].ToString();
                        }
                        datos.Close();

                        tbSucursal.Text = sucursal;

                        tbClienteDNI.Enabled = false; //bloquea la escritura del cliente dni
                        tbNumeroFactura.Enabled = true; //habilito escritura del numero de factura

                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("se produjo un error: " + error.ToString());
                }
            }
            else 
            {
                MessageBox.Show("Debe rellenar el campo del DNI con el número de documento");
            }
        }
    }

}