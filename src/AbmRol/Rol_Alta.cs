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
using System.Configuration;

namespace PagoAgilFrba.AbmRol
{
    public partial class Rol_Alta : PantallasGenericas.Pantalla_Alta
    {
        DataColumn columna;
        DataRow fila;

        public Rol_Alta()
        {
            try
            {
                InitializeComponent();
                //obtengo todas las funciones
                base.query = String.Format("select funcion_nombre from gesda.funcion");
                //lleno la tabla con los roles
                base.dp = new SqlDataAdapter(query, Utilidades.conexion);
                base.dp.Fill(ds);
                listado_funciones.DataSource = ds.Tables[0];

                //creo la columna para el listado de las funciones que va a tener el rol
                DataGridViewTextBoxColumn columnaFunciones = new DataGridViewTextBoxColumn();
                rol_funciones.Columns.Add(columnaFunciones);

                //defino la tabla que voy a mandar como parametro al procedure
                base.dt = new DataTable();
                columna = new DataColumn();
                columna.DataType = System.Type.GetType("System.String");
                columna.ColumnName = "funcion";
                columna.ReadOnly = true;
                dt.Columns.Add(columna);

            }
            catch (Exception error)
            {
                MessageBox.Show("se produjo un error: " + error.ToString());
            }
        }

        private void boton_guardar_Click(object sender, EventArgs e)
        {
            //dejo en blanco los errores de validacion anteriores, si es que tenia
            base.errorValidar.Clear();
            dt.Clear();
            //Verifico que no quede campos sin completar
            if (this.validar())
            {
                try
                {
                    //agrego las funciones del listado rol_funciones al dataTable
                    foreach (DataGridViewRow rowGrid in rol_funciones.Rows)
                    {
                        fila = dt.NewRow();
                        fila["funcion"] = Convert.ToString(rowGrid.Cells[0].Value);
                        dt.Rows.Add(fila);
                    }

                    //llamo al procedure que crea el rol
                    base.comando = new SqlCommand("GESDA.crear_rol", Utilidades.conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    //declaro y seteo los parametros de entrada
                    comando.Parameters.Add(new SqlParameter("@nombre_rol", SqlDbType.VarChar, 88));
                    comando.Parameters.Add(new SqlParameter("@funciones", SqlDbType.Structured, 88));
                    comando.Parameters["@nombre_rol"].Value = texto_nombre.Text;
                    comando.Parameters["@funciones"].Value = dt;
                    SqlParameter resultado = new SqlParameter("@resultado", SqlDbType.VarChar, 88);
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
        }

        private void boton_limpiar_Click(object sender, EventArgs e)
        {
            texto_nombre.Text = "";
            rol_funciones.Rows.Clear();
        }

        public bool validar()
        {
            bool noHayError = true;
            //valido que el nombre no este vacio
            if (texto_nombre.Text == String.Empty)
            {
                //al error provider le paso el texbox o boton que no cumple la validacion
                errorValidar.SetError(texto_nombre, "Por favor complete este campo");
                noHayError = false;
            }

            if (rol_funciones.Rows.Count == 0)
            {
                errorValidar.SetError(rol_funciones, "Por favor asocie una funcion");
                noHayError = false;
            }

            return noHayError;
        }

        private void boton_agregar_Click(object sender, EventArgs e)
        {
            //valido que el usuario selecciono un resultado
            if (listado_funciones.Rows.Count == 0)
            {
                MessageBox.Show("error: debe seleccionar una funcionalidad a dar de alta");
            }
            else
            {
                bool estaLaFuncion = false;
                String funcion = Convert.ToString(listado_funciones.Rows[listado_funciones.CurrentRow.Index].Cells[0].Value);
                //Verifico si la funcion que quiere agregar ya se encuentra en el listado de las funciones agregadas
                foreach (DataGridViewRow row in rol_funciones.Rows)
                {
                    if (Convert.ToString(row.Cells[0].Value) == funcion)
                    {
                        estaLaFuncion = true;
                    }
                }
                if (!estaLaFuncion)
                {
                    rol_funciones.Rows.Add(funcion);
                }
            }
        }

        private void boton_sacar_Click(object sender, EventArgs e)
        {
            //valido que el usuario selecciono un resultado
            if (rol_funciones.Rows.Count == 0)
            {
                MessageBox.Show("error: debe seleccionar una funcionalidad a sacar");
            }
            else
            {
                rol_funciones.Rows.RemoveAt(rol_funciones.CurrentRow.Index);
            }
        }
    }
}