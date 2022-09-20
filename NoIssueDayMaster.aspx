<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NoIssueDayMaster.aspx.cs" Inherits="NoIssueDayMaster" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>Display Ad. Booking & Sheduling No Issue Day Master</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="css/main.css" type="text/css" rel="stylesheet">
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		
		<script language="javascript" type="text/javascript" src="javascript/permission.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/tree.js" ></script>
		<script language="javascript" type="text/javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/NoIssueDayMaster.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		
		
	</head>
	<body leftMargin="5" topmargin=0 id="bdy" onload= "return givebuttonpermission('NoIssueDayMaster');" onkeydown="javascript:return tabvalue(event,'txtnoissuedayname');"  onkeypress="eventcalling(event);" style="background-color:#f3f6fd;"> 
		<form id="Form1" method="post" runat="server">
			<table id="OuterTable" width="1000"  border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colSpan="2"><uc1:topbar id="Topbar1" runat="server" Text="No Issue Day Master" ></uc1:topbar></td>

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
			<table border="0" cellpadding="0" cellspacing="0" style=" width:100%;margin:15px 40px">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>No Issue Day Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:770px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			<table style="width:100%;margin:40px 200px;">
				<TR>
					<TD style="width:130px"><asp:label id="lbldaycode" runat="server" CssClass="TextField"></asp:label></TD>
					<TD><asp:textbox id="txtnoissuedaycode" runat="server" CssClass="btext1"
							Enabled="False" MaxLength="8"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="width: 130px"><asp:label id="lbldayname" runat="server" CssClass="TextField"></asp:label></TD>
					<TD><asp:textbox id="txtnoissuedayname" runat="server" CssClass="btext"	Enabled="False" MaxLength="30"></asp:textbox></TD>
				</TR>
			</table>
			<input id="hiddencomcode" type="hidden" size="1" name="hiddencomcode" runat="server"/>
			<input id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server"/> 
			<input id="hiddenDateFormat" type="hidden" size="1" name="Hidden2" runat="server"/>
			<input id="hiddencompcode" type="hidden" size="1" name="hiddencompcode" runat="server"/>
			<input id="hiddenusername" type="hidden" size="2" name="Hidden1" runat="server"/>
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
		</form>
	</body>
</html>
