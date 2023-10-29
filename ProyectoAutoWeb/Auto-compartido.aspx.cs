using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAutoWeb
{
    public partial class Auto_compartido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			if (!IsPostBack)
			{
				SqlConnection miConexion = Conexion.agregarConexion();
				if (miConexion != null)
				{
					String query = String.Format("SELECT idRegistro FROM RegistroUsuario WHERE idUsu = {0}", int.Parse(Session["idUsu"].ToString()));
					SqlCommand cmd = new SqlCommand(query, miConexion);
					SqlDataReader rd = cmd.ExecuteReader();
					while (rd.Read())
					{
						ddIdAu.Items.Add(rd.GetInt32(0).ToString());
					}
					rd.Close();
					miConexion.Close();
				}
			}
		}

        protected void btReg_Click(object sender, EventArgs e)
        {
			try
            {
				int idUsu, idReg, res;

				idReg = int.Parse(ddIdAu.SelectedValue);
				idUsu = int.Parse(txClavUsu.Text);

				SqlConnection con = Conexion.agregarConexion();
				SqlCommand cmd = new SqlCommand(String.Format("INSERT INTO RegistroUsuario (idUsu, idRegistro) VALUES ({0}, {1})", idUsu, idReg), con);
				res = cmd.ExecuteNonQuery();
				if (res > 0)
				{
					lbEx.Text = "Enlace exitoso";
				}
				else
				{
					lbEx.Text = "Relacion interrumpida";
				}
			}
			catch(Exception ex)
            {
				lbEx.Text = "No se puede relacionar al mismo usuario";
            }
		}
    }
}