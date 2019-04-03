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
    public partial class Administrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conxx = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
            conxx.Open();
            SqlCommand comxx = new SqlCommand(); // Create a object of SqlCommand class
            comxx.Connection = conxx; //Pass the connection object to Command
            comxx.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comxx.CommandText = "ExistenciaDeCuenta"; //Stored Procedure Name
            comxx.Parameters.Add("@numerodecuenta", SqlDbType.NVarChar).Value = TextBox1.Text;
            comxx.ExecuteNonQuery();
            int cuenta1 = 0;
            decimal ElSaldo = 0;
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
                Debitar(Convert.ToInt32(TextBox1.Text), Convert.ToDecimal(TextBox2.Text), TextBox3.Text);
                ModificarSaldo(Debito(ElSaldo, Convert.ToDecimal(TextBox2.Text)), Convert.ToInt32(TextBox1.Text));
                MessageBox.Show("Saldo Debitado");
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
            }
            else
            {
                MessageBox.Show("Cuenta Inexistente");
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
            }
        }

        public decimal Debito(decimal Saldo, decimal descuento)
        {
            return Saldo - descuento; ;
        }
        public void Debitar(int cuenta, decimal saldo,String Descripcion)
        {
            SqlConnection conxxp = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
            conxxp.Open();
            SqlCommand comxxp = new SqlCommand(); // Create a object of SqlCommand class
            comxxp.Connection = conxxp; //Pass the connection object to Command
            comxxp.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comxxp.CommandText = "HacerDebito"; //Stored Procedure Name
            comxxp.Parameters.Add("@numero_de_Cuenta", SqlDbType.NVarChar).Value = cuenta;
            comxxp.Parameters.Add("@descripcion", SqlDbType.NVarChar).Value = Descripcion;
            comxxp.Parameters.Add("@monto", SqlDbType.NVarChar).Value = saldo;
            comxxp.ExecuteNonQuery();

        }

        public void ModificarSaldo(decimal saldo, int cuenta)
        {
            SqlConnection conxxp = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
            conxxp.Open();
            SqlCommand comxxp = new SqlCommand(); // Create a object of SqlCommand class
            comxxp.Connection = conxxp; //Pass the connection object to Command
            comxxp.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comxxp.CommandText = "ModificarSaldo2"; //Stored Procedure Name
            comxxp.Parameters.Add("@saldox", SqlDbType.NVarChar).Value = saldo;
            comxxp.Parameters.Add("@codigo_Cuenta", SqlDbType.NVarChar).Value = cuenta;
            comxxp.ExecuteNonQuery();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection conxx = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
            conxx.Open();
            SqlCommand comxx = new SqlCommand(); // Create a object of SqlCommand class
            comxx.Connection = conxx; //Pass the connection object to Command
            comxx.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comxx.CommandText = "ExistenciaDeCuenta"; //Stored Procedure Name
            comxx.Parameters.Add("@numerodecuenta", SqlDbType.NVarChar).Value = TextBox1.Text;
            comxx.ExecuteNonQuery();
            int cuenta1 = 0;
            decimal ElSaldo = 0;
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

                hacerdeposito(Convert.ToInt32(TextBox4.Text), depositar(ElSaldo, Convert.ToDecimal(TextBox5.Text)));
                MessageBox.Show("Monto Agregado a Cuenta");
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
            }
            else
            {
                MessageBox.Show("Cuenta Inexistente");
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
            }
        }

        public decimal depositar(decimal saldoActual, decimal MasSaldo)
        {

            return saldoActual + MasSaldo;
        }
        public void hacerdeposito(int cuenta,decimal saldo)
        {
            SqlConnection conxxp = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
            conxxp.Open();
            SqlCommand comxxp = new SqlCommand(); // Create a object of SqlCommand class
            comxxp.Connection = conxxp; //Pass the connection object to Command
            comxxp.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comxxp.CommandText = "ModificarSaldo2"; //Stored Procedure Name
            comxxp.Parameters.Add("@saldox", SqlDbType.NVarChar).Value = saldo;
            comxxp.Parameters.Add("@codigo_Cuenta", SqlDbType.NVarChar).Value = cuenta;
            comxxp.ExecuteNonQuery();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlConnection conxx = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
            conxx.Open();
            SqlCommand comxx = new SqlCommand(); // Create a object of SqlCommand class
            comxx.Connection = conxx; //Pass the connection object to Command
            comxx.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comxx.CommandText = "VerificarCredito"; //Stored Procedure Name
            comxx.Parameters.Add("@codigo", SqlDbType.NVarChar).Value = Convert.ToInt32(TextBox6.Text);
            comxx.ExecuteNonQuery();
            int cuenta1 = 0;
            int lacuenta= 0;
            decimal elmonto = 0;
            SqlDataReader readerxx = comxx.ExecuteReader();
            if (readerxx.HasRows)
            {
                while (readerxx.Read())
                {
                    cuenta1 = readerxx.GetInt32(0);
                    lacuenta = readerxx.GetInt32(1);
                    elmonto = readerxx.GetDecimal(3);
                    break;
                }
            }

            ///Si la cuenta Existe
            if (cuenta1>0)
            {
                //modificando el estado del credito
                

                ///añadiendo dinero a la cuenta del usuario
                ///
                SqlConnection conxxh = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
                conxxh.Open();
                SqlCommand comxxh = new SqlCommand(); // Create a object of SqlCommand class
                comxxh.Connection = conxxh; //Pass the connection object to Command
                comxxh.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
                comxxh.CommandText = "ExistenciaDeCuenta"; //Stored Procedure Name
                comxxh.Parameters.Add("@numerodecuenta", SqlDbType.NVarChar).Value = lacuenta;
                comxxh.ExecuteNonQuery();
                decimal ElSaldo = 0;
                SqlDataReader readerxxh = comxxh.ExecuteReader();
                if (readerxxh.HasRows)
                {
                    while (readerxxh.Read())
                    {
                        ElSaldo = readerxxh.GetDecimal(2);
                        break;
                    }
                }
                


                SqlConnection conxxq = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
                conxxq.Open();
                SqlCommand comxxq = new SqlCommand(); // Create a object of SqlCommand class
                comxxq.Connection = conxxq; //Pass the connection object to Command
                comxxq.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
                comxxq.CommandText = "AprobarCredito"; //Stored Procedure Name
                comxxq.Parameters.Add("@codigo", SqlDbType.NVarChar).Value = Convert.ToInt32(TextBox6.Text);
                comxxq.ExecuteNonQuery();

                ///Verificando si el credito no fue aprobado con ateriorirdad
                ///
                SqlConnection conxxhp = new SqlConnection("Data Source=.;Initial Catalog = Practica3_AYD1;Trusted_Connection=true;");
                conxxhp.Open();
                SqlCommand comxxhp = new SqlCommand(); // Create a object of SqlCommand class
                comxxhp.Connection = conxxhp; //Pass the connection object to Command
                comxxhp.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
                comxxhp.CommandText = "ESTADO"; //Stored Procedure Name
                comxxhp.Parameters.Add("@codigo", SqlDbType.NVarChar).Value = Convert.ToInt32(TextBox6.Text);
                comxxhp.ExecuteNonQuery();
                string Elestado = "";
                SqlDataReader readerxxhp = comxxhp.ExecuteReader();
                if (readerxxhp.HasRows)
                {
                    while (readerxxhp.Read())
                    {
                        Elestado = readerxxhp.GetString(0);
                        break;
                    }
                }

                if (Elestado == "Aprobado") {
                    MessageBox.Show("Credito  YA aprobado, no se puede aprobar nuevamente");
                }
                else
                {
                    MessageBox.Show("Credito  aprobado");
                    hacerdeposito(lacuenta, ElSaldo + elmonto);
                }
                
                TextBox6.Text = "";
                GridView1.DataBind();
            }
            else
            {
                MessageBox.Show("Error Credito No aprobado");
                TextBox6.Text = "";
            }
        }
    }
}