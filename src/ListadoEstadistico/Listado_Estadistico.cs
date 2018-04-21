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

namespace PagoAgilFrba.ListadoEstadistico
{
    public partial class Listado_Estadistico : PantallasGenericas.Pantalla_Inicial
    {
        public Listado_Estadistico()
        {
            InitializeComponent();

            //lleno las opciones del listado
            combo_listado.Items.Add("Porcentaje de facturas cobradas por empresa");
            combo_listado.Items.Add("Empresas con mayor monto rendido");
            combo_listado.Items.Add("Clientes con mas pagos");
            combo_listado.Items.Add("Clientes con mayor porcentaje de facturas pagadas");

            //lleno los trimestres
            combo_trimestre.Items.Add("Primer trimestre");
            combo_trimestre.Items.Add("Segundo trimestre");
            combo_trimestre.Items.Add("Tercer trimestre");
            combo_trimestre.Items.Add("Cuarto trimestre");

            //seteo el año con el archivo de configuracion
            año.Value = Utilidades.fecha;
        }

        public bool validar()
        {
            bool noHayError = true;

            if ((combo_trimestre.SelectedIndex < 0))
            {
                //al error provider le paso el combo box que no cumple la validacion
                errorValidar.SetError(combo_trimestre, "Por favor selecione un item");
                noHayError = false;
            }

            if ((combo_listado.SelectedIndex < 0))
            {
                //al error provider le paso el combo box que no cumple la validacion
                errorValidar.SetError(combo_listado, "Por favor selecione un item");
                noHayError = false;
            }

            return noHayError;

        }

        private void boton_consultar_Click(object sender, EventArgs e)
        {
            //borro los errores anteriores
            this.errorValidar.Clear();

            if (this.validar())
            {
                //limpio la tabla de resultados, si es que tiene
                if (listado.Rows.Count != 0)
                {
                    DataTable dt = (DataTable)listado.DataSource;
                    dt.Clear();
                }

                if (combo_listado.SelectedItem.ToString() == "Porcentaje de facturas cobradas por empresa")
                {
                    String query = String.Format("select * from GESDA.PorcentajeFacturas('{0}','{1}')", combo_trimestre.SelectedItem.ToString(), Convert.ToString(año.Value.Year));
                    //lleno la tabla con las empresas que mas facturas cobradas tuvieron y su porcentaje
                    SqlDataAdapter dp = new SqlDataAdapter(query, Utilidades.conexion);
                    DataSet ds = new DataSet();
                    dp.Fill(ds);
                    listado.DataSource = ds.Tables[0];
                }
                if (combo_listado.SelectedItem.ToString() == "Empresas con mayor monto rendido")
                {
                    String query = String.Format("select * from GESDA.EmpresasMayorMonto('{0}','{1}')", combo_trimestre.SelectedItem.ToString(), Convert.ToString(año.Value.Year));
                    //lleno la tabla con las empresas que mas rindieron
                    SqlDataAdapter dp = new SqlDataAdapter(query, Utilidades.conexion);
                    DataSet ds = new DataSet();
                    dp.Fill(ds);
                    listado.DataSource = ds.Tables[0];
                }
                if (combo_listado.SelectedItem.ToString() == "Clientes con mas pagos")
                {
                    String query = String.Format("select * from gesda.ClientesConMasPagos('{0}','{1}')", combo_trimestre.SelectedItem.ToString(), Convert.ToString(año.Value.Year));
                    //lleno la tabla con los clientes que tuvieron mas pagos
                    SqlDataAdapter dp = new SqlDataAdapter(query, Utilidades.conexion);
                    DataSet ds = new DataSet();
                    dp.Fill(ds);
                    listado.DataSource = ds.Tables[0];
                }
                if (combo_listado.SelectedItem.ToString() == "Clientes con mayor porcentaje de facturas pagadas")
                {
                    String query = String.Format("select * from gesda.Clientescumplidores('{0}','{1}')", combo_trimestre.SelectedItem.ToString(), Convert.ToString(año.Value.Year));
                    //lleno la tabla con los clientes que tuvieron mas porcentaje de facturas pagadas
                    SqlDataAdapter dp = new SqlDataAdapter(query, Utilidades.conexion);
                    DataSet ds = new DataSet();
                    dp.Fill(ds);
                    listado.DataSource = ds.Tables[0];
                }
            }
        }
    }
}
