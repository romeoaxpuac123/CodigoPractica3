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
        int ElNumerodeCuenta = 0;
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
                Session["Codigo_Cuenta"] = cuenta;

                Label1.Text = "Codigo Usuario " + Session["Codigo_Usuario"].ToString();
                Label2.Text = "Usuario " + Usuario;
                Label3.Text = "Nombre Usuario " + Nombre_Usuario;
                Label4.Text = "Numero Cuenta " + cuenta;
                ElNumerodeCuenta = cuenta;
                TextBox3.Text = Convert.ToString(cuenta);
                TextBox3.ReadOnly = true;

                ///elaborando el gridview
               
                ///

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

        protected void Button2_Click(object sender, EventArgs e)
        {
            decimal ElSaldo = 0;
            
            ///Obteniendo Saldo de la Cuenta
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

            //Verificando Fondos

            if (SALDO < Convert.ToDecimal(TextBox2.Text))
            {
                MessageBox.Show("Saldo Insuficiente para Realizar la Transaccion");
                TextBox1.Text = "";
                TextBox2.Text = "";
            }
            else {
                ///Realizando Operacion 
                ///
                SqlConnection conxx = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
                conxx.Open();
                SqlCommand comxx = new SqlCommand(); // Create a object of SqlCommand class
                comxx.Connection = conxx; //Pass the connection object to Command
                comxx.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
                comxx.CommandText = "ExistenciaDeCuenta"; //Stored Procedure Name
                comxx.Parameters.Add("@numerodecuenta", SqlDbType.NVarChar).Value = TextBox1.Text;
                comxx.ExecuteNonQuery();
                int cuenta1 = 0;
                SqlDataReader readerxx = comxx.ExecuteReader();
                if (readerxx.HasRows)
                {
                    while (readerxx.Read())
                    {
                        cuenta1 = readerxx.GetInt32(0);
                        ElSaldo = readerxx.GetDecimal(2);
                        break;
                    }
                }
                //Existencia de Cuenta
                if (cuenta1 > 0)
                {
                    ///Realizando Cambios a la Cuenta donde se transfiere el dinero
                    SqlConnection conxa = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
                    conxa.Open();
                    SqlCommand comxa = new SqlCommand(); // Create a object of SqlCommand class
                    comxa.Connection = conxa; //Pass the connection object to Command
                    comxa.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
                    comxa.CommandText = "VerSaldo"; //Stored Procedure Name
                    comxa.Parameters.Add("@codigo_usuario", SqlDbType.NVarChar).Value = Session["Codigo_Usuario"].ToString();
                    comxa.ExecuteNonQuery();
                    decimal SALDOa = 0;
                    SqlDataReader readerxa = comxa.ExecuteReader();
                    if (readerxa.HasRows)
                    {
                        while (readerxa.Read())
                        {
                            SALDOa = readerxa.GetDecimal(0);
                            break;
                        }
                    }
                    SALDOa = SALDOa - Convert.ToDecimal(TextBox2.Text);
                    SqlConnection conxaA = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
                    conxaA.Open();
                    SqlCommand comxaA = new SqlCommand(); // Create a object of SqlCommand class
                    comxaA.Connection = conxaA; //Pass the connection object to Command
                    comxaA.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
                    comxaA.CommandText = "ModificarSaldo"; //Stored Procedure Name
                    comxaA.Parameters.Add("@saldox", SqlDbType.NVarChar).Value = SALDOa;
                    comxaA.Parameters.Add("@codigo_usuario", SqlDbType.NVarChar).Value = Session["Codigo_Usuario"].ToString();
                    comxaA.ExecuteNonQuery();
                    ///modificando saldo en cuenta 2
                    ///SALDOa = SALDOa - Convert.ToDecimal(TextBox2.Text);
                    SqlConnection conxaAy = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
                    conxaAy.Open();
                    SqlCommand comxaAy = new SqlCommand(); // Create a object of SqlCommand class
                    comxaAy.Connection = conxaAy; //Pass the connection object to Command
                    comxaAy.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
                    comxaAy.CommandText = "ModificarSaldo2"; //Stored Procedure Name
                    comxaAy.Parameters.Add("@saldox", SqlDbType.NVarChar).Value = ElSaldo + Convert.ToDecimal(TextBox2.Text);
                    comxaAy.Parameters.Add("@codigo_Cuenta", SqlDbType.NVarChar).Value = TextBox1.Text;
                    comxaAy.ExecuteNonQuery();


                 


                    SqlConnection conxaAyx = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
                    conxaAyx.Open();
                    SqlCommand comxaAyx = new SqlCommand(); // Create a object of SqlCommand class
                    comxaAyx.Connection = conxaAyx; //Pass the connection object to Command
                    comxaAyx.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
                    comxaAyx.CommandText = "AgregarTrasnferencia"; //Stored Procedure Name
                    comxaAyx.Parameters.Add("@numero_de_cuenta", SqlDbType.NVarChar).Value = ElNumerodeCuenta;
                    comxaAyx.Parameters.Add("@cuenta_a_transferir", SqlDbType.NVarChar).Value = Convert.ToInt32(TextBox1.Text);
                    comxaAyx.Parameters.Add("@monto", SqlDbType.NVarChar).Value = TextBox2.Text;
                    comxaAyx.Parameters.Add("@fecha", SqlDbType.NVarChar).Value = DateTime.Now;
                    comxaAyx.ExecuteNonQuery();

                    MessageBox.Show("Transaccion Realizada Con exito");


                    Label5.Text = "Q. " + SALDOa;

                    TextBox1.Text = "";
                    TextBox2.Text = "";
                }
                else
                {
                    MessageBox.Show("Cuenta Inexistente");
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                }


            }


            GridView1.DataBind();
            GridView2.DataBind();
            GridView3.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            if (Convert.ToDecimal(TextBox4.Text) > 0)
            {
                SqlConnection conxa = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
                conxa.Open();
                SqlCommand comxa = new SqlCommand(); // Create a object of SqlCommand class
                comxa.Connection = conxa; //Pass the connection object to Command
                comxa.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
                comxa.CommandText = "SolicitudDeCretido"; //Stored Procedure Name
                comxa.Parameters.Add("@cuenta", SqlDbType.NVarChar).Value = Convert.ToInt32(TextBox3.Text);
                comxa.Parameters.Add("@descripcion", SqlDbType.NVarChar).Value = TextBox5.Text;
                comxa.Parameters.Add("@monto", SqlDbType.NVarChar).Value = Convert.ToDecimal(TextBox4.Text);

                comxa.ExecuteNonQuery();
                MessageBox.Show("Credito Solicitado");
                TextBox1.Text = "";
                TextBox2.Text = "";
                //TextBox3.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
            }
            else
            {
                MessageBox.Show("SOLICITUD DENEGADA");
                TextBox1.Text = "";
                TextBox2.Text = "";
                //TextBox3.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
            }
            GridView1.DataBind();
            GridView2.DataBind();
            GridView3.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Session["Codigo_Usuario"] = "";
            Response.Redirect("Login.aspx", false);
            Response.Cookies.Clear();
        }
    }
}