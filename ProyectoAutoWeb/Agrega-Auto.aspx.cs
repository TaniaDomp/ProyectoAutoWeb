using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAutoWeb
{
    public partial class Agrega_Auto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btRegistro_Click(object sender, EventArgs e)
        {
            String marca, submarca, idAut;
            int anioM, anAnti, res1, res2, idUsu;
            float emCO2T;
            SqlCommand cmd, cmd1, cmd2, relUsReg;

            idUsu = int.Parse(Session["idUsu"].ToString());
            SqlConnection con = Conexion.agregarConexion();
            marca = txMarca.Text;
            submarca = txSubmarca.Text;
            anioM = int.Parse(txAnio.Text);
            anAnti = int.Parse(txAnioA.Text);

            cmd = new SqlCommand(String.Format("SELECT idAut, emisionCO2, emisionNOx, emisionAnualCO2 FROM Automovil WHERE marca LIKE '{0}' AND submarca LIKE '{1}' AND AnioModelo = {2} AND emisionCO2 IS NOT NULL AND emisionNOx IS NOT NULL AND emisionAnualCO2 IS NOT NULL", marca, submarca, anioM), con);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                rd.Read();
                idAut = rd.GetString(0);
                emCO2T = (float)rd.GetDouble(3);
                //checar problemas con el cast
                rd.Close();
                cmd1 = new SqlCommand(String.Format("INSERT INTO Registro (emisionesCO2Tot, aniosAntiguedad, idAut) VALUES ({0}, {1}, '{2}')", emCO2T, anAnti, idAut), con);
                res1 = cmd1.ExecuteNonQuery();
                cmd2 = new SqlCommand(String.Format("SELECT idRegistro FROM Registro WHERE @@ROWCOUNT > 0 AND idRegistro = SCOPE_IDENTITY()"), con);
                SqlDataReader rd1 = cmd2.ExecuteReader();
                rd1.Read();
                int idReg = rd1.GetInt32(0);
                rd1.Close();
                relUsReg = new SqlCommand(String.Format("INSERT INTO RegistroUsuario (idUsu, idRegistro) VALUES ({0}, {1})", idUsu, idReg), con);
                res2 = relUsReg.ExecuteNonQuery();
                if (res1 > 0 & res2 > 0)
                {
                    lbReg.Text = "Registro exitoso";
                }
                else
                {
                    lbReg.Text = "Error en la operacion";
                }
                con.Close();
            }
            else
            {
                lbReg.Text = "Modelo no dado de alta";
            }

        }

        protected void btIngre_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = Conexion.agregarConexion();
                SqlCommand cmd;
                String marca, submarca, idAut;
                int anioMod, res;

                marca = txRMarca.Text;
                submarca = txRSub.Text;
                anioMod = int.Parse(txRAM.Text);
                idAut = marca.Substring(0, 3) + "-" + submarca + "-" + anioMod;
                cmd = new SqlCommand(String.Format("INSERT INTO Automovil (idAut, marca, submarca, anioModelo) VALUES ('{0}', '{1}', '{2}', {3})", idAut, marca, submarca, anioMod), con);
                res = cmd.ExecuteNonQuery();
                if (res > 0)
                {
                    lbIng.Text = "Solicitud exitosa";
                }
                else
                {
                    lbIng.Text = "Error en la operacion";
                }
                con.Close();
            }
            catch(Exception ex)
            {
                lbIng.Text = "Error en la operacion";
            }
        }
    }
}