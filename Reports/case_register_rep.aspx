<%@ Page Language="C#" AutoEventWireup="true" CodeFile="case_register_rep.aspx.cs" Inherits="Reports_case_register_rep" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Case Register Report</title>
    
    	<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<link href="css/booking.css" type="text/css" rel="stylesheet"/>
		<link href="css/report.css" type="text/css" rel="stylesheet"/>
		
		<script type="text/javascript"  language="javascript" src="javascript/datevalidation.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/case_register.js"></script>

</head>

<body onload="javascript:return blankfield();" >
    <form id="report1"  runat="server">
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
								<!---------left bar start--------->
								<td width="200" style="WIDTH: 200px"><img src="images/leftbar.jpg" style="WIDTH: 193px; HEIGHT: 483px" height="483" width="193" /></td>
								
									<td valign="top" style="width: 78%">
								
								<table cellpadding="0" cellspacing="0" width="790" style="WIDTH: 790px; HEIGHT: 488px"
										borderColorDark="#000000" border="1">
										<tr>
											<td align="center">
											<table ><tr>
											<td><asp:Label ID="heading" runat ="server" Text="Case Register Report" CssClass="heading"></asp:Label></td></tr>
											</table>
											<br />
												<table width="0" border="0" cellspacing="0" cellpadding="2">
										     	<tr>
														<td align="left" ><asp:Label id="lbAdtype" runat="server" CssClass="TextField"></asp:Label></td>
														  <td align="left">
                                                           <asp:DropDownList CssClass="dropdown" id="dpdadtype" runat="server"  ></asp:DropDownList>
                                                        </td>
                                                        
													</tr>
													
														<tr>
													<td align="left"><asp:Label id="lbadcatgory" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                
                                                                    <asp:ListBox id="dpadcatgory" runat="server" CssClass="btext1" Height ="66px" SelectionMode="Multiple" Width="144px"  >
                                                                        <asp:ListItem>--Select Ad Cat--</asp:ListItem>
                                                                        
                                                                    </asp:ListBox>
                                                             
                                                        </td>
													</tr>
													
													<tr>
													<td align="left"><asp:Label id="lbladsubcat" runat="server" CssClass="TextField" Text="Ad Sub Category" ></asp:Label></td>
														<td align="left">
                                                           
                                                                    <asp:ListBox id="lstadsubcat" runat="server" CssClass="btext1" Height ="66px"  SelectionMode="Multiple" Width="144px">
                                                                        <asp:ListItem>--Select Ad SubCat--</asp:ListItem>
                                                                        
                                                                    </asp:ListBox>
													</tr>
													
													<tr>
														<td align="left">
														<asp:Label id="lbDateFrom" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
     
                                                             <asp:TextBox id="txtfrmdate" runat="server" CssClass="btext1" ></asp:TextBox>
                                                             <img src='Images/cal1.gif'  onclick='popUpCalendar(this, report1.txtfrmdate, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/>
                                                           
                                                        </td>
                                                        
													</tr>
													<tr>
													<td align="left">
														<asp:Label id="lbToDate" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                          
                                                                    <asp:TextBox id="txttodate1" runat="server" CssClass="btext1" ></asp:TextBox>
                                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, report1.txttodate1, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/>
                                                           
                                                        </td>
														
                                                       	</tr>
                                                       	
                                                       	<tr>
														<td align="left"><asp:Label id="lbPublication" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                         
                                                                    <asp:DropDownList id="dppub1" runat="server" CssClass="dropdown" ></asp:DropDownList>
                                                         
                                                        </td>
													</tr>
													
													<tr>
                                                        
                                                       <td align="left">
                                                        <asp:Label id="lbPublicationCenter" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                        
                                                                    <asp:DropDownList id="dppubcent" runat="server" CssClass="dropdown" ></asp:DropDownList>
                                                       
                                                        </td>
                                                        
                                                       </tr>
													
													<tr>
                                                            <td align="left">
                                                        <asp:Label id="lbEdition" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                         
                                                       <asp:DropDownList id="dpedition" runat="server" CssClass="dropdown" type="password"></asp:DropDownList>
                                                        
                                                        </td></tr>
                                                        
                                                        
                                                        <tr>
                                                        <td align="left"><asp:Label id="lbl_printcent" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                      
                                                          <asp:DropDownList id="dpd_printcent" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                           
                                                        </td>
                                                        
                                                        
                                                        </tr>
                                                        <tr>
                                                        
													<td align="left"><asp:Label id="lbl_branch" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                             
                                                         <asp:DropDownList id="dpd_branch" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                              
                                                        </td>
													</tr> 
													<tr>
													
													<td align="left"><asp:Label id="lbluserid" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                            
                                                            <asp:DropDownList id="drpuserid" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                       
                                                        </td>
													
													
													</tr>
													 <tr><td align="left">
                                                        <asp:Label id="lbdestination" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                        
                                                          <asp:DropDownList id="drpdest" runat="server" CssClass="dropdown" type="password"></asp:DropDownList>
                                                          
                                                        </td></tr>
													 <tr><td align="left">
                                                        <asp:Label id="lblbased" runat="server" CssClass="TextField" Text="Based On"></asp:Label></td>
														<td  align="left">
                                                        
                                                          <asp:DropDownList id="drpbased" runat="server" CssClass="dropdown" type="password"></asp:DropDownList>
                                                          
                                                        </td></tr>
													
													
													
										       </table>
										       
										       <table>
												
												<tr >
														<td align="center">
                                                                
                                                 <asp:button id="BtnRun"  CssClass="btntext" Runat="server"></asp:button>
                                                                                
                                                            </td>
													</tr>
													
													
												</table>
										       
											</td></tr></table></td>
							</tr>
							</td>
							</table>	
							
							 <input id="hiddendateformat" type="hidden" runat="server" /></td>
							  <input id="hiddencompcode" type="hidden" name="hiddencompcode" runat="server" />
								
								
    </form>
</body>
</html>
