<%@ Page Language="C#" AutoEventWireup="true" CodeFile="multi_discount.aspx.cs" Inherits="multi_discount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<HEAD>
		<title>multi_discount</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="javascript/DiscountMaster.js"></script>
		<LINK href="css/main.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function closebox()
		{
		window.close();
		return false;
		}
		
		</script>
		
	</HEAD>
	<body >
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 48px; WIDTH: 192px; POSITION: absolute; TOP: 16px; HEIGHT: 107px"
				cellSpacing="1" cellPadding="1" width="192" border="0">
				<TR>
					<TD><asp:listbox id="ListBox1" runat="server" Width="120px" SelectionMode="Multiple"></asp:listbox></TD>
				</TR>
				<TR>
					<TD><asp:button id="btnsubmit" runat="server" CssClass="button1" Text="Submit" onclick="btnsubmit_Click"></asp:button><asp:button id="btnupdate" runat="server" CssClass="button1" Text="Update" onclick="btnupdate_Click"></asp:button><asp:button id="btnclose" runat="server" CssClass="button1" Text="Close"></asp:button></TD>
				</TR>
				<TR>
					<TD><INPUT id="hidndiscode" type="hidden" runat="server"></TD>
				</TR>
			</TABLE>
		</FORM>
	</body>
</HTML>
