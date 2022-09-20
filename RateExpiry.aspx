<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RateExpiry.aspx.cs" Inherits="RateExpiry" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Rate Expiry</title>
    <script type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>
    <script type="text/javascript" language="javascript" src="javascript/datevalidation.js"></script>
    <script  type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
    <script  type="text/javascript"language="javascript" src="javascript/RateExpiry.js"></script>
    <link href="css/main.css" type="text/css" rel="stylesheet" />
</head>
<body onload="javascript:return enabling();" onkeydown="javascript:return tabval(event);">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
    <div>
    <table id="OuterTable" cellspacing="0" cellpadding="0"  border="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Agency Master"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top" id="ctltd" style="width:25%"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" id="sectd">
						<asp:label id="li" runat="server"></asp:label></td>
				</tr>
			</table>
			<table border="0" cellpadding="0" cellspacing="0" width="100%" style="width:auto;margin:10px 40px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Rate Expiry</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
            <table cellpadding="0" cellspacing="0" border="0" width="80%" align="center" >
				<tr>
                                            <td style="height: 18px" width="420px" colspan="2">
                                                <asp:RadioButton ID="rbsolo" Checked="true"   style="font-family:Verdana;font-size:12px" Text="Solo Rate" GroupName="A" runat="server" /><asp:RadioButton Text="Package Rate"  style="font-family:Verdana;font-size:12px" GroupName="A" ID="rbpackage" runat="server" /></td>
                                            <td id="tdall" colspan="3" style="width: 400px; height: 18px;"><asp:RadioButton ID="rdall" Checked="true" Text="All"   style="font-family:Verdana;font-size:12px" GroupName="B" runat="server" /><asp:RadioButton Text="Main"  style="font-family:Verdana;font-size:12px" GroupName="B" ID="rdmain" runat="server" /><asp:RadioButton ID="rdsubedition"   style="font-family:Verdana;font-size:12px" Text="Subedition" GroupName="B" runat="server" /><asp:RadioButton Text="Supplement" GroupName="B"  style="font-family:Verdana;font-size:12px" ID="rdsupplement" runat="server" /></td><td id="td2">&nbsp;</td>
                                                </td>
                                            
                                           
                                        </tr>
                                        </table>
                                        
                                         <table cellpadding="0" cellspacing="0" border="0" width="80%" align="center" >
                                        
				<tr>
                                            <td style="height: 18px">
                                                <asp:Label ID="lbladtyp" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td style="width: 222px; height: 18px;">
                                                <asp:DropDownList ID="ddladtyp" runat="server" CssClass="dropdown">
                                                <asp:ListItem Value="0">--Select Type--</asp:ListItem>
                                    </asp:DropDownList></td>
                                            <td style="height: 18px; width: 112px;">
                                                <asp:Label ID="lblrtcod" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td style="height: 18px"><asp:DropDownList ID="ddlrtcod" runat="server" CssClass="dropdown">
                                              <asp:ListItem Value="0">--Select Rate Code--</asp:ListItem>
                                               </asp:DropDownList></td>
                                        </tr><tr>
									    <td><asp:label id="lblcategory" runat="server" CssClass="TextField"></asp:label></td>
								        <td>
                                              <asp:DropDownList ID="ddlcategory" runat="server" CssClass="dropdown">
                                              <asp:ListItem Value="0">--Select Category--</asp:ListItem>
                                              </asp:DropDownList>
                                        </td>
                                        <td>
												<asp:label id="lblcolor" runat="server" CssClass="TextField"></asp:label></td>
											<td id="Td2" rowspan="1" style=" height: 18px;">
												<asp:dropdownlist id="ddlcolor" runat="server" CssClass="dropdown" Width="144px">
                                                    <asp:ListItem Value="0" Selected="True">--Select Color--</asp:ListItem>
                                                </asp:dropdownlist></td>
									</tr><tr>
											<td style="height: 19px"><asp:label id="lbluom" runat="server" CssClass="TextField"></asp:label></td>
											<td style="WIDTH: 222px; height: 18px;">
												<asp:dropdownlist id="ddluom" runat="server" CssClass="dropdown">
												<asp:ListItem Value="0" Selected="True">--Select Uom--</asp:ListItem>
												</asp:dropdownlist></td>
											<td style="width: 112px; height: 19px;"><asp:label id="lblpackage" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:dropdownlist id="ddlpkg" runat="server" CssClass="dropdown">
											<asp:ListItem Value="0" Selected="True">--Select Package--</asp:ListItem>
											</asp:dropdownlist></td>
											
										</tr>
										<tr>
										<td><asp:label id="lblvldfrm" runat="server" CssClass="TextField"></asp:label></td>
											<td style="height: 19px"><asp:textbox  id="txtvldfrm" runat="server" CssClass="btext1" Enabled="true" MaxLength="10"   AutoPostBack="True"></asp:textbox>
											<img src='Images/cal1.gif'  onclick='popUpCalendar(this,form1.txtvldfrm,"mm/dd/yyyy")' height="14" width="14" ></td>
											
											<td align="left" style="width: 112px"><asp:label id="lblvldto" runat="server" CssClass="TextField"></asp:label></td>
											<td style="WIDTH: 222px"><asp:textbox id="txtvldto" runat="server" CssClass="btext1" Enabled="true" MaxLength="10"   AutoPostBack="True"></asp:textbox>
											<img src='Images/cal1.gif'  onclick='popUpCalendar(this,form1.txtvldto,"mm/dd/yyyy")' height="14" width="14" ></td>
											
											
										</tr>
										<tr>
										<td style="width: 112px"><asp:label id="lblexpdt" runat="server" CssClass="TextField"></asp:label></td>
											<td><asp:textbox id="txtexpdt" runat="server" CssClass="btext1" Enabled="true" MaxLength="10"  AutoPostBack="True"></asp:textbox>
											<img src='Images/cal1.gif'  onclick='popUpCalendar(this,form1.txtexpdt,"mm/dd/yyyy")' height="14" width="14" ></td>
											
										<tr><td></td>	
										</tr>
										<tr>
										
										<td colspan="2" align="right">
										<asp:UpdatePanel ID="up1" runat="server">
										<ContentTemplate>
										
										<asp:Button ID="btnsbmit" Text="Submit" Width="80px" runat="server"  />
										</ContentTemplate>
										</asp:UpdatePanel>
										</td>
										<td align="center"><asp:Button ID="btnExit" Text="Exit" Width="80px" runat="server"  /></td>
										<td><asp:Button ID="btnClear" Text="Clear" Width="80px" runat="server"  /></td>
										</tr>
										<tr><td>&nbsp;</td>	
										</tr>
																				
									</table>
								
									<%--<table border="0" width="90%" style="height:30px;background-color:#7DAAE3;" cellpadding="0" cellspacing="0" align="center">
	                                      <tr>
                                            <td ><asp:Label runat="server" id="view0" width="60px" CssClass="tabsHeadersr"></asp:Label></td>
                                            <td><asp:Label runat="server" id="view1" width="60px" CssClass="tabsHeader"></asp:Label></td>
                                            <td><asp:Label runat="server" id="view2" width="60px" CssClass="tabsHeader"></asp:Label></td>
      	                                    <td><asp:Label runat="server" id="view3" width="60px" CssClass="tabsHeader"></asp:Label></td>
      	                                    <td><asp:Label runat="server" id="view4" width="60px" CssClass="tabsHeader"></asp:Label></td>
      	                                    <td><asp:Label runat="server" id="view5" width="60px" CssClass="tabsHeader"></asp:Label></td>
      	                                    <td><asp:Label runat="server" id="view6" width="60px" CssClass="tabsHeader"></asp:Label></td>
      	                                    <td><asp:Label runat="server" id="view7" width="60px" CssClass="tabsHeader"></asp:Label></td>
      	                                    <td><asp:Label runat="server" id="view8" width="60px" CssClass="tabsHeader"></asp:Label></td>
                                            <td><asp:Label runat="server" id="view9" width="60px" CssClass="tabsHeader"></asp:Label></td>
      	                                    <td><asp:Label runat="server" id="view10" width="60px" CssClass="tabsHeader"></asp:Label></td>
      	                                    <td><asp:Label runat="server" id="view11" width="60px" CssClass="tabsHeader"></asp:Label></td>
      	                                    
                                          </tr>
                                      
	                                </table>--%>
	                                <div id="div2" style="overflow:auto; height:300px">
	                                <table  style="vertical-align:top" border="0" width="90%" style="height:30px;" cellpadding="0" cellspacing="0" align="center">
	                                     <tr>
	                                     <td width="100%" runat="server" id="view19" style="display:block;" align="left" valign="top"></td>
                                           
                                         </tr>
	                               </table>
	                           </div>
	                                <table width="80%" align="center">
	                                <tr><td align="center">
	                                <asp:UpdatePanel ID="up2" runat="server">
										<ContentTemplate>
	                                <asp:Button ID="btnsave" Text="Save" Width="80px" runat="server"  />
	                                </ContentTemplate>
										</asp:UpdatePanel>
	                                </td></tr>
	                                </table>
    </div>
    
    <input id="hiddendateformat" type="hidden" name="hiddendateformat" runat="server"/>
    <input id="hiddenuserid" type="hidden" name="hiddenuserid" runat="server"/>
    <input id="hiddencompcode" type="hidden" name="hiddencompcode" runat="server"/>
    <input id="hdnadtyp" type="hidden" name="hdnadtyp" runat="server"/>
    <input id="hdnrateunitid" type="hidden" name="hdnrateunitid" runat="server"/>
    <input id="hdndtabase" type="hidden" name="hdnser" runat="server"/>
    </form>
</body>
</html>
