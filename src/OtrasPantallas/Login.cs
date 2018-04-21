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

namespace PagoAgilFrba.OtrasPantallas
{
    public partial class Login : PantallasGenericas.Pantalla_Inicial
    {
        public Login()
        {
            InitializeComponent();
        }
       
        public bool validar()
        {
            //indico primero que no hay error
            bool noHayError = true;

            //valido que el usuario no este vacio
            if (vt_user.Text == String.Empty)
            {
                //al error provider le paso el texbox o boton que no cumple la validacion
                errorValidar.SetError(vt_user, "Por favor complete el usuario");
                noHayError = false;
            }
            //valido que el password no este vacio
            if (vt_pass.Text == String.Empty)
            {
                //al error provider le paso el texbox o boton que no cumple la validacion
                errorValidar.SetError(vt_pass, "Por favor complete la contraseña");
                noHayError = false;
            }

            return noHayError;
        }

        private void boton_iniciar_sesion_Click(object sender, EventArgs e)
        {
            //dejo en blanco los errores anteriores, si es que tenia
            errorValidar.Clear();
            //primero valido que complete todos los campos
            if (this.validar())
            {
                try
                {
                    //establesco los parametros iniciales
                    Utilidades.establecerConexion();
                    Utilidades.establecerFecha();

                    //llamo al procedure
                    SqlCommand comando = new SqlCommand("GESDA.login", Utilidades.conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    //declaro los parametros y seteo los parametros de entrada
                    comando.Parameters.Add(new SqlParameter("@username", SqlDbType.VarChar, 88));
                    comando.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 88));
                    comando.Parameters["@username"].Value = vt_user.Text;
                    comando.Parameters["@password"].Value = vt_pass.Text;
                    SqlParameter resultado = new SqlParameter("@resultado", SqlDbType.VarChar, 88);
                    resultado.Direction = ParameterDirection.Output;
                    comando.Parameters.Add(resultado);
                    //ejecuto el comando 
                    comando.ExecuteNonQuery();
                    String resultadoString = comando.Parameters["@resultado"].Value.ToString();


                    if (resultadoString == "login correcto")
                    {
                        //abro la ventana del usuario para que elija los roles
                        OtrasPantallas.Seleccion_Sucursal ventanaSucursal = new OtrasPantallas.Seleccion_Sucursal(vt_user.Text);
                        ventanaSucursal.Show();
                    }
                    else
                    {
                        //muestro resultado en caso de errores de usuario
                        MessageBox.Show(resultadoString);
                    }

                    //borro lo que escribio el usuario
                    vt_user.Text = "";
                    vt_pass.Text = "";


                }
                catch (Exception error)
                {
                    MessageBox.Show("se produjo un error: " + error.ToString());
                }

            }

        }

    }
}
