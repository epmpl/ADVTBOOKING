<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Pageparametermaster.aspx.cs" Inherits="Pageparametermaster" %>
<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew.ascx" %>  
<%@ Register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<HEAD>
		<title>Display Ad. Booking & Sheduling Page Parameter Master</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="css/main.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="javascript/pageparameter.js"></script>
		
			<script type="text/javascript" language="javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/TreeLibrary.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/tree.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/permission.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		<script language="javascript">
		function uppercase(a)
		{
		
		document.getElementById(a).value=document.getElementById(a).value.toUpperCase();
		return ;
		
		}
function notchar2()
{
if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9))
{
return true;
}
else
{
return false;
}
}
function notchardec()
{
if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9)||(event.keyCode==46))
{
return true;
}
else
{
return false;
}
}


function notchar0()
{

if((event.keyCode>=48 && event.keyCode<=57)||
(event.keyCode==127)||(event.keyCode==37)||
(event.keyCode>=97 && event.keyCode<=122)||
(event.keyCode>=65 && event.keyCode<=90)||
(event.keyCode==9 || event.keyCode==32))
{
return true;
}
else
{
return false;
}
}
		
		</script>
	</HEAD>
	<body leftMargin="5" topmargin="0"   id="bdy" onkeypress="eventcalling(event);" onkeydown="javascript:return tabvalue('txtremarks')" onload="document.getElementById('btnNew').focus();javascript:return givebuttonpermission('Pageparametermaster');">
		<form id="Form1" method="post" runat="server">
			<table id="OuterTable" width="980" align="center" border="0" cellpadding="0" cellspacing="0">
			<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Page Parameter Master"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td vAlign="top">
						<table cellSpacing="0" cellPadding="0" border="0" id="RightTable" class="RightTable">
							<tr valign="top">
								<td style="height: 24px"><asp:button id="btnNew" runat="server" CssClass="topbutton" Width="63px" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px"></asp:button><asp:button id="btnSave" runat="server" Width="63px" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px"></asp:button><asp:button id="btnModify" runat="server" Width="63px" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px"></asp:button><asp:button id="btnQuery" runat="server" Width="63px" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px"></asp:button><asp:button id="btnExecute" runat="server" Width="63px" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px"></asp:button><asp:button id="btnCancel" runat="server" Width="63px" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px"></asp:button><asp:button id="btnfirst" runat="server" Width="62px" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px"></asp:button><asp:button id="btnprevious" runat="server" Width="63px" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px"></asp:button><asp:button id="btnnext" runat="server" Width="63px" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px"></asp:button><asp:button id="btnlast" runat="server" Width="63px" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px"></asp:button><asp:button id="btnDelete" runat="server" Width="63px" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px"></asp:button><asp:button id="btnExit" runat="server" Width="63px" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px"></asp:button>
								</td>
							</tr>
							<tr align="left" valign="top">
								<td>
									<table class="Popupbar" width="752" height="23" cellSpacing="0" cellPadding="0" border="0"
										style="WIDTH: 755px; HEIGHT: 23px">
										<tr>
											<td bgColor="#7daae3"></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td height="25"></td>
							</tr>
							<tr>
								<td>
									<table align="center" cellpadding="0" cellspacing="0" >
										<tr>
										    <td style="height: 23px"><asp:label id="PageParameterCode" runat="server" CssClass="TextField"></asp:label></td>
											<td style="height: 23px"><asp:textbox id="txtpagecode" onkeypress="return notchar0();" runat="server" CssClass="btext1"
													Enabled="False" MaxLength="8"></asp:textbox></td>
											<td style="height: 23px"><asp:label id="AdType" runat="server" CssClass="TextField"></asp:label></td>
											<td style="height: 23px"><asp:dropdownlist id="drpadvtype" runat="server" CssClass="dropdown" Enabled="False"></asp:dropdownlist></td>
											
										</tr>
										<tr>
											<td>
                                                <asp:Label ID="Publication" runat="server" CssClass="TextField"></asp:Label></td>
											<td><asp:dropdownlist id="drpPubName" runat="server" CssClass="dropdown">
                                            </asp:DropDownList></td>
											<td></td>
											<td></td>
										</tr>
										<tr>
											<td style="height: 19px"><asp:label id="Edition" runat="server" CssClass="TextField"></asp:label></td>
											<td colspan="3" style="height: 19px"><asp:dropdownlist id="drpedition" runat="server" CssClass="dropdown" Width="480px" Enabled="False">
                                                <asp:ListItem Value="0">---Select Edition---</asp:ListItem>
                                            </asp:dropdownlist></td>
											<td style="height: 19px"></td>
											<td style="height: 19px"></td>
										</tr>
										<tr>
											<td style="height: 19px"><asp:label id="AdCategory" runat="server" CssClass="TextField"></asp:label></td>
											<td colspan="3" rowspan="1" style="height: 19px"><asp:dropdownlist id="drpadvcategory" runat="server" CssClass="dropdown" Width="480px" Enabled="False"></asp:dropdownlist></td>
											<td style="height: 19px"></td>
											<td style="height: 19px"></td>
										</tr>
										<tr>
											<td><asp:label id="Color" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:dropdownlist id="drpcolor" runat="server" CssClass="dropdown" Enabled="False"></asp:dropdownlist></td>
											<td></td>
											<td></td>
										</tr>
										<tr>
											<td><asp:label id="PageNo" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox id="txtpageno" onkeypress="return notchar2();" runat="server" CssClass="btext1numeric"
													Enabled="False" MaxLength="4"></asp:textbox></td>
											<td><asp:label id="ColumnNo" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox id="txtcolno" onkeypress="return notchar2();" runat="server" CssClass="btext1numeric" Enabled="False"
													MaxLength="3"></asp:textbox></td>
										</tr>
										<tr>
											<td style="height: 21px"><asp:label id="AdMaxSize" runat="server" CssClass="TextField"></asp:label></td>
											<td style="height: 21px"><asp:textbox id="txtadvsize" onkeypress="return notchardec();" runat="server" CssClass="btext1numeric"
													Enabled="False" MaxLength="6"></asp:textbox></td>
											<td style="height: 21px"><asp:label id="UOM" runat="server" CssClass="TextField"></asp:label></td>
											<td style="height: 21px"><asp:dropdownlist id="drpuom" runat="server" CssClass="dropdown" Enabled="False"></asp:dropdownlist></td>
										</tr>
										<tr>
											<td><asp:label id="Remarks" runat="server" CssClass="TextField">Remarks</asp:label></td>
											<td colspan="3"><asp:textbox id="txtremarks" runat="server" CssClass="btext" Enabled="False" MaxLength="200"></asp:textbox></td>
											<td></td>
											<td></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<input id="hiddencompcode" type="hidden" runat="server" name="hiddencompcode"/> <input id="hiddenuserid" type="hidden" runat="server" name="hiddenuserid"/>
			<input id="hiddenusername" type="hidden" size="1" name="hiddenusername" runat="server" onserverchange="hiddenusername_ServerChange"/>
			 <input id="hiddenauto" type="hidden" name="hiddenregion" runat="server"/>
	
		</form>
	</body>
</html>
