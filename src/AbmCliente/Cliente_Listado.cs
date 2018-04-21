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

namespace PagoAgilFrba.AbmCliente
{
    public partial class Cliente_Listado : PantallasGenericas.Pantalla_Listado
    {
        public Cliente_Listado()
        {
            InitializeComponent();

            try
            {
                //obtengo todos los clientes
                base.query = String.Format("select c.cliente_nombre,c.cliente_apellido,c.cliente_dni from gesda.Cliente c");
                //lleno la tabla con los clientes
                base.dp = new SqlDataAdapter(query, Utilidades.conexion);
                base.dp.Fill(ds);
                base.listado.DataSource = ds.Tables[0];

            }
            catch (Exception error)
            {
                MessageBox.Show("se produjo un error: " + error.ToString());
            }
        }

        public bool validar()
        {
            bool noHayError = true;

            if (texto_listado_dni.Text != String.Empty)
            {
                try
                {
                    //como el campo no es vacio, verifico si el dato que ingresaron es del tipo numerico
                    int i = Convert.ToInt32(texto_listado_dni.Text);
                }
                catch
                {
                    errorValidar.SetError(texto_listado_dni, "Por favor introduzca un campo numerico");
                    noHayError = false;
                }
            }

            return noHayError;
        }


        public void filtro1()
        {
            try
            {
                base.query = String.Format("select c.cliente_nombre,c.cliente_apellido,c.cliente_dni from gesda.Cliente c where c.cliente_nombre like " + "'%" + "{0}" + "%'", texto_name.Text);
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
                base.query = String.Format("select c.cliente_nombre,c.cliente_apellido,c.cliente_dni from gesda.Cliente c where c.cliente_apellido like " + "'%" + "{0}" + "%'", texto_surname.Text);
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
                base.query = String.Format("select c.cliente_nombre,c.cliente_apellido,c.cliente_dni from gesda.Cliente c where c.cliente_dni='{0}'", texto_listado_dni.Text);
                //lleno la tabla con los roles asociados a la busqueda
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
            //funciona
            if (listado.Rows.Count == 0)
            {
                MessageBox.Show("error: debe seleccionar un cliente a dar de baja");
            }
            else
            {
                String itemSeleccionado = Convert.ToString(listado.Rows[listado.CurrentRow.Index].Cells[2].Value);
                Cliente_Modificacion ventanaModificacion = new Cliente_Modificacion(itemSeleccionado);
                ventanaModificacion.Show();
            }
        }

        private void boton_buscar_Click(object sender, EventArgs e)
        {
            this.errorValidar.Clear();

            if (this.validar())
            {
                try
                {
                    //limpio la tabla de resultados
                    base.dt = (DataTable)listado.DataSource;
                    base.dt.Clear();

                    //busco por el filtro 1
                    if (texto_name.Text.Length != 0)
                    {
                        this.filtro1();
                    }

                    //busco por el filtro 2
                    if (texto_surname.Text.Length != 0)
                    {
                        this.filtro2();
                    }
                    //busco por filtro 3
                    if (texto_listado_dni.Text.Length != 0)
                    {
                        this.filtro3();
                    }


                    //si es que no ingresa datos el usuario devuelvo todo
                    if (texto_name.Text.Length == 0 && texto_surname.Text.Length == 0 && texto_listado_dni.Text.Length == 0)
                    {
                        base.query = String.Format("select c.cliente_nombre,c.cliente_apellido,c.cliente_dni from gesda.Cliente c");
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
        }

        private void boton_limpiar_Click(object sender, EventArgs e)
        {
            texto_name.Text = "";
            texto_surname.Text = "";
            texto_listado_dni.Text = "";
            //limpio la tabla de resultados
            base.dt = (DataTable)listado.DataSource;
            base.dt.Clear();
        }
    }
}
