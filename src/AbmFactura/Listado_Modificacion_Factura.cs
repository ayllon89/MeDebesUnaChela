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
    public partial class Listado_Modificacion_Factura : PantallasGenericas.Pantalla_Listado
    {
        public Listado_Modificacion_Factura()
        {
            InitializeComponent();
            try
            {

                base.query = String.Format("SELECT id_factura, cliente_mail, empresa_cuit, factura_numero, factura_total FROM GESDA.Factura f JOIN GESDA.Cliente c ON (f.id_cliente =c.id_cliente) JOIN GESDA.Empresa e ON (f.id_empresa=e.id_empresa)");
                //lleno la tabla con las sucursales
                base.dp = new SqlDataAdapter(query, Utilidades.conexion);
                base.dp.Fill(ds);
                base.listado.DataSource = ds.Tables[0];

            }
            catch (Exception error)
            {
                MessageBox.Show("se produjo un error: " + error.ToString());
            }
        }

        private void boton_limpiar_Click(object sender, EventArgs e)
        {
            textBox_mail_cliente.Text = "";
            textBox_cuit_empresa.Text = "";
            textBox_num_factura.Text = "";
            dt = (DataTable)listado.DataSource;
            dt.Clear();
        }

        private void boton_buscar_Click(object sender, EventArgs e)
        {
            base.dt = (DataTable)listado.DataSource;
            base.dt.Clear();

            if (string.IsNullOrEmpty(textBox_mail_cliente.Text) && string.IsNullOrEmpty(textBox_cuit_empresa.Text) && string.IsNullOrEmpty(textBox_num_factura.Text))
            {
                base.query = String.Format("SELECT id_factura, cliente_mail, empresa_cuit, factura_numero, factura_total FROM GESDA.Factura f JOIN GESDA.Cliente c ON (f.id_cliente =c.id_cliente) JOIN GESDA.Empresa e ON (f.id_empresa=e.id_empresa)");
                base.dp = new SqlDataAdapter(query, Utilidades.conexion);
                base.dp.Fill(ds);
                base.listado.DataSource = ds.Tables[0];
            }
            else
            {
                this.filtro();
            }
        }
        public void filtro()
        {
            try
            {
                base.query = String.Format("SELECT DISTINCT id_factura, cliente_mail, empresa_cuit, factura_numero, factura_total FROM GESDA.Factura f JOIN GESDA.Cliente c ON (f.id_cliente =c.id_cliente) JOIN GESDA.Empresa e ON (f.id_empresa=e.id_empresa) WHERE cliente_mail LIKE " + "'" + "{0}" + "'" + " OR " + "empresa_cuit LIKE " + "'" + "{1}" + "'" + " OR " + "factura_numero LIKE " + "'" + "{2}" + "'", textBox_mail_cliente.Text, textBox_cuit_empresa.Text, textBox_num_factura.Text);
                base.dp = new SqlDataAdapter(query, Utilidades.conexion);
                base.dp.Fill(ds);
                base.listado.DataSource = ds.Tables[0];
            }
            catch (Exception error)
            {
                MessageBox.Show("se produjo un error: " + error.ToString());
            }
        }

        private void boton_seleccion_Click(object sender, EventArgs e)
        {
            if (listado.Rows.Count == 0)
            {
                MessageBox.Show("error: debe seleccionar una factura a modificar");
            }
            else
            {
                String itemSeleccionado1 = Convert.ToString(listado.Rows[listado.CurrentRow.Index].Cells[0].Value);
                String itemSeleccionado2 = Convert.ToString(listado.Rows[listado.CurrentRow.Index].Cells[1].Value);
                String itemSeleccionado3 = Convert.ToString(listado.Rows[listado.CurrentRow.Index].Cells[2].Value);
                String itemSeleccionado4 = Convert.ToString(listado.Rows[listado.CurrentRow.Index].Cells[3].Value);
                Decimal itemSeleccionado5 = Convert.ToDecimal(listado.Rows[listado.CurrentRow.Index].Cells[4].Value, CultureInfo.CreateSpecificCulture("en-US"));

                //llamo al procedure 
                base.comando = new SqlCommand("GESDA.habilitar_modificacion", Utilidades.conexion);
                comando.CommandType = CommandType.StoredProcedure;

                //declaro y seteo los parametros de entrada
                comando.Parameters.Add(new SqlParameter("@id_factura", SqlDbType.Int, 88));
                comando.Parameters["@id_factura"].Value = Convert.ToInt32(itemSeleccionado1);
                resultado = new SqlParameter("@resultado", SqlDbType.VarChar, 88);
                resultado.Direction = ParameterDirection.Output;
                comando.Parameters.Add(resultado);

                //ejecuto el comando 
                comando.ExecuteNonQuery();
                String resultadoString = comando.Parameters["@resultado"].Value.ToString();

                if (resultadoString == "La factura puede modificarse")
                {
                    Modificacion_Factura ventanaModFact = new Modificacion_Factura(itemSeleccionado1, itemSeleccionado2, itemSeleccionado3, itemSeleccionado4, itemSeleccionado5);
                    ventanaModFact.Show();
                }
                else
                {
                    MessageBox.Show(resultadoString);
                }

            }
        }
    }
}
