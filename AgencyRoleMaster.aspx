<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AgencyRoleMaster.aspx.cs" Inherits="AgencyRoleMaster" %>
<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx" %>  
<%@ Register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML xmlns="http://www.w3.org/1999/xhtml">
	<HEAD>
		<title>Display Ad. Booking & Sheduling Designation</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="javascript/agencyrolemaster.js"></script>
		<script language="javascript" src="javascript/tree.js"></script>
		<script language="javascript" src="javascript/TreeLibrary.js"></script>
		<script language="javascript" src="javascript/permission.js"></script>
		<script language="javascript" src="javascript/entertotab.js"></script>
		<script language="javascript" src="javascript/givepermission.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/Validations.js"></script>
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

//numeric check
/*function num()
{
if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==32))
{
return true;
}
else
{
alert("Please enter only numeric values");
return false;
}
}*/

//Special Character Check Validator Function
function ClientSpecialchar()
{
    // var u=document.getElementById('txtname').value; 
    //alert(event.keyCode);
	if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==8)||(event.keyCode==189)||(event.keyCode>=97 && event.keyCode<=122)||(event.keyCode==9 || event.keyCode==32)||(event.keyCode>=65 && event.keyCode<=90))
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
            <link href="css/webcontrol.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="5" topmargin="0" onkeydown="javascript:return tabvalue(event,'txtnameofrole');" onload="javascript:return cleardest();" onkeypress="eventcalling(event);" style="background-color:#f3f6fd;">
		<form id="Form1" method="post" runat="server">

	<%--		<table id="OuterTable" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr vAlign="top">
					<td colSpan="2"><uc1:topbar id="Topbar1" runat="server" Text="Designation Master"></uc1:topbar></td>
				</tr>
				<tr vAlign="top">
					<td vAlign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td vAlign="top" style="width: 796px">
						<table class="RightTable" id="RightTable" cellSpacing="0" cellPadding="0" border="0">
							<tr vAlign="top">--%>

                    <table id="OuterTable" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr valign="top">
                    <td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Client Master"></uc1:topbar></td>
                    </tr>
                    <tr valign="top" style="width:100%">
                    <td valign="top" class="rel"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
                    <td valign="top" style="width: 82.6%">
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
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Designation Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			<table  class="sty4" cellpadding="0" cellspacing="0" >
										<TR>
											<TD><asp:label id="Code" runat="server" CssClass="TextField"></asp:label></TD>
											<TD><asp:textbox id="txtcode"  onkeypress="return ClientSpecialchar(event);"  runat="server" CssClass="btext1" MaxLength="8" Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD><asp:label id="Nameoftherole" runat="server" CssClass="TextField"></asp:label></TD>
											<TD><asp:textbox id="txtnameofrole"  onkeypress="return ClientSpecialchar(event);" runat="server" CssClass="btext" MaxLength="30" Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 4px"><asp:label id="Agencycode" runat="server" CssClass="TextField" Visible="False"></asp:label></TD>
											<TD style="HEIGHT: 4px"><asp:dropdownlist id="drpagencycode" runat="server" CssClass="dropdown" Visible="False" ></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD><asp:label id="Agencysubcode" runat="server" CssClass="TextField" Visible="False"></asp:label></TD>
											<TD>
												<asp:DropDownList id="drpsubcode" runat="server" CssClass="dropdown" Visible="False"></asp:DropDownList></TD>
										</TR>
										<TR>
										</TR>
									</table>
			<INPUT id="hiddencompcode" type="hidden" size="14" runat="server" NAME="hiddencompcode">
			<INPUT id="hiddenuserid" type="hidden" size="17" runat="server" NAME="hiddenuserid">
			<INPUT id="hiddenusername" type="hidden" size="1" name="hiddenusername" runat="server">
            <INPUT id="hiddenauto" type="hidden" size="1" name="hiddenusername" runat="server">
		</form>
	</body>
</HTML>
