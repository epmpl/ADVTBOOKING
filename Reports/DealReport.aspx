<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeFile="DealReport.aspx.cs" Inherits="DealReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Deal Report</title>
    <script type="text/javascript"  language="javascript" src="javascript/datevalidation.js"></script>
	<script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
	<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
	<script type="text/javascript" language="javascript" src="javascript/DealReport.js"></script>
	<%--<script type="text/javascript" language="javascript" src="javascript/new.js"></script>
	<script type="text/javascript"  language="javascript" src="javascript/billbook.js"></script>--%>
	<link href="css/report.css" rel="stylesheet" type="text/css" />
	<link href="css/main.css" type="text/css" rel="stylesheet"/>

</head>
<body  onkeydown="javascript:return tabvalue();" >
    <form id="delrept" runat="server">
    <div id="div1" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
	  <table cellpadding="0" cellspacing="0"><tr><td>
	  <asp:ListBox ID="lstagency" Width="382px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
	  </td></tr></table></div>
	   <div id="div2" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
	  <table cellpadding="0" cellspacing="0"><tr><td>
	  <asp:ListBox ID="lstclient" Width="382px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
	  </td></tr></table></div>
			<table width="1005" border="0" cellspacing="0" cellpadding="0" align="center" style="WIDTH: 1005px; HEIGHT: 358px">
				<tr>
					<td width="100%" bordercolor="#1"><img src="images/img_02A.jpg" width="1004" border="0" />
                       
                    </td>
				</tr>
				<tr>
					<td  id="td2"  onclick="javascript:return logoutpage();"   width="100%" bordercolor="#1" style="background-image:url('images/top.jpg');font-family:Trebuchet MS;font-size: 13px;color:#CC0000;cursor:hand;" align="right">
                     Logout</td>
				</tr>
				<tr>
					<td style="height: 505px"><table width="985" border="0" cellspacing="0" cellpadding="0" style="WIDTH: 985px; HEIGHT: 486px">
							<tr>
								
								<td width="200" style="WIDTH: 200px"><img src="images/leftbar.jpg" style="WIDTH: 193px; HEIGHT: 483px" height="483" width="193" /></td>
							
								<td valign="top" style="width: 78%">
								
								<table cellpadding="0" cellspacing="0" width="790" style="WIDTH: 790px; HEIGHT: 488px"
										borderColorDark="#000000" border="1">
										<tr>
											<td align="center">
											<table ><tr>
											<td><asp:Label ID="heading" runat ="server" CssClass="heading"></asp:Label></td></tr>
											</table>
											<br />
											
											<table width="0" border="0" cellspacing="0" cellpadding="2">
													<tr>
														<td align="left">
														<asp:Label id="lbDateFrom" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                                    <asp:TextBox id="txtfrmdate" runat="server" CssClass="btext1" ></asp:TextBox>
                                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, delrept.txtfrmdate, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/>
                                                      </td>
                                                        
													</tr>
													<tr>
													<td align="left">
														<asp:Label id="lbToDate" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                                    <asp:TextBox id="txttodate1" runat="server" CssClass="btext1" ></asp:TextBox>
                                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, delrept.txttodate1, "mm/dd/yyyy")' onfocus="abc();" height="14" width="14"/>
                                                               </td>
														
                                                       	</tr>
                                                       	<tr>
														    <td align="left">
														    <asp:Label id="Label1" runat="server" CssClass="TextField">No of Days</asp:Label></td>
														    <td  align="left">
                                                                        <asp:TextBox id="noofdatys" onkeypress="return notchar2(event);"  runat="server" CssClass="btext1" ></asp:TextBox>
                                                          </td>
                                                            
													    </tr>
                                                       	  <tr>
														<td align="left" ><asp:Label id="lbAdtype" runat="server" CssClass="TextField"></asp:Label></td>
														  <td align="left"><asp:DropDownList CssClass="dropdown" id="dpaddtype" runat="server" ></asp:DropDownList>
                                                              </td>
                                                        
													</tr>
												
													
													<tr>
													<td align="left"><asp:Label id="lbadcatgory" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                    <asp:ListBox id="dpadcatgory" runat="server" CssClass="btext1" Height ="66px"  SelectionMode="Multiple" Width="144px">
                                                                        <asp:ListItem>--Select Ad Cat--</asp:ListItem>
                                                                    </asp:ListBox>
                                                        </td>
													</tr>
													<tr>
							                            <td align="left" style="width: 106px"><asp:Label id="lbl_agency" runat="server" CssClass="TextField"></asp:Label></td>
							                            <td align="left" colspan="6"><asp:TextBox  ID="txtagency"  runat="server" style="text-transform:uppercase;" CssClass="btext1" Width="350" ></asp:TextBox></td>
						                            </tr>
						                            <tr>
							                            <td align="left" style="width: 106px"><asp:Label id="lblclient" runat="server" CssClass="TextField"></asp:Label></td>
							                            <td align="left" colspan="6"><asp:TextBox  ID="txtclient"  runat="server" style="text-transform:uppercase;"  CssClass="btext1" Width="350" ></asp:TextBox></td>
						                            </tr>
													
													      <tr>
														<td align="left"><asp:Label id="lbldealtype" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                                    <asp:DropDownList id="drpdealtype" runat="server"  CssClass="dropdown"  ></asp:DropDownList>
                                                        </td>
                                                        </tr>
                                                        
                                                        
                                                        
                                                    
                                                      
                                                      <tr>
														<td align="left"><asp:Label id="lblpackage" runat="server" Text="Package" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                                    <asp:DropDownList id="drppackage" runat="server"  CssClass="dropdown" ></asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        
                                                     
                                                       
													
													<tr>
														<td align="left"><asp:Label id="lbratecode" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                                    <asp:DropDownList id="dpratecode" runat="server"  CssClass="dropdown" ></asp:DropDownList>
                                                        </td>
                                                        </tr>
                                                      <tr>
                                                        
                                                       <td align="left">
                                                        <asp:Label id="lblstatus" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                                    <asp:DropDownList id="dppstatus" runat="server"  CssClass="dropdown">
                                                                    <asp:ListItem Value="0">--Select Status--</asp:ListItem>
                                                                    <asp:ListItem Value="Y">Approve</asp:ListItem>
                                                                    <asp:ListItem Value="N">UnApprove</asp:ListItem>
                                                                    </asp:DropDownList>
                                                        </td>
                                                        
                                                       </tr>
													
                                                        <tr><td align="left">
                                                        <asp:Label id="lbdestination" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                                    <asp:DropDownList id="Txtdest" runat="server" CssClass="dropdown" type="password"></asp:DropDownList>
                                                        </td></tr>
													</table>
													
													<table>
													<tr >
														<td align="center">
                                                                    <asp:button id="BtnRun" CssClass="btntext" Runat="server" OnClick="BtnRun_Click" ></asp:button>
                                                           </td>
													</tr>
													
												</table>
												<table style="width: 223px" >
												<tr>
														
															
															
                                                            <td style="height: 116px"></td>
                                                        </tr>
                                                        </table>
													</tr>
														</table>
                                                
												</td>
                                                
												</td>

							</tr>
						</table>
						<table>
						<tr><td>
                        <input id="hiddendateformat" type="hidden" runat="server" /></td>
                         <td><input id="hiddendateformat1" type="hidden" runat="server" /></td>
                         <td><input id="hiddenascdesc" type="hidden" runat="server" /></td>
                          <td><input id="hiddenadcat" type="hidden" runat="server" /></td>
                          <td><input id="hiddenadcatname" type="hidden" name="hiddenolddate" runat="server" /></td>
                          <td><input id="hdnagmaincode" type="hidden" name="hdnagmaincode" runat="server" /></td>
                          <td><input id="hdnagsubcode" type="hidden" name="hdnagsubcode" runat="server" /></td>
                           <td><input id="hdncompcode" type="hidden" name="hdncompcode" runat="server" /></td>  
                            <td><input id="hdnagencytxt" type="hidden" name="hiddenadcat" runat="server" />
                              <input id="hdnagency1" type="hidden" name="hiddenadcatname" runat="server" />
                              <input id="hdnclient1" type="hidden" name="hiddenedition" runat="server" />
                              <input id="hdnclienttxt" type="hidden" name="hiddeneditionname" runat="server" />
                              <input id="hiddenpackage" type="hidden" name="hiddenpackage" runat="server" />
                              <input id="hiddenpackagename" type="hidden" name="hiddenpackagename" runat="server" /></td>  

  


                         
			</tr>
				
			</table>
			
    </form>
</body>
</html>
