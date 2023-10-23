<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Agrega-Viaje.aspx.cs" Inherits="ProyectoAutoWeb.Agrega_Viaje" %>

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
            Registra los datos de tus trayectos:<br />
            <br />
            Tipo de Viaje:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddTipoViaje" runat="server" AutoPostBack="True">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lbDiaVelProm" runat="server" Text="Velocidad promedio: " Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txDiaVelP" runat="server" Visible="False"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:Label ID="lbDiaHorViaj" runat="server" Text="Horas viajadas: " Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txDiaHorViaj" runat="server" Visible="False"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lbSemVelProm" runat="server" Text="Velocidad promedio: " Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txSemVelProm" runat="server" Visible="False"></asp:TextBox>
&nbsp;
            <asp:Label ID="lbSemHoras" runat="server" Text="Horas promedio por día:" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txSemHoras" runat="server" Visible="False"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <asp:Label ID="lbSemDias" runat="server" Text="Número de días de uso: " Visible="False"></asp:Label>
            <asp:TextBox ID="txSemDias" runat="server" Visible="False"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lbMesKm" runat="server" Text="Kilometros promedio: " Visible="False"></asp:Label>
            <asp:TextBox ID="txMesKm" runat="server" Visible="False"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lbMesDiaUs" runat="server" Text="Número de días de uso: " Visible="False"></asp:Label>
            <asp:TextBox ID="txMesDiaUs" runat="server" Visible="False"></asp:TextBox>
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
