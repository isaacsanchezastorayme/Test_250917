<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LoggerFrm.aspx.cs" Inherits="BelatrixTest.UI.LoggerFrm" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Monitoreo - Belatrix Test
    </h2>
    <p>
        Ing. Isaac Sanchez Astorayme <!--<a href="http://www.nsr.edu" title="NSR Website">www.nsr.edu</a>.-->
    </p>   
    <table>
        <tr>
            <th>Estado de la conexión:&nbsp;</th>
            <td colspan="2"><asp:TextBox ID="txtConexion" runat ="server" Text ="No se logró conectar." Width="585px" ></asp:TextBox></td>
        </tr>
         <tr>
            <th>&nbsp</th>
            <td colspan="2">&nbsp</td>
        </tr>       
        <tr>
            <th>Logger to DataBase:&nbsp;</th>
            <td><asp:Button ID="btnLoggerDB" runat ="server" Text ="Clic para generar log" OnClick="btnLoggerDB_Click" ></asp:Button></td>
            <td><asp:TextBox ID="txtLoggerDBMessage" runat ="server" Text ="Ingrese texto para log" Width="400px" ></asp:TextBox></td>
        </tr>
        <tr>
            <th>&nbsp</th>
            <td colspan="2">&nbsp</td>
        </tr>      
        <tr>
            <th>Logger to Console:&nbsp;</th>
            <td><asp:Button ID="btnLoggerCommandPrompt" runat ="server" Text ="Clic para generar log" OnClick="btnLoggerConsole_Click" ></asp:Button></td>
            <td><asp:TextBox ID="txtLoggerConsoleMessage" runat ="server" Text ="Ingrese texto para log" Width="400px" ></asp:TextBox></td>
        </tr>
        <tr>
            <th>&nbsp</th>
            <td colspan="2">&nbsp</td>
        </tr>
        <tr>
            <th>Logger to a File in Disk:&nbsp;</th>
            <td><asp:Button ID="btnLoggerFileInDisk" runat ="server" Text ="Clic para generar log" OnClick="btnLoggerFileInDisk_Click" ></asp:Button></td>
            <td><asp:TextBox ID="txtLoggerFileInDisk" runat ="server" Text ="Ingrese texto para log" Width="400px" ></asp:TextBox></td>
        </tr>
    </table>
</asp:Content>