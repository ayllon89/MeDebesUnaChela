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

namespace PagoAgilFrba.AbmRol
{
    public partial class Rol_Listado : PantallasGenericas.Pantalla_Listado
    {
        public Rol_Listado()
        {
            try
            {
                InitializeComponent();
                this.listado.Size = new System.Drawing.Size(420, 300);
                this.listado.Location = new System.Drawing.Point(19, 74);

                //obtengo todos los roles
                base.query = String.Format("select r.rol_nombre Rol from GESDA.rol r");
                //lleno la tabla con los roles
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
            //valido que el usuario selecciono un rol
            if (listado.Rows.Count == 0)
            {
                MessageBox.Show("error: debe seleccionar un rol a modificar");
            }
            else
            {
                String itemSeleccionado = Convert.ToString(listado.Rows[listado.CurrentRow.Index].Cells[0].Value);
                Rol_Modificacion ventanaModificacion = new Rol_Modificacion(itemSeleccionado);
                ventanaModificacion.Show();
                this.Close();
            }
        }
    }
}
