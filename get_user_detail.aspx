<%@ Page Language="C#" AutoEventWireup="true" CodeFile="get_user_detail.aspx.cs" Inherits="get_user_detail" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/main.css" type="text/css" rel="stylesheet" />
    <link href="css/booking.css" type="text/css" rel="stylesheet" />
    <link href="css/report.css" type="text/css" rel="stylesheet" />

    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <script type="text/javascript" language="javascript" src="javascript/datevalidation.js"></script>
    <script type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>
    <script type="text/javascript" language="javascript" src="javascript/get_user_detail.js"></script>
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
    <form id="form2" runat="server">
        <div id="divuser" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:ListBox ID="lstuser" Width="200px" Height="75px" runat="server" CssClass="btextlist"></asp:ListBox></td>
                </tr>
            </table>
        </div>
        <div id="div1" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:ListBox ID="lstmodule" Width="200px" Height="75px" runat="server" CssClass="btextlist"></asp:ListBox></td>
                </tr>
            </table>
        </div>
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
                                                            <asp:Label ID="lblmodule" runat="server" CssClass="TextField"></asp:Label></td>
                                                        <td style="HEIGHT: 25px" align="left">

                                                            <asp:TextBox ID="txtmodule" runat="server" CssClass="btext1"></asp:TextBox>

                                                        </td>

                                                    </tr>
                                                  <%--  <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblstatus" runat="server" CssClass="TextField"></asp:Label></td>
                                                        <td style="HEIGHT: auto" align="left">

                                                            <asp:DropDownList ID="dpdtatus" runat="server" CssClass="btext1"></asp:DropDownList>


                                                        </td>--%>
                                                     <tr>
                                                        <td align="left" class="auto-style1">
                                                            <asp:Label ID="lblstatus" runat="server" CssClass="TextField"></asp:Label></td>
                                                        <td align="left" class="auto-style1">

                                                            <asp:DropDownList CssClass="dropdown" ID="dpdtatus" runat="server"></asp:DropDownList>

                                                        </td>
                                                    </tr>

                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lbluserid" runat="server" CssClass="TextField"></asp:Label></td>
                                                        <td style="HEIGHT: 25px" align="left">

                                                            <asp:TextBox ID="txtuserid" runat="server" CssClass="btext1"></asp:TextBox>

                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblcreationdtfrom" runat="server" CssClass="TextField"></asp:Label></td>
                                                        <td style="HEIGHT: 25px" align="left">

                                                             <asp:TextBox id="txtfrmdate" runat="server" CssClass="btext1" ></asp:TextBox>
                                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form2.txtfrmdate, "dd/mm/yyyy")' onfocus="abc();" height=14 width=14/>

<%--                                                            <asp:TextBox ID="txtfrmdate" runat="server" CssClass="btext1"></asp:TextBox>
                                                            <img src='Images/cal1.gif' onclick='popUpCalendar(this, form2.txtfrmdate, "mm/dd/yyyy")' onfocus="abc();" height="14" width="14" />--%>

                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblcreationtodt" runat="server" CssClass="TextField"></asp:Label></td>
                                                        <td style="HEIGHT: 25px" align="left">

                                                            <asp:TextBox ID="txtcreationtodt" runat="server" CssClass="btext1"></asp:TextBox>
                                                            <img src='Images/cal1.gif' onclick='popUpCalendar(this, form2.txtcreationtodt, "dd/mm/yyyy")' onfocus="abc();" height="14" width="14" />
                                                    </tr>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lbllastuseddtform" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td style="HEIGHT: 25px" align="left">

                                                <asp:TextBox ID="txtuseddtfrom" runat="server" CssClass="btext1"></asp:TextBox>
                                                <img src='Images/cal1.gif' onclick='popUpCalendar(this, form2.txtuseddtfrom, "mm/dd/yyyy")' onfocus="abc();" height="14" width="14" />

                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lbllastusedtodt" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td style="HEIGHT: 25px" align="left">

                                                <asp:TextBox ID="txtusedtodt" runat="server" CssClass="btext1"></asp:TextBox>
                                                <img src='Images/cal1.gif' onclick='popUpCalendar(this, form2.txtusedtodt, "mm/dd/yyyy")' onfocus="abc();" height="14" width="14" />
                                        </tr>
                                </td>
                                <tr>
                                                        <td align="left" class="auto-style1">
                                                            <asp:Label ID="lbldestination" runat="server" CssClass="TextField"></asp:Label></td>
                                                        <td align="left" class="auto-style1">

                                                            <asp:DropDownList CssClass="dropdown" ID="dpdest" runat="server"></asp:DropDownList>

                                                        </td>
                                                    </tr>
                                
                        </table>
                        <table>
                            <tr>
                                <td align="center">


                                    <asp:Button ID="btnsummary" Width="80px" runat="server"></asp:Button>

                                    <asp:Button ID="btnclear" Width="80px" runat="server"></asp:Button>


                                    <asp:Button ID="btnexit" Width="80px" runat="server"></asp:Button>




                                </td>
                            </tr>
                        </table>
                        <input id="hiddencompcode" type="hidden" name="hiddencompcode" runat="server" />
                        <input id="hiddenuserid" type="hidden" name="hiddenuserid" runat="server" />
                        <input id="hiddenuser" type="hidden" size="1" name="hiddenuser" runat="server" />
                        <input id="hiddenmodulename" type="hidden" size="1" name="hiddenmodulename" runat="server" />
                        <input id="hiddendateformat" type="hidden" size="1" name="Hidden2" runat="server"/>
                        <input id="hiddenusername" type="hidden" size="1" name="Hidden1" runat="server" />
                        <input id="hiddenRoleId" type="hidden" size="1" name="hiddenmoduleno" runat="server" />
                        <input id="hiddendivision" type="hidden" size="1" name="hiddendivision" runat="server" />
                         <input id="hdnuserid" type="hidden" size="1" name="hiddendivision" runat="server" />
                          <input id="hdnmoduleid" type="hidden" size="1" name="hiddendivision" runat="server" />
            </table>
        </div>
    </form>
</body>
</html>
