<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cat_mapping.aspx.cs" Inherits="cat_mapping" %>
<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew.ascx" %>  
<%@ Register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
         <title>Category Mapping</title>
         <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		
		
		<script language="javascript" type="text/javascript" src="javascript/permission.js"></script>
		<script language="javascript" src="javascript/tree.js"type="text/javascript" ></script>
		<script type="text/javascript" language="javascript" src="javascript/TreeLibrary.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		
		
		
		
		<script type="text/javascript" language="javascript" src="javascript/cat_map.js"></script>
		<%--<script type="text/javascript" language="javascript" src="javascript/adcat3.js"></script>--%>
		</head>

<body onkeypress="eventcalling(event);"onkeydown="tabvalue('txtalias');"onload="javascript:return givebuttonpermission('cat_mapping');">
      <form  method="post" runat="server">
    			<table id="OuterTable" width="980" align="center" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Category Mapping"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top" style="width: 179px"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top">
						<table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0">
							<tr valign="top">
								<td><asp:button id="btnNew" runat="server" CssClass="topbutton" Width="63px" Font-Size="XX-Small"
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
								</td>
							</tr>
							<tr align="left" valign="top">
								<td >
									<table class="Popupbar" width="752"  cellspacing="0" cellpadding="0" border="0"
										>
										<tr>
											<td bgcolor="#7daae3"></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td style="height:20px"></td>
							</tr>
							<tr>
								<td>
									<table align="center" cellspacing="0" cellpadding="0">
									<tr>
                                        <td>
                                        </td>
									       <td>
                                               <asp:Label ID="lb1" runat="server" CssClass="TextField"></asp:Label></td>
									        <td >
                                                <asp:DropDownList ID="drpsouregion" runat="server" CssClass="dropdown" Enabled="False">
                                                </asp:DropDownList></td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td >
                                        </td>
                                        <td>
                                        </td>
                                        <td >
                                            <asp:Label ID="lb8" runat="server" CssClass="TextField"></asp:Label></td>
                                        <td>
                                            <asp:DropDownList ID="drpdesedition" runat="server" CssClass="dropdown" Enabled="False">
                                            </asp:DropDownList></td>
									</tr>
										<tr>
                                            <td>
                                            </td>
										    <td>
                                                <asp:Label ID="lb2" runat="server" CssClass="TextField"></asp:Label></td>
											<td >
                                                <asp:DropDownList ID="drpsouvariable" runat="server" CssClass="dropdown" Enabled="False">
                                                </asp:DropDownList></td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td >
                                            </td>
                                            <td>
                                            </td>
                                            <td >
                                                <asp:Label ID="lb9" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="drpdesregion" runat="server" CssClass="dropdown" Enabled="False">
                                                </asp:DropDownList></td>
											
										</tr>
										<tr>
                                            <td >
                                            </td>
											<td >
                                                <asp:Label ID="lb3" runat="server" CssClass="TextField"></asp:Label></td>
											<td >
                                                <asp:DropDownList ID="drpsoucat1" runat="server" CssClass="dropdown" Enabled="False">
                                                </asp:DropDownList></td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td >
                                            </td>
                                            <td >
                                            </td>
                                            <td >
                                                <asp:Label ID="lb10" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td >
                                                <asp:DropDownList ID="drpdesvariable" runat="server" CssClass="dropdown" Enabled="False">
                                                </asp:DropDownList></td>
													
										</tr>
										<tr>
                                            <td >
                                            </td>
											<td ><asp:label id="lb4" runat="server" CssClass="TextField"></asp:label></td>
											<td >
                                                <asp:DropDownList ID="drpsoucat2" runat="server" CssClass="dropdown" Enabled="False">
                                                </asp:DropDownList></td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td >
                                            </td>
                                            <td >
                                            </td>
                                            <td >
                                                <asp:Label ID="lb11" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td >
                                                <asp:DropDownList ID="drpdescat1" runat="server" CssClass="dropdown" Enabled="False">
                                                </asp:DropDownList></td>
										</tr>
                                        <tr>
                                            <td >
                                            </td>
                                            <td >
                                                <asp:Label ID="lb5" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td >
                                                <asp:DropDownList ID="drpsoucat3" runat="server" CssClass="dropdown" Enabled="False">
                                                </asp:DropDownList></td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td >
                                            </td>
                                            <td >
                                            </td>
                                            <td >
                                                <asp:Label ID="lb12" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td >
                                                <asp:DropDownList ID="drpdescat2" runat="server" CssClass="dropdown" Enabled="False">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td >
                                            </td>
                                            <td >
                                                <asp:Label ID="lb6" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td >
                                                <asp:DropDownList ID="drpsoucat4" runat="server" CssClass="dropdown" Enabled="False">
                                                </asp:DropDownList></td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td >
                                            </td>
                                            <td >
                                            </td>
                                            <td >
                                                <asp:Label ID="lb13" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td >
                                                <asp:DropDownList ID="drpdescat3" runat="server" CssClass="dropdown" Enabled="False">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td >
                                            </td>
                                            <td >
                                                <asp:Label ID="lb7" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td >
                                                <asp:DropDownList ID="drpsoucat5" runat="server" CssClass="dropdown" Enabled="False">
                                                </asp:DropDownList></td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td >
                                            </td>
                                            <td >
                                            </td>
                                            <td >
                                                <asp:Label ID="lb14" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td >
                                                <asp:DropDownList ID="drpdescat4" runat="server" CssClass="dropdown" Enabled="False">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td >
                                            </td>
                                            <td >
                                            </td>
                                            <td >
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td >
                                            </td>
                                            <td >
                                            </td>
                                            <td >
                                                <asp:Label ID="lb15" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td >
                                                <asp:DropDownList ID="drpdescat5" runat="server" CssClass="dropdown" Enabled="False">
                                                </asp:DropDownList></td>
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