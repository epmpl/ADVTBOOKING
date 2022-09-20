<%@ Page Language="C#" AutoEventWireup="true" CodeFile="copyrate1.aspx.cs" Inherits="copyrate1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Copy Rate</title>
    <script language="javascript" type="text/javascript" src="javascript/copyrate1.js"></script>
    <script language="javascript" type="text/javascript" src="javascript/Validations.js"></script>
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <table style="width:1000px; text-align:center">
            <tr>
                <td>
                    <table>
                        <tr onkeypress="eventcalling(event)">
                            <td style="text-align:left">
                                <asp:Label ID="lblsrcrcode" runat="server" Text="Sorce Rate Code" CssClass="TextField"></asp:Label>
                            </td>
                            
                            <td>
                                <asp:TextBox ID="txtsrcrcode" runat="server" CssClass="btext1"></asp:TextBox>
                            </td>
                            <td style="text-align:left">
                                <asp:Label ID="lbldestrcode" runat="server" Text="Destination Rate Code" CssClass="TextField"></asp:Label>
                            </td>
                            
                            <td>
                                <asp:TextBox ID="txtdestrcode" runat="server" CssClass="btext1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:left">
                                <asp:Label ID="lblsrcrgrcode" runat="server" Text="Sorce Rate Group Code" CssClass="TextField"></asp:Label>
                            </td>
                            
                            <td>
                                <asp:DropDownList ID="drpsrcrgrcode" CssClass="dropdown" runat="server"></asp:DropDownList>
                            </td>
                            
                            <td style="text-align:left">
                                <asp:Label ID="lbldestrgrcode" runat="server" Text="Destination Rate Group Code" CssClass="TextField"></asp:Label>
                            </td>
                            
                            <td>
                                <asp:DropDownList ID="drpdestrgrcode" CssClass="dropdown" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align:right">
                                <asp:Button ID="btncopy" Text="Copy" runat="server" CssClass="topbutton" OnClientClick="javascript:return copyrate()" />
                            </td>
                            <td colspan="2" style="text-align:left">
                                <asp:Button ID="btnreset" Text="Reset" CssClass="topbutton" runat="server" OnClientClick="javascript:return rset1()" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <input type="hidden" id="hiddendateformat" runat="server" />
    </form>
</body>
</html>
