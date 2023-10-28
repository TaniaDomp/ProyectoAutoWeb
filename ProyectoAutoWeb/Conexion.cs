using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoAutoWeb
{
    public class Conexion
    {
        public static SqlConnection agregarConexion()
        {
            SqlConnection cnn;
            try
            {
                cnn = new SqlConnection("Data Source=LAPTOP-5V05KTCM;Initial Catalog=DBAutoProy;Integrated Security=True");
                cnn.Open();
            }
            catch (Exception ex)
            {
                cnn = null;
            }
            return cnn;
        }


    }
}