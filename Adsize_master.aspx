<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Adsize_master.aspx.cs" Inherits="Adsize_master" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>Display Ad. Booking & Sheduling Ad Size Master</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<script type="text/javascript"  language="javascript" src="javascript/Adsize.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/TreeLibrary.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/permission.js"></script>
		<script language="javascript" src="javascript/givepermission.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/entertotab.js"></script>
		
		<script type="text/javascript" language="javascript">
		if(navigator.appName.indexOf("Microsoft")!=-1)
	{
		document.writeln('<LINK href ="css/main.css" type= "text/css" rel = "stylesheet">');
	}
	else
	{
	document.writeln('<LINK href ="css/main_mozilla.css" type= "text/css" rel = "stylesheet">');
	}
	
		
		/*function multiple()
		{
		var adsize=document.getElementById('txtadvsizecode').value;
		
		if(adsize!=null && adsize!="")
		{
		//window.open('multi_adsize.aspx');
		window.open('multi_adsize.aspx?adsize='+adsize,'xyz','status=0,toolbar=0,resizable=1,top=190,left=580,width=200px,height=130px');
		return false;
		}
		else
		{
		alert("Please Fill Ad Size Code");
		return false;
		}
		
		}*/
		
		function notchar2()
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

//var a=Adsize_master
		
</script>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <link href="css/main.css" type="text/css" rel="stylesheet"/>
        <link href="css/webcontrol.css" type="text/css" rel="stylesheet" />
      <link href="css/agencytypemaster.css" type="text/css" rel="stylesheet" />
        
</head>		
<body  id="bdy" onload="javascript:return clearaddsize();" onkeydown="javascript:return tabvalue(event,'txtremarks');" style="background-color:#f3f6fd;">
		<form id="Form1" method="post" runat="server">
			<%--<table id="OuterTable" width="1000" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" text="Adv Size Master"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top" style="width: 184px"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
				
					<td valign="top" style="width: 796px">
						<table cellspacing="0" cellpadding="0"  border="0" id="RightTable" class="RightTable">
							<tr valign="top">--%>
             <table id="OuterTable" width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server"  text="Adv Size Master"></uc1:topbar></td>
				</tr>
				<tr valign="top" style="width:100%">
					
                    <td valign="top" class="rel"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar>
                    </td>
					<td valign="top" style="width: 81.6%">
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
			<table border="0" cellpadding="0" cellspacing="0" width=100% class="bar4css">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Adv Size Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
            <table class="styl33"cellpadding="0" cellspacing="0" >	
                    <tr>
							<td>
								<asp:linkbutton id="lbadtype" runat="server" CssClass="btnlink_n" Font-Underline="False" Visible="false">Advertisement Type</asp:linkbutton>
							</td>
					</tr>
			</table>
			<table cellpadding="0" cellspacing="0" border="0" class="styl34">
										<tr>
											<td><asp:label id="Label2" runat="server" CssClass="textfield3">Adv Type<font color="red">*</font></asp:label></td>
											<td><asp:dropdownlist id="txtadvtype" runat="server" CssClass="dropdownsize" Enabled="False"></asp:dropdownlist></td>
										</tr>
										<tr>
											<td><asp:label id="Label3" runat="server" CssClass="textfield3">Adv Category<font color="red">
														*</font></asp:label></td>
											<td><asp:ListBox id="lbadcategory" runat="server"   SelectionMode="Multiple" CssClass="texttable" Enabled="False"></asp:ListBox><asp:button id="btnmulti" runat="server" CssClass="button1" Height="18px" Text="Multi" Visible="false"></asp:button></td>
										</tr>
										<tr>
											<td><asp:label id="Label9" runat="server" CssClass="TextField" >Package<font color="red">*</font></asp:label></td>
											<td><asp:ListBox id="drpedition"  runat="server" class="packagesize"  SelectionMode="Multiple"  Enabled="False" readonly="true"></asp:ListBox></td>
										</tr>
										<tr>
											<td><asp:label id="Label10" runat="server" CssClass="TextField">Adv Size Code<font color="red">
														*</font></asp:label></td>
											<td><asp:textbox onkeypress="return notchar0();" id="txtadvsizecode" runat="server" CssClass="btext1adsize"
													Enabled="False" MaxLength="6"></asp:textbox></td>
										</tr>
										<tr>
											<td><asp:label id="Label11" runat="server" CssClass="TextField">Adv Size Description<font color="red">
														*</font></asp:label></td>
											<td><asp:textbox onkeypress="return notchar0();" id="txtadvdescription" runat="server" CssClass="btext"
													Enabled="False" MaxLength="50"></asp:textbox></td>
										</tr>
										<tr>
										  <td><asp:Label ID="Height" runat="server" CssClass="TextField">Normal Height</asp:Label></td>
										  <td><asp:TextBox ID="txtheight1" runat="server" CssClass="btext1adsize" onkeypress="return notchar2();" onpaste="return false;" MaxLength="5"></asp:TextBox></td>
										</tr>
										<tr>
										  <td><asp:Label ID="Width" runat="server" CssClass="TextField">Normal Width</asp:Label></td>
										  <td><asp:TextBox ID="txtwidth1" runat="server" CssClass="btext1adsize" onkeypress="return notchar2();" onpaste="return false;" MaxLength="5"></asp:TextBox></td>
										</tr>
										<tr>
										  <td><asp:Label ID="lblcol" runat="server" CssClass="TextField">Column</asp:Label></td>
										  <td><asp:TextBox ID="txtcol" runat="server" CssClass="btext1adsize" onkeypress="return notchar2();" onpaste="return false;" MaxLength="5"></asp:TextBox></td>
										</tr>
										<tr>
											<td style="HEIGHT: 4px"><asp:label id="Label12" runat="server" CssClass="TextField">Color<font color="red">*</font></asp:label></td>
											<td style="HEIGHT: 4px"><asp:dropdownlist id="drpcolor" runat="server" CssClass="dropdownsize" Enabled="False"></asp:dropdownlist></td>
										</tr>
										<tr>
											<td style="HEIGHT: 16px"><asp:label id="Label13" runat="server" CssClass="TextField">UOM<font color="red">*</font></asp:label></td>
											<td style="HEIGHT: 16px"><asp:dropdownlist id="drpuom" runat="server" CssClass="dropdownsize" Enabled="False"></asp:dropdownlist>
												<asp:dropdownlist id="drpuomnew" style="display:none" runat="server" CssClass="dropdownsize" Enabled="False">
												</asp:dropdownlist></td>
										</tr>
										<tr>
											<td><asp:label id="Label14" runat="server" CssClass="TextField">Remarks</asp:label></td>
											<td><asp:textbox id="txtremarks" runat="server" CssClass="btext" Enabled="True" MaxLength="50"></asp:textbox></td>
										</tr>
										<%--<tr>
											<td colspan="2"><asp:label id="Label15" runat="server" CssClass="textfield">Add Ads will be charged at maximum Width Rate If Width is between</asp:label><asp:label id="Label16" runat="server" Width="14px"></asp:label><asp:textbox onkeypress="return notchar2();" id="txtwidth1" runat="server" Enabled="False" MaxLength="4"
													Width="40px" CssClass="btext1007"></asp:textbox>&nbsp;<asp:label id="Label18" runat="server" Width="16px">to</asp:label><asp:textbox onkeypress="return notchar2();" id="txtwidth2" runat="server" Enabled="False" MaxLength="4"
													Width="40px" CssClass="btext1007"></asp:textbox></td>
										</tr>
										<tr>
											<td colspan="2"><asp:label id="Label17" runat="server" CssClass="textfield" Width="418px">Add Ads will be charged at maximum Height Rate If Height is between</asp:label><asp:label id="Label19" runat="server"></asp:label><asp:textbox onkeypress="return notchar2();" id="txtheight1" runat="server" Enabled="False" MaxLength="4"
													Width="40px" CssClass="btext1007"></asp:textbox>&nbsp;<asp:label id="Label20" runat="server" Width="16px">to</asp:label><asp:textbox onkeypress="return notchar2();" id="txtheight2" runat="server" Enabled="False" MaxLength="4"
													Width="40px" CssClass="btext1007"></asp:textbox></td>
										</tr>--%>
									</table>
			<input  id="hiddencompcode" type="hidden" runat="server" name="hiddencompcode"/> 
			<input id="hiddenuserid" type="hidden" runat="server" name="hiddenuserid"/>
			<input id="hiddenpermission" runat="server" type="hidden" name="hiddenpermission"/>
			<input id="hiddenusername" runat="server" type="hidden" size="1" name="hiddenusername" onserverchange="hiddenusername_ServerChange"/>
			<input id="hiddenuom" type="hidden" name="hiddenuom" runat="server" />
		</form>
	</body>
</html>
