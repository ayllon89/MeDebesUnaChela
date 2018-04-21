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
    public partial class Seleccion_Rol : PantallasGenericas.Pantalla_Inicial
    {
        private String sucursal;

        public Seleccion_Rol(String usuario,String sucursalSeleccionada)
        {
            try
            {
                InitializeComponent();

                this.sucursal = sucursalSeleccionada;
                base.ds = new DataSet();
                //obtengo los roles del usuario que ingreso al sistemas
                base.query = String.Format("select r.rol_nombre ROL from GESDA.rol r Join GESDA.Rol_Usuario ru on (R.id_rol=ru.id_rol) join GESDA.Usuario u on (ru.id_usuario=u.id_usuario) where u.usuario_username='{0}'", usuario);
                //lleno la tabla con los roles asociados al usuario
                base.dp = new SqlDataAdapter(query, Utilidades.conexion);
                dp.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("el usuario no tiene roles");
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
            //tomo el rol que eligio el usuario
            String rol = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);

            //valido si el rol tiene funciones asociadas
            base.query = String.Format("select f.id_funcion from gesda.funcion f join gesda.rol_funcion rf on (f.id_funcion=rf.id_funcion) join gesda.rol r on (r.id_rol=rf.id_rol) where r.rol_nombre='{0}'", rol);
            base.comando = new SqlCommand(query, Utilidades.conexion);
            base.datos = comando.ExecuteReader();

            if (datos.Read())
            {
                datos.Close();
                OtrasPantallas.Pantalla_Funciones ventanaFuncion = new OtrasPantallas.Pantalla_Funciones(rol,sucursal);
                ventanaFuncion.Show();
            }
            else
            {
                MessageBox.Show("El rol seleccionado no contiene funciones asociadas");
                datos.Close();
            }
        }
    }
}
