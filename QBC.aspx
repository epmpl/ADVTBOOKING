<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="QBC.aspx.cs"
    Inherits="QBC" %>

<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx" %>
<%@ Register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>QBC</title>
    <script type="text/javascript" src="javascript/jquery.min.js"></script>
    <script language="javascript" src="javascript/givepermission.js" type="text/javascript"></script>
    <script language="javascript" src="javascript/popupcalender_cl.js" type="text/javascript"></script>
    <script language="javascript" src="javascript/datevalidation.js" type="text/javascript"></script>
    <script language="javascript" src="javascript/datechkforcurrdate.js" type="text/javascript"></script>
    <script language="javascript" src="javascript/Validations.js" type="text/javascript"></script>
    <script language="javascript" src="javascript/QBC.js" type="text/javascript"></script>
    <script language="javascript" src="javascript/entertotabqbc.js" type="text/javascript"></script>
    <script language="javascript" src="javascript/datevalidationforbook.js" type="text/javascript"></script>
    <script language="javascript" src="javascript/jquery-1.5.js" type="text/javascript"></script>
    <link href="css/booking.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript">



        function rateenter(evt) {
            //alert(event.keyCode);
            var charCode = (evt.which) ? evt.which : event.keyCode
            if ((event.keyCode >= 46 && event.keyCode <= 57) || (event.keyCode >= 96 && event.keyCode <= 105) || (event.keyCode == 111) || (event.keyCode == 127) || (event.keyCode == 190) || (event.keyCode == 8) || (event.keyCode == 9) || (event.keyCode == 13)) {
                return true;
            }
            else {
                return false;
            }
        }
        clientfromconfig = '<%=ConfigurationManager.AppSettings["CLIENTNAME"].ToString()%>'
        agnf2 = '<%=ConfigurationManager.AppSettings["agencyf2"].ToString()%>'
        chkforalert = '<%=ConfigurationManager.AppSettings["insertionchk"].ToString()%>';
        hdnsmsflag = '<%=ConfigurationManager.AppSettings["QBCSMS"].ToString()%>';
        hdnmailflag = '<%=ConfigurationManager.AppSettings["QBCMAIL"].ToString()%>';
        clientf2 = '<%=ConfigurationManager.AppSettings["clientf2"].ToString()%>';
        roundoff = '<%=ConfigurationManager.AppSettings["roundoff_Transaction"].ToString()%>'
        ALLOWBOOKINGGST = '<%=ConfigurationManager.AppSettings["ALLOWBOOKINGGST"].ToString()%>'
    </script>
</head>
<body onload="document.getElementById('btnNew').focus();document.getElementById('chkage').disabled=true;document.getElementById('chkad').disabled=true;document.getElementById('chkclie').disabled=true;document.getElementById('chkhindu').disabled=true;document.getElementById('chkhindi').disabled=true;document.getElementById('chkattach').disabled=true;document.getElementById('chkall').disabled=true;javascript:return givebuttonpermission('QBC');"
    onkeydown="javascript:return tabvalue(event);" onkeypress="eventcalling(event);"
    onclick="documentClick(event);" style="background-color: #f3f6fd; margin: 0px 0px 0px 0px;">
    <form id="Form1" runat="server" method="post" autocomplete="off">
    <div>
       
        <div id="divagencymain" style="position: absolute; top: 0px; left: 0px; border: none;
            background-color: White; display: none; z-index: 1;" runat="server">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:ListBox ID="lstagencymain" Width="254px" Height="65px" runat="server" CssClass="btextlist">
                        </asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divcopyinsertion" style="border: 2px solid rgb(0, 0, 0); position: absolute;
            top: 0px; left: 0px; display: none; z-index: 1;">
        </div>
        <div id="div1" style="position: absolute; top: 0px; left: 0px; border: none; display: none;
            z-index: 0;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:ListBox ID="lstagency" Width="254px" Height="35px" runat="server" CssClass="btextlist">
                        </asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divclient" style="position: absolute; top: 0px; left: 0px; border: none;
            background-color: White; display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:ListBox ID="lstclient" Width="254px" Height="65px" runat="server" CssClass="btextlist">
                        </asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divdeal" style="position: absolute; top: 0px; left: 0px; border: none; display: none;
            z-index: +999;">
        </div>
        <div id="divpkg" style="position: absolute; top: 0px; left: 0px; height: 90px; width: 200px;
            border: 1; display: none; background-color: White; z-index: 1;">
        </div>
        <table id="OuterTable" cellspacing="0" cellpadding="0" width="1000" align="LEFT"
            border="0">
            <tr valign="top">
                <td colspan="2">
                    <uc1:Topbar ID="Topbar1" runat="server" Text=""></uc1:Topbar>
                </td>
                <td style="width: 9px">
                </td>
            </tr>
            <tr valign="top">
                <td valign="top" id="sectd">
                    <table class="RightTable" id="RightTable" border="0">
                        <tr valign="top">
                            <td>
                                <asp:ImageButton ID="btnNew" runat="server" Font-Size="XX-Small" BackColor="Control"
                                    BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton
                                        AccessKey="s" ID="btnSave" runat="server" Font-Size="XX-Small" BackColor="Control"
                                        BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" 
                                    onclick="btnSave_Click1"></asp:ImageButton><asp:ImageButton
                                            AccessKey="s" ID="btnSaveConfirm" Style="display: none" runat="server" Font-Size="XX-Small"
                                            BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"
                                            TabIndex="63"></asp:ImageButton><asp:ImageButton ID="btnModify" runat="server" Font-Size="XX-Small"
                                                BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"
                                                TabIndex="64"></asp:ImageButton><asp:ImageButton ID="btnQuery" runat="server" Font-Size="XX-Small"
                                                    BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"
                                                    TabIndex="65"></asp:ImageButton><asp:ImageButton ID="btnExecute" runat="server" Font-Size="XX-Small"
                                                        BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"
                                                        TabIndex="66"></asp:ImageButton><asp:ImageButton ID="btnCancel" runat="server" Font-Size="XX-Small"
                                                            BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"
                                                            TabIndex="67"></asp:ImageButton><asp:ImageButton ID="btnfirst" runat="server" Font-Size="XX-Small"
                                                                BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"
                                                                TabIndex="68"></asp:ImageButton><asp:ImageButton ID="btnprevious" runat="server"
                                                                    Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray"
                                                                    Font-Bold="True" TabIndex="69"></asp:ImageButton><asp:ImageButton ID="btnnext" runat="server"
                                                                        Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray"
                                                                        Font-Bold="True" TabIndex="70"></asp:ImageButton><asp:ImageButton ID="btnlast" runat="server"
                                                                            Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray"
                                                                            Font-Bold="True" TabIndex="71"></asp:ImageButton><asp:ImageButton ID="btnDelete"
                                                                                runat="server" Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset"
                                                                                BorderColor="DarkGray" Font-Bold="True" TabIndex="72">
                                </asp:ImageButton><asp:ImageButton ID="btnExit" runat="server" Font-Size="XX-Small"
                                    BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"
                                    TabIndex="73"></asp:ImageButton>
                            </td>
                        </tr>
                        <tr>
                            <td id="tbl3" style="width: 942px">
                            </td>
                        </tr>
                        <tr>
                            <td id="tbl1" style="width: 942px">
                                <table border="1">
                                    <tr>
                                        <td>
                                            <table align="left" cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                    <td colspan="1">
                                                    </td>
                                                    <td colspan="2" id="tbl2">
                                                        <asp:Label ID="lbclntheading" runat="server" Style="width: 20%;" CssClass="TextFieldHeading"
                                                            Text="Customer Details"></asp:Label>&nbsp;&nbsp;-
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblbooking" runat="server" Style="font-size: 11px; display: none;
                                                            width: 20%;"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:Label ID="lbclient" runat="server" CssClass="TextField" Text="Client"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top" id="tdclient">
                                                        <asp:TextBox ID="txtclient" runat="server" CssClass="btextforbook" Enabled="False"
                                                            MaxLength="50" ToolTip="For further options press F2" TabIndex="2"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 10px">
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbbranch" runat="server" CssClass="TextField" Text="Branch"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="txtbranch" runat="server" CssClass="dropdownforbook" BackColor="lightGray"
                                                            TabIndex="61">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="padding: 10px">
                                                    </td>
                                                    <td style="padding-left: 5px">
                                                        <asp:Label ID="lbdatetime" runat="server" CssClass="TextField" Text="Date/Time"></asp:Label>
                                                        <!-- Remove Booked By Label -->
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtdatetime" TabIndex="76" runat="server" CssClass="btextforbookqbc"
                                                            BackColor="LightGray" ReadOnly="True" ForeColor="Black">Date/Time</asp:TextBox>
                                                        <!-- Remove Booked By Text Box -->
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbcaddress" runat="server" CssClass="TextField" Text="Address"></asp:Label>
                                                    </td>
                                                    <td style="display: none">
                                                        <asp:Label ID="lbcioid" runat="server" CssClass="TextField" Text="CIO Booking ID"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td rowspan="2">
                                                        <asp:TextBox ID="txtclientadd" runat="server" CssClass="btext1addforqbc" TextMode="MultiLine"
                                                            Enabled="False" MaxLength="500" Height="30px" Width="112" TabIndex="3"></asp:TextBox>
                                                    </td>
                                                    <td style="display: none">
                                                        <asp:TextBox ID="txtciobookid" BackColor="lightGray" runat="server" CssClass="btextforbook"
                                                            ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbbookedby" runat="server" CssClass="TextField" Text="Booked By"></asp:Label>
                                                    </td>
                                                    <td style="display: none">
                                                        <asp:Label ID="lbpreid" runat="server" Text="Prev. BookingID" CssClass="TextField"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtbookedby" TabIndex="74" runat="server" CssClass="btextforbook"
                                                            BackColor="lightGray" ReadOnly="true">Booked By</asp:TextBox>
                                                    </td>
                                                    <td style="display: none">
                                                        <asp:TextBox ID="txtprevbook" BackColor="lightGray" runat="server" CssClass="btextforbook"
                                                            ReadOnly="True">Previous Booking</asp:TextBox>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td style="padding-left: 5px">
                                                        <asp:Label ID="lbagency" runat="server" CssClass="TextField" Text="Agency"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td id="tdagen" valign="top">
                                                        <asp:TextBox Style="color: black" ID="txtagency" TabIndex="1" runat="server" CssClass="btextforbookqbc"
                                                            BackColor="lightGray" ToolTip="For further options press F2" MaxLength="50" onkeyup="javascript:return f2query(event);"
                                                            ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblreceiptno" runat="server" CssClass="TextField" Text="Receipt No"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtreceipt" TabIndex="75" runat="server" CssClass="btextforbook"
                                                            BackColor="LightGray" ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td style="padding-left: 5px" rowspan="2">
                                                        <asp:Label ID="lbboxadd" runat="server" CssClass="TextField"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td rowspan="2">
                                                        <asp:TextBox ID="txtboxadd" TabIndex="50" runat="server" CssClass="btextforbookqbc"
                                                            Height="35px" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="12">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td rowspan="2" colspan="3">
                                                        <asp:CheckBox ID="chkage" Text="same as Agency" runat="server" CssClass="TextField" />
                                                        <asp:CheckBox ID="chkclie" Text="same as Client" runat="server" CssClass="TextField" />
                                                    </td>
                                                    <%--<td></td>
                                        <td>
                                           
<asp:TextBox id="TextBox2" TabIndex="25" runat="server" CssClass="btextforbookqbc" Height="35px" ReadOnly="true" TextMode="MultiLine"></asp:TextBox> 

                                            </td>
                                        <td></td>--%>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbmobileno" runat="server" Text="Mobile No" CssClass="TextField"></asp:Label>
                                                        <!-- Remove Date Time Label -->
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtMobile" TabIndex="4" onkeypress="return notchar2(event);" Enabled="False"
                                                            MaxLength="11" runat="server" CssClass="btextforbook"></asp:TextBox>
                                                        <!-- Remove Date Time Text Box -->
                                                    </td>
                                                    <td style="width: 1px">
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbsapid" runat="server" CssClass="TextField" Text="SAP ID"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtsapid" runat="server" CssClass="btextforbook" BackColor="LightGray"
                                                            MaxLength="16" ReadOnly="True"></asp:TextBox>
                                                        <!-- Remove Client Adddress Text Area -->
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        &nbsp;<!-- Remove ad type Label -->
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        &nbsp;<!-- Remove Ad type drop down -->
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbbillto" runat="server" CssClass="TextField"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="drpbillto_qbc" runat="server" CssClass="dropdownforbook" Enabled="False"
                                                            TabIndex="5">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 1px">
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbrono" runat="server" Enabled="true" CssClass="TextField" Text="RO No."></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtrono" TabIndex="6" runat="server" CssClass="btextforbook" MaxLength="20"
                                                            Enabled="true"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbrodate" runat="server" CssClass="TextField" Enabled="true" Text="RO Date"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtrodate" TabIndex="7" onkeypress="return dateenter(event);" runat="server"
                                                            CssClass="btextforbookqbc" Enabled="false"></asp:TextBox><img id="Img2" onclick='popUpCalendar(this, Form1.txtrodate, "mm/dd/yyyy")'
                                                                height="11" src="Images/cal1.gif" width="14" />
                                                    </td>
                                                    <td>
                                                        &nbsp;<!-- Remove ad type Label -->
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        &nbsp;<!-- Remove Ad type drop down -->
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbaddtlheading" runat="server" CssClass="TextFieldHeading" Text="Ad Details"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:DropDownList ID="drpstate" Enabled="false" runat="server" CssClass="dropdownforbook">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td colspan="4" style="display: none">
                                                        <asp:CheckBox ID="chkhindu" AutoPostBack="false" runat="server" Text="Hindustan Times"
                                                            CssClass="TextField" />
                                                        <asp:CheckBox ID="chkhindi" runat="server" AutoPostBack="false" Text="Hindustan"
                                                            CssClass="TextField" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <!-- Remove Ad Sub Cat4 Dropdown -->
                                                        <asp:Label ID="lbadtype" runat="server" CssClass="TextField" Text="Ad Type"></asp:Label>
                                                    </td>
                                                    <td style="width: 10px">
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="drpadtype" TabIndex="8" runat="server" CssClass="dropdownforbook"
                                                            Enabled="False">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 1px">
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbuom" runat="server" CssClass="TextField" Text="UOM"></asp:Label>
                                                    </td>
                                                    <td style="width: 10px">
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="drpuom" AutoPostBack="false" runat="server" CssClass="dropdownforbook"
                                                            Enabled="False" TabIndex="13">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <!--adtype-->
                                                    <td style="width: 1px">
                                                    </td>
                                                    <td valign="top" colspan="3" rowspan="5">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td valign="top">
                                                                    <asp:Label ID="lbpackage" runat="server" CssClass="TextField" Text="Package" Width="30px"
                                                                        Height="25px"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:ListBox ID="drppackage" runat="server" CssClass="btextlistqbcnew" Enabled="False"
                                                                        TabIndex="18"></asp:ListBox>
                                                                    <asp:CheckBox ID="chkall" runat="server" AutoPostBack="false" Text="All" CssClass="TextField"
                                                                        OnCheckedChanged="chkall_CheckedChanged" TabIndex="62" />
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td valign="top" style="padding-top: 3px; padding-bottom: 3px">
                                                                    <table width="80%" border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td align="left">
                                                                                <asp:Button ID="btncopy" runat="server" Width="35px" CssClass="buttonsmall" Text="+"
                                                                                    Enabled="False" TabIndex="19" />
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Button ID="btndel" runat="server" CssClass="buttonsmall" Width="35px" Text="-"
                                                                                    Enabled="False"></asp:Button>
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Button ID="get_pacakge_new" runat="server" CssClass="buttonsmall" Width="72px"
                                                                                    Text="Multi Packages" Enabled="False"></asp:Button>
                                                                                <asp:Button ID="btnschme" runat="server" CssClass="buttonsmall" Width="30px" Text="Sch."
                                                                                    Enabled="False"></asp:Button>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top">
                                                                    <asp:Label ID="lbpackagecopy" runat="server" CssClass="TextField" Text="Package Copy"
                                                                        Width="70px" Height="25px"></asp:Label>
                                                                </td>
                                                                <td colspan="2">
                                                                    <asp:ListBox ID="drppackagecopy" runat="server" CssClass="btextlistqbcnew" Enabled="False">
                                                                    </asp:ListBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:Label ID="lbadcat" runat="server" CssClass="TextField" Text="Ad Category"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:DropDownList ID="drpadcategory" runat="server" CssClass="dropdownforbook" AutoPostBack="false"
                                                            TabIndex="9" Enabled="False" onclick="chkfillagency()" OnSelectedIndexChanged="drpadcategory_SelectedIndexChanged"
                                                            ToolTip="For further options Press Alt + Down Arrow">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 1px">
                                                    </td>
                                                    <%--<td colspan="3">
                                        </td>--%>
                                                    <td>
                                                        <asp:Label ID="lblboxcode" runat="server" CssClass="TextField"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="drpboxcodenew" runat="server" CssClass="dropdownforbook" Enabled="False"
                                                            TabIndex="14">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 1px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                    </td>
                                                    <td valign="top">
                                                        <asp:Label ID="lbadsubcategory" runat="server" CssClass="TextField"></asp:Label>
                                                        <!-- Remove Region Label -->
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:DropDownList ID="drpadsubcategory" runat="server" TabIndex="9" CssClass="dropdownforbook"
                                                            Enabled="False" OnSelectedIndexChanged="drpadsubcategory_SelectedIndexChanged"
                                                            ToolTip="For further options Press Alt + Down Arrow">
                                                        </asp:DropDownList>
                                                        <!-- Remove Region Drop Down -->
                                                    </td>
                                                    <td style="width: 1px">
                                                    </td>
                                                    <%--<td valign="top" colspan="3">
                                            </td>--%>
                                                    <td>
                                                        <asp:Label ID="lbbullet" runat="server" CssClass="TextField" Text="Eye Catcher"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:DropDownList ID="drpbullet" runat="server" CssClass="dropdownforbook" Enabled="False"
                                                            TabIndex="15">
                                                        </asp:DropDownList>
                                                        <asp:TextBox ID="txteyecathval" onkeypress="return notchar2(event);" oncopy="javascript:return false;"
                                                            onPASTE="javascript:return false;" runat="server" CssClass="btextsmallqbc" Width="23px"
                                                            ToolTip="Please enter heigth of Eyecatcher" TabIndex="7"></asp:TextBox><br />
                                                    </td>
                                                    <%--<td style="width: 1px">
                                        </td>--%>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                    </td>
                                                    <td valign="top">
                                                        <asp:Label ID="lbadcat3" runat="server" CssClass="TextField"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:DropDownList ID="drpadcat3" runat="server" CssClass="dropdownforbook" Enabled="False"
                                                            ToolTip="For further options Press Alt + Down Arrow" TabIndex="10">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <%--<td align="center" colspan="3">
                                        </td>--%>
                                                    <td>
                                                        <asp:Label ID="lbcolor" runat="server" CssClass="TextField" Text="Color"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="drpcolor" runat="server" CssClass="dropdownforbook" Enabled="False"
                                                            TabIndex="16">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <%--<td valign="top" colspan="5">
                                                            <table border="0" width="100%"><tr><td>
                                                <asp:Label ID="lbbullet" runat="server" CssClass="TextField" Text="Eye Catcher"></asp:Label></td>
                                                             <td valign="top" align="right">
                                                            
                                            </td>
                                                            </tr>
                                                            <tr><td>
                                                            <asp:Label ID="lbmat" runat="server" CssClass="TextField" Text="Material Status"></asp:Label>
                                                            </td>
                                                            <td align="right"> <asp:UpdatePanel ID="UpdatePanel78" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="drpmatstat" runat="server" Width="117px" CssClass="dropdownforbook" Enabled="False"
                                                            >
                                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                                        <asp:ListItem  Value="hardcopy">Hard Copy</asp:ListItem>
                                                        <asp:ListItem  Value="softcopy">Soft Copy</asp:ListItem>
                                                        <asp:ListItem  Value="cd">CD</asp:ListItem>
                                                        <asp:ListItem  Value="other">Others</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel></td>
                                                            </tr>
                                                            </table>
                                                        </td>--%>
                                                    <td style="width: 1px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:Label ID="lbadcat4" runat="server" CssClass="TextField" Text=""></asp:Label>
                                                        <!-- Remove Package Label -->
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:DropDownList ID="drpadcat4" runat="server" CssClass="dropdownforbook" Enabled="False"
                                                            ToolTip="For further options Press Alt + Down Arrow" TabIndex="11">
                                                        </asp:DropDownList>
                                                        <!-- Remove Package List Box -->
                                                    </td>
                                                    <%--<td colspan="3">
                                             </td>--%>
                                                    <td style="width: 1px">
                                                    </td>
                                                    <td valign="top">
                                                        <asp:Label ID="lbbgcolor" runat="server" Text="BgColor" CssClass="TextField"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:DropDownList ID="drpbgcolor" runat="server" CssClass="dropdownforbook" Enabled="False"
                                                            TabIndex="17">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 1px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:Label ID="lbadcat5" runat="server" CssClass="TextField"></asp:Label>
                                                        <!-- Remove Color Label -->
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:DropDownList ID="drpadcat5" runat="server" CssClass="dropdownforbook" Enabled="False"
                                                            ToolTip="For further options Press Alt + Down Arrow" TabIndex="12">
                                                        </asp:DropDownList>
                                                        <%-- Remove Color Dropdown --%>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbkey" runat="server" Text="Key No." CssClass="TextField"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtkeyno" runat="server" CssClass="btextforbook" Enabled="False"
                                                            MaxLength="50"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbkey0" runat="server" Text="Style" CssClass="TextField"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <!-- <table border="0" width="100%" cellpadding="0" cellspacing="0">
                                                    <tr valign="top">
                                                        <td style="width:30%"></td>
                                                        <td align="right" valign="top" style="width:70%; border-top:dotted 1px black; color:White">-</td>
                                                    </tr>
                                                </table>-->
                                                        <asp:DropDownList ID="drpstyle" Enabled="false" runat="server" CssClass="dropdownforbook"
                                                            onfocus="javascript:return changebackcolor(this);" TabIndex="20">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblcoupantype" runat="server" Text="CPN Type" CssClass="TextField"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="drpcoutype" Enabled="false" runat="server" CssClass="dropdownforbook"
                                                            TabIndex="20">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblcouno" runat="server" Text="CPN No." CssClass="TextField"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtcouno" TabIndex="20" runat="server" CssClass="btextforbookrateqbc"
                                                            Enabled="false"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <%--<td valign="top">
                                                <table border="0" width="100%" cellpadding="0" cellspacing="0">
                                                    <tr valign="top">
                                                        <td style="width:30%"></td>
                                                        <td align="right" valign="top" style="width:70%; border-top:dotted 1px black; color:White">-</td>
                                                    </tr>
                                                </table>
                                            </td>--%>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbpaydetail" runat="server" Text="Payment Details" CssClass="TextFieldHeading"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:Label ID="lbldesign" runat="server" CssClass="TextField" Text="Design Box"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:DropDownList ID="drpdesign" Enabled="false" runat="server" CssClass="dropdownforbook"
                                                            TabIndex="20">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:Label ID="lbllogoprem" runat="server" CssClass="TextField" Text="Logo Premium"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:DropDownList ID="drplogoprem" Enabled="false" runat="server" CssClass="dropdownforbook"
                                                            TabIndex="21">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblpaymenttype" runat="server" CssClass="TextField" Text="Payment Type"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="drppaymenttype" runat="server" CssClass="btextforbookqbc" Style="height: 15px;"
                                                            TabIndex="22" Enabled="false">
                                                        </asp:DropDownList>
                                                        <input cssclass="TextField" type="checkbox" onclick="chequedetail();" id="chequedetailbox"
                                                            disabled="disabled" />
                                                    </td>
                                                    <%--onclick="chequedetail();"--%>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:Label ID="lbselectdate" runat="server" CssClass="TextField" Text="Start With"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top" width="150px">
                                                        <asp:TextBox ID="txtdummydate" runat="server" Enabled="false"  oncopy="javascript:return false;"
                                                            onPASTE="javascript:return false;" CssClass="btextforbook" onkeypress="return dateenter(event);"
                                                            OnTextChanged="txtdummydate_TextChanged" TabIndex="22"></asp:TextBox><img src='Images/cal1.gif'
                                                                id="Img3" onclick='popUpCalendar(this, Form1.txtdummydate, "mm/dd/yyyy")' onfocus="abc()"
                                                                height="11" width="14" />
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:Label ID="lbnoofins" runat="server" CssClass="TextField" Text="No. Of Insertion"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:TextBox ID="txtinsertion" TabIndex="23" onkeypress="return notchar2(event);"
                                                            oncopy="javascript:return false;" onPASTE="javascript:return false;" runat="server"
                                                            CssClass="btextforbook" MaxLength="6" Enabled="False"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 1px">
                                                    </td>
                                                    <td valign="top" style="padding-left: 5px">
                                                        <asp:Label ID="lblcardrate" runat="server" Text="Card Rate" CssClass="TextField"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:TextBox ID="txtcardrate" TabIndex="31" runat="server" CssClass="btextforbookrateqbc"
                                                            MaxLength="500" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:Label ID="lbrepdate" runat="server" CssClass="TextField" Text="Repeating Day"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:TextBox ID="txtrepeatingdate" TabIndex="24" onkeypress="return notchar2(event);"
                                                            Enabled="false"  onkeydown="javascript:return shdulerepdays();" oncopy="javascript:return false;" onPASTE="javascript:return false;" 
                                                            runat="server" CssClass="btextforbook" MaxLength="10" Width="46px"></asp:TextBox>
                                                        <asp:Button ID="btnshdl" runat="server" CssClass="buttonshdul" Text="S" Enabled="false"></asp:Button>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label1" runat="server" CssClass="TextField" Text="Total Area"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:TextBox Style="font-weight: bold; text-align: left" TabIndex="26" ID="txttotalarea"
                                                            onkeypress="return notchar2(event);" runat="server" CssClass="btextforbookright"
                                                            MaxLength="8" ReadOnly="true"></asp:TextBox>
                                                        <asp:Label ID="lbmeasuretotal" runat="server" CssClass="TextFielduom"></asp:Label>
                                                    </td>
                                                    <td style="width: 1px" valign="top">
                                                    </td>
                                                    <td valign="top" style="padding-left: 5px">
                                                        <asp:Label ID="lbboxchrg" runat="server" CssClass="TextField"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtboxchrg" TabIndex="34" runat="server" CssClass="btextforbookrateqbc"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                    </td>
                                                    <td valign="top">
                                                        <!-- Temp Receipt Date Label -->
                                                        <asp:Label ID="lblreceiptdate" runat="server" CssClass="TextField" Text="Receipt Date"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <!-- Temp Receipt Date Text Box -->
                                                        <asp:TextBox ID="txtreceiptdate" TabIndex="19" onkeypress="return notchar2(event);"
                                                            oncopy="javascript:return false;" onpaste="javascript:return false;" runat="server"
                                                            CssClass="btextforbook" MaxLength="10" Enabled="False"></asp:TextBox><img id="Img5"
                                                                onclick='popUpCalendar(this, Form1.txtreceiptdate, "mm/dd/yyyy")' height="11"
                                                                src="Images/cal1.gif" width="14" />
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:Label ID="lbcolumn" runat="server" Text="No. of Columns" CssClass="TextField"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:TextBox ID="txtcolum" onkeypress="return notchar2(event);" oncopy="javascript:return false;"
                                                            onpaste="javascript:return false;" runat="server" CssClass="btextforbookright"
                                                            MaxLength="4" Enabled="False"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 1px">
                                                    </td>
                                                    <td valign="top" style="border-left: dotted 1px black; padding-left: 5px">
                                                        <asp:Label ID="lbpaid" runat="server" CssClass="TextField" Text="Paid Ins."></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:TextBox ID="txtpaid" TabIndex="37" onkeypress="return notchar2(event);" runat="server"
                                                            CssClass="btextforbookrateqbc" MaxLength="10" ReadOnly="true" AutoPostBack="True"
                                                            OnTextChanged="txtinsertion_TextChanged1"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:Label ID="lbmat" runat="server" CssClass="TextField" Text="Material Status"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:DropDownList ID="drpmatstat" TabIndex="21" runat="server" CssClass="dropdownforbook"
                                                            Width="117px" Enabled="False">
                                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                                            <asp:ListItem Value="hardcopy">Hard Copy</asp:ListItem>
                                                            <asp:ListItem Value="softcopy">Soft Copy</asp:ListItem>
                                                            <asp:ListItem Value="cd">CD</asp:ListItem>
                                                            <asp:ListItem Value="other">Others</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:Label ID="lbadsize" runat="server" CssClass="TextField" Text="Adv Size"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:Label ID="h" runat="server" CssClass="TextField" Text="H"></asp:Label>
                                                        <asp:TextBox ID="txtadsize1" TabIndex="26" oncopy="javascript:return false;" onpaste="javascript:return false;"
                                                            onkeypress="return rateenter(event);" runat="server" CssClass="btextsmallqbc"
                                                            MaxLength="5" Enabled="False"></asp:TextBox>
                                                        <asp:Label ID="w" runat="server" CssClass="TextField" Text="W"></asp:Label>
                                                        <asp:TextBox ID="txtadsize2" TabIndex="26" onkeypress="return rateenter(event);"
                                                            oncopy="javascript:return false;" onpaste="javascript:return false;" runat="server"
                                                            CssClass="btextsmallqbc" MaxLength="5" Enabled="False"></asp:TextBox>
                                                        <asp:Label ID="lbmeasure" runat="server" CssClass="TextFielduom"></asp:Label>
                                                    </td>
                                                    <td style="width: 1px">
                                                    </td>
                                                    <td valign="top" style="border-left: dotted 1px black; padding-left: 5px">
                                                        <asp:Label ID="lbltotalamt" runat="server" CssClass="TextField" Enabled="true" Text="Gross Amount"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:TextBox ID="txttotalamt" TabIndex="41" runat="server" CssClass="btextforbookgrossqbc"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                    </td>
                                                    <td valign="top">
                                                        <asp:Label ID="lbprintremark" runat="server" Text="Caption" CssClass="TextField"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top" colspan="6">
                                                        <asp:TextBox ID="txtprintremark" TabIndex="26" runat="server" CssClass="btextforbook"
                                                            Style="width: 370px;" MaxLength="500" Enabled="false" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                    <td valign="top" style="border-left: dotted 1px black; padding-left: 5px">
                                                        <asp:Label ID="lbgrossamt" runat="server" Text="Net Amount" CssClass="TextField"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top" style="padding-bottom: 2px;">
                                                        <asp:TextBox ID="txtgrossamt" TabIndex="41" runat="server" CssClass="btextforbookgrossqbc"
                                                            ReadOnly="true"></asp:TextBox>
                                                        <input cssclass="TextField" type="checkbox" onclick="blankGross();" id="chktrade"
                                                            disabled="disabled" /><asp:Label ID="lbltrade" CssClass="TextField" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                    </td>
                                                    <td valign="top">
                                                        <asp:Label ID="lbratecode" runat="server" CssClass="TextField"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:DropDownList ID="drpratecode" TabIndex="27" runat="server" CssClass="dropdownforbook"
                                                            Enabled="False">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="attachment1" runat="server" CssClass="btnlinkImage" ToolTip="Attachment"
                                                            ImageUrl="~/Images/index.jpeg"></asp:ImageButton>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:CheckBox ID="chkcontract" runat="server" CssClass="TextField" Enabled="False"
                                                            Checked="false"></asp:CheckBox>
                                                    </td>                                                    
                                                    <td valign="top" colspan="2">
                                                    <asp:CheckBox ID="chkdistype" runat="server" Checked="true" CssClass="TextField"  Text="E.W.Disc."/>
                                                    </td>
                                                    <td style="width: 1px" valign="top">
                                                    </td>
                                                    <td valign="top" style="border-left: dotted 1px black; border-bottom: dotted 1px black;
                                                        padding-left: 5px">
                                                        <asp:Label ID="lblbalance" runat="server" Text="Agency Balance" CssClass="TextField"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top" style="padding-bottom: 2px">
                                                        <asp:TextBox ID="txtagencybalance" TabIndex="41" runat="server" CssClass="btextforbookgrossqbc"
                                                            ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr style="display: none">
                                                    <%--   <td>
                                                            </td>
                                                            <td valign="top">
                                                            <asp:Label ID="lbrono" runat="server" Enabled="false" CssClass="TextField" Text="RO No."></asp:Label></td><td></td>
                                                        <td valign="top">
                                                           
<asp:TextBox id="txtrono" TabIndex="46" runat="server" CssClass="btextforbook" MaxLength="20" Enabled="False"></asp:TextBox> 

                                                            
                                                        </td>
                                                        <td></td>
                                                        <td valign="top">
                                                            <asp:Label ID="lbrodate" runat="server" CssClass="TextField" Enabled="false" Text="RO Date"></asp:Label></td><td></td>
                                                        <td valign="top">
                                                           
<asp:TextBox id="txtrodate" TabIndex="42" onkeypress="return dateenter(event);" runat="server" CssClass="btextforbook" Enabled="False"></asp:TextBox><IMG id="Img2" onclick='popUpCalendar(this, Form1.txtrodate, "mm/dd/yyyy")' height=11 src="Images/cal1.gif" width=14 />

                                                        </td>
                                                        <td style="width: 1px" valign="top">
                                                        </td>--%>
                                                    <td valign="top">
                                                        <asp:Label ID="lblpaymentstatus" runat="server" CssClass="TextField" Text="Payment Status"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:DropDownList ID="drppaymentstatus" TabIndex="44" runat="server" CssClass="dropdownforbook"
                                                            Enabled="False">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td valign="top" style="display: none">
                                                        <asp:DropDownList ID="drpagscode" TabIndex="44" runat="server" CssClass="dropdownforbook"
                                                            Enabled="False">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr style="display: none">
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:Label ID="lbboxcode" runat="server" Enabled="false" CssClass="TextField" Text="Region"></asp:Label><!-- Remove Box Code Label -->
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:DropDownList ID="drpregion" TabIndex="47" runat="server" CssClass="dropdownforbook"
                                                            Enabled="False" OnSelectedIndexChanged="drpboxcode_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:Label ID="lblboxno" Enabled="false" runat="server" CssClass="TextField" Text="Box No."></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:TextBox ID="txtboxnonew" TabIndex="48" runat="server" CssClass="btextforbook"
                                                            MaxLength="10" Enabled="False"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 1px">
                                                    </td>
                                                    <td valign="top">
                                                        &nbsp;<asp:Label ID="lbrostatus" runat="server" Enabled="false" CssClass="TextField"
                                                            Text="Ro Status"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:DropDownList ID="drprostatus" TabIndex="45" runat="server" CssClass="dropdownforbook"
                                                            Enabled="False">
                                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                                            <asp:ListItem Value="1">Booked</asp:ListItem>
                                                            <asp:ListItem Value="2">Unconfirmed</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <!-- Remove Box Address Text Box -->
                                                    </td>
                                                </tr>
                                                <tr style="display: none">
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <!-- Temp Color Type Label -->
                                                        <asp:Label ID="lbcolortype" Enabled="false" runat="server" CssClass="TextField"></asp:Label>
                                                        <!-- Remove Box Charge Label -->
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <!-- Temp Color Type Dropdown -->
                                                        <asp:DropDownList ID="drpcolortype" TabIndex="50" runat="server" CssClass="dropdownforbook"
                                                            Enabled="false">
                                                        </asp:DropDownList>
                                                        <!-- Remove Box Charge Text Box -->
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top" style="display: none">
                                                        <!-- Temp Contract Type Label -->
                                                        <asp:Label ID="lbcontractname" Enabled="false" runat="server" CssClass="TextField"
                                                            Text="Contract Name"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top" style="display: none">
                                                        <!-- Temp Contract Type Text Box -->
                                                        <asp:TextBox ID="txtcontractname" TabIndex="51" onkeypress="return notchar2(event);"
                                                            runat="server" CssClass="btextforbook" MaxLength="10" Enabled="False" OnTextChanged="txtinsertion_TextChanged1"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 1px">
                                                    </td>
                                                    <td valign="top">
                                                        <asp:Label ID="lbpagepost" Style="display: none" runat="server" Enabled="false" CssClass="TextField"
                                                            Text="Page Position"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <!-- Temp Page Position Dropdown -->
                                                        <asp:DropDownList ID="drppageposition" TabIndex="43" Style="display: none" runat="server"
                                                            CssClass="dropdownforbook" Enabled="False">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <div id="trbtnlogo" style="display: none;">
                                                            <asp:Button ID="btnlogo" runat="server" CssClass="buttonsmall" Enabled="False" />
                                                        </div>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td style="width: 1px">
                                                    </td>
                                                    <td style="display: none">
                                                        <asp:Label ID="lbcontracttype" Enabled="false" runat="server" CssClass="TextField"
                                                            Text="Contract Rate"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top" style="display: none">
                                                        <asp:TextBox ID="txtdealrate" TabIndex="52" onkeypress="return notchar2(event);"
                                                            runat="server" CssClass="btextforbook" MaxLength="10" Enabled="False" AutoPostBack="True"
                                                            OnTextChanged="txtinsertion_TextChanged1"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <div id="trlogouoload" style="display: none;">
                                                            <asp:Label ID="lblogosize" runat="server" CssClass="TextField"></asp:Label>
                                                        </div>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <div id="trlogouoload1" style="display: none;">
                                                            <asp:Label ID="logoh" runat="server" CssClass="TextField"></asp:Label>
                                                            <asp:TextBox ID="txtlogohei" TabIndex="53" onkeypress="return rateenter(event);"
                                                                runat="server" CssClass="btextsmallqbc" MaxLength="5" Enabled="False"></asp:TextBox>
                                                            <asp:Label ID="logow" runat="server" CssClass="TextField"></asp:Label>
                                                            <asp:TextBox ID="txtlogowid" onkeypress="return rateenter(event);" runat="server"
                                                                CssClass="btextsmallqbc" MaxLength="5" Enabled="False"></asp:TextBox>&nbsp;
                                                        </div>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <div id="trlogouoload2" style="display: none;">
                                                            <asp:Label ID="lbcolorlogo" runat="server" CssClass="TextField"></asp:Label>
                                                        </div>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <div id="trlogouoload3" style="display: none;">
                                                            <asp:DropDownList ID="drplogocolor" TabIndex="54" runat="server" CssClass="dropdownforbook"
                                                                Enabled="False">
                                                                <asp:ListItem Selected="True" Value="0">Select Logo Color</asp:ListItem>
                                                                <asp:ListItem Value="B">B</asp:ListItem>
                                                                <asp:ListItem Value="C">C</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                    <td style="width: 1px">
                                                    </td>
                                                    <td>
                                                        <div id="trlogouoload4" style="display: none;">
                                                            <asp:Button ID="btnlogoupload" runat="server" CssClass="buttonsmall" Enabled="False" />
                                                        </div>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top">
                                                        <div id="trlogouoload5" style="display: none;">
                                                            <asp:TextBox ID="txtlogoname" TabIndex="55" onkeypress="return notchar2(event);"
                                                                runat="server" CssClass="btextforbook" MaxLength="10" Enabled="False" AutoPostBack="True"
                                                                OnTextChanged="txtinsertion_TextChanged1"></asp:TextBox>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <div id="trlogouom" style="display: none;">
                                                            <asp:Label ID="lblogouom" runat="server" CssClass="TextField"></asp:Label>
                                                        </div>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <div id="trlogouom1" style="display: none;">
                                                            <asp:TextBox ID="txtlogouomcode" TabIndex="56" onkeypress="return notchar2(event);"
                                                                runat="server" CssClass="btextforbook" MaxLength="10" Enabled="False" AutoPostBack="True"
                                                                OnTextChanged="txtinsertion_TextChanged1"></asp:TextBox>
                                                        </div>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top" style="display: none">
                                                        <!-- Temp Contract Name Label -->
                                                        <asp:Label ID="Label2" runat="server" CssClass="TextField" Text="Attachment"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top" style="display: none">
                                                        <!-- Temp Contract Name Text Box -->
                                                        <asp:CheckBox ID="chkattach" runat="server" Checked="true" CssClass="TextField" />
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top" style="display: none">
                                                        <!-- Temp Variable Label -->
                                                        <asp:Label ID="lbboxno" Enabled="false" runat="server" CssClass="TextField" Text="Variable"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td valign="top" style="display: none">
                                                        <!-- Temp Box No. Text Box -->
                                                        <asp:DropDownList ID="drpvarient" Enabled="false" runat="server" CssClass="dropdownforbook">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblscheme" runat="server" CssClass="TextField" Text="Scheme"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <!-- Temp RO Status Label-->
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtscheme" TabIndex="51" runat="server" CssClass="btextforbook"
                                                            Enabled="False"></asp:TextBox>
                                                    </td>
                                                    <td colspan="9" align="right">
                                                        <div style="display: none;">
                                                            <asp:Button ID="btnsharing" runat="server" CssClass="buttonsmall" Text="Sharing"
                                                                Enabled="False" />
                                                        </div>
                                                        <asp:Button ID="btnshgrid" TabIndex="26" runat="server" CssClass="buttonsmall" Text="Get Rate"
                                                            Enabled="False"></asp:Button>
                                                        <asp:Button ID="btnsavepay" Enabled="false" TabIndex="57" runat="server" CssClass="buttonsmall"
                                                            Text="Save&Pay"></asp:Button>
                                                        <asp:Button ID="btnholding" Enabled="false" TabIndex="57" runat="server" CssClass="buttonsmall"
                                                            Text="Hold&Save"></asp:Button>
                                                        <asp:Button ID="btndiscount" TabIndex="58" runat="server" CssClass="buttonsmall"
                                                            Width="95px" Text="Discount/Premium" Enabled="False"></asp:Button>
                                                        <asp:Button ID="btnfmg" TabIndex="58" runat="server" CssClass="buttonsmall" Width="75px"
                                                            Text="FMG Ref" Enabled="False"></asp:Button><asp:Button ID="btnconfirm" TabIndex="58"
                                                                runat="server" CssClass="buttonsmall" Width="75px" Text="Confirm Ad" Enabled="False">
                                                            </asp:Button>
                                                        <asp:Button ID="lbreceipt" TabIndex="59" runat="server" CssClass="buttonsmall" Width="75px"
                                                            Text="Print Receipt" Enabled="False"></asp:Button>
                                                        <asp:Button ID="btnpaygateway" TabIndex="60" runat="server" CssClass="buttonsmall"
                                                            Width="75px" Text="Payment Gateway" Enabled="False"></asp:Button>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="left" id="tblinsert" runat="server">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <input id="hiddencomcode" type="hidden" size="1" name="hiddencomcode" runat="server" />
                    <input id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server" />
                    <input id="hiddendateformat" type="hidden" size="1" name="Hidden2" runat="server" />
                    <input id="hiddencompcode" type="hidden" size="1" name="hiddencompcode" runat="server" />
                    <input id="hiddenbackdatebook" type="hidden" size="1" name="Hidden2" runat="server" />
                    <input id="hiddenusername" type="hidden" name="username" runat="server" />
                    <input type="hidden" id="hiddenrowcount" runat="server" />
                    <input type="hidden" id="hiddenbulletpremtype" runat="server" />
                    <input id="hiddensubcode" type="hidden" runat="server" />
                    <input id="hiddentfn" type="hidden" runat="server" />
                    <input id="hiddenstatus" type="hidden" runat="server" />
                    <input id="hiddenpay" type="hidden" runat="server" />
                    <input id="hiddenpackage" type="hidden" runat="server" />
                    <input id="hiddensavemod" type="hidden" runat="server" />
                    <input id="hiddenbranch" type="hidden" runat="server" />
                    <input id="hiddencurrency" type="hidden" runat="server" />
                    <input id="hiddenpremtype" type="hidden" runat="server" />
                    <input id="hiddentype" type="hidden" runat="server" />
                    <input id="hiddenbrand" type="hidden" runat="server" />
                    <input id="hiddenzone" type="hidden" runat="server" />
                    <input id="hiddenad_subcat" type="hidden" runat="server" />
                    <input id="hiddenclickdate" type="hidden" size="1" name="hiddencompcode" runat="server" />
                    <input id="hiddeninserts" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddenagency" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddenagencynew" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddencioid" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddenvar" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddenbillto" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddenbillpay" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddenprefix" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddensufix" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddenreceiptno" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddenadscat3" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddenadscat4" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddenadscat5" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddenbgcolor" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddenbullprem" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddenratecode" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddenuom" type="hidden" size="1" name="inserts" runat="server" />&nbsp;&nbsp;
                    <input id="lbbullprem" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddenroperm" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddenroadcat" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddenrodatetime" type="hidden" size="1" name="inserts" runat="server" />
                    <br />
                    <input id="hiddenprevamt" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddenadtype" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddenaudit" type="hidden" size="1" name="inserts" runat="server" />
                    <input type="hidden" id="pkgname" />
                    <input type="hidden" id="txtratecode" runat="server" />
                    <input type="hidden" id="hiddenvat" runat="server" />
                    <input type="hidden" id="hiddencirculation" runat="server" />
                    <input type="hidden" id="txtpageamt" runat="server" />
                    <input type="hidden" id="hidval" />
                    <input type="hidden" id="hidcount" />
                    <input type="hidden" id="hiddenboxno" />
                    <input type="hidden" id="hiddeninsertion" runat="server" />
                    <input type="hidden" id="hiddencalendar" runat="server" />
                    <input type="hidden" id="hiddenscheme" runat="server" />
                    <input type="hidden" id="hiddenuom1" runat="server" />
                    <input type="hidden" id="hiddenuploadheight" runat="server" />
                    <input type="hidden" id="hiddenuploadwidth" runat="server" />
                    <input type="hidden" id="hiddencompuser" runat="server" />
                    <input type="hidden" id="hiddenadmin" runat="server" />
                    <input type="hidden" id="drpboxcode" runat="server" />
                    <input type="hidden" id="txtboxno" runat="server" />
                    <input type="hidden" id="hiddentypedatabase" runat="server" />
                    <input type="hidden" id="hiddencopy" runat="server" />
                    <input type="hidden" id="hiddendummycioid" runat="server" />
                    <input type="hidden" id="globalschemedisc" runat="server" />
                    <input type="hidden" id="hiddencatcode" runat="server" />
                    <input type="hidden" id="hiddenuomcode" runat="server" />
                    <input type="hidden" id="hiddenLineCount" runat="server" />
                    <input type="hidden" id="hiddencolortype" runat="server" />
                    <input type="hidden" id="hiddenbullet" runat="server" />
                    <input id="hdnf2" type="hidden" runat="server" />
                    <input type="hidden" id="hiddenuomdesc" runat="server" />
                    <input type="hidden" id="hiddenlogomatter" runat="server" />
                    <input type="hidden" id="hiddenlogocode" runat="server" />
                    <input type="hidden" id="hiddenagencyrate" runat="server" />
                    <input type="hidden" id="hiddenagencycodeforrate" runat="server" />
                    <input type="hidden" id="hiddenuomstylesheet" runat="server" />
                    <input type="hidden" id="hiddenEyeBasedOnEdition" runat="server" />
                    <input type="hidden" id="hiddenregClient" runat="server" />
                    <input type="hidden" id="hiddenClient" runat="server" />
                    <input type="hidden" id="hdnagencyname" runat="server" />
                    <input type="hidden" id="hiddenboxchrgtype" runat="server" />
                    <input type="hidden" id="hiddenboxadd" runat="server" />
                    <input type="hidden" id="hiddenadsearch" runat="server" />
                    <input type="hidden" id="hiddenvaliddate" runat="server" />
                    <input type="hidden" id="hiddeninsertwise" runat="server" />
                    <input type="hidden" id="Hdn_f2" runat="server" />
                    <input type="hidden" id="hidden_client" runat="server" />
                    <input type="hidden" id="hiddencopyrate" runat="server" />
                    <input type="hidden" id="hiddenprint_rec" runat="server" />
                    <input type="hidden" id="hiddenclientname" runat="server" />
                    <input type="hidden" id="hiddenclientaddress" runat="server" />
                    <input type="hidden" id="hiddenreceiptno1" runat="server" />
                    <input type="hidden" id="hiddenbooktype" runat="server" />
                    <input type="hidden" id="hiddenbooktypeOrig" runat="server" />
                    <input type="hidden" id="hiddencardamt" runat="server" />
                    <input type="hidden" id="hiddencardrate" runat="server" />
                    <input type="hidden" id="hiddenboxchrg" runat="server" />
                    <input type="hidden" id="hiddengrossamt" runat="server" />
                    <input type="hidden" id="hiddenpaidins" runat="server" />
                    <input type="hidden" id="hiddentotalarea" runat="server" />
                    <input type="hidden" id="hiddenratecheckdate" runat="server" />
                    <input type="hidden" id="hiddencenter" runat="server" />
                    <input type="hidden" id="hiddenratepremtype" runat="server" />
                    <input type="hidden" id="hiddengross" runat="server" />
                    <input type="hidden" id="hiddenchkf2" runat="server" />
                    <input type="hidden" id="hiddenbuttonidcheck" runat="server" />
                    <input type="hidden" id="hiddenbookstatus" runat="server" />
                    <input type="hidden" id="hiddenreceiptnoformat" runat="server" />
                    <input type="hidden" id="hiddencioidformat" runat="server" />
                    <input type="hidden" id="hiddenagencycodeforsave" runat="server" />
                    <input type="hidden" id="hiddenconfirm_Permission" runat="server" />
                    <input type="hidden" id="hiddenpkgedition" runat="server" />
                    <input type="hidden" id="hiddenschemetype" runat="server" />
                    <input type="hidden" id="tempinsert" runat="server" />
                    <input type="hidden" id="configclient" runat="server" />
                    <input type="hidden" id="hiddengriddata" runat="server" />
                    <input type="hidden" id="hiddenconnect" runat="server" />
                    <input type="hidden" id="hiddencutofftime" runat="server" />
                    <input type="hidden" id="currdate" runat="server" />
                    <input type="hidden" id="hiddenexecname" runat="server" />
                    <input type="hidden" id="hiddenproduct" runat="server" />
                    <input type="hidden" id="hiddendrppageprem" runat="server" />
                    <input type="hidden" id="hiddentxtpremper" runat="server" />
                    <input type="hidden" id="hiddenagreedamt" runat="server" />
                    <input type="hidden" id="hiddenspediscper" runat="server" />
                    <input type="hidden" id="hiddenspedisc" runat="server" />
                    <input type="hidden" id="hiddenretainer" runat="server" />
                    <input type="hidden" id="hiddenretainercomm" runat="server" />
                    <input type="hidden" id="hiddenspecharges" runat="server" />
                    <input type="hidden" id="hiddenqbcadtype" runat="server" />
                    <input type="hidden" id="hiddenagcommflag" runat="server" />
                    <input type="hidden" id="hiddeneyecatchpubwise" runat="server" />
                    <input type="hidden" id="hiddenmaxdays" runat="server" />
                    <input type="hidden" id="hidspldisedit" runat="server" />
                    <input type="hidden" id="hidshareman" runat="server" />
                    <input type="hidden" id="hidmultisel" runat="server" />
                    <input type="hidden" id="hidschememin" runat="server" />
                    <input type="hidden" id="hidagencyname" runat="server" />
                    <input id="oldboxno" type="hidden" runat="server" />
                    <input type="hidden" id="hidattach1" runat="server" />
                    <input id="txtagencyaddress" type="hidden" runat="server" />
                    <input type="hidden" id="hiddenmodifyinsert" runat="server" />
                    <input type="hidden" id="txtcontracttype" runat="server" />
                    <input type="hidden" id="hiddensepcashier" runat="server" />
                    <input type="hidden" id="txtdeviation" runat="server" />
                    <input type="hidden" id="Hiddendrppageposition" runat="server" />
                    <input type="hidden" id="Hiddentxtpageamt" runat="server" />
                    <input type="hidden" id="hideditagency" runat="server" />
                    <input type="hidden" id="hdnlengthcounthold" runat="server" />
                    <input type="hidden" id="hdnbutton" runat="server" />
                    <input type="hidden" id="hdndepo" runat="server" />
                    <input type="hidden" id="hdnprcioid" runat="server" />
                    <input type="hidden" id="hidstyle" runat="server" />
                    <input id="txtclientcatdisc" type="hidden" runat="server" />
                    <input id="txtflatfreqdisc" type="hidden" runat="server" />
                    <input id="txtcatdisc" type="hidden" runat="server" />
                    <input id="txtclientcatam" type="hidden" runat="server" />
                    <input id="txtflatfreqamt" type="hidden" runat="server" />
                    <input id="txtcatamt" type="hidden" runat="server" />
                    <input id="hdnclientcatdistype" type="hidden" runat="server" />
                    <input id="hdnflatfreqdisctype" type="hidden" runat="server" />
                    <input id="hdncatdisctype" type="hidden" runat="server" />
                    <input id="txtcashdiscount" type="hidden" runat="server" />
                    <input id="hiddencashdiscper" type="hidden" runat="server" />
                    <input id="txtagencyoutstand" type="hidden" runat="server" />
                    <%--/////////////////add by anuja for paymenttype--%>
                    <input type="hidden" id="agnlogin" runat="server" />
                    <input type="hidden" id="hdnproofread" runat="server" />
                    <input type="hidden" id="hiddenuserdisc" runat="server" />
                    <input id="hiddenchequeno" type="hidden" size="1" name="hiddencomcode" runat="server" />
                    <input id="hiddenchequedate" type="hidden" size="1" name="Hidden1" runat="server" />
                    <input id="hiddenbankname" type="hidden" size="1" name="Hidden2" runat="server" />
                    <input id="HDN_server_date" type="hidden" size="1" name="Hidden2" runat="server" />
                     <input id="hdnflagdetail" type="hidden" size="1" name="Hidden2" runat="server" />
                     <input id="HDNAGNOUTSTANDING" type="hidden" size="1" name="Hidden2" runat="server" />
                     <input type="hidden" id="hiddenorigbranch" runat="server" />
                     <input type="hidden" id="hdnmodifycateg" runat="server" />
                      <input type="hidden" id="hdnrecnomod" runat="server" />
                       <input type="hidden" id="hdnronomodify" runat="server" />
                    <%-- /////////////////////////////////end    --%>
                </td>
            </tr>
        </table>
    </div>
    <div id="showselectedition" style="z-index: 0; background-color: #e1e1e1; border-right: thin groove;
        border-top: thin groove; border-left: thin groove; border-bottom: thin groove;
        font-size: 8pt; position: absolute; display: none; height: auto; width: 200px;
        top: 200px; left: 400px;">
    </div>
    <div id="dvpackage" style="display: none; background-color: Black;">
    </div>
    <div id="dvmainpackage" style="top: 300px; left: 600px; position: absolute; background-color: white;
        width: 200px; display: none;">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td style="border: solid 1px black;">
                    <div style="overflow: auto; width: 200px; height: 150px; top: 500px; border-left-color: WindowFrame;">
                        <asp:DataGrid runat="server" ID="test_grid" AutoGenerateColumns="false" Width="180px">
                            <Columns>
                                <asp:TemplateColumn>
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="test_chk" onclick="find_package(this.id)" />
                                        <asp:Label runat="server" ID="test_lbl" CssClass="multichk"><%# DataBinder.Eval(Container.DataItem, "Package_Name")%></asp:Label>
                                        <asp:Label Style="display: none" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"pck_code") %>'
                                            ID="pack_id"> </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                            </Columns>
                        </asp:DataGrid>
                    </div>
                </td>
            </tr>
            <tr>
                <td width="10px;">
                </td>
            </tr>
            <tr>
                <td style="border-bottom: solid 1px black; border-right: solid 1px black; border-left: solid 1px black;">
                    <input id="Button1" type="button" runat="server" onclick="submitpack()" value="Submit" />
                    <input id="Button2" type="button" runat="server" onclick="cancelpack()" value="Cancel" />
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>
    <div style="display: none;">
        <asp:CheckBox ID="chkad" runat="server" /><asp:Button ID="btndeal" runat="server"
            CssClass="buttonsmall" Enabled="False" /></div>
    <div id="Divgrid1" style="position: absolute; top: 0px; left: 0px; border: none;
        display: none; z-index: 0; background-color: White; overflow: auto; width: 445px;
        height: 230px" runat="server">
        <table id="Table3" style="width: 435px; height: 180px" align="center">
            <tr>
                <td runat="server" id="view19" padding-left="10px" align="center" valign="top">
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" id="pagingtab" runat="server" width="250px"
            style="display: none; padding-left: 6px;">
            <tr>
                <td id="prepage" colspan="3" runat="server" onclick="javascript:return pageprev(this.value);"
                    class="previousPage1">
                    Previous
                </td>
                <td id="next1" colspan='0' runat="server" class="style4">
                </td>
                <td id="nextpage" class="nextpage" runat="server" width="10px" onclick="javascript:return pagenext(this.value);">
                    Next
                </td>
            </tr>
        </table>
        <asp:Button ID="Button3" runat="server" CssClass="topbutton" Width="40px" Text="Close" />
    </div>
    <%-- <div id="daysdiv" style="border: 2px solid rgb(0, 0, 0) ;position: absolute; top: 0px; left: 0px;
            display: none; z-index: 1;">--%>
    <%--<div id="daysdiv" style="display: none;">
                                    <table id="Table1" style="WIDTH: 435px; HEIGHT: 180px" align="center">
									<tr><td runat="server" id="daysdiv4" padding-left="10px" align="center" valign="top" ></td></tr></table>
                                    </div>--%>
    <div id="daysdiv4" style="z-index: 2; border: 2px solid #a7d2fc; display: none;
        background: white; width: 196px; position: absolute; height: 87px; overflow: hidden;">
        <div runat="server" id="daysdiv" style="width: 171px; height: 98px;margin-left: 12px;overflow: hidden;
            border-bottom: thin solid #a7d2fc; border-top: thin solid #a7d2fc; z-index: 2;"
            xml:lang="en" >
        </div>
    </div>
    </form>
</body>
</html>
