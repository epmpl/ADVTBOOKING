<%@ Page Language="C#" AutoEventWireup="true" CodeFile="invoice.aspx.cs" Inherits="invoice" %>
<%@ register TagPrefix="uc3" TagName="billing" Src="~/billing.ascx"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Invoice</title>
</head>
<body>
   	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table style="WIDTH: 245px; HEIGHT: 48px">
				<tr>
				</tr>
				<tr>
					<td><asp:label id="lblprint" Runat="server"></asp:label><asp:placeholder id="placeholder1" Runat="server"></asp:placeholder></td>
				</tr>
			</table>
		</form>
	</body>
</body>
</html>
