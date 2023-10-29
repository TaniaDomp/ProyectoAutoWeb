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
			int selec;

			selec = ddTipoViaje.SelectedIndex;
			//0->Por dia, 1-> Por semana, 2-> Por mes
			switch (selec)
			{
				case 0:
					lbDiaHorViaj.Visible = true;
					lbDiaVelProm.Visible = true;
					txDiaHorViaj.Visible = true;
					txDiaVelP.Visible = true;
					btDia.Visible = true;
					lbDias.Visible = true;
					lbExi.Text = "";
					lbSem.Text = "";
					lbDias.Text = "";
					lbMes.Text = "";
					txDiaHorViaj.Text = "";
					txDiaVelP.Text = "";
					txSemDias.Text = "";
					txSemHoras.Text = "";
					txSemVelProm.Text = "";
					txDiaHorViaj.Text = "";
					txDiaVelP.Text = "";


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
					lbSem.Visible = false;
					lbMes.Visible = false;
					break;
				case 1:
					lbSemDias.Visible = true;
					lbSemHoras.Visible = true;
					lbSemVelProm.Visible = true;
					txSemDias.Visible = true;
					txSemHoras.Visible = true;
					txSemVelProm.Visible = true;
					btSemana.Visible = true;
					lbSem.Visible = true;
					lbExi.Text = "";
					lbSem.Text = "";
					lbDias.Text = "";
					lbMes.Text = "";
					txDiaHorViaj.Text = "";
					txDiaVelP.Text = "";
					txSemDias.Text = "";
					txSemHoras.Text = "";
					txSemVelProm.Text = "";
					txDiaHorViaj.Text = "";
					txDiaVelP.Text = "";

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
					lbDias.Visible = false;
					lbMes.Visible = false;
					break;
				case 2:
					lbMesDiaUs.Visible = true;
					lbMesKm.Visible = true;
					txMesDiaUs.Visible = true;
					txMesKm.Visible = true;
					btMes.Visible = true;
					lbMes.Visible = true;
					lbExi.Text = "";
					lbSem.Text = "";
					lbDias.Text = "";
					lbMes.Text = "";
					txDiaHorViaj.Text = "";
					txDiaVelP.Text = "";
					txSemDias.Text = "";
					txSemHoras.Text = "";
					txSemVelProm.Text = "";
					txDiaHorViaj.Text = "";
					txDiaVelP.Text = "";

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
					lbDias.Visible = false;
					lbSem.Visible = false;
					break;
			}
		}

        protected void btDia_Click(object sender, EventArgs e)
        {
			try
            {
				SqlConnection con = Conexion.agregarConexion();
				SqlCommand cmdV, cmdT, cmdAu, cmdCV;
				int idReg, res1 = 0, res2 = 0, diaHor, diavelProm, diaKm;
				String idAut, tipoV, fecha;
				float CO2, NOx, totCO2, totNOx;

				idReg = int.Parse(ddIdAut.SelectedValue);
				cmdAu = new SqlCommand(String.Format("SELECT Automovil.idAut, Automovil.emisionCO2, Automovil.emisionNOx FROM Automovil INNER JOIN Registro ON Registro.idAut = Automovil.idAut WHERE Registro.idRegistro = {0}", idReg), con);
				SqlDataReader rdAu = cmdAu.ExecuteReader();
				rdAu.Read();
				idAut = rdAu.GetString(0);
				tipoV = "porDia";
				fecha = DateTime.Now.ToShortDateString();
				diaHor = int.Parse(txDiaHorViaj.Text);
				diavelProm = int.Parse(txDiaVelP.Text);
				CO2 = (float)rdAu.GetDouble(1);
				NOx = (float)rdAu.GetDouble(2);
				rdAu.Close();
				diaKm = diaHor * diavelProm;
				totCO2 = CO2 * diaKm;
				totNOx = NOx * diaKm;
				cmdV = new SqlCommand(String.Format("INSERT INTO Viaje (tipo, fecha, emisionCO2, emisionNOx, idRegistro) VALUES ('{0}', '{1}', {2}, {3}, {4})", tipoV, fecha, totCO2, totNOx, idReg), con);
				res1 = cmdV.ExecuteNonQuery();
				cmdCV = new SqlCommand(String.Format("SELECT idViaje FROM Viaje WHERE @@ROWCOUNT > 0 AND idViaje = SCOPE_IDENTITY()"), con);
				SqlDataReader rd1 = cmdCV.ExecuteReader();
				rd1.Read();
				int idViaj = rd1.GetInt32(0);
				rd1.Close();
				cmdT = new SqlCommand(String.Format("INSERT INTO porDia (idViaje, velocidadProm, horasViajadas) VALUES ({0}, {1}, {2})", idViaj, diavelProm, diaHor), con);
				res2 = cmdT.ExecuteNonQuery();
				if (res1 > 0 & res2 > 0)
				{
					float totCO2S, totNOxS, totSumCO2, totSumNOx;
					int resAct = 0;

					SqlCommand cmdTot = new SqlCommand(String.Format("SELECT emisionesCO2Tot, emisionesNOxTot FROM Registro WHERE idRegistro = {0}", idReg), con);
					SqlDataReader rdTot = cmdTot.ExecuteReader();
					rdTot.Read();
					totCO2S = (float)rdTot.GetDouble(0);
					totSumCO2 = totCO2 + totCO2S;
					totNOxS = (float)rdTot.GetDouble(1);
					totSumNOx = totNOx + totNOxS;
					rdTot.Close();
					SqlCommand act = new SqlCommand(String.Format("UPDATE Registro SET emisionesCO2Tot = {0}, emisionesNOxTot = {1} WHERE idRegistro = {2}", totSumCO2, totSumNOx, idReg), con);
					resAct = act.ExecuteNonQuery();
					if (resAct > 0)
						lbDias.Text = "Registro exitoso";
					else
						lbDias.Text = "Error en la actualizacion";
				}
				else
				{
					lbDias.Text = "Error en el registro";
				}
				con.Close();
			}
			catch(Exception ex)
            {
				lbExi.Text = "Error en la operacion";
            }
		}

        protected void btSemana_Click(object sender, EventArgs e)
        {
			try
			{
				SqlConnection con = Conexion.agregarConexion();
				SqlCommand cmdV, cmdT, cmdAu, cmdCV;
				int idReg, res1 = 0, res2 = 0, semHor, semVelProm, semDias, semKm;
				String idAut, tipoV, fecha;
				float CO2, NOx, totCO2, totNOx;

				idReg = int.Parse(ddIdAut.SelectedValue);
				cmdAu = new SqlCommand(String.Format("SELECT Automovil.idAut, Automovil.emisionCO2, Automovil.emisionNOx FROM Automovil INNER JOIN Registro ON Registro.idAut = Automovil.idAut WHERE Registro.idRegistro = {0}", idReg), con);
				SqlDataReader rdAu = cmdAu.ExecuteReader();
				rdAu.Read();
				idAut = rdAu.GetString(0);
				tipoV = "porSem";
				fecha = DateTime.Now.ToShortDateString();
				semHor = int.Parse(txSemHoras.Text);
				semVelProm = int.Parse(txSemVelProm.Text);
				semDias = int.Parse(txSemDias.Text);
				CO2 = (float)rdAu.GetDouble(1);
				NOx = (float)rdAu.GetDouble(2);
				rdAu.Close();
				semKm = semHor * semDias * semVelProm;
				totCO2 = CO2 * semKm;
				totNOx = NOx * semKm;
				cmdV = new SqlCommand(String.Format("INSERT INTO Viaje (tipo, fecha, emisionCO2, emisionNOx, idRegistro) VALUES ('{0}', '{1}', {2}, {3}, {4})", tipoV, fecha, totCO2, totNOx, idReg), con);
				res1 = cmdV.ExecuteNonQuery();
				cmdCV = new SqlCommand(String.Format("SELECT idViaje FROM Viaje WHERE @@ROWCOUNT > 0 AND idViaje = SCOPE_IDENTITY()"), con);
				SqlDataReader rd1 = cmdCV.ExecuteReader();
				rd1.Read();
				int idViaj = rd1.GetInt32(0);
				rd1.Close();
				cmdT = new SqlCommand(String.Format("INSERT INTO porSem (idViaje, horasPorDia, velocidadProm, numDiasAuto) VALUES ({0}, {1}, {2}, {3})", idViaj, semHor, semVelProm, semDias), con);
				res2 = cmdT.ExecuteNonQuery();
				if (res1 > 0 & res2 > 0)
				{
					float totCO2S, totNOxS, totSumCO2, totSumNOx;
					int resAct = 0;

					SqlCommand cmdTot = new SqlCommand(String.Format("SELECT emisionesCO2Tot, emisionesNOxTot FROM Registro WHERE idRegistro = {0}", idReg), con);
					SqlDataReader rdTot = cmdTot.ExecuteReader();
					rdTot.Read();
					totCO2S = (float)rdTot.GetDouble(0);
					totSumCO2 = totCO2 + totCO2S;
					totNOxS = (float)rdTot.GetDouble(1);
					totSumNOx = totNOx + totNOxS;
					rdTot.Close();
					SqlCommand act = new SqlCommand(String.Format("UPDATE Registro SET emisionesCO2Tot = {0}, emisionesNOxTot = {1} WHERE idRegistro = {2}", totSumCO2, totSumNOx, idReg), con);
					resAct = act.ExecuteNonQuery();
					if (resAct > 0)
						lbSem.Text = "Registro exitoso";
					else
						lbSem.Text = "Error en la actualizacion";
				}
				else
				{
					lbSem.Text = "Error en el registro";
				}
				con.Close();
			}
			catch (Exception ex)
			{
				lbExi.Text = "Error en la operacion";
			}
		}

        protected void btMes_Click(object sender, EventArgs e)
        {
			try
			{
				SqlConnection con = Conexion.agregarConexion();
				SqlCommand cmdV, cmdT, cmdAu, cmdCV;
				int idReg, res1 = 0, res2 = 0, mesKm, mesRKm, mesDias;
				String idAut, tipoV, fecha;
				float CO2, NOx, totCO2, totNOx;

				idReg = int.Parse(ddIdAut.SelectedValue);
				cmdAu = new SqlCommand(String.Format("SELECT Automovil.idAut, Automovil.emisionCO2, Automovil.emisionNOx FROM Automovil INNER JOIN Registro ON Registro.idAut = Automovil.idAut WHERE Registro.idRegistro = {0}", idReg), con);
				SqlDataReader rdAu = cmdAu.ExecuteReader();
				rdAu.Read();
				idAut = rdAu.GetString(0);
				tipoV = "porMes";
				fecha = DateTime.Now.ToShortDateString();
				mesRKm = int.Parse(txMesKm.Text);
				mesDias = int.Parse(txMesDiaUs.Text);
				CO2 = (float)rdAu.GetDouble(1);
				NOx = (float)rdAu.GetDouble(2);
				rdAu.Close();
				mesKm = mesRKm * mesDias;
				totCO2 = CO2 * mesKm;
				totNOx = NOx * mesKm;
				cmdV = new SqlCommand(String.Format("INSERT INTO Viaje (tipo, fecha, emisionCO2, emisionNOx, idRegistro) VALUES ('{0}', '{1}', {2}, {3}, {4})", tipoV, fecha, totCO2, totNOx, idReg), con);
				res1 = cmdV.ExecuteNonQuery();
				cmdCV = new SqlCommand(String.Format("SELECT idViaje FROM Viaje WHERE @@ROWCOUNT > 0 AND idViaje = SCOPE_IDENTITY()"), con);
				SqlDataReader rd1 = cmdCV.ExecuteReader();
				rd1.Read();
				int idViaj = rd1.GetInt32(0);
				rd1.Close();
				cmdT = new SqlCommand(String.Format("INSERT INTO porMes (idViaje, kmPorDia, numDiasConAuto) VALUES ({0}, {1}, {2})", idViaj, mesRKm, mesDias), con);
				res2 = cmdT.ExecuteNonQuery();
				if (res1 > 0 & res2 > 0)
				{
					float totCO2S, totNOxS, totSumCO2, totSumNOx;
					int resAct = 0;

					SqlCommand cmdTot = new SqlCommand(String.Format("SELECT emisionesCO2Tot, emisionesNOxTot FROM Registro WHERE idRegistro = {0}", idReg), con);
					SqlDataReader rdTot = cmdTot.ExecuteReader();
					rdTot.Read();
					totCO2S = (float)rdTot.GetDouble(0);
					totSumCO2 = totCO2 + totCO2S;
					totNOxS = (float)rdTot.GetDouble(1);
					totSumNOx = totNOx + totNOxS;
					rdTot.Close();
					SqlCommand act = new SqlCommand(String.Format("UPDATE Registro SET emisionesCO2Tot = {0}, emisionesNOxTot = {1} WHERE idRegistro = {2}", totSumCO2, totSumNOx, idReg), con);
					resAct = act.ExecuteNonQuery();
					if (resAct > 0)
						lbMes.Text = "Registro exitoso";
					else
						lbMes.Text = "Error en la actualizacion";
				}
				else
				{
					lbMes.Text = "Error en el registro";
				}
				con.Close();
			}
			catch (Exception ex)
			{
				lbExi.Text = "Error en la operacion";
			}
		}
    }
}