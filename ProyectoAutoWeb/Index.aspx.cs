using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAutoWeb
{
    public partial class AltaUsu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btInicioSes_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            SqlDataReader dr;
            SqlCommand cmd;
            String correo, contra;

            try
            {
                correo = txCorreoInS.Text;
                contra = txContraIS.Text;
                if(correo != "" & contra != "")
                {
                    con = Conexion.agregarConexion();
                    cmd = new SqlCommand(String.Format("SELECT idUsu from Usuario where correo='{0}' AND contrasenia = '{1}'", correo, contra), con);
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        Session["idUsu"] = dr.GetInt32(0).ToString();
                        lbInSes.Text = "Usuario y password correcto";
                        Response.Redirect("OpUsu.aspx");
                    }
                    else
                        lbInSes.Text = "Usuario o contraseña incorrectos";//usuario no encontrado
                    con.Close();
                }
                else
                {
                    lbInSes.Text = "Campos vacios";
                }
            }
            catch (Exception ex)
            {
                lbInSes.Text = "Error";
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            try
            {
                int res;
                SqlConnection con = Conexion.agregarConexion();
                SqlCommand cmd;
                String nombre, aP, aM, domicilio, correo, contrasenia;

                nombre = txNombre.Text;
                aP = txAP.Text;
                aM = txAM.Text;
                domicilio = txCorreo.Text;
                correo = txCorreo.Text;
                contrasenia = txContra.Text;
                if(nombre != "" & aP != "" & aM != "" & domicilio != "" & correo != "" & contrasenia != "" )
                {
                    cmd = new SqlCommand(String.Format("INSERT INTO Usuario VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", nombre, aP, aM, domicilio, correo, contrasenia), con);
                    res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        lbReg.Text = "Alta exitosa";
                    }
                    else
                    {
                        lbReg.Text = "Error en el alta";
                    }
                }
                else
                {
                    lbReg.Text = "Existen campos vacios";
                }
                con.Close();
            }
            catch (Exception ex)
            {
                lbReg.Text = "Error";
            }
        }

    }
}