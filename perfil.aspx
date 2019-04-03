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
               <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Cerrar Sesion" />
               <br />
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



               <br />
               <br />
               <br />



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
                   <br />
                   <br />
                   <asp:Label ID="Label9" runat="server" BackColor="Black" ForeColor="White" Text="TUS CREDITOS"></asp:Label>
                   <br />
                   <br />
                   <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="#6666FF" DataKeyNames="codigo_credito" DataSourceID="SqlDataSource1">
                       <Columns>
                           <asp:BoundField DataField="codigo_credito" HeaderText="codigo_credito" InsertVisible="False" ReadOnly="True" SortExpression="codigo_credito" />
                           <asp:BoundField DataField="numero_de_cuenta" HeaderText="numero_de_cuenta" SortExpression="numero_de_cuenta" />
                           <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" />
                           <asp:BoundField DataField="monto" HeaderText="monto" SortExpression="monto" />
                           <asp:BoundField DataField="estado" HeaderText="estado" SortExpression="estado" />
                       </Columns>
                   </asp:GridView>
                   <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Practica3_AYD1ConnectionString3 %>" SelectCommand="SELECT * FROM [credito] WHERE ([numero_de_cuenta] = @numero_de_cuenta)">
                       <SelectParameters>
                           <asp:SessionParameter Name="numero_de_cuenta" SessionField="Codigo_Cuenta" Type="Int32" />
                       </SelectParameters>
                   </asp:SqlDataSource>
                   <br />
                   <asp:Label ID="Label10" runat="server" BackColor="Black" ForeColor="White" Text="TUS DEBITOS"></asp:Label>
                   <br />
                   <br />
                   <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="#6600FF" DataSourceID="SqlDataSource2">
                       <Columns>
                           <asp:BoundField DataField="codigo_debito" HeaderText="codigo_debito" InsertVisible="False" ReadOnly="True" SortExpression="codigo_debito" />
                           <asp:BoundField DataField="numero_de_cuenta" HeaderText="numero_de_cuenta" SortExpression="numero_de_cuenta" />
                           <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" />
                           <asp:BoundField DataField="monto" HeaderText="monto" SortExpression="monto" />
                       </Columns>
                   </asp:GridView>
                   <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Practica3_AYD1ConnectionString3 %>" SelectCommand="SELECT * FROM [debito] WHERE ([numero_de_cuenta] = @numero_de_cuenta)">
                       <SelectParameters>
                           <asp:SessionParameter Name="numero_de_cuenta" SessionField="Codigo_Cuenta" Type="Int32" />
                       </SelectParameters>
                   </asp:SqlDataSource>
                   <br />
                   <br />
                   <asp:Label ID="Label11" runat="server" BackColor="Black" ForeColor="White" Text="TUS TRANSACCIONES"></asp:Label>
                   <br />
                   <br />
                   <asp:GridView ID="GridView3" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="#9933FF" DataKeyNames="codigo_transferencia" DataSourceID="SqlDataSource3">
                       <Columns>
                           <asp:BoundField DataField="codigo_transferencia" HeaderText="codigo_transferencia" InsertVisible="False" ReadOnly="True" SortExpression="codigo_transferencia" />
                           <asp:BoundField DataField="cuenta_a_transferir" HeaderText="cuenta_a_transferir" SortExpression="cuenta_a_transferir" />
                           <asp:BoundField DataField="monto" HeaderText="monto" SortExpression="monto" />
                           <asp:BoundField DataField="fecha" HeaderText="fecha" SortExpression="fecha" />
                       </Columns>
                   </asp:GridView>
                   <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Practica3_AYD1ConnectionString3 %>" SelectCommand="SELECT [codigo_transferencia], [cuenta_a_transferir], [monto], [fecha] FROM [transferencia] WHERE ([numero_de_cuenta] = @numero_de_cuenta)">
                       <SelectParameters>
                           <asp:SessionParameter Name="numero_de_cuenta" SessionField="Codigo_Cuenta" Type="Int32" />
                       </SelectParameters>
                   </asp:SqlDataSource>
                   <br />
               </center>

               </center>
</form>

</html>
