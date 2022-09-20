<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ad_Branch_Mail_Master.aspx.cs"
    Inherits="Ad_Branch_Mail_Master" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx" %>
<%@ Register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Branch Mail Master</title>
    <script type="text/javascript" language="javascript" src="javascript/jquery.min.js"></script>
    <script type="text/javascript" language="javascript" src="javascript/Ad_Branch_Mail_Master.js"></script>
    <link href="css/main.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .LabelText
        {
            font-family: Trebuchet MS;
            color: Black;
            text-align: right;
            height: 11px;
            font-size: small;
            height: 13px;
            width: 150px;
        }
        
        .Textfield
        {
            border: 1px solid #929292;
            background-color: #ffffff;
            font-family: verdana;
            font-size: 10px;
            color: #000000;
            height: 13px;
            width: 195px;
            text-transform: uppercase;
        }
        
        .DrpTextfield
        {
            border: 1px solid #929292;
            background-color: #ffffff;
            font-family: verdana;
            font-size: 10px;
            color: #000000;
            height: 17px;
            width: 200px;
            text-transform: uppercase;
        }
    </style>
    <script type="text/javascript" language="javascript">
        var str = "adcv";
        function notchar2(event) {
            var i;
            var browser = navigator.appName;
            if (browser != "Microsoft Internet Explorer") {
                if ((event.which >= 46 && event.which <= 57) || (event.which == 127) || (event.which == 8) || (event.which == 9)) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                if ((event.keyCode >= 46 && event.keyCode <= 57) || (event.keyCode == 127) || (event.keyCode == 8) || (event.keyCode == 9)) {
                    return true;
                }
                else {
                    return false;
                }
            }

        }
        function ClientSpecialchardp(event) {
            var browser = navigator.appName;
            if (browser != "Microsoft Internet Explorer") {
                if ((event.which >= 48 && event.which <= 57) || (event.which == 0) || (event.which == 44) || (event.which == 45) || (event.which == 38) || (event.which == 8) || (event.which == 189) || (event.which >= 97 && event.which <= 122) || (event.which == 32) || (event.which >= 65 && event.which <= 90)) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 8) || (event.keyCode == 44) || (event.keyCode == 45) || (event.keyCode == 38) || (event.keyCode == 189) || (event.keyCode >= 97 && event.keyCode <= 122) || (event.keyCode == 9 || event.keyCode == 32) || (event.keyCode >= 65 && event.keyCode <= 90)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
    </script>
</head>
<body id="bdy" style="background-color: #f3f6fd;" onkeydown="javascript:return EnterTab(event,this.id);">
    <form id="Form1" method="post" runat="server">
    <div id="divunit" style="position: absolute; top: 0px; left: 0px; border: none; display: none;
        z-index: 1;">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:ListBox ID="lstunit" Width="300px" Height="100px" runat="server" CssClass="Textfield">
                    </asp:ListBox>
                </td>
            </tr>
        </table>
    </div>
    <div id="divbranch" style="position: absolute; top: 0px; left: 0px; border: none;
        display: none; z-index: 2;">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:ListBox ID="lstbranch" Width="300px" Height="100px" runat="server" CssClass="Textfield">
                    </asp:ListBox>
                </td>
            </tr>
        </table>
    </div>
    <div id="divuser" style="position: absolute; top: 0px; left: 0px; border: none; display: none;
        z-index: 3;">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:ListBox ID="lstuser" Width="300px" Height="100px" runat="server" CssClass="Textfield">
                    </asp:ListBox>
                </td>
            </tr>
        </table>
    </div>
    <table id="OuterTable" cellspacing="0" cellpadding="0" width="1000" border="0">
        <tr valign="top">
            <td colspan="2">
                <uc1:Topbar ID="Topbar1" runat="server" Text="Barter Master"></uc1:Topbar>
            </td>
        </tr>
        <tr valign="top">
            <td valign="top">
                <uc2:Leftbar ID="Leftbar1" runat="server"></uc2:Leftbar>
            </td>
            <td valign="top" style="width: 796px">
                <table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0">
                    <tr valign="top">
                        <td style="height: 24px; width: 758px;">
                            <asp:ImageButton ID="btnNew" runat="server" CssClass="topbutton" Font-Size="XX-Small"
                                BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True">
                            </asp:ImageButton><asp:ImageButton ID="btnSave" runat="server" CssClass="topbutton"
                                Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray"
                                Font-Bold="True"></asp:ImageButton><asp:ImageButton ID="btnModify" runat="server"
                                    Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray"
                                    Font-Bold="True"></asp:ImageButton><asp:ImageButton ID="btnQuery" runat="server"
                                        Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray"
                                        Font-Bold="True"></asp:ImageButton><asp:ImageButton ID="btnExecute" runat="server"
                                            Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray"
                                            Font-Bold="True"></asp:ImageButton><asp:ImageButton ID="btnCancel" runat="server"
                                                Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray"
                                                Font-Bold="True"></asp:ImageButton><asp:ImageButton ID="btnfirst" CssClass="topbutton"
                                                    runat="server" Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset"
                                                    BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton ID="btnprevious"
                                                        runat="server" Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset"
                                                        BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton ID="btnnext"
                                                            runat="server" Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset"
                                                            BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton ID="btnlast"
                                                                runat="server" Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset"
                                                                BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton ID="btnDelete"
                                                                    runat="server" Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset"
                                                                    BorderColor="DarkGray" Font-Bold="True">
                            </asp:ImageButton><asp:ImageButton ID="btnExit" runat="server" Font-Size="XX-Small"
                                BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True">
                            </asp:ImageButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table border="0" width="100%" cellpadding="0" cellspacing="0" style="width: auto;
        margin: 15px 30px;">
        <tr>
            <td style="width: 27px;">
            </td>
            <td style="background-image: url(images/corner-left.jpg); width: 11px; background-position: right center;
                background-repeat: no-repeat; height: 20px;">
            </td>
            <td style="width: 150PX; font-family: Verdana; text-align: right; font-size: 10px;
                background-color: #a0bfeb; height: 20px;">
                <center>
                    <b>Branch Mail Master</b></center>
            </td>
            <td style="background-image: url(images/corner-right.jpg); background-repeat: no-repeat;
                height: 20px; width: 11px">
            </td>
            <td style="width: 750px">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="background-color: #a0bfeb; width: 750px; height: 3px;">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="Div2" runat="server" style="width: 720px; padding-left: 15px; float: left;
        margin-top: 10px; border: 2px solid #7DAAE3; margin-left: 240px; padding-top: 10px;
        padding-bottom: 10px;">
        <table align="left" cellspacing="0" cellpadding="1" style="width: 740px;">
            <tr>
                <td>
                    <asp:Label ID="lblunitname" runat="server" CssClass="LabelText"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtunitname" runat="server" CssClass="Textfield"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lbbranchname" runat="server" CssClass="LabelText"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbranch" runat="server" CssClass="Textfield"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbluser" runat="server" CssClass="LabelText"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtuserid" runat="server" CssClass="Textfield"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblmail" runat="server" CssClass="LabelText"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtmail" runat="server" CssClass="Textfield"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblmodule" runat="server" CssClass="LabelText"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="drpmoduleid" runat="server" CssClass="DrpTextfield">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="lblremarks" runat="server" CssClass="LabelText"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtremarks" runat="server" CssClass="Textfield"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblflag" runat="server" CssClass="LabelText"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="drpflag" runat="server" CssClass="DrpTextfield">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
     <div id="ViewButton" style="width: 600px; height: auto; max-height: 40px; margin-left: 520px; padding-top: 10px; border: 0px solid #7DAAE3; overflow: auto;">
            <input type="button" id="btnview" runat="server" value="View" style="height: 25px; width: 75px; border-radius: 10px; background-color: #a7d2fc;" onclick="javascript: return OnClickView();" />
        </div>
        <div id="View" style="padding: 0; width: 1240px; height: auto; max-height: 350px; margin-left: 10px; margin-top: 10px; border: 2px solid #7DAAE3; overflow: hidden; border-radius: 4px; background-color: #f6f2dc;">
        </div>
    <input type="hidden" runat="server" id="hdncompcode" />
    <input type="hidden" runat="server" id="hdncompname" />
    <input type="hidden" runat="server" id="hdnunitcd" />
    <input type="hidden" runat="server" id="hdnunitnm" />
    <input type="hidden" runat="server" id="hdnbrancd" />
    <input type="hidden" runat="server" id="hdnbrannm" />
    <input type="hidden" runat="server" id="hdnusernm" />
    <input type="hidden" runat="server" id="hdnuserid" />
    <input type="hidden" runat="server" id="hiddendateformat" />
    <input type="hidden" runat="server" id="hdnunitcode" />
    <input type="hidden" runat="server" id="hdnbranccode" />
    <input type="hidden" runat="server" id="hdnusercode" />
    <input type="hidden" runat="server" id="hdntransid" />
    </form>
</body>
</html>

