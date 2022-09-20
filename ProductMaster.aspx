<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductMaster.aspx.cs" Inherits="ProductMaster" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>Display Ad. Booking & Sheduling Product Master</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="css/main.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="javascript/productmaster.js"></script>
		<script language="javascript" src="javascript/permission.js"></script>
		<script language="javascript" src="javascript/tree.js"></script>
		<script language="javascript" src="javascript/tree.js"></script>
		<script language="javascript" src="javascript/TreeLibrary.js"></script>
		<script language="javascript" src="javascript/givepermission.js"></script>
		<script language="javascript">
		
		function uppercase(a)
			{
			
			document.getElementById(a).value=document.getElementById(a).value.toUpperCase();
			return ;
			
			}
		
		function notchar0(event)
	{
	 var browser=navigator.appName;
	if(browser!="Microsoft Internet Explorer")
 {

	if((event.which>=48 && event.which<=57)||
	(event.which==127)||(event.which==37)||
	(event.which>=97 && event.which<=122)||
	(event.which>=65 && event.which<=90)||
	(event.which==9 || event.which==32)||
	(event.which==8))
	{
	return true;
	}
	else
	{
	return false;
	}
	}
	else
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
	
	}
		
		</script>
</HEAD>
	<body leftMargin="5" topmargin="0"id="bdy" style="background-color:#f3f6fd;" onkeydown="javascript:return keycalling(event)" onload="javascript:return clearproductmaster();">
	
		<form id="Form1" method="post" runat="server">
			<table id="OuterTable" cellspacing="0" cellpadding="0" width="1000" border="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server"  Text="Client Product Master"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 796px">
						<table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0">
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
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton></td>
							</tr>
							
							
						</table>
					</td>
				</tr>
			</table>
			<table border="0" width="100%" cellpadding="0" cellspacing="0" style="width:auto;margin:15px 30px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Client Product </center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			<table align="center" style="width:auto;margin:30px 170px;" cellpadding="0" cellspacing="0">
										<tr>
											<td><asp:label id="ProductCode" runat="server" CssClass="NewTextField"></asp:label></td>
											<td><asp:textbox onkeypress="return notchar0(event);" id="txtproductcode" runat="server" CssClass="btext1"
													MaxLength="8" Enabled="False"></asp:textbox></td>
										</tr>
										<tr>
											<td>
                                                <asp:Label ID="ProductSubCode" runat="server" CssClass="NewTextField"></asp:Label></td>
											<td><asp:textbox id="txtprodsubcode" runat="server" CssClass="btext1" MaxLength="8" Enabled="False"></asp:textbox></td>
										</tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Clientname" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="drpclientname" runat="server" CssClass="dropdown" Enabled="False">
                                                </asp:DropDownList></td>
                                        </tr>
										<tr>
											<td><asp:label id="ProductName" runat="server" CssClass="NewTextField"></asp:label></td>
											<td><asp:textbox id="txtprodname" runat="server" CssClass="btext" MaxLength="30" Enabled="False"></asp:textbox></td>
										</tr>
										<tr>
										</tr>
									</table>
			<input id="hiddencompcode" type="hidden" size="14" name="hiddencompcode" runat="server">
			<input id="hiddenuserid" type="hidden" size="17" name="hiddenuserid" runat="server">
			<input id="hiddenusername" type="hidden" size="1" name="hiddenusername" runat="server" >
		</form>
	</body>

</html>
