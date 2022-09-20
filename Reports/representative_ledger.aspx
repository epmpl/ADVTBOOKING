<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeFile="representative_ledger.aspx.cs" Inherits="representative_ledger" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Executive/Retainer Wise Business Report</title>
     <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		<style type="text/css">.style1 { FONT-WEIGHT: bold; COLOR: #ffffff; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif }
	.style2 { COLOR: #ffffff }
		</style>
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<link href="css/booking.css" type="text/css" rel="stylesheet"/>
		<link href="css/report.css" type="text/css" rel="stylesheet"/>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
				<script type="text/javascript"  language="javascript" src="javascript/datevalidation.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/rept.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/new.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/ACDB.js"></script>
		
		<link href="css/report.css" rel="stylesheet" type="text/css" />

		<script type="text/javascript" language="javascript" src="javascript/disschreg.js"></script>
		<style type="text/css">.style1 { FONT-WEIGHT: bold; FONT-SIZE: xx-large; COLOR: #ffffff }
	.style2 { COLOR: #ffffff }
	.style4 { FONT-WEIGHT: normal; FONT-SIZE: 14pt; COLOR: #d85414; FONT-FAMILY: Verdana }
	.style6 { FONT-SIZE: x-small }
	.style7 { FONT-WEIGHT: bold; COLOR: #6666ff }
		</style>
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
<body onkeydown="javascript:return tabvalueexeret(event);" onkeypress="eventcalling(event);" onload="javascript:return clearretainerwise();">
    <form id="publicationrep" runat="server">
<%--     <asp:ScriptManager ID="ScriptManager2" runat="server">
                        </asp:ScriptManager>--%>
                        
      <div id="divdistrict" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
    <table cellpadding="0" cellspacing="0">
    <tr><td>
    <asp:ListBox ID="lstdistrict" Width="280px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
    </td></tr>
    </table>
    </div>                  
                        
                        
                        
     <div id="div1" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
	  <table cellpadding="0" cellspacing="0"><tr><td>
	  <asp:ListBox ID="lstagency" Width="315px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
	  </td></tr></table></div>
	   <div id="div2" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
	  <table cellpadding="0" cellspacing="0"><tr><td>
	  <asp:ListBox ID="lstclient" Width="315px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
	  </td></tr></table></div> 
	  
	  <div id="div4" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
	  <table cellpadding="0" cellspacing="0"><tr><td>
	  <asp:ListBox ID="lstretainer" Width="315px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
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
                                            <td>
                                               <%-- <asp:UpdatePanel ID="UpdatePanel53" runat="server">
                                                <ContentTemplate>--%>
                                                <asp:RadioButton ID="rbagency" runat="server" Checked="True" CssClass="TextField" Visible="false"
                                                Text="For On Screen" />
                                               <%-- </ContentTemplate></asp:UpdatePanel>--%>
                                            </td>
                                            <td style="width: 200px">
                                               <%-- <asp:UpdatePanel ID="UpdatePanel54" runat="server">
                                                <ContentTemplate>--%>
                                                <asp:RadioButton ID="rbclient" runat="server" CssClass="TextField" Text="For On Excel" Visible="false" />
                                                <%--</ContentTemplate></asp:UpdatePanel>--%>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr> 
												
													
													
													
													<tr>
														<td align="left">
														<asp:Label id="lbDateFrom" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                           <%-- <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:TextBox id="txtfrmdate" runat="server" CssClass="btext1" ></asp:TextBox>
                                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, publicationrep.txtfrmdate, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/>
                                                               <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
                                                        
													
													<td align="left">
														<asp:Label id="lbToDate" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                           <%-- <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:TextBox id="txttodate1" runat="server" CssClass="btext1" ></asp:TextBox>
                                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, publicationrep.txttodate1, "mm/dd/yyyy")' onfocus="abc();" height="14" width="14"/>
                                                              <%--  </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
														
                                                       	</tr>
                                                       <tr>
                                                        
                                                       <td align="left">
                                                        <asp:Label id="lbag" runat="server" Text="Agency" CssClass="TextField"></asp:Label></td>
														<td  align="left" colspan="3">
                                                           <%-- <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                                <ContentTemplate>--%>
                                                                   <asp:TextBox  ID="txt_agency"  runat="server"   CssClass="btext1" Width="300"  ></asp:TextBox>
                                                                     <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
                                                        
                                                       </tr>
                                                       <tr>
                                                        
                                                       <td align="left">
                                                        <asp:Label id="lbcl" runat="server" Text="Client" CssClass="TextField"></asp:Label></td>
														<td  align="left" colspan="3">
                                                           <%-- <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:TextBox  ID="txt_client"  runat="server"   CssClass="btext1" Width="300"  ></asp:TextBox>
                                                       <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
                                                        
                                                       </tr>
                                                																							
													<tr>
														<td align="left"><asp:Label id="lbPublication" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                           <%-- <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:DropDownList id="dppub1" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                                     <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
                                                      
                                                        
                                                       <td align="left">
                                                        <asp:Label id="lbPublicationCenter" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                           <%-- <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:DropDownList id="dppubcent" runat="server" CssClass="dropdown"  ></asp:DropDownList>
                                                               <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
                                                        
                                                       </tr>
                                                       
                                                                                 
                                                         
                                                         <tr>
                                                        
                                                       <td align="left">
                                                        <asp:Label id="lbbill" Text="BillNo." runat="server" CssClass="TextField" Visible="False"></asp:Label></td>
														<td  align="left">
                                                           <%-- <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:TextBox id="txtbill" runat="server" CssClass="dropdown"  Visible="False"></asp:TextBox >
                                                               <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
                                                        
                                                       </tr>
                                                       
                                                         <tr>
                                                        <td></td>
														 <td align="left" >
                                                                     <asp:RadioButton id="executivewise" runat="server" CssClass="TextField" Checked="true" ></asp:RadioButton>
                                                              </td><td>
                                                     
                                                                     <asp:RadioButton id="retainerwise" runat="server" CssClass="TextField"  ></asp:RadioButton>
                                                            </td>
                                                      
                                                        
                                                           
													</tr>
                                                          <tr>
                                                        
                                                       <td align="left"><asp:Label id="retainer" runat="server" CssClass="TextField" ></asp:Label>
                                                       </td>
														<td  align="left">
                                                           <%-- <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:TextBox  ID="txt_retainer"  runat="server"   CssClass="btext1" Width="300"  ></asp:TextBox>
                                                                <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
                                                        
                                                     
                                                        <td align="left"></td>
														<td align="left">
                                                                     
                                                       
                                                        </td>
                                                        
                                                       </tr>
                                                       <tr>
                                                       <td align="left"><asp:Label id="lbl_branch" runat="server" CssClass="TextField" ></asp:Label>
                                                       </td>
                                                       <td align="left"><asp:DropDownList id="dpd_branch" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                       </td>
                                                       <td align="left"><asp:Label id="lbagtype" runat="server" CssClass="TextField" ></asp:Label>
                                                       </td>
                                                       <td align="left"><asp:TextBox id="txtdistrict" runat="server" CssClass="btext1" Visible="true"></asp:TextBox>
                                                       </td>
                                                       
                                                       </tr>
                                                       
                                                       <tr>
                                                       
                                                       
                                                        <td align="left"> <asp:Label id="lbteam" runat="server" CssClass="TextField"></asp:Label></td>
                                                       <td align="left"><asp:DropDownList id="dpteam" runat="server" CssClass="dropdown"  ></asp:DropDownList></td>
                                                       <td align="left">
                                                        <asp:Label id="lbrevenue" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                          <%--  <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:DropDownList id="dpexec" runat="server" CssClass="dropdown"  ></asp:DropDownList>
                                                               <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
                                                       
                                                      
                                                       </tr>
                           
                                                        	
                                                       <tr>
														<td align="left" ><asp:Label id="lbAdtype" runat="server" CssClass="TextField"></asp:Label></td>
														  <td align="left"><%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:DropDownList CssClass="dropdown" id="dpaddtype" runat="server" ></asp:DropDownList>
                                                               <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
                                                        
												
                                                        <td align="left">
                                                        <asp:Label id="lbdestination" runat="server" CssClass="TextField" Visible="true"></asp:Label></td>
														<td  align="left">
                                                           <%-- <asp:UpdatePanel ID="UpdatePanel66" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:DropDownList id="Txtdest" runat="server" CssClass="dropdown" type="password"></asp:DropDownList>
                                                               <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
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
                                                               <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:button id="BtnRun" CssClass="btntext" Runat="server" OnClick="BtnRun_Click" ></asp:button>
                                                                    <asp:button id="btnsummary" CssClass="btntext" Runat="server" OnClick="Btnsummaryclick" ></asp:button>
                                                                
                                                                <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                               
                                                            </td>
                                                            <td align="center">
                                                               <%--  <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:button id="btnxl" Text ="On excel" CssClass="btntext" Runat="server"  Visible="False" ></asp:button>
                                                                <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                               
                                                            </td>
													</tr>
											<tr>		
												<td><input id="hiddendateformat" type="hidden" runat="server"/></td>
                         <td><input id="hiddendateformat1" type="hidden" runat="server" /></td>
			<%--	<td><input id="hindistrict" type="hidden" runat="server" /></td>
				<td><input id="hiddebranch" type="hidden" runat="server" /></td>--%>
				</tr>
				
			</table>
                                </td>
                            </tr>
                    </table>

        
                    </td>
                </tr>
            </table>

<input id="hiddencompcode" type="hidden" name="hiddencompcode" runat="server" />
<input id="hiddenuserid" type="hidden" name="hiddenuserid" runat="server" />
<input id="hiddenexecutive" type="hidden" name="hiddenexecutive" runat="server" />
<input id="hiddenexecutivename" type="hidden" name="hiddenexecutivename" runat="server" />
             <input id="hiddenuseid" type="hidden" name="hiddenuseid" runat="server" />
             
             <input id="hidden_dist_text" name="hidden_dist_text" runat="server" type="hidden" />
        <input id="hidden_dist" name="hidden_dist" runat="server" type="hidden" />   
<input id="hiddenascdesc" type="hidden" runat="server" />
   <input id="hiddencioid" type="hidden" runat="server" />
   <td><input id="hiddenolddate" type="hidden" name="hiddenolddate" runat="server" /></td>
    <input id="hdnagency" type="hidden" runat="server" />
                              <input id="hdnclient" type="hidden" runat="server" />
                              <input id="hdncompcode" type="hidden" runat="server" />
                                  <input id="hdnagencyname" type="hidden" runat="server" />
                              <input id="hdnclientname" type="hidden" runat="server" />
                              <input id="hdnretainer" type="hidden" name="hiddeneditionname" runat="server" />
   <input id="hdnretainername" type="hidden" name="hiddeneditionname" runat="server" />
    </form>
</body>
</html>
		
			
			
