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
    public partial class Listado_Modificacion_Sucursal : PantallasGenericas.Pantalla_Listado
    {
        public Listado_Modificacion_Sucursal()
        {
            InitializeComponent();
            try
            {

                base.query = String.Format("SELECT sucursal_nombre, sucursal_direccion, sucursal_codigo_postal FROM GESDA.Sucursal");
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
            textBox_nombre.Text = "";
            textBox_direccion.Text = "";
            textBox_codigo_postal.Text = "";
            dt = (DataTable)listado.DataSource;
            dt.Clear();
        }

        private void boton_buscar_Click(object sender, EventArgs e)
        {
            //limpio la tabla de resultados
            base.dt = (DataTable)listado.DataSource;
            base.dt.Clear();

            //si es que no ingresa datos el usuario devuelvo todo
            if (string.IsNullOrEmpty(textBox_nombre.Text) && string.IsNullOrEmpty(textBox_direccion.Text) && string.IsNullOrEmpty(textBox_codigo_postal.Text))
            {
                base.query = String.Format("SELECT sucursal_nombre, sucursal_direccion, sucursal_codigo_postal FROM GESDA.Sucursal");
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
                base.query = String.Format("SELECT DISTINCT sucursal_nombre, sucursal_direccion, sucursal_codigo_postal FROM GESDA.Sucursal WHERE sucursal_nombre LIKE " + "'" + "{0}" + "'" + " OR " + "sucursal_direccion LIKE " + "'" + "{1}" + "'" + " OR " + "sucursal_codigo_postal LIKE " + "'" + "{2}" + "'", textBox_nombre.Text, textBox_direccion.Text, textBox_codigo_postal.Text);
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
                MessageBox.Show("error: debe seleccionar una sucursal a modificar");
            }
            else
            {
                String itemSeleccionado1 = Convert.ToString(listado.Rows[listado.CurrentRow.Index].Cells[0].Value);
                String itemSeleccionado2 = Convert.ToString(listado.Rows[listado.CurrentRow.Index].Cells[1].Value);
                String itemSeleccionado3 = Convert.ToString(listado.Rows[listado.CurrentRow.Index].Cells[2].Value);
                Modificacion_Sucursal ventanaModificacion = new Modificacion_Sucursal(itemSeleccionado1, itemSeleccionado2, itemSeleccionado3);
                ventanaModificacion.Show();               
            }
        }
    }
}
