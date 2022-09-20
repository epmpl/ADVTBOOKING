<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RateGroupMaster.aspx.cs" Inherits="RateGroupMaster" %>
<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx" %>  
<%@ Register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>Display Ad. Booking & Sheduling Rate Group Master</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" Content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		<script type="text/javascript" language="javascript" src="javascript/RateGroupMaster.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/TreeLibrary.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/permission.js"></script>
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		<script type="text/javascript"language="javascript">
		function uppercase(a)
		{
		
		document.getElementById(a).value=document.getElementById(a).value.toUpperCase();
		//return ;
		
		}
		</script>
	</head>
	<body leftMargin="5" ID="bdy" topmargin=0 <%--onkeydown="if(event.keyCode==13){event.keyCode=9;return event.keyCode;}"--%>onload="loadXML('xml/errorMessage.xml');return givebuttonpermission('RateGroupMaster');"  onkeydown="javascript:return tabvalue(event,'txtAlias');" onkeypress="eventcalling(event);" style="background-color:#f3f6fd;">
		<form ID="Form1" method="post" runat="server">
			<table id="OuterTable" cellspacing="0" cellpadding="0" width="1000" border="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" text="Box Master"></uc1:topbar></td>
				</tr>
				<tr valign="top" >
					<td valign="top" style="width: 184px"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 796px">
						<table class="RightTable" runat="server"  id="RightTable" cellspacing="0" cellpadding="0" border="0" >
							<tr valign="top">
								       <td style="padding-left:-1px"><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
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
					<table border="0" width="100%" cellpadding="0" cellspacing="0" style="width:auto;margin:15px 30px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Rate Group Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			<table  style="width:auto;margin:40px 170px;" cellpadding="0" cellspacing="0" >
										<tr>
											<td><asp:Label ID="RateGroupCode" runat="server" CssClass="TextField"></asp:Label></td>
											<td><asp:TextBox onkeypress="return ClientSpecialchar(event);" ID="txtRtGroupCode" runat="server" CssClass="btext1" Enabled="False" MaxLength="8"></asp:TextBox></td>
										</tr>
										<tr>
											<td><asp:Label ID="RateGroupName" runat="server" CssClass="TextField"></asp:Label></td>
											<td><asp:TextBox ID="txtRtGroupName" runat="server" onkeypress="return ClientSpecialchar(event);" CssClass="btext" Enabled="False" MaxLength="50"></asp:TextBox></td>
										</tr>
										<tr>
											<td><asp:Label ID="Alias" runat="server" CssClass="TextField"></asp:Label></td>
											<td><asp:TextBox ID="txtAlias" runat="server"  onkeypress="return ClientSpecialchar(event);" CssClass="btext" Enabled="False" MaxLength="50"></asp:TextBox></td>
										</tr>
									</table>
			<input ID="hiddencompcode" type="hidden" size="1" name="hiddenregion" runat="server"/>
			<input ID="hiddenuserid" type="hidden" size="1" name="hiddenregion" runat="server"/>
			<input ID="dateformat" type="hidden" size="1" name="hiddenregion" runat="server"/>
			<input ID="hiddendateformat" type="hidden" size="1" name="hiddenregion" runat="server"/>
			<input ID="hiddenusername" type="hidden" size="1" name="hiddenusername" runat="server"/>
            <input ID="hiddenauto" type="hidden"  name="hiddenusername" runat="server"/>
		</form>
	</body>
</html>
