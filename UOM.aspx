<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UOM.aspx.cs" Inherits="UOM" %>
<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx" %>  
<%@ Register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>Display Ad. Booking & Sheduling UOM Master</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
        <link href="css/webcontrol.css" type="text/css" rel="stylesheet" />
     <link href="css/agencytypemaster.css" type="text/css" rel="stylesheet" />
		<script type="text/javascript" language="javascript" src="javascript/tree.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/TreeLibrary.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/UOM.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/permission.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
       <script language="javascript" src="javascript/prototype.js" type="text/javascript"></script>
     
        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
		<script type="text/javascript" language="javascript">
			function uppercase(a)
			{
			
			document.getElementById(a).value=document.getElementById(a).value.toUpperCase();
			return ;
			
			}
			function notchar0(event)
	{
	var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer")
 {

	if((event.which>=48 && event.which<=57)||
	(event.which==127)||
	(event.which>=97 && event.which<=122)||
	(event.which>=65 && event.which<=90)||
	(event.which==9 || event.which==32 ) || event.which==0)
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
	(event.keyCode==127)||
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
	}
	
	
	
	function notchar2(event)
{
var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer")
 {
        if((event.which>=48 && event.which<=57)||(event.which==127)||(event.which==8)||(event.which==9)||(event.which==46) || (event.which==0))
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
         if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9)||(event.keyCode==46))
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
	</head>
	<body leftMargin="5" topmargin="0" id="bdy" onload="javascript:return clearuom();" onkeydown="javascript:return chkenterndtab(event);" <%--onkeydown="if(event.keyCode==13){event.keyCode=9;return event.keyCode;}"--%> onkeypress="eventcalling(event);" style="background-color:#f3f6fd;"> 
		
		<form id="Form1" method="post" runat="server">
            <div id="divservicecode" style="position: absolute; top: 0px; left: 0px; border: none;
        display: none; z-index: 1;">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:ListBox ID="lstservicecode" Width="210px" Height="95px" runat="server" CssClass="btextlist">
                    </asp:ListBox>
                </td>
            </tr>
        </table>
    </div>
           
        <div id="divsubservicecode" style="position: absolute; top: 0px; left: 0px; border: none;
        display: none; z-index: 1;">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:ListBox ID="lstsubservicecode" Width="210px" Height="95px" runat="server" CssClass="btextlist">
                    </asp:ListBox>
                </td>
            </tr>
        </table>
    </div>
			<%--<table id="OuterTable" width="1000"  border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="UOM Master"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 796px">
						<table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0">
							<tr valign="top">--%>
              <table id="OuterTable" width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server"  Text="UOM Master"></uc1:topbar></td>
				</tr>
				<tr valign="top" style="width:100%">
					
                    <td valign="top" class="rel"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar>
                    </td>
					<td valign="top" style="width: 81.6%">
						<table class="RightTable" id="RightTable" cellpadding="0" cellspacing="0" border="0">
							<tr valign="top" >
					<td><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnSave" runat="server" CssClass="topbutton" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnSave_Click"></asp:ImageButton><asp:ImageButton id="btnModify" runat="server"  Font-Size="XX-Small" BackColor="Control"
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
			<table border="0" cellpadding="0" cellspacing="0" width=100% class="bar3css">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>UOM Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			<table cellpadding="0" cellspacing="0" border="0" class="styl32">
						<tr><td><asp:label id="lbladtype" runat="server" CssClass="TextField"></asp:label></td>
						<td><asp:DropDownList Enabled="false" ID="drpadtype" runat="server" CssClass="dropdownuom"></asp:DropDownList></td>
						</tr>
							<tr>
								<td><asp:label id="Label1" runat="server" CssClass="TextField"></asp:label></td>
								<td><asp:textbox onkeypress="return notchar0(event);" id="txtuomcode" runat="server" CssClass="btext1uom"
										Enabled="False" MaxLength="8"></asp:textbox></td>
							</tr>
                            <tr>
                                <td style="height: 18px">
                                    <asp:Label ID="lbtype" runat="server" CssClass="TextField"></asp:Label></td>
                                <td style="height: 18px">
                                    <asp:DropDownList Enabled="false" ID="drpuomtype" runat="server" CssClass="dropdownuom">
                                    <asp:ListItem Selected="True" Value="0">Select Type</asp:ListItem>
                                    <asp:ListItem  Value="3">Classified</asp:ListItem>
                                    <asp:ListItem  Value="4">Display</asp:ListItem>
                                    <asp:ListItem  Value="2">Web</asp:ListItem>
                                    <asp:ListItem  Value="1">Weight</asp:ListItem>
                                      <asp:ListItem  Value="5">Tv</asp:ListItem>
                                    </asp:DropDownList>
                                  </td>
                            </tr>
                            <tr>
                                <td style="height: 18px">
                                    <asp:Label ID="lbaddesc" runat="server" CssClass="TextField"></asp:Label></td>
                                <td style="height: 18px">
                                    <asp:DropDownList Enabled="false" ID="drpaddesc" runat="server" CssClass="dropdownuom">
                                        <asp:ListItem Selected="True" Value="0">Select Uom Desc</asp:ListItem>
                                        <asp:ListItem Value="3">Classified</asp:ListItem>
                                       <asp:ListItem Value="2">Web</asp:ListItem>
                                       <asp:ListItem Value="1">Weight</asp:ListItem>
                                       </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td style="height: 18px">
                                    <asp:Label ID="lblogo" runat="server" CssClass="TextField"></asp:Label></td>
                                <td style="height: 18px">
                                    <asp:DropDownList ID="drplogo" runat="server" CssClass="dropdownuom" Enabled="false"><asp:ListItem Selected="True" Value="0">Select Logo</asp:ListItem>
                                    <asp:ListItem Value="no">No</asp:ListItem>
                                    <asp:ListItem Value="yes">Yes</asp:ListItem></asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td style="height: 18px">
                                    <asp:Label ID="logouom" runat="server" CssClass="TextField"></asp:Label></td>
                                <td style="height: 18px">
                                    <asp:TextBox ID="txtlogouom" runat="server" CssClass="btext1uom" Enabled="False" MaxLength="8"
                                        onkeypress="return ClientSpecialchar(event);"></asp:TextBox></td>
                            </tr>
							<tr>
								<td><asp:label id="Label2" runat="server" CssClass="TextField"></asp:label></td>
								<td><asp:textbox onkeypress="return ClientSpecialchar(event)" id="txtuomdesc" runat="server" CssClass="btext"
										Enabled="False" MaxLength="20"></asp:textbox></td>
							</tr>
							<tr>
								<td style="height: 21px"><asp:label id="Label3" runat="server" CssClass="TextField"></asp:label></td>
								<td style="height: 21px"><asp:textbox onkeypress="return ClientSpecialchar(event)" id="txtalias" runat="server" CssClass="btext"
										Enabled="False" MaxLength="20" OnTextChanged="txtalias_TextChanged"></asp:textbox></td>
							</tr>
							<tr>
								<td style="height: 21px"><asp:label id="lbSampleImg" runat="server" CssClass="TextField"></asp:label></td>
								<td style="height: 21px"><asp:textbox onkeypress="return ClientSpecialchar(event)" id="txtSampleImg" runat="server" CssClass="btext"
										Enabled="False" MaxLength="30"></asp:textbox></td>
							</tr>
							<tr>
								<td style="height: 21px"><asp:label id="lbStyleSheet" runat="server" CssClass="TextField"></asp:label></td>
								<td style="height: 21px"><asp:textbox onkeypress="return ClientSpecialchar(event)" id="txtStyleSheet" runat="server" CssClass="btext"
										Enabled="False" MaxLength="50"></asp:textbox></td>
							</tr>
							
							
							</tr>
							<tr>
								<td style="height: 21px"><asp:label id="lblcolumn" runat="server" CssClass="TextField"></asp:label></td>
								<td style="height: 21px"><asp:textbox onkeypress="return ClientSpecialchar(event)" id="txtcol" runat="server" CssClass="btext"
										Enabled="False" MaxLength="50"></asp:textbox></td>
							</tr>
							
							
							</tr>
							<tr>
								<td style="height: 21px"><asp:label id="lblguttwid" runat="server" CssClass="TextField"></asp:label></td>
								<td style="height: 21px"><asp:textbox onkeypress="return notchar2(event);"  id="txtguttwid" runat="server" CssClass="btext"
										Enabled="False" MaxLength="50"></asp:textbox></td>
							</tr>
							
							
							</tr>
							<tr>
								<td style="height: 21px"><asp:label id="lblcolwid" runat="server" CssClass="TextField"></asp:label></td>
								<td style="height: 21px"><asp:textbox onkeypress="return notchar2(event);"  id="txtcolwid" runat="server" CssClass="btext"
										Enabled="False" MaxLength="50"></asp:textbox></td>
							</tr>
							<tr>
                         <td style="height: 18px">
                            <asp:Label ID="lblsrvcacc" runat="server" CssClass="TextField"></asp:Label>
                        </td>
                        <td style="height: 18px">
                            <asp:TextBox ID="txtsrvcacc" runat="server" CssClass="Textfield" Font-Size="10px" Width="160px"></asp:TextBox>
                        </td>
                                </tr>
                <tr>
                        <td style="height: 18px">
                            <asp:Label ID="lblsubsrvacc" runat="server" CssClass="TextField"></asp:Label>
                        </td>
                        <td style="height: 18px">
                            <asp:TextBox ID="txtsubsrvcacc" runat="server" CssClass="Textfield" > </asp:TextBox>
                        </td>
                    </tr>
							</table>
			<input id="hiddencompcode" type="hidden" size="14" runat="server" NAME="hiddencompcode"/>
            <input id="hiddendateformat" type="hidden" runat="server" name="hiddendateformat" />
			<input id="hiddenuserid" type="hidden" size="17" runat="server" NAME="hiddenuserid"/>
			<input id="hiddenusername" type="hidden" size="1" name="hiddenusername" runat="server" />
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
		    <input id="ip1" type="hidden" name="ip1" runat="server" />
                    <input id="hdnsrvcacc" type="hidden" name="hdnsrvcacc" runat="server" />
        <input id="hdnsubsrvcacc" type="hidden" name="hdnsubsrvcacc" runat="server" />
		</form>
	</body>
</html>
