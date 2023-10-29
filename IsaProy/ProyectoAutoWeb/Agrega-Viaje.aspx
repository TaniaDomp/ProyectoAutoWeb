<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Agrega-Viaje.aspx.cs" Inherits="ProyectoAutoWeb.Agrega_Viaje" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        body {background-color:#3CB371;}
         h1{background-color:white;text-align:center;color:#3CB371}
    </style>
</head>
<body>
     <header>
     <h1>
         Redu-CO2
     </h1>
 </header>
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
            <b>Registra los datos de tus trayectos:<br />
            </b>
                <br />
            Tipo de Viaje:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddTipoViaje" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddTipoViaje_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            Clave del auto:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddIdAut" runat="server" AutoPostBack="True">
            </asp:DropDownList>
            <br />
            <a href="Agrega-Viaje.aspx">Agrega-Viaje.aspx</a><br />
            <asp:Label ID="lbDiaVelProm" runat="server" Text="Velocidad promedio: " Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txDiaVelP" runat="server" Visible="False"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:Label ID="lbDiaHorViaj" runat="server" Text="Horas viajadas: " Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txDiaHorViaj" runat="server" Visible="False"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btDia" runat="server" Text="Insertar" Visible="False" OnClick="btDia_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lbDias" runat="server" Visible="False"></asp:Label>
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
            <asp:Button ID="btSemana" runat="server" Text="Insertar" Visible="False" OnClick="btSemana_Click" />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lbSem" runat="server" Visible="False"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lbMesKm" runat="server" Text="Kilometros promedio: " Visible="False"></asp:Label>
            <asp:TextBox ID="txMesKm" runat="server" Visible="False"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lbMesDiaUs" runat="server" Text="Número de días de uso: " Visible="False"></asp:Label>
            <asp:TextBox ID="txMesDiaUs" runat="server" Visible="False"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btMes" runat="server" Text="Insertar" Visible="False" OnClick="btMes_Click" />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lbMes" runat="server" Visible="False"></asp:Label>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lbExi" runat="server"></asp:Label>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
