<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cngpassword.aspx.cs" Inherits="cngpassword" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbanr.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Change Password</title>
      <link href="css/booking.css" type="text/css" rel="stylesheet" />
      <link href="css/main.css" type="text/css" rel="stylesheet"/>
      <script  type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
      <script language="javascript" type="text/javascript" src="javascript/changepwd.js"></script>
</head>
<body onkeydown="tabvalue12(event,'txtcfrmpwd');">
    <form id="form1" runat="server">
      
               <table width="1005" border="0" cellspacing="0" cellpadding="0" >
            <tr>
                <td><uc1:topbar id="Topbar1" runat="server" Text="Change Password"></uc1:topbar></td>
            </tr>
           <tr>
                <td>
                    <table width="985" border="0" cellspacing="0" cellpadding="0" style="width: 985px;
                        height: 486px">
                        <tr>
                            <td width="80%" valign="top">
                                <table cellpadding="0" cellspacing="0" width="790" style="width: 790px; height: 488px;"
                                    bordercolordark="#000000" border="0">
                                   <asp:DropDownList style="display:none;" runat="server" ID="drpusername">
                                    
                                   </asp:DropDownList><tr>
                                        <td style="height: 20px; width: 786px;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="36" style="height: 20px; width: 786px;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="height: 163px; width: 786px;" valign="top">
                                            <table width="0" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lbusername" runat="server" CssClass="TextField"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtusername" runat="server" DISABLED CssClass="btext1" ></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lboldpwd" runat="server" CssClass="TextField"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtoldpwd" runat="server" CssClass="btext1" TextMode="Password"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lbnewpwd" runat="server" CssClass="TextField"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtnewpwd" runat="server" CssClass="btext1" TextMode="Password"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lbconfpwd" runat="server" CssClass="TextField" Text="Confirm Password"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtcfrmpwd" runat="server" CssClass="btext1" TextMode="Password"></asp:TextBox>
                                                    </td>
                                                </tr>
                                             
                                                <tr>
                                                    <td height="30px">
                                                    </td>
                                                    <td align="right">
                                                    <input type="button" runat="server" value="Submit" id="btnsubmit" />
                                                        </td>
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
                  <input type="hidden" runat="server" id="hiddenusername" />
                  <input type="hidden" runat="server" id="hiddencompcode" />

  
    </form>
    
</body>
</html>
