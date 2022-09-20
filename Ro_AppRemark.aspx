<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ro_AppRemark.aspx.cs" Inherits="Ro_AppRemark" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>RO_Remarks</title>
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
    <script language="javascript" src="javascript/ROapproval.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <%--<div style="position:absolute;word-wrap: break-word;zoom:150%">--%>
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td><asp:Label ID="Label1" runat="server" CssClass="TextField" Text="Remarks" style="font-size:x-large;"></asp:Label></td></tr>
                    
                    <tr>
                    <td><asp:TextBox id="lbremark" runat="server"   CssClass="btextmultiline" TextMode="MultiLine" MaxLength="500"></asp:TextBox></td></tr>
                  <tr><td>&nbsp;&nbsp;&nbsp;&nbsp;</td> </tr><tr align="right"><td><asp:Button id="btnSubmit" runat="server" Text="Submit" CssClass="topbutton" Width="63px" Font-Size="XX-Small"
							BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px" /></td>
				</tr>
            </table>
            <input type="hidden" runat="server" id="bookingid" />
            <input type="hidden" runat="server" id="appstatus" />
            <input type="hidden" runat="server" id="insertid" />
            <input id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server" />
        <%--</div>--%>
    </form>
</body>
</html>
