<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bill_preview_print.aspx.cs" Inherits="billing_bill_preview_print" %>
<%@ register TagPrefix="uc3" TagName="RCB2" Src="~/billing/RCB2.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body oncopy="return false;" onpaste="return false;">
    <form id="form1" runat="server">
     <table style="WIDTH: 245px; HEIGHT: 48px">
				<tr>
				</tr>
				<tr>
					<td><asp:Button id="lblprint" Runat="server"  Visible ="false"  ></asp:Button><asp:placeholder id="placeholder1" Runat="server"></asp:placeholder></td>
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
</html>
