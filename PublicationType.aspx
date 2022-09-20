<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PublicationType.aspx.cs" Inherits="PublicationType" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>Publication Type Master</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		<script type="text/javascript"language="javascript" src="javascript/PublicationType.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/permission.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/tree.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/TreeLibrary.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<script type="text/javascript" language="javascript" >
	

function ClientSpecialcharname(event)
{
if(browser!="Microsoft Internet Explorer")
 {
 if((event.which>=48 && event.which<=57)||(event.which==8)||(event.which==189)||(event.which>=97 && event.which<=122)||(event.which==9 || event.which==32)||(event.which>=65 && event.which<=90)||(event.which==92))
	{
		return true;
	}
	else
	{
		return false;
	}
 }
 else
 {
	if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==8)||(event.keyCode==189)||(event.keyCode>=97 && event.keyCode<=122)||(event.keyCode==9 || event.keyCode==32)||(event.keyCode>=65 && event.keyCode<=90)||(event.keyCode==92))
	{
		return true;
	}
	else
	{
		return false;
	}
 }
}
function ClientSpecialcharnamen(event)
{
if(browser!="Microsoft Internet Explorer")
 {
 if((event.which>=46 && event.which<=57)||(event.which==38)||(event.which==8)||(event.which==189)||(event.which>=97 && event.which<=122)||(event.which==9 || event.which==32)||(event.which>=65 && event.which<=90)||(event.which==44)||(event.which==45)||(event.which==46)||(event.which==47)||(event.which==92))
	{
		return true;
	}
	else
	{
		return false;
	}
 }
 else
 {
	if((event.keyCode>=46 && event.keyCode<=57)||(event.keyCode==38)||(event.keyCode==8)||(event.keyCode==189)||(event.keyCode>=97 && event.keyCode<=122)||(event.keyCode==9 || event.keyCode==32)||(event.keyCode>=65 && event.keyCode<=90)||(event.keyCode==44)||(event.keyCode==45)||(event.keyCode==46)||(event.keyCode==47)||(event.keyCode==92))
	{
		return true;
	}
	else
	{
		return false;
	}
  }	
}
	
</script>

	</head>
	<body leftMargin="5" topmargin="0"  onload="loadXML('xml/errorMessage.xml');document.getElementById('btnNew').focus();javascript:return givebuttonpermission('PublicationType');" id="bdy" onkeydown="tabvalue(event,'txtAlias');"  onkeypress="eventcalling(event); chkfield(event);"  style="background-color:#f3f6fd;" > <%--  onkeydown="if(event.keyCode==13){event.keyCode=9;return event.keyCode;}"--%>
	
	
		<form id="Form1" method="post" runat="server">
			<table id="OuterTable" width="1000" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Publication Type Master"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 796px">
						<table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0">
							<tr valign="top">
								<td><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"  onclick="btnNew_Click"></asp:ImageButton><asp:ImageButton id="btnSave" runat="server" CssClass="topbutton" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnModify" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnQuery" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnExecute" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnCancel" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnfirst" CssClass="topbutton" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnprevious" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnnext" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnlast" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnDelete" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnExit" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<table border="0" cellpadding="0" cellspacing="0" width="100%" style="width:auto;margin:15px 40px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Publication Type</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			<table align="center" border="0" cellpadding="0" cellspacing="0" style="width:100%;margin:40px 200px;">
				<tr>
					<td style="width: 140px"><asp:Label id="lblpubtypeCode" runat="server" CssClass="TextField"></asp:Label>&nbsp;</td>
					<td><asp:TextBox onkeypress="return ClientSpecialcharname(event);" id="txtpubtypecode"  MaxLength="8" runat="server" CssClass="btext1"></asp:TextBox></td>
		`		</tr>
				<tr>
					<td style="width: 140px"><asp:Label id="lbpubtypename" runat="server" CssClass="TextField"></asp:Label></td>
					<td><asp:TextBox onkeypress="return ClientSpecialcharnamen(event);" id="txtpubtypename" runat="server" CssClass="btext" MaxLength="50"></asp:TextBox></td>
				</tr>
				<tr>
					<td style="width: 140px"><asp:Label id="lbAlias" runat="server" CssClass="TextField"></asp:Label></td>
					<td><asp:TextBox onkeypress="return ClientSpecialcharnamen(event);" id="txtAlias" runat="server" CssClass="btext" MaxLength="50"></asp:TextBox></td>
				</tr>
		   </table>
			<input id="hiddencompcode" type="hidden" size="1" name="hiddenregion" runat="server"/>
			<input id="hiddenuserid" type="hidden" size="1" name="hiddenregion" runat="server"/>
			<input id="dateformat" type="hidden" size="1" name="hiddenregion" runat="server"/>
			<input id="hiddendateformat" type="hidden" size="1" name="hiddenregion" runat="server"/>
			<input id="hiddenusername" runat="server" type="hidden" size="1" name="hiddenusername" />
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server"/>
			<input id="ip1" type="hidden" name="ip1" runat="server" />
		</form>
	</body>
</html>

