<%@ Page Language="C#" AutoEventWireup="true" CodeFile="changeeditionstatus.aspx.cs" Inherits="changeeditionstatus" %>
<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx" %>  
<%@ Register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<HEAD>
		<title>Edition Status</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript" src="javascript/Changeeditionstatus.js"></script>		
		<script language="javascript" src="javascript/permission.js"></script>	
		<script type="text/javascript" language="javascript" src="javascript/entertotab.js"></script>	
		<LINK href="css/main.css" type="text/css" rel="stylesheet">
		
	</HEAD>
	<body leftMargin="5" topmargin="0"  id="bdy" onload="javascript:return clearedition();" onkeydown="javascript:return tabvalue(event,'drpStatus');" style="background-color:#f3f6fd;"> 
		<form id="Form1" method="post" runat="server">
			<table id="OuterTable" width="980" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Edition Status Master"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td vAlign="top" style="width: 796px">
						<table cellSpacing="0" cellPadding="0" border="0" id="RightTable" class="RightTable">
							<tr valign="top">
								<td><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnSave" runat="server" CssClass="topbutton" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnModify" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnQuery" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnExecute" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnCancel" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnfirst" CssClass="topbutton" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnprevious" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnnext" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnlast" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnDelete" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnExit" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<table border="0" cellpadding="0" cellspacing="0" width=100% style="width:auto;margin:15px 40px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Main/Sub Edition Status</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			<table cellpadding="0" cellspacing="0" style="width:auto;margin:40px 200px;">
				<TR>
					<TD><asp:Label id="AdType" runat="server" CssClass="TextField"  style="display:none"></asp:Label></TD>
					<TD><asp:DropDownList id="drpadtype" runat="server" CssClass="btext" style="display:none"></asp:DropDownList></TD>
				</TR>
				
				<tr>
						<td><asp:Label id="lbeditiontype" runat="server" CssClass="TextField"></asp:Label></td>
						<td><asp:DropDownList id="drpeditiontype" runat="server" CssClass="btext"><asp:ListItem Value="0">-Select Edition type-</asp:ListItem>
                            <asp:ListItem Value="Main Edition">Main Edition</asp:ListItem>
                            <asp:ListItem Value="Edition">Sub Edition</asp:ListItem>
                        </asp:DropDownList></td>
					</tr>
				
				
				
				<TR>
					
					<TD><asp:Label id="PackageCode" runat="server" CssClass="TextField"></asp:Label>&nbsp;</TD>
					<TD><asp:DropDownList ID="drpPackageCode" runat="server" CssClass="btext" Enabled="False">
					<%--<asp:ListItem Selected="True" Value="0">--SELECT EDITION--</asp:ListItem>--%>
					</asp:DropDownList></TD>
				</TR>
				<TR>
					<TD><asp:Label id="Status" runat="server" CssClass="TextField"></asp:Label></TD>
					<TD><asp:DropDownList id="drpStatus" runat="server" CssClass="btext"></asp:DropDownList></TD>
				</TR>
			</table>
			<INPUT id="hiddencompcode" type="hidden" size="1" name="hiddenregion" runat="server">
			<INPUT id="hiddenuserid" type="hidden" size="1" name="hiddenregion" runat="server">
			<INPUT id="dateformat" type="hidden" size="1" name="hiddenregion" runat="server">
			<INPUT id="hiddendateformat" type="hidden" size="1" name="hiddenregion" runat="server">
			<INPUT id="hiddenrecordid" type="hidden" size="1" name="hiddenrecordid" runat="server">
			<INPUT id="hiddenusername" runat="server" type="hidden" size="1" NAME="hiddenusername">
            <INPUT id="hiddenauto" runat="server" type="hidden" size="1" NAME="hiddenusername">
		</form>
	</body>
</HTML>

