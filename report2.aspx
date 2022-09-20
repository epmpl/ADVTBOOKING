<%@ Page Language="C#" AutoEventWireup="true" CodeFile="report2.aspx.cs" Inherits="report2" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Report</title>
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
		<script type="text/javascript" language="javascript" src="javascript/rept.js"></script>

		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
		<script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
				<script type="text/javascript" language="javascript" src="javascript/entertotab.js"></script>
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

<body onkeydown="javascript:return tabvalue(event);">
    <form id="form1" runat="server">

    
    <table width="1005" border="0" cellspacing="0" cellpadding="0" align="center" style="WIDTH: 1005px; HEIGHT: 358px">
				<tr>
					<td width="100%" bordercolor="#1"><img src="images/img_02A.jpg" width="1004" border="0" />
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    </td>
				</tr>
				<tr>
					<td width="100%" bordercolor="#1"><img src="images/top.jpg" width="1004" border="0" /></td>
				</tr>
				<tr>
					<td style="height: 505px"><table width="985" border="0" cellspacing="0" cellpadding="0" style="WIDTH: 985px; HEIGHT: 486px">
							<tr>
								<!---------left bar start--------->
								<td width="200" style="WIDTH: 200px"><img src="images/leftbar.jpg" style="WIDTH: 193px; HEIGHT: 483px" height="483" width="193" /></td>
								<!---------left bar end--------->
								<!---------middle start--------->
								<td width="80%" valign="top">
								
								<table cellpadding="0" cellspacing="0" width="790" style="WIDTH: 790px; HEIGHT: 488px" borderColorDark ="#000000" border="1">
										<tr>
											<td align="center">
											<table ><tr>
											<td><asp:Label ID="heading" runat ="server" CssClass="heading" meta:resourcekey="headingResource1"></asp:Label></td></tr>
											</table>
											
											<br />
											
											<table width="0" border="0" cellspacing="0" cellpadding="0">
													<tr>
														<td align="left" ><asp:Label id="agencyname" runat="server" CssClass="TextField" meta:resourcekey="agencynameResource1"></asp:Label></td>
														<td align="left"><asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList CssClass="dropdown" id="dpagencyna" runat="server" meta:resourcekey="dpagencynaResource1"></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        
													</tr>
													<tr><td align="left"></td>
													
													
													<td align="left" CssClass="checkbox" >
													
													 <asp:CheckBox ID="ChekAgency"  runat ="server"   /><font class="test">Including Sub Agency</font>
                                                            
                                                       
													</td>
													</tr>
													<tr>
													</tr>
													<tr></tr>
													<tr>
														<td align="left" ><asp:Label id="lbadtype" runat="server" CssClass="TextField" meta:resourcekey="lbadtypeResource1"></asp:Label></td>
														<td align="left"><asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList CssClass="dropdown" id="dpdadtype" runat="server" AutoPostBack="false" OnSelectedIndexChanged="dpdadtype_SelectedIndexChanged" meta:resourcekey="dpdadtypeResource1" ></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        
													</tr>
													<tr>
													</tr>
													<tr ></tr>
													<td align="left"><asp:Label id="lbadcatgory" runat="server" CssClass="TextField" meta:resourcekey="lbadcatgoryResource1" ></asp:Label></td>
														<td align="left"><asp:UpdatePanel ID="UpdatePanel10" runat="server" >
                                                                <ContentTemplate>
                                                                    <asp:ListBox id="dpadcatgory" runat="server" CssClass="btext1" Height ="66px" SelectionMode="Multiple" Width="144px" meta:resourcekey="dpadcatgoryResource1">
                                                                        <asp:ListItem>--ALL--</asp:ListItem>
                                                                        
                                                                    </asp:ListBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
													
													<tr>
														
													</tr>
													<tr></tr>
													<tr>
														<td align="left">
														<asp:Label id="lbDateFrom" runat="server" CssClass="TextField" meta:resourcekey="lbDateFromResource1"></asp:Label></td>
														<td  align="left">
                                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox id="txtfrmdate" runat="server" CssClass="btext1" meta:resourcekey="txtfrmdateResource1" ></asp:TextBox>
                                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtfrmdate, "mm/dd/yyyy")'  height=14 width=14 />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        
													</tr>
													<tr>
													<td align="left">
														<asp:Label id="lbToDate" runat="server" CssClass="TextField" meta:resourcekey="lbToDateResource1"></asp:Label></td>
														<td  align="left">
                                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox id="txttodate1" runat="server" CssClass="btext1" meta:resourcekey="txttodate1Resource1" ></asp:TextBox>
                                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txttodate1, "mm/dd/yyyy")'  height=14 width=14/>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
														
                                                       	</tr>
													<tr>
														<td align="left"><asp:Label id="lbPublication" runat="server" CssClass="TextField" meta:resourcekey="lbPublicationResource1"></asp:Label></td>
														<td align="left">
                                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList id="dppub1" runat="server" CssClass="dropdown"  AutoPostBack="True" meta:resourcekey="dppub1Resource1"></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
													</tr>
                                                        <tr><td align="left">
                                                        <asp:Label id="lbPublicationCenter" runat="server" CssClass="TextField" meta:resourcekey="lbPublicationCenterResource1"></asp:Label></td>
														<td  align="left">
                                                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList id="dppubcent" runat="server" CssClass="dropdown" type="password"  AutoPostBack="True" meta:resourcekey="dppubcentResource1" OnSelectedIndexChanged="dppubcent_SelectedIndexChanged2"></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td></tr>
                                                        
                                                            
                                                            
                                                            <tr><td align="left">
                                                        <asp:Label id="lbEdition" runat="server" CssClass="TextField" meta:resourcekey="lbEditionResource1"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList id="dpedition" runat="server" CssClass="dropdown" type="password" meta:resourcekey="dpeditionResource1"></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td></tr>
                                                        
                                                        
                                                        
                                                         <tr><td align="left">
                                                        <asp:Label id="lbdestination" runat="server" CssClass="TextField" meta:resourcekey="lbdestinationResource1"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList id="Txtdest" runat="server" CssClass="dropdown" type="password" meta:resourcekey="TxtdestResource1"></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td></tr>
                                                            
                                                            
													</table>
													
													
													<table>
													<tr >
														<td align="center">
                                                               <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:button id="BtnRun" CssClass="btntext" Runat="server" OnClick="BtnRun_Click" meta:resourcekey="BtnRunResource1" ></asp:button>
                                                                </ContentTemplate></asp:UpdatePanel>
                                                            
                                                               
                                                            </td>
													</tr>
													</table> 
												
													</tr>
														</table>
                                                
												</td>
								<!---------middle end--------->
							</tr>
						</table>
                    </td>
                </tr>
    </table>
      
         <input id="hiddendateformat" type="hidden" runat="server" />
         
   
			
			<input id="hiddenascdesc" type="hidden" runat="server" />
   <input id="hiddencioid" type="hidden" runat="server" />
   <input id="hdnagencytxt" type="hidden" runat="server" />
   <input id="hiddenadcat" type="hidden" runat="server" />
   <input id="hiddenedition" type="hidden" runat="server" />
   <input id="hiddeneditionname" type="hidden" runat="server" />
   <input id="hdnagency1" type="hidden" runat="server" />
   <input id="hiddenadcatname" type="hidden" runat="server" />
    <input id="hiddenagencyname" type="hidden" runat="server" />
   <input id="hiddenagency" type="hidden" runat="server" />
   <td><input id="hiddenolddate" type="hidden" name="hiddenolddate" runat="server" /></td>
   
    </form>
</body>
</html>
                       
				