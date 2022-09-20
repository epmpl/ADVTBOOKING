<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ADV_Page_Reservation.aspx.cs" Inherits="ADV_Page_Reservation" EnableEventValidation="false" %>

<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx" %>
<%@ Register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx" %>
<!DOCTYPE html>

<head id="Head1" runat="server">
    <title>Page Reservation</title>
    <script type="text/javascript" language="javascript" src="javascript/jquery.min.js"></script>
    <script language="javascript" type="text/javascript" src="javascript/givepermission.js"></script>
    <script language="javascript" type="text/javascript" src="javascript/popupcalender.js"></script>
    <script language="javascript" type="text/javascript" src="javascript/datevalidation.js"></script>


    <script type="text/javascript" language="javascript" src="javascript/ADV_Page_Reservation.js"></script>
    <link href="css/main.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .LabelText {
            font-family: Trebuchet MS;
            color: Black;
            text-align: right;
            height: 11px;
            font-size: small;
            height: 13px;
            width: 150px;
        }

        .Textfield {
            border: 1px solid #929292;
            background-color: #ffffff;
            font-family: verdana;
            font-size: 10px;
            color: #000000;
            text-transform: uppercase;
        }

        .DrpTextfield {
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
            width: 135px;
        }

        .btextforbook {
        }

        .auto-style2 {
            width: 171px;
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
        <div id="divunit" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:ListBox ID="lstunit" Width="300px" Height="100px" runat="server" CssClass="Textfield"></asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divclient" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>

                        <asp:ListBox ID="lstclient" Width="550px" Height="185px" runat="server" CssClass="btextlistagen"></asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        <%--<div id="divmail" style="border: 0px solid rgb(0, 0, 0); position: absolute; top: 0px; left: 0px; display: none; z-index: 1;">
        </div>--%>


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
                                    BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton ID="btnSave" runat="server" CssClass="topbutton"
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
                                                                            BorderColor="DarkGray" Font-Bold="True" Width="16px"></asp:ImageButton><asp:ImageButton ID="btnExit" runat="server" Font-Size="XX-Small"
                                                                                BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table border="0" width="100%" cellpadding="0" cellspacing="0" style="width: auto; margin: 15px 30px;">
            <tr>
                <td style="width: 27px;"></td>
                <td style="background-image: url(images/corner-left.jpg); width: 11px; background-position: right center; background-repeat: no-repeat; height: 20px;"></td>
                <td style="width: 150PX; font-family: Verdana; text-align: right; font-size: 10px; background-color: #a0bfeb; height: 20px;">
                    <center>
                    <b>Page Reservation</b></center>
                </td>
                <td style="background-image: url(images/corner-right.jpg); background-repeat: no-repeat; height: 20px; width: 11px"></td>
                <td style="width: 750px">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="background-color: #a0bfeb; width: 750px; height: 3px;"></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <div id="div1" style="border: 2px solid rgb(0, 0, 0); position: absolute; top: 0px; left: 0px; display: none; z-index: 1;">
        </div>
        <div id="Div2" runat="server" style="width: 1131px; padding-left: 15px; float: left; margin-top: 10px; border: 2px solid #7DAAE3; margin-left: 25px; padding-top: 10px; padding-bottom: 10px; height: 473px;">
            <table align="left" cellspacing="0" cellpadding="1" style="width: 1000px;">
                <tr style="vertical-align: top">
                    <td class="auto-style2" style="vertical-align: top">
                        <asp:Label ID="lblrcode" runat="server" CssClass="LabelText"></asp:Label>
                    </td>
                    <td style="vertical-align: top">
                        <asp:TextBox ID="txtrcode" runat="server" CssClass="Textfield" OnTextChanged="txtschdate_TextChanged" Width="214px"></asp:TextBox>
                    </td>
                    <td class="auto-style1" style="vertical-align: top; margin-left: 10px">
                        <asp:Label ID="lblcreatedby" runat="server" CssClass="LabelText"></asp:Label>
                    </td>
                    <td style="vertical-align: top">
                        <asp:TextBox ID="txtcreatedby" runat="server" CssClass="Textfield" OnTextChanged="txtschdate_TextChanged" Width="229px"></asp:TextBox>
                    </td>
                </tr>
                <tr style="vertical-align: top">
                    <td class="auto-style2" style="vertical-align: top">
                        <asp:Label ID="lblschdate" runat="server" CssClass="LabelText"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtschdate" runat="server" CssClass="Textfield" OnTextChanged="txtschdate_TextChanged" Width="203px"></asp:TextBox>
                        <img src='Images/cal1.gif' onclick='popUpCalendar(this, Form1.txtschdate, "mm/dd/yyyy")' height="14" width="14">
                    </td>
                    <td class="auto-style1" style="vertical-align: top">
                        <asp:Label ID="lbladsize" runat="server" CssClass="LabelText"></asp:Label>
                    </td>
                    <td style="vertical-align: top">
                        <asp:TextBox ID="txtw" runat="server" CssClass="Textfield" OnTextChanged="txtw_TextChanged" Width="114px">
                        </asp:TextBox><asp:TextBox ID="txth" runat="server" CssClass="Textfield" OnTextChanged="txth_TextChanged" Width="108px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" style="vertical-align: top">
                        <asp:Label ID="lblclient" runat="server" CssClass="LabelText"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtclient" runat="server" CssClass="Textfield" onkeyup="javascript:return f2query(event);" Width="219px"></asp:TextBox>
                    </td>
                    <td class="auto-style1" style="vertical-align: top">
                        <asp:Label ID="lblpageprem" runat="server" CssClass="LabelText"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="drppageprem" runat="server" CssClass="DrpTextfield" Width="229px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top" class="auto-style2">
                        <asp:Label ID="lblpubl" runat="server" CssClass="LabelText"></asp:Label>
                    </td>
                    <td style="vertical-align: top">
                        <asp:ListBox ID="drppubl" runat="server" CssClass="btextlistqbcnew" Enabled="False" Height="87px" SelectionMode="Multiple" Width="228px"></asp:ListBox>
                    </td>
                    <td class="auto-style1" style="vertical-align: top">
                        <asp:Label ID="lbledtn" runat="server" CssClass="LabelText"></asp:Label>
                    </td>
                    <td style="vertical-align: top">
                        <asp:ListBox ID="drpedtn" runat="server" CssClass="btextlistqbcnew" Enabled="False" Height="87px" SelectionMode="Multiple" Width="241px">
                            <asp:ListItem Value="CITY">CITY</asp:ListItem>
                            <asp:ListItem Value="LATE CITY">LATE CITY</asp:ListItem>
                        </asp:ListBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblstatus" runat="server" CssClass="LabelText"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="drpstatus" runat="server" CssClass="DrpTextfield" Width="229px">
                            <asp:ListItem Value="O">Booked</asp:ListItem>
                            <asp:ListItem Value="C">Canceled</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="lblremark" runat="server" CssClass="LabelText"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtremark" runat="server" CssClass="Textfield" OnTextChanged="txtschdate_TextChanged" Width="229px"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <%--<div id="ViewButton" style="width: 1000px; height: auto; max-height: 40px; margin-left: 25px; padding-top: 10px; border: 0px solid #7DAAE3; overflow: auto;">
            </div>--%>
            <div id="divmail" style="width: 1000px; height: auto; max-height: 1000px; margin-left: 25px; padding-top: 10px; border: 0px solid #7DAAE3; overflow: auto;">
            </div>
        </div>


    </form>
    <input type="hidden" runat="server" id="hiddencompcode" />
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
    <input type="hidden" runat="server" id="hiddenadtype" />
    <input type="hidden" runat="server" id="hdnclientcode" />
    <input type="hidden" runat="server" id="hdnmode" />
    <input type="hidden" runat="server" id="hdntrnid" />
    <input type="hidden" runat="server" id="hdncurrdate" />
    <input type="hidden" runat="server" id="hdncenter" />
    
</body>
</html>


