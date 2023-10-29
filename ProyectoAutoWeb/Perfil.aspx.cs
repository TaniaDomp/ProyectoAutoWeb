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
           try
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
                rd.Close();

                if (!IsPostBack)
                {
                    String query = String.Format("SELECT idRegistro FROM RegistroUsuario WHERE idUsu = {0}", int.Parse(Session["idUsu"].ToString()));
                    SqlCommand cmd1 = new SqlCommand(query, con);
                    SqlDataReader rd1 = cmd1.ExecuteReader();
                    while (rd1.Read())
                    {
                        ddIdAut.Items.Add(rd1.GetInt32(0).ToString());
                    }
                    rd1.Close();
                    ddMod.Items.Add("Domicilio");
                    ddMod.Items.Add("Correo");
                    ddMod.Items.Add("Contraseña");
                }
                con.Close();
            }
            catch(Exception ex)
            {
                lbErrOp.Text = "Error en la operación";
            }
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

        protected void btEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                //Solo se puede eliminar el auto si no tiene viajes registrados 
                SqlConnection con = Conexion.agregarConexion();
                SqlCommand cmdViaUsu, cmdEli1, cmdEli2;
                int idReg, re1, re2;

                idReg = int.Parse(ddIdAut.SelectedValue);
                cmdViaUsu = new SqlCommand(String.Format("SELECT idViaje FROM Viaje WHERE Viaje.idRegistro = {0}", idReg), con);
                SqlDataReader rd = cmdViaUsu.ExecuteReader();
                if (!rd.HasRows)
                {
                    rd.Close();
                    cmdEli1 = new SqlCommand(String.Format("DELETE FROM RegistroUsuario WHERE idRegistro = {0}", idReg), con);
                    re1 = cmdEli1.ExecuteNonQuery();
                    cmdEli2 = new SqlCommand(String.Format("DELETE FROM Registro WHERE idRegistro = {0}", idReg), con);
                    re2 = cmdEli2.ExecuteNonQuery();
                    if (re1 > 0 & re2 > 0)
                        lbElimina.Text = "Auto eliminado";
                    else
                        lbElimina.Text = "Error en la eliminacion";
                }
                else
                {
                    lbElimina.Text = "El auto no se puede eliminar porque cuenta con informacion";
                }
                con.Close();
            }
            catch(Exception ex)
            {
                lbElimina.Text = "Error en la operacion";
            }
        }
    }
}