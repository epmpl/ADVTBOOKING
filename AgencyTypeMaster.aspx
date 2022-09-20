<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AgencyTypeMaster.aspx.cs" Inherits="AgencyTypeMaster" EnableSessionState="True" %>

<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx" %>
<%@ Register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Display Ad. Booking & Sheduling Agency Type Master</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
    <meta content="C#" name="CODE_LANGUAGE" />
    <meta content="JavaScript" name="vs_defaultClientScript" />
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
    <script type="text/javascript" language="javascript" src="javascript/AgencyTypeMaster.js"></script>
    <script type="text/javascript" language="javascript" src="javascript/permission.js"></script>
    <script type="text/javascript" language="javascript" src="javascript/Validations.js"></script>
    <script type="text/javascript" language="javascript" src="javascript/tree.js"></script>
    <script type="text/javascript" language="javascript" src="javascript/TreeLibrary.js"></script>
    <script type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>
    <script type="text/javascript" language="javascript" src="javascript/datevalidation.js"></script>
    <script type="text/javascript" language="javascript" src="javascript/givepermission.js"></script>

    <script type="text/javascript" language="javascript" src="javascript/entertotab.js"></script>
    <%--<script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>--%>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="css/main.css" type="text/css" rel="stylesheet" />
    <link href="css/agencytypemaster.css" type="text/css" rel="stylesheet" />


    <script type="text/javascript" language="javascript">

        function notchar(event) {
            if (browser != "Microsoft Internet Explorer") {
                if ((event.which >= 48 && event.which <= 57) ||
               (event.which == 8) ||
               (event.which == 189) ||
               (event.which == 36) ||
               (event.which == 35) ||
               (event.which == 46) ||
               (event.which == 37) ||
               (event.which == 39) ||
               (event.which == 9 || event.which == 32)) {
                    document.getElementById('txtcommrate').value = document.getElementById('txtcommrate').value;
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                if ((event.keyCode >= 48 && event.keyCode <= 57) ||
                (event.keyCode == 8) ||
                (event.keyCode == 189) ||
                (event.keyCode == 36) ||
                (event.keyCode == 35) ||
                (event.keyCode == 46) ||
                (event.keyCode == 37) ||
                (event.keyCode == 39) ||
                (event.keyCode == 9 || event.keyCode == 32)) {
                    document.getElementById('txtcommrate').value = document.getElementById('txtcommrate').value;
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        function datecurr(event) {
            if (browser != "Microsoft Internet Explorer") {
                if ((event.which >= 48 && event.which <= 57) || (event.which == 47) || (event.which == 11) || (event.which == 8) || (event.which == 9)) {

                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 47) || (event.keyCode == 11) || (event.which == 9)) {

                    return true;
                }
                else {
                    return false;
                }
            }
        }
        function notchar212(event) {
            var browser = navigator.appName;
            if (browser != "Microsoft Internet Explorer") {
                if ((event.which >= 46 && event.which <= 57) || (event.which >= 96 && event.which <= 105) || (event.which == 111) || (event.which == 127) || (event.which == 190) || (event.which == 8) || (event.which == 9) || (event.which == 13) || (event.which == 0)) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {

                if ((event.keyCode >= 46 && event.keyCode <= 57) || (event.keyCode >= 96 && event.keyCode <= 105) || (event.keyCode == 111) || (event.keyCode == 127) || (event.keyCode == 190) || (event.keyCode == 8) || (event.keyCode == 9) || (event.keyCode == 13)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        function notchar212(event) {
            //alert(event.keyCode);
            var browser = navigator.appName;
            if (browser != "Microsoft Internet Explorer") {
                if ((event.which >= 48 && event.which <= 57) || (event.which == 127) || (event.which == 8) || (event.which == 9) || (event.which == 0)) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 127) || (event.keyCode == 8) || (event.keyCode == 9)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }


    </script>

</head>
<body id="bdy" onload="javascript:return blankagency();" onkeydown="javascript:return tabvalue(event,'txtcreditdays');" onkeypress="eventcalling(event);" style="background-color: #f3f6fd;">

    <form id="Form1" method="post" runat="server">
        <table id="OuterTable" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr valign="top">
                <td colspan="2">
                    <uc1:Topbar ID="Topbar1" runat="server" Text="Agency Type Master"></uc1:Topbar>
                </td>
            </tr>
            <tr valign="top" style="width: 100%">
                <td valign="top" class="rel">
                    <uc2:Leftbar ID="Leftbar1" runat="server"></uc2:Leftbar>
                </td>
                <td valign="top" class="agencytypetopbar">
                    <table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0">
                        <tr valign="top">
                            <td>
                                <asp:ImageButton ID="btnNew" runat="server" CssClass="topbutton" Font-Size="XX-Small"
                                    BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton ID="btnSave" runat="server" CssClass="topbutton" Font-Size="XX-Small" BackColor="Control"
                                        BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton ID="btnModify" runat="server" Font-Size="XX-Small" BackColor="Control"
                                            BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton ID="btnQuery" runat="server" Font-Size="XX-Small" BackColor="Control"
                                                BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton ID="btnExecute" runat="server" Font-Size="XX-Small"
                                                    BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton ID="btnCancel" runat="server" Font-Size="XX-Small" BackColor="Control"
                                                        BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton ID="btnfirst" CssClass="topbutton" runat="server" Font-Size="XX-Small" BackColor="Control"
                                                            BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton ID="btnprevious" runat="server" Font-Size="XX-Small"
                                                                BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton ID="btnnext" runat="server" Font-Size="XX-Small" BackColor="Control"
                                                                    BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton ID="btnlast" runat="server" Font-Size="XX-Small" BackColor="Control"
                                                                        BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton ID="btnDelete" runat="server" Font-Size="XX-Small" BackColor="Control"
                                                                            BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton ID="btnExit" runat="server" Font-Size="XX-Small" BackColor="Control"
                                                                                BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton>
                            </td>
                        </tr>

                    </table>
                </td>
            </tr>
        </table>
        <table border="0" class="pagen">
            <tr>
                <td style="width: 27px;"></td>
                <td style="background-image: url(images/corner-left.jpg); width: 11px; background-position: right center; background-repeat: no-repeat; height: 20px;"></td>
                <td style="width: 13.5%; font-family: Verdana; text-align: right; font-size: 10px; background-color: #a0bfeb; height: 20px;"><b>
                    <center>Agency Type Master</center>
                </b></td>
                <td style="background-image: url(images/corner-right.jpg); background-repeat: no-repeat; height: 20px; width: 11px"></td>
                <td style="width: 100%">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="background-color: #a0bfeb; width: 77%; height: 3px;"></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>

        <table style="width: 60%; margin: -20px 230px" cellpadding="0" cellspacing="0">
            <tr style="display: none">
                <td>
                    <asp:LinkButton ID="agencytypslab" Style="cursor: pointer" runat="server" CssClass="btnlink_n">Agency Type Wise Slab</asp:LinkButton>
                </td>
            </tr>
        </table>


        <table class="agfield">
            <tr>
                <td>
                    <asp:Label ID="AgencyTypeCode" runat="server" CssClass="TextField"></asp:Label></td>
                <td>
                    <asp:TextBox onkeypress="return ClientSpecialchar(event);" ID="txtagencycode" runat="server" CssClass="btext1"
                        MaxLength="15"></asp:TextBox></td>
                <td>
                    <asp:Label ID="Adcat" runat="server" CssClass="TextField"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="drpadcat" runat="server" CssClass="dropdown" Enabled="False">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="AgencyTypeName" runat="server" CssClass="TextField"></asp:Label></td>
                <td colspan="3">
                    <asp:TextBox onkeypress="return ClientSpecialchar(event);" ID="txtagencyname" runat="server" CssClass="btext"
                        MaxLength="15"></asp:TextBox></td>

                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Alias" runat="server" CssClass="TextField"></asp:Label></td>
                <td colspan="3">
                    <asp:TextBox onkeypress="return ClientSpecialchar(event);" ID="txtalias" runat="server" CssClass="btext"
                        MaxLength="30"></asp:TextBox></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="EffectiveFrom" runat="server" CssClass="TextField"></asp:Label></td>
                <td>
                    <asp:TextBox onkeydown="return datecurr(event);" MaxLength="10" ID="txtefffrom" runat="server" CssClass="startandenddate" onpaste="return false;"></asp:TextBox>

                    <script type="text/javascript" language="javascript">
                        if (!document.layers) {
                            document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, Form1.txtefffrom, \"mm/dd/yyyy\")' Height=14  width=14>")
                        }
                    </script>
                </td>
                <td>
                    <asp:Label ID="EffectiveTill" runat="server" CssClass="TextField"></asp:Label></td>
                <td>
                    <asp:TextBox onkeydown="return datecurr(event);" MaxLength="10" ID="txtefftill" runat="server" CssClass="startandenddate" onpaste="return false;"></asp:TextBox>
                    <script type="text/javascript" language="javascript">
                        if (!document.layers) {
                            document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, Form1.txtefftill, \"mm/dd/yyyy\")' Height=14  width=14>")
                        }
                    </script>

                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="CommissionRate" runat="server" CssClass="TextField"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtcommrate" runat="server" CssClass="btext1" onkeypress="return notchar212(event);"
                        MaxLength="5"></asp:TextBox></td>

                <td>
                    <asp:Label ID="CommissionApllyOn" runat="server" CssClass="TextField"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="drpcommdetail" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="0">--Select Type--</asp:ListItem>
                        <asp:ListItem Value="Gross">Gross</asp:ListItem>
                        <asp:ListItem Value="Net">Net</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="CreditDays" runat="server" CssClass="TextField"></asp:Label></td>
                <td>
                    <asp:TextBox onkeypress="return ClientisNumber(event);" ID="txtcreditdays" runat="server" CssClass="btext1"
                        MaxLength="3"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblmrvno" runat="server" CssClass="TextField"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="drpmrvno" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="0">--Select MRV Ref No--</asp:ListItem>
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                        <asp:ListItem Value="N">No</asp:ListItem>
                    </asp:DropDownList></td>



            </tr>




            <tr>
                <td>
                    <asp:Label ID="lblpamtargettable" runat="server" CssClass="TextField"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txttargettable" runat="server" CssClass="btext1"></asp:TextBox>
                </td>

                <td>
                    <asp:Label ID="lblmonthenddate" runat="server" CssClass="TextField"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="drpmonthenddate" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                        <asp:ListItem Value="N">No</asp:ListItem>
                    </asp:DropDownList></td>



            </tr>




            <tr>
                <td>
                    <asp:Label ID="lblcommisionreq" runat="server" CssClass="TextField"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="drpcommisionreq" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                        <asp:ListItem Value="N">No</asp:ListItem>
                    </asp:DropDownList>
                </td>

                <td>&nbsp;</td>
                <td>&nbsp;</td>



            </tr>




        </table>
        <input id="hiddencomcode" type="hidden" size="1" name="hiddencomcode" runat="server" />
        <input id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server" />
        <input id="hiddendateformat" type="hidden" size="1" name="Hidden2" runat="server" />
        <input id="hiddencompcode" type="hidden" size="1" name="hiddencompcode" runat="server" />
        <input id="hiddenusername" type="hidden" name="username" runat="server" />
        <input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
        <input id="hiddenuniqueid" type="hidden" name="hiddenuniqueid" runat="server" />
        <input id="hiddenagtypename" type="hidden" name="hiddenagtypename" runat="server" />
        <input id="ip1" type="hidden" name="ip1" runat="server" />
        <input id="hiddensession" type="hidden" name="ip1" runat="server" />
        <input id="hdnconntype" type="hidden" name="hdnconntype" runat="server" />
    </form>
</body>
</html>
