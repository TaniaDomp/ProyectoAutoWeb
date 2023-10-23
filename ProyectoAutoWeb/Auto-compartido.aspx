<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Auto-compartido.aspx.cs" Inherits="ProyectoAutoWeb.Auto_compartido" %>

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
            Si compartes tu auto con otro usuario puedes enlazar sus datos:<br />
            <br />
            Ingresa los datos:<br />
            <br />
            Clave del auto:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddIdAu" runat="server">
            </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Clave del usuario:
            <asp:TextBox ID="txClavUsu" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btReg" runat="server" Text="Registro" />
            <br />
            <br />
            <br />
            <br />

        </div>
    </form>
</body>
</html>
