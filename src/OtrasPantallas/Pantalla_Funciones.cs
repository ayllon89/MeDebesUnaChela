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
    public partial class Pantalla_Funciones : PantallasGenericas.Pantalla_Inicial
    {
        private String rol;
        private String sucursal;

        public Pantalla_Funciones(string rolSeleccionado, string sucursalSeleccionada)
        {
            this.rol = rolSeleccionado;
            this.sucursal = sucursalSeleccionada;
            InitializeComponent();

            //se realizan las validaciones para ver a que funcionalidades puede entrar el rol
            //valido si el rol puede entrar a ABM rol
            base.query = String.Format("select * from gesda.funcion f join gesda.rol_funcion rf on (f.id_funcion=rf.id_funcion) join gesda.rol r on (r.id_rol=rf.id_rol) where f.funcion_nombre like '%rol%' and r.rol_nombre='{0}'", rol);
            base.comando = new SqlCommand(query, Utilidades.conexion);
            base.datos = comando.ExecuteReader();

            if (!datos.Read())
            {
                datos.Close();
                boton_abm_rol.Visible = false;
            }
            datos.Close();

            //valido si el rol puede entrar a ABM cliente
            base.query = String.Format("select * from gesda.funcion f join gesda.rol_funcion rf on (f.id_funcion=rf.id_funcion) join gesda.rol r on (r.id_rol=rf.id_rol) where f.funcion_nombre like '%cliente%' and r.rol_nombre='{0}'", rol);
            base.comando = new SqlCommand(query, Utilidades.conexion);
            base.datos = comando.ExecuteReader();

            if (!datos.Read())
            {
                datos.Close();
                boton_abm_cliente.Visible = false;
            }
            datos.Close();

            //valido si el rol puede entrar a ABM empresa
            base.query = String.Format("select * from gesda.funcion f join gesda.rol_funcion rf on (f.id_funcion=rf.id_funcion) join gesda.rol r on (r.id_rol=rf.id_rol) where f.funcion_nombre like '%empresa%' and r.rol_nombre='{0}'", rol);
            base.comando = new SqlCommand(query, Utilidades.conexion);
            base.datos = comando.ExecuteReader();

            if (!datos.Read())
            {
                datos.Close();
                boton_abm_empresa.Visible = false;
            }
            datos.Close();

            //valido si el rol puede entrar a ABM sucursal
            base.query = String.Format("select * from gesda.funcion f join gesda.rol_funcion rf on (f.id_funcion=rf.id_funcion) join gesda.rol r on (r.id_rol=rf.id_rol) where f.funcion_nombre like '%sucursal%' and r.rol_nombre='{0}'", rol);
            base.comando = new SqlCommand(query, Utilidades.conexion);
            base.datos = comando.ExecuteReader();

            if (!datos.Read())
            {
                datos.Close();
                boton_abm_sucursal.Visible = false;
            }
            datos.Close();

            //valido si el rol puede entrar a ABM factura
            base.query = String.Format("select * from gesda.funcion f join gesda.rol_funcion rf on (f.id_funcion=rf.id_funcion) join gesda.rol r on (r.id_rol=rf.id_rol) where f.funcion_nombre like 'factura%' and r.rol_nombre='{0}'", rol);
            base.comando = new SqlCommand(query, Utilidades.conexion);
            base.datos = comando.ExecuteReader();

            if (!datos.Read())
            {
                datos.Close();
                boton_abm_factura.Visible = false;
            }
            datos.Close();

            //valido si el rol puede entrar a registro pago
            base.query = String.Format("select * from gesda.funcion f join gesda.rol_funcion rf on (f.id_funcion=rf.id_funcion) join gesda.rol r on (r.id_rol=rf.id_rol) where f.funcion_nombre like '%registrar%' and r.rol_nombre='{0}'", rol);
            base.comando = new SqlCommand(query, Utilidades.conexion);
            base.datos = comando.ExecuteReader();

            if (!datos.Read())
            {
                datos.Close();
                boton_registrar_pago.Visible = false;
            }
            datos.Close();

            //valido si el rol puede entrar a rendicion facturas
            base.query = String.Format("select * from gesda.funcion f join gesda.rol_funcion rf on (f.id_funcion=rf.id_funcion) join gesda.rol r on (r.id_rol=rf.id_rol) where f.funcion_nombre like '%rendir%' and r.rol_nombre='{0}'", rol);
            base.comando = new SqlCommand(query, Utilidades.conexion);
            base.datos = comando.ExecuteReader();

            if (!datos.Read())
            {
                datos.Close();
                boton_rendir_facturas.Visible = false;
            }
            datos.Close();

            //valido si el rol puede entrar a Devoluciones
            base.query = String.Format("select * from gesda.funcion f join gesda.rol_funcion rf on (f.id_funcion=rf.id_funcion) join gesda.rol r on (r.id_rol=rf.id_rol) where f.funcion_nombre like '%devolucion%' and r.rol_nombre='{0}'", rol);
            base.comando = new SqlCommand(query, Utilidades.conexion);
            base.datos = comando.ExecuteReader();

            if (!datos.Read())
            {
                datos.Close();
                boton_devolucion.Visible = false;
            }
            datos.Close();

            //valido si el rol puede entrar a listado estadistico
            base.query = String.Format("select * from gesda.funcion f join gesda.rol_funcion rf on (f.id_funcion=rf.id_funcion) join gesda.rol r on (r.id_rol=rf.id_rol) where f.funcion_nombre like '%listado%' and r.rol_nombre='{0}'", rol);
            base.comando = new SqlCommand(query, Utilidades.conexion);
            base.datos = comando.ExecuteReader();

            if (!datos.Read())
            {
                datos.Close();
                boton_listado_estadistico.Visible = false;
            }
            datos.Close();
        }

        private void boton_abm_rol_Click(object sender, EventArgs e)
        {
                AbmRol.Rol_Inicio ventanaRol = new AbmRol.Rol_Inicio(rol);
                ventanaRol.Show();
        }

        private void boton_devolucion_Click(object sender, EventArgs e)
        {
            Devolucion.Devolucion_Listado ventanaDevolucionListado = new Devolucion.Devolucion_Listado();
            ventanaDevolucionListado.Show();
        }

        private void boton_abm_sucursal_Click(object sender, EventArgs e)
        {
            AbmSucursal.Sucursal_Inicio ventanaSucursal = new AbmSucursal.Sucursal_Inicio(rol);
            ventanaSucursal.Show();
        }

        private void boton_registrar_pago_Click(object sender, EventArgs e)
        {
            RegistroPago.RegistroPago ventanaRegistroPago = new RegistroPago.RegistroPago(sucursal);
            ventanaRegistroPago.Show();
        }

        private void boton_rendir_facturas_Click(object sender, EventArgs e)
        {
            Rendicion.Rendicion ventanaRendicion = new Rendicion.Rendicion();
            ventanaRendicion.Show();
        }

        private void boton_abm_cliente_Click(object sender, EventArgs e)
        {
            AbmCliente.Cliente_Inicio ventanaClienteInicio = new AbmCliente.Cliente_Inicio(rol);
            ventanaClienteInicio.Show();
        }

        private void boton_listado_estadistico_Click(object sender, EventArgs e)
        {
            ListadoEstadistico.Listado_Estadistico ventanaListado = new ListadoEstadistico.Listado_Estadistico();
            ventanaListado.Show();
        }

        private void boton_abm_empresa_Click(object sender, EventArgs e)
        {
            AbmEmpresa.Empresa_Inicio ventanaEmpresa = new AbmEmpresa.Empresa_Inicio(rol);
            ventanaEmpresa.Show();
        }

        private void boton_abm_factura_Click(object sender, EventArgs e)
        {
            AbmFactura.Inicio_ABM_Factura ventanaFactura = new AbmFactura.Inicio_ABM_Factura(rol);
            ventanaFactura.Show();
        }
    }
}
