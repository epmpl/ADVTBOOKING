<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CityMaster.aspx.cs" Inherits="CityMaster" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>Display Ad. Booking & Sheduling City Master</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<script type="text/javascript" language="javascript" src="javascript/CityMaster.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/TreeLibrary.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/tree.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/permission.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		
			<script type="text/javascript"  language="javascript">
			
function notchar1()
{
if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode>=97 && event.keyCode<=122)||(event.keyCode>=65 && event.keyCode<=90)||(event.keyCode==9))
{
return true;
}
else
{
return false;
}
}

function ClientisNumber()
{
   if (document.getElementById('drpCountryName').value=="0")
	{
			alert("Please Select Country Name");
			document.getElementById('drpCountryName').focus();
			return false;
	}
	if ((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==9)||(event.keyCode==11)|| (event.keyCode==13))
	{
		
		return true;
	}
	else
	{
		return false;
	}
	
}

function rateenter(event)
{
var browser=navigator.appName;

  if(browser!="Microsoft Internet Explorer")
    { 
     if((event.which>=46 && event.which<=57)||(event.which==127)||(event.which==8)||(event.which==9))
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
    if((event.keyCode>=46 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9))
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
		
		<meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <link href="css/main.css" type="text/css" rel="stylesheet" />
         <link href="css/stab.css" type="text/css" rel="stylesheet" />
       <link href="css/agencytypemaster.css" type="text/css" rel="stylesheet" />
	
	</head>
	<body  id="bdy"  topmargin="0" leftmargin="0"	onkeydown="javascript:return tabvalue(event,'txtbranch')"; onload="document.getElementById('btnNew').focus();loadXML('xml/errorMessage.xml'); givebuttonpermission('CityMaster'); enabledist();"  <%--onkeydown="if(event.keyCode==13){event.keyCode=9;return event.keyCode;}"--%> onkeypress="eventcalling(event);" style="background-color:#f3f6fd;">
		<form id="Form1" method="post" runat="server">
			<%--<table id="OuterTable" width="1000" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="City Master"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 796px">
						<table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0">
							<tr valign="top">--%>

              <table id="OuterTable" width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="City Master"></uc1:topbar></td>
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
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>City Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			<table  class="sty15" cellpadding="0" cellspacing="0" >
									<tr>
											<td><asp:label id="CountryName" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:dropdownlist id="drpCountryName" runat="server" CssClass="dropdown"></asp:dropdownlist></td>
										</tr>
										<tr>
											<td><asp:label id="lblCitycode" runat="server" CssClass="TextField"></asp:label>&nbsp;</td>
											<td><asp:textbox onkeypress="return ClientSpecialchar(event);" id="txtCityCode" runat="server" CssClass="btext"
													MaxLength="8"></asp:textbox></td>
										</tr>
										<tr>
											<td><asp:label  id="CityName" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox onkeypress="return ClientSpecialchar(event);"   id="txtCityName" runat="server" CssClass="btext"
													MaxLength="30"></asp:textbox></td>
										</tr>
										<tr>
											<td><asp:label id="CityAlias" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox id="txtAlias" runat="server" CssClass="btext"
													MaxLength="30"></asp:textbox></td>
										</tr>
										
										<tr>
											<td style="HEIGHT: 18px"><asp:label id="StateName" runat="server" CssClass="TextField"></asp:label></td>
											<td style="HEIGHT: 18px"><asp:dropdownlist id="drpStateName" runat="server" CssClass="dropdown">
                                                <asp:ListItem Value="0" Selected="True">----Select State----</asp:ListItem>
                                            </asp:dropdownlist></td>
										</tr>
										<tr id="district">
											<td style="HEIGHT: 14px"><asp:label id="DistrictName" runat="server" CssClass="TextField"></asp:label></td>
											<td style="HEIGHT: 14px"><asp:dropdownlist id="drpDistrictName" runat="server" CssClass="dropdown">
                                                <asp:ListItem Value="0">---Select District---</asp:ListItem>
                                            </asp:dropdownlist></td>
										</tr>
										<tr id="zone">
											<td style="HEIGHT: 18px"><asp:label id="ZoneName" runat="server" CssClass="TextField"></asp:label></td>
											<td style="HEIGHT: 18px"><asp:dropdownlist id="drpZoneName" runat="server" CssClass="dropdown"></asp:dropdownlist></td>
										</tr>
										<tr id="region">
											<td><asp:label id="lbregion" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:dropdownlist id="drpRegion" runat="server" CssClass="dropdown"></asp:dropdownlist></td>
										</tr>
										<tr>
											<td><asp:label id="CityStdCode" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox id="txtCitySTD" runat="server"  CssClass="btext" onkeypress="return rateenter(event);" 
													MaxLength="60"></asp:textbox></td>
										</tr>
										<tr>
										 <td><asp:Label ID="branchcode" runat="server" CssClass="TextField"></asp:Label></td>
										 <td><asp:ListBox ID="txtbranch" runat="server" SelectionMode="multiple" CssClass="dropdown" Height="100px"></asp:ListBox></td>
										</tr>
									</table>
			<input id="hiddencompcode" type="hidden" size="1" name="hiddenregion" runat="server"/>
			<input id="hiddenuserid" type="hidden" size="1" name="hiddenregion" runat="server"/>
			<input id="dateformat" type="hidden" size="1" name="hiddenregion" runat="server"/>&nbsp;
			<input id="hiddenusername" type="hidden" size="1" name="Hidden1" runat="server" onserverchange="hiddenusername_ServerChange"/>
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
			<input id="hiddendateformat" type="hidden" size="1" name="hiddenregion" runat="server"/>
			<input id="hiddenHindustan" type="hidden" size="1" name="hiddenHindustan" runat="server"/>
			<input id="ip1" type="hidden" name="ip1" runat="server" />
		</form>
	</body>
</html>

