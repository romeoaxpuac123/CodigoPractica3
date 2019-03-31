<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Practica3.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>REGISTRO TU BANCO S.A.</title>
</head>
    <style type="text/css">
body {
 background-image: url(banco1.jpg);
	  background-position: center center;	  
	  background-repeat: no-repeat;
	background-attachment: fixed;
	background-size: cover;
}

#mail {
	width: 100%;
	position: fixed;
}
</style>
        <center><img src="texto2.png"></center>
     <form id="form1" runat="server">
        <div>
            <center>
             <table>
        <tr>
            <td>
               Codigo Usuario
            </td>
            <td>
                <asp:TextBox ID="txtCodigo"  
                runat="server" 
                required="true">Ingrese Su codigo</asp:TextBox>
            
            </td>
        </tr> <tr>
            <td>
                Usuario
            </td>
            <td>
                <asp:TextBox ID="txtUs" 
                runat="server" 
                required="true" >Ingrese Su Usuario</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
               Password 
            </td>
            <td>
             <asp:TextBox ID="txtPassword" 
             runat="server" 
             type="Password">Ingrese su Password</asp:TextBox>
            </td>
        </tr> 
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnLogin" 
                runat="server" Text="Ingresar" OnClick="btnSubmit_Click" />
            </td>
        </tr>



        
</table>
            </center>
        </div>

    <center>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Registrar" />
        <br />
        <br />
        <img src="login1.gif"></center>
    </form>

</body>
</html>
