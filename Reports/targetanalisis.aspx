<%@ Page Language="C#" AutoEventWireup="true" CodeFile="targetanalisis.aspx.cs" Inherits="Reports_targetanalisis" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Target Analisis</title>
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
		<script type="text/javascript"  language="javascript" src="javascript/new.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/targetanalisis.js"></script>
			<script type="text/javascript"  language="javascript" src="javascript/prototype.js"></script>
		<style type="text/css">.style1 { FONT-WEIGHT: bold; FONT-SIZE: xx-large; COLOR: #ffffff }
	.style2 { COLOR: #ffffff }
	.style4 { FONT-WEIGHT: normal; FONT-SIZE: 14pt; COLOR: #d85414; FONT-FAMILY: Verdana }
	.style6 { FONT-SIZE: x-small }
	.style7 { FONT-WEIGHT: bold; COLOR: #6666ff }
		</style>
		
</head>
<body onload="javascript:return clear_onload();">
    <form id="report1" runat="server">
    <div id="div1" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
	  <table cellpadding="0" cellspacing="0"><tr><td>
	  <asp:ListBox ID="lstagency" Width="382px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
	  </td></tr></table></div>
   <table width="1005" border="0" cellspacing="0" cellpadding="0" align="center" style="WIDTH: 1005px; HEIGHT: 358px">
				<tr>
					<td width="100%" bordercolor="#1"><img src="images/img_02A.jpg" width="1004" border="0" />
                  </td>
				</tr>
				<tr>
					<td  id="td2"  onclick="javascript:return logoutpage();"   width="100%" bordercolor="#1" style="background-image:url('images/top.jpg');font-family:Trebuchet MS;font-size: 13px;color:#CC0000;cursor:hand;" align="right">
                     LogLogout</td>
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
											
											<table width="0" border="0" cellspacing="0" cellpadding="0">
													
									                <tr>
														<td align="left">
														<asp:Label id="agencyname" runat="server" CssClass="TextField" ></asp:Label>
														<td style="HEIGHT: 25px" align="left">
                                                           
                                                                    <asp:TextBox CssClass="btext1" id="dpagency" runat="server" ></asp:TextBox>
                                                               
                                                        </td>
                                                        
													</tr>
												
													<tr>
														<td align="left">
														<asp:Label id="lbDateFrom" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                           
                                                                    <asp:TextBox id="txtfrmdate" runat="server" CssClass="btext1"  onblur="javascript:return ValidateForm(event,this.id)" ></asp:TextBox>
                                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, report1.txtfrmdate, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/>
                                                               
                                                        </td>
                                                        
													</tr>
													<tr>
													<td align="left">
														<asp:Label id="lbToDate" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                          
                                                                    <asp:TextBox id="txttodate1" runat="server" CssClass="btext1" Enabled="true"  ></asp:TextBox>
                                                                   <img src='Images/cal1.gif'  onclick='popUpCalendar(this, report1.txttodate1, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/>
 
                                                              
                                                        </td>
														
                                                       	</tr>
													<tr>
														<td align="left"><asp:Label id="lbPublication" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                          
                                                                    <asp:DropDownList id="dppub1" runat="server" CssClass="dropdown" ></asp:DropDownList>
                                                                   
                                                       </td>
													</tr>
                                                        
                                                        
                                                        
													<tr>
                                                        
													<td align="left"><asp:Label id="lbedition" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                     <asp:DropDownList id="drpedition" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                             
                                                        </td>
													</tr>     
													<tr>
                                                        
													<td align="left"><asp:Label id="lbadtype" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                     <asp:DropDownList id="drpadtype" runat="server" CssClass="dropdown" ></asp:DropDownList>
                                                             
                                                        </td>
													</tr>
													<tr><td align="left">
                                                        <asp:Label id="lbuom" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                           
                                                                   <%-- <asp:DropDownList id="drpuom" runat="server" CssClass="dropdown" type="password" ></asp:DropDownList>--%>
                                                                    <asp:ListBox id="drpuom" runat="server" CssClass="btext1" Height ="70px"  SelectionMode="Multiple" Width="144px">
                                                                                                                                               
                                                                    </asp:ListBox>
                                                                    
                                                               
                                                        </td></tr>        
                                                        <tr><td align="left">
                                                        <asp:Label id="lbpaymode" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                            
                                                                    <asp:DropDownList id="drppaymode" runat="server" CssClass="dropdown" ></asp:DropDownList>
                                                             
                                                        </td></tr>
                                                        
                                                       <tr><td align="left">
                                                        <asp:Label id="lbbasedon" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                            
                                                                    <asp:DropDownList id="drpbasedon" runat="server" CssClass="dropdown" ></asp:DropDownList>
                                                             
                                                        </td>
                                                        </tr>
                                                            <tr><td align="left">
                                                        <asp:Label id="lbdestination" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                            
                                                                   <asp:DropDownList id="drpdestination" runat="server" CssClass="dropdown" type="password"></asp:DropDownList>
                                                             
                                                        </td></tr>
                                             <tr>
                                                <td>
                                                <asp:RadioButton ID="rdoexecutive" runat="server" CssClass="TextField" GroupName="radio5" Checked="true"/>
                                                </td>
                                                <td>
                                                <asp:RadioButton ID="rdoagencywise" runat="server" CssClass="TextField" GroupName="radio5" />
                                                </td>
                                                <td>
                                                <asp:RadioButton ID="rdouomwise" runat="server" CssClass="TextField" GroupName="radio5"/>
                                                </td>
                                                <td>
                                                <asp:RadioButton ID="rdosupplinentwise" runat="server" CssClass="TextField" GroupName="radio5" />
                                                </td>
                                             </tr>
                                                      
													</table>
													<table>
													<tr >
														<td align="center">
                                                             
                                                                    <asp:button id="BtnRun" CssClass="btntext" Runat="server" ></asp:button>
                                                                        <asp:button id="btnclear" CssClass="btntext" Runat="server" ></asp:button>
                                                                    
                                                                    
                                                                    
                                                            
                                                               
                                                            </td>
													</tr>
													
												</table>
												
													</tr>
														</table>
                                                
												</td>
								<!---------middle end--------->
							</tr>
						</table>
                        <input id="hiddendateformat" type="hidden" runat="server" /></td>
                         <td><input id="hiddencompcode" type="hidden" runat="server" /></td>
                            <td><input id="hdnuserid" type="hidden" runat="server" /></td>
                              <input id="hdnagency1" name="hdnagency1" runat="server" type="hidden" />
                              <input id="hdnagencytxt" name="hdnagencytxt" runat="server" type="hidden" />
				</tr>
				
			</table>
    </form>
</body>
</html>
