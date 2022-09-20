<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IssuePages.aspx.cs" Inherits="IssuePages" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>LayoutX : Issue Volume</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript" src="javascript/tree.js"></script>
		<script language="javascript" src="javascript/popupcalender.js"></script>
		<script language="javascript" src="javascript/Isspage.js"></script>
		<script language="javascript" src="javascript/TreeLibrary.js"></script>	
		<script type="text/javascript"language="javascript" src="javascript/chkpermission.js"></script>	
		<style type="text/css">.style1 { FONT-WEIGHT: bold; COLOR: #ffffff; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif }
	.style2 { COLOR: #ffffff }
	</style>
		<LINK href="css/main.css" type="text/css" rel="stylesheet">
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<script language="javascript" src="javascript/TreeLibrary.js"></script>
		<script language="javascript" src="javascript/tree.js">

</script>
		
</head>
<body>
    <form id="Form1" method="post" runat="server">
        &nbsp;<table id="OuterTable" width="1000" height="100%" align="center" border="0" cellpadding="0"
				cellspacing="0">
				<tr valign="top">
					<td colSpan="2" style="height: 59px"><uc1:topbar id="Topbar1" runat="server" Text="Issue Pages"></uc1:topbar></td>
				</tr>
				<tr valign="top" >
					<td valign="top" style="height: 613px; width: 214px;" ><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" id="frsttd" style="height: 613px; width: 742px;" align="left">	
					<table id=RightTable style="width:780px align=left height=613px">
					<tr valign="top">
							<td style="width: 706px">
                                     	<asp:button id="btnExit" runat="server" Height="24px" Font-Bold="True" 
										BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Width="63px" CssClass="topbutton"></asp:button>
										<asp:button id="btnQuery" runat="server" Height="24px" Font-Bold="True" 
										BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Width="63px" CssClass="topbutton"></asp:button></td>
								</tr>
					
					<tr>
					    <td style="HEIGHT: 22px; width: 780px;">
                            &nbsp;
                        </td></tr>	
					 <tr>
					    <td style="HEIGHT: 22px; width: 780px;"></td></tr>						
					<tr>
					
					<td id=secid> <TABLE cellSpacing="0" cellPadding="0" align="center" border="0" width="700">
					<tr><td style="width:160">
					<asp:Label ID="lblPublicationDate" runat="server" CssClass="TextField"></asp:Label></td>
					<td style="width: 182px">
                       <asp:TextBox ID="PubDate" runat="server" CssClass="btext1"></asp:TextBox>
                       <img src='Images/cal1.gif' id="div1" onclick='popUpCalendar(this, Form1.PubDate, "mm/dd/yyyy")' height=17 width=18></td>
                       <td colspan="3" style="width: 212px"></td>
					</tr>
					<tr>
					<td><asp:Label ID="lblPublication" runat="server" CssClass="TextField"></asp:Label></td>
					<td style="width: 52px">
                       <asp:DropDownList ID="ddlPublication" runat="server" CssClass="dropdown"><asp:ListItem Value="0">Select Publication</asp:ListItem></asp:DropDownList></td>
                       <td colspan="2" style="width: 212px"></td>
					</tr>
					<tr>
					<td><asp:Label ID="lblCenter" runat="server" CssClass="TextField"></asp:Label></td>
					<td style="width: 52px">
                       <asp:DropDownList ID="ddlCenter" runat="server" CssClass="dropdown"><asp:ListItem Value="0">Select Center</asp:ListItem></asp:DropDownList></td>
                       <td colspan="3" style="width: 212px"></td>
					</tr>
					<tr>
					<td><asp:Label ID="lblEdition" runat="server" CssClass="TextField"></asp:Label></td>
					<td style="width: 52px">
                       <asp:DropDownList ID="ddlEdition" runat="server" CssClass="dropdown"><asp:ListItem Value="0">Select Edition</asp:ListItem></asp:DropDownList></td>
                       <td colspan="3" style="width: 212px"></td>
					</tr>
					<tr>
					<td><asp:Label ID="lblSupplement" runat="server" CssClass="TextField"></asp:Label></td>
					<td style="width: 52px">
                       <asp:DropDownList ID="ddlSupplement" runat="server" CssClass="dropdown"><asp:ListItem Value="0">Select Supplement</asp:ListItem></asp:DropDownList></td>
                       <td colspan="3" style="width: 212px"></td>
					</tr>
					<tr>
					<td style="width: 52px"></td>
                       <td><asp:Button ID="btnIssueVolume" runat="server" BackColor="Control"
                BorderStyle="Outset" CssClass="topbutton" Font-Bold="True" Font-Size="XX-Small"
                Height="24px" Width="83px" /></td>
                       <td colspan="3" style="width: 212px"></td>
					</tr>
					<tr><td colspan="3" style="width: 312px"></td></tr>
					<tr><td><asp:Label ID="lblColorAd" runat="server" CssClass="TextField"></asp:Label></td>
					<td><asp:Label ID="lblBWAd" runat="server" CssClass="TextField"></asp:Label></td>
					<td><asp:Label ID="lblTotalVolume" runat="server" CssClass="TextField"></asp:Label></td>
					</tr>
					<tr><td>
                        <asp:TextBox ID="txtColorAdVolume" runat="server" BorderStyle="Solid" Width="50px"></asp:TextBox></td>
					<td>
                        <asp:TextBox ID="txtBWAdVolume" runat="server" BorderStyle="Solid" Width="50px"></asp:TextBox></td>
					<td style="width: 69px">
                        &nbsp;
                        <asp:TextBox ID="txtAdVolume" runat="server" BorderStyle="Solid" Width="50px"></asp:TextBox></td>
					</tr>
					<tr><td colspan="3" style="HEIGHT: 22px;  width: 750px"></td></tr>
					<tr>
					<td><asp:Label ID="lblSelectPage" runat="server" CssClass="TextField"></asp:Label></td>
					<td style="width: 52px">
                       <asp:DropDownList ID="drlPage" runat="server" CssClass="dropdown"><asp:ListItem Value="0">Select Page</asp:ListItem></asp:DropDownList></td>
                       <td colspan="3" style="width: 212px"></td>
					</tr>
					<tr>
					<td style="width: 52px"></td>
                       <td><asp:Button ID="btnSubmit" runat="server" BackColor="Control"
                BorderStyle="Outset" CssClass="topbutton" Font-Bold="True" Font-Size="XX-Small"
                Height="24px" Width="83px" /></td>
                       <td colspan="3" style="width: 212px"></td>
					</tr>
					</table>
					<asp:label id="li" runat="server"></asp:label>
					
					</td>									
					
					</tr>
					
							
		</table>
		</TD></TR></TABLE>
        <input id="hiddenuserid" runat="server" type="hidden" name="hiddenuserid">&nbsp;
        <input id="hiddenusername" runat="server" type="hidden" name="username">
        <input id="hiddencompcode" runat="server" type="hidden" name="hiddencompcode">
        <input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server"/>
        <input id="hiddenpermission" type="hidden" name="hiddenpermission" runat="server">
        <input id="UserLabel" type="hidden" name="UserLabel" runat="server"/> 
        <input id="hiddenstatuslabel" type="hidden" name="hiddenstatuslabel" runat="server">
        <input id="hiddendateformat" type="hidden" name="hiddendateformat" runat="server">	
        
		</form>
</body>
</html>
