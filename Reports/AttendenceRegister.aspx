<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeFile="AttendenceRegister.aspx.cs" Inherits="AttendenceRegister" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Attendence Register</title>
    
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
    <link href="css/booking.css" type="text/css" rel="stylesheet"/>
    <link href="css/report.css" type="text/css" rel="stylesheet"/>
    <script type="text/javascript"  language="javascript" src="javascript/datevalidation.js"></script>
    <script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
    <script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
   <%-- <script type="text/javascript" language="javascript" src="javascript/rept.js"></script>--%>
    <script type="text/javascript" language="javascript" src="javascript/AttendenceRegister.js"></script>
    <%--<script type="text/javascript"  language="javascript" src="javascript/billbook.js"></script>--%>
    <link href="css/report.css" rel="stylesheet" type="text/css" />
</head>
<body onkeydown="javascript:return tabvalue();"  onload="document.getElementById('txtfrmdate').focus();">
    <form id="publicationrep" runat="server">
 

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
														<td  align="left"><asp:TextBox id="txtfrmdate" runat="server" CssClass="btext1" ></asp:TextBox> <img src='Images/cal1.gif'  onclick='popUpCalendar(this, publicationrep.txtfrmdate, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/>
                                                          </td>
                                                        
													</tr>
													<tr>
													<td align="left">
														<asp:Label id="lbToDate" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                                    <asp:TextBox id="txttodate1" runat="server" CssClass="btext1" ></asp:TextBox>
                                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, publicationrep.txttodate1, "mm/dd/yyyy")' onfocus="abc();" height="14" width="14"/>
                                                        </td>
                                                    </tr>
                                                       	
                                                    <tr>
														<td align="left" ><asp:Label id="lbAdtype" runat="server" CssClass="TextField"></asp:Label></td>
														  <td align="left">
                                                                    <asp:DropDownList CssClass="dropdown" id="dpaddtype" runat="server" ></asp:DropDownList>
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
												
													<td align="left"><asp:Label id="lbladsubcat" runat="server" CssClass="TextField" Text="Ad Sub Category" ></asp:Label></td>
														<td align="left"><%--<asp:UpdatePanel ID="UpdatePanel10" runat="server" >
                                                                <ContentTemplate>--%>
                                                                    <asp:ListBox id="lstadsubcat" runat="server" CssClass="btext1" Height ="66px"  SelectionMode="Multiple" Width="144px">
                                                                        <asp:ListItem>--Select Ad SubCat--</asp:ListItem>
                                                                        
                                                                    </asp:ListBox>
                                                               <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
													
													</tr>
													
													<tr  style="display:none">
														<td align="left"><asp:Label id="Label1" Text="Package Detail Required" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                                    <asp:DropDownList id="drppackagedetail" runat="server"  CssClass="dropdown"  ></asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    
                                                      <tr style="display:none">
														<td align="left"><asp:Label id="Label2" runat="server" Text="Package" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                                    <asp:DropDownList id="drppackage" runat="server"  CssClass="dropdown" >
                                                                    <asp:ListItem Value="0" Text="--Select Package--"></asp:ListItem></asp:DropDownList>
                                                       </td>
                                                      </tr>
                                                        
                                                     
                                                       
													
													<tr>
														<td align="left"><asp:Label id="lbPublication" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                        <asp:DropDownList id="dppub1" runat="server"  CssClass="dropdown" ></asp:DropDownList>
                                                        </td>
                                                        </tr>
                                                        
                                                      <tr>
                                                       <td align="left">
                                                        <asp:Label id="lbPublicationCenter" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                                    <asp:DropDownList id="dppubcent" runat="server"  CssClass="dropdown"    ></asp:DropDownList>
                                                        </td>
                                                        
                                                       </tr>
                                                     
													
                                                       
                                                      <tr  style="display:none">
                                                            <td align="left">
                                                        <asp:Label id="lbEdition" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                                    <asp:DropDownList id="dpedition" runat="server" CssClass="dropdown" >
                                                                    <asp:ListItem Value="0" Text="--Select Edition Name--"></asp:ListItem></asp:DropDownList>
                                                               
                                                        </td>
                                                     </tr>
                                                       
                                                         
                                                      <tr  style="display:none">
                                                            <td align="left">
                                                        <asp:Label id="suppliment" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                                    <asp:DropDownList id="dpsuppliment" runat="server" CssClass="dropdown" type="password">
                                                                    <asp:ListItem Value= "0" >Select supplement</asp:ListItem></asp:DropDownList>
                                                        </td></tr>
                                                       
                                                       
                                                       <tr style="display:none;"><td align="left">
                                                        <asp:Label id="editiondetail" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                                    <asp:DropDownList id="dpedidetail" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                        </td></tr>
                                                        <tr>
                                                        
													<td align="left"><asp:Label id="lbl_branch" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                     <asp:DropDownList id="dpd_branch" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                               
                                                        </td>
													</tr>     
                                                        
                                                       <%-- <tr><td align="left">
                                                        <asp:Label id="Label3" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                                    <asp:DropDownList id="DropDownList1" runat="server" CssClass="dropdown">
                                                                    <asp:ListItem Text="--Select Status--" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="Include Cancel" Value="cancel"></asp:ListItem>
                                                                     <asp:ListItem Text="Include Hold" Value="hold"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                        </td></tr>--%>
                                                       
                                                        <tr><td align="left">
                                                        <asp:Label id="status" runat="server" CssClass="TextField" Visible="False"></asp:Label></td>
														<td  align="left">
                                                                    <asp:DropDownList id="drpstatus" runat="server" CssClass="dropdown" 
                                                                        Visible="False">
                                                                    <asp:ListItem Text="--Select Status--" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="Include Cancel" Value="cancel"></asp:ListItem>
                                                                     <asp:ListItem Text="Include Hold" Value="hold"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                        </td></tr>
                                                        <tr><td align="left">
                                                        <asp:Label id="lblbookfrom" runat="server" CssClass="TextField">Book For other Branch</asp:Label></td>
														<td  align="left">
                                                                    <asp:DropDownList id="drpbookfrom" runat="server" CssClass="dropdown">
                                                                     <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                        </td></tr>
                                                        
                                                          <tr><td align="left">
                                                        <asp:Label id="lbluom" runat="server" CssClass="TextField">Uom</asp:Label></td>
														<td  align="left">
                                                                    <asp:DropDownList id="drpuom" runat="server" CssClass="dropdown">
                                                                     <asp:ListItem Value="0">--- Select Uom ---</asp:ListItem>
                                                                    </asp:DropDownList>
                                                        </td></tr>
                                                               <tr><td align="left">
                                                        <asp:Label id="Label3" runat="server" CssClass="TextField">Show Billed Ads</asp:Label></td>
														<td  align="left">
                                                                    <asp:DropDownList id="drpflag" runat="server" CssClass="dropdown" type="password">
                                                                    <asp:ListItem Value="bill">Yes</asp:ListItem>
                                                                    <asp:ListItem Value="notbill">No</asp:ListItem></asp:DropDownList>
                                                         </td></tr>
                                                                <tr><td align="left">
                                                        <asp:Label id="Label4" runat="server" CssClass="TextField">Booked For Dummy</asp:Label></td>
														<td  align="left">
                                                                    <asp:DropDownList id="drpdummy" runat="server" CssClass="dropdown" type="password">
                                                                    <asp:ListItem Value="YDU">Yes</asp:ListItem>
                                                                    <asp:ListItem Value="NDU">No</asp:ListItem></asp:DropDownList>
                                                         </td></tr>
                                                                  <tr><td align="left">
                                                        <asp:Label id="Label5" runat="server" CssClass="TextField">Show Branch Based</asp:Label></td>
														<td  align="left">
                                                                    <asp:DropDownList id="drpbranchbased" runat="server" CssClass="dropdown" type="password">
                                                                       <asp:ListItem Value="NB">No</asp:ListItem>
                                                                    <asp:ListItem Value="YB">Yes</asp:ListItem>
                                                                
                                                                    </asp:DropDownList>
                                                         </td></tr>
														
                                                        <tr><td align="left">
                                                        <asp:Label id="lbdestination" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                                    <asp:DropDownList id="Txtdest" runat="server" CssClass="dropdown" type="password">
                                                                    <asp:ListItem Value="1">On Screen</asp:ListItem>
                                                                    <asp:ListItem Value="4">Excel Sheet</asp:ListItem></asp:DropDownList>
                                                         </td></tr>
														
														 <tr><td align="center" id="fg" colspan="2" style="display:none;">
                                                         
                                                       
                                                       
                                                                    <asp:RadioButton id="exe" runat="server"  Checked="true" Text="Excel"></asp:RadioButton>
                                                                    <asp:RadioButton id="csv" runat="server"  Text="CSV"></asp:RadioButton>
                                                                    
                                                      
                                                              
                                                        </td></tr>
													</table>
													
													<table>
													<tr >
														<td align="center">
                                                                    <asp:button id="BtnRun" CssClass="btntext" Runat="server"  ></asp:button>
                                                                      <asp:button id="btnallbilled" CssClass="btntext" Runat="server"  ></asp:button>
                                                           
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
                          <td><input id="hiddencioid" type="hidden" runat="server" /></td>
                          <td><input id="hiddenolddate" type="hidden" name="hiddenolddate" runat="server" /></td>
                          <td><input id="hdnsuppliment" type="hidden" name="hdnsuppliment" runat="server" /></td>
                           <td><input id="hdncompcode" type="hidden" name="hdncompcode" runat="server" /></td>
 <td><input id="hiddencompcode" type="hidden" name="hiddencompcode" runat="server" /></td>

  <input id="hiddenadcat" type="hidden" name="hiddenadcat" runat="server" />
  <input id="hiddenadcatname" type="hidden" name="hiddenadcatname" runat="server" />
  <input id="hiddenedition" type="hidden" name="hiddenedition" runat="server" />
  <input id="hiddeneditionname" type="hidden" name="hiddeneditionname" runat="server" />
  <input id="hiddenpackage" type="hidden" name="hiddenpackage" runat="server" />
  <input id="hiddenpackagename" type="hidden" name="hiddenpackagename" runat="server" />

  


                         
			</tr>
				
			</table>
			
			

       
        
    </form>
</body>
</html>
