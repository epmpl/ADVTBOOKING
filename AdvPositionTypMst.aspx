<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdvPositionTypMst.aspx.cs" Inherits="AdvPositionTypMst" %>
<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx" %>  
<%@ Register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<HEAD>
		<title>Ad Position Type Mst</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript" src="javascript/AdvPositionTypMst.js"></script>
		<script language="javascript" src="javascript/Validations.js"></script>
		<script language="javascript" src="javascript/permission.js"></script>
		<script language="javascript" src="javascript/tree.js"></script>
		<script language="javascript" src="javascript/TreeLibrary.js"></script>
		<script language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/datevalidation.js"></script>
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
function clientdate() {
    if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 47) || (event.keyCode == 11)) {

        return true;
    }
    else {
        return false;
    }
}

function notchar2s()
{
if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9)||(event.keyCode==46))
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
//function ClientSpecialchar(event)
//{
//	if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==8)||(event.keyCode==189)||(event.keyCode==37)||(event.keyCode>=97 && event.keyCode<=122)||(event.keyCode==9 || event.keyCode==32)||(event.keyCode>=65 && event.keyCode<=90)||(event.keyCode==39))
//	{
//		return true;
//	}
//	else
//	{
//		return false;
//	}
//}

function ClientSpecialchar(event) {
    var browser = navigator.appName;
    if (browser != "Microsoft Internet Explorer") {
        if ((event.which >= 48 && event.which <= 57) || (event.which == 0) || (event.which == 8) || (event.which == 189) || (event.which >= 97 && event.which <= 122) || (event.which == 32) || (event.which >= 65 && event.which <= 90)) {
            return true;
        }
        else {
            return false;
        }
    }
    else {
        if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 8) || (event.keyCode == 189) || (event.keyCode >= 97 && event.keyCode <= 122) || (event.keyCode == 9 || event.keyCode == 32) || (event.keyCode >= 65 && event.keyCode <= 90)) {
            return true;
        }
        else {
            return false;
        }
    }
}




function notchar8()
{
if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9)||(event.keyCode==46))
{
return true;
}
else
{
return false;
}
}

function notchar2rs()
{
if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9)||(event.keyCode==46))
{
return true;
}
else
{
return false;
}
}


	
//		function chknumber_adv(event)
//		{
//		 if((event.keyCode>=48 && event.keyCode<=57)||
//         (event.keyCode==46))
//        {
//        return true;
//        }
//        	
//	        else
//	        {
//		        return false;
//	        }




//	    }
function chknumber_adv(event) {
    var browser = navigator.appName;
    if (browser != "Microsoft Internet Explorer") {
        if ((event.which >= 48 && event.which <= 57) || ((event.which == 127) || (event.which == 37) || (event.which == 46) || (event.which == 8) || (event.which == 9) || (event.which == 13) || (event.which == 0) || (event.which == 47) || (event.which == 44))) {

            return true;
        }
        else {
            //alert("Please Enter Only Numeric Value");
            return false;
        }
    }
    else {
        if ((event.keyCode >= 48 && event.keyCode <= 57) || ((event.keyCode == 127) || (event.keyCode == 37) || (event.keyCode == 46) || (event.keyCode == 8) || (event.keyCode == 9) || (event.keyCode == 13) || (event.keyCode == 47) || (event.keyCode == 44))) {

            return true;
        }
        else {
            //alert("Please Enter Only Numeric Value");
            return false;
        }
    }
}
		
		



		
		</script>
	</HEAD>
	<body leftMargin="5" topmargin="0"   id="bdy" onload="loadXML('xml/errorMessage.xml');javascript:return givebuttonpermission('AdvPositionTypMst')" onkeydown="javascript:return tabvalue(event,'txtamount');" onkeypress="eventcalling(event);"style="background-color:#f3f6fd;">
		<form id="Form1" method="post" runat="server">
			<table id="OuterTable" cellspacing="0" cellpadding="0" width="1000" border="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Ad Position Master"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server" ></uc2:leftbar></td>
					<td valign="top" style="width: 796px">
						<table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0" style="left: 0px; top: 0px">
							<tr valign="top">
								<TD><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnSave" runat="server" CssClass="topbutton" Font-Size="XX-Small" BackColor="Control"
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
								</TD>
							</tr>
				        </table>
				    </tr>
				<table>
		        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="width:auto;margin:15px 40px;">
                  <tr>
		             <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>AD Position Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
			         <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
                </table>
				<table align="center" cellpadding="0" cellspacing="0">
								<tr>
									<TD><asp:Label id="PositionTypeCode" runat="server" CssClass="TextField"></asp:Label>&nbsp;</TD>
									<TD ><asp:TextBox onkeypress="return ClientSpecialchar();" id="txtPosTypCode" runat="server" CssClass="btext1" MaxLength="8"></asp:TextBox></TD>
									
									 <td><asp:Label id="AdvType" runat="server" CssClass="TextField"></asp:Label></td>
									  <td><asp:DropDownList   ID="dradvtyp" runat="server" CssClass="dropdown"></asp:DropDownList></td>
									
									
								</tr>
								<tr>
									<TD><asp:Label id="PositonType" runat="server" CssClass="TextField"></asp:Label></TD>
									<TD  colspan="3"><asp:TextBox onkeypress="return ClientSpecialchar(event);" id="txtPosType" runat="server" CssClass="btext" MaxLength="30"></asp:TextBox></TD>
								</tr>
								<tr>
									<TD><asp:Label id="Alias" runat="server" CssClass="TextField"></asp:Label></TD>
									<TD  colspan="3"><asp:TextBox onkeypress="return ClientSpecialchar();" id="txtAlias" runat="server" CssClass="btext" MaxLength="30"></asp:TextBox></TD>
								</tr>
								 <tr>
									  <td><asp:Label ID="ValidFrom" runat="server" CssClass="TextField"></asp:Label></td>
									  <td><asp:TextBox ID="txtvalid" runat="server" CssClass="btext1" onkeypress="return clientdate();" MaxLength="10"></asp:TextBox>
										<img src='Images/cal1.gif' id="div123"  onclick='popUpCalendar(this, Form1.txtvalid, "dd/mm/yyyy")' onfocus=abc();  height=14 width=14> 
																			
										 </td>
									  <td><asp:Label ID="ValidTill" runat="server" CssClass="TextField"></asp:Label></td>
									  <td><asp:TextBox ID="txtvalidtill" runat="server" CssClass="btext1" onkeypress="return clientdate();"  MaxLength="10"></asp:TextBox>
								       <img src='Images/cal1.gif' id="Img1"  onclick='popUpCalendar(this, Form1.txtvalidtill, "dd/mm/yyyy")' onfocus=abc();  height=14 width=14> 
															
									</td>
									 </tr>
								 <tr>
							 <td><asp:Label ID="premium" runat="server" CssClass="TextField"></asp:Label></td>
							  <td><asp:DropDownList ID="drpremium" runat="server" CssClass="dropdownsmall12" Height="20" Width="70" >
							   <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
							   <asp:ListItem Value="per">Percentage</asp:ListItem>
							  <asp:ListItem Value="fixed">Fixed</asp:ListItem>
							  </asp:DropDownList>
							 <asp:TextBox ID="txtamount" runat="server" CssClass="btextsmallphonepank" onkeypress="return chknumber_adv(event);" MaxLength="6" ></asp:TextBox></td>
							
							   
						
							 </tr>
								<%--<TR>
									<TD><asp:Label id="lblamount" runat="server" CssClass="TextField"></asp:Label></TD>
									<TD><asp:TextBox onkeypress="return notchar8();" id="txtamount" runat="server" CssClass="numerictext" MaxLength="5"></asp:TextBox></TD>
								</TR>--%>
								<%--<TR>
									<TD style="height: 20px"><asp:Label id="Pageno" runat="server" CssClass="TextField"></asp:Label></TD>
									<TD style="height: 20px">
                                        <asp:DropDownList ID="drppageno" runat="server" CssClass="dropdown" Visible="False">
                                        </asp:DropDownList></TD>
								</TR>--%>
								
				</table>
								
				<table>
			        <INPUT id="hiddenprem" type="hidden" size="1" runat="server"/>
			        <INPUT id="hiddencompcode" type="hidden" size="1" name="hiddenregion" runat="server">
			        <INPUT id="hiddenuserid" type="hidden" size="1" name="hiddenregion" runat="server">
			        <INPUT id="dateformat" type="hidden" size="1" name="hiddenregion" runat="server">
			        <INPUT id="hiddendateformat" type="hidden" size="1" name="hiddendateformat" runat="server">
        			   <INPUT id="hdndateformat" type="hidden" runat="server">
			        <INPUT id="hiddenusername" runat="server" type="hidden" size="1" NAME="hiddenusername" onserverchange="hiddenusername_ServerChange">
                    <INPUT id="hiddenauto" runat="server" type="hidden" size="1" NAME="hiddenusername" onserverchange="hiddenusername_ServerChange">
                </table>
		</form>
	</body>
</HTML>
