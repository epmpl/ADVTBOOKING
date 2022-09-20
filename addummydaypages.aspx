<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addummydaypages.aspx.cs" Inherits="addummydaypages" EnableEventValidation="false" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Duisplay Ad Dummy Day Pages</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
	<meta content="C#" name="CODE_LANGUAGE"/>
	<meta content="JavaScript" name="vs_defaultClientScript"/>
	<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
	<script type="text/javascript"language="javascript" src="javascript/popupcalender.js"></script>
	<script language="javascript" type="text/javascript"src="javascript/Validations.js"></script>
	<script type="text/javascript"language="javascript" src="javascript/addummydaypages.js"></script>
	<script language="javascript" type="text/javascript"src="javascript/permission.js"></script>
	<script language="javascript" type="text/javascript"src="javascript/TreeLibrary.js"></script>
	<script type="text/javascript"language="javascript" src="javascript/tree.js"></script>
	<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
	<%--<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>--%>
	<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
	<%-- <script type="text/javascript"language="javascript" src="javascript/datevalidation.js"></script>--%>
	<link href="css/main.css" type="text/css" rel="stylesheet"/>
	
	<script type="text/javascript" language="javascript">
	
    function notchar2()
    {
        if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9))
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
<body onkeydown="javascript:return tabvalue('txtTo');" onload="javascript:return givebuttonpermission('addummydaypages');">
    <form id="form1" method="post" runat="server">
        <table id="OuterTable" width="1000" align="center" border="0" cellpadding="0" cellspacing="0">
            <tr valign="top">
			    <td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Ad dummy pages"></uc1:topbar></td>
			</tr>
			<tr valign="top">
			    <td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
			    <td valign="top">
			        <table cellspacing="0" cellpadding="0" border="0" id="RightTable" class="RightTable" style="height: 39px">
                        <tr valign="top">
						    <td style="height: 24px"><asp:button id="btnNew" runat="server" CssClass="topbutton" Width="63px" Font-Size="XX-Small"
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
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px"></asp:button>
								</td>
						</tr>			            
			        </table>
			        <table cellspacing="0" cellpadding="0" align="center" border="0" >
			            <tr>
						    <td><asp:label id="lbDay" runat="server" CssClass="TextField"></asp:label></td>
							<td>
                                <asp:DropDownList ID="drpDay" runat="server" CssClass="dropdown">
                                    <asp:ListItem Value="0">----Select Day----</asp:ListItem>
                                    <asp:ListItem Value="MON">MONDAY</asp:ListItem>
                                    <asp:ListItem Value="TUE">TUESDAY</asp:ListItem>
                                    <asp:ListItem Value="WED">WEDNESSDAY</asp:ListItem>
                                    <asp:ListItem Value="THU">THURSDAY</asp:ListItem>
                                    <asp:ListItem Value="FRI">FRIDAY</asp:ListItem>
                                    <asp:ListItem Value="SAT">SATURDAY</asp:ListItem>
                                    <asp:ListItem Value="SUN">SUNDAY</asp:ListItem>
                                </asp:DropDownList>
                            </td>
						</tr>
						<tr>
						    <td><asp:label id="lbPName" runat="server" CssClass="TextField"></asp:label></td>
						    <td>
                                <asp:DropDownList ID="drpPName" runat="server" CssClass="dropdown">
                                </asp:DropDownList>
                            </td>
						</tr>
						<tr>
						    <td>
						        <asp:label id="lbPCName" runat="server" CssClass="TextField"></asp:label>
						    </td>
						    <td>
                                <asp:DropDownList ID="drpPCName" runat="server" CssClass="dropdown">
                                </asp:DropDownList>
						    </td>
						</tr>
						<tr>
						    <td>
						        <asp:label id="lbEdition" runat="server" CssClass="TextField"></asp:label>
						    </td>
						    <td>
                                <asp:DropDownList ID="drpEdition" runat="server" CssClass="dropdown">
                                </asp:DropDownList>
						    </td>
						</tr>
						<tr>
						    <td>
						        <asp:label id="lbSuppliment" runat="server" CssClass="TextField"></asp:label>
						    </td>
						    <td>
                                <asp:DropDownList ID="drpSuppliment" runat="server" CssClass="dropdown">
                                </asp:DropDownList>
						    </td>
						</tr>
						<tr>
						    <td>
						        <asp:label id="lbNPages" runat="server" CssClass="TextField"></asp:label>
						    </td>
						    <td>
						        <asp:TextBox ID="txtNPages" runat="server" CssClass="btext1numeric" onkeypress="return ClientisNumber();"></asp:TextBox>
						    </td>
						</tr>
						<tr>
						    <td>
						        <asp:label id="lbFrom" runat="server" CssClass="TextField"></asp:label>
						    </td>
						    <td>
                                <asp:TextBox ID="txtFrom" runat="server" CssClass="btext1" onkeypress="return ClientisNumber();"></asp:TextBox>
                                <script type="text/javascript"language="javascript">										
			                        if (!document.layers)
									{
									    document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtFrom, \"mm/dd/yyyy\")' onfocus=abc();  height=14 width=14> ")
									}										
								</script>
						    </td>
						</tr>
						<tr>
						    <td>
						        <asp:label id="lbTo" runat="server" CssClass="TextField"></asp:label>
						    </td>
						    <td>
                                <asp:TextBox ID="txtTo" runat="server" CssClass="btext1" onkeypress="return ClientisNumber();"></asp:TextBox>
                                <script type="text/javascript"language="javascript">
			                        if (!document.layers)
									{
									    document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtTo, \"mm/dd/yyyy\")' onfocus=abc();  height=14 width=14> ")
									}										
								</script>
						    </td>
						</tr>
			        </table>
			    </td>
			</tr>
        </table>
    	<input id="hiddencompcode" type="hidden" size="1" runat="server" name="hiddencompcode"/>
		<input id="hiddenchk" type="hidden" size="1" runat="server" name="hiddenvalue"/>
		<input id="hiddencentcode" type="hidden" size="1" runat="server" name="hiddencentcode"/>
		<input id="hiddenuserid" type="hidden" size="1" runat="server" name="hiddenuserid"/>
		<input id="hiddendateformat" type="hidden" size="1" runat="server" name="hiddenDateFormat"/>
		&nbsp;
		<input id="hiddenusername" type="hidden" size="1" name="hiddenusername" runat="server"/>
	    <input id="hiddenauto" type="hidden" size="1" name="hiddenuserid" runat="server" />
	    <input id="hiddensaurabh" type="hidden" size="1" name="hiddensaurabh" runat="server" />
	    <input id="hidden1" type="hidden" size="1" name="hiddensaurabh" runat="server" />
	    <input id="hiddenRecordId" type="hidden" size="1" name="hiddensaurabh" runat="server" />
    </form>
</body>
</html>
