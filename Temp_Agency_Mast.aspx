<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Temp_Agency_Mast.aspx.cs" Inherits="Temp_Agency_Mast" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx" %>
<%@ Register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Temp. Agency Master</title>
    <script type="text/javascript" language="javascript" src="javascript/jquery.min.js"></script>
    <script type="text/javascript" language="javascript" src="javascript/Temp_Agency_Mast.js"></script>
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
        .auto-style1 {
            height: 28px;
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
        function isEmail(email) {
            if (document.Form1.txtmail.value.indexOf("@") != "-1" && document.Form1.txtmail.value.indexOf(".") != "-1")
                return true;
            else
                return false;
        }

        function checkEmail() {


            if (isEmail(document.Form1.txtmail.value) == false && document.Form1.txtmail.value != "") {
                alert("Enter your correct Email ID");
                document.Form1.txtmail.value = "";
                document.Form1.txtmail.focus();
                return false;
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
                                                                    BorderColor="DarkGray" Font-Bold="True" Width="16px">
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
                    <b>New Agency Master</b></center>
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
                    <asp:Label ID="lbagcategory" runat="server" CssClass="LabelText"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="drpagcategory" runat="server" CssClass="DrpTextfield"  >
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblagency" runat="server" CssClass="LabelText"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtagency" runat="server" CssClass="Textfield"></asp:TextBox>
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
                    <asp:Label ID="lbladd" runat="server" CssClass="LabelText"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtadd" runat="server" CssClass="Textfield">
                    </asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblplace" runat="server" CssClass="LabelText"></asp:Label>
                </td>
                <td>
                    <%--<asp:TextBox ID="txtplace" runat="server" CssClass="Textfield"></asp:TextBox>--%>
                    <asp:dropdownlist id="txtplace" runat="server" CssClass="DrpTextfield" >
                                        <asp:ListItem Value="0">---Select City---</asp:ListItem>
                                    </asp:dropdownlist>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="lblgst" runat="server" CssClass="LabelText"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtgst" runat="server" CssClass="Textfield">
                    </asp:TextBox>
                </td>
                <td class="auto-style1">
                    <asp:Label ID="lblmob" runat="server" CssClass="LabelText"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtmob" runat="server" onkeypress="return notchar2(event);"   CssClass="Textfield" MaxLength="12"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="lblpincode" runat="server" CssClass="LabelText"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtpincode" runat="server" onkeypress="return notchar2(event);"  CssClass="Textfield" MaxLength="10">
                    </asp:TextBox>
                </td>
                 <td class="auto-style1">
                    <asp:Label ID="lblphone" runat="server" CssClass="LabelText"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtphone" runat="server" onkeypress="return notchar2(event);"   CssClass="Textfield" MaxLength="12"></asp:TextBox>
                </td>
                 </tr>
        </table>
    </div>
     <div id="ViewButton" style="width: 600px; height: auto; max-height: 40px; margin-left: 520px; padding-top: 10px; border: 0px solid #7DAAE3; overflow: auto;">
          &nbsp;
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
        <input type="hidden" runat="server" id="hdnrefbookingid" />
         <input type="hidden" runat="server" id="hdnrefflag" />
        
    </form>
</body>
</html>

