using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAutoWeb
{
    public partial class Agrega_Viaje : System.Web.UI.Page
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
						ddIdAut.Items.Add(rd.GetInt32(0).ToString());
					}
					rd.Close();
					miConexion.Close();

					ddTipoViaje.Items.Add("Por Dia");
					ddTipoViaje.Items.Add("Por Semana");
					ddTipoViaje.Items.Add("Por Mes");
				}
			}
		}

        protected void ddTipoViaje_SelectedIndexChanged(object sender, EventArgs e)
        {
			SqlConnection con = Conexion.agregarConexion();
			SqlCommand cmdV, cmdT, cmdAu, cmdCV;
			int selec, idReg, res1 = 0, res2 = 0;
			String idAut;


			selec = ddTipoViaje.SelectedIndex;
			idReg = int.Parse(ddIdAut.SelectedValue);
			cmdAu = new SqlCommand(String.Format("SELECT Automovil.idAut, Automovil.emisionCO2, Automovil.emisionNOx FROM Automovil INNER JOIN Registro ON Registro.idAut = Automovil.idAut WHERE Registro.idRegistro = {0}", idReg), con);
			SqlDataReader rdAu = cmdAu.ExecuteReader();
			rdAu.Read();
			idAut = rdAu.GetString(0);

			//0->Por dia, 1-> Por semana, 2-> Por mes
			switch (selec)
			{
				case 0:
					

					lbDiaHorViaj.Visible = true;
					lbDiaVelProm.Visible = true;
					txDiaHorViaj.Visible = true;
					txDiaVelP.Visible = true;
					btDia.Visible = true;

					//oculta las demas ventanas
					lbSemDias.Visible = false;
					lbSemHoras.Visible = false;
					lbSemVelProm.Visible = false;
					txSemDias.Visible = false;
					txSemHoras.Visible = false;
					txSemVelProm.Visible = false;
					lbMesDiaUs.Visible = false;
					lbMesKm.Visible = false;
					txMesDiaUs.Visible = false;
					txMesKm.Visible = false;
					btMes.Visible = false;
					btSemana.Visible = false;
					break;
				case 1:
					lbSemDias.Visible = true;
					lbSemHoras.Visible = true;
					lbSemVelProm.Visible = true;
					txSemDias.Visible = true;
					txSemHoras.Visible = true;
					txSemVelProm.Visible = true;
					btSemana.Visible = true;

					//oculta las demas ventanas
					lbMesDiaUs.Visible = false;
					lbMesKm.Visible = false;
					txMesDiaUs.Visible = false;
					txMesKm.Visible = false;
					lbDiaHorViaj.Visible = false;
					lbDiaVelProm.Visible = false;
					txDiaHorViaj.Visible = false;
					txDiaVelP.Visible = false;
					btDia.Visible = false;
					btMes.Visible = false;
					break;
				case 2:
					lbMesDiaUs.Visible = true;
					lbMesKm.Visible = true;
					txMesDiaUs.Visible = true;
					txMesKm.Visible = true;
					btMes.Visible = true;

					//oculta las demas ventanas
					lbSemDias.Visible = false;
					lbSemHoras.Visible = false;
					lbSemVelProm.Visible = false;
					txSemDias.Visible = false;
					txSemHoras.Visible = false;
					txSemVelProm.Visible = false;
					lbDiaHorViaj.Visible = false;
					lbDiaVelProm.Visible = false;
					txDiaHorViaj.Visible = false;
					txDiaVelP.Visible = false;
					btDia.Visible = false;
					btSemana.Visible = false;
					break;
			}
		}

    }
}