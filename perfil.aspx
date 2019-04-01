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
               <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="CONSULTAR SALDO" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
               <br />

           </center>
</form>

</html>
