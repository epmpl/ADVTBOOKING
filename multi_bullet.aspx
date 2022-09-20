<%@ Page Language="C#" AutoEventWireup="true" CodeFile="multi_bullet.aspx.cs" Inherits="multi_bullet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<HEAD>
		<title>multi_bullet</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<LINK href="css/main.css" type="text/css" rel="stylesheet">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript">
		function closebullet()
		{
		window.close();
		return false;
		}
		
		
		
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 40px; WIDTH: 192px; POSITION: absolute; TOP: 16px; HEIGHT: 107px"
				cellSpacing="1" cellPadding="1" width="192" border="0">
				<TR>
					<TD>
						<asp:ListBox id="ListBox1" runat="server" SelectionMode="Multiple" Width="120px"></asp:ListBox></TD>
				</TR>
				<TR>
					<TD>
						<asp:Button id="btnsubmit" runat="server" Text="Submit" CssClass="button1" onclick="btnsubmit_Click"></asp:Button>
						<asp:Button id="btnupdate" runat="server" Text="Update" CssClass="button1" onclick="btnupdate_Click"></asp:Button>
						<asp:Button id="btnclose" runat="server" Text="Close" CssClass="button1"></asp:Button></TD>
				</TR>
			</TABLE>
			<INPUT id="chkmulti" style="Z-INDEX: 102; LEFT: 48px; WIDTH: 24px; POSITION: absolute; TOP: 152px; HEIGHT: 22px"
				type="hidden" size="1" name="chkmulti" runat="server">
		</form>
	</body>
</HTML>
