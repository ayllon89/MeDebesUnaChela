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

namespace PagoAgilFrba.OtrasPantallas
{
    public partial class Seleccion_Sucursal : PantallasGenericas.Pantalla_Inicial
    {
        private String unUsuario;

        public Seleccion_Sucursal()
        {
            InitializeComponent();
        }

        public Seleccion_Sucursal(String usuario)
        {
            try
            {
                InitializeComponent();

                this.unUsuario = usuario;

                base.ds = new DataSet();
                //obtengo las sucursales del usuario que ingreso al sistema
                base.query = String.Format("select s.sucursal_nombre Nombre,s.sucursal_direccion Direccion from gesda.Sucursal s join gesda.Usuario_Sucursal us on (s.id_sucursal=us.id_sucursal) join gesda.Usuario u on (u.id_usuario=us.id_usuario) where u.usuario_username='{0}'", usuario);
                //lleno la tabla con las sucursales asociados al usuario
                base.dp = new SqlDataAdapter(query, Utilidades.conexion);
                dp.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("el usuario no tiene sucursales");
                    boton_seleccionar.Enabled = !boton_seleccionar.Enabled;
                }


            }
            catch (Exception error)
            {
                MessageBox.Show("se produjo un error: " + error.ToString());
            }
        }

        private void boton_seleccionar_Click(object sender, EventArgs e)
        {
            //tomo la sucursal que eligio el usuario
            String sucursal = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);

            OtrasPantallas.Seleccion_Rol ventanaRol = new OtrasPantallas.Seleccion_Rol(unUsuario, sucursal);
            ventanaRol.Show();
        }

    }
}
