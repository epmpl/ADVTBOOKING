<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MaterialMaster.aspx.cs" Inherits="MaterialMaster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<HEAD>
		<title>Display Ad. Booking & Sheduling Material Master</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript" src="javascript/MaterialMaster.js"></script>
		<script language="javascript" src="javascript/Validations.js"></script>
		<script language="javascript" src="javascript/permission.js"></script>
		<script language="javascript" src="javascript/tree.js"></script>
		<script language="javascript" src="javascript/TreeLibrary.js"></script>
		<link href="css/main.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body topmargin=0 leftmargin="5"  id="bdy">
		<form id="Form1" method="post" runat="server">
			<table id="OuterTable" cellSpacing="0" cellPadding="0" width="1000" align="center" border="0">
				<tr vAlign="top">
					<td colSpan="2"></td>
				</tr>
				<tr vAlign="top">
					<td vAlign="top"></td>
					<td vAlign="top">
						<table class="RightTable" id="RightTable" cellSpacing="0" cellPadding="0" border="0">
							<tr vAlign="top">
								<TD><asp:button id="btnNew" runat="server" Text="New" Width="63px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Bold="True" Height="24px" Font-Size="XX-Small" BackColor="Control" CssClass="topbutton"></asp:button><asp:button id="btnSave" runat="server" Text="Save" Width="63px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Bold="True" Height="24px" Font-Size="XX-Small" BackColor="Control" CssClass="topbutton"></asp:button><asp:button id="btnModify" runat="server" Text="Modify" Width="63px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Bold="True" Height="24px" Font-Size="XX-Small" BackColor="Control" CssClass="topbutton"></asp:button><asp:button id="btnQuery" runat="server" Text="Query" Width="63px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Bold="True" Height="24px" Font-Size="XX-Small" BackColor="Control" CssClass="topbutton"></asp:button><asp:button id="btnExecute" runat="server" Text="Execute" Width="63px" BorderStyle="Outset"
										BorderColor="DarkGray" Font-Bold="True" Height="24px" Font-Size="XX-Small" BackColor="Control" CssClass="topbutton"></asp:button><asp:button id="btnCancel" runat="server" Text="Cancel" Width="63px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Bold="True" Height="24px" Font-Size="XX-Small" BackColor="Control" CssClass="topbutton"></asp:button><asp:button id="btnfirst" runat="server" Text="First" Width="62px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Bold="True" Height="24px" Font-Size="XX-Small" BackColor="Control" CssClass="topbutton"></asp:button><asp:button id="btnprevious" runat="server" Text="Previous" Width="63px" BorderStyle="Outset"
										BorderColor="DarkGray" Font-Bold="True" Height="24px" Font-Size="XX-Small" BackColor="Control" CssClass="topbutton"></asp:button><asp:button id="btnnext" runat="server" Text="Next" Width="63px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Bold="True" Height="24px" Font-Size="XX-Small" BackColor="Control" CssClass="topbutton"></asp:button><asp:button id="btnlast" runat="server" Text="Last" Width="63px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Bold="True" Height="24px" Font-Size="XX-Small" BackColor="Control" CssClass="topbutton"></asp:button><asp:button id="btnDelete" runat="server" Text="Delete" Width="63px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Bold="True" Height="24px" Font-Size="XX-Small" BackColor="Control" CssClass="topbutton"></asp:button><asp:button id="btnExit" runat="server" Text="Exit" Width="63px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Bold="True" Height="24px" Font-Size="XX-Small" BackColor="Control" CssClass="topbutton"></asp:button></TD>
							</tr>
							<TR align="left" valign="top">
								<td>
									<table class="Popupbar" width="752" height="23" cellSpacing="0" cellPadding="0" border="0"
										style="WIDTH: 755px; HEIGHT: 23px">
										<tr>
											<td bgColor="#7daae3"></td>
										</tr>
									</table>
								</td>
							</TR>
							<tr>
								<td height="25"></td>
							</tr>
							<tr>
								<td>
									<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="300" border="0" align="center">
										<TR>
											<TD>
												<asp:Label id="Label1" runat="server" CssClass="textfield" Width="96px">Material Code<font color="red">
														*</font></asp:Label></TD>
											<TD>
												<asp:TextBox id="txtmatcode" runat="server" onkeypress="return ClientSpecialchar()" CssClass="btext1"
													MaxLength="8"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD>
												<asp:Label id="Label2" runat="server" CssClass="textfield">Material Name<font color="red">
														*</font></asp:Label></TD>
											<TD>
												<asp:TextBox id="txtmatname" runat="server" onkeypress="return ClientSpecialchar()" CssClass="btext"
													MaxLength="50"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD>
												<asp:Label id="Label3" runat="server" CssClass="textfield">Alias<font color="red">*</font></asp:Label></TD>
											<TD>
												<asp:TextBox id="txtmatalias" runat="server" onkeypress="return ClientSpecialchar()" CssClass="btext"
													MaxLength="15"></asp:TextBox></TD>
										</TR>
									</TABLE>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<INPUT id="hiddencompcode" type="hidden" size="1" name="Hidden1" runat="server">
			<INPUT id="hiddenuserid" type="hidden" size="1" name="Hidden2" runat="server"> <INPUT id="hiddenDateFormat" type="hidden" size="1" name="Hidden3" runat="server">
			<INPUT id="Hidden4" type="hidden" size="1" name="Hidden4" runat="server"> <INPUT id="Hidden5" type="hidden" size="1" name="Hidden5" runat="server">
			<INPUT id="hiddenusername" runat="server" type="hidden" size="1" NAME="hiddenusername" onserverchange="hiddenusername_ServerChange">
		</form>
	</body>
</HTML>
