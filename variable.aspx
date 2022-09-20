<%@ Page Language="C#" AutoEventWireup="true" CodeFile="variable.aspx.cs" Inherits="variable" %>

<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Variable Master</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<script type="text/javascript" language="javascript" src="javascript/variable.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/tree.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/TreeLibrary.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/permission.js"></script>
			<%-- <script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>--%>
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		
		<style type="text/css">.style1 { FONT-WEIGHT: bold; COLOR: #ffffff; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif }
	.style2 { COLOR: #ffffff }
		</style>
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<script type="text/javascript" language="javascript">	
		
	
	function uppercase()
		{
		document.getElementById('txtregioncode').value=document.getElementById('txtregioncode').value.toUpperCase();
		return ;
		}
		
		function uppercase2()
		{
		document.getElementById('txtalias').value=document.getElementById('txtalias').value.toUpperCase();
		return ;
		}
		
		
			
			function charval()
		{

	}
		
		</script>
</head>
<body leftmargin="0" topmargin="0"  id="bdy" onkeypress="return eventcalling(event);" onload="loadXML('xml/errorMessage.xml');return givebuttonpermission('region_master');" onkeydown="javascript:return tabvalue('txtalias');">
		<form id="Form1" method="post" runat="server">
			<table id="OuterTable" width="1000" align="center" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Variable Master"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top">
						<table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0">
							<tr valign="top">
								<td><asp:button id="btnNew" runat="server" CssClass="topbutton" Width="63px" Font-Size="XX-Small"
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
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px" ></asp:button>
								</td>
							</tr>
							<tr align="left" valign="top">
								<td>
									<table class="Popupbar" width="752" Height="23" cellspacing="0" cellpadding="0" border="0"
										style="WIDTH: 755px; HEIGHT: 23px">
										<tr>
											<td bgColor="#7daae3"></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td Height="25"></td>
							</tr>
							<tr>
								<td style="height: 83px">
									<table align="center" style="WIDTH: 602px; HEIGHT: 64px" cellspacing="0" cellpadding="0">
										<tr>
											<td><asp:label id="lbregioncode" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox id="txtregioncode" runat="server" CssClass="btext1" MaxLength="8"></asp:textbox></td>
										</tr>
										<tr>
											<td ><asp:label id="lbregionname" runat="server" CssClass="TextField"></asp:label></td>
											<td ><asp:textbox id="txtregionname" runat="server" CssClass="btext" MaxLength="30"></asp:textbox></td>
											<td ></td>
										</tr>
										<tr>
											<td><asp:label id="lbalias" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox id="txtalias" runat="server" CssClass="btext"  MaxLength="30"></asp:textbox></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<input id="hiddenuserid" type="hidden" runat="server" size="1" name="hiddenuserid" />
			<input id="hiddencompanycode" type="hidden" size="1" name="Hidden1" runat="server"/>
			<input id="hiddencompcode" type="hidden" size="1" name="hiddencompcode" runat="server"/>
			<input id="hiddenusername" type="hidden" size="1" name="hiddenusername" runat="server" />
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
		
		</form>
	</body>
</html>
