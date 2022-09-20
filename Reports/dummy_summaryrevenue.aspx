<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dummy_summaryrevenue.aspx.cs" Inherits="Reports_dummy_summaryrevenue" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Dummy Revenue Report</title>
 <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1"/>
	<meta name="CODE_LANGUAGE" content="C#"/>
	<meta name="vs_defaultClientScript" content="JavaScript"/>
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
	
    <link href="css/report.css" rel="stylesheet" type="text/css" />
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
	<link href="css/booking.css" type="text/css" rel="stylesheet"/>
	<script type="text/javascript"  language="javascript" src="javascript/datevalidation.js"></script>
	<script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
    <script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script> 
   	<script type="text/javascript"  language="javascript" src="javascript/dummy_revenue.js"></script>

   			<script language="javascript" type="text/javascript">
   			    function forfocus() {
   			        document.getElementById('Txtusernme').focus();
   			    }
   			    function maximize() {
   			        window.moveTo(0, 0)
   			        window.resizeTo(screen.availWidth, screen.availHeight)
   			    }
   			    maximize();
		</script>
   	<style type="text/css">.style1 { FONT-WEIGHT: bold; FONT-SIZE: xx-large; COLOR: #ffffff }
	.style2 { COLOR: #ffffff }
	.style4 { FONT-WEIGHT: normal; FONT-SIZE: 14pt; COLOR: #d85414; FONT-FAMILY: Verdana }
	.style6 { FONT-SIZE: x-small }
	.style7 { FONT-WEIGHT: bold; COLOR: #6666ff }
		</style></head>
<body>
    <form id="RevnSum" runat="server">
      
    <div id="divagency" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:0;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstagency" Width="124px"  Height="35px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div> 
			 
<div id="divclient" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:0;"><table cellpadding="0" cellspacing="0"><tr><td>
<%--<asp:UpdatePanel  ID="UpdatePanel71" runat="server"><ContentTemplate>--%>
<asp:ListBox ID="lstclient" Width="124px" Height="65px" runat="server" CssClass="btextlist" ></asp:ListBox>
<%--</ContentTemplate></asp:UpdatePanel>--%>
</td></tr></table></div> 
<div id="divproduct" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:0;"><table cellpadding="0" cellspacing="0"><tr><td style="height: 110px">
<%--<asp:UpdatePanel  ID="UpdatePanel70" runat="server"><ContentTemplate>--%>
<asp:ListBox ID="lstproduct" Width="124px" Height="65px" runat="server" CssClass="btextlist" ></asp:ListBox>
<%--</ContentTemplate></asp:UpdatePanel>--%>
</td></tr></table></div> 
  
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
								
					    <table cellpadding="0" cellspacing="0" width="790" style="WIDTH: 790px; HEIGHT: 488px" borderColorDark="#000000" border="1">
										
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
                                            <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>--%>
                                                    <asp:TextBox id="txtfrmdate" runat="server" CssClass="btext1" ></asp:TextBox>
                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, RevnSum.txtfrmdate, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/>
                                               <%-- </ContentTemplate>
                                            </asp:UpdatePanel>--%>
                                        </td>
                                        
									</tr>
									
                                                  <%--  <tr>
														<td align="left" ><asp:Label id="lbadtype" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left"><%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                <ContentTemplate>--%>
                                                            <%--        <asp:DropDownList CssClass="dropdown" id="dpdadtype" runat="server" ></asp:DropDownList>
                                                                <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                      <%--  </td>
                                                        
													</tr>  --%>   	
                                               	<tr>
                                               	
                                               	<td align="left">
                                                <asp:Label id="lbpub" runat="server" CssClass="TextField"></asp:Label></td>
												<td  align="left">
                                                   <%-- <asp:UpdatePanel ID="UpdatePane21" runat="server">
                                                        <ContentTemplate>--%>
                                                            <asp:DropDownList id="dppub1" runat="server" CssClass="dropdown"  ></asp:DropDownList>
                                                       <%-- </ContentTemplate>
                                                    </asp:UpdatePanel>--%>
                                                </td>
                                                
                                                </tr>
                                                   <tr><td align="left">
                                                        <asp:Label id="lbPublicationCenter" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                            <%--<asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:DropDownList id="dppubcent" runat="server" CssClass="dropdown"  ></asp:DropDownList>
                                                               <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td></tr>
                                                <tr>
                                               <td align="left">
                                                <asp:Label id="lbedition" runat="server" CssClass="TextField"></asp:Label></td>
												<td  align="left">
                                                    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                        <ContentTemplate>--%>
                                                <asp:DropDownList id="dpedition" runat="server" CssClass="dropdown"></asp:DropDownList>
                                             
                                                </td>
                                                </tr>
                                                    
                                                        <tr><td align="left">
                                                        <asp:Label id="lbdestination" runat="server" CssClass="TextField" ></asp:Label></td>
														<td  align="left">
                                                        <asp:DropDownList id="Txtdest" runat="server" CssClass="dropdown" type="password" ></asp:DropDownList>
                                                             
                                                        </td></tr>
                                                        <tr><td align="left">
                                                        <asp:Label id="lblincludehold" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                                    <asp:DropDownList id="drpincludehold" runat="server" CssClass="dropdown" type="password">
                                                                    <asp:ListItem Value="1">Edit</asp:ListItem> <asp:ListItem Value="2">Revenue</asp:ListItem>
                                                                    </asp:DropDownList>
                                                        </td></tr>
														
													
													</table>
													
													<table>
													<tr >
														<td align="center">
														<%--<asp:UpdatePanel ID="updatebtn" runat ="server">
                                                                <ContentTemplate >--%>
                                                                    <asp:button id="BtnRun" CssClass="btntext"  Runat="server" OnClick="BtnRun_Click"></asp:button><%----%>
                                                                    <%--</ContentTemplate>
                                                                    </asp:UpdatePanel> --%>
                                                                    
                                                                    
                                                              
                                                               
                                                            </td>
													</tr>
													
												</table>
												<table style="width: 223px" >
												<tr>
														<%--<td align="left" colSpan="2" style="width: 72px; height: 25px;">
															</td>--%>
															
															
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
                           <td><input id="hiddenolddate" type="hidden" name="hiddenolddate" runat="server" />
                           <td style="height: 26px"><input id="hiddenascdesc" type="hidden" runat="server" />
                            <input id="hiddencioid" type="hidden" runat="server" />
                           
                           </td>
                         
			</tr>
				
			</table>
        			
	 <input id="hiddencompcode" type="hidden" name="hiddencompcode" runat="server" />
    <input id="hiddenadcat" type="hidden" name="hiddenadcat" runat="server" />
     <input id="hiddenadsubcat" type="hidden" name="hiddenadsubcat" runat="server" />
      <input id="hiddenadcatname" type="hidden" name="hiddenadcatname" runat="server" />
     <input id="hiddenadsubcatname" type="hidden" name="hiddenadsubcatname" runat="server" />
      <input id="hiddenedition" type="hidden" name="hiddenedition" runat="server" />
      <input id="hiddeneditionname" type="hidden" name="hiddeneditionname" runat="server" />

    </form>
</body>
</html>
