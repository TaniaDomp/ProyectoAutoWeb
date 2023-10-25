using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAutoWeb
{
    public partial class OpUsu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int idUsu;
                SqlConnection con = Conexion.agregarConexion();

                idUsu = int.Parse(Session["idUsu"].ToString());
                SqlCommand cmd = new SqlCommand(String.Format("SELECT Automovil.marca, Automovil.submarca, Automovil.AnioModelo, Registro.idRegistro, Registro.aniosAntiguedad, Registro.emisionesCO2Tot, Registro.emisionesNOxTot, Registro.emisionesMenCO2, Registro.emisionesMenNOx FROM Registro, Automovil, Usuario, RegistroUsuario WHERE Registro.idAut = Automovil.idAut AND RegistroUsuario.idRegistro = Registro.idRegistro AND RegistroUsuario.idUsu = Usuario.idUsu AND Usuario.idUsu = {0}", idUsu), con);
                SqlDataReader rd = cmd.ExecuteReader();
                gvDatos.DataSource = rd;
                gvDatos.DataBind();
                con.Close();
            }
            catch(Exception ex)
            {
                gvDatos.DataSource = "Error en la operacion";
            }
        }

        protected void btCCO2_Click(object sender, EventArgs e)
        {
            SqlConnection con = Conexion.agregarConexion();
            int idUsu;
            float totCO2;
            String txtFin;

            idUsu = int.Parse(Session["idUsu"].ToString());
            SqlCommand cmd = new SqlCommand(String.Format("SELECT SUM(Registro.emisionesCO2Tot) FROM Registro, Automovil, Usuario, RegistroUsuario WHERE Registro.idAut = Automovil.idAut AND RegistroUsuario.idRegistro = Registro.idRegistro AND RegistroUsuario.idUsu = Usuario.idUsu AND Usuario.idUsu = {0}", idUsu), con);
            SqlDataReader rd = cmd.ExecuteReader();
            rd.Read();
            totCO2 = (float)rd.GetDouble(0);
            //checar problemas con el cast
            txtFin = "Sus emisiones son de " + totCO2 + "kg.";
            txCalCO2.Text = txtFin;
            con.Close();
        }

        protected void btCNOx_Click(object sender, EventArgs e)
        {
            SqlConnection con = Conexion.agregarConexion();
            int idUsu;
            float totCO2;
            String txtFin;

            idUsu = int.Parse(Session["idUsu"].ToString());
            SqlCommand cmd = new SqlCommand(String.Format("SELECT SUM(Registro.emisionesNOxTot) FROM Registro, Automovil, Usuario, RegistroUsuario WHERE Registro.idAut = Automovil.idAut AND RegistroUsuario.idRegistro = Registro.idRegistro AND RegistroUsuario.idUsu = Usuario.idUsu AND Usuario.idUsu = {0}", idUsu), con);
            SqlDataReader rd = cmd.ExecuteReader();
            rd.Read();
            totCO2 = (float)rd.GetDouble(0);
            //checar problemas con el cast
            txtFin = "Sus emisiones son de " + totCO2 + "kg.";
            txCalCO2.Text = txtFin;
            con.Close();
        }
    }
}