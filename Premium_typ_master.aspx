<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Premium_typ_master.aspx.cs" Inherits="Premium_typ_master" %>
<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx" %>  
<%@ Register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>Display Ad. Booking & Sheduling Premium Type Master</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<script type="text/javascript"language="javascript" src="javascript/tree.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/tree.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/premiumtyp_master.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/permission.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		<script type="text/javascript"language="javascript">

	function uppercase(a)
			{
			
			document.getElementById(a).value=document.getElementById(a).value.toUpperCase();
			//return ;
			
			}
			
			function notchar0(event)
	{
    var browser=navigator.appName;

  if(browser!="Microsoft Internet Explorer") {
      
          if((event.which>=48 && event.which<=57)||
	    (event.which==127)||(event.which>=97 && event.which<=122)||
	    (event.which>=65 && event.which<=90)||
	    (event.which == 9 || event.which == 32) || (event.which == 8) || (event.which == 0))
	    {
	    return true;
	    }
	    else
	    {
	    return false;
	    }
    }
    else if((event.keyCode>=48 && event.keyCode<=57)||
	(event.keyCode==127)||(event.keyCode>=97 && event.keyCode<=122)||
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
</head>
	<body leftMargin="5" topmargin=0  id="bdy" onload="loadXML('xml/errorMessage.xml'); return givebuttonpermission('Premium_typ_master');"  onkeydown="javascript:return tabvalue(event,'txtalias');" onkeypress="eventcalling(event);" style="background-color:#f3f6fd;">
		<form ID="Form1" method="post" runat="server">
			<table id="OuterTable" width="1000" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar ID="Topbar1" runat="server" Text="Premium Type Master"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar ID="Leftbar1" runat="server"></uc2:leftbar>
					<asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
					</td>
					<td valign="top" style="width: 796px">
						<table cellspacing="0" cellpadding="0" border="0" ID="RightTable" class="RightTable">
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
			<table border="0" width="100%" cellpadding="0" cellspacing="0" style="width:auto;margin:15px 30px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Premium Type Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			<table  style="width:auto;margin:40px 170px;" cellpadding="0" cellspacing="0" >
										 <tr>
											<td><asp:Label ID="AdvType" runat="server" CssClass="TextField"></asp:Label></td>
											<td><asp:DropDownList ID="drpadvtype" runat="server" CssClass="dropdown" Enabled="False"></asp:DropDownList></td>
										</tr>
										<tr>
											<td><asp:Label ID="PremiumTypeCode" runat="server" CssClass="TextField"></asp:Label></td>
											<td><asp:TextBox onkeypress="return notchar0(event);" ID="txtpretycode" runat="server" CssClass="btext1" MaxLength="8" Enabled="False"></asp:TextBox></td>
										</tr>
										<tr>
											<td ><asp:Label ID="PremiumTypeDescription" runat="server" CssClass="TextField"></asp:Label></td>
											<td ><asp:TextBox onkeypress="return notchar0(event);" ID="txtpredesc" runat="server" CssClass="btext" MaxLength="30" Enabled="False"></asp:TextBox></td>
										</tr>
										<tr>
											<td><asp:Label ID="Alias" runat="server" CssClass="TextField"></asp:Label></td>
											<td><asp:TextBox onkeypress="return notchar0(event);" ID="txtalias" runat="server" CssClass="btext" MaxLength="30" Enabled="False"></asp:TextBox></td>
										</tr>
									</table>
			<input id="hiddencompcode" type="hidden" name="hiddencompcode" runat="server"/> 
			<input id="hiddenuserid" type="hidden" name="hiddenuserid" runat="server"/>
			<input id="hiddenusername" type="hidden" name="hiddenuserid" runat="server" onserverchange="hiddenusername_ServerChange"/>
            <input  id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" onserverchange="hiddenusername_ServerChange"/>
		</form>
	</body>
</html>
