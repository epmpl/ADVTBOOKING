<%@ Page Language="C#" AutoEventWireup="true" CodeFile="multiclientschedulereg.aspx.cs" Inherits="multiclientschedulereg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title> Multi Client Schedule Register Report</title>
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
		<script type="text/javascript"  language="javascript" src="javascript/billbook.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/multiclientschereg.js"></script>
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
<body  onkeypress="eventcalling(event);" onload="document.getElementById('txtfrmdate').focus();">
    <form id="publicationrep" runat="server">
    
    <%--onkeydown="javascript:return tabvalueschreg(event);"--%>
    
                    <div id="div1" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
	  <table cellpadding="0" cellspacing="0"><tr><td>
	  <asp:ListBox ID="lstsectioncode" Width="315px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
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
                                                            <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:TextBox id="txtfrmdate" runat="server" CssClass="btext1" ></asp:TextBox>
                                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, publicationrep.txtfrmdate, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/>
                                                                <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
                                                        
													</tr>
													<tr>
													<td align="left">
														<asp:Label id="lbToDate" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                           <%-- <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:TextBox id="txttodate1" runat="server" CssClass="btext1" ></asp:TextBox>
                                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, publicationrep.txttodate1, "mm/dd/yyyy")' onfocus="abc();" height="14" width="14"/>
                                                                <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
														
                                                       	</tr>
                                                       	
                                                       	  <tr>
														<td align="left" ><asp:Label id="lbAdtype" runat="server" CssClass="TextField"></asp:Label></td>
														  <td align="left"><%--<asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:DropDownList CssClass="dropdown" id="dpaddtype" runat="server" ></asp:DropDownList>
                                                                <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
                                                        
													</tr>
												
													
													<tr>
													<td align="left"><asp:Label id="lbadcatgory" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left"><%--<asp:UpdatePanel ID="UpdatePanel2" runat="server" >
                                                                <ContentTemplate>--%>
                                                                    <asp:ListBox id="dpadcatgory" runat="server" CssClass="btext1" Height ="66px"  SelectionMode="Multiple" Width="144px">
                                                                        <asp:ListItem>--Select Ad Cat--</asp:ListItem>
                                                                        
                                                                    </asp:ListBox>
                                                               <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
													</tr>
													
													
													      <tr>
														<td align="left"><asp:Label id="Label1" Text="Package Detail Required" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            <%--<asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:DropDownList id="drppackagedetail" runat="server"  CssClass="dropdown"  ></asp:DropDownList>
                                                                   <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
                                                        </tr>
                                                        
                                                        
                                                        
                                                    
                                                      
                                                      <tr>
														<td align="left"><asp:Label id="Label2" runat="server" Text="Package" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                           <%-- <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:DropDownList id="drppackage" runat="server"  CssClass="dropdown" ></asp:DropDownList>
                                                                 <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
                                                        </tr>
                                                        
                                                     
                                                       
													
													<tr>
														<td align="left"><asp:Label id="lbPublication" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            <%--<asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:DropDownList id="dppub1" runat="server"  CssClass="dropdown" ></asp:DropDownList>

                                                               <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
                                                        </tr>
                                                        
                                                        
                                                        
                                                     
                                                      
                                                
                                                        
                                                        
                                                      <tr>
                                                        
                                                       <td align="left">
                                                        <asp:Label id="lbPublicationCenter" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                           <%-- <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:DropDownList id="dppubcent" runat="server"  CssClass="dropdown"    ></asp:DropDownList>
                                                               <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
                                                        
                                                       </tr>
                                                     
													
                                                       
                                                      <tr>
                                                            <td align="left">
                                                        <asp:Label id="lbEdition" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                           <%-- <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:DropDownList id="dpedition" runat="server" CssClass="dropdown" ></asp:DropDownList>
                                                               <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td></tr>
                                                       
                                                         
                                                      <tr>
                                                            <td align="left">
                                                        <asp:Label id="suppliment" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                           <%-- <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:DropDownList id="dpsuppliment" runat="server" CssClass="dropdown" type="password"></asp:DropDownList>
                                                               <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td></tr>
                                                       
                                                       
                                                       <tr><td align="left">
                                                        <asp:Label id="editiondetail" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                           <%-- <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:DropDownList id="dpedidetail" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                               <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td></tr>
                                                        <tr>
                                                        
													<td align="left"><asp:Label id="lbl_branch" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left"><%--<asp:UpdatePanel ID="UpdatePanel13" runat="server" >
                                                                <ContentTemplate>--%>
                                                                     <asp:DropDownList id="dpd_branch" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                               <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
													</tr>     
                                                        
                                                       
                                                        <tr><td align="left">
                                                        <asp:Label id="status" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                           <%-- <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:DropDownList id="drpstatus" runat="server" CssClass="dropdown">
                                                                    <asp:ListItem Text="--Select Status--" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="Include Cancel" Value="cancel"></asp:ListItem>
                                                                     <asp:ListItem Text="Include Hold" Value="hold"></asp:ListItem>
                                                                    
                                                                    </asp:DropDownList>
                                                                 
                                                              <%--  </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td></tr>
                                                        
                                                        
                                                        <tr><td align="left">
                                                        <asp:Label id="lblrostatus" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                           <%-- <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:DropDownList id="ddlrostatus" runat="server" CssClass="dropdown">
                                                                 <%--   <asp:ListItem Text="-Select RO Status-" Value="0"></asp:ListItem>--%>
                                                                    <asp:ListItem Text="Confirm" Value="1" Selected="True"></asp:ListItem>
                                                                     <asp:ListItem Text="Reservation" Value="2"></asp:ListItem>
                                                                    
                                                                    </asp:DropDownList>
                                                                 
                                                              <%--  </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td></tr>
                                                        
                                                        
                                                        
                                                        
                                                        
                                                          <tr><td align="left">
                                                        <asp:Label id="lbldesigner" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            
                                                                  <%--    <asp:DropDownList id="drpagency" runat="server" CssClass="dropdown"></asp:DropDownList>--%>
                                                                    <asp:TextBox  ID="txt_designer"  runat="server"   CssClass="btext1" Width="135"  ></asp:TextBox>
                                                               
                                                        </td></tr>
                                                        
                                                        
                                                        
                                                        
                                                       
                                                        
                                                        <tr><td align="left">
                                                        <asp:Label id="lbdestination" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            <%--<asp:UpdatePanel ID="UpdatePanel66" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:DropDownList id="Txtdest" runat="server" CssClass="dropdown" type="password"></asp:DropDownList>
                                                               <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td></tr>
														
														 <tr><td align="center" id="fg" colspan="2" style="display:none;">
                                                         
                                                       
                                                       
                                                                    <asp:RadioButton id="exe" runat="server"  Checked="true" Text="Excel"></asp:RadioButton>
                                                                    <asp:RadioButton id="csv" runat="server"  Text="CSV"></asp:RadioButton>
                                                                    
                                                      
                                                              
                                                        </td></tr>
													</table>
													
													<table>
													<tr >
														<td align="center">
                                                                <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:button id="BtnRun" CssClass="btntext" Runat="server"  ></asp:button>
                                                                 <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                               
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





