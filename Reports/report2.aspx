<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeFile="report2.aspx.cs" Inherits="report2" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>All Ads Of Agency</title>
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
		<script type="text/javascript"  language="javascript" src="javascript/datevalidation.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/rept.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/billbook.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/new.js"></script>

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
<body  onclick="chklstagency();" onkeypress="eventcalling(event)" onkeydown="javascript:return tabvalueadagency(event);chklstagency();" onload="javascript:return clearreport2();">
    <form id="form1" runat="server">

    <div id="div1" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
	  <table cellpadding="0" cellspacing="0"><tr><td>
	  <asp:ListBox ID="lstagency" Width="382px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
	  </td></tr></table></div>
    <table width="1005" border="0" cellspacing="0" cellpadding="0" align="center" style="WIDTH: 1005px; HEIGHT: 358px">
				<tr>
					<td width="100%" bordercolor="#1"><img src="images/img_02A.jpg" width="1004" border="0" />
                        <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>--%>
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
														<td align="left"><%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <%--<asp:DropDownList CssClass="dropdownget" id="dpagency" runat="server" meta:resourcekey="dpagencyResource1"></asp:DropDownList>--%>
                                                                    <asp:TextBox CssClass="dropdownget" id="dpagency" runat="server" meta:resourcekey="dpagencyResource1"></asp:TextBox>
                                                               <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
                                                        
													</tr>
													<tr><td align="left"></td>
													
													
													<td align="left" CssClass="checkbox" >
													
													 <asp:CheckBox ID="ChekAgency"  runat ="server"   /><font class="test">Including Sub Agency</font>
                                                            
                                                       
													</td>
													</tr>
													<tr>
														<td align="left" ><asp:Label id="lbadtype" runat="server" CssClass="TextField" meta:resourcekey="lbadtypeResource1"></asp:Label></td>
														<td align="left"><%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:DropDownList CssClass="dropdown" id="dpdadtype" runat="server" >
                                                                    </asp:DropDownList>
                                                               <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
                                                        
													</tr>
													<td align="left"><asp:Label id="lbadcatgory" runat="server" CssClass="TextField" meta:resourcekey="lbadcatgoryResource1" ></asp:Label></td>
														<td align="left"><%--<asp:UpdatePanel ID="UpdatePanel10" runat="server" >
                                                                <ContentTemplate>--%>
                                                                    <asp:ListBox id="dpadcatgory" runat="server" CssClass="btext1" Height ="66px" SelectionMode="Multiple" Width="144px" meta:resourcekey="dpadcatgoryResource1" >
                                                                        <asp:ListItem>--Select Ad Cat--</asp:ListItem>
                                                                        
                                                                    </asp:ListBox>
                                                               <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
													
													<tr>
														<td align="left"><asp:Label id="lbluom" runat="server" CssClass="TextField" meta:resourcekey="lbPublicationResource1"></asp:Label></td>
														<td align="left">
                                                            <%--<asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:DropDownList id="drpuom" runat="server" CssClass="dropdown"   meta:resourcekey="dppub1Resource1">
                                                                    <asp:ListItem>--Select UOM--</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
													</tr>
													<tr>
														<td align="left">
														<asp:Label id="lbDateFrom" runat="server" CssClass="TextField" meta:resourcekey="lbDateFromResource1"></asp:Label></td>
														<td  align="left">
                                                           <%-- <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:TextBox id="txtfrmdate" runat="server" CssClass="btext1" meta:resourcekey="txtfrmdateResource1" ></asp:TextBox>
                                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtfrmdate, "mm/dd/yyyy")'  height=14 width=14 />
                                                               <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
                                                        
													</tr>
													<tr>
													<td align="left">
														<asp:Label id="lbToDate" runat="server" CssClass="TextField" meta:resourcekey="lbToDateResource1"></asp:Label></td>
														<td  align="left">
                                                           <%-- <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:TextBox id="txttodate1" runat="server" CssClass="btext1" meta:resourcekey="txttodate1Resource1" ></asp:TextBox>
                                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txttodate1, "mm/dd/yyyy")'  height=14 width=14/>
                                                                <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
														
                                                       	</tr>
													<tr>
														<td align="left"><asp:Label id="lbPublication" runat="server" CssClass="TextField" meta:resourcekey="lbPublicationResource1"></asp:Label></td>
														<td align="left">
                                                            <%--<asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:DropDownList id="dppub1" runat="server" CssClass="dropdown"   meta:resourcekey="dppub1Resource1"></asp:DropDownList>
                                                                <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
													</tr>
                                                        <tr><td align="left">
                                                        <asp:Label id="lbPublicationCenter" runat="server" CssClass="TextField" meta:resourcekey="lbPublicationCenterResource1"></asp:Label></td>
														<td  align="left">
                                                            <%--<asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:DropDownList id="dppubcent" runat="server" CssClass="dropdown" type="password"   meta:resourcekey="dppubcentResource1" ></asp:DropDownList>
                                                                <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td></tr>
                                                          <tr>
                                                    <td align="left" ><asp:Label ID="lblbranch" runat="server"   CssClass="TextField">Branch</asp:Label></td>
    <td  align="left">           
    <asp:DropDownList id="drpbranch" runat="server" style="text-align:left;" CssClass="dropdown" ></asp:DropDownList>                          
    </td>
                                                            
                                                            
                                                            <tr><td align="left">
                                                        <asp:Label id="lbEdition" runat="server" CssClass="TextField" meta:resourcekey="lbEditionResource1"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                           <%-- <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:DropDownList id="dpedition" runat="server" CssClass="dropdown" type="password" meta:resourcekey="dpeditionResource1"></asp:DropDownList>
                                                                <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td></tr>
                                                        
                                                        <tr>
                                                        
													<td align="left"><asp:Label id="lbagtype" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left"><%--<asp:UpdatePanel ID="UpdatePanel13" runat="server" >
                                                                <ContentTemplate>--%>
                                                                     <asp:DropDownList id="dpagtype" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                                <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
													</tr>
                                                        
                                                        
                                                     <tr>
                                                        
													<td align="left"><asp:Label id="Status12" runat="server" CssClass="TextField" text = "Status"></asp:Label></td>
														<td align="left"><%--<asp:UpdatePanel ID="UpdatePanel13" runat="server" >
                                                                <ContentTemplate>--%>
                                                                <asp:ListBox id="lststatus" runat="server" CssClass="btext1" Height ="66px" SelectionMode="Multiple" Width="144px" meta:resourcekey="dpadcatgoryResource1" OnClick="getValue()">
                                                                        <asp:ListItem>--Select Status--</asp:ListItem>
                                                                        
                                                                    </asp:ListBox>
                                                                     <%--<asp:DropDownList id="Dropdwnstatus" runat="server" CssClass="dropdown"></asp:DropDownList>--%>
                                                                <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
													</tr>
                                                    
                                                    
                                                    
                                                        
                                                        
                                                        
                                                         <tr><td align="left">
                                                        <asp:Label id="lbdestination" runat="server" CssClass="TextField" meta:resourcekey="lbdestinationResource1"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                           <%-- <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:DropDownList id="Txtdest" runat="server" CssClass="dropdown" type="password" meta:resourcekey="TxtdestResource1"></asp:DropDownList>
                                                                <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td></tr>
                                                             <tr><td align="center" id="fg" colspan="2" style="display:none;">
                                                         
                                                        <%--  <div id="fg" runat="server" style="display:block">--%>
                                                       
                                                                    <asp:RadioButton id="exe" runat="server"  Checked="true" Text="Excel"></asp:RadioButton>
                                                                    <asp:RadioButton id="csv" runat="server"  Text="CSV"></asp:RadioButton>
                                                                    
                                                         <%--  </div>--%>
                                                              
                                                        </td></tr>
                                                            
													</table>
													
													
													<table>
													<tr >
														<td align="center" style="padding-right:100px">
                                                               <%--<asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:button id="BtnRun" CssClass="btntext" Runat="server"  meta:resourcekey="BtnRunResource1" ></asp:button>
                                                            <%--    </ContentTemplate></asp:UpdatePanel>--%>
                                                            
                                                               
                                                                    <asp:button id="Btnsummary" CssClass="btntext" Runat="server" onclick="Btnsummary_Click" ></asp:button>
                                                            
                                                            
                                                               
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
   <input id="hdncompcode" type="hidden" runat="server" />
   
   <td><input id="hiddenolddate" type="hidden" name="hiddenolddate" runat="server" /></td>
   
   
   <input id="hiddencompcode" type="hidden" name="hiddencompcode" runat="server" />
    <input id="hiddenadcat" type="hidden" name="hiddenadcat" runat="server" />
     <input id="hiddenadsubcat" type="hidden" name="hiddenadsubcat" runat="server" />
      <input id="hiddenadcatname" type="hidden" name="hiddenadcatname" runat="server" />
     <input id="hiddenadsubcatname" type="hidden" name="hiddenadsubcatname" runat="server" />
      <input id="hiddenedition" type="hidden" name="hiddenedition" runat="server" />
      <input id="hiddeneditionname" type="hidden" name="hiddeneditionname" runat="server" />
      <input id="hdnagency1" name="hdnagency1" runat="server" type="hidden" />
      <input id="hdnagencytxt" name="hdnagencytxt" runat="server" type="hidden" />
      <input id="hdnstatus" name="hdnstatus" runat="server" type="hidden" />
    </form>
</body>
</html>
                       
				