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

namespace PagoAgilFrba.Devolucion
{
    public partial class Devolucion_Listado : PantallasGenericas.Pantalla_Listado
    {
        private String factura_numero;
        private String empresa_cuit;

        public Devolucion_Listado()
        {
            InitializeComponent();
            try
            {
                //obtengo todas las facturas
                base.query = String.Format("select distinct f.factura_numero,c.cliente_dni,e.empresa_nombre,e.empresa_cuit,f.factura_total from gesda.Factura f join gesda.cliente c ON (c.id_cliente=f.id_cliente) join gesda.Empresa e ON (e.id_empresa=f.id_empresa) join gesda.Pago_Detalle pd ON (f.id_factura=pd.id_factura) where f.id_factura not in (select id_factura from gesda.Devolucion d where d.id_factura is not null) and f.id_factura not in (select id_factura from gesda.Rendicion_Detalle)");
                //lleno la tabla con las facturas
                base.dp = new SqlDataAdapter(query, Utilidades.conexion);
                base.dp.Fill(ds);
                base.listado.DataSource = ds.Tables[0];

            }
            catch (Exception error)
            {
                MessageBox.Show("se produjo un error: " + error.ToString());
            }
        }

        private void boton_buscar_Click(object sender, EventArgs e)
        {
            //si el usuario no puso nada en el textbox significa que quiere ver todas las facturas
            if (texto_factura.Text == String.Empty)
            {
                //limpio la tabla de resultados
                base.dt = (DataTable)listado.DataSource;
                base.dt.Clear();

                try
                {
                    //obtengo todas las facturas
                    base.query = String.Format("select distinct f.factura_numero,c.cliente_dni,e.empresa_nombre,e.empresa_cuit,f.factura_total from gesda.Factura f join gesda.cliente c ON (c.id_cliente=f.id_cliente) join gesda.Empresa e ON (e.id_empresa=f.id_empresa) join gesda.Pago_Detalle pd ON (f.id_factura=pd.id_factura) where f.id_factura not in (select id_factura from gesda.Devolucion d where d.id_factura is not null) and f.id_factura not in (select id_factura from gesda.Rendicion_Detalle)");
                    //lleno la tabla con las facturas
                    base.dp = new SqlDataAdapter(query, Utilidades.conexion);
                    base.ds = new DataSet();
                    base.dp.Fill(ds);
                    base.listado.DataSource = ds.Tables[0];

                }
                catch (Exception error)
                {
                    MessageBox.Show("se produjo un error: " + error.ToString());
                }
            }
            else
            { 
                //borro los errores anteriores si es que tenia
                this.errorValidar.Clear();
                //si el usuario puso una factura a buscar,valido que haya ingresado un numero
                if (this.validar())
                {
                    try
                    {
                        //limpio la tabla de resultados
                        base.dt = (DataTable)listado.DataSource;
                        base.dt.Clear();
                        try
                        {
                            base.query = String.Format("select distinct f.factura_numero,c.cliente_dni,e.empresa_nombre,e.empresa_cuit,f.factura_total from gesda.Factura f join gesda.cliente c ON (c.id_cliente=f.id_cliente) join gesda.Empresa e ON (e.id_empresa=f.id_empresa) join gesda.Pago_Detalle pd ON (f.id_factura=pd.id_factura) where f.id_factura not in (select id_factura from gesda.Devolucion d where d.id_factura is not null) and f.id_factura not in (select id_factura from gesda.Rendicion_Detalle) and f.factura_numero like " + "'%" + "{0}" + "%'", texto_factura.Text);
                            base.dp = new SqlDataAdapter(query, Utilidades.conexion);
                            base.ds = new DataSet();
                            base.dp.Fill(ds);
                            base.listado.DataSource = ds.Tables[0];
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show("se produjo un error: " + error.ToString());
                        }                      
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("se produjo un error: " + error.ToString());
                    }
                }
            }
        }

        private void boton_seleccion_Click(object sender, EventArgs e)
        {
            //valido que el usuario selecciono un resultado
            if (listado.Rows.Count == 0)
            {
                MessageBox.Show("error: debe seleccionar una factura a devolver");
            }
            else
            {
                this.factura_numero = Convert.ToString(listado.Rows[listado.CurrentRow.Index].Cells[0].Value);
                this.empresa_cuit = Convert.ToString(listado.Rows[listado.CurrentRow.Index].Cells[3].Value);
                Devolucion ventanaDevolucion = new Devolucion(factura_numero,empresa_cuit);
                ventanaDevolucion.Show();

            }
        }


        public bool validar()
        {
            bool noHayError = true;

            if (texto_factura.Text != String.Empty)
            {
                try
                {
                    //verifico si el dato que ingresaron es del tipo numerico
                    int i = Convert.ToInt32(texto_factura.Text);
                }
                catch
                {
                    errorValidar.SetError(texto_factura, "Por favor introdusca un numero");
                    noHayError = false;
                }
            }
            return noHayError;
        }

        private void boton_limpiar_Click(object sender, EventArgs e)
        {
            texto_factura.Text = "";
            //limpio la tabla de resultados
            base.dt = (DataTable)listado.DataSource;
            base.dt.Clear();

            //obtengo todas las facturas
            base.query = String.Format("select distinct f.factura_numero,c.cliente_dni,e.empresa_nombre,e.empresa_cuit,f.factura_total from gesda.Factura f join gesda.cliente c ON (c.id_cliente=f.id_cliente) join gesda.Empresa e ON (e.id_empresa=f.id_empresa) join gesda.Pago_Detalle pd ON (f.id_factura=pd.id_factura) where f.id_factura not in (select id_factura from gesda.Devolucion d where d.id_factura is not null) and f.id_factura not in (select id_factura from gesda.Rendicion_Detalle)");
            //lleno la tabla con las facturas
            base.dp = new SqlDataAdapter(query, Utilidades.conexion);
            base.ds = new DataSet();
            base.dp.Fill(ds);
            base.listado.DataSource = ds.Tables[0];
        }
    }
}
