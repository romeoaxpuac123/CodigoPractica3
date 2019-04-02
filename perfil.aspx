<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="perfil.aspx.cs" Inherits="Practica3.perfil" %>

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
        <form id="form1" runat="server">
        <center><img src="texto2.png"></center>
   

</body>
           <center> 
               <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

               <br />
               <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
               <br />
               <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
               <br />
               <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
               <br />
               <br />
               <br />
               <center><img src="saldo.png" style="height: 61px; width: 469px"></center>
               <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="CONSULTAR SALDO" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
               <br />
               <br />
               <br />
                <center><img src="banck.png" style="height: 61px; width: 508px"></center>

           
               Numero De Cuenta a Transferir
               <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
               <br />
               Monto a Transferir:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
               <br />
               <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="TRANSFERIR" />



               <center><img src="solicitud.png" style="height: 61px; width: 469px"><br />
                   <asp:Label ID="Label6" runat="server">Numero de Cuenta</asp:Label>
                   <asp:TextBox ID="TextBox3" runat="server" ></asp:TextBox>
                   <br />
                   <asp:Label ID="Label7" runat="server" Text="Monto"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                   <br />
                   <asp:Label ID="Label8" runat="server" Text="Descripcion"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                   <br />
                   <asp:Button ID="Button3" runat="server" Text="Solicitar Credito" OnClick="Button3_Click" />
               </center>

               </center>
</form>

</html>
