<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="datewise_billing_report.aspx.cs"
    Inherits="datewise_billing_report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Date Wise Billing Report</title>
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

    <script type="text/javascript" language="javascript" src="javascript/datewise_billing_report.js"></script>

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

    <script language="javascript" type="text/javascript">
		function forfocus()
		{
		document.getElementById('Txtusernme').focus();
		}
		function maximize()
        {
        window.moveTo(0,0)            
        window.resizeTo(screen.availWidth, screen.availHeight)
         }
        maximize();
    </script>

</head>
<body onkeydown="javascript:return tabvaluedatewise(event);" onkeypress="eventcalling(event);"
    onload="document.getElementById('dpdadtype').focus();">
    <form id="report1" runat="server">
    <table width="1005" border="0" cellspacing="0" cellpadding="0" align="center" style="width: 1005px;
        height: 358px">
        <tr>
            <td width="100%" bordercolor="#1">
                <img src="images/img_02A.jpg" width="1004" border="0" />
                <%-- <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>--%>
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
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lbadtype" runat="server" CssClass="TextField"></asp:Label>
                                                </td>
                                                <td style="height: 25px" align="left">
                                                    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                <ContentTemplate>--%>
                                                    <asp:DropDownList CssClass="dropdown" ID="dpdadtype" runat="server">
                                                    </asp:DropDownList>
                                                    <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lbadcatgory" runat="server" CssClass="TextField"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server" >
                                                                <ContentTemplate>--%>
                                                    <asp:ListBox ID="dpadcatgory" runat="server" CssClass="btext1" Height="66px" SelectionMode="Multiple"
                                                        Width="144px">
                                                        <asp:ListItem>--Select Ad Cat--</asp:ListItem>
                                                    </asp:ListBox>
                                                    <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                </td>
                                            </tr>
                                            <%-- ************************************ --%>
                                            <tr style="display: none">
                                                <td align="left">
                                                    <asp:Label ID="lbsubcat" runat="server" CssClass="TextField"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:ListBox ID="drpsubcat" runat="server" CssClass="btext1" Height="66px" SelectionMode="Multiple"
                                                        Width="144px">
                                                        <asp:ListItem>--Select AdSubCat--</asp:ListItem>
                                                    </asp:ListBox>
                                                </td>
                                            </tr>
                                            <%-- ************************************--%>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lbDateFrom" runat="server" CssClass="TextField"></asp:Label>
                                                </td>
                                                <td style="height: 25px" align="left">
                                                    <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                <ContentTemplate>--%>
                                                    <asp:TextBox ID="txtfrmdate" runat="server" CssClass="btext1"></asp:TextBox>
                                                    <img src='Images/cal1.gif' onclick='popUpCalendar(this, report1.txtfrmdate, "mm/dd/yyyy")'
                                                        onfocus="abc();" height="14" width="14" />
                                                    <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lbToDate" runat="server" CssClass="TextField"></asp:Label>
                                                </td>
                                                <td style="height: 25px" align="left">
                                                    <%-- <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                <ContentTemplate>--%>
                                                    <asp:TextBox ID="txttodate1" runat="server" CssClass="btext1"></asp:TextBox>
                                                    <img src='Images/cal1.gif' onclick='popUpCalendar(this, report1.txttodate1, "mm/dd/yyyy")'
                                                        onfocus="abc();" height="14" width="14" />
                                                    <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
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
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lbPublicationCenter" runat="server" CssClass="TextField"></asp:Label>
                                                </td>
                                                <td style="height: 25px" align="left">
                                                    <asp:DropDownList ID="dppubcent" runat="server" CssClass="dropdown">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lbl_branch" runat="server" CssClass="TextField"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <%--<asp:UpdatePanel ID="UpdatePanel13" runat="server" >
                                                                <ContentTemplate>--%>
                                                    <asp:DropDownList ID="dpd_branch" runat="server" CssClass="dropdown">
                                                    </asp:DropDownList>
                                                    <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lbl_printcent" runat="server" CssClass="TextField"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <%--<asp:UpdatePanel ID="UpdatePanel13" runat="server" >
                                                                <ContentTemplate>--%>
                                                    <asp:DropDownList ID="dpd_printcent" runat="server" CssClass="dropdown">
                                                    </asp:DropDownList>
                                                    <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lbl_report" runat="server" CssClass="TextField"></asp:Label>
                                                </td>
                                                <td style="height: 25px" align="left">
                                                    <%--<asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                <ContentTemplate>--%>
                                                    <asp:DropDownList ID="dpd_report" runat="server" CssClass="dropdown" type="password">
                                                    </asp:DropDownList>
                                                    <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lbdestination" runat="server" CssClass="TextField"></asp:Label>
                                                </td>
                                                <td style="height: 25px" align="left">
                                                    <%--<asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                <ContentTemplate>--%>
                                                    <asp:DropDownList ID="Txtdest" runat="server" CssClass="dropdown" type="password">
                                                    </asp:DropDownList>
                                                    <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                </td>
                                            </tr>
                                            <%--<tr><td align="center" id="fg" colspan="2" style="display:none;">
                                                         
                                                        
                                                       
                                                                    <asp:RadioButton id="exe" runat="server"  Checked="true" Text="Excel"></asp:RadioButton>
                                                                    <asp:RadioButton id="csv" runat="server"  Text="CSV"></asp:RadioButton>
                                                                    
                                                         
                                                              
                                                        </td></tr>--%>
                                            <td align="left">
                                            </td>
                                        </table>
                                        <table>
                                            <tr>
                                                <td align="center">
                                                    <%-- <asp:UpdatePanel ID="UpdatePanel8" runat="server">OnClick="BtnRun_Click"
                                                                <ContentTemplate>--%>
                                                    <asp:Button ID="BtnRun" CssClass="btntext" runat="server"></asp:Button>
                                                    <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="width: 223px">
                                            <tr>
                                                <td style="height: 116px">
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
                <input id="hiddendateformat1" type="hidden" runat="server" />
            </td>
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
    <input id="hiddeneditionname" type="hidden" name="hiddeneditionname" runat="server" />
    </form>
</body>
</html>
