<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administrador.aspx.cs" Inherits="Practica3.Administrador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ADMINISTRADOR BANCO S.A.</title>
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
        <center><img src="ad.png"></center>
   

            <center>


                <center><img src="eldeposito.png" style="height: 61px; width: 408px"><br />
                    Numero De Cuenta
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                    <br />
                    Monto&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                    <br />
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="DEPOSITAR" />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />


                <center><img src="eldebito.png" style="height: 61px; width: 365px"><br />
                    <asp:Label ID="Label1" runat="server" Text="Numero de Cuenta"></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="                                                         Monto                  "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="Descripcion"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    <br />
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Debitar" />
                    <br />
                    <br />
                    <br />
                </center>
                    
                    
                   <img src="credito.png" style="height: 61px; width: 506px"><br />

           
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="codigo_credito" DataSourceID="SqlDataSource1" BackColor="#6699FF" BorderColor="#3333FF" ForeColor="#CCFFFF" ShowFooter="True" ShowHeaderWhenEmpty="True">
                <Columns>
                    <asp:BoundField DataField="codigo_credito" HeaderText="codigo_credito" InsertVisible="False" ReadOnly="True" SortExpression="codigo_credito" />
                    <asp:BoundField DataField="numero_de_cuenta" HeaderText="numero_de_cuenta" SortExpression="numero_de_cuenta" />
                    <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" />
                    <asp:BoundField DataField="monto" HeaderText="monto" SortExpression="monto" />
                    <asp:BoundField DataField="estado" HeaderText="estado" SortExpression="estado" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Practica3_AYD1ConnectionString %>" SelectCommand="SELECT * FROM [credito] WHERE ([estado] = @estado)">
                <SelectParameters>
                    <asp:Parameter DefaultValue="No Aprobado" Name="estado" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>

                     <asp:Label ID="Label4" runat="server" BackColor="Black" BorderColor="#CCFFFF" ForeColor="White" Text="Ingrese El Codigo de Credito para su aprobacion: "></asp:Label>
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                    <br />
                    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" style="height: 26px" Text="Aceptar Credito" />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />

                     </center>
</form>
</html>

