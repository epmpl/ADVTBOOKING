<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PubCatRef.aspx.cs" Inherits="PubCatRef" EnableEventValidation="false"%>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>pubcatref</title>
    
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<script language="javascript" type="text/javascript" src="javascript/pubcatref.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		<script language="javascript">
	function ClientSpecialchar()
{
	
	if(event.keyCode==13)
	{
		return false;
	}
}	
</script>
</head>
<body leftMargin="5" topmargin=0 id="bdy"   onkeydown="javascript:return tabvalue(event ,'txtname');" style="background-color:#f3f6fd;">
    <form id="form1" method="post" runat="server">
    <table id="OuterTable" width="1000"  border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="PubCatRef" ></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top" style="width: 184px"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 796px">
						<table cellspacing="0" cellpadding="0" border="0" id="RightTable" class="RightTable">
							<tr valign="top">
								<td><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
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
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>PubCatRef</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			 <table  cellpadding="0" cellspacing="0" border="0" style="width:auto;margin:30px 300px;">
				<tr>
				        <td><asp:label id="lblpub" runat="server" CssClass="TextField" ></asp:label></td>
				        <td><asp:dropdownlist id="drpPubName" runat="server" CssClass="dropdown"></asp:dropdownlist></td>
				</tr>
				<tr>
						<td><asp:label id="lbcat" runat="server" CssClass="TextField"></asp:label></td>
						 <td><asp:dropdownlist id="drpadcategory" runat="server" CssClass="dropdown"></asp:dropdownlist></td>
				</tr>
				<tr>
						<td><asp:label id="lbsubcat" runat="server" CssClass="TextField"></asp:label></td>
						 <td><asp:dropdownlist id="drpadvcatcode" runat="server" CssClass="dropdown"></asp:dropdownlist></td>
				</tr>
				<tr>
						<td><asp:label id="lbname" runat="server" CssClass="TextField"></asp:label></td>
						<td><asp:TextBox ID="txtname"  runat="server" CssClass="btext1" MaxLength="30" onkeypress="javascript:return ClientSpecialchar();" ></asp:TextBox></td> 
				</tr>
			</table>	
				<input id="hiddencompcode" type="hidden" size="5" name="hiddenregion" runat="server" />			
    </form>
</body>
</html>
