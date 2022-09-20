<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cir_roleMaster.aspx.cs" Inherits="Cir_roleMaster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx"%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Role Master</title>
        <script language="javascript" src="javascript/prototype.js" type="text/javascript"></script>
    <script language ="javascript" src="javascript/Cir_roleMaster.js" type="text/javascript" ></script>
    <script language="javascript" src="javascript/replace_Char.js" type="text/javascript"></script>
     <link  rel="Stylesheet" href="css/cir_main.css" type="text/css" />
     
</head>
<body id="body" onload="blankfields(); loadXML('XML/Cir_roleMaster.xml');" onkeydown="javascript:return chkfld(event)"; onkeypress="javascript:return chkfld(event)";>
  <form id="form1" runat="server">
     <table id="outertable" width="1000px" border="0" cellpadding="0" cellspacing="0">
     <tr>
      <td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Role Master"></uc1:topbar></td>
      </tr>
      <tr valign="top">
					<td valign="top" style="width: 184px"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top"><table class="RightTable" id="Table1" cellspacing="0" cellpadding="0" bordercolor="yellow" border="0">
							<tr valign="top">
								<td style="width: 764px"><asp:Button ID="btnNew" runat="server" BackColor="Control"
                                        BorderStyle="Outset" CssClass="topbutton" Font-Bold="True" Font-Size="XX-Small"
                                        Height="24px" Width="63px" /><asp:button id="btnSave" runat="server" Height="24px" Font-Bold="True" 
										BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Width="63px" CssClass="topbutton" ></asp:button><asp:button id="btnModify" runat="server" Height="24px" Font-Bold="True" 
										BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Width="63px" CssClass="topbutton"></asp:button><asp:button id="btnQuery" runat="server" Height="24px" Font-Bold="True" 
										BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Width="63px" CssClass="topbutton"></asp:button><asp:button id="btnExecute" runat="server" Height="24px" Font-Bold="True" 
										BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Width="63px" CssClass="topbutton"></asp:button><asp:button id="btnCancel" runat="server" Height="24px" Font-Bold="True" 
										BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Width="63px" CssClass="topbutton"></asp:button><asp:button id="btnfirst" runat="server" Height="24px" Font-Bold="True" 
										BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Width="62px" CssClass="topbutton"></asp:button><asp:button id="btnprevious" runat="server" Height="24px" Font-Bold="True" 
										BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Width="63px" CssClass="topbutton"></asp:button><asp:button id="btnnext" runat="server" Height="24px" Font-Bold="True" 
										BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Width="63px" CssClass="topbutton"></asp:button><asp:button id="btnlast" runat="server" Height="24px" Font-Bold="True" 
										BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Width="63px" CssClass="topbutton"></asp:button><asp:button id="btnDelete" runat="server" Height="24px" Font-Bold="True" 
										BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Width="63px" CssClass="topbutton"></asp:button><asp:button id="btnExit" runat="server" Height="24px" Font-Bold="True" 
										BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" Width="63px" CssClass="topbutton"></asp:button></td>
							 
							 
							 
							</table>
					<table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0">
					<tr valign="top" align="left">
					<td>
					<table class="Popupbar" style="WIDTH: 755px; HEIGHT: 23px" cellspacing="0"
										cellpadding="0" width="752" border="0">
										<tr>
											<td bgcolor="#7daae3" style="height: 23px"></td>
											
										</tr>
					</table>
					</td>
					
					</tr>
					<tr>
								<td style="height: 25px"></td>
					</tr>
					<tr>
					<td>
					<table align="center" cellspacing="0" cellpadding="0" width="755px">
					  <tr>
					<td style="height:25px"><asp:label id="lblcompcode" 
                                            runat="server" CssClass="LabelText"></asp:label></td>
                    <td align="left"><asp:textbox id="txtcompcode" runat="server" CssClass="Textfield" Enabled ="false"
									></asp:textbox></td>
					<td style="height:25px"> <asp:label id="lblcompname" runat="server" CssClass="LabelText"></asp:label></td>
									<td align="left"><asp:textbox id="txtcompname" runat="server" CssClass="Textfield" Enabled ="false "
											></asp:textbox></td>
					</tr>
					<tr>
					<td style="height:25px;"><asp:label id="lblRoleCode" 
                                            runat="server" CssClass="LabelText"></asp:label></td>
                    <td align="left"><asp:textbox id="txtRoleCode" runat="server" CssClass="Textfield"
									 ></asp:textbox></td>
					<td style="height:25px;"><asp:label id="lblRoleName" runat="server" CssClass="LabelText"></asp:label></td>
									<td align="left"><asp:textbox id="txtRoleName" runat="server" CssClass="Textfield"
											></asp:textbox></td>
					</tr>
					
					<tr>
					<td style="height:25px;"><asp:label id="lblLevels" 
                                            runat="server" CssClass="LabelText"></asp:label></td>
                    <td align="left"><asp:DropDownList id="ddlLevels" runat ="server" CssClass ="dropdown"></asp:DropDownList></td>
					<td style="height:25px;"><asp:label id="lblfreezflag" runat="server" CssClass="LabelText"></asp:label></td>
									 <td align="left"><asp:dropdownlist id="drpfreezflag" runat="server" CssClass="dropdown">
													
                                                </asp:dropdownlist>
									 </td>
					</tr>
					<tr style ="height:40px">
      <td colspan ="4" align ="center" >
     <asp:Button runat ="server" ID="Button4" Text="view" Width="100px" 
              />&nbsp;&nbsp;
            
      </td>
      </tr>
      
					
					
					</table>
					</td>
					</tr>
					 <tr>
	                             <td id='Td14' style='display:none'>
	                                <table border="0" style="width:755px; height:20px;background-color:#7DAAE3" 
                                         cellpadding="0" cellspacing="0" align="center">
	                                      <tr>
                                            <td><asp:Label runat="server" id="view10" width="40px" CssClass="tabsHeadersr"></asp:Label></td>
                                            <td><asp:Label runat="server" id="view11" width="90px" CssClass="tabsHeader"></asp:Label></td>
                                          <%-- <td><img src="images/arrowup.jpg" width='14px;' height='8px;' id='upid' style="display:none;" alt='up'/> <img src="images/arrowdown.jpg" id='downid' width='14px;' height='8px;' style="display:block;" alt='down'/></td>--%>
                                            <td><asp:Label runat="server" id="view12" width="90px" CssClass="tabsHeader"></asp:Label></td>
      	                                    <td><asp:Label runat="server" id="view13" width="90px" CssClass="tabsHeader"></asp:Label></td>
      	                                  
      	                            
      	                               <%--     <td><asp:Label runat="server" id="view16" width="90px" CssClass="tabsHeader"></asp:Label></td>--%>
      	                                    
                                          </tr>
	                                </table>
	                            </td>
	
	                         <tr>
	                            <td>
	                                <table>
	                                     <tr>
                                            <td runat="server" id="view19" style="display:block;" align="center" valign="top" class="style1"></td>
                                         </tr>
	                               </table>
	                           </td>
	                        </tr>
	                    </tr>
	                     <tr>
	                                            <td>
	                                            <table cellpadding='0' cellspacing='0' width='700px' border=0 style="padding-left:20px;">
	                                            
	                                            <tr>
	                                            <td id="prepage" colspan='3' runat="server" 
                                                        style="font-size:16px;font-weight:bold;color:Gray;text-align:right;cursor:hand;padding-left:490px;display:none;" 
                                                        onclick="javascript:return pageprev(this.value);" class="style3">Previous</td>
	                                            <td id="next1" colspan='3' runat="server" class="style4"  ></td>
	                                            
	                                            <td id="nextpage" runat="server" style="font-size:16px;font-weight:bold;cursor:hand;color:Gray;text-align:right;display:none;" width='30px' value='2' onclick="javascript:return pagenext(this.value);">Next</td>
                                            	
	                                            </tr>
	                                            </table>
	                                            </td>
	                                            </tr>
								 
					</table>
					</td>
		</tr>						 
		</table>			 
     
    </form>
    
     <input id="hdncompcode" type="hidden" runat="server" name="hdncompcode"/>
     <input id="hdncompname" type="hidden" runat="server" name="hdncompname"/>
     <input type="hidden" id="hiddendateformat"  runat ="server" name="dateformat"/>
     <input type="hidden" id="hdnuserid" runat ="server" name="hdnuserid" />
     <input type="hidden" id="hdnunit" runat="server" name="hdnunit" />
     <input type="hidden" runat="server" id="tblfields" />
     <input type="hidden" runat="server" id="executefields" />
     <input type="hidden" runat="server" id="deltblfields" />
     <input type="hidden" id="hdnduplicacy" runat="server" />
     <input type="hidden" id="hdntablename" runat="server" />
     <input id="hdn_user_right" type="hidden" runat="server" name="hdn_user_right"/>
      <input type="hidden" id="hdnalrt" runat="server" />
</body>
</html>
