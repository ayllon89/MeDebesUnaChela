﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PagoAgilFrba.AbmFactura
{
    public partial class Inicio_ABM_Factura : PantallasGenericas.Pantalla_ABM

    {
        public Inicio_ABM_Factura(String rol)
        {
            InitializeComponent();

            //valido si el rol puede entrar al alta
            base.query = String.Format("select * from gesda.funcion f join gesda.rol_funcion rf on (f.id_funcion=rf.id_funcion) join gesda.rol r on (r.id_rol=rf.id_rol) where f.funcion_nombre='factura alta' and r.rol_nombre='{0}'", rol);
            base.comando = new SqlCommand(query, Utilidades.conexion);
            base.datos = comando.ExecuteReader();

            if (datos.Read())
            {
                datos.Close();
            }
            else
            {
                datos.Close();
                boton_alta.Visible = false;
            }

            //valido si el rol puede entrar a la modificacion
            base.query = String.Format("select * from gesda.funcion f join gesda.rol_funcion rf on (f.id_funcion=rf.id_funcion) join gesda.rol r on (r.id_rol=rf.id_rol) where f.funcion_nombre='factura modificacion' and r.rol_nombre='{0}'", rol);
            base.comando = new SqlCommand(query, Utilidades.conexion);
            base.datos = comando.ExecuteReader();

            if (datos.Read())
            {
                datos.Close();
            }
            else
            {
                datos.Close();
                boton_modificacion.Visible = false;
            }
        }

        private void boton_alta_Click(object sender, EventArgs e)
        {
            Alta_Factura ventanaAltaFactura = new Alta_Factura();
            ventanaAltaFactura.Show();
        }

        private void boton_modificacion_Click(object sender, EventArgs e)
        {
            Listado_Modificacion_Factura ventanaModificacion = new Listado_Modificacion_Factura();
            ventanaModificacion.Show();
        }
    }
}
