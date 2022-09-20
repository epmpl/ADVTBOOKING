<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CurrencyMaster.aspx.cs" EnableViewState="false" Inherits="CurrencyMaster" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>Display Ad. Booking & Scheduling Currency Master</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<script type="text/javascript" language="javascript" src="javascript/currencymaster.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/permission.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/TreeLibrary.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
	
		<script type="text/javascript" language="javascript">
		
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
		
		</script>
        	    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
 <link href="css/main.css" type="text/css" rel="stylesheet" />
  <link href="css/webcontrol.css" type="text/css" rel="stylesheet" />
	</head>
	<body   id="bdy" onload="loadXML('xml/errorMessage.xml'); return givebuttonpermission('CurrencyMaster');"  onkeydown="javascript:return tabvalue(event,'txtalias');" onkeypress="eventcalling(event);"style="background-color:#f3f6fd;">
		<form id="Form1" method="post" runat="server">
		    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>--%>
			<%--<table id="OuterTable" width="1000"  border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Currency Master" ></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 796px">
						<table cellspacing="0" cellpadding="0" border="0" id="RightTable" class="RightTable">
							<tr valign="top">--%>

               <table id="OuterTable" width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" text="Currency Master"></uc1:topbar></td>
				</tr>
				<tr valign="top" style="width:100%">
					
                    <td valign="top" class="rel"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar><asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    </td>
					<td valign="top" style="width: 82.6%">
						<table class="RightTable" id="RightTable" cellpadding="0" cellspacing="0" border="0">
							<tr valign="top" >
			
								<td><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnNew_Click"></asp:ImageButton><asp:ImageButton id="btnSave" runat="server" CssClass="topbutton" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"  OnClick="btnSave_Click"></asp:ImageButton><asp:ImageButton id="btnModify" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnQuery" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnExecute" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnCancel" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"  OnClick="btnCancel_Click"></asp:ImageButton><asp:ImageButton id="btnfirst" CssClass="topbutton" runat="server"  Font-Size="XX-Small" BackColor="Control"
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
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Currency Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			<table  class="styl16" cellpadding="0" cellspacing="0" >
			<tr >
				<td>
					<asp:linkbutton id="lbconrate" runat="server" CssClass="btnlink_n" Font-Underline="False" OnClick="lbconrate_Click"></asp:linkbutton>
				</td>
			</tr>
			</table>
			<table  cellpadding="0" cellspacing="0" border="0" class="styl17" >
										<tr>
											<td><asp:label id="CountryName" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:dropdownlist id="drpcountryname" runat="server" Enabled="False" CssClass="dropdown"></asp:dropdownlist></td>
										</tr>
										<tr>
											<td><asp:label id="CurrencyCode" runat="server" CssClass="TextField"></asp:label></td>
											<td> <asp:TextBox ID="txtcurrcode" runat="server" onkeypress="return ClientSpecialchar(event);" MaxLength="8" CssClass="btext1"  Enabled="False"></asp:TextBox></td>
										</tr>
										<tr>
											<td><asp:label id="CurrencyName" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox onkeypress="return ClientSpecialchar(event);" id="txtcurrname" runat="server" CssClass="btext"
													MaxLength="30" Enabled="False"></asp:textbox></td>
										</tr>
										<tr>
											<td><asp:label id="Alias" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox onkeypress="return ClientSpecialchar(event);" id="txtalias" runat="server" CssClass="btext" MaxLength="30"
													Enabled="False"></asp:textbox></td>
										</tr>
									
									
									
									
									<tr>
											<td><asp:label id="currsymbol" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox id="txtcurrsymbol" runat="server" CssClass="btext" MaxLength="30"
													Enabled="False"></asp:textbox></td>
										</tr>
									
									
									
									
									
									
                                        <tr>
                                            <td>
                                            </td>
                                            <td style="display:none">
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="btext1"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                    <td><asp:label id="SYMBOL_P" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox  id="txtSYMBOL_P" runat="server" CssClass="btextsmallphone" MaxLength="5"
													Enabled="False"></asp:textbox></td>
                                        </tr>
									</table>
			<input id="hiddencompcode" type="hidden" size="1" runat="server" name="hiddencompcode"/>
			<input id="hiddenuserid" type="hidden" size="1" runat="server" name="hiddenuserid"/>
			<input id="hiddenusername" type="hidden" size="1" name="Hidden1" runat="server" />
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
			<input id="hiddencurrate" type="hidden" name="hiddencurrate" runat="server" />
			<input id="hiddenfromdate" type="hidden" name="hiddenfromdate" runat="server" />
	        <input id="hiddentilldate" type="hidden" name="hiddentilldate" runat="server" />
            <input id="hiddencode" type="hidden" name="hiddentilldate" runat="server" />
	         <input id="hiddenchk" type="hidden" name="hiddenchk" runat="server" />
            <input id="hiddencountry" type="hidden" name="hiddenchk" runat="server" />
	 <input id="hiddendateformat" type="hidden" name="hiddenchk" runat="server" />
		<input id=hdnsession type="hidden" runat="server" />
			
		</form>
	</body>
</html>
