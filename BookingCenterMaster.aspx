<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BookingCenterMaster.aspx.cs" Inherits="BookingCenterMaster" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Display Ad. Booking Center Master</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<script type="text/javascript"language="javascript" src="javascript/BookingCenterMaster.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/TreeLibrary.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/permission.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/Tree.js"></script>
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
	
</head>
<body leftMargin="5" bottomMargin="0"  topMargin="0" 
		id="bdy" rightMargin="0"  onkeydown="if(event.keyCode==13){event.keyCode=9;return event.keyCode;}" onkeypress="eventcalling(event);">
    <form id="form1" method="post" runat="server">
    <table id="OuterTable" cellspacing="0" cellpadding="0" width="1000" align="center" border="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Booking Center Master"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top">
						<table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0">
							<tr valign="top">
								<td><asp:button id="btnNew" runat="server" Width="63px" CssClass="topbutton" Height="24px" BorderStyle="Outset"
										BorderColor="DarkGray" Font-Size="XX-Small" Font-Bold="True" BackColor="Control"></asp:button><asp:button id="btnSave" runat="server" Width="63px" Height="24px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Size="XX-Small" Font-Bold="True" BackColor="Control"></asp:button><asp:button id="btnModify" runat="server" Width="63px" Height="24px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Size="XX-Small" Font-Bold="True" BackColor="Control"></asp:button><asp:button id="btnQuery" runat="server" Width="63px" Height="24px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Size="XX-Small" Font-Bold="True" BackColor="Control"></asp:button><asp:button id="btnExecute" runat="server" Width="63px" Height="24px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Size="XX-Small" Font-Bold="True" BackColor="Control"></asp:button><asp:button id="btnCancel" runat="server" Width="63px" Height="24px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Size="XX-Small" Font-Bold="True" BackColor="Control"></asp:button><asp:button id="btnfirst" runat="server" Width="62px" Height="24px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Size="XX-Small" Font-Bold="True" BackColor="Control"></asp:button><asp:button id="btnprevious" runat="server" Width="63px" Height="24px" BorderStyle="Outset"
										BorderColor="DarkGray" Font-Size="XX-Small" Font-Bold="True" BackColor="Control"></asp:button><asp:button id="btnnext" runat="server" Width="63px" Height="24px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Size="XX-Small" Font-Bold="True" BackColor="Control"></asp:button><asp:button id="btnlast" runat="server" Width="63px" Height="24px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Size="XX-Small" Font-Bold="True" BackColor="Control"></asp:button><asp:button id="btnDelete" runat="server" Width="63px" Height="24px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Size="XX-Small" Font-Bold="True" BackColor="Control"></asp:button><asp:button id="btnExit" runat="server" Width="63px" Height="24px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Size="XX-Small" Font-Bold="True" BackColor="Control"></asp:button></td>
							</tr>
							<tr valign="top" align="left">
								<td>
									<table class="Popupbar" style="WIDTH: 755px; HEIGHT: 23px" height="23" cellspacing="0"
										cellpadding="0" width="752" border="0">
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
										  <td><asp:Label ID="lbbookcentercode" runat="server" CssClass="TextField" ></asp:Label></td>
										  <td><asp:TextBox ID="txtbookcentercode" runat="server" CssClass="btext1"></asp:TextBox></td>
										</tr>
										<tr>
										  <td><asp:Label ID="lbbookcentername" runat="server" CssClass="TextField"></asp:Label></td>
										  <td><asp:TextBox ID="txtbookcentername" runat="server" CssClass="btext1"></asp:TextBox></td>
										  
										 
										</tr>
										<tr>
										  <td><asp:Label ID="lbpubcentname" runat="server" CssClass="TextField"></asp:Label></td>
										  <td><asp:DropDownList ID="drpubcentname" runat="server" CssClass="dropdown"></asp:DropDownList></td>
										</tr>
										<tr>
										  <td><asp:Label ID="pubcentcity" runat="server" CssClass="TextField"></asp:Label></td>
										  <td><asp:TextBox ID="txtpubctcity" runat="server" CssClass="btext1"></asp:TextBox></td>
										</tr>
										
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<input id="hiddencompcode" type="hidden" size="5" name="hiddenregion" runat="server" />
			<input id="hiddenuserid" type="hidden" size="5" name="hiddenregion" runat="server" />
			<input id="dateformat" type="hidden" size="5" name="hiddenregion" runat="server" />
			<input id="hiddendateformat" type="hidden" size="5" name="hiddenregion" runat="server" />
			<input id="hiddenusername" type="hidden" size="1" name="hiddenusername" runat="server" />
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
		</form>
   
</body>
</html>
