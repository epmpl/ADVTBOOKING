<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dayspopup.aspx.cs" Inherits="dayspopup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link href="css/booking.css" type="text/css" rel="stylesheet" />
      <link href="css/main.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
  <%--  <div>--%>
    <table id="Table5" style="WIDTH: 300px; HEIGHT: 32px" cellspacing="0" cellpadding="0" border="1">
    <tr valign="middle">
									<td align="center" bgColor="#7daae3"><asp:Label id="Label12" runat="server" CssClass="TextField">S</asp:Label></td>
									<td align="center" bgColor="#7daae3"><asp:Label id="Label13" runat="server" CssClass="TextField">M</asp:Label></td>
									<td align="center" bgColor="#7daae3"><asp:Label id="Label14" runat="server" CssClass="TextField">T</asp:Label></td>
									<td align="center" bgColor="#7daae3"><asp:Label id="Label15" runat="server" CssClass="TextField">W</asp:Label></td>
									<td align="center" bgColor="#7daae3"><asp:Label id="Label16" runat="server" CssClass="TextField">T</asp:Label></td>
									<td align="center" bgColor="#7daae3"><asp:Label id="Label17" runat="server" CssClass="TextField">F</asp:Label></td>
									<td align="center" bgColor="#7daae3"><asp:Label id="Label19" runat="server" CssClass="TextField">S</asp:Label></td>
									<td align="center" bgColor="#7daae3"><asp:Label id="Label18" runat="server" CssClass="TextField">A</asp:Label></td>
								</tr>
								<tr valign="middle">
									<td align="center"><asp:CheckBox id="CheckBox1" runat="server" CssClass="TextField"></asp:CheckBox></td>
									<td align="center"><asp:CheckBox id="CheckBox2" runat="server" CssClass="TextField"></asp:CheckBox></td>
									<td align="center"><asp:CheckBox id="CheckBox3" runat="server" CssClass="TextField"></asp:CheckBox></td>
									<td align="center"><asp:CheckBox id="CheckBox4" runat="server" CssClass="TextField"></asp:CheckBox></td>
									<td align="center"><asp:CheckBox id="CheckBox5" runat="server" CssClass="TextField"></asp:CheckBox></td>
									<td align="center"><asp:CheckBox id="CheckBox6" runat="server" CssClass="TextField"></asp:CheckBox></td>
									<td align="center"><asp:CheckBox id="CheckBox7" runat="server" CssClass="TextField"></asp:CheckBox></td>
									<td align="center"><asp:CheckBox id="CheckBox8" runat="server" CssClass="TextField"></asp:CheckBox></td>
								</tr></table>
                                    <table id="Table1" style="WIDTH: 100px; HEIGHT: 32px; margin-top:20px;" cellspacing="0" cellpadding="0" > <tr><asp:Button id="btnok" runat="server" CssClass="buttonshdul" Text="Ok"></asp:Button></tr></table>
   <%-- </div>--%>
    </form>
</body>
</html>
