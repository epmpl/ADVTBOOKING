<%@ Page Language="C#" AutoEventWireup="true" CodeFile="packagewisereport.aspx.cs" Inherits="packagewisereport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <title>Package Wise Report</title>
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
		<script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/rept.js"></script>
		<%--<script type="text/javascript" language="javascript" src="javascript/disschreg.js"></script>--%>
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
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
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
                                                           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox id="txtfrmdate" runat="server" CssClass="btext1" ></asp:TextBox>
                                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this,form1.txtfrmdate, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/>
                                                               </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        
													</tr>
													<tr>
													<td align="left">
														<asp:Label id="lbToDate" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                             <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox id="txttodate1" runat="server" CssClass="btext1" ></asp:TextBox>
                                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this,form1.txttodate1, "mm/dd/yyyy")' onfocus="abc();" height="14" width="14"/>
                                                                 </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
														
                                                       	</tr>
                                                       	
                                                       	 <tr><td align="left">
                                                        <asp:Label id="lbagency" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                             <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList id="drpagency" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                               </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td></tr>
                                                        
                                                        
                                                         <tr><td align="left">
                                                        <asp:Label id="lbclient" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList id="drpclient" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                                 </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td></tr>
                                                        
                                                         <tr>
                                                        
													<td align="left"><asp:Label id="lbadtype" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
														<asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                <ContentTemplate>
                                                                     <asp:DropDownList id="dpadtype" runat="server" CssClass="dropdown" OnSelectedIndexChanged="dpadtype_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
													</tr>
                                                        <tr>
														<td align="left"><asp:Label id="lbPublication" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList id="dppub1" runat="server" CssClass="dropdown" OnSelectedIndexChanged="dppub1_SelectedIndexChanged1" AutoPostBack="True"></asp:DropDownList>
                                                                    </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        </tr>
                                                        
                                                        <tr>
                                                        
                                                       <td align="left">
                                                        <asp:Label id="lbPublicationCenter" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                             <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList id="dppubcent" runat="server" CssClass="dropdown" OnSelectedIndexChanged="dppubcent_SelectedIndexChanged" type="password"  AutoPostBack="True"></asp:DropDownList>
                                                                   </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        
                                                       </tr>
                                                       
                                                       <tr>
                                                            <td align="left">
                                                        <asp:Label id="lbEdition" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                           <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList id="dpedition" runat="server" CssClass="dropdown" type="password"></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td></tr>
                                                       
                                                    
                                                        
                                                         <tr><td align="left">
                                                        <asp:Label id="lbpackage" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                             <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList id="drppackage" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                                 </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td></tr>
                                                       
                                                        <tr><td align="left">
                                                        <asp:Label id="lbdestination" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList id="Txtdest" runat="server" CssClass="dropdown" type="password"></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td></tr>
                                                        </table>
                                                        <table>
													<tr >
														<td align="center">
                                                                 <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:button id="BtnRun" CssClass="btntext" Runat="server" OnClick="BtnRun_Click" ></asp:button>
                                                                    </ContentTemplate>
                                                            </asp:UpdatePanel> 
                                                               
                                                            </td>
													</tr>
													
												</table>
													</tr>
														</table>
                                                
												</td>
                                                
												
							</tr>
						</table>
						</td></tr></table>
                        <input id="hiddendateformat" type="hidden" runat="server" />
                         <input id="hiddendateformat1" type="hidden" runat="server" />
                           <input id="hiddendateformat2" type="hidden" runat="server" />
                          <input id="hiddenolddate" type="hidden" name="hiddenolddate" runat="server" />
                           <input id="hiddenascdesc" type="hidden" runat="server" />
                            <input id="hiddencioid" type="hidden" runat="server" />
    </form>
</body>
</html>
