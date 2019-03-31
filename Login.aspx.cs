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
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Codigo_Usuario"] = txtCodigo.Text;
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            char[] Validos = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K'
            ,'L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z' };

            char[] Validos2 = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k'
            ,'l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};

            char[] Validos3 = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            int v1 = 0;
            int v2 = 0;

            string codigo = txtCodigo.Text;
            string password = txtPassword.Text;
            string usuario = txtUs.Text;

            for (int i = 0; i < Validos.Length; i++)
            {
                if (codigo.Contains(Validos[i]))
                {
                    v1 = v1 + 1;
                }

            }

            for (int i = 0; i < Validos2.Length; i++)
            {
                if (codigo.Contains(Validos2[i]))
                {
                    v1 = v1 + 1;
                }

            }

            for (int i = 0; i < Validos3.Length; i++)
            {
                if (codigo.Contains(Validos3[i]))
                {
                    v2 = v2 + 1;
                }

            }
            //Para login

            if (v1 > 0)
            {
                MessageBox.Show("Datos Incorrectos, Intentelo de Nuevo");
            }
            else {
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
                con.Open();
                SqlCommand com = new SqlCommand(); // Create a object of SqlCommand class
                com.Connection = con; //Pass the connection object to Command
                com.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
                com.CommandText = "Login"; //Stored Procedure Name
                com.Parameters.Add("@codigo_usuario", SqlDbType.NVarChar).Value = codigo;
                com.Parameters.Add("@usuario", SqlDbType.NVarChar).Value = usuario;
                com.Parameters.Add("@password", SqlDbType.NVarChar).Value = password;
                com.ExecuteNonQuery();
                int codigo1 = 0;
                String Usuario = "";
                String Passwordo = "";
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        codigo1 = reader.GetInt32(0);
                        Usuario = reader.GetString(1);
                        Passwordo = reader.GetString(2);
                        break;
                    }
                }

                if (codigo1 != 0 && Usuario.Length > 0 && Passwordo.Length > 0)
                {
                    MessageBox.Show("Bienvenido " + Usuario);
                    Response.Redirect("perfil.aspx");
                    txtCodigo.Text = "";
                    txtPassword.Text = "";
                    txtUs.Text = "";


                }
                else
                {
                    MessageBox.Show("Datos Incorrectos, Intentelo de Nuevo");
                }
            }

            
            ///MessageBox.Show("Codigo Usuario " + codigo1 + " Usuario " + Usuario + " Pass " + Passwordo);


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //pararegistrar
            
            
            Response.Redirect("Registro.aspx");
        }

    }
}