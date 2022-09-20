<%@ Page Language="C#" AutoEventWireup="true" CodeFile="region_master.aspx.cs" Inherits="region_master" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Display Sheduling Region Master</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
        <meta content="C#" name="CODE_LANGUAGE"/>
        <meta content="JavaScript" name="vs_defaultClientScript"/>
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
        <script type="text/javascript" language="javascript" src="javascript/regiom_master.js"></script>
        <script type="text/javascript" language="javascript" src="javascript/Validations.js"></script>
        <script type="text/javascript" language="javascript" src="javascript/tree.js"></script>
        <script type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>
        <script type="text/javascript" language="javascript" src="javascript/TreeLibrary.js"></script>
        <script type="text/javascript" language="javascript" src="javascript/permission.js"></script>
        <script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
        <script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>

        <style type="text/css">.style1 { FONT-WEIGHT: bold; COLOR: #ffffff; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif }
        .style2 { COLOR: #ffffff }
        </style>

        <script type="text/javascript" language="javascript">	
		
	
	function uppercase()
		{
		document.getElementById('txtregioncode').value=document.getElementById('txtregioncode').value.toUpperCase();
		return ;
		}
		
		function uppercase2()
		{
		document.getElementById('txtalias').value=document.getElementById('txtalias').value.toUpperCase();
		return ;
		}
		
		
			
			function charval()
		{

			if((event.keyCode>=48 && event.keyCode<=57)||
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

<meta name="viewport" content="width=device-width, initial-scale=1.0" />
<link href="css/main.css" type="text/css" rel="stylesheet" />
<link href="css/webcontrol.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0"  id="bdy" onkeypress="return eventcalling(event);" onload="loadXML('xml/errorMessage.xml');return givebuttonpermission('region_master');" onkeydown="javascript:return tabvalue(event,'txtalias');" style="background-color:#f3f6fd;">
		<form id="Form1" method="post" runat="server">
    <table id="OuterTable" width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server"   Text="Region Master" ></uc1:topbar></td>
				</tr>
				<tr valign="top" style="width:100%">
					
                    <td valign="top" class="rel"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 82.6%">
						<table class="RightTable" id="RightTable" cellpadding="0" cellspacing="0" border="0">
							<tr valign="top" >
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
			<table border="0"  class="barcss" cellpadding="0" cellspacing="0" >
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Region Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			<table class="sty14"  cellpadding="0" cellspacing="0" >
			                            <tr>
					                        <td><asp:Label id="lbzone" runat="server" CssClass="TextField"></asp:Label></td>
					                        <td><asp:DropDownList  id="drzone" runat="server" CssClass="dropdown"
							                        MaxLength="8"></asp:DropDownList></td>
				                        </tr>
										<tr>
											<td><asp:label id="lbregioncode" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox id="txtregioncode" runat="server" CssClass="btext1" MaxLength="8"></asp:textbox></td>
										</tr>
										<tr>
											<td ><asp:label id="lbregionname" runat="server" CssClass="TextField"></asp:label></td>
											<td ><asp:textbox id="txtregionname" runat="server" CssClass="btext" MaxLength="30"></asp:textbox></td>
											<td ></td>
										</tr>
										<tr>
											<td><asp:label id="lbalias" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox id="txtalias" runat="server" CssClass="btext"  MaxLength="30"></asp:textbox></td>
										</tr>
                                        <tr>
                                        <td><asp:label id="lblintegration" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox onkeypress="return ClientisNumber(event)"  id="txtintegration" 
                                                    runat="server" CssClass="btextmailcompname"
													MaxLength="20" Width="419px"></asp:textbox></td></tr>
									</table>
			<input id="hiddenuserid" type="hidden" runat="server" size="1" name="hiddenuserid" />
			<input id="hiddencompanycode" type="hidden" size="1" name="Hidden1" runat="server"/>
			<input id="hiddencompcode" type="hidden" size="1" name="hiddencompcode" runat="server"/>
			<input id="hiddenusername" type="hidden" size="1" name="hiddenusername" runat="server" />
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
		
		</form>
	</body>
</html>
