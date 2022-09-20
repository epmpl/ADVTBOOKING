<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>::AD BOOKING::</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" content="C#"/> 
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		<style type="text/css">.style1 { FONT-WEIGHT: bold; COLOR: #ffffff; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif }
	.style2 { COLOR: #ffffff }
		</style>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
	<link href="css/main.css" type="text/css" rel="stylesheet">
    <link href="css/loginmain.css" type="text/css" rel="stylesheet">
		<script language="javascript" type="text/javascript" src="javascript/login.js"></script>
		
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		
		<style type="text/css">.style1 { FONT-WEIGHT: bold; FONT-SIZE: xx-large; COLOR: #ffffff }
	.style2 { COLOR: #ffffff }
	.style4 { FONT-WEIGHT: normal; FONT-SIZE: 14pt; COLOR: #d85414; FONT-FAMILY: Verdana }
	.style6 { FONT-SIZE: x-small }
	.style7 { FONT-WEIGHT: bold; COLOR: #6666ff }
		</style>
    <style type="text/css">
<!--
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
	background-image: url(Images/bgmain.jpg);
	background-repeat: no-repeat;
	background-position:top;
	background-color: #058ad9;
}
-->
</style>
<script language="javascript">
function openRateCard()
{
    window.open('downloadFont.aspx')
    return false;
}
</script>
</head>

<body onload="javascript:return forfocus();" onkeydown="javascript:return tabvalue('txtpwd');">
<form id="Form1" method="post" runat="server">
    <div id="divagency" style="position: absolute; top: 0px; left: 0px; border: none;
            background-color: White; display: none; z-index: 1;" runat="server">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:ListBox ID="lstagency" Width="254px" Height="65px" runat="server" CssClass="btextlist">
                        </asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
  <table  border="0" cellspacing="0" cellpadding="0" align="center" >
   <tr>
      <td style="width:1000px; height:50px;" colspan="6"></td>
   </tr>
   <tr style="width:1000px; height:50px">
      <td style="width:50px"></td>
      <td style="width:200px;"><!--<img id="imglogo" runat="server"  src="Images/ht_eng_logo.gif"/>--></td>
      <td style="width:300px;"><!--<img  id="Quicktxt" runat="server" src="Images/quick_text.png"/>--></td>
      <td style="width:110px"></td>
      <td style="width:200px;"><!--<img id="hindilogo" runat="server" src="Images/ht_hindi_logo.gif" />--></td>
      <td style="width:50px"></td>
  </tr>
  <tr><td colspan="6" style="height:25px;"></td></tr>
  
  <tr>
       <td style="width:50px"></td>
       <td colspan="4" valign="top">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td class="lcorner" style="background-image:url(images/left_black_corner.jpg);"></td>
       <td class="key" style="background-image:url(Images/mid_black_corner.jpg);">
       
       
            <img class="imgkey" id="keybord" runat="server" src="Images/keyboard_img.jpg"/>
        </td>
        <td class="ldetail" style="background-image:url(Images/mid_black_corner.jpg);">
             
       <table class="louter" style="background-image:url(images/login_bg.jpg);">
            <tr>
            <td valign="middle" colspan="5" style="height:293px;">
                <table class="lsection">
                <tr><td align="center"><table> 
       <tr>
											<td align="right" style="HEIGHT: 163px; width: 786px;"><table id="tbllogin" width="0" border="0" cellspacing="0" cellpadding="0">
													<!--<TR>
														<TD><asp:Label id="Label1" runat="server" CssClass="TextField">Company Code</asp:Label></TD>
														<TD><asp:DropDownList CssClass="dropdown" id="dpdadtype" runat="server" Width="300"></asp:DropDownList></TD>
													</TR>-->
                                                <tr id="rwrbtn" style="padding-bottom:12px;padding-top:12px;">
                                                    <td align="right">
                                                        </td>
                                                    <td align="right">
                                                        <asp:RadioButton ID="rbcomp" runat="server" Font-Bold="true" CssClass="TextField" Checked="True" Text="Hindustan" />
                                                        &nbsp;
                                                        &nbsp;
                                                        <asp:RadioButton ID="rbagency" runat="server" Font-Bold="true" CssClass="TextField" Text="Agency" /></td>
                                                       
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 78px">
                                                    </td>
                                                    <td align="left">
                                                    </td>
                                                </tr>
													<tr id="trcenter"><td align="left" style="width: 78px">
													<asp:Label id="lblcenter" runat="server" Font-Bold="true" CssClass="TextField"></asp:Label>
													</td>
														<td><asp:DropDownList CssClass="dropdown" Width="180px" id="drpcenter" runat="server" ></asp:DropDownList></td>
													</tr>
													<tr id="trqbc" style="height:32px;"><td align="left" style="width: 78px">
													<asp:Label id="lblqbc" Font-Bold="true" runat="server" CssClass="TextField"></asp:Label>
													</td>
														<td><asp:DropDownList CssClass="dropdown" Width="180px" id="drpqbc" runat="server"></asp:DropDownList></td>
													</tr>
                                                <tr id="tragency" style="display:none;">
                                                    <td align="left" style="width: 78px">
                                                        <asp:Label ID="lbagency" Font-Bold="true" runat="server" CssClass="TextField"></asp:Label></td>
                                                    <td>
                                                        <asp:TextBox CssClass="btext1" Width="175px" id="drpagency" runat="server"></asp:TextBox>
                                                        <%--<asp:DropDownList CssClass="dropdown" Width="180px" id="drpagency" runat="server">
                                                        </asp:DropDownList>--%></td>
                                                </tr>
													<tr style="height:32px;">
														<td align="left" style="width: 78px">
														<asp:Label id="lbusername" Font-Bold="true" runat="server" CssClass="TextField"></asp:Label></TD>
														<td><asp:TextBox runat="server" Width="175px" ID="txtusername" CssClass="btext1"></asp:TextBox>
														    
														
														<asp:DropDownList style="display:none;" Width="180px" CssClass="dropdown" id="drpusername" runat="server"></asp:DropDownList></td>
													</tr>
													<tr>
														<td align="left" style="width: 78px"><asp:Label id="lbpassword" Font-Bold="true" runat="server" CssClass="TextField"></asp:Label></td>
														<td><asp:TextBox id="txtpwd" Width="175px" runat="server" CssClass="btext1" type="password" TextMode="Password"></asp:TextBox></td>
													</tr>
													<tr>
														<td colspan="2" align="center" style="height: 19px"></td>
													</tr>
													<TR>
														<TD align="right" colSpan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
														<asp:ImageButton ID="btnlogin" runat="server" CssClass="btntext" ImageUrl="~/Images/submit.png" />
															</TD>
													</TR>
												</table>
												<INPUT type="hidden" name="UserLabel" runat="server" id="UserLabel">
												<INPUT type="hidden" name="UserLabel" runat="server" id="hiddenmysql">
													<INPUT type="hidden" name="UserLabel" runat="server" id="hiddendepo">
													<input type="hidden" name="UserLabel" runat="server" id="hiddenshowrdbtn">
                                                <input type="hidden" id="hdncodesucode" runat="server" />
											</td>
										</tr>
       
       </table>
       
       </td>
       
       
       
       </tr>
                </table>
            </td>
            </tr>
            <tr style="padding-top:40px;color:White;" class="TextField">
            <td style="cursor:hand"><span onclick="window.location.href='Forgetpassword.aspx'">Forgot Password</span></td>
            <td>|</td>
            <td>Privacy Policy</td>
            <td style="visibility:hidden;">|</td>
            <td style="cursor:hand; visibility:hidden;"><span onclick="return openRateCard();">Font Download</span></td>
            
            </tr>
       </table>
       
       </td>
       <td class="rcorner" style="background-image:url(images/right_black_corner.jpg);"></td>
           </tr>
        </table>
       </td>
        <td style="width:50px"></td>
  </tr>
  <tr>
  <td style="width:50px"></td>
  <td colspan="4" style="color:White;padding-top:10px;" class="TextField">
  <table width="100%">
  <tr>
<!-- <td align="left">&copy; Copyright HT 2009. All Right Reserved</td> -->
<td class="designlogo">Developed & Designed By: <img src="Images/4c_logo.jpg"/></td>
</tr>
  </table>
  </td>
  <td style="width:50px"></td>
  </tr>

  </table>
  </form>
</body>
</html>
