<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SupplimentMaster.aspx.cs" Inherits="SupplimentMaster" %>
<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx" %>  
<%@ Register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>Display Ad. Booking & Sheduling Supplement Master</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<script type="text/javascript" language="javascript" src="javascript/SupplimentMaster.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/tree.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/TreeLibrary.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/permission.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<link href="css/ret.css" type="text/css" rel="stylesheet"/>
			<script type="text/javascript" language="javascript">
		function uppercase(a)
		{
		
		document.getElementById(a).value=document.getElementById(a).value.toUpperCase();
		return ;
		
		}
		
		function notchar0(event)
{
if(browser!="Microsoft Internet Explorer")
 {
 if((event.which>=48 && event.which<=57)||
(event.which==127)||(event.which==37)||
(event.which>=97 && event.which<=122)||
(event.which>=65 && event.which<=90)||
(event.which==9 || event.which==32)||(event.which==39)||(event.which==8))
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
(event.keyCode==9 || event.keyCode==32)||(event.keyCode==39))
{
return true;
}
else
{
return false;
}
}
}
function novalue()
{

if((event.keyCode>=0 && event.keyCode<=200))
{
return false;
}
else
{
return false;
}
}

		
		</script>
	</head>
	<body leftmargin="5" bottommargin="0"  topmargin="0" onkeydown="javascript:return tabvalue(event,'txtproduction');" onload="loadXML('xml/errorMessage.xml'); return  disablecheck(); return givebuttonpermission('Createuser');" <%--onkeydown="if(event.keyCode==13){event.keyCode=9;return event.keyCode;}"--%> onkeypress="eventcalling(event);checkfield(event);" style="background-color:#f3f6fd;"
		id="bdy" rightMargin="0">
		<form id="Form1" method="post" runat="server"> 
			<table id="OuterTable" width="980" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top" align="left">
					<td colspan="2" ><uc1:topbar id="Topbar1" runat="server" Text="Supplement Master" OnLoad="Topbar1_Load"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 796px">
						<table cellspacing="0" cellpadding="0" border="0" id="RightTable" class="RightTable">
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
			<table border="0" cellpadding="0" cellspacing="0" width="100%" style="width:auto;margin:15px 40px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Supplement Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			<table style=" width:100%;margin:0px 190px" cellpadding="0" cellspacing="0" >	
                    <tr>
							<td>
								<asp:linkbutton id="lbsupplement" runat="server" CssClass="btnlink_n" Font-Underline="False"></asp:linkbutton>
							</td>
					</tr>
			</table>
			<table cellpadding="0" cellspacing="0" style="width:51%;margin:10px 250px;">
			    <tr>
					<td><asp:label id="PublicationName" runat="server" CssClass="TextField"></asp:label></td>
					<td style="width: 496px"><asp:dropdownlist id="drpPubName" runat="server" CssClass="dropdown"></asp:dropdownlist></td>
				</tr>
				
				
					
				<tr>
					<td><asp:label id="EditonName" runat="server" CssClass="TextField"></asp:label></td>
					<td style="width: 496px"><asp:dropdownlist id="drEditonName" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="0">----Select Edititon----</asp:ListItem>
                    </asp:dropdownlist></td>
                      
				</tr>
				  <tr>
					<td><asp:label id="supptyp" runat="server" CssClass="TextField"></asp:label></td>
					<td style="width: 496px"><asp:dropdownlist id="drsupptyp" runat="server" CssClass="dropdown"></asp:dropdownlist></td>
				</tr>
				
				<tr>
					<td><asp:label id="SupplementCode" runat="server" CssClass="TextField"></asp:label></td>
					<td style="width: 496px"><asp:textbox id="txtSuppCode" onkeypress="return notchar0(event);" runat="server" CssClass="btext1"  MaxLength="8"></asp:textbox></td>
				</tr>
				
				<tr>
					<td><asp:label id="SupplementName" runat="server" CssClass="TextField" ></asp:label></td>
					<td ><asp:textbox id="txtSuppName" onkeypress="return notchar0(event);"  runat="server" CssClass="btextshipra" MaxLength="50"></asp:textbox></td>
				</tr>
				
				<tr>
					<td><asp:label id="Alias" runat="server" CssClass="TextField"></asp:label></td>
					<td ><asp:textbox id="txtAlias" onkeypress="return notchar0(event);" runat="server" CssClass="btextshipra" MaxLength="15"></asp:textbox></td>
				</tr>
				
				
				
				
				  <tr>
				     <td style="height: 19px"><asp:Label ID="lblshortname" runat="server" CssClass="TextField"></asp:Label></td>
				     <td style="width: 496px; height: 19px;"><asp:TextBox ID="txtshortname" runat="server" CssClass="btext1" MaxLength="50" onkeypress="javascript:return ischarKey(event);"></asp:TextBox></td>
				     </tr>
				
				
				
				
				      <tr>
				    <td><asp:Label ID="lbperiodicity" runat="server" CssClass="TextField" ></asp:Label></td>
				    <td style="width: 496px"><asp:DropDownList ID="drperiodicity" runat="server" CssClass="dropdown" ></asp:DropDownList></td></tr>
				    
				   
				
				    <tr>
				    <td><asp:Label ID="lbuom" runat="server" CssClass="TextField"></asp:Label></td>
				    <td style="width: 496px"><asp:DropDownList ID="druom" runat="server" CssClass="dropdown"></asp:DropDownList></td>
				    </tr>
				    <tr>
				    <td><asp:Label ID="lbcolumn" runat="server" CssClass="TextField"></asp:Label></td>
				    <td style="width: 496px"><asp:TextBox ID="txtcolumn" runat="server" CssClass="numerictext"   onkeypress="return ClientisNumber(event);" MaxLength="5"  onpaste="javascript:return false;"></asp:TextBox></td>
				    </tr>
				    <tr>
				     <td style="height: 19px"><asp:Label ID="lbheight" runat="server" CssClass="TextField"></asp:Label></td>
				     <td style="width: 496px; height: 19px;"><asp:TextBox ID="txtsizeheight" runat="server" onkeypress="return Multiply(event);" MaxLength="5"  CssClass="numerictext"></asp:TextBox></td>
				     </tr>
				    <tr>
				     <td><asp:Label ID="lbwidth" runat="server" CssClass="TextField"></asp:Label></td>
				        <td style="width: 496px"><asp:TextBox ID="txtsizewidth" runat="server" onkeypress="return Multiply(event);" MaxLength="5"  CssClass="numerictext"></asp:TextBox></td>
				     </tr>
				     <tr>
				    <td style="height: 19px"><asp:Label ID="lbsize" runat="server" CssClass="TextField"></asp:Label></td>
				    <td style="width: 496px; height: 19px;"><asp:TextBox ID="txtarea" runat="server" CssClass="numerictext" ></asp:TextBox></td>
				    </tr>
				   

				
				
				
			
				
				
				<tr>
					<td><asp:Label ID="lblgutter" runat="server" CssClass="TextField"></asp:Label></td>
					<td style="width: 496px"><asp:TextBox ID="txtgutter" runat="server" onkeypress="return Multiply(event);" MaxLength="5"  CssClass="numerictext"></asp:TextBox></td>
				</tr>
				<tr>
					<td><asp:Label ID="lblcolumn" runat="server" CssClass="TextField"></asp:Label></td>
					<td style="width: 496px"><asp:TextBox ID="txtcol" runat="server" onkeypress="return Multiply(event);" MaxLength="5"  CssClass="numerictext"></asp:TextBox></td>
				</tr>
				
				
				 <tr>
					<td align="left"><asp:Label id="lblrotime" runat="server" CssClass="TextField"></asp:Label></td>
					<td align="left" style="width: 496px"><asp:TextBox onkeypress="return ClientisNumber(event);" id="txthr" runat="server" CssClass="numerictext" onpaste="javascript:return false;"
					MaxLength="2"></asp:TextBox><asp:Label id="lblhr" runat="server" CssClass="TextField"></asp:Label><asp:TextBox ID="txtmin" runat="server" CssClass="numerictext" MaxLength="2" onkeypress=" return ClientisNumber(event);" onpaste="javascript:return false;"></asp:TextBox><asp:Label id="lblmin" runat="server" CssClass="TextField"></asp:Label></td>
					
				</tr>
				
				<tr>
				    <td align="left" style="height: 19px"><asp:Label id="lblproduction" runat="server" CssClass="TextField"></asp:Label></td>
					<td align="left" style="width: 496px; height: 19px;"><asp:TextBox onkeypress="return ClientisNumber(event);" id="txtproduction" runat="server" CssClass="numerictext" onpaste="javascript:return false;"
							MaxLength="3"></asp:TextBox><asp:Label id="lbdaysbefore" runat="server" CssClass="TextField"></asp:Label></td>
				</tr>
				
				
				
				
				<tr>
				    <td align="left" style="height: 19px"><asp:Label id="lblepr" runat="server" 
                            CssClass="TextField"></asp:Label></td>
					<td align="left" style="width: 496px; height: 19px;"><asp:TextBox ID="txtepr" 
                            runat="server" 
                            CssClass="numerictext"></asp:TextBox></td>
				</tr>
				
				
				
				
				<tr>
					<td colspan="2" style="height: 108px">
						<table id="Table5" style="WIDTH: 576px; HEIGHT: 85px" height="85" cellSpacing="0" cellPadding="0"
							width="576" border="1">
							<tr>
								<td valign="top" align="center" bgColor="#7daae3" colSpan="8"><asp:label id="SELECTSUPPLIMENTDAY" runat="server" ForeColor="White" Width="213px" CssClass="TextField"></asp:label></td>
							</tr>
							<tr valign="middle">
								<td align="center"><asp:label id="SUN" runat="server" CssClass="TextField"></asp:label></td>
								<td align="center"><asp:label id="MON" runat="server" CssClass="TextField"></asp:label></td>
								<td align="center"><asp:label id="TUE" runat="server" CssClass="TextField"></asp:label></td>
								<td align="center"><asp:label id="WED" runat="server" CssClass="TextField"></asp:label></td>
								<td align="center"><asp:label id="THU" runat="server" CssClass="TextField"></asp:label></td>
								<td align="center"><asp:label id="FRI" runat="server" CssClass="TextField"></asp:label></td>
								<td align="center"><asp:label id="SAT" runat="server" CssClass="TextField"></asp:label></td>
								<td align="center"><asp:label id="ALL" runat="server" CssClass="TextField"></asp:label></td>
							</tr>
							<tr valign="middle">
								<td align="center" style="height: 41px"><asp:checkbox id="CheckBox1" runat="server" CssClass="TextField"></asp:checkbox></td>
								<td align="center" style="height: 41px"><asp:checkbox id="CheckBox2" runat="server" CssClass="TextField"></asp:checkbox></td>
								<td align="center" style="height: 41px"><asp:checkbox id="CheckBox3" runat="server" CssClass="TextField"></asp:checkbox></td>
								<td align="center" style="height: 41px"><asp:checkbox id="CheckBox4" runat="server" CssClass="TextField"></asp:checkbox></td>
								<td align="center" style="height: 41px"><asp:checkbox id="CheckBox5" runat="server" CssClass="TextField"></asp:checkbox></td>
								<td align="center" style="height: 41px"><asp:checkbox id="CheckBox6" runat="server" CssClass="TextField"></asp:checkbox></td>
								<td align="center" style="height: 41px"><asp:checkbox id="CheckBox7" runat="server" CssClass="TextField"></asp:checkbox></td>
								<td align="center" style="height: 41px"><asp:checkbox id="CheckBox8" runat="server" CssClass="TextField"></asp:checkbox></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<input id="hiddenusername" type="hidden" size="5" name="hiddenregion" runat="server" onserverchange="hiddenusername_ServerChange"/>
			<input id="hiddencompcode11" type="hidden" size="5" name="hiddenregion" runat="server"/>
			<input id="hiddenuserid" type="hidden" size="5" name="hiddenregion" runat="server"/>
			<input id="dateformat" type="hidden" size="5" name="hiddenregion" runat="server"/>
			<input id="hiddendateformat" type="hidden" size="5" name="hiddenregion" runat="server" />
            <input id="hiddenauto" type="hidden" name="hiddenregion" runat="server"/>
            <input id="hiddeneditalias" type="hidden" name="hiddeneditalias" runat="server" />
			<input id="hiddeneditdate" type="hidden" name="hiddeneditdate" runat="server" />
	        <input id="hiddeneditaddate" type="hidden" name="hiddeneditaddate" runat="server" />
	            <input id="hiddencompcode" type="hidden" name="hiddeneditaddate" runat="server" />
	         <input id="hdnsuppcode" type="hidden" name="hiddeneditaddate" runat="server" />
	        <input id="hidro" type="hidden" runat="server" />
	<input id="hdnbntstatus" type="hidden" runat="server" />
              <input id="hiddenchk" type="hidden" name="hiddenchk" runat="server" />
	          <input id="ip1" type="hidden" name="ip1" runat="server" />
		</form>
	</body>
</html>
