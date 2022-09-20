<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testnew.aspx.cs" Inherits="testnew" %>
<%@ register TagPrefix="uc3" TagName="testcontrol" Src="~/billing/testcontrol.ascx"%>
<%@ register TagPrefix="uc3" TagName="punebillre" Src="~/billing/punebillre.ascx"%>
<%@ register TagPrefix="uc3" TagName="prhaarre" Src="~/billing/prhaarre.ascx"%>

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
					<td><asp:Button id="lblprint" Runat="server" OnClick="lblprint_Click" Visible ="false"  ></asp:Button><asp:placeholder id="placeholder1" Runat="server"></asp:placeholder></td>
				</tr>
			</table>
			<table >
			<tr>
				<td><input id="hiddendateformat" type="hidden" runat="server" /></td>
				<td><input id="hiddeninsertion" type="hidden" runat="server" /></td>
			</tr>
			</table>
			<div  id="printprogress" runat="server" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:0;">
			<asp:Label ID="printprog" runat ="server" Text ="Printing On Progress"></asp:Label>
 			
			
			
			</div>
		
		</form>
	</body>
</body>
</html>
