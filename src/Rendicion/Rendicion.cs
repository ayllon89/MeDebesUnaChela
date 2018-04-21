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


namespace PagoAgilFrba.Rendicion
{
    public partial class Rendicion : PantallasGenericas.Pantalla_Inicial
    {
        public Rendicion()
        {
            InitializeComponent();

            //lleno el combobox con el nombre de las empresas
            base.comando = new SqlCommand("Select empresa_nombre FROM GESDA.Empresa", Utilidades.conexion);
            base.datos = base.comando.ExecuteReader();
            while (datos.Read())
            {
                cbEmpresa.Items.Add(datos["empresa_nombre"].ToString());
            }
            datos.Close();

            //seteo fecha
            dtpFechaRendicion.Value = Utilidades.fecha;
        }

        private string cint(string p)
        {
            throw new NotImplementedException();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void bLimpiar_Click(object sender, EventArgs e)
        {
            limpiar_Todo();
        }

        private void limpiar_Todo()
        {
            cbEmpresa.SelectedItem = null;
            tbComision.Text = "";
            tbCantidadFacturas.Text = "";
            tbImporte.Text = "";
            tbImporteMenosComision.Text = "";
            cbEmpresa.Enabled = true;
            if (dgvFacturasRendidas.RowCount > 0)
            {
                base.dt = (DataTable)dgvFacturasRendidas.DataSource;
                base.dt.Clear();
            }
        }
        //boton de ingresar porcentaje
        private void button1_Click(object sender, EventArgs e)
        {
            if (cbEmpresa.SelectedItem != null && es_porcentaje(tbComision.Text))
            {
                try
                {
                    //agrego importe menos la comision al ya tener el porcentaje
                    int numImporte = Convert.ToInt32(tbImporte.Text);
                    double numComision = Convert.ToInt32(tbComision.Text);
                    int numImporteMenComision = Convert.ToInt32(numImporte * (1 - (numComision / 100)));
                    tbImporteMenosComision.Text = numImporteMenComision.ToString();
                    //bloqueo el porcentaje de comision
                    tbComision.Enabled = false;
                }
                catch (Exception error)
                {
                    MessageBox.Show("se produjo un error: " + error.ToString());
                }
            }
            else {
                MessageBox.Show("Debe agregarse un porcentaje (número entre 0 y 100)");
            }

        }
        public bool es_porcentaje(string texto)
        {
            int numero;
            bool canConvert = int.TryParse(texto, out numero);
            if (canConvert == true)
            {
                if (numero >= 0 && numero <= 100)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        private void bVerificarEmpresa_Click_1(object sender, EventArgs e)
        {
            if (cbEmpresa.SelectedItem != null)
            {
                try
                {
                    //verifico que la empresa este habilitada y pueda rendir
                    base.comando = new SqlCommand("GESDA.verificarEmpresa", Utilidades.conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@empresa_nombre", SqlDbType.VarChar, 88));
                    comando.Parameters["@empresa_nombre"].Value = cbEmpresa.SelectedItem;
                    comando.Parameters.Add(new SqlParameter("@fecha_actual", SqlDbType.DateTime, 88));
                    comando.Parameters["@fecha_actual"].Value = dtpFechaRendicion.Value;
                    SqlParameter resultado = new SqlParameter("@resultado", SqlDbType.VarChar, 88);
                    resultado.Direction = ParameterDirection.Output;
                    comando.Parameters.Add(resultado);
                    comando.ExecuteNonQuery();
                    String resultadoString = comando.Parameters["@resultado"].Value.ToString();

                    MessageBox.Show(resultadoString);
                    //si es correcto aca se llenan varios campos que se muestran en la pantalla
                    if (resultadoString == "Empresa verificada correctamente")
                    {


                        //obtengo todas las facturas a rendir
                        base.query = String.Format
                        ("SELECT distinct c.cliente_nombre +' '+ c.Cliente_apellido AS 'Cliente',f.factura_numero AS 'Numero de factura',f.factura_total AS 'Importe' FROM  GESDA.Cliente AS C JOIN GESDA.Factura AS F ON (c.id_Cliente=f.id_cliente) JOIN GESDA.Pago_detalle AS Pd ON (F.id_factura=Pd.id_factura) JOIN GESDA.Pago AS P ON (Pd.id_pago=P.id_pago) LEFT JOIN GESDA.Devolucion AS D ON (D.id_factura=F.id_factura) JOIN GESDA.Empresa AS E ON (E.id_empresa=F.id_empresa) WHERE year(p.Pago_fecha) = year('{1}') AND month(p.Pago_fecha) = month('{1}') AND d.id_devolucion IS NULL AND e.empresa_nombre= '{0}'", cbEmpresa.SelectedItem,dtpFechaRendicion.Value);
                        base.dp = new SqlDataAdapter(query, Utilidades.conexion);
                        base.dp.Fill(ds);
                        dgvFacturasRendidas.DataSource = ds.Tables[0];

                        //cantidad de facturas
                        tbCantidadFacturas.Text = dgvFacturasRendidas.RowCount.ToString();

                        //calculo el importe sumando todas las facturas
                        int numImporte = 0;
                        for (int i = 0; i < Convert.ToInt32(tbCantidadFacturas.Text); ++i)
                        {
                            numImporte += Convert.ToInt32(dgvFacturasRendidas.Rows[i].Cells[2].Value);
                        }
                        tbImporte.Text = numImporte.ToString();
                        //bloqueo la escritura en el campo de empresa y desbloqueo la del porcentaje de rendicion
                        cbEmpresa.Enabled = false;
                        tbComision.Enabled = true;

                        if (dgvFacturasRendidas.RowCount == 0) 
                        {
                            limpiar_Todo();
                            MessageBox.Show("La empresa no cuenta con facturas cobradas para poder rendir este mes");
                        }
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("se produjo un error: " + error.ToString());
                }
            }
            else 
            {
                MessageBox.Show("Ingresar un nombre de empresa");
            }
        }

        private void bRendir_Click_1(object sender, EventArgs e)
        {
            if (validar_campos_rendicion())
            {
                try
                {
                    //inserto lo que esta en pantalla en la tabla rendicion
                    base.comando = new SqlCommand("GESDA.crearRendicion", Utilidades.conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@empresa_nombre", SqlDbType.VarChar, 88));
                    comando.Parameters["@empresa_nombre"].Value = cbEmpresa.Text;
                    comando.Parameters.Add(new SqlParameter("@rendicion_fecha", SqlDbType.DateTime, 88));
                    comando.Parameters["@rendicion_fecha"].Value = dtpFechaRendicion.Value;
                    comando.Parameters.Add(new SqlParameter("@rendicion_cantidad_facturas", SqlDbType.Int, 88));
                    comando.Parameters["@rendicion_cantidad_facturas"].Value = tbCantidadFacturas.Text;
                    comando.Parameters.Add(new SqlParameter("@rendicion_importe_neto", SqlDbType.Int, 88));
                    comando.Parameters["@rendicion_importe_neto"].Value = Convert.ToInt32(tbImporteMenosComision.Text);
                    comando.Parameters.Add(new SqlParameter("@rendicion_comision", SqlDbType.Float, 88));
                    comando.Parameters["@rendicion_comision"].Value = tbComision.Text;
                    comando.Parameters.Add(new SqlParameter("@rendicion_importe_bruto", SqlDbType.Float, 88));
                    comando.Parameters["@rendicion_importe_bruto"].Value = tbImporte.Text;
                    SqlParameter resultado = new SqlParameter("@resultado", SqlDbType.VarChar, 88);
                    resultado.Direction = ParameterDirection.Output;
                    comando.Parameters.Add(resultado);
                    comando.ExecuteNonQuery();
                    String resultadoString = comando.Parameters["@resultado"].Value.ToString();

                    int idRendicion = 0;
                    base.query = ("SELECT TOP 1 id_rendicion FROM GESDA.Rendicion order by id_rendicion DESC");
                    base.comando = new SqlCommand(query, Utilidades.conexion);
                    base.datos = comando.ExecuteReader();
                    if (datos.Read())
                    {
                        idRendicion = Convert.ToInt32(datos["id_rendicion"].ToString());
                    }
                    datos.Close();

                    //voy insertando en rendicion detalle
                    int facturaNumero;
                    for (int i = 0; i < Convert.ToInt32(tbCantidadFacturas.Text); i++)
                    {
                        facturaNumero = Convert.ToInt32(dgvFacturasRendidas.Rows[i].Cells[1].Value);

                        base.comando = new SqlCommand("GESDA.insertarItemRendicion", Utilidades.conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@id_rendicion", SqlDbType.Int, 88));
                        comando.Parameters["@id_rendicion"].Value = idRendicion;
                        comando.Parameters.Add(new SqlParameter("@factura_numero", SqlDbType.Int, 88));
                        comando.Parameters["@factura_numero"].Value = facturaNumero;
                        comando.Parameters.Add(new SqlParameter("@empresa_nombre", SqlDbType.VarChar, 88));
                        comando.Parameters["@empresa_nombre"].Value = cbEmpresa.Text;
                        SqlParameter resultado2 = new SqlParameter("@resultado", SqlDbType.VarChar, 88);
                        resultado2.Direction = ParameterDirection.Output;
                        comando.Parameters.Add(resultado2);
                        comando.ExecuteNonQuery();
                        String resultadoString2 = comando.Parameters["@resultado"].Value.ToString();

                        if (!String.IsNullOrEmpty(resultadoString2))
                        {
                            resultadoString = comando.Parameters["@resultado"].Value.ToString();
                        }
                    }

                    MessageBox.Show(resultadoString);
                    limpiar_Todo();
                }
                catch (Exception error)
                {
                    MessageBox.Show("se produjo un error: " + error.ToString());
                }
            }
        
        }
    

        private bool validar_campos_rendicion()
        {
            bool resultado = true;

            string falta = "Faltan los siguientes campos o acciones:";

            if (cbEmpresa.SelectedItem == null)
            {
            resultado = false;
            falta = falta + "\n Empresa";
            }
            if (string.IsNullOrEmpty(tbCantidadFacturas.Text) && string.IsNullOrEmpty(tbImporte.Text) && (dgvFacturasRendidas.Rows.Count == 0))
            {
            resultado = false;
            falta = falta + "\n Verificar la empresa";
            }
            if(string.IsNullOrEmpty(tbComision.Text) || string.IsNullOrEmpty(tbImporteMenosComision.Text))
            {
            resultado = false;
            falta = falta + "\n Ingresar la comisión y/o verificarla";
            }

            if (resultado == false)
            {
                MessageBox.Show(falta);
            }
            return resultado;

        }

    }
}
