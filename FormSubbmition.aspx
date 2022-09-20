<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormSubbmition.aspx.cs" Inherits="FormSubbmition" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Form Submition</title>
    <link href="css/main.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
   	<script type="text/javascript"language="javascript" src="javascript/Validations.js"></script>
   	<script type="text/javascript"language="javascript" src="javascript/FormSubbmition.js"></script>
   	<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
   	
</head>
<body onkeydown="javascript:return tabvalue(event,'txtalias');" onload="javascript:return givebuttonpermission('FormSubbmition');" style="background-color:#f3f6fd; margin:0px 0px 0px 0px;">
    <form id="form1" runat="server">
    <table id="OuterTable" width="1000" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="FormSubbmition"></uc1:topbar></td>
				</tr>
				<tr valign="top">
				<asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
					<td valign="top" style="width:25%"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 796px">
						<table style="margin:0px 0px 0px 0px;" id="RightTable" cellspacing="0" cellpadding="0" border="0">
							<tr valign="top">
								<td><asp:UpdatePanel ID="UpdatePanel3" runat="server"><ContentTemplate><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnSave" runat="server" CssClass="topbutton" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnSave_Click" ></asp:ImageButton><asp:ImageButton id="btnModify" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnQuery" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnExecute" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnCancel" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnfirst" CssClass="topbutton" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnprevious" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnnext" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnlast" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnDelete" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnExit" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton></ContentTemplate></asp:UpdatePanel>
								</td>
							</tr>
					</table></td>
					
						   <input id="hiddencompcode" type="hidden" size="14" runat="server" name="hiddencompcode"/>
			<input id="hiddenuserid" type="hidden" size="17" runat="server" name="hiddenuserid"/>
			<input id="hiddenusername" type="hidden" size="1" name="hiddenusername" runat="server" />
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
               <input id="pnew" type="hidden" name="pnew" runat="server" />         
                  <asp:Label ID="d1" runat="server"></asp:Label>      
				</tr>
			</table>
			
			<table border="0" cellpadding="0" cellspacing="0" width="100%" style="width:auto;margin:15px 40px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>FormSubbmition</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
						        <table cellspacing="0" cellpadding="0" align="center" border="0">
						        <tr>
											<td><asp:label id="lblformtype" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:UpdatePanel ID="UpdatePanel4" runat ="server" ><ContentTemplate><asp:dropdownlist id="drpformtype" runat="server" CssClass="dropdown">
											        <asp:ListItem Value="0">--Select Formtype--</asp:ListItem>
											        <asp:ListItem Value="M">Master</asp:ListItem>
													<asp:ListItem Value="R">Reports</asp:ListItem>
													<asp:ListItem Value="T">Transaction</asp:ListItem>
											</asp:dropdownlist></ContentTemplate></asp:UpdatePanel></td>
										</tr>
								 <tr>
											<td><asp:label id="lblmodcode" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:UpdatePanel ID="UpdatePanel5" runat ="server" ><ContentTemplate><asp:dropdownlist id="drpmodcode" runat="server" CssClass="dropdown">
											        <%--<asp:ListItem Value="0">--Select ModuleCode--</asp:ListItem>
											        <asp:ListItem Value="ADB">AdBooking</asp:ListItem>
													<asp:ListItem Value="PAM">PAM</asp:ListItem>
													<asp:ListItem Value="ADA">AD-ACCOUNTS</asp:ListItem>
													<asp:ListItem Value="CIR">CIRCULATION</asp:ListItem>
													<asp:ListItem Value="LAY">LAYOUTX</asp:ListItem>
													<asp:ListItem Value="NEW">NEWSPRINT</asp:ListItem>
													<asp:ListItem Value="PAY">PAYROLL</asp:ListItem>
													<asp:ListItem Value="FIN">FINANCE</asp:ListItem>--%>
											</asp:dropdownlist></ContentTemplate></asp:UpdatePanel></td>
										</tr>
						        
						        <tr>
						        <td><asp:Label ID="lbformid" runat="server" CssClass="TextField" ></asp:Label></td>
						        <td><asp:UpdatePanel ID="update1" runat ="server" ><ContentTemplate><asp:TextBox ID="txtid" runat="server" CssClass ="btext1" Enabled="False" MaxLength="8"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
						        </tr>
						         <tr>
						        <td><asp:Label ID="lbformname" runat="server" CssClass="TextField" ></asp:Label></td>
						        <td><asp:UpdatePanel ID="UpdatePanel1" runat ="server" ><ContentTemplate><asp:TextBox ID="txtname" runat="server" CssClass ="btextlower" MaxLength="30"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
						        </tr>
						        <tr>
						        <td><asp:Label ID="lbalias" runat="server" CssClass="TextField" ></asp:Label></td>
						        <td><asp:UpdatePanel ID="UpdatePanel2" runat ="server" ><ContentTemplate><asp:TextBox ID="txtalias" runat="server" CssClass ="btext" MaxLength="30"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
						        </tr>
						        
						        <tr>
						        <td></td>
						        <%--td align ="right" ><asp:button id="btnsave" runat="server" CssClass="topbutton" Width="63px" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px" OnClick="btnsave_Click"></asp:button></td>
						        </tr>--%>
						   </table>
						   <input id="hidden1" type="hidden" size="5" name="hiddenregion" runat="server" />	
						   
    </form>
</body>
</html>
