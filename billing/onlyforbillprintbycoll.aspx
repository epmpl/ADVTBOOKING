<%@ Page Language="C#" AutoEventWireup="true" CodeFile="onlyforbillprintbycoll.aspx.cs" Inherits="onlyforbillprintbycoll" %>
<%@ register TagPrefix="haribhoomi1" TagName="haribhoomi1" Src="~/billing/haribhoomi_display.ascx"%>
<%@ register TagPrefix="uc3" TagName="haribhoomi_billnew1" Src="haribhoomi_billnew1.ascx"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Invoice</title>
    
  </head>
<body>
  
		<form id="Form1"  runat="server">
			<%--<table valign="top" >
				<tr>
					<td valign="top"><asp:Button id="lblprint" Runat="server"  Visible ="false"  ></asp:Button>--%>
					<asp:placeholder id="placeholder1" Runat="server"></asp:placeholder></td>
				<%--</tr>
			</table>--%>
					</form>
	<input id="hiddendateformat" type="hidden" runat="server" />
				<input id="hiddeninsertion" type="hidden" runat="server" />
</body>
</html>
