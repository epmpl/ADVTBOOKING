<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Materiallog.aspx.cs" Inherits="Reports_Materiallog" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Material Log</title>
   <style type="text/css">.style1 { FONT-WEIGHT: bold; COLOR: #ffffff; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif }
	.style2 { COLOR: #ffffff }
		</style>
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<link href="css/booking.css" type="text/css" rel="stylesheet"/>
		<link href="css/report.css" type="text/css" rel="stylesheet"/>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
		<script type="text/javascript"  language="javascript" src="javascript/datevalidation.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/Materiallog.js"></script>
		

		<style type="text/css">.style1 { FONT-WEIGHT: bold; FONT-SIZE: xx-large; COLOR: #ffffff }
	.style2 { COLOR: #ffffff }
	.style4 { FONT-WEIGHT: normal; FONT-SIZE: 14pt; COLOR: #d85414; FONT-FAMILY: Verdana }
	.style6 { FONT-SIZE: x-small }
	.style7 { FONT-WEIGHT: bold; COLOR: #6666ff }
		</style>
    
</head>
<body onload="javascript:return calonload()" onkeydown="javascript:return onkeydoawn(event)">
    <form id="form1" runat="server">
   
    <div id="div1" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lst_user" Width="360px" Height="185px" runat="server" CssClass="dropdown" ></asp:ListBox></td></tr></table></div>
    <div id="div2" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lst_cent" Width="360px" Height="185px" runat="server" CssClass="dropdown" ></asp:ListBox></td></tr></table></div>
       <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <table width="1005" border="0" cellspacing="0" cellpadding="0" align="center" style="WIDTH: 1005px; HEIGHT: 358px">
				<tr>
					<td width="100%" bordercolor="#1"><img src="images/img_02A.jpg" width="1004" border="0" />
                       <%-- <asp:ScriptManager ID="ScriptManager1" runat="server">
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
								
								<table cellpadding="0" cellspacing="0" width="790" style="WIDTH: 790px; HEIGHT: 488px" borderColorDark="#000000" border="1">
										<tr>
											<td align="center">
											<table ><tr>
											<td><asp:Label ID="heading" runat ="server" CssClass="heading"></asp:Label></td></tr>
											</table>
											
											<br />
											
											<table width="50%" border="0" cellspacing="0" cellpadding="0">
											<tr><td  align="left">
											<asp:Label id="lblcenter" runat="server" CssClass="TextField" style="text-align:left"></asp:Label>
											</td><td style="HEIGHT: 25px" align="left">
											<asp:TextBox id="txtcenter" runat="server" CssClass="btext1" ></asp:TextBox>
											</td>
											</tr>	
											
											<tr><td align="left">
											<asp:Label id="lblusrnam" runat="server" CssClass="TextField"  style="text-align:left;"></asp:Label>
											</td><td style="HEIGHT: 25px" align="left">
											<asp:TextBox id="txtusrnam" runat="server" CssClass="btext1" ></asp:TextBox>
											</td>
											</tr>	
												
												<tr>
														<td align="left">
														<asp:Label id="lbpubdat" runat="server" CssClass="TextField"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                           
                                                                    <asp:TextBox id="txtpubdat" runat="server" CssClass="btext1" ></asp:TextBox>
                                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtpubdat, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/>
                                                              
                                                        </td>
                                                        
													</tr>
													
													<tr>
														<td align="left">
														<asp:Label id="lbldest" runat="server" CssClass="TextField" style="text-align:left"></asp:Label></td>
														<td style="HEIGHT: 25px" align="left">
                                                           
                                                                    <asp:DropDownList id="drpdest" runat="server" CssClass="dropdown" type="password"></asp:DropDownList>
                                                              
                                                        </td>
                                                        
													</tr>
													
													</table>
													<br />
													
													<table>
													<tr >
														<td align="center" style="padding-right:60px">
														<asp:UpdatePanel ID='up1' runat="server">
														<ContentTemplate>
														
														
                                                        <asp:button id="BtnRun" CssClass="btntext" Runat="server" ></asp:button>
                                                        </ContentTemplate>
														</asp:UpdatePanel>
                                                            </td>
													</tr>
												
													
														</table>
                                                
												</td>
								<!---------middle end--------->
							</tr>
						</table>
          </td></tr>
				
				
			</table></td></tr></table>
			 
               
     <input id="hiddendateformat" type="hidden" runat="server" />          
   <input id="hiddencompcode" type="hidden" name="hiddencompcode" runat="server" />
   <input id="user" name="hdnagencytxt" runat="server" type="hidden" />
    <input id="hiddenuserid" name="hdnagencytxt" runat="server" type="hidden" />
    <input id="hiddenuserhome" name="hdnagencytxt" runat="server" type="hidden" />
    <input id="hiddenrevenue" name="hdnagencytxt" runat="server" type="hidden" />
    <input id="hiddenadmin" name="hdnagencytxt" runat="server" type="hidden" />
    <input id="hidcent" name="hdnagencytxt" runat="server" type="hidden" />
    <input id="hdnaccess" name="hdnagencytxt" runat="server" type="hidden" />
               
    </form>
</body>
</html>
