<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RepMast.aspx.cs" Inherits="RepMast" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>Representative Master</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<script type="text/javascript" language="javascript" src="javascript/permission.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/RepMast.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/tree.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/treeLibrary.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
        <script type="text/javascript" language="javascript">
      
		//Special Character Check Validator Function
function ClientSpecialcharrep(event)
{
var browser=navigator.appName;
//alert(event.keyCode);
 if(browser!="Microsoft Internet Explorer")
 {
    if((event.which>=44 && event.which<=57)|| (event.which==0) ||(event.which==8)|| (event.keyCode==38)|| (event.which==189)||(event.which>=97 && event.which<=122)||( event.which==32)||(event.which>=65 && event.which<=90))
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
	if((event.keyCode>=44 && event.keyCode<=57)||(event.keyCode==8) || (event.keyCode==38)||(event.keyCode==189)||(event.keyCode>=97 && event.keyCode<=122)||(event.keyCode==9 || event.keyCode==32)||(event.keyCode>=65 && event.keyCode<=90))
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
        <link href="css/webcontrol.css" type="text/css" rel="stylesheet">
     <link href="css/agencytypemaster.css" type="text/css" rel="stylesheet" />  
	</head>
	<body id="bdy" onload="javascript:return clearrepmast(); "  onkeydown="javascript:return tabvalue(event,'txtrepstatus');"  onkeypress="eventcalling(event);" style="background-color:#f3f6fd;"> <%--onkeydown="if(event.keyCode==13){event.keyCode=9;return event.keyCode;}" --%> 
		<form id="Form1" method="post" runat="server">
		
		
		
		<div id="divsubcatname" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
            <table cellpadding="0" cellspacing="0"><tr><td>
                <asp:ListBox ID="lstsubcatname" Width="260px" Height="85px" runat="server" CssClass="dropdown" >
                 </asp:ListBox>
                 </td></tr>
                 </table>
            </div>
		
		
<%--			<table id="OuterTable" width="1000" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Reprsentative Master" ></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 796px">
						<table cellspacing="0" cellpadding="0" border="0" id="RightTable" class="RightTable">
							<tr valign="top">--%>
            <table id="OuterTable" cellspacing="0" cellpadding="0" width="100%" border="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Reprsentative Master"></uc1:topbar></td>
				</tr>
				<tr valign="top" style="width:100%">
					<td valign="top" class="rel"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" class="styl58">
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
				<table border="0" width="100%" cellpadding="0" cellspacing="0" class="barcss" >
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Reprsentative Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:770px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
				<table id="table2" align="center" class="styl3" cellpadding="0" cellspacing="0">
											<tr>
												<td>
													<asp:label id="RepresentativeCode" runat="server" CssClass="TextField"></asp:label></td>
												<td>
													<asp:textbox  id="txtrepcode" onkeypress="return ClientSpecialchar(event);" runat="server" CssClass="btext1"
														Enabled="False" MaxLength="8"></asp:textbox></td>
											</tr>
											<tr>
												<td >
													<asp:label id="RepresentativeName" runat="server" CssClass="TextField"></asp:label></td>
												<td style="height: 23px">
													<asp:textbox  id="txtrepname" onkeypress="return ClientSpecialcharrep(event);" runat="server" CssClass="btext"
														Enabled="False" MaxLength="50"></asp:textbox></td>
											</tr>
												<tr>
											  <td>
											    <asp:Label id="country" runat="server" CssClass="TextField"></asp:Label>
											  </td>
											  <td style="height: 23px">
											      <asp:DropDownList  id="txtcountry" runat="server" CssClass="dropdown" Enabled="False" MaxLength="50">
												  </asp:DropDownList>
										      </td>
														
											</tr>
											
											<tr>
												<td >
													<asp:label id="city" runat="server" CssClass="TextField"></asp:label></td>
												<td style="height: 23px">
													<asp:DropDownList  id="txtcity"  runat="server" CssClass="dropdown"
														Enabled="False" MaxLength="50"><asp:ListItem Value="0" Text="----Select City----"></asp:ListItem></asp:DropDownList></td>
											</tr>
										 <tr>
												<td >
													<asp:label id="state" runat="server" CssClass="TextField"></asp:label></td>
												<td style="height: 23px">
													<asp:textbox  id="txtstate" runat="server" CssClass="btext1" Enabled="False" MaxLength="50"></asp:textbox></td>
											</tr>
											
											<tr>
												<td >
													<asp:label id="dist" runat="server" CssClass="TextField"></asp:label></td>
												<td style="height: 23px">
											
													<asp:textbox  id="txtdist" runat="server" CssClass="btext1" Enabled="False" MaxLength="50"></asp:textbox></td>
											</tr>
											<tr>
												<td >
													<asp:label id="taluka" runat="server" CssClass="TextField"></asp:label></td>
												<td style="height: 23px">
													<asp:DropDownList  id="txttaluka"  runat="server" CssClass="dropdown"
														Enabled="False" MaxLength="50"><asp:ListItem Value="0" Text="----Select Taluka----"></asp:ListItem></asp:DropDownList></td>
											</tr>
											
										
											<tr>
											  <td>
											    <asp:Label id="repstatus" runat="server" CssClass="TextField"></asp:Label>
											  </td>
											  <td style="height: 23px">
											      <asp:DropDownList  id="txtrepstatus" runat="server" CssClass="dropdown" Enabled="False" MaxLength="50"><asp:ListItem Value="Active" Text="Active"></asp:ListItem>
													<asp:ListItem Value="InActive" Text="InActive"></asp:ListItem>
												  </asp:DropDownList>
										      </td>
														
											</tr>
											
										</table>
				<input id="hiddencompcode" type="hidden" size="14" name="hiddencompcode" runat="server"/>
				<input id="hiddenuserid" type="hidden" size="17" name="hiddenuserid" runat="server"/>
				<input id="hiddenusername" type="hidden" size="1" name="hiddenusername" runat="server"/>
            <input id="hiddenauto" type="hidden" size="1" name="hiddenusername" runat="server"/>
             <input id="hdncatname" type="hidden" size="1" name="hdncatname" runat="server">
            
            <input id="hdnsubcat" type="hidden" size="1" name="hdnsubcat" runat="server">
            <input id="hdncity" type="hidden" size="1" name="hiddencity" runat="server"/>
			</form>
		
	</body>
</html>
