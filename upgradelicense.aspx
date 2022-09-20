<%@ Page Language="C#" AutoEventWireup="true" CodeFile="upgradelicense.aspx.cs" Inherits="upgradelicense" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="css/main.css" type="text/css" rel="stylesheet"/>
<script language="javascript" type="text/javascript" src="javascript/upgradelicense.js"></script>
    <title>Upgrade License</title>
</head>
<body onload="document.getElementById('txtkeyno').focus();">
    <form id="form1" runat="server">
   <table id="OuterTable" width="1000" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Upgrade License"></uc1:topbar></td>
				</tr>
				
			</table>
			<table border="0" cellpadding="0" cellspacing="0" width=100% style="width:auto;margin:15px 40px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Upgrade License</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
            <table align="center" cellspacing="0" cellpadding="0" style="width:auto;">
						<tr>
							<td style="HEIGHT: 10px"><asp:label id="lblkeyno" runat="server" CssClass="TextField" Text="Enter Key No."></asp:label></td>
							<td style="HEIGHT: 10px" ><asp:textbox  id="txtkeyno" runat="server" CssClass="btext"
									></asp:textbox></td>
						</tr>
						<tr><td></td><td align="right"><asp:Button ID="btnupgradelicense" CssClass="button1" runat="server" STYLE="width:100px" Text="Upgrade License" /><asp:Button ID="btnexit" CssClass="button1" style="width:100px" runat="server" Text="Exit" /></td></tr>
			</table>
			<input type="hidden" id="hiddencompname" runat="server" />
			<input type="hidden" id="hiddencompcode" runat="server" />
			<input type="hidden" id="hiddenuserid" runat="server" />
    </form>
</body>
</html>
