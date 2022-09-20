<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adDummyDayPS.aspx.cs" Inherits="adDummyDayPS" EnableEventValidation="false" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Display Ad Dummy Day Page Status</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
	<meta content="C#" name="CODE_LANGUAGE"/>
	<meta content="JavaScript" name="vs_defaultClientScript"/>
	<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
	<script type="text/javascript"language="javascript" src="javascript/popupcalender.js"></script>
	<script language="javascript" type="text/javascript"src="javascript/Validations.js"></script>
	<script type="text/javascript"language="javascript" src="javascript/adDummyDayPS.js"></script>
	<script language="javascript" type="text/javascript"src="javascript/permission.js"></script>
	<script language="javascript" type="text/javascript"src="javascript/TreeLibrary.js"></script>
	<script type="text/javascript"language="javascript" src="javascript/tree.js"></script>
	<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
	
	<script type="text/javascript"language="javascript" src="javascript/datevalidation.js"></script>
	
	<link href="css/main.css" type="text/css" rel="stylesheet"/>
	
</head>
<body onkeydown="javascript:return tabvalue('txtAdVolume');" onload="loadXML('xml/errorMessage.xml');return givebuttonpermission('adDummyDayPS');">
    <form id="form1" method="post" runat="server">
        <table id="OuterTable" width="1000" align="center" border="0" cellpadding="0" cellspacing="0">
            <tr valign="top">
			    <td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Publication Center Master"></uc1:topbar></td>
			</tr>
			<tr valign="top">
			    <td valign="top"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar>
			    <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager></td>
			    <td>
			      <table cellspacing="0" cellpadding="0" border="0" id="RightTable" class="RightTable">
							  <tr valign="top">					
					             <td>
					                    <asp:UpdatePanel ID="buttonupdate" runat="server"><ContentTemplate><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnSave" runat="server" CssClass="topbutton" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"  ></asp:ImageButton><asp:ImageButton id="btnModify" runat="server"  Font-Size="XX-Small" BackColor="Control"
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
						        </ContentTemplate></asp:UpdatePanel></td>
				             </tr>		
			           </table>
			        <table cellspacing="0" cellpadding="0" align="center"border="0" >
			            <tr>
						    <td style="height: 19px"><asp:label id="lbDay" runat="server" CssClass="TextField"></asp:label></td>
							<td style="width: 213px; height: 19px;">
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
						
						    <td style="height: 19px"><asp:label id="lbPName" runat="server" CssClass="TextField"></asp:label></td>
						    <td style="width: 213px; height: 19px;">
                                <asp:DropDownList ID="drpPName" runat="server" CssClass="dropdown">
                                </asp:DropDownList>
                            </td>
						</tr>
						<tr>
						    <td style="height: 19px">
						        <asp:label id="lbPCName" runat="server" CssClass="TextField"></asp:label>
						    </td>
						    <td style="width: 213px; height: 19px;">
                                <asp:DropDownList ID="drpPCName" runat="server" CssClass="dropdown">
                                </asp:DropDownList>
						    </td>
						    
						    <td style="height: 19px">
						        <asp:label id="lbEdition" runat="server" CssClass="TextField"></asp:label>
						    </td>
						    <td style="width: 213px; height: 19px;">
                                <asp:DropDownList ID="drpEdition" runat="server" CssClass="dropdown">
                                </asp:DropDownList>
						    </td>
						</tr>
						<tr>
						    <td style="height: 19px">
						        <asp:Label id="lbSuppliment" runat="server" CssClass="TextField"></asp:Label></td>
						    <td style="width: 213px; height: 19px;">
                                <asp:DropDownList ID="drpSuppliment" runat="server" CssClass="dropdown">
                                </asp:DropDownList> 
						    </td>
						    
						    <td style="height: 19px">
						        <asp:Label ID="lbPageNo" runat="server" CssClass="TextField"></asp:Label></td>
						    <td style="width: 213px; height: 19px;">
                                <asp:TextBox ID="txtPageNo" runat="server" CssClass="btext1numeric" onkeypress="return ClientisNumber();"></asp:TextBox>
						    </td>
						</tr>
						<tr>
						    <td style="height: 19px">
						        <asp:Label ID="lbPageHeading" runat="server" CssClass="TextField"></asp:Label></td>
						    <td style="width: 213px; height: 19px;">
                                 <asp:TextBox ID="txtPageHeading" runat="server" CssClass="btext1" onkeypress="eventcalling(event);"></asp:TextBox>   
						    </td>
						    
						    <td style="height: 19px">
						        <asp:Label id="lbNPages" runat="server" CssClass="TextField"></asp:Label></td>
						    <td style="width: 213px; height: 19px;">
                                <asp:TextBox ID="txtNPages" runat="server" CssClass="btext1numeric" onkeypress="return ClientisNumber();"></asp:TextBox>
						    </td>
						</tr>
						
						<tr>
						    <td style="height: 19px">
						        <asp:Label id="lbAdCtg" runat="server" CssClass="TextField"></asp:Label></td>
						    <td style="width: 213px; height: 19px;">
                                <asp:DropDownList ID="drpAdCtg" runat="server" CssClass="dropdown">
                                </asp:DropDownList>
						    </td>
						    
						    <td style="height: 19px">
						        <asp:Label id="lbSubAdCtg" runat="server" CssClass="TextField"></asp:Label></td>
						    <td style="width: 213px; height: 19px;">
                                <asp:DropDownList ID="drpSubAdCtg" runat="server" CssClass="dropdown">
                                </asp:DropDownList>
						    </td>
						</tr>
						
						<tr>
						    <td style="height: 19px">
						        <asp:Label id="lbMaxRow" runat="server" CssClass="TextField"></asp:Label></td>
						    <td style="width: 213px; height: 19px;">
                                <asp:TextBox ID="txtMaxRow" runat="server" CssClass="btext1numeric" onkeypress="return ClientisNumber();"></asp:TextBox>
						    </td>
						    
						    <td style="height: 19px">
						        <asp:Label id="lbMaxCol" runat="server" CssClass="TextField"></asp:Label></td>
						    <td style="width: 213px; height: 19px;">
                                <asp:TextBox ID="txtMaxCol" runat="server" CssClass="btext1numeric" onkeypress="return ClientisNumber();"></asp:TextBox>
						    </td>
						</tr>
						
						<tr>
						    <td style="height: 19px">
						        <asp:Label id="lbStartRow" runat="server" CssClass="TextField"></asp:Label></td>
						    <td style="width: 213px; height: 19px;">
                                <asp:TextBox ID="txtStartRow" runat="server" CssClass="btext1numeric" onkeypress="return ClientisNumber();"></asp:TextBox>
						    </td>
						    
						    <td style="height: 19px">
						        <asp:Label id="lbStartCol" runat="server" CssClass="TextField"></asp:Label></td>
						    <td style="width: 213px; height: 19px;">
                                <asp:TextBox ID="txtStartCol" runat="server" CssClass="btext1numeric" onkeypress="return ClientisNumber();"></asp:TextBox>
						    </td>
						</tr>
						
						<tr>
						    <td style="height: 19px">
						        <asp:Label id="lbMaxAd" runat="server" CssClass="TextField"></asp:Label></td>
						    <td style="width: 213px; height: 19px;">
                                <asp:TextBox ID="txtMaxAd" runat="server" CssClass="btext1numeric" onkeypress="return ClientisNumber();"></asp:TextBox>
						    </td>
						    
						    <td style="height: 19px">
						        <asp:Label ID="lbPagiCode" runat="server" CssClass="TextField"></asp:Label></td>
						    <td style="width: 213px; height: 19px;">
                                 <asp:TextBox ID="txtPagiCode" runat="server" CssClass="btext1" onkeypress="eventcalling(event);" MaxLength="3"></asp:TextBox>   
						    </td>
						</tr>
						
						<tr>
						    <td>
						        <asp:label id="lbFrom" runat="server" CssClass="TextField"></asp:label>
						    </td>
						    <td>
                                <asp:TextBox ID="txtFrom" runat="server" CssClass="btext1" onkeypress="return ClientisNumber();" onChange="checkdate(this);"></asp:TextBox>
                                <script type="text/javascript"language="javascript">										
			                        if (!document.layers)
									{
									    document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtFrom, \"mm/dd/yyyy\")' onfocus=abc();  height=14 width=14> ")
									}										
								</script>
						    </td>
						    
						    <td>
						        <asp:label id="lbTo" runat="server" CssClass="TextField"></asp:label>
						    </td>
						    <td>
                                <asp:TextBox ID="txtTo" runat="server" CssClass="btext1" onkeypress="return ClientisNumber();" onChange="checkdate(this);"></asp:TextBox>
                                <script type="text/javascript"language="javascript">
			                        if (!document.layers)
									{
									    document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtTo, \"mm/dd/yyyy\")' onfocus=abc();  height=14 width=14> ")
									}										
								</script>
						    </td>
						</tr>
						
						<tr>
						
						    <td>
						        <asp:label id="lbPDate" runat="server" CssClass="TextField"></asp:label>
						    </td>
						    <td>
                                <asp:TextBox ID="txtPDate" runat="server" CssClass="btext1" onkeypress="return ClientisNumber();" onChange="checkdate(this);"></asp:TextBox>
                                <script type="text/javascript"language="javascript">
			                        if (!document.layers)
									{
									    document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtPDate, \"mm/dd/yyyy\")' onfocus=abc();  height=14 width=14> ")
									}										
								</script>
						    </td>
						    
						    <td style="height: 19px">
						        <asp:Label ID="lbLaderStatus" runat="server" CssClass="TextField"></asp:Label></td>
						    <td style="width: 213px; height: 19px;">
                                 <asp:TextBox ID="txtLaderStatus" runat="server" CssClass="btext1" MaxLength="3" onkeypress="eventcalling(event);"></asp:TextBox>   
						    </td>
						</tr>
						
						<tr>
						    <td style="height: 19px">
						        <asp:label id="lbColor" runat="server" CssClass="TextField"></asp:label>
						    </td>
						    <td style="width: 213px; height: 19px;">
                                <asp:DropDownList ID="drpColor" runat="server" CssClass="dropdown">
                                    <asp:ListItem Value="0">--Select Color--</asp:ListItem>
                                    <asp:ListItem Value="B">B</asp:ListItem>
                                    <asp:ListItem Value="C">C</asp:ListItem>
                                </asp:DropDownList>
						    </td>
						    <td style="height: 19px">
						        <asp:label id="lbAdVolume" runat="server" CssClass="TextField"></asp:label>
						    </td>
						    <td style="width: 213px; height: 19px;">
                                <asp:TextBox ID="txtAdVolume" runat="server" CssClass="btext1numeric" onkeypress="return ClientisNumber();"></asp:TextBox>
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
    </form>
</body>
</html>
