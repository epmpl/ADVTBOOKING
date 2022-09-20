<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BillRegister_Chklst.aspx.cs" Inherits="BillRegister_Chklst" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bill Register (Check List)</title>
    
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
    <link href="css/booking.css" type="text/css" rel="stylesheet"/>
    <link href="css/report.css" type="text/css" rel="stylesheet"/>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <script type="text/javascript"  language="javascript" src="javascript/datevalidation.js"></script>
    <script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
    <script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
    <script type="text/javascript" language="javascript" src="javascript/BillRegister_Chklst.js"></script>
</head>
<body onkeydown="javascript:return tabvalue();" onload="document.getElementById('txtfrmdate').focus();">
     <form id="billregchklst" runat="server">

    <div id="divagency" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:0;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstagency" Width="124px"  Height="35px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div> 
			 
<div id="divclient" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:0;"><table cellpadding="0" cellspacing="0"><tr><td>

<asp:ListBox ID="lstclient" Width="124px" Height="65px" runat="server" CssClass="btextlist" ></asp:ListBox>

</td></tr></table></div> 
<div id="divproduct" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:0;"><table cellpadding="0" cellspacing="0"><tr><td style="height: 110px">
<asp:ListBox ID="lstproduct" Width="124px" Height="65px" runat="server" CssClass="btextlist" ></asp:ListBox>
</td></tr></table></div> 
  
			<table width="1005" border="0" cellspacing="0" cellpadding="0" align="center" style="WIDTH: 1005px; HEIGHT: 358px">
				<tr>
					<td width="100%" bordercolor="#1"><img alt="" src="images/img_02A.jpg" width="1004" border="0" />
                       
                    </td>
				</tr>
				<tr>
					<%--<td width="100%" bordercolor="#1"><img alt="" src="images/top.jpg" width="1004" border="0" /></td>--%>
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
											<td><asp:Label ID="heading" runat ="server" CssClass="heading"></asp:Label></td></tr>
											</table>
											<br />
											
											<table width="0" border="0" cellspacing="0" cellpadding="2">
													<tr>
														<td align="left">
														<asp:Label id="lbDateFrom" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                        
                                                                    <asp:TextBox id="txtfrmdate" runat="server" CssClass="btext1" ></asp:TextBox>
                                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, billregchklst.txtfrmdate, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/>
                                                               
                                                        </td>
                                                        
													</tr>
													<tr>
													<td align="left">
														<asp:Label id="lbToDate" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                           
                                                                    <asp:TextBox id="txttodate1" runat="server" CssClass="btext1" ></asp:TextBox>
                                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, billregchklst.txttodate1, "mm/dd/yyyy")' onfocus="abc();" height="14" width="14"/>
                                                                
                                                        </td>
														
                                                       	</tr>
                                                       	<tr>
                                                       	
                                                       	<td align="left">
                                                        <asp:Label id="lbladtype" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                          
                                                                    <asp:DropDownList id="drpadtype" runat="server" CssClass="dropdown" >
                                                                    </asp:DropDownList>
                                                               
                                                        </td>
                                                        
                                                        </tr>
                                                           <tr>
                                                        
                                                        <td align="left">
                                                        <asp:Label id="lbpublication" runat="server" CssClass="TextField" Visible="False"></asp:Label></td>
														<%--<td  align="left">
                                                           
                                                       
                                                       <asp:DropDownList id="dppub1"  runat="server" CssClass="dropdown" Visible="False"></asp:DropDownList>
                                                                        
                                                                   
                                                       
                                                        </td>--%>
                                                        
                                                        </tr>
                                                        
                                                         <tr><td align="left">
                                                        <asp:Label id="lbPublicationCenter" runat="server" CssClass="TextField" ></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                           
                                                                    <asp:DropDownList id="dppubcent" runat="server" CssClass="dropdown"  ></asp:DropDownList>
                                                             
                                                        </td></tr>
                                                         <tr>
                                                        
                                                        <td align="left">
                                                        <asp:Label id="lbedition"  runat="server" CssClass="TextField" Visible="False"></asp:Label></td>
														<td  align="left">
                                                           
                                                       
                                                       <asp:DropDownList id="dpedition" runat="server" CssClass="dropdown" Visible="False">
                                                       <asp:ListItem Value="0">--Select Edition Name--</asp:ListItem></asp:DropDownList>
                                                                        
                                                       
                                                        </td>
                                                        
                                                        </tr>
                                                        
                                                    	<tr>
                                                       	
                                                       	<td align="left">
                                                        <asp:Label id="lblbranch" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                          
                                                                    <asp:DropDownList id="drpbranch" runat="server" CssClass="dropdown" >
                                                                    </asp:DropDownList>
                                                               
                                                        </td>
                                                        
                                                        </tr>
													
                                                        <tr>
                                                        
													<td align="left"><asp:Label id="lbagtype" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                     <asp:DropDownList id="dpagtype" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                               
                                                        </td>
													</tr>
                                                        
                                                        
                                                        <tr>
                                                        
													<td align="left"><asp:Label id="lblratecode" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                     <asp:DropDownList id="drpratecode" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                               
                                                        </td>
													</tr>
													<tr>
                                                        
													<td align="left"><asp:Label id="lbluom" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                     <asp:DropDownList id="drpuom" runat="server" CssClass="dropdown">
                                                                     <asp:ListItem Value="0">--- Select Uom ---</asp:ListItem></asp:DropDownList>
                                                               
                                                        </td>
													</tr>
													
													
													 <tr><td align="left">
                                                        <asp:Label id="lblcolor" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            
                                                                    <asp:DropDownList id="drpcolor" runat="server" CssClass="dropdown">
                                                                    <asp:ListItem Value="0">All</asp:ListItem>
                                                                    <asp:ListItem Value="CO0">Color</asp:ListItem>
                                                                    <asp:ListItem Value="B">Black & White</asp:ListItem></asp:DropDownList>
                                                              
                                                        </td></tr>
													
													
													
													
													 <tr>
													    <td align="left"><asp:Label id="lblfilteron" runat="server" CssClass="TextField" ></asp:Label>
													    </td>
														<td align="left"><asp:DropDownList id="drpfilteron" runat="server" CssClass="dropdown" >
														        <asp:ListItem Value="0">All</asp:ListItem>
														                 <asp:ListItem Selected="True" Value="1">Only Billed</asp:ListItem>
														               <asp:ListItem   Value="2">Not Billed</asp:ListItem>
														                <asp:ListItem Value="3">To Be Billed</asp:ListItem>
                                                                        
                                                            </asp:DropDownList>
                                                               
                                                        </td>
													</tr>
													
													
													
													
                                                        <tr><td align="left">
                                                        <asp:Label id="lbdestination" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            
                                                                    <asp:DropDownList id="Txtdest" runat="server" CssClass="dropdown">
                                                                    <asp:ListItem Value="1">On Screen</asp:ListItem>
                                                                    <asp:ListItem Value="4">Excel Sheet</asp:ListItem></asp:DropDownList>
                                                              
                                                        </td></tr>
														
													</table>
													
													<table>
													<tr>
														<td align="center"><asp:button id="BtnRun" CssClass="btntext" Runat="server" OnClick="BtnRun_Click" Width="60px" ></asp:button>
                                                            <asp:button id="Btnsummary" CssClass="btntext" Runat="server" Width="60px" 
                                                                ></asp:button>
                                                                <asp:button id="btndetail" CssClass="btntext" Runat="server" Width="60px" 
                                                                ></asp:button>
                                                                   <asp:button id="btndaily" CssClass="btntext" Runat="server" Width="60px" 
                                                                ></asp:button>
                                                                
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
								<!---------middle end--------->
							</tr>
						</table>
						<table>
						<tr><td>
                        <input id="hiddendateformat" type="hidden" runat="server" /></td>
                         <td><input id="hiddendateformat1" type="hidden" runat="server" /></td>
                           <td><input id="hiddendateformat2" type="hidden" runat="server" /></td>
                           <td><input id="hiddenolddate" type="hidden" name="hiddenolddate" runat="server" /></td>
                           <td><input id="hiddenascdesc" type="hidden" runat="server" />
                            <input id="hiddencioid" type="hidden" runat="server" />
                             <input id="hiddencompcode" type="hidden" runat="server" />
                              <input id="hiddenedition" type="hidden" name="hiddenedition" runat="server" />
      <input id="hiddeneditionname" type="hidden" name="hiddeneditionname" runat="server" />
              <td> <input id="hdnexecode" runat="server"  type="hidden" /></td>
                            <td> <input id="hdnexename" runat="server"  type="hidden" /></td>
                         <td> <input id="hidden1" runat="server"  type="hidden" /></td>
                                      
   </td>
                         
			</tr>
				
			</table>
			
			
        <%--</TD></TR></TABLE>--%>
       <%-- </TD></TR></TABLE>--%>

       

        
     
    </form>
</body>
</html>
