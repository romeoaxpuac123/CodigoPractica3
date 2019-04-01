using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Practica3
{
    public partial class perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Codigo_Usuario"].ToString().Length == 0)
            {
                MessageBox.Show("Usuario Sin Permisos");
                Response.Redirect("Login.aspx");
            }
            else {
                Label5.Text = "";
                //Obteniendo nombre y usuario
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
                con.Open();
                SqlCommand com = new SqlCommand(); // Create a object of SqlCommand class
                com.Connection = con; //Pass the connection object to Command
                com.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
                com.CommandText = "VerUsuario"; //Stored Procedure Name
                com.Parameters.Add("@codigo_usuario", SqlDbType.NVarChar).Value = Session["Codigo_Usuario"].ToString();
                com.ExecuteNonQuery();
                String Usuario = "";
                String Nombre_Usuario = "";
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Nombre_Usuario = reader.GetString(0);
                        Usuario = reader.GetString(1);
                        break;
                    }
                }

                ///Obteniendo Numero de Cuenta
                ///
                SqlConnection conx = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
                conx.Open();
                SqlCommand comx = new SqlCommand(); // Create a object of SqlCommand class
                comx.Connection = conx; //Pass the connection object to Command
                comx.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
                comx.CommandText = "VerCuenta"; //Stored Procedure Name
                comx.Parameters.Add("@codigo_usuario", SqlDbType.NVarChar).Value = Session["Codigo_Usuario"].ToString();
                comx.ExecuteNonQuery();
                int cuenta = 0;
                SqlDataReader readerx = comx.ExecuteReader();
                if (readerx.HasRows)
                {
                    while (readerx.Read())
                    {
                        cuenta = readerx.GetInt32(0);
                        break;
                    }
                }


                Label1.Text = "Codigo Usuario " + Session["Codigo_Usuario"].ToString();
                Label2.Text = "Usuario " + Usuario;
                Label3.Text = "Nombre Usuario " + Nombre_Usuario;
                Label4.Text = "Numero Cuenta " + cuenta;
            }
           
        }
        

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conx = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
            conx.Open();
            SqlCommand comx = new SqlCommand(); // Create a object of SqlCommand class
            comx.Connection = conx; //Pass the connection object to Command
            comx.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comx.CommandText = "VerSaldo"; //Stored Procedure Name
            comx.Parameters.Add("@codigo_usuario", SqlDbType.NVarChar).Value = Session["Codigo_Usuario"].ToString();
            comx.ExecuteNonQuery();
            decimal SALDO = 0;
            SqlDataReader readerx = comx.ExecuteReader();
            if (readerx.HasRows)
            {
                while (readerx.Read())
                {
                    SALDO = readerx.GetDecimal(0);
                    break;
                }
            }


            Label5.Text = "Q. " + SALDO;

        }
    }
}