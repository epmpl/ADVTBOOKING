<%@ Page Language="C#" AutoEventWireup="true" CodeFile="invoice_classified.aspx.cs" Inherits="invoice_classified" %>

<%@ register TagPrefix="uc3" TagName="billing_packageprahar" Src="~/billing/billing_classi.ascx"%>
<%@ register TagPrefix="uc3" TagName="punebillclassi" Src="~/billing/punebillclassi.ascx"%>
<%@ register TagPrefix="uc3" TagName="punebill" Src="~/billing/punebill.ascx"%>
<%@ register TagPrefix="uc3" TagName="prahhar_classified" Src="~/billing/prahhar_classified.ascx"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Classified Bill</title>
</head>
<body>
        <body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
		 <table width='100%' cellpadding="0" cellspacing="0" border="0" class='maindataa3'><tr><td align="right" id="pagging" runat="server" style="width:100%"></td><td style="width:2%"></td></tr>
	                        </table>
			<table style="WIDTH: 245px; HEIGHT: 48px">
				<tr>
				</tr>
				<tr>
					<td><asp:label id="lblprint" Runat="server"></asp:label><asp:placeholder id="placeholder1" Runat="server"></asp:placeholder></td>
				</tr>
			</table>
			<table >
			<tr>
				<td><input id="hiddendateformat" type="hidden" runat="server" /></td>
				<td><input id="hiddeninsertion" type="hidden" runat="server" /></td>
			</tr>
			</table>
			
			 <table cellpadding="0" cellspacing="0" style="width:100%" border="0">
	                       <tr><td><div id="bottom1" runat="server"><table cellpadding="0" cellspacing="0" style="width:100%">
	                         <tr><td style="width:100%;height:1px;background-color:#fedec8" align="center"></td></tr>             
	                          <tr><td style="width:100%;height:1px"></td></tr>
	                        <tr><td style="width:100%">
	                       
	                        </td></tr>
	                       </table></div></td></tr>
	                        
	                        <tr><td style="height:10px"></td></tr>
	                        <tr> <td valign="top" id="Myresult" runat="server" style="width:100%">
	                        </td></tr>
	                        <tr><td><div id="bottom2" runat="server"><table cellpadding="0" cellspacing="0" style="width:100%">
	                         <tr><td style="height:10px"></td></tr>
	                       <tr><td style="width:100%;height:1px;background-color:#fedec8" align="center"></td></tr>             
	                         <tr><td style="width:100%;height:1px"></td></tr>
	                         <tr><td style="width:100%">
	                        <table width='100%' cellpadding="0" cellspacing="0" border="0" class='maindataa3'><tr><td align="right" id="pagging1" runat="server" style="width:100%"></td><td style="width:2%"></td></tr>
	                        </table>
	                        </td></tr></table></div></td></tr>
	                        </table>
		
		</form>
	</body>
</body>
</html>
