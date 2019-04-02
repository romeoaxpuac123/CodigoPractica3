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
    }
}