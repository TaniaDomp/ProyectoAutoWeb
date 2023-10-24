using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAutoWeb
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int idUsu;

            SqlConnection con = Conexion.agregarConexion();
            idUsu = int.Parse(Session["idUsu"].ToString());
            SqlCommand cmd = new SqlCommand(String.Format("SELECT nombreP, aP, aM, domicilio, correo FROM Usuario WHERE idUsu = {0}", idUsu), con);
            SqlDataReader rd = cmd.ExecuteReader();

            rd.Read();
            lbClave.Text = Session["idUsu"].ToString();
            lbNombre.Text = rd.GetString(0);
            lbApellidos.Text = rd.GetString(1) + " " + rd.GetString(2);
            lbDomicilio.Text = rd.GetString(3);
            lbCorreo.Text = rd.GetString(4);

            if (!IsPostBack)
            {
                ddMod.Items.Add("Domicilio");
                ddMod.Items.Add("Correo");
                ddMod.Items.Add("Contraseña");
            }
            con.Close();
        }

        protected void btMod_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = Conexion.agregarConexion();
                String contra = txContra.Text;
                int idUsu;

                idUsu = int.Parse(Session["idUsu"].ToString());
                SqlCommand cmd1 = new SqlCommand(String.Format("SELECT contrasenia FROM Usuario WHERE idUsu = {0}", idUsu), con);
                SqlDataReader rd = cmd1.ExecuteReader();
                rd.Read();

                if (rd.GetString(0).Equals(contra))
                {
                    //0 -> Domicilio, 1-> Correo, 2->Contraseña
                    rd.Close();
                    int selDD, res = 0;
                    SqlCommand cmd;
                    String dN;

                    dN = txNuevoD.Text;
                    selDD = ddMod.SelectedIndex;
                    switch (selDD)
                    {
                        case 0:
                            cmd = new SqlCommand(String.Format("UPDATE Usuario SET domicilio = '{0}' WHERE idUsu = {1}", dN, idUsu), con);
                            res = cmd.ExecuteNonQuery();
                            break;
                        case 1:
                            cmd = new SqlCommand(String.Format("UPDATE Usuario SET correo = '{0}' WHERE idUsu = {1}", dN, idUsu), con);
                            res = cmd.ExecuteNonQuery();
                            break;
                        case 2:
                            cmd = new SqlCommand(String.Format("UPDATE Usuario SET contrasenia = '{0}' WHERE idUsu = {1}", dN, idUsu), con);
                            res = cmd.ExecuteNonQuery();
                            break;
                    }
                    if(res > 0)
                    {
                        lbErrOp.Text = "Modificacion exitosa";
                    }
                    else
                    {
                        lbErrOp.Text = "Error en la modificacion";
                    }
                }
                else
                {
                    lbErrOp.Text = "Contraseña incorrecta";
                }
            }
            catch(Exception ex)
            {
                lbErrOp.Text = "Error en la operacion";
            }
        }
    }
}