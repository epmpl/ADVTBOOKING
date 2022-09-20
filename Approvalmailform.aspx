<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Approvalmailform.aspx.cs" Inherits="Approvalmailform" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Approval Mail Form</title>
    <style type="text/css">
        .style1
        {
            width: 90%;
        }
        .style2
        {
            height: 24px;
        }
    </style>
    <script type="text/javascript"  language="javascript" src="javascript/AuthorizationRelease.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table align="center" cellpadding="0" cellspacing="0" class="style1">
            <tr>
                <td align="center" colspan="4" 
                    style="font-family: Verdana; font-size: 20px; font-weight: bold; color: #000080;">
                    Mail Approval From</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="4" 
                    style="font-family: verdana; font-size: 10px; font-weight: bold">
                    <asp:Label ID="lblto" runat="server" Font-Bold="True" Font-Size="12px" 
                        Text="To "></asp:Label>
                    <asp:TextBox ID="txtmailto" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4" 
                    style="font-family: verdana; font-size: 10px; font-weight: bold">
                    <asp:Label ID="lblcc" runat="server" Font-Bold="True" Font-Size="12px" 
                        Text="Cc"></asp:Label>
                    <asp:TextBox ID="txtmailcc" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" 
                    style="font-family: verdana; font-size: 10px; font-weight: bold">
                    &nbsp;</td>
                <td align="center" 
                    style="font-family: verdana; font-size: 10px; font-weight: bold">
                    &nbsp;</td>
                <td align="right">
                    <asp:Button ID="btnmail" runat="server" Text="Send Mail" 
                        onclick="btnmail_Click" />
                </td>
                <td align="right">
                    &nbsp;</td>
            </tr>
             </table>
             <table align="center" cellpadding="0" width="100%" cellspacing="0" 
            style="margin-left: 201px" ><tr>
             <td align="right" class="style2"><asp:Label style="vertical-align:text-top" ID="Label1" runat="server" Font-Bold="True" Font-Size="12px" 
                        Text="Remark"></asp:Label></td>
                <td align="left"  style="font-family: verdana; font-size: 10px; font-weight: bold;" 
                         class="style2">
                    <asp:TextBox ID="txtremarks" TextMode="multiLine" CssClass="btext1_BOOKADI" 
                        Width="549px"  Height="50px" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    
    </div>
    <div id="mailbody"  runat="server" style="width:80%;margin-top:50px;"></div>
    
    </form>
</body>
</html>
