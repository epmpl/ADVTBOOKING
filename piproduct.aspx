<%@ Page Language="C#" AutoEventWireup="true" CodeFile="piproduct.aspx.cs" Inherits="piproduct" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>PI Report Product Wise</title>
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
		<script type="text/javascript" language="javascript" src="javascript/validatationdate.js"></script>
		<%--<script type="text/javascript" language="javascript" src="javascript/piproduct.js"></script>--%>
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
<body onkeydown="javascript:return tabvalue();" onload="document.getElementById('txtfrmdate').focus();">
    <form id="productreport" runat="server">
   <asp:ScriptManager ID="ScriptManager2" runat="server">
                        </asp:ScriptManager>
    
    <div id="divagency" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:0;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstagency" Width="124px"  Height="35px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div> 
			 
<div id="divclient" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:0;"><table cellpadding="0" cellspacing="0"><tr><td><asp:UpdatePanel  ID="UpdatePanel71" runat="server"><ContentTemplate><asp:ListBox ID="lstclient" Width="124px" Height="65px" runat="server" CssClass="btextlist" ></asp:ListBox></ContentTemplate></asp:UpdatePanel></td></tr></table></div> 
<div id="divproduct" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:0;"><table cellpadding="0" cellspacing="0"><tr><td style="height: 110px"><asp:UpdatePanel  ID="UpdatePanel70" runat="server"><ContentTemplate><asp:ListBox ID="lstproduct" Width="124px" Height="65px" runat="server" CssClass="btextlist" ></asp:ListBox></ContentTemplate></asp:UpdatePanel></td></tr></table></div> 
  
			<table width="1005" border="0" cellspacing="0" cellpadding="0" align="center" style="WIDTH: 1005px; HEIGHT: 358px">
				<tr>
					<td width="100%" bordercolor="#1"><img src="images/img_02A.jpg" width="1004" border="0" />
                        <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>--%>
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
											
											       
											       
											       
											       
													<%--<tr>
														<td align="left" ><asp:Label id="lbAdtype" runat="server" CssClass="TextField"></asp:Label></td>
														  <td align="left"><asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList CssClass="dropdown" id="dpaddtype" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dpaddtype_SelectedIndexChanged"></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        
													</tr>--%>
												
													
													<%--<tr>
													<td align="left"><asp:Label id="Label1" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left"><asp:UpdatePanel ID="UpdatePanel8" runat="server" >
                                                                <ContentTemplate>
                                                                    <asp:ListBox id="ListBox1" runat="server" CssClass="btext1" Height ="66px" OnSelectedIndexChanged="dpadcatgory_SelectedIndexChanged" SelectionMode="Multiple" Width="144px">
                                                                        
                                                                    </asp:ListBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
													</tr>--%>
													
													<tr>
														<td align="left">
														<asp:Label id="lbDateFrom" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox id="txtfrmdate" runat="server" CssClass="btext1" MaxLength="10" ></asp:TextBox>
                                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, productreport.txtfrmdate, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        
													</tr>
													<tr>
													<td align="left">
														<asp:Label id="lbToDate" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox id="txttodate1" runat="server" CssClass="btext1" MaxLength="10" ></asp:TextBox>
                                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, productreport.txttodate1, "mm/dd/yyyy")' onfocus="abc();" height="14" width="14"/>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
														
                                                       	</tr>
                                                       	
                                                       	<tr>
                                                       	
                                                       	<td align="left">
                                                        <asp:Label id="lbregion" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            <asp:UpdatePanel ID="UpdatePane21" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList id="dpregion" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        
                                                        </tr>
                                                        
                                                        
                                                        <tr>
                                                        
                                                        <td align="left">
                                                        <asp:Label id="lbproduct" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                <ContentTemplate>
                                                       <%-- <asp:DropDownList id="dpproduct" runat="server" CssClass="dropdown"></asp:DropDownList>--%>
                                                       <asp:ListBox id="dpproduct" runat="server" CssClass="btext1" Height ="66px" SelectionMode="Multiple" Width="144px" meta:resourcekey="dpadcatgoryResource1">
                                                                        
                                                                    </asp:ListBox>
                                                        <%--<asp:TextBox ID="txtproduct" runat="server" CssClass="btext1" AutoPostBack="false"></asp:TextBox>--%>
                                                    </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        
                                                        </tr>
                                                        <%--<tr>
                                                        
													<td align="left"><asp:Label id="lbcatgory" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left"><asp:UpdatePanel ID="UpdatePanel2" runat="server" >
                                                                <ContentTemplate>
                                                                    <asp:ListBox id="dpcatgory" runat="server" CssClass="btext1" Height ="66px" SelectionMode="Multiple" Width="144px">
                                                                        
                                                                    </asp:ListBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
													</tr>--%>
													<%--<tr>
                                                       	
                                                       	<td align="left">
                                                        <asp:Label id="lbsubcat" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList id="dpsubcat" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        
                                                        </tr>--%>
                                                        
                                                        <%--<tr>
                                                       	
                                                       	<td align="left">
                                                        <asp:Label id="lbsubsubcat" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList id="dpsubsubcat" runat="server" CssClass="dropdown" Width="145px"></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        
                                                        </tr>--%>
                                                        
                                                        <%--<tr>
                                                        <td align="left">
                                                        <asp:Label id="lbstatus" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList id="dpstatus" runat="server" CssClass="dropdown" type="password"></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        </tr>--%>
                                                        
                                                        
                                                        
													
                                                        
													
													<%--<tr>	
													<td align="left">
														
                                                <asp:Label ID="lbagency" runat="server" CssClass="TextField" ></asp:Label></td>
										     	
										     	<td  align="left">
										     	<asp:UpdatePanel ID="UpdatePanel7" runat="server">
											        <ContentTemplate>
                                                        <asp:TextBox ID="txtagency" runat="server" CssClass="btext1" AutoPostBack="True" ></asp:TextBox>
                                                    </ContentTemplate>
                                                    </asp:UpdatePanel></td>
                                            <td>
                                            </td>
                                                        
													</tr>--%>
													<%--<tr>
														<td align="left">
													
                                                <asp:Label ID="lbaaddress" runat="server" CssClass="TextField"></asp:Label></td>
											<td><asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                    <ContentTemplate>
                                                <asp:TextBox ID="txtagencyaddress" runat="server" CssClass="btext1forbooknew" TextMode="MultiLine" Enabled="False" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
                                           </tr>--%>
													<%--<tr>
														<td align="left"><asp:Label id="lbPublication" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList id="dppub1" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                                    
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        </tr>--%>
                                                        
                                                        
                                                        <%--<tr>
                                                        
                                                       <td align="left">
                                                        <asp:Label id="lbPublicationCenter" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList id="dppubcent" runat="server" CssClass="dropdown" OnSelectedIndexChanged="dppubcent_SelectedIndexChanged" type="password"  AutoPostBack="True"></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        
                                                       </tr>--%>
                                                       <%--<tr>
														<td align="left" ><asp:Label id="lbClient" runat="server" CssClass="TextField"></asp:Label></td>
														<td align="left"><asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                                <ContentTemplate>
                                                <asp:TextBox ID="txtclient" runat="server" CssClass="btext1" Enabled="False"></asp:TextBox>
                                                    </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        </tr>--%>
                                                        <%--<tr>
                                                       <td  align="left">
                                                <asp:Label ID="lbcaddress" runat="server" CssClass="TextField" ></asp:Label></td>
                                            <td  align="left"><asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                                    <ContentTemplate>
                                                <asp:TextBox ID="txtclientadd" runat="server" CssClass="btext1forbooknew"  TextMode="MultiLine" Enabled="False"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
                                                        </tr> --%>                                                                      													
													    <%--<tr>
														<td align="left" ><asp:Label id="lbbrand" runat="server" CssClass="TextField"></asp:Label></td>
														<td align="left"><asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                <ContentTemplate>
                                                <asp:DropDownList ID="drpbrand" runat="server" CssClass="dropdown" Enabled="False">
                                                </asp:DropDownList></ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        
													</tr>--%>
													<%--<tr>
                                                            <td align="left">
                                                        <asp:Label id="lbvarient" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList id="dpvarient" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td></tr>--%>
													
													
                                                       
                                                       <%--<tr>
                                                            <td align="left">
                                                        <asp:Label id="lbEdition" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList id="dpedition" runat="server" CssClass="dropdown" type="password"></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td></tr>
                                                       --%>

                                                        
                                                        
                                                        
                                                        
                                                       
                                                        
                                                        <tr><td align="left">
                                                        <asp:Label id="lbdestination" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            <asp:UpdatePanel ID="UpdatePanel66" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList id="Txtdest" runat="server" CssClass="dropdown" type="password"></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td></tr>
														
													
													</table>
													
													<table>
													<tr >
														<td align="center">
                                                                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:button id="BtnRun" CssClass="btntext" Runat="server" OnClick="BtnRun_Click" ></asp:button>
                                                                    
                                                                    
                                                                    
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                               
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
                         <td><input id="hiddenascdesc" type="hidden" runat="server" /></td>
   <td><input id="hiddencioid" type="hidden" runat="server" /></td>
  <td><input id="hiddenolddate" type="hidden" name="hiddenolddate" runat="server" /></td>
  <td><input id="hidden1" type="hidden" name="hiddentext" runat="server" /></td>
			</tr>
				
			</table>
			
			
        <%--</TD></TR></TABLE>--%>
        
     
    </form>
</body>
</html>
