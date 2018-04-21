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
    public partial class Rol_Modificacion : PantallasGenericas.Pantalla_Alta
    {
        String rolActual;
        DataColumn columna;
        DataRow fila;

        public Rol_Modificacion()
        {
            InitializeComponent();
        }

        public Rol_Modificacion(String rol)
        {
            try
            {
                InitializeComponent();

                //lleno el textbox con el nombre del rol y ademas lo guardo en una variable
                //para despues verificar si el usuario lo cambio
                texto_nombre.Text = rol;
                rolActual = rol;

                //defino la tabla que voy a mandar como parametro al procedure
                base.dt = new DataTable();
                columna = new DataColumn();
                columna.DataType = System.Type.GetType("System.String");
                columna.ColumnName = "funcion";
                columna.ReadOnly = true;
                dt.Columns.Add(columna);

                //obtengo todas las funciones
                base.query = String.Format("select funcion_nombre from gesda.funcion");
                //lleno la tabla con los roles
                base.dp = new SqlDataAdapter(query, Utilidades.conexion);
                base.dp.Fill(ds);
                listado_funciones.DataSource = ds.Tables[0];

                //creo la columna para el listado de las funciones que va a tener el rol
                DataGridViewTextBoxColumn columnaFunciones = new DataGridViewTextBoxColumn();
                rol_funciones.Columns.Add(columnaFunciones);

                //averiguo las funciones que tiene el rol
                query = String.Format("select f.funcion_nombre from gesda.Funcion f join gesda.Rol_Funcion rf on (f.id_funcion=rf.id_funcion) join gesda.Rol r on (r.id_rol=rf.id_rol) where r.rol_nombre='{0}'", rol);
                dp = new SqlDataAdapter(query, Utilidades.conexion);
                ds = new DataSet();
                dp.Fill(ds);
                //el resultado lo pongo en un datagridview auxiliar para despues poder manejar las celdas
                dg.DataSource = ds.Tables[0];

                foreach (DataGridViewRow row in dg.Rows)
                {
                    //hago un if si es vacio, dado que hay un elemento que es vacio
                    if (Convert.ToString(row.Cells[0].Value) != "")
                    {
                        rol_funciones.Rows.Add(Convert.ToString(row.Cells[0].Value));
                    }
                }

                //averiguo si el rol esta dado de alta o baja
                query = String.Format("select r.rol_estado from gesda.Rol r where r.rol_nombre='{0}'", rol);
                dp = new SqlDataAdapter(query, Utilidades.conexion);
                ds = new DataSet();
                dp.Fill(ds);
                //si el estado es uno, tildo el checkbox mencionando que fue dado de alta
                if (ds.Tables[0].Rows[0]["rol_estado"].ToString() == "1")
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }

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
            //Verifico que no quede campos sin completar
            if (this.validar())
            {
                //verifico si el usuario modifico el nombre del rol
                if (texto_nombre.Text != rolActual)
                {
                    this.modificar_nombre();
                }
                else
                {
                    this.modificar_funciones();
                }
            }

        }

        private void modificar_nombre()
        {
            try
            {
                //llamo al procedure
                base.comando = new SqlCommand("GESDA.modificar_rol_nombre", Utilidades.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //declaro los parametros y seteo los parametros de entrada
                comando.Parameters.Add(new SqlParameter("@nombre_viejo", SqlDbType.VarChar, 88));
                comando.Parameters.Add(new SqlParameter("@nombre_nuevo", SqlDbType.VarChar, 88));
                comando.Parameters["@nombre_viejo"].Value = rolActual;
                comando.Parameters["@nombre_nuevo"].Value = texto_nombre.Text;
                base.resultado = new SqlParameter("@resultado", SqlDbType.VarChar, 88);
                resultado.Direction = ParameterDirection.Output;
                comando.Parameters.Add(resultado);
                //ejecuto el comando 
                comando.ExecuteNonQuery();
                String resultadoString = comando.Parameters["@resultado"].Value.ToString();
                //muestro el resultado por pantalla
                MessageBox.Show(resultadoString);
                //actualizo el nombre
                if (resultadoString == "se modifico el nombre")
                {
                    rolActual = texto_nombre.Text;
                    this.modificar_funciones();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("se produjo un error: " + error.ToString());
            }
        }

        private void modificar_funciones()
        {
            try
            {
                //limpio la tabla si es que anteriormente tenia datos
                dt.Clear();
                //agrego las funciones del listado rol_funciones al dataTable
                foreach (DataGridViewRow rowGrid in rol_funciones.Rows)
                {
                    fila = dt.NewRow();
                    fila["funcion"] = Convert.ToString(rowGrid.Cells[0].Value);
                    dt.Rows.Add(fila);
                }

                //llamo al procedure que crea el rol
                base.comando = new SqlCommand("GESDA.modificar_funciones", Utilidades.conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //declaro y seteo los parametros de entrada
                comando.Parameters.Add(new SqlParameter("@nombre_rol", SqlDbType.VarChar, 88));
                comando.Parameters.Add(new SqlParameter("@funciones", SqlDbType.Structured, 88));
                comando.Parameters["@nombre_rol"].Value = rolActual;
                comando.Parameters["@funciones"].Value = dt;
                SqlParameter resultado = new SqlParameter("@resultado", SqlDbType.VarChar, 88);
                resultado.Direction = ParameterDirection.Output;
                comando.Parameters.Add(resultado);
                //ejecuto el comando 
                comando.ExecuteNonQuery();
                String resultadoString = comando.Parameters["@resultado"].Value.ToString();

                if (resultadoString != "")
                {
                    MessageBox.Show(resultadoString);
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("se produjo un error: " + error.ToString());
            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                //habilito el rol
                try
                {
                    //llamo al procedure
                    base.comando = new SqlCommand("GESDA.habilitar_rol", Utilidades.conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    //declaro los parametros y seteo los parametros de entrada
                    comando.Parameters.Add(new SqlParameter("@nombre_rol", SqlDbType.VarChar, 88));
                    comando.Parameters["@nombre_rol"].Value = rolActual;
                    SqlParameter resultado = new SqlParameter("@resultado", SqlDbType.VarChar, 88);
                    resultado.Direction = ParameterDirection.Output;
                    comando.Parameters.Add(resultado);
                    //ejecuto el comando 
                    comando.ExecuteNonQuery();
                    String resultadoString = comando.Parameters["@resultado"].Value.ToString();
                    //muestro el resultado por pantalla
                    MessageBox.Show(resultadoString);

                }
                catch (Exception error)
                {
                    MessageBox.Show("se produjo un error: " + error.ToString());
                }

            }
            else
            {
                //deshabilito el rol
                try
                {
                    //llamo al procedure
                    base.comando = new SqlCommand("GESDA.deshabilitar_rol", Utilidades.conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    //declaro los parametros y seteo los parametros de entrada
                    comando.Parameters.Add(new SqlParameter("@nombre_rol", SqlDbType.VarChar, 88));
                    comando.Parameters["@nombre_rol"].Value = rolActual;
                    SqlParameter resultado = new SqlParameter("@resultado", SqlDbType.VarChar, 88);
                    resultado.Direction = ParameterDirection.Output;
                    comando.Parameters.Add(resultado);
                    //ejecuto el comando 
                    comando.ExecuteNonQuery();
                    String resultadoString = comando.Parameters["@resultado"].Value.ToString();
                    //muestro el resultado por pantalla
                    MessageBox.Show(resultadoString);

                }
                catch (Exception error)
                {
                    MessageBox.Show("se produjo un error: " + error.ToString());
                }
            }
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

    }
}
