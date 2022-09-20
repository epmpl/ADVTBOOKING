<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbanr_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
 <HEAD>
		<title>Default</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1" />
		<meta name="CODE_LANGUAGE" Content="C#" />
		<meta name="vs_defaultClientScript" content="JavaScript" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript" src="javascript/tree.js"></script>
		<script language="javascript" src="javascript/TreeLibrary.js"></script>
		<style type="text/css">.style1 { FONT-WEIGHT: bold; COLOR: #ffffff; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif }
	.style2 { COLOR: #ffffff }
	</style>
		<LINK href="css/main.css" type="text/css" rel="stylesheet">
     <LINK href="css/loginmain.css" type="text/css" rel="stylesheet">
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<script language="javascript" src="javascript/TreeLibrary.js"></script>
		<script language="javascript" src="javascript/tree.js"></script>
		<script language="javascript" src="javascript/deletion.js"></script>
</HEAD>
	<body onload="return chkadmin();" style="margin-top:0px;" onkeydown="javascript:return openhelppage(event);">
		<form id="Form1" method="post" runat="server">
			<table id="OuterTable" width="100%" height="100%" align="center" border="0" cellpadding="0"
				cellspacing="0">
				<tr valign="top">
					<td colSpan="2" valign="Top"><uc1:topbar id="Topbar1" runat="server" Text="Enter Page"></uc1:topbar></td>
				</tr>
				<tr valign="top" >
					<td valign="top" ><uc2:leftbar id="Leftbar1" runat="server" OnLoad="Leftbar1_Load"></uc2:leftbar></td>
					<td valign="top"  align="left">
					
						<iframe style=" BACKGROUND-COLOR:white; "    id="detail" frameBorder="0" width="600px"  height="540" ></iframe></td></tr>
			</table><table  width="100%" height="100%" align="center" border="0" cellpadding="0"
				cellspacing="0">
				<tr><td style="height:10px;"></td></tr>
				<tr><td colSpan="2" style="color:Red;" class="TextField">
			   <marquee direction="right"><strong> <%=message %></strong></marquee>
			</td></tr></table>
			<INPUT id="hiddencompcode" runat="server" type="hidden" NAME="hiddencompcode"> <INPUT id="hiddenuserid" runat="server" type="hidden" NAME="hiddenuserid">
			<INPUT id="hiddenusername" runat="server" type="hidden" NAME="username">
			<INPUT id="hiddencompuser" runat="server" type="hidden" NAME="username2">
			<INPUT id="hiddenadmin" runat="server" type="hidden" NAME="username1">
			<INPUT id="hiddencompname" runat="server" type="hidden" NAME="username1">
			<input id="hiddencenter" runat="server" type="hidden" name="hiddencenter" />
			<input id="hdndispauditbk" runat="server" type="hidden" name="hiddencenter" />
			<INPUT id="hiddencentername" runat="server" type="hidden" NAME="username1">
			<input id="hiddendatetime" runat="server" type="hidden" name="hiddencenter" />
		</form>
	</body>
</HTML>
