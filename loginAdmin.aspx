<%@ Page Language="C#" AutoEventWireup="true" CodeFile="loginAdmin.aspx.cs" Inherits="loginAdmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Ad-Display:: Login Admin</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1" />
    <meta name="CODE_LANGUAGE" content="C#" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <style type="text/css">.style1 { FONT-WEIGHT: bold; COLOR: #ffffff; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif }
	.style2 { COLOR: #ffffff }
		</style>
    <link href="css/main.css" type="text/css" rel="stylesheet">

    <script language="javascript" type="text/javascript" src="javascript/loginAdmin.js"></script>

    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
    <style type="text/css">
    .style1 { FONT-WEIGHT: bold; FONT-SIZE: xx-large; COLOR: #ffffff }
	.style2 { COLOR: #ffffff }
	.style4 { FONT-WEIGHT: normal; FONT-SIZE: 14pt; COLOR: #d85414; FONT-FAMILY: Verdana }
	.style6 { FONT-SIZE: x-small }
	.style7 { FONT-WEIGHT: bold; COLOR: #6666ff }
		</style>

    <script language="javascript" type="text/javascript">
		function forfocus()
		{
		document.getElementById('drpUser').focus();
		}
		
    </script>

</head>
<body rightmargin="0" leftmargin="0" topmargin="0" onload="javascript:return forfocus();javascript:tabvalue();"
    onkeydown="javascript:return tabvalue('txtpwd');">
    <form id="Form1" method="post" runat="server">
        <table width="1005" border="0" cellspacing="0" cellpadding="0" align="center" style="width: 1005px;
            height: 358px">
            <tr>
                <td width="100%" bordercolor="#1">
                    <img src="images/img_02A.jpg" width="1004" border="0"></td>
            </tr>
            <tr>
                <td width="100%" bordercolor="#1">
                    <img src="images/top.jpg" width="1004" border="0" /></td>
            </tr>
            <tr>
                <td>
                    <table width="985" border="0" cellspacing="0" cellpadding="0" style="width: 985px;
                        height: 486px">
                        <tr>
                            <!---------left bar start--------->
                            <td width="200" style="width: 200px">
                                <img src="images/leftbar.jpg" style="width: 193px; height: 483px" height="483" width="193"></td>
                            <!---------left bar end--------->
                            <!---------middle start--------->
                            <td width="80%" valign="top">
                                <table cellpadding="0" cellspacing="0" width="790" style="width: 790px; height: 488px"
                                    bordercolordark="#000000" border="0">
                                    <tr>
                                        <td style="height: 40px; width: 786px;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 33px; width: 786px;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="36" style="height: 36px; width: 786px;" bgcolor="#7daae3">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="height: 163px; width: 786px;">
                                            <table width="0" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lbusername" runat="server" CssClass="proplbl"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="drpUser" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lbpwd" runat="server" CssClass="proplbl"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtpwd" runat="server" CssClass="btext1" TextMode="Password"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                
                                                <tr height="20px">
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="20px">
                                                    </td>
                                                    <td align="right">
                                                        <asp:Button ID="btnlogin" CssClass="button1" runat="server" OnClick="btnlogin_Click"
                                                            TabIndex="3"></asp:Button></td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2">
                                                        <input type="hidden" name="UserLabel" runat="server" id="UserLabel">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <!---------middle end--------->
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
