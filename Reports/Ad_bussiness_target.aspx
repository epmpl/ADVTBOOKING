<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ad_bussiness_target.aspx.cs"
    Inherits="Reports_Ad_bussiness_target" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Bussiness Target Analisis</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1" />
    <meta name="CODE_LANGUAGE" content="C#" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <style type="text/css">
        .style1
        {
            font-weight: bold;
            color: #ffffff;
            font-family: Verdana, Arial, Helvetica, sans-serif;
        }
        .style2
        {
            color: #ffffff;
        }
    </style>
    <link href="css/main.css" type="text/css" rel="stylesheet" />
    <link href="css/booking.css" type="text/css" rel="stylesheet" />
    <link href="css/report.css" type="text/css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />

    <script type="text/javascript" language="javascript" src="javascript/datevalidation.js"></script>

    <script type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>

    <script type="text/javascript" language="javascript" src="javascript/new.js"></script>

    <script type="text/javascript" language="javascript" src="javascript/entertotab.js"></script>

    <script type="text/javascript" language="javascript" src="javascript/Ad_bussiness_target.js"></script>

    <script type="text/javascript" language="javascript" src="javascript/prototype.js"></script>

    <style type="text/css">
        .style1
        {
            font-weight: bold;
            font-size: xx-large;
            color: #ffffff;
        }
        .style2
        {
            color: #ffffff;
        }
        .style4
        {
            font-weight: normal;
            font-size: 14pt;
            color: #d85414;
            font-family: Verdana;
        }
        .style6
        {
            font-size: x-small;
        }
        .style7
        {
            font-weight: bold;
            color: #6666ff;
        }
    </style>
</head>
<body onload="javascript:return clear_onload();">
    <form id="report1" runat="server">
    <div id="div1" style="position: absolute; top: 0px; left: 0px; border: none; display: none;
        z-index: 1;">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:ListBox ID="lstagency" Width="382px" Height="75px" runat="server" CssClass="btextlist">
                    </asp:ListBox>
                </td>
            </tr>
        </table>
    </div>
    <table width="1005" border="0" cellspacing="0" cellpadding="0" align="center" style="width: 1005px;
        height: 358px">
        <tr>
            <td width="100%" bordercolor="#1">
                <img src="images/img_02A.jpg" width="1004" border="0" />
            </td>
        </tr>
        <tr>
            <td id="td2" onclick="javascript:return logoutpage();" width="100%" bordercolor="#1"
                style="background-image: url('images/top.jpg'); font-family: Trebuchet MS; font-size: 13px;
                color: #CC0000; cursor: hand;" align="right">
                LogLogout
            </td>
        </tr>
        <tr>
            <td style="height: 505px">
                <table width="985" border="0" cellspacing="0" cellpadding="0" style="width: 985px;
                    height: 486px">
                    <tr>
                        <!---------left bar start--------->
                        <td width="200" style="width: 200px">
                            <img src="images/leftbar.jpg" style="width: 193px; height: 483px" height="483" width="193" />
                        </td>
                        <!---------left bar end--------->
                        <!---------middle start--------->
                        <td valign="top" style="width: 78%">
                            <table cellpadding="0" cellspacing="0" width="790" style="width: 790px; height: 488px"
                                bordercolordark="#000000" border="1">
                                <tr>
                                    <td align="center">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="heading" runat="server" CssClass="heading"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                        <table width="0" border="0" cellspacing="0" cellpadding="0">
                                            <tr style="visibility:hidden;">
                                                <td align="left">
                                                    <asp:Label ID="agencyname" runat="server" CssClass="TextField"></asp:Label>
                                                    <td style="height: 25px" align="left">
                                                        <asp:TextBox CssClass="btext1" ID="dpagency" runat="server" Enabled="false"></asp:TextBox>
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lbDateFrom" runat="server" CssClass="TextField"></asp:Label>
                                                </td>
                                                <td style="height: 25px" align="left">
                                                    <asp:TextBox ID="txtfrmdate" runat="server" CssClass="btext1" onblur="javascript:return ValidateForm(event,this.id)"></asp:TextBox>
                                                    <img src='Images/cal1.gif' onclick='popUpCalendar(this, report1.txtfrmdate, "mm/dd/yyyy")'
                                                        onfocus="abc();" height="14" width="14" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lbToDate" runat="server" CssClass="TextField"></asp:Label>
                                                </td>
                                                
                                                <td style="height: 25px" align="left">
                                                    <asp:TextBox ID="txttodate1" runat="server" CssClass="btext1" Enabled="true"></asp:TextBox>
                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, report1.txttodate1, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lbPublication" runat="server" CssClass="TextField"></asp:Label>
                                                </td>
                                                <td style="height: 25px" align="left">
                                                    <asp:DropDownList ID="dppub1" runat="server" CssClass="dropdown">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr style="visibility:hidden;">
                                                <td align="left">
                                                    <asp:Label ID="lbedition" runat="server" CssClass="TextField"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="drpedition" runat="server" CssClass="dropdown">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lbadtype" runat="server" CssClass="TextField"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="drpadtype" runat="server" CssClass="dropdown">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lbuom" runat="server" CssClass="TextField"></asp:Label>
                                                </td>
                                                <td style="height: 25px" align="left">
                                                    <%-- <asp:DropDownList id="drpuom" runat="server" CssClass="dropdown" type="password" ></asp:DropDownList>--%>
                                                    <asp:ListBox ID="drpuom" runat="server" CssClass="btext1" Height="70px" SelectionMode="Multiple"
                                                        Width="144px"></asp:ListBox>
                                                </td>
                                            </tr>
                                            <tr style="visibility:hidden;">
                                                <td align="left">
                                                    <asp:Label ID="lbpaymode" runat="server" CssClass="TextField"></asp:Label>
                                                </td>
                                                <td style="height: 25px" align="left">
                                                    <asp:DropDownList ID="drppaymode" runat="server" CssClass="dropdown">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr style="visibility:hidden;">
                                                <td align="left">
                                                    <asp:Label ID="lbbasedon" runat="server" CssClass="TextField"></asp:Label>
                                                </td>
                                                <td style="height: 25px" align="left">
                                                    <asp:DropDownList ID="drpbasedon" runat="server" CssClass="dropdown">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lbdestination" runat="server" CssClass="TextField"></asp:Label>
                                                </td>
                                                <td style="height: 25px" align="left">
                                                    <asp:DropDownList ID="drpdestination" runat="server" CssClass="dropdown" type="password">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr style="visibility:hidden;">
                                                <td>
                                                    <asp:RadioButton ID="rdoexecutive" runat="server" CssClass="TextField" GroupName="radio5"
                                                        onclick="javascript:return enabledisable(this.id)" Checked="true" />
                                                </td>
                                                <td>
                                                    <asp:RadioButton ID="rdoagencywise" runat="server" CssClass="TextField" onclick="javascript:return enabledisable(this.id)"
                                                        GroupName="radio5" />
                                                </td>
                                                <td>
                                                    <asp:RadioButton ID="rdouomwise" runat="server" CssClass="TextField" onclick="javascript:return enabledisable(this.id)"
                                                        GroupName="radio5" />
                                                </td>
                                                <td>
                                                    <asp:RadioButton ID="rdosupplinentwise" runat="server" CssClass="TextField" Visible="false"
                                                        onclick="javascript:return enabledisable(this.id)" GroupName="radio5" />
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td align="center">
                                                    <asp:Button ID="BtnRun" CssClass="btntext" runat="server"></asp:Button>
                                                    <asp:Button ID="btnclear" CssClass="btntext" runat="server"></asp:Button>
                                                </td>
                                            </tr>
                                        </table>
                                </tr>
                            </table>
                        </td>
                        <!---------middle end--------->
                    </tr>
                </table>
                <input id="hiddendateformat" type="hidden" runat="server" />
            </td>
            <td>
                <input id="hiddencompcode" type="hidden" runat="server" />
            </td>
            <td>
                <input id="hdnuserid" type="hidden" runat="server" />
            </td>
            <input id="hdnagency1" name="hdnagency1" runat="server" type="hidden" />
            <input id="hdnagencytxt" name="hdnagencytxt" runat="server" type="hidden" />
        </tr>
    </table>
    </form>
</body>
</html>
