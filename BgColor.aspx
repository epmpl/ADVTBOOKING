<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BgColor.aspx.cs" Inherits="BgColor" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>BgColor</title>
     
        <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		
		
		<script type="text/javascript" language="javascript" src="javascript/Validations.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/permission.js"></script>
		<script language="javascript" src="javascript/tree.js"type="text/javascript" ></script>
		<script type="text/javascript" language="javascript" src="javascript/TreeLibrary.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/BgColor.js"></script>
		
		
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<script language="javascript" type="text/javascript">
        function notss()
        {
//         alert(event.keyCode);
          var browser=navigator.appName;
         if(browser!="Microsoft Internet Explorer")
         { 
            if((event.which>=48 && event.which<=57)||(event.which==127)||(event.which==8)||(event.which==9)||(event.which>=65 && event.which<=90)||(event.which>=97 && event.which<=122)||(event.which==43)||(event.which==32))
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
         if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9)||(event.keyCode>=65 && event.keyCode<=90)||(event.keyCode>=97 && event.keyCode<=122)||(event.keyCode==43)||(event.keyCode==32))
            {
            return true;
            }
            else
            {
            return false;
            }
         }
       }
       function notchar2(event)
{
var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer")
 {
if((event.which>=48 && event.which<=57)||
(event.which==127)||(event.which==8)||(event.which==190)||

(event.which==9 || event.which==32)||(event.which==46) ||
(event.which==0))
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
(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==190)||

(event.keyCode==9 || event.keyCode==32)||(event.keyCode==46))
{
return true;
}
else
{
return false;
}
}
}


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




		</script>
</head>
<body onkeypress="eventcalling(event);" onload="javascript:return clearbgcolor();" onkeydown="tabvalue(event,'drpcolortype')" style="background-color:#f3f6fd;">
    <form id="frmbgcolor" method="post" runat="server">
    			<table id="OuterTable" width="1000" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Bg Color"></uc1:topbar></td>
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
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Bg Color</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			<table  style="width:auto;margin:40px 170px;" cellpadding="0" cellspacing="0" >
										<tr>
											<td><asp:label id="lblbgid"  runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox id="txtbgid"  runat="server" CssClass="btext1" onkeypress="return notss(event);"
													MaxLength="8"></asp:textbox></td>
										</tr>
										<tr>
											<td><asp:label id="lblbgname" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox id="txtbgname" runat="server" CssClass="btext" onkeypress="return ClientSpecialchar(event);" 
													MaxLength="30"></asp:textbox></td>
										</tr>
										<tr>
											<td style="height: 19px"><asp:label id="lblbgalias" runat="server" CssClass="TextField"></asp:label></td>
											<td style="height: 19px">
                                                <asp:TextBox ID="txtbgalias" runat="server" CssClass="btext" MaxLength="30" Enabled="False"></asp:TextBox></td>
										</tr>
										<tr>
											<td><asp:label id="lblcharges" runat="server" CssClass="TextField">BgAmount</asp:label></td>
											<td colSpan="2"><asp:dropdownlist id="drpbgamttype" runat="server" CssClass="dropdown" Enabled="False" OnChange="javascript:fixper();">
													<asp:ListItem Value="0" Selected="True">--Select BgAmt--</asp:ListItem>
													<asp:ListItem Value="F">Fixed</asp:ListItem>
													<asp:ListItem Value="P">Percentage</asp:ListItem>
												<%--	<asp:ListItem Value="S">Space</asp:ListItem>--%>
												</asp:dropdownlist><asp:textbox id="txtbgamt" onkeypress="return notchar2(event);"  runat="server" Enabled="False"
													MaxLength="5" CssClass="btext1numeric" onblur="javascript:fixper();"></asp:textbox></td>
										</tr>
                                        <tr>
                                            <td style="height: 19px">
                                                <asp:Label ID="lbpub" runat="server" CssClass="TextField" Text="Label"></asp:Label></td>
                                            <td style="height: 19px">
                                                <asp:DropDownList ID="drppub" runat="server" CssClass="dropdowns" Enabled="False">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 19px">
                                                <asp:Label ID="lbedition" runat="server" CssClass="TextField" Text="Label" Width="31px"></asp:Label></td>
                                            <td style="height: 19px">
                                                <asp:DropDownList ID="drpedition" runat="server" CssClass="dropdowns" Enabled="False">
                                                <asp:ListItem Value="0" Selected="True">--Select Edition--</asp:ListItem>
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 19px">
                                                <asp:Label ID="lbcat" runat="server" Text="Label" CssClass="TextField"></asp:Label></td>
                                            <td style="height: 19px">
                                                <asp:DropDownList ID="drpcat" runat="server" CssClass="dropdowns" Enabled="False">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 19px">
                                                <asp:Label ID="lbcat2" runat="server" Text="Label" CssClass="TextField"></asp:Label></td>
                                            <td style="height: 19px">
                                                <asp:DropDownList ID="drpcat2" runat="server" CssClass="dropdowns">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 19px">
                                                <asp:Label ID="lbcat3" runat="server" Text="Label" CssClass="TextField"></asp:Label></td>
                                            <td style="height: 19px">
                                                <asp:DropDownList ID="drpcat3" runat="server" CssClass="dropdowns">
                                                </asp:DropDownList></td>
                                        </tr>
                                         <tr>
                                            <td style="height: 19px">
                                                <asp:Label ID="lbcat4" runat="server" Text="Label" CssClass="TextField"></asp:Label></td>
                                            <td style="height: 19px">
                                                <asp:DropDownList ID="drpcat4" runat="server" CssClass="dropdowns" >
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 19px">
                                                <asp:Label ID="lbcat5" runat="server" Text="Label" CssClass="TextField"></asp:Label></td>
                                            <td style="height: 19px">
                                                <asp:DropDownList ID="drpcat5" runat="server" CssClass="dropdowns" >
                                                </asp:DropDownList></td>
                                        </tr>
                                         
                                        <tr>
                                            <td style="height: 19px">
                                                <asp:Label ID="lbcolortype" runat="server" Text="Label" CssClass="TextField"></asp:Label></td>
                                            <td style="height: 19px">
                                                <asp:DropDownList ID="drpcolortype" runat="server" CssClass="dropdowns" Enabled="False">
                                                </asp:DropDownList></td>
                                        </tr>
									</table>
			<input id="hiddencomcode" type="hidden" size="1" name="hiddencomcode" runat="server"/>
			<input id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server"/> 
			<input id="hiddenDateFormat" type="hidden" size="1" name="Hidden2" runat="server"/>
			<input id="hiddencompcode" type="hidden" size="1" name="hiddencompcode" runat="server"/>
			<input id="hiddenusername" type="hidden" size="2" name="Hidden1" runat="server"/>
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
			<input id="hiddenpubforbg" type="hidden" name="hiddenpubforbg" runat="server" />
			<input id="value" type="hidden" name="value" runat="server" />
		    <input id="ip1" type="hidden" name="ip1" runat="server" />
    
    </form>
</body>
</html>
