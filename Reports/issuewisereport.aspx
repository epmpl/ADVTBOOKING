<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeFile="issuewisereport.aspx.cs" Inherits="issuewisereport" %>

<%--<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>--%>
<%@ Register TagPrefix="uc1" TagName="Leftbar" Src="~/Leftbar.ascx" %>
<%@ Register TagPrefix="uc2" TagName="Topbar" Src="~/Topbarnew.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Issue Wise Printing Center Wise Business Report</title>
    	<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<link href="css/booking.css" type="text/css" rel="stylesheet"/>
		<link href="css/report.css" type="text/css" rel="stylesheet"/>
				<script type="text/javascript"  language="javascript" src="javascript/datevalidation.js"></script>
     <script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/rept.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/NEW.js"></script>
       <script language="javascript" type="text/javascript">
		function forfocus()
		{
		document.getElementById('Txtusernme').focus();
		}
		function maximize()
        {
        window.moveTo(0,0)            
        window.resizeTo(screen.availWidth, screen.availHeight)
         }
        maximize();
		</script>
</head>
<body onkeydown="javascript:return tabvalueisuebusi(event);"  onload="document.getElementById('txtfrmdate').focus();">
       
    <form id="form1" runat="server">
   <%--<table id="OuterTable" border="0" width="1000" cellpadding="0" cellspacing="0" align="center">
            <tr valign="top">
                <td colspan="2" style="height: 54px">
                    <uc2:Topbar ID="Topbar1" runat="server" text="Reports" />
                </td>
            </tr>
            <tr valign="top" >
                
                <td valign="top">
                    <uc1:Leftbar ID="Leftbar1" runat="server"></uc1:Leftbar>
                </td>
                <td valign="top" >
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <table id="RightTable" cellpadding="0" cellspacing="0">
                          <caption  class="heading_l">Issue Wise Printing Center Business</caption>
                          <tr></tr>
                          <tr></tr>
                          <tr></tr>
                     
	                    
	                    
                        
                        <tr>
                            <td>
                                <asp:Label ID="LblFromDate" runat="server" CssClass="TextField"></asp:Label>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="TxtFromDate" runat="server" CssClass="btext1" Width="120px"  onkeypress="return ClientSpecialcharforDate();"></asp:TextBox>                                    
                                        <img id="Img1" alt="Img1" src='Images/cal1.gif' runat="server"  onclick='popUpCalendar(this, form1.TxtFromDate, "mm/dd/yyyy")' height="14" width="14" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                            
                        <tr></tr>          
                        
                        <tr>    
                            <td>
                                <asp:Label ID="LblToDate" runat="server" CssClass="TextField"></asp:Label>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="TxtToDate" runat="server" CssClass="btext1" Width="120px"  onkeypress="return ClientSpecialcharforDate();"></asp:TextBox>                                     
                                        <img id="Img2" alt="Img2" src='Images/cal1.gif' runat="server"  onclick='popUpCalendar(this, form1.TxtToDate, "mm/dd/yyyy")' height="14" width="14" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td> 
                        </tr>
                        
                        <tr></tr>
                       
                         
                        
                        <tr>
                            <td>
                                <asp:Label ID="Lblpubcent" runat="server" CssClass="TextField"></asp:Label>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="Drppubcent"  runat="server" AutoPostBack="True"  OnSelectedIndexChanged="dppubcent_SelectedIndexChanged1" CssClass="btext1" Height="20px" Width="125px" ></asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>                                      
	                                     
                        <tr></tr> 
                        <tr>
                            <td>
                                <asp:Label ID="Lbledition" runat="server" CssClass="TextField"></asp:Label>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="Drpedition" runat="server" CssClass="dropdown" Width="125px" >
                                            <asp:ListItem Value="0">-Select Edition-</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>  
                        <tr></tr>                   
                        
                        <tr>                           
                            <td>
                                <asp:Label ID="LblDestinationType" runat="server" CssClass="TextField" Visible="false"></asp:Label>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList  ID="Txtdest" runat="server" CssClass="dropdown" Width="125px" AutoPostBack="false" Visible="false">
                                            <asp:ListItem >---Select Report---</asp:ListItem>
                                            <asp:ListItem>On Screen</asp:ListItem>
                                            <asp:ListItem>Excel File</asp:ListItem>
                                            <asp:ListItem>PDF</asp:ListItem>
                                           
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>                                                       
                        </tr>
                        </table>
                        <table id="TableButton" cellpadding="0" cellspacing="0" border="0" style="top:100px">	         
	                        <tr></tr>
	                          <tr></tr>
	                             <tr></tr>
	                        <tr align="center">
	                        <td></td>
	                         <td></td>
	                            <td colspan="4" align="center">
	                               
                                            <asp:button id="btnRun" runat="server" Height="24px" Font-Bold="True" BorderStyle="Outset" BackColor="Control" Font-Size="X-Small" Width="70px" CssClass="topbutton" OnClick="BtnRun_Click" >
                                            </asp:button><asp:button id="btnExit" runat="server" Height="24px" Font-Bold="True" BorderStyle="Outset" BackColor="Control" Font-Size="X-Small" Width="70px" CssClass="topbutton"></asp:button>
	                                  
	                            </td>
	                        </tr> 
	                    </table>
	            </td> 
	        </tr>
	    </table>--%>
	    
	    
			<table width="1005" border="0" cellspacing="0" cellpadding="0" align="center" style="WIDTH: 1005px; HEIGHT: 358px">
				<tr>
					<td width="100%" bordercolor="#1"><img src="images/img_02A.jpg" width="1004" border="0" />
                        
                    </td>
				</tr>
				<tr>
					<%--<td width="100%" bordercolor="#1"><img src="images/top.jpg" width="1004" border="0" /></td>--%>
					<td  id="td2"  onclick="javascript:return logoutpage();"   width="100%" bordercolor="#1" style="background-image:url('images/top.jpg');font-family:Trebuchet MS;font-size: 13px;color:#CC0000;cursor:hand;" align="right">
                     Logout</td>
				</tr>
				<tr>
					<td style="height: 505px"><table width="985" border="0" cellspacing="0" cellpadding="0" style="WIDTH: 985px; HEIGHT: 486px">
							<tr>
								<!---------left bar start--------->
								<td width="200" style="WIDTH: 200px"><img src="images/leftbar.jpg" style="WIDTH: 193px; HEIGHT: 483px" height="483" width="193" /></td>
								<!---------left bar end--------->
								<!---------middle start--------->
								<td valign="top" style="width: 78%">
								
								<table cellpadding="0" cellspacing="0" width="790" style="WIDTH: 790px; HEIGHT: 488px"
										borderColorDark="#000000" border="1">
										<tr>
											<td align="center">
											<table ><tr>
											<td><asp:Label ID="heading" runat ="server" CssClass="heading" Text="Issue Wise Printing Center Wise Business Report"></asp:Label></td></tr>
											</table>
											<br />
											
											<table width="0" border="0" cellspacing="0" cellpadding="0">
													
													
													
													
													<tr>
														<td align="left">
														<asp:Label id="lbDateFrom" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                           
                                                                    <asp:TextBox id="txtfrmdate" runat="server" CssClass="btext1" ></asp:TextBox>
                                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtfrmdate, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/>
                                                               
                                                        </td>
                                                        
													</tr>
													<tr>
													<td align="left">
														<asp:Label id="lbToDate" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                            
                                                                    <asp:TextBox id="txttodate1" runat="server" CssClass="btext1" ></asp:TextBox>
                                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txttodate1, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/>
                                                               
                                                        </td>
														
                                                       	</tr>
													<tr>
														<td align="left"><asp:Label id="Lblpubcent" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                           
                                                                    <asp:DropDownList  ID="Drppubcent"  runat="server"  CssClass="dropdown" ></asp:DropDownList>
                                                                   
                                                        </td>
													</tr>
                                                        <tr style="display:none"><td align="left">
                                                        <asp:Label id="Lbledition" runat="server" CssClass="TextField" ></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                          
                                                                     <asp:DropDownList ID="Drpedition" runat="server" CssClass="dropdown" >
                                            <asp:ListItem Value="0">-Select Edition-</asp:ListItem>
                                                                     </asp:DropDownList>
                                                                
                                                        </td></tr>
                                                      
                                                      <tr>
														<td align="left"><asp:Label id="lblbasedon" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                           
                                                                    <asp:DropDownList  ID="drpbasedon"  runat="server"  CssClass="dropdown" >
                                                                    <asp:ListItem Value="T">Transaction</asp:ListItem>
                                                                    <asp:ListItem Value="A">Agency Master</asp:ListItem>
                                                                     </asp:DropDownList>
                                                        </td>
													</tr>
                                                       <tr><td align="left">
                                                        <asp:Label id="lbl_ratiotyp" runat="server" CssClass="TextField" Text="Ratio Type"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                          
                                                                     <asp:DropDownList ID="dpd_ratiotyp" runat="server" CssClass="dropdown"  >
                                            <asp:ListItem Value="C">Circulation Copy</asp:ListItem>
                                            <asp:ListItem Value="E">Edition Ratio</asp:ListItem>
                                                                     </asp:DropDownList>
                                                                
                                                        </td></tr>
                                                        
                                                            <tr><td align="left">
                                                        <asp:Label id="lblreporttype" runat="server" CssClass="TextField" Text="Report Type"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                          
                                                                     <asp:DropDownList ID="drpreporttype" runat="server" CssClass="dropdown"  >
                                            <asp:ListItem Value="O">Without Volume</asp:ListItem>
                                            <asp:ListItem Value="W">With Volume</asp:ListItem>
                                                                     </asp:DropDownList>
                                                                
                                                        </td></tr>
                                                        <tr>
                                                        <td align="left"><asp:Label id="lbagtype" runat="server" CssClass="TextField" Text="Report Type"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                                     <asp:DropDownList id="dpagtype" runat="server" CssClass="dropdown" ></asp:DropDownList>
                                                                </td>
                                                        </tr>
                                                        <tr><td align="left">
                                                        <asp:Label id="LblDestinationType" runat="server" CssClass="TextField" ></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                           
                                                                   <asp:DropDownList  ID="Txtdest" runat="server" CssClass="dropdown"  >
                                            <asp:ListItem Value="0">---Select Report---</asp:ListItem>
                                            <asp:ListItem Value="1" >On Screen</asp:ListItem>
                                            <asp:ListItem Value="4">Excel File</asp:ListItem>
                                            <asp:ListItem Value="3">PDF</asp:ListItem>
                                           
                                        </asp:DropDownList>
                                                        </td></tr>
														 <tr><td align="center" id="fg" colspan="4" style="display:none;">
                                                         
                                                        <%--  <div id="fg" runat="server" style="display:block">--%>
                                                       
                                                                    <asp:RadioButton id="exe" runat="server"  Checked="true" Text="Excel"></asp:RadioButton>
                                                                    <asp:RadioButton id="csv" runat="server"  Text="CSV"></asp:RadioButton>
                                                                    
                                                         <%--  </div>--%>
                                                              
                                                        </td></tr>
													</table>
													<table>
													<tr >
														<td align="center">
                                                               
                                                                    <asp:button id="btnRun" CssClass="btntext" Runat="server" OnClick="BtnRun_Click" ></asp:button>
                                                                    
                                                                    
                                                               
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
								
							</tr>
						</table>
                        <input id="hidden1" type="hidden" runat="server" /></td>
                         <td><input id="hiddendateformat1" type="hidden" runat="server" /></td>
				</tr>
				
			</table>
		
	    
	    
	    
	     <table>
        <tr><td id="rptDiv" runat ="server" colspan="11" >
       
 </td>
  </tr>
  </table> 
	    
	    <input id="hiddencomcode" runat="server" name="hiddencomcode" type="hidden" />
        <input id="hiddencompcode" runat="server" name="hiddencompcode" style="width: 55px" type="hidden"/>
        <input id="hiddenuserid" runat="server" style="width: 48px" type="hidden" />
        <input id="hiddendateformat" runat="server" style="width: 77px" type="hidden" />
        <input id="hiddenusername" runat="server" name="hiddenusername" style="width: 44px" type="hidden" />
        <input id="hiddenauto" runat="server" name="hiddenauto" style="width: 51px" type="hidden" />
        <input id="hdnedition" runat="server" name="hdnedition" style="width: 51px" type="hidden" />
        <input id="hdneditionname" runat="server" name="hdneditionname" style="width: 51px" type="hidden" />
    
    
    </form>
</body>
</html>
