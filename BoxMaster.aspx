<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BoxMaster.aspx.cs" Inherits="BoxMaster" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>Display Ad. Booking & Sheduling Box Master</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<script type="text/javascript"language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/BoxMaster.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/permission.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/datevalidation.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/tree.js"></script>
		<%--<script type="text/javascript"language="javascript" src="javascript/TreeLibrary.js"></script>--%>
		<script type="text/javascript"  language="javascript" src="javascript/givepermission.js"></script>
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<script type="text/javascript" language="javascript" >
//		(event.keyCode==37)||
function ClientSpecialchar22()
{
	if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==8)||(event.keyCode==189)||(event.keyCode>=97 && event.keyCode<=122)||(event.keyCode==9 || event.keyCode==32)||(event.keyCode>=65 && event.keyCode<=90)||(event.keyCode==39)||(event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9)||(event.keyCode==46))
	{
		return true;
	}
	else
	{
		return false;
	}
    notchar2();

}
function notchar2()
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

function nc2()
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
	
		
		</script>
		
	    <style type="text/css">
            .style1
            {
                height: 19px;
            }
        </style>
		
	</head>
	<body id="bdy" onload="loadXML('xml/errorMessage.xml');return givebuttonpermission('BoxMaster');" onkeydown="javascript:return tabvalue(event,'txtremark');" onkeypress="eventcalling(event);" style="background-color:#f3f6fd;">
		<form id="Form1" method="post" runat="server">
			
			<table id="OuterTable" cellspacing="0" cellpadding="0" width="1000" border="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" text="Box Master"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top" style="width: 184px"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 796px">
						<table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0" >
							<tr valign="top" style="padding-left:1px">
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
                        <input id="hiddendrop" name="hiddendrop" type="hidden" runat="server" />
					</td>
				</tr>
			</table>
			<table border="0" width="100%" cellpadding="0" cellspacing="0" style="width:auto;margin:15px 30px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Box Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			<table align="center" style="width:auto;margin:30px 170px;" cellpadding="0" cellspacing="0" >
									<tr>
											<td align="left"><asp:Label id="lblpubcenter" runat="server" CssClass="TextField"></asp:Label></td>
											<td align="left"><asp:dropdownlist id="drppubcenter" runat="server" CssClass="dropdown">
													
												</asp:dropdownlist></td>
											
									</tr>
									
									<tr>
											<td align="left" style="height: 21px"><asp:Label id="lblboxcode" runat="server" CssClass="TextField" ></asp:Label></td>
											<td align="left" style="height: 21px"><asp:textbox onkeypress="return ClientSpecialchar(event)" id="txtboxcode" runat="server" CssClass="btext1"
													MaxLength="8"></asp:textbox></td>
													
													<td align="left" style="height: 21px"></td>
										</tr>
										<tr>
											<td align="left" style="height: 19px" ><asp:Label id="lblboxdes" runat="server" CssClass="TextField"></asp:Label></td>
											<td colspan="3" align="left" style="height: 19px"><asp:textbox onkeypress="return ClientSpecialcharDesc(event)" id="txtboxdes" runat="server" CssClass="btextsau"
													MaxLength="50"></asp:textbox></td>
													<td style="height: 19px"></td>
													<td style="height: 19px"></td>
										</tr>
										<tr>
											<td align="left" style="height: 17px"><asp:Label id="lblalias" runat="server" CssClass="TextField"></asp:Label></td>
											<td colspan="3" style="height: 17px" align="left"><asp:textbox onkeypress="return ClientSpecialchar(event);" id="txtalias" runat="server" CssClass="btextsau"
													MaxLength="50"></asp:textbox></td>
													<td style="height: 17px"></td>
													<td style="height: 17px"></td>
								
										</tr>
										<tr>
											<td align="left"><asp:Label id="lbldispatch" runat="server" CssClass="TextField"></asp:Label></td>
											<td align="left"><asp:textbox id="txtdispatch" runat="server" onkeypress="return ClientisNumber(event);" CssClass="btext1" MaxLength="5" onpaste="return false;"></asp:textbox></td>
											<td align="left"></td>
											
										</tr>
										
										<tr>
											<td></td>
											<td></td>
											<td><asp:label id="lblnative" runat="server" CssClass="TextField"></asp:label></td>
											<td style="display:block;width: 218px;" align="center"><asp:label id="lblinter" runat="server" CssClass="TextField"></asp:label></td>
										</tr>
										
										
										<tr>
											<td align="left"><asp:Label id="lblboxcharges" runat="server" CssClass="TextField"></asp:Label></td>
											<td align="left"><asp:dropdownlist id="drpboxcharge" runat="server" CssClass="dropdown">
													<asp:ListItem Value="0">-Select Box Charges-</asp:ListItem>
													<asp:ListItem Value="1">Fixed</asp:ListItem>
													<asp:ListItem Value="2">Percentage</asp:ListItem>
												</asp:dropdownlist></td>
											<td align="left"><asp:TextBox onkeypress="return nc2();" id="txtnative" runat="server" CssClass="btextsmallnumeric"
													MaxLength="20"></asp:TextBox></td>
											<td align="center"><asp:TextBox ID="txtinter" runat="server" CssClass="btextsmallnumeric" MaxLength="20" onkeypress="return nc2();"></asp:TextBox></td>
										</tr>
										<tr>
											<td align="left"><asp:Label id="lblvalidfrom" runat="server" CssClass="TextField"></asp:Label></td>
											<td align="left"><asp:TextBox id="txtvalidfrom" runat="server" CssClass="btext1" MaxLength="10" onkeypress="return datecurr();" onpaste="return fasle;"></asp:TextBox>
											<script type="text/javascript"language="javascript">
																								
															if (!document.layers) 
																{
																document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this,Form1.txtvalidfrom, \"mm/dd/yyyy\")' height=14 width=14> ")
																}
																									
												</script>
											</td>
											<td align="right"><asp:Label id="lblvalidtill" runat="server" CssClass="TextField"></asp:Label></td>
											<td align="center"><asp:TextBox id="txtvalidtill" runat="server" CssClass="btext1" MaxLength="10" onkeypress="return datecurr();" onpaste="return fasle;"></asp:TextBox>
											<script type="text/javascript"language="javascript">
																								
															if (!document.layers) 
																{
																document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this,Form1.txtvalidtill, \"mm/dd/yyyy\")' height=14 width=14> ")
																}
																									
												</script>
											</td>
										</tr>
										<tr>
											<td align="left" class="style1"> <asp:label id="lblremarks" runat="server" CssClass="TextField"></asp:label></td>
											<td colspan="3" align="left" class="style1"><asp:textbox onkeypress="return ClientSpecialchar(event)" id="txtremark" runat="server" CssClass="btextsau"
													MaxLength="50"></asp:textbox></td>
													<td class="style1"></td>
													<td class="style1"></td>
											</tr>
										<tr>
											<td align="left" style="height: 19px"> <asp:label id="lblcheckbox" runat="server" colspan='2'
                                                    CssClass="TextField" Text='Include Box Words With Matter' ></asp:label></td>
											<td colspan="3" align="left" style="height: 19px">
											<asp:CheckBox  runat='Server' ID ='chkmatter' >  </asp:CheckBox>
											
											</td>
													<td style="height: 19px">&nbsp;</td>
													<td style="height: 19px">&nbsp;</td>
											</tr>
                                    </table>
			<input id="hiddencompcode" type="hidden" size="1" name="Hidden1" runat="server" />
			<input id="hiddenuserid" type="hidden" size="1" name="Hidden2" runat="server" />
			<input id="hiddendateformat" type="hidden" size="1" name="Hidden3" runat="server" />
			<input id="Hidden4" type="hidden" size="1" name="Hidden4" runat="server" />
			<input id="hiddenusername" runat="server" type="hidden" size="1" name="hidden" onserverchange="hiddenusername_ServerChange" />
			<input id="hiddenauto" type="hidden" size="1" name="Hidden2" runat="server" />
			<input id="ip1" type="hidden" name="ip1" runat="server" />
		</form>
	</body>
</html>
