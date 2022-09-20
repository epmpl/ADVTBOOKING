  <%@ Page Language="C#" AutoEventWireup="true" CodeFile="CrditDebit.aspx.cs" Inherits="Reports_CrditDebit"  enableEventValidation="false" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="css/main.css" type="text/css" rel="stylesheet" />
    <link href="css/booking.css" type="text/css" rel="stylesheet" />
    <link href="css/report.css" type="text/css" rel="stylesheet" />

    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <script type="text/javascript" language="javascript" src="javascript/datevalidation.js"></script>
    <script type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>
    <script type="text/javascript" language="javascript" src="javascript/CrditDebit.js"></script>
    <script type="text/javascript" language="javascript" src="javascript/entertotab.js"></script>
    <%--<script type="text/javascript" language="javascript" src="javascript/rept.js"></script>--%>
    <style type="text/css">
        .style1
        {
            FONT-WEIGHT: bold;
            FONT-SIZE: xx-large;
            COLOR: #ffffff;
        }

        .style2
        {
            COLOR: #ffffff;
        }

        .style4
        {
            FONT-WEIGHT: normal;
            FONT-SIZE: 14pt;
            COLOR: #d85414;
            FONT-FAMILY: Verdana;
        }

        .style6
        {
            FONT-SIZE: x-small;
        }

        .style7
        {
            FONT-WEIGHT: bold;
            COLOR: #6666ff;
        }

        .auto-style1
        {
            height: 24px;
        }
        .auto-style2
        {
            width: 212px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="1005" border="0" cellspacing="0" cellpadding="0" align="center" style="WIDTH: 1005px; HEIGHT: 358px">
                <tr>
                    <td width="100%" bordercolor="#1">
                        <img src="images/img_02A.jpg" width="1004" border="0" />
                        <%-- <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>--%>
                    </td>
                </tr>
                <tr>
                    <td id="td2" onclick="javascript:return logoutpage();" width="100%" bordercolor="#1" style="background-image: url('images/top.jpg'); font-family: Trebuchet MS; font-size: 13px; color: #CC0000; cursor: hand;" align="right">Logout</td>
                </tr>
                <tr>
                    <td style="height: 505px">
                        <table width="985" border="0" cellspacing="0" cellpadding="0" style="WIDTH: 985px; HEIGHT: 486px">
                            <tr>
                                <!---------left bar start--------->
                                <td class="auto-style2">
                                    <img src="images/leftbar.jpg" style="WIDTH: 188px; HEIGHT: 483px" height="483" /></td>
                                <!---------left bar end--------->
                                <!---------middle start--------->
                                <td valign="top" style="width: 78%">

                                    <table cellpadding="0" cellspacing="0" width="790" style="WIDTH: 790px; HEIGHT: 488px"
                                        bordercolordark="#000000" border="1">
                                        <tr>
                                            <td align="center">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="heading" runat="server" CssClass="heading"></asp:Label></td>
                                                    </tr>
                                                </table>
                                                <br />

                                                <table width="0" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="FromDate" runat="server" CssClass="TextField"></asp:Label></td>
                                                        <td style="HEIGHT: 25px" align="left">

                                                            <asp:TextBox ID="txtfrmdate" runat="server" CssClass="btext1" Width="118px"></asp:TextBox>
                                                            <img src='Images/cal1.gif' onclick='popUpCalendar(this, form1.txtfrmdate, "mm/dd/yyyy")' onfocus="abc();" height="14" width="14" />

                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="ToDate" runat="server" CssClass="TextField"></asp:Label></td>
                                                        <td style="HEIGHT: 25px" align="left">

                                                            <asp:TextBox ID="txttodate1" runat="server" CssClass="btext1" Width="119px"></asp:TextBox>
                                                            <img src='Images/cal1.gif' onclick='popUpCalendar(this, form1.txttodate1, "mm/dd/yyyy")' onfocus="abc();" height="14" width="14" />

                                                    </tr>
                                                     <tr>
                                                        <td align="left">
                                                            <asp:Label ID="PublicCenter" runat="server" CssClass="TextField"></asp:Label></td>
                                                        <td style="HEIGHT: 25px" align="left">

                                                            <asp:DropDownList ID="txtpublicentr" runat="server" CssClass="btext1" style="HEIGHT: 20px" ></asp:DropDownList>


                                                        </td>
                                                          <td align="left">
                                                            <asp:Label ID="Branch" runat="server" CssClass="TextField"></asp:Label></td>
                                                          <td style="HEIGHT: 25px"  align="left">

                                                            <asp:DropDownList ID="dpbranch" runat="server" CssClass="btext1" style="HEIGHT: 20px" ></asp:DropDownList>


                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="ReportType" runat="server" CssClass="TextField"></asp:Label></td>
                                                        <td align="left" >

                                                            <asp:DropDownList CssClass="dropdown" ID="dprpttype" runat="server"></asp:DropDownList>

                                                        </td>
                                                        <td align="left" >
                                                            <asp:Label ID="Destination" runat="server" CssClass="TextField"></asp:Label></td>
                                                        <td align="left" >

                                                            <asp:DropDownList CssClass="dropdown" ID="dpdestination" runat="server"></asp:DropDownList>

                                                        </td>

                                                    </tr>


                                                    </table>
                                                <table>
                                                    <tr>
                                                        <td align="center">

                                                            <asp:Button ID="BtnRun" Width="80px" runat="server"></asp:Button>




                                                        </td>
                                                    </tr>

                                                </table>
                                                <br />
                                                <table style="width: 223px">
                                                    <tr>
                                                    </tr>
                                                </table>
                                        </tr>
                                    </table>

                                </td>
                                <!---------middle end--------->
                            </tr>
                        </table>
                        <input id="hiddendateformat" type="hidden" runat="server" /></td>
                    <td>
                        <input id="hiddendateformat1" type="hidden" runat="server" /></td>
                </tr>

            </table>
            <input id="hiddenascdesc" type="hidden" runat="server" />
            <input id="hiddencioid" type="hidden" runat="server" />
            <input id="hiddenolddate" type="hidden" name="hiddenolddate" runat="server" />
            <input id="hiddencompcode" type="hidden" name="hiddencompcode" runat="server" />
            <input id="hiddenadcat" type="hidden" name="hiddenadcat" runat="server" />
            <input id="hiddenadsubcat" type="hidden" name="hiddenadsubcat" runat="server" />
            <input id="hiddenadcatname" type="hidden" name="hiddenadcatname" runat="server" />
            <input id="hiddenadsubcatname" type="hidden" name="hiddenadsubcatname" runat="server" />
            <input id="hiddenedition" type="hidden" name="hiddenedition" runat="server" />
            <input id="hdncompname" type="hidden" name="hiddeneditionname" runat="server" />
            <input id="hdnuserid" type="hidden" name="hiddenuom" runat="server" />
        </div>
    </form>
</body>
</html>

