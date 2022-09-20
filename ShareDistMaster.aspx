<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShareDistMaster.aspx.cs" Inherits="ShareDistMaster" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<script type="text/javascript" language="javascript" src="javascript/permission.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/ShareDistMast.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/tree.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/treeLibrary.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
</head>
<body id="bdy" onload="loadXML('xml/errorMessage.xml'); return givebuttonpermission('ShareDistMaster');"  onkeydown="javascript:return tabvalue();" <%--onkeydown="if(event.keyCode==13){event.keyCode=9;return event.keyCode;}" --%> onkeypress="eventcalling(event);" >
		<form id="Form1" method="post" runat="server">
			<table id="OuterTable" width="1000" align="center" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="ShareDistMaster" ></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top">
						<table cellspacing="0" cellpadding="0" border="0" id="RightTable" class="RightTable">
							<tr valign="top">
			              <td><asp:button id="btnNew" runat="server" CssClass="topbutton" Height="24px" Font-Bold="true" BorderColor="DarkGray"
							BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Width="63px"></asp:button><asp:button id="btnSave" runat="server" Height="24px" Font-Bold="true" BorderColor="DarkGray"
							BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Width="63px"></asp:button><asp:button id="btnModify" runat="server" Height="24px" Font-Bold="true" BorderColor="DarkGray"
							BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Width="63px"></asp:button><asp:button id="btnQuery" runat="server" Height="24px" Font-Bold="true" BorderColor="DarkGray"
							BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Width="63px"></asp:button><asp:button id="btnExecute" runat="server" Height="24px" Font-Bold="true" BorderColor="DarkGray"
							BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Width="63px"></asp:button><asp:button id="btnCancel" runat="server" Height="24px" Font-Bold="true" BorderColor="DarkGray"
							BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Width="63px"></asp:button><asp:button id="btnfirst" runat="server" Height="24px" Font-Bold="true" BorderColor="DarkGray"
							BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Width="62px"></asp:button><asp:button id="btnprevious" runat="server" Height="24px" Font-Bold="true" BorderColor="DarkGray"
							BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Width="63px"></asp:button><asp:button id="btnnext" runat="server" Height="24px" Font-Bold="true" BorderColor="DarkGray"
							BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Width="63px"></asp:button><asp:button id="btnlast" runat="server" Height="24px" Font-Bold="true" BorderColor="DarkGray"
							BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Width="63px"></asp:button><asp:button id="btnDelete" runat="server" Height="24px" Font-Bold="true" BorderColor="DarkGray"
							BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Width="63px"></asp:button><asp:button id="btnExit" runat="server" Height="24px" Font-Bold="true" BorderColor="DarkGray"
							BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Width="63px"></asp:button></td>
				</tr>
								<tr valign="top" align="left">
									<td>
										<table class="Popupbar" id="table1" style="WIDTH: 755px; HEIGHT: 23px" height="23" cellspacing="0"
											cellpadding="0" width="752" border="0">
											<tr>
												<td bgcolor="#7daae3"></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td height="25"></td>
								</tr>
								<tr>
									<td>
										<table id="table2" align="center" border="0" cellpadding="0" cellspacing="0">
											<tr>
												<td>
													<asp:label id="ShareCode" runat="server" CssClass="TextField"></asp:label></td>
												<td>
													<asp:textbox  id="txtShareCode" onkeypress="return ClientSpecialchar();" runat="server" CssClass="btext1"
														Enabled="False" MaxLength="8"></asp:textbox></td>
											</tr>
											<tr>
												<td >
													<asp:label id="ShareName" runat="server" CssClass="TextField"></asp:label></td>
												<td style="height: 23px">
													<asp:textbox  id="txtSharename" onkeypress="return ClientSpecialchar();" runat="server" CssClass="btext"
														Enabled="False" MaxLength="20"></asp:textbox></td>
											</tr>
											<tr>
												<td></td>
												<td>
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                </td>
											</tr>
											<tr>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</td>
					</tr>
				</table>
				<input id="hiddencompcode" type="hidden" size="14" name="hiddencompcode" runat="server"/>
				<input id="hiddenuserid" type="hidden" size="17" name="hiddenuserid" runat="server"/>
				<input id="hiddenusername" type="hidden" size="1" name="hiddenusername" runat="server"/>
            <input id="hiddenauto" type="hidden" size="1" name="hiddenusername" runat="server"/>
			</form>
		
	</body>
</html>
