<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OpUsu.aspx.cs" Inherits="ProyectoAutoWeb.OpUsu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <nav class="menu">
            <lu><a href="OpUsu.aspx">Inicio</a></lu>
            <lu><a href="Agrega-Viaje.aspx">Agregar viaje</a></lu>
            <lu><a href="Agrega-Auto.aspx">Agregar auto</a></lu>
            <lu><a href="Auto-compartido.aspx">Auto compartido</a></lu>
            <lu><a href="Perfil.aspx">Perfil</a></lu>
            </nav>
            <br />
            Información de autos registrados:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />
            &nbsp;&nbsp;&nbsp;
            <br />
            <asp:GridView ID="gvDatos" runat="server">
            </asp:GridView>
            <br />
            <br />
            Producción total de CO2:&nbsp;
            <asp:Label ID="txCalCO2" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btCCO2" runat="server" Text="Calcular" OnClick="btCCO2_Click" />
            <br />
            <br />
            Producción total de NOx:&nbsp;
            <asp:Label ID="txCalNOx" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btCNOx" runat="server" Text="Calcular" OnClick="btCNOx_Click" />
            <br />
            <br />
            <br />
            <asp:Button ID="btSalir" runat="server" Height="37px" Text="Salir" Width="122px" />
            <br />
            <br />
            




        </div>
    </form>
</body>
</html>
