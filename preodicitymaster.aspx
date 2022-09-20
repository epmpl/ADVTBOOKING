
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="preodicitymaster.aspx.cs" Inherits="preodicitymaster" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>Periodicity Master</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		<script type="text/javascript"language="javascript" src="javascript/preodicitymaster.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/permission.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/tree.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/TreeLibrary.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
	</head>
	<body leftMargin="5" topmargin="0"   id="bdy" onload="loadXML('xml/errorMessage.xml');document.getElementById('btnNew').focus();javascript:return givebuttonpermission('preodicitymaster');" onkeydown="tabvalue(event,'txtAlias');" onkeypress="eventcalling(event);" style="background-color:#f3f6fd;">
		<form id="Form1" method="post" runat="server">
			<table id="OuterTable" width="1000" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top" style="width: 184px; height:60px;">
						<table border="0" cellpadding="0" cellspacing="0" >
							<tr valign="top" style="height:26px">
								<td valign="baseline" colspan="3">
									<div id="Leftbar1_tP1" class="topbarclock1"><span id="Leftbar1_lbrelease">Release No. 5.0.01</span></div>
								</td>
							</tr>				
						</table>					
					</td>
					<td valign="top" style="width: 796px">
						<table class="RightTable" id="RightTable" cellpadding="0" cellspacing="0">
							<tr valign="top">
								<td><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"  onclick="btnNew_Click"></asp:ImageButton><asp:ImageButton id="btnSave" runat="server" CssClass="topbutton" Font-Size="XX-Small" BackColor="Control"
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
			<table border="0" cellpadding="0" cellspacing="0" width="100%" style="width:auto;margin:15px 40px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Periodicity Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:770px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
            <table  border="0" style="width:auto;margin:40px 200px;">
					<tr style="height:17px">
						<td><asp:Label id="lblpreCode" runat="server" CssClass="TextField"></asp:Label></td>
						<td><asp:TextBox id="txtpreCode" runat="server"  MaxLength="8" CssClass="btext1"></asp:TextBox></td>
					</tr>
					<tr>
						<td><asp:Label id="lbpreodicityname" runat="server" CssClass="TextField"></asp:Label></td>
						<td><asp:TextBox id="txtprename" runat="server"  MaxLength="30" CssClass="btext" onkeypress="javascript:return ischarKey(event);"></asp:TextBox></td>
					</tr>
					<tr>
						<td><asp:Label id="lbAlias" runat="server" CssClass="TextField"></asp:Label></td>
						<td><asp:TextBox id="txtAlias" runat="server" MaxLength="30" CssClass="btext"></asp:TextBox></td>
					</tr>
			</table>
			<input id="hiddencompcode" type="hidden" size="1" name="hiddenregion" runat="server"/>
			<input id="hiddenuserid" type="hidden" size="1" name="hiddenregion" runat="server"/>
			<input id="dateformat" type="hidden" size="1" name="hiddenregion" runat="server"/>
			<input id="hiddendateformat" type="hidden" size="1" name="hiddenregion" runat="server"/>
			<input id="hiddenusername" runat="server" type="hidden" size="1" name="hiddenusername" onserverchange="hiddenusername_ServerChange"/>
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server"/>
		</form>
	</body>
</html>
