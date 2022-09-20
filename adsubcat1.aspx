<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adsubcat1.aspx.cs" Inherits="adsubcat1" %>
<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx" %>  
<%@ Register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<HEAD>
		<title> Ad Sub Category Master</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="javascript/popupcalender.js"></script>
		<script language="javascript" src="javascript/adsubcat1.js"></script>
		<script language="javascript" src="javascript/tree.js"></script>
		<script language="javascript" src="javascript/Validations.js"></script>
		<script language="javascript" src="javascript/permission.js"></script>
		<script language="javascript" src="javascript/entertotab.js"></script>
		<script language="javascript" src="javascript/givepermission.js"></script>
		<LINK href="css/main.css" type="text/css" rel="stylesheet">
		
			<script language="javascript">
			
function notchar2()
{
if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9))
{
return true;
}
else
{
return false;
}
}

function uppercase(a)
		{
		
		document.getElementById(a).value=document.getElementById(a).value.toUpperCase();
		return ;
		
		}

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

//Special Character Check Validator Function
function ClientSpecialchar()
{
	if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==8)||(event.keyCode==189)||(event.keyCode==37)||(event.keyCode>=97 && event.keyCode<=122)||(event.keyCode==9 || event.keyCode==32)||(event.keyCode>=65 && event.keyCode<=90)||(event.keyCode==39))
	{
		return true;
	}
	else
	{
		return false;
	}
}

	</script>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="css/main.css" type="text/css" rel="stylesheet" />
    <link href="css/stab.css" type="text/css" rel="stylesheet" />
       <link href="css/agencytypemaster.css" type="text/css" rel="stylesheet" />
	
  </HEAD>
	<body leftMargin="5" topmargin="0" onkeydown="javascript:return keycalling(event)"onload="javascript:return clearadsub1();" onkeypress="eventcalling(event);" style="background-color:#f3f6fd;">
		<form id="Form1" method="post" runat="server">
			<%--<table id="OuterTable" width="980" border="0" cellpadding="0" cellspacing="0">
			<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Ad Sub Category Master"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 796px">
						<table cellspacing="0" cellpadding="0" border="0" id="RightTable" class="RightTable">
							<tr valign="top">--%>
            <table id="OuterTable" width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="District Master"></uc1:topbar></td>
				</tr>
				<tr valign="top" style="width:100%">
					
                    <td valign="top" class="rel"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 82.6%">
						<table class="RightTable" id="RightTable" cellpadding="0" cellspacing="0" border="0">
							<tr valign="top" >
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
			<table border="0" width="100%" cellpadding="0" cellspacing="0" style="width:auto;margin:15px 30px;">
                  <tr>
				     <td style="width:0px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Ad Sub Category</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			<table class="am" cellpadding="0" cellspacing="0" >
										<tr>
											<td><asp:label id="AdvCategoryName" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:dropdownlist id="drpadvcatcode" runat="server" CssClass="dropdown18"></asp:dropdownlist></td>
										</tr>
										<tr>
											<td><asp:label id="lblstatewise" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:dropdownlist id="drpstatewise" runat="server" CssClass="dropdown18"></asp:dropdownlist></td>
										</tr>
										<tr>
										    <td><asp:label id="AdvSubCategoryCode" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox id="txtsubcatcode" runat="server" CssClass="btext112" MaxLength="8"></asp:textbox></td>
										</tr>
										<tr>
										    <td><asp:label id="AdvSubCategoryName" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox id="txtadsubcatname" runat="server" CssClass="btext" MaxLength="50"></asp:textbox></td>
																				
										</tr>
										<tr>
											<td><asp:label id="Alias" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox id="txtalias" runat="server" CssClass="btext" MaxLength="50"></asp:textbox></td>
										</tr>
										<tr>
											<td><asp:Label id="lbimagename" runat="server" CssClass="TextField"></asp:Label></td>
											<td><asp:TextBox  id="txtimagename" Enabled="false" runat="server" CssClass="btext"
													MaxLength="50"></asp:TextBox></td> <!--onkeypress="return ClientSpecialchar();"-->
										</tr>
										<tr>
											<td><asp:Label id="lbxml" runat="server" CssClass="TextField"></asp:Label></td>
											<td><asp:TextBox id="txtxml" Enabled="false" runat="server" CssClass="btext"
													MaxLength="50"></asp:TextBox></td>
										</tr>
										<tr>
										<td><asp:label id="Status" runat="server" CssClass="TextField"></asp:label></td>
                                        <td><asp:dropdownlist id="drpstatus" runat="server" CssClass="dropdown18">
                                        <asp:ListItem Value="1">Active</asp:ListItem>
                                        <asp:ListItem Value="0">InActive</asp:ListItem></asp:dropdownlist></td>
										</tr>
											<tr>
											<td><asp:Label id="Label1" runat="server" CssClass="TextField" Text="Priority"></asp:Label></td>
											<td><asp:TextBox id="txtpri" Enabled="false" runat="server" CssClass="btextsmallphonenumeric"
													MaxLength="5" onkeypress="return ClientisNumber(event);" Height="13px" Width="138px"></asp:TextBox></td>
										</tr>
										<tr>
											<td><asp:Label id="lblsapcode" runat="server" CssClass="TextField" Text="SAP Code"></asp:Label></td>
											<td><asp:TextBox id="txtsapcode"  Enabled="false" runat="server" CssClass="btext"
													MaxLength="50" Width="138px"></asp:TextBox></td>
										</tr>
										
                                    <tr>
                                         <td class="style1">
                                         <asp:Label ID="lbleddisflag" runat="server" CssClass="TextField">Edition Discount Flag </asp:Label></td>
                                         <td class="style6">
                                         <asp:DropDownList  ID="drpeddiscflag" runat="server"  CssClass="dropdown"  enable="true">     
                                         <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                         <asp:ListItem Text="Yes" Value="Y"></asp:ListItem></asp:DropDownList></td>
                                    </tr>
									</table>
			<INPUT id="hiddencomcode" type="hidden" size="1" name="hiddencomcode" runat="server">
			<INPUT id="hiddencatcode" type="hidden" size="1" name="Hidden2" runat="server"> <INPUT id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server">
			<INPUT id="hiddenDateFormat" type="hidden" size="1" name="Hidden2" runat="server">
			<INPUT id="hiddenusername" type="hidden" size="1" name="Hidden2" runat="server" onserverchange="hiddenusername_ServerChange">
			<INPUT id="hiddencompcode" type="hidden" runat="server" NAME="hiddencompcode" onserverchange="hiddencompcode_ServerChange">
            <INPUT id="hiddenauto" type="hidden" runat="server" NAME="hiddencompcode" onserverchange="hiddencompcode_ServerChange">
            
            <input id="ip1" type="hidden" name="ip1" runat="server" />
		</form>
	</body>
</HTML>
