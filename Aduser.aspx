<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Aduser.aspx.cs" Inherits="Aduser" EnableEventValidation="false" %>
<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew.ascx" %>  
<%@ Register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
         <title>Ad User</title>
         <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		
		<script type="text/javascript" language="javascript" src="javascript/Adduser.js"></script>
		</head>
<body>
      <form id="frmcat3" method="post" runat="server">
    			<table id="OuterTable" width="980" align="center" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Ad User"></uc1:topbar></td>
				</tr>				
				<tr valign="top">
					<td valign="top" style="width: 179px"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top">
						<table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0">
							<tr valign="top">
							    <%-- <td><asp:button id="btnNew" runat="server" CssClass="topbutton" Width="63px" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px"></asp:button><asp:button id="btnSave" runat="server" Width="63px" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px"></asp:button><asp:button id="btnModify" runat="server" Width="63px" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px"></asp:button><asp:button id="btnQuery" runat="server" Width="63px" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px"></asp:button><asp:button id="btnExecute" runat="server" Width="63px" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px"></asp:button><asp:button id="btnCancel" runat="server" Width="63px" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px"></asp:button><asp:button id="btnfirst" runat="server" Width="62px" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px"></asp:button><asp:button id="btnprevious" runat="server" Width="63px" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px"></asp:button><asp:button id="btnnext" runat="server" Width="63px" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px"></asp:button><asp:button id="btnlast" runat="server" Width="63px" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px"></asp:button><asp:button id="btnDelete" runat="server" Width="63px" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px"></asp:button><asp:button id="btnExit" runat="server" Width="63px" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px" ></asp:button>
								</td>--%>
							</tr>
							<tr align="left" valign="top">
								<td style="height: 42px">
									<table class="Popupbar" width="752"  cellspacing="0" cellpadding="0" border="0"
										style="WIDTH: 755px; HEIGHT: 20px">
										<tr>
											<td></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td style="height: 20px"></td>
							</tr>
							<tr>
								<td>
									<table align="center" cellspacing="0" cellpadding="0">
									<tr>
									       <td style="height: 18px"><asp:label id="Agencyname" runat="server"  CssClass="TextField"></asp:label></td>
									        <td style="height: 18px"><asp:dropdownlist id="drpagency" runat="server" CssClass="dropdown"></asp:dropdownlist></td>
									</tr>
									
									<tr>
									       <td style="height: 20px; padding-top:10px;"><asp:label id="genno" runat="server" CssClass="TextField"></asp:label></td>
									        <td style="height: 20px; padding-top:10px;"><asp:TextBox id="txtgenno" runat="server" CssClass="btext" MaxLength="8"></asp:TextBox></td>
									</tr>
									
									<tr>
									       <td style="height: 19px; padding-top:10px;"><asp:label id="modgenno" runat="server" CssClass="TextField"></asp:label></td>
									        <td style="height: 19px; padding-top:10px;"><asp:TextBox  id="txtmodgenno" runat="server" CssClass="btext" MaxLength="8"></asp:TextBox></td>
									</tr>
										<tr>
										  <td  colspan="2"></td>
										</tr>
										<tr>
										</tr>
										<tr>
										</tr>
										<tr>
										</tr>
										<tr>
										</tr>
										<tr>
										    <td colspan="2">
										         <table width="100%">
										              <tr>
										                 <td align="right" style="height: 24px; padding-top:8px; width: 50%"><asp:Button ID="Submit" runat="server" Width="63px" /></td>
										                 <td align="left" style="height: 24px; padding-top:8px; width: 50%"><asp:Button ID="Exit" runat="server" Width="63px" /></td>
										              </tr>
										         </table>
									     	</td>
										    
										 </tr>
										
										 
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<input id="hiddencomcode" type="hidden" size="1" name="hiddencomcode" runat="server"/>
			<input id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server"/> 
			<input id="hiddenDateFormat" type="hidden" size="1" name="Hidden2" runat="server"/>
			<input id="hiddencompcode" type="hidden" size="1" name="hiddencompcode" runat="server"/>
			<input id="hiddenusername" type="hidden" size="2" name="Hidden1" runat="server"/>
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
		
    
    </form>
</body>
</html>