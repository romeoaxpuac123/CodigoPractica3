using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practica3
{
    public partial class perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Text = Session["Codigo_Usuario"].ToString();
        }
        

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}