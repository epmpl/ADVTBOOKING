<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdBookingIssue1.aspx.cs" Inherits="AdBookingIssue1" EnableEventValidation="false" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//Dtd Xhtml 1.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>Display Ad. Booking & Sheduling Ad Booking Issue</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		
	 
		<script type="text/javascript"language="javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/TreeLibrary.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/permission.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/Tree.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/AdBookingIssue1.js"></script>
		
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
    	<script language=javascript type="text/javascript">
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
        </script>
	</head>
	<body leftMargin="5" bottomMargin="0"  topMargin="0" id="bdy" rightMargin="0"  onkeydown="javascript:return tabvalue('txtnopages');"onload="return givebuttonpermission('AdBookingIssue1');"  >
		<form id="Form1" method="post" runat="server">
			<table id="OuterTable" cellspacing="0" cellpadding="0" width="1000" align="center" border="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Ad Booking Issue"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 796px">
						<table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0">
							<tr valign="top">
								<td><asp:button id="btnNew" runat="server" Width="63px" CssClass="topbutton" Height="24px" BorderStyle="Outset"
										BorderColor="DarkGray" Font-Size="XX-Small" Font-Bold="True" BackColor="Control" OnClick="btnNew_Click"></asp:button><asp:button id="btnSave" runat="server" Width="63px" Height="24px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Size="XX-Small" Font-Bold="True" BackColor="Control"></asp:button><asp:button id="btnModify" runat="server" Width="63px" Height="24px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Size="XX-Small" Font-Bold="True" BackColor="Control"></asp:button><asp:button id="btnQuery" runat="server" Width="63px" Height="24px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Size="XX-Small" Font-Bold="True" BackColor="Control"></asp:button><asp:button id="btnExecute" runat="server" Width="63px" Height="24px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Size="XX-Small" Font-Bold="True" BackColor="Control"></asp:button><asp:button id="btnCancel" runat="server" Width="63px" Height="24px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Size="XX-Small" Font-Bold="True" BackColor="Control"></asp:button><asp:button id="btnfirst" runat="server" Width="62px" Height="24px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Size="XX-Small" Font-Bold="True" BackColor="Control"></asp:button><asp:button id="btnprevious" runat="server" Width="63px" Height="24px" BorderStyle="Outset"
										BorderColor="DarkGray" Font-Size="XX-Small" Font-Bold="True" BackColor="Control"></asp:button><asp:button id="btnnext" runat="server" Width="63px" Height="24px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Size="XX-Small" Font-Bold="True" BackColor="Control"></asp:button><asp:button id="btnlast" runat="server" Width="63px" Height="24px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Size="XX-Small" Font-Bold="True" BackColor="Control"></asp:button><asp:button id="btnDelete" runat="server" Width="63px" Height="24px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Size="XX-Small" Font-Bold="True" BackColor="Control"></asp:button><asp:button id="btnExit" runat="server" Width="63px" Height="24px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Size="XX-Small" Font-Bold="True" BackColor="Control"></asp:button></td>
							</tr>
						
							<tr>
								<td height="25" style="width: 743px"></td>
							</tr>
							<tr>
								<td style="width: 1000px">
									<table align="center" cellpadding="0" cellspacing="0" border="0">
										<tr>
											<td style="height: 18px"><asp:Label id="lblpublication" runat="server" CssClass="TextField"></asp:Label></td>
											<td style="height: 18px"><asp:DropDownList id="drppublication" runat="server" CssClass="dropdown" >
											</asp:DropDownList></td>
										</tr>	
																		
										<tr>
											<td><asp:Label id="lblpubcenter" runat="server" CssClass="TextField"></asp:Label></td>
											<td><asp:DropDownList id="drppubcenter" runat="server" CssClass="dropdown" >
                                            </asp:DropDownList></td>
										</tr>
										<tr>
										<td align="left"><asp:label id="lbledition" runat="server" CssClass="TextField"></asp:label> </td>
											<td align="left"><asp:DropDownList ID="drpedition" runat="server" CssClass="dropdown">
											</asp:DropDownList> </td>
										</tr>
										<tr>
										
											<td align="left"><asp:label id="lblsupplement" runat="server" CssClass="TextField"></asp:label></td>
										<td align="left"><asp:dropdownlist id="drpsuplement" runat="server" CssClass="dropdown">
                                        </asp:dropdownlist></td>
										</tr>
											
										
										   
										    
										    <tr>
										    <td><asp:Label ID="lblbookvolume" runat="server" CssClass="TextField" ></asp:Label></td>
										    <td><asp:TextBox  id="txtbookvolume" runat="server" CssClass="numerictext" MaxLength="6" onkeypress=" return ClientisNumber()"></asp:TextBox></td>
										    
										    </tr>
										
										    <tr>
										    <td><asp:Label ID="lblnopages" runat="server" CssClass="TextField"></asp:Label></td>
										    <td><asp:TextBox ID="txtnopages"   MaxLength="6" runat="server" CssClass="numerictext" onkeypress=" return ClientisNumber()"></asp:TextBox></td>
										    </tr>
							 		</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<input id="hiddencompcode" type="hidden" size="5" name="hiddenregion" runat="server" />
			<input id="hiddenuserid" type="hidden" size="5" name="hiddenregion" runat="server" />
			<input id="hiddensolorate" type="hidden" size="20" name="hiddenregion" runat="server" />
			<input id="dateformat" type="hidden" size="5" name="hiddenregion" runat="server" />
			<input id="hiddendateformat" type="hidden" size="5" name="hiddenregion" runat="server" />
			<input id="hiddenusername" type="hidden" size="1" name="hiddenusername" runat="server" />
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
			<input id="hiddeneditalias" type="hidden" name="hiddeneditalias" runat="server" />
			<input id="hiddeneditdate" type="hidden" name="hiddeneditdate" runat="server" />
	        <input id="hiddeneditaddate" type="hidden" name="hiddeneditaddate" runat="server" />
	        <input id="hiddenid" type="hidden" name="hiddenhid" runat="server" />
            &nbsp;
		</form>
	</body>
</html>
