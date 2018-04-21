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
    public partial class Empresa_Listado : PantallasGenericas.Pantalla_Listado
    {
        public Empresa_Listado()
        {
            InitializeComponent();

            try
            {
                //obtengo todos las empresas
                base.query = String.Format("select e.empresa_nombre Nombre,e.empresa_cuit Cuit,e.empresa_direccion Direccion,r.rubro_descripcion Rubro from gesda.Empresa e join gesda.Rubro r on (r.id_rubro=e.id_rubro)");
                //lleno la tabla con los automoviles
                base.dp = new SqlDataAdapter(query, Utilidades.conexion);
                base.dp.Fill(ds);
                base.listado.DataSource = ds.Tables[0];

                //lleno el combo de marcas
                base.comando = new SqlCommand("select r.rubro_descripcion from gesda.Rubro r", Utilidades.conexion);
                base.datos = base.comando.ExecuteReader();
                while (datos.Read())
                {
                    combo_rubro.Items.Add(datos["rubro_descripcion"].ToString());
                }
                datos.Close();

            }
            catch (Exception error)
            {
                MessageBox.Show("se produjo un error: " + error.ToString());
            }
        }

        private void boton_limpiar_Click(object sender, EventArgs e)
        {
            //limpio la tabla de resultados
            base.dt = (DataTable)listado.DataSource;
            base.dt.Clear();
            combo_rubro.SelectedItem = null;
            texto_cuit.Text = "";
            texto_nombre.Text = "";
        }

        private void boton_buscar_Click(object sender, EventArgs e)
        {
            try
            {
                //limpio la tabla de resultados
                base.dt = (DataTable)listado.DataSource;
                base.dt.Clear();

                //busco por el filtro 1
                if (texto_nombre.Text.Length != 0)
                {
                    this.filtro1();
                }

                //busco por el filtro 2
                if (texto_cuit.Text.Length != 0)
                {
                    this.filtro2();
                }
                
                //busco por el filtro 3
                if (combo_rubro.SelectedIndex >= 0)
                {
                    this.filtro3();
                }

                //si es que no ingresa datos el usuario devuelvo todo
                if (texto_nombre.Text.Length == 0 && texto_cuit.Text.Length == 0 && combo_rubro.SelectedIndex < 0)
                {

                    base.query = String.Format("select e.empresa_nombre Nombre,e.empresa_cuit Cuit,e.empresa_direccion Direccion,r.rubro_descripcion Rubro from gesda.Empresa e join gesda.Rubro r on (r.id_rubro=e.id_rubro)");
                    //base.query = String.Format("select am.auto_marca,am.auto_modelo,a.auto_patente,c.chofer_dni from gesda.Automovil a join gesda.Chofer c ON (c.id_chofer=a.id_chofer) join gesda.Automovil_Marca am ON (am.id_auto_marca=a.id_auto_marca)");
                    //lleno la tabla con los roles
                    base.dp = new SqlDataAdapter(query, Utilidades.conexion);
                    base.dp.Fill(ds);
                    base.listado.DataSource = ds.Tables[0];
                }


            }
            catch (Exception error)
            {
                MessageBox.Show("se produjo un error: " + error.ToString());
            }
        }

        public void filtro1()
        {
            try
            {
                base.query = String.Format("select e.empresa_nombre Nombre,e.empresa_cuit Cuit,e.empresa_direccion Direccion,r.rubro_descripcion Rubro from gesda.Empresa e join gesda.Rubro r on (r.id_rubro=e.id_rubro) where e.empresa_nombre like " + "'%" + "{0}" + "%'", texto_nombre.Text);
                base.dp = new SqlDataAdapter(query, Utilidades.conexion);
                base.dp.Fill(ds);
                base.listado.DataSource = ds.Tables[0];
            }
            catch (Exception error)
            {
                MessageBox.Show("se produjo un error: " + error.ToString());
            }
        }

        public void filtro2()
        {
            try
            {
                base.query = String.Format("select e.empresa_nombre Nombre,e.empresa_cuit Cuit,e.empresa_direccion Direccion,r.rubro_descripcion Rubro from gesda.Empresa e join gesda.Rubro r on (r.id_rubro=e.id_rubro) where e.empresa_cuit like " + "'%" + "{0}" + "%'", texto_cuit.Text);
                base.dp = new SqlDataAdapter(query, Utilidades.conexion);
                base.dp.Fill(ds);
                base.listado.DataSource = ds.Tables[0];
            }
            catch (Exception error)
            {
                MessageBox.Show("se produjo un error: " + error.ToString());
            }
        }

        public void filtro3()
        {
            try
            {
                base.query = String.Format("select e.empresa_nombre Nombre,e.empresa_cuit Cuit,e.empresa_direccion Direccion,r.rubro_descripcion Rubro from gesda.Empresa e join gesda.Rubro r on (r.id_rubro=e.id_rubro) where r.rubro_descripcion like " + "'%" + "{0}" + "%'", combo_rubro.SelectedItem.ToString());
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
            //valido que el usuario selecciono un resultado
            if (listado.Rows.Count == 0)
            {
                MessageBox.Show("error: debe seleccionar una empresa a modificar");
            }
            else
            {
                String cuit = Convert.ToString(listado.Rows[listado.CurrentRow.Index].Cells[1].Value);
                Empresa_Modificacion ventanaModificacion = new Empresa_Modificacion(cuit);
                ventanaModificacion.Show();
            }
        }

        private void boton_seleccionar_Click(object sender, EventArgs e)
        {

        }
    }
}
