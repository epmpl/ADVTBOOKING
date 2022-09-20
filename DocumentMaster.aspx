<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DocumentMaster.aspx.cs" Inherits="DocumentMaster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<HEAD>
		<title>Display Ad. Booking & Sheduling Document Master</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="css/main.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="javascript/DocumentMaster.js"></script>
		<script language="javascript" src="javascript/permission.js"></script>
		<script language="javascript" src="javascript/tree.js"></script>
		<script language="javascript" src="javascript/TreeLibrary.js"></script>
		<script language="javascript" src="javascript/Validations.js"></script>
		<script language="javascript">
		
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
	<body leftMargin="5" topmargin="0"  onload="javascript:return getPermission('DocumentMaster');"
		id="bdy">
		<form id="Form1" method="post" runat="server">
		<TABLE id="OuterTable" cellSpacing="0" cellPadding="0" width="1000" align="center" border="0">
				<TR vAlign="top">
					<TD colSpan="2">
						</TD>
				</TR>
				<TR vAlign="top">
					<TD vAlign="top">
						</TD>
					<TD vAlign="top">
			<TABLE class="RightTable" id="RightTable" cellSpacing="0" cellPadding="0" border="0">
				<tr vAlign="top">
			
			
					<TD><asp:button id="btnNew" runat="server" CssClass="topbutton" Height="24px" Font-Bold="True" BorderColor="DarkGray"
							BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Text="New" Width="63px"></asp:button><asp:button id="btnSave" runat="server" Height="24px" Font-Bold="True" BorderColor="DarkGray"
							BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Text="Save" Width="63px"></asp:button><asp:button id="btnModify" runat="server" Height="24px" Font-Bold="True" BorderColor="DarkGray"
							BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Text="Modify" Width="63px"></asp:button><asp:button id="btnQuery" runat="server" Height="24px" Font-Bold="True" BorderColor="DarkGray"
							BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Text="Query" Width="63px"></asp:button><asp:button id="btnExecute" runat="server" Height="24px" Font-Bold="True" BorderColor="DarkGray"
							BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Text="Execute" Width="63px"></asp:button><asp:button id="btnCancel" runat="server" Height="24px" Font-Bold="True" BorderColor="DarkGray"
							BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Text="Cancel" Width="63px"></asp:button><asp:button id="btnfirst" runat="server" Height="24px" Font-Bold="True" BorderColor="DarkGray"
							BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Text="First" Width="62px"></asp:button><asp:button id="btnprevious" runat="server" Height="24px" Font-Bold="True" BorderColor="DarkGray"
							BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Text="Previous" Width="63px"></asp:button><asp:button id="btnnext" runat="server" Height="24px" Font-Bold="True" BorderColor="DarkGray"
							BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Text="Next" Width="63px"></asp:button><asp:button id="btnlast" runat="server" Height="24px" Font-Bold="True" BorderColor="DarkGray"
							BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Text="Last" Width="63px"></asp:button><asp:button id="btnDelete" runat="server" Height="24px" Font-Bold="True" BorderColor="DarkGray"
							BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Text="Delete" Width="63px"></asp:button><asp:button id="btnExit" runat="server" Height="24px" Font-Bold="True" BorderColor="DarkGray"
							BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Text="Exit" Width="63px"></asp:button></TD>
				</tr>
				<TR vAlign="top" align="left">
					<td>
						<table class="Popupbar" style="WIDTH: 755px; HEIGHT: 23px" height="23" cellSpacing="0"
							cellPadding="0" width="752" border="0">
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
						<table align="center" style="WIDTH: 600px; HEIGHT: 88px">
							<TR>
								<TD><asp:label id="Label1" runat="server" CssClass="textfield">Document Code<font color="red">
											*</font></asp:label></TD>
								<TD><asp:textbox id="txtdoccode" onkeypress="return notchar0();" runat="server" CssClass="btext1"></asp:textbox></TD>
							</TR>
							<TR>
								<TD><asp:label id="Label2" runat="server" CssClass="textfield">Document Type<font color="red">
											*</font></asp:label></TD>
								<TD><asp:textbox id="txtdoctyp" onkeypress="return notchar0();" runat="server" CssClass="btext1"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 18px"><asp:label id="Label3" runat="server" CssClass="textfield">Alias<font color="red">*</font></asp:label></TD>
								<TD style="HEIGHT: 18px"><asp:textbox id="txtdocalias" onkeypress="return notchar0();" runat="server" CssClass="btext"></asp:textbox></TD>
							</TR>
							<TR>
								<TD><asp:label id="Label4" runat="server" CssClass="textfield">Multiplier<font color="red">*</font></asp:label></TD>
								<TD><asp:textbox id="txtmultiplier" onkeypress="return notchar0();" runat="server" CssClass="btext1"></asp:textbox></TD>
							</TR>
						</table>
					</td>
				</tr>
			</table>
			</td>
				</tr>
			</table>
			<INPUT id="hiddenformname" style="Z-INDEX: 101; LEFT: 320px; POSITION: absolute; TOP: 224px"
				type="hidden" size="1" name="Hidden1" runat="server" onserverchange="hiddenformname_ServerChange">
			&nbsp; <INPUT id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server">
			<INPUT id="hiddendateformat" type="hidden" size="1" name="Hidden2" runat="server">
			<INPUT id="hiddenusername" type="hidden" size="1" name="Hidden2" runat="server">
			<INPUT id="hiddencompcode" type="hidden" runat="server" NAME="hiddencompcode">
		</form>
	</body>
</HTML>
