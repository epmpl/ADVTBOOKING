<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AgencySubCategoryMaster.aspx.cs" Inherits="AgencySubCategoryMaster" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx"%>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>Display Ad. Booking & Sheduling Agency Sub Category Master</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		<script type="text/javascript" language="javascript" src="javascript/AgencySubCategoryMaster.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/permission.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/tree.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/treeLibrary.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/Validations.js"></script>
			<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
	</head>
	<body   id="bdy" onload="loadXML('xml/errorMessage.xml'); return givebuttonpermission('AgencySubCategoryMaster');"  onkeydown="javascript:return tabvalue('txtalias');" <%--onkeydown="if(event.keyCode==13){event.keyCode=9;return event.keyCode;}"--%> 
	onkeypress="eventcalling(event);">
		<form id="Form1" method="post" runat="server">
			<table id="OuterTable" width="1000" align="center" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Agency Sub Category Master" ></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top">
						<table cellspacing="0" cellpadding="0" border="0" id="RightTable" class="RightTable">
							<tr valign="top">
								<td><asp:button id="btnNew" runat="server" CssClass="topbutton" Width="63px" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="true" Height="24px"></asp:button><asp:button id="btnSave" runat="server" Width="63px" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="true" Height="24px"></asp:button><asp:button id="btnModify" runat="server" Width="63px" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="true" Height="24px"></asp:button><asp:button id="btnQuery" runat="server" Width="63px" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="true" Height="24px"></asp:button><asp:button id="btnExecute" runat="server" Width="63px" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="true" Height="24px"></asp:button><asp:button id="btnCancel" runat="server" Width="63px" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="true" Height="24px"></asp:button><asp:button id="btnfirst" runat="server" Width="62px" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="true" Height="24px"></asp:button><asp:button id="btnprevious" runat="server" Width="63px" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="true" Height="24px"></asp:button><asp:button id="btnnext" runat="server" Width="63px" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="true" Height="24px"></asp:button><asp:button id="btnlast" runat="server" Width="63px" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="true" Height="24px"></asp:button><asp:button id="btnDelete" runat="server" Width="63px" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="true" Height="24px"></asp:button><asp:button id="btnExit" runat="server" Width="63px" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="true" Height="24px"></asp:button>
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
									<table align="center" cellpadding="0" cellspacing="0" border="0">
										<tr>
											<td><asp:label id="AgencyType" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:dropdownlist id="drpagencytype" runat="server" CssClass="dropdown"></asp:dropdownlist></td>
										</tr>
										<tr>
											<td><asp:label id="AgencyCategory" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:dropdownlist id="drpagencycat" runat="server" CssClass="dropdown">
                                                <asp:ListItem Value="0">---Select Agency Category--</asp:ListItem>
                                            </asp:dropdownlist></td>
										</tr>
										<tr>
											<td><asp:label id="AgencySubCategoryCode" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox onkeypress="return ClientSpecialchar();" id="txtasccode" runat="server" CssClass="btext1"
													MaxLength="12"></asp:textbox></td>
										</tr>
										<tr>
											<td><asp:label id="AgencySubCategoryName" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox onkeypress="return ClientSpecialchar();" id="txtascname" runat="server" CssClass="btext"
													MaxLength="30"></asp:textbox></td>
										</tr>
										<tr>
											<td style="height: 19px"><asp:label id="Alias" runat="server" CssClass="TextField"></asp:label></td>
											<td style="height: 19px"><asp:textbox onkeypress="return ClientSpecialchar();" id="txtalias" runat="server" CssClass="btext"
													MaxLength="10"></asp:textbox></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<input id="hiddencomcode" type="hidden" size="1" name="hiddencomcode" runat="server"/>
			<input id="hiddencatcode" type="hidden" size="1" name="Hidden2" runat="server"/> <input id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server"/>
			<input id="hiddenDateFormat" type="hidden" size="1" name="Hidden2" runat="server"/>
			<input id="hiddenusername" type="hidden" size="1" name="Hidden2" runat="server"/>
			<input id="hiddencompcode" type="hidden" runat="server" name="hiddencompcode"/>
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
		
		</form>
	</body>
</html>
