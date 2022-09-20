<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ad_rep_roapproval_detail.aspx.cs" Inherits="ad_rep_roapproval_detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ad_rep_roapproval_detail</title>
    	<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<link href="css/booking.css" type="text/css" rel="stylesheet"/>
		<link href="css/report.css" type="text/css" rel="stylesheet"/>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
				<script type="text/javascript"  language="javascript" src="javascript/datevalidation.js"></script>
     <script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
				<script type="text/javascript" language="javascript" src="javascript/ad_rep_roapproval_detail.js"></script>

</head>
<body>
    <form id="form1" runat="server">
  <div id="divagency" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
	  <table cellpadding="0" cellspacing="0"><tr><td>
	  <asp:ListBox ID="lstagency" Width="382px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
	  </td></tr></table></div>
	   <div id="divclient" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
	  <table cellpadding="0" cellspacing="0"><tr><td>
	  <asp:ListBox ID="lstclient" Width="382px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
	  </td></tr></table></div>
	     <div id="divexcutive" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
	  <table cellpadding="0" cellspacing="0"><tr><td>
	  <asp:ListBox ID="istexcutive" Width="382px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
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
                                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtfrmdate, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/>
                                                      </td>
                                                        
													</tr>
													<tr>
													<td align="left">
														<asp:Label id="lbToDate" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                                    <asp:TextBox id="txttodate1" runat="server" CssClass="btext1" ></asp:TextBox>
                                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txttodate1, "mm/dd/yyyy")' onfocus="abc();" height="14" width="14"/>
                                                               </td>
														
                                                       	</tr>
                                                       	<tr>
														<td align="left"><asp:Label id="lblprint" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                                    <asp:DropDownList id="drprevenu" runat="server"  CssClass="dropdown" ></asp:DropDownList>
                                                        </td>
                                                        </tr>
                                                        <tr>
														<td align="left"><asp:Label id="lblbranch" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                                    <asp:DropDownList id="drpbranch" runat="server"  CssClass="dropdown" >
                                                                    <asp:ListItem Value="0">--Select Branch--</asp:ListItem>
                                                                  
                                                                    </asp:DropDownList>
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
							                            <td align="left" style="width: 106px"><asp:Label id="lblexcutive" runat="server" CssClass="TextField"></asp:Label></td>
							                            <td align="left" colspan="6"><asp:TextBox  ID="txtexecname"  runat="server" style="text-transform:uppercase;"  CssClass="btext1" Width="350" ></asp:TextBox></td>
						                            </tr>
												
													    
                                                        
                                                        
                                                        
                                                    
                                                  
                                                     
                                                       
													
                                                      <tr>
                                                        
                                                       <td align="left">
                                                        <asp:Label id="lblstatus" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                                    <asp:DropDownList id="dppstatus" runat="server"  CssClass="dropdown">
                                                                    <asp:ListItem Value="0">--Select Status--</asp:ListItem>
                                                                    <asp:ListItem Value="A">Approve</asp:ListItem>
                                                                    <asp:ListItem Value="R">Regect</asp:ListItem>
                                                                     <asp:ListItem Value="U">Unapprove</asp:ListItem>
                                                               
                                                                    </asp:DropDownList>
                                                        </td>
                                                        
                                                       </tr>
                                                       
													<tr>
														<td align="left"><asp:Label id="lbratecode" runat="server" CssClass="TextField"></asp:Label></td>
														<td align="left"><asp:DropDownList ID="drpbasedon" runat="server" CssClass="dropdown">
                                                              <asp:ListItem Value="B">BookingDate</asp:ListItem> 
                                                             <asp:ListItem Value="P">PublishDate</asp:ListItem>   
                                                                   </asp:DropDownList></td>
                                                        </tr>
													
                                                        <tr><td align="left">
                                                        <asp:Label id="lbdestination" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                                    <asp:DropDownList id="drpadate" runat="server" CssClass="dropdown" type="password"></asp:DropDownList>
                                                        </td></tr>
													</table>
													
													<table>
													<tr >
														<td align="center">
                                                                    <asp:button id="BtnRun" CssClass="btntext" Runat="server"  ></asp:button>
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
                       				</table>
		 <input id="hiddencomcode" type="hidden" size="1" name="hiddencomcode" runat="server"/>
			<input id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server"/> 
			<input id="hiddendateformat" type="hidden" size="1" name="Hidden2" runat="server"/>
			<input id="hiddencompcode" type="hidden" size="1" name="hiddencompcode" runat="server"/>
			<input id="hiddenusername" type="hidden" size="2" name="Hidden1" runat="server"/>
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
			<input id="hiddenbookingid" type="hidden" name="hiddenbookingid" runat="server" />
			<input id="hiddenrowcount" type="hidden" name="hiddenrowcount" runat="server" />
			<input id="hiddenadtype" type="hidden" name="hiddenadtype" runat="server" />
			<input id="hiddenid" type="hidden" name="hiddenid" runat="server" />
			<input id="hiddenmodify" value="0" type="hidden" name="hiddenmodify" runat="server" />
			<input id="hiddenrefresh" value="0" type="hidden" name="hiddenrefresh" runat="server" />
			<input id="hiddenuomdesc" value="0" type="hidden" name="hiddenuomdesc" runat="server" />
			<input id="hiddenbranch" type="hidden" size="1" name="hiddenbranch" runat="server"/>
					<input id="hiddenserverip" type="hidden" size="1" name="hiddenbranch1" runat="server"/>
			<input id="hdnexecutivetxt" type="hidden" size="1" name="hiddenbranch1" runat="server"/>
			<input id="hiddenagencycode2" type="hidden" size="1" name="hiddenagencycode2" runat="server"/>
		
		<input id="hiddenclientcode2" type="hidden" size="1" name="hiddenclientcode2" runat="server"/>
			<input id="hiddenclientcode" type="hidden" size="1" name="hiddenclientcode" runat="server"/>
		<input id="hiddenexcutivecode2" type="hidden" size="1" name="hiddenexcutivecode2" runat="server"/>
			<input id="hiddenexcutivecode" type="hidden" size="1" name="hiddenexcutivecode" runat="server"/>
	  <input id="hiddenretcode2" type="hidden" size="1" name="hiddenretcode2" runat="server"/>
			<input id="hiddenretcode" type="hidden" size="1" name="hiddenretcode" runat="server"/>
	
			<input id="hiddenbk_audit" type="hidden" size="1" name="hiddenbranch" runat="server"/>
				<input id="hdn_package" type="hidden" size="1"  runat="server"/>
				<input id="hiddenagencycode" type="hidden" size="1"  runat="server"/>
			
				<input id="hidden_client" type="hidden" size="1"  runat="server"/>
				<input id="hidden_section" type="hidden" size="1"  runat="server"/>
			<input id="hidattach1" type="hidden" size="1"  runat="server"/>
			<input id="hiddenediton" type="hidden" size="1"  runat="server"/>
	
	
    </form>
</body>
</html>
