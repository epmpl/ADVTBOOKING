<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Forgetpassword.aspx.cs" Inherits="Forgetpassword" %>
<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew.ascx" %>  
<%@ Register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Forget Password</title>
    <link href="css/main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript"language="javascript" src="javascript/forgotpassword.js"></script>
</head>
<body >
		<form id="Form1" method="post" runat="server">
			
			<table width="1005" border="0" cellspacing="0" cellpadding="0" align="center" style="WIDTH: 1005px; HEIGHT: 50px">
				<tr>
					<td width="100%"><img src="images/img_02A.jpg" width="1004" border="0" />
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    </td>
				</tr>
				<tr>
					<td width="100%" bordercolor="#1"><img src="images/top.jpg" width="1004" border="0" /></td>
				</tr>
				<tr>
					<td style="height: 505px"><table width="985" border="0" cellspacing="0" cellpadding="0" style="WIDTH: 985px; HEIGHT: 486px">
					<tr><td style="height:10px"></td></tr>
					<tr><td></td><td class="nodescription"><u>Forgot Password</u></td></tr>
							<tr>
								<!---------left bar start--------->
								<td width="200" style="WIDTH: 200px"><img src="images/leftbar.jpg" style="WIDTH: 193px; HEIGHT: 483px" height="483" width="193" /></td>
								<!---------left bar end--------->
								<!---------middle start--------->
								
								<td valign="top" style="width: 78%" align="top">
								
								<table cellpadding="0" cellspacing="0" width="790" style="WIDTH: 790px;"
										>
										<tr><td style="height:40px"></td></tr>
                                <tr><td valign="top" class="TextField" style="width: 177px; height: 1px;">Enter Email ID</td><td valign="top" style="height: 1px">
                                <asp:UpdatePanel ID="up1" runat="server"><ContentTemplate><asp:TextBox ID="txtemail" runat="server" cssClass="btext1" Width="214px"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td></tr>										
                                <tr><td></td><td><asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate><asp:Button ID="btnsubmit" runat="server" OnClick="btnsubmit_Click1" Text="Submit"  /></ContentTemplate></asp:UpdatePanel></td><td></td></tr>
								</table>
                                              
												</td>
												
								<!---------middle end--------->
							</tr>
						</table>
                      
				</tr>
				
			</table>
					
		
		</form>
	</body>
</html>
