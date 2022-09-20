<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginDJ.aspx.cs" Inherits="LoginDJ" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>::HT QBC::</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" content="C#"/> 
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		<style type="text/css">.style1 { FONT-WEIGHT: bold; COLOR: #ffffff; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif }
	.style2 { COLOR: #ffffff }
		</style>
		<link href="css/main.css" type="text/css" rel="stylesheet">
		<script language="javascript" type="text/javascript" src="javascript/logindj.js"></script>
		
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

</head>

<body onload="document.getElementById('txtusername').focus();" onkeydown="javascript:return tabvalue('drploginth');">
<form id="Form1" method="post" runat="server">
  <table width="1000px" border="0" cellspacing="0" cellpadding="0" align="center" >
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
                <td style="width:12px;background-image:url(images/left_black_corner.jpg);background-repeat:no-repeat;"></td>
       <td valign="top" style="padding:13px;padding-bottom:35px;padding-top:16px;background-image:url(images/mid_black_corner.jpg);background-repeat:repeat;">
       
       
            <img  id="keybord" runat="server" src="Images/keyboard_img.jpg"/>
        </td>
        <td valign="top" style="padding:13px;padding-bottom:35px;padding-top:16px;background-image:url(images/mid_black_corner.jpg);background-repeat:repeat;">
             
       <table cellpadding="0" cellspacing="0" style="height:302px;width:332px;background-image:url(images/login_bg.jpg);background-repeat:no-repeat;">
            <tr>
            <td valign="middle" colspan="5" style="height:285px;">
                <table cellpadding="0" cellspacing="0" style="padding-top:70px;width:300px;">
                <tr><td align="center"><table> 
       <tr>
											<td align="right" style="HEIGHT: 163px; width: 786px;"><table id="tbllogin" width="0" border="0" cellspacing="0" cellpadding="0">
													<!--<TR>
														<TD><asp:Label id="Label1" runat="server" CssClass="TextField">Company Code</asp:Label></TD>
														<TD><asp:DropDownList CssClass="dropdown" id="dpdadtype" runat="server" Width="300"></asp:DropDownList></TD>
													</TR>-->
                                              
                                              
													
                                              
													<tr style="height:32px;">
														<td align="left" style="width: 78px">
														<asp:Label id="lbusername" Font-Bold="true" Text="User Name" runat="server" CssClass="TextField"></asp:Label></TD>
														<td><asp:TextBox runat="server" Width="175px" ID="txtusername" CssClass="btext111" TabIndex="0"></asp:TextBox></td>
													</tr>
													<tr>
														<td align="left" style="width: 78px"><asp:Label id="lbpassword" Text="Password" Font-Bold="true" runat="server" CssClass="TextField"></asp:Label></td>
														<td><asp:TextBox id="txtpwd" Width="175px" runat="server" CssClass="btext111" type="password" TabIndex="0" TextMode="Password"></asp:TextBox></td>
													</tr>
													<tr id="tr1" style="height:32px;"><td align="left" style="width: 78px">
													<asp:Label id="lblpub" Font-Bold="true" runat="server" Text="Publication" CssClass="TextField"></asp:Label>
													</td>
														<td><asp:DropDownList CssClass="dropdown" Width="180px" id="drppublication" TabIndex="0" runat="server"></asp:DropDownList></td>
													</tr>
													<tr id="trcenter"><td align="left" style="width: 78px">
													<asp:Label id="lblcenter" runat="server" Font-Bold="true" Text="Center" CssClass="TextField"></asp:Label>
													</td>
														<td><asp:DropDownList CssClass="dropdown" Width="180px" id="drpcenter" runat="server" TabIndex="0" ></asp:DropDownList></td>
													</tr>
													<tr id="trqbc" style="height:32px;"><td align="left" style="width: 98px">
													<asp:Label id="lblqbc" Font-Bold="true" Text="Login Through" runat="server" CssClass="TextField"></asp:Label>
													</td>
														<td><asp:DropDownList CssClass="dropdown" Width="180px" id="drploginth" runat="server" TabIndex="0"></asp:DropDownList></td>
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
													<input type="hidden" name="UserLabel" runat="server" id="hiddenbranch">
											</td>
										</tr>
       
       </table>
       
       </td>
       
       
       
       </tr>
                </table>
            </td>
            </tr>
          
       </table>
       
       </td>
       <td style="width:12px;background-image:url(images/right_black_corner.jpg);background-repeat:no-repeat;"></td>
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
<td align="right" style="padding-right:15px;">Developed & Designed By: <img src="Images/4c_logo.jpg"/></td>
</tr>
  </table>
  </td>
  <td style="width:50px"></td>
  </tr>

  </table>
  </form>
</body>
</html>
