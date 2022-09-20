<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Booking_master.aspx.cs" EnableEventValidation="false"
    Inherits="Booking_master" %>

<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx" %>
<%@ Register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Display Booking</title>

    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
    <meta content="C#" name="CODE_LANGUAGE" />
    <meta content="JavaScript" name="vs_defaultClientScript" />
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
    <style>
        .loader {
            border: 16px solid #f3f3f3;
            border-radius: 50%;
            border-top: 16px solid #3498db;
            width: 50px;
            height: 50px;
            -webkit-animation: spin 2s linear infinite;
            animation: spin 2s linear infinite;
        }

        @-webkit-keyframes spin {
            0% {
                -webkit-transform: rotate(0deg);
            }

            100% {
                -webkit-transform: rotate(360deg);
            }
        }

        @keyframes spin {
            0% {
                transform: rotate(0deg);
            }

            100% {
                transform: rotate(360deg);
            }
        }

        .dtGridHd121 {
            font-family: arial, sans-serif;
            border-collapse: collapse;
            width: 100%;
        }

            .dtGridHd121 td, .dtGridHd121 th {
                border: 1px solid #dddddd;
                text-align: left;
                padding: 5px;
            }

        .auto-style2 {
            width: 75px;
        }

        .auto-style3 {
            width: 65px;
        }

        .auto-style4 {
            width: 55px;
        }

        .auto-style5 {
            width: 68px;
        }

        .auto-style6 {
            width: 83px;
        }

        .auto-style7 {
            width: 70px;
        }

        .auto-style8 {
            width: 198px;
        }

        #OuterTable {
            width: 1085px;
        }

        #Table1 {
            width: 545px;
        }
    </style>

    <script language="javascript" src="javascript/givepermission.js" type="text/javascript"></script>
    <script language="javascript" src="javascript/popupcalender_cl.js" type="text/javascript"></script>
    <script language="javascript" src="javascript/datevalidation.js" type="text/javascript"></script>
    <script language="javascript" src="javascript/datechkforcurrdate.js" type="text/javascript"></script>
    <script language="javascript" src="javascript/Validations.js" type="text/javascript"></script>
    <script language="javascript" src="javascript/entertotabbooking.js" type="text/javascript"></script>
    <script language="javascript" src="javascript/bookingMaster.js" type="text/javascript"></script>
    <script language="javascript" src="javascript/datevalidationforbook.js" type="text/javascript"></script>
    <script language="javascript" src="javascript/ShowAllPage.js" type="text/javascript"></script>
    <script language="javascript" src="javascript/dragImage.js" type="text/javascript"></script>
    <script language="javascript" src="javascript/receiptcumbill.js" type="text/javascript"></script>
    <script language="javascript" src="javascript/bookingLink.js" type="text/javascript"></script>
    <script language="javascript" src="javascript/jquery-1.5.js" type="text/javascript"></script>
    <script>
        TVURL = '<%=ConfigurationManager.AppSettings["TVURL"].ToString()%>';
        VISIBLEAGREEDRATE = '<%=ConfigurationManager.AppSettings["VISIBLEAGREEDRATE"].ToString()%>'
        ALLOWBOOKINGBRANCHMAIL = '<%=ConfigurationManager.AppSettings["ALLOWBOOKINGBRANCHMAIL"].ToString()%>'
        ALLOWBOOKINGGST = '<%=ConfigurationManager.AppSettings["ALLOWBOOKINGGST"].ToString()%>'
        ALLOWGSTROUND = '<%=ConfigurationManager.AppSettings["ALLOWGSTROUND"].ToString()%>';
    </script>

    <script language="javascript" type="text/javascript">


        var browser = navigator.appName;


        var popUpWin = "";
        function keyvalue() {


        }
        function Hide() {
            if (document.getElementById('divpopup').style.display == "block") {
                document.getElementById('divpopup').style.display = "none";
                //alert(document.getElementById('hiddiv').innerHTML);
                //document.getElementById('hidehref').innerHTML="Show";
                document.getElementById('shodi').style.display = "block";
                //alert(document.getElementById('hidehref').innerHTML)
                return false;

                // document.getElementById('tblinsert').style.display="block";


            }
            else {
                document.getElementById('divpopup').style.display = "block";
                document.getElementById('hidehref').innerHTML = "Hide";
                return false;
                //document.getElementById('tblinsert').style.display="none";
            }
        }

        function notchar2(event) {
            var key = event.keyCode ? event.keyCode : event.which;
            if (document.activeElement.id == "txtpospremdisc" && (document.getElementById('drppageposition').value == "0" || document.getElementById('drppageposition').value == "")) {
                return false;
            }
            if (document.activeElement.id == "txttranslationdisc" && (document.getElementById('drptranslation').value == "0" || document.getElementById('drptranslation').value == "")) {
                return false;
            }
            if (browser != "Microsoft Internet Explorer") {
                if ((event.which >= 48 && event.which <= 57) || (event.which == 127) || (event.which == 8) || (event.which == 9) || (event.which == 46) || (event.which == 0)) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 127) || (event.keyCode == 8) || (event.keyCode == 9) || (event.keyCode == 46)) {
                    return true;
                }
                else {
                    return false;
                }

            }
        }
        //        function notchar2Insert(event)
        //        {
        //           
        //            if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9))
        //            {
        //                return true;
        //            }
        //            else
        //            {   
        //                return false;
        //            }
        //        }
        function openClient() {
            window.open('clientName.aspx', 'ClientName', 'resizable=0,toolbar=0,top=140,left=30,scrollbars=yes,width=340px,height=255px');
            return false;
        }



        function changedivbill() {
            if (document.getElementById('LinkButton3').disabled == true)
                return false;
            //alert(document.getElementById('LinkButton1').click);
            document.getElementById('tblrate').style.display = "none";
            document.getElementById('tblbill').style.display = "block";
            document.getElementById('addetails').style.display = "none";
            document.getElementById('pagedetail').style.display = "none";
            //document.getElementById('tblsize').style.display="none";
            document.getElementById('tblpackage').style.display = "none";
            return false;
        }

        function openboxpopup() {
            if (document.getElementById('LinkButton6').disabled == true)
                return false;
            if (enLink == "1") {
                document.getElementById('LinkButton1').disabled = false;
                document.getElementById('LinkButton2').disabled = false;
                document.getElementById('LinkButton3').disabled = false;
                document.getElementById('LinkButton4').disabled = false;
                document.getElementById('LinkButton5').disabled = false;
                document.getElementById('LinkButton6').disabled = false;
                document.getElementById('LinkButton7').disabled = false;
            }
            if (document.getElementById('LinkButton6').disabled == false) {

                if (document.getElementById('txtagency').value == "") {
                    alert("Please fill the Agency Sub Code");
                    if (document.getElementById('txtagency').disabled == false)
                        document.getElementById('txtagency').focus();
                    return false;
                }
                else if (document.getElementById('drpagscode').value == "" || document.getElementById('drpagscode').value == "0") {
                    alert("Please select the agency sub code");
                    if (document.getElementById('drpagscode').disabled == false)
                        document.getElementById('drpagscode').focus();
                    return false;

                }
                if (document.getElementById('txtrono').value != "" && document.getElementById('txtrono').disabled == false) {
                    if (document.getElementById('txtrodate').value == "") {
                        alert("Please fill ro date");
                        if (document.getElementById('txtrodate').disabled == false)
                            document.getElementById('txtrodate').focus();
                        return false;

                    }

                }

                //*25Aug* check for retainer or Executive
                if (document.getElementById('drpretainer').value == "" && document.getElementById('txtexecname').value == "") {
                    alert('Please fill Execute Name or Retainer.');
                    if (document.getElementById('drpretainer').disabled == false)
                        document.getElementById('drpretainer').focus();
                    return false;
                }
                document.getElementById('LinkButton6').style.fontWeight = "bold";
                document.getElementById('LinkButton6').style.color = "#FFFF80";
                document.getElementById('LinkButton3').style.fontWeight = "normal";
                document.getElementById('LinkButton3').style.color = "White";
                document.getElementById('LinkButton4').style.fontWeight = "normal";
                document.getElementById('LinkButton4').style.color = "White";
                document.getElementById('LinkButton5').style.fontWeight = "normal";
                document.getElementById('LinkButton5').style.color = "White";
                document.getElementById('LinkButton1').style.fontWeight = "normal";
                document.getElementById('LinkButton1').style.color = "White";
                document.getElementById('LinkButton2').style.fontWeight = "normal";
                document.getElementById('LinkButton2').style.color = "White";
                document.getElementById('LinkButton7').style.fontWeight = "normal";
                document.getElementById('LinkButton7').style.color = "White";
                document.getElementById('tblrate').style.display = "none";
                document.getElementById('tblbill').style.display = "none";
                //alert(document.getElementById('LinkButton1').click);
                document.getElementById('pagedetail').style.display = "none";
                document.getElementById('addetails').style.display = "none";
                //document.getElementById('tblsize').style.display="none";
                document.getElementById('tblpackage').style.display = "none";
                document.getElementById('tblpackage').style.display = "none";
                document.getElementById('tbbox').style.display = "block";
                document.getElementById('tbvts').style.display = "none";
                if (document.getElementById('drpboxcode').disabled == false) {
                    document.getElementById('drpboxcode').focus();
                }
                return false;
            }
        }

        function openvts() {
            if (document.getElementById('LinkButton7').disabled == true)
                return false;
            if (enLink == "1") {
                document.getElementById('LinkButton1').disabled = false;
                document.getElementById('LinkButton2').disabled = false;
                document.getElementById('LinkButton3').disabled = false;
                document.getElementById('LinkButton4').disabled = false;
                document.getElementById('LinkButton5').disabled = false;
                document.getElementById('LinkButton6').disabled = false;
                document.getElementById('LinkButton7').disabled = false;
            }
            if (document.getElementById('LinkButton7').disabled == false) {

                if (document.getElementById('txtagency').value == "") {
                    alert("Please fill the Agency Sub Code");
                    document.getElementById('txtagency').focus();
                    return false;
                }
                else if (document.getElementById('drpagscode').value == "" || document.getElementById('drpagscode').value == "0") {
                    alert("Please select the agency sub code");
                    document.getElementById('drpagscode').focus();
                    return false;

                }
                if (document.getElementById('txtrono').value != "" && document.getElementById('txtrono').disabled == false) {
                    if (document.getElementById('txtrodate').value == "") {
                        alert("Please fill ro date");
                        document.getElementById('txtrodate').focus();
                        return false;

                    }

                }


                if (document.getElementById('drpretainer').value == "" && document.getElementById('txtexecname').value == "") {
                    alert('Please fill Execute Name or Retainer.');
                    document.getElementById('drpretainer').focus();
                    return false;
                }
                document.getElementById('LinkButton6').style.fontWeight = "normal";
                document.getElementById('LinkButton6').style.color = "White";
                document.getElementById('LinkButton3').style.fontWeight = "normal";
                document.getElementById('LinkButton3').style.color = "White";
                document.getElementById('LinkButton4').style.fontWeight = "normal";
                document.getElementById('LinkButton4').style.color = "White";
                document.getElementById('LinkButton5').style.fontWeight = "normal";
                document.getElementById('LinkButton5').style.color = "White";
                document.getElementById('LinkButton1').style.fontWeight = "normal";
                document.getElementById('LinkButton1').style.color = "White";
                document.getElementById('LinkButton2').style.fontWeight = "normal";
                document.getElementById('LinkButton2').style.color = "White";
                document.getElementById('LinkButton7').style.fontWeight = "bold";
                document.getElementById('LinkButton7').style.color = "#FFFF80";
                document.getElementById('tblrate').style.display = "none";
                document.getElementById('tblbill').style.display = "none";
                //alert(document.getElementById('LinkButton1').click); tbvts
                document.getElementById('pagedetail').style.display = "none";
                document.getElementById('addetails').style.display = "none";
                //document.getElementById('tblsize').style.display="none";
                document.getElementById('tblpackage').style.display = "none";
                document.getElementById('tblpackage').style.display = "none";
                document.getElementById('tbbox').style.display = "none";
                document.getElementById('tbvts').style.display = "block";
                if (document.getElementById('txtciragency').disabled == false) {
                    document.getElementById('txtciragency').focus();
                }
                return false;
            }


        }



        function showstrip() {
            document.getElementById('divpopup').style.display = "block";
            document.getElementById('shodi').style.display = "none";
            return false;
        }
        retexeboth = '<%=ConfigurationManager.AppSettings["retainerexecutiveboth"].ToString() %>'
        regclient = '<%=ConfigurationManager.AppSettings["registerClient"].ToString() %>'
        agnf2 = '<%=ConfigurationManager.AppSettings["agencyf2"].ToString()%>'
        chkforalert = '<%=ConfigurationManager.AppSettings["insertionchk"].ToString()%>';
        clientfromconfig = '<%=ConfigurationManager.AppSettings["CLIENTNAME"].ToString()%>'
        roundoff = '<%=ConfigurationManager.AppSettings["roundoff_Transaction"].ToString()%>'
        PAGEPREMIUMALERT = '<%=ConfigurationManager.AppSettings["PAGEPREMIUMALERT"].ToString()%>'
        COMMASALLOWINBOOKING = '<%=ConfigurationManager.AppSettings["COMMASALLOWINBOOKING"].ToString()%>'
        AREACALCULATION = '<%=ConfigurationManager.AppSettings["AREACALCULATION"].ToString()%>'
        // alert(retexeboth);		
    </script>

    <link href="css/booking.css" type="text/css" rel="stylesheet" />
</head>
<body onload="document.getElementById('Button1').disabled=true;javascript:return getdatafrompermissionmast();" onkeydown="javascript:return tabvalue(event);"
    onkeypress="eventcalling(event);" style="margin-top: 0px; background-color: #f3f6fd;" onclick="documentClick(event);">
    <form id="Form1" method="post" runat="server" autocomplete="off">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div id="Popup"
            style="border: 1px double #000000; position: absolute; top: 0px; left: 0px; display: none; z-index: 1; width: 350px; height: 80px; background-color: #CCFFFF;">
            <div style="background-color: #0099FF">
                <b>
                    <center>
                        <span>Remark</span></center>
                </b>
            </div>
            <div>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td id="tdremark" align="left" class="runtext1" style="font-family: verdana; font-size: 9px;"></td>
                    </tr>
                </table>

            </div>
        </div>

        <div id="multibilling_div" style="position: absolute; top: 0px; left: 0px; border: 1px solid #7DAAE3; display: none; z-index: 1; height: 200px; overflow: auto; width: 550px;">
        </div>

        <div id="div2" style="position: absolute; top: 0px; left: 0px; border: 0; display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0" style="border: thin double #000000; height: 80px; width: 300px; background-color: #D4D0C8;">
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblagaddf2" runat="server" CssClass="TextField" Text="Agency Address"></asp:Label></td>
                    <td valign="top">
                        <asp:TextBox ID="txtagaddf2" Width="180px" Height="50px" runat="server" CssClass="btext1forbooknew" Enabled="true" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" valign="top" align="left" style="padding-right: 10px">
                        <input type="button" value="Close" runat="server" style="height: 18px;" id="close1" class="buttonsmall" /></td>
                    <td colspan="2" valign="top" align="right" style="padding-right: 10px">
                        <input type="button" value="Search" runat="server" style="height: 18px;" id="btnagencysearch" class="buttonsmall" /></td>
                </tr>
            </table>
        </div>
        <div id="div4" style="position: absolute; top: 0px; left: 0px; border: 0; display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0" style="border: thin double #000000; height: 80px; width: 300px; background-color: #D4D0C8;">
                <tr>
                    <td valign="top">
                        <asp:Label ID="lblcliaddf2" runat="server" CssClass="TextField" Text="Client Address"></asp:Label></td>
                    <td valign="top">
                        <asp:TextBox ID="txtcliaddf2" Width="180px" Height="50px" runat="server" CssClass="btext1forbooknew" Enabled="true" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" valign="top" align="left" style="padding-right: 10px">
                        <input type="button" value="Close" runat="server" style="height: 18px;" id="close2" class="buttonsmall" /></td>
                    <td colspan="2" valign="top" align="right" style="padding-right: 10px">
                        <input type="button" value="Search" runat="server" style="height: 18px;" id="btnclientsearch" class="buttonsmall" /></td>
                </tr>
            </table>
        </div>


        <div id="div1" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:ListBox ID="lstagency" Width="820px" Height="150px" runat="server" CssClass="btextlistagen"></asp:ListBox></td>
                </tr>
            </table>
        </div>
        <div id="divloader" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <img src='Images/loader.gif' id="Img1" height="250" width="250" /></td>
                </tr>
            </table>
        </div>

        <div id="divcap" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:ListBox ID="lstcap" Width="350px" Height="80px" runat="server" CssClass="btextlist"></asp:ListBox></td>
                </tr>
            </table>
        </div>
        <div id="divcopyinsertion" style="border: 2px solid rgb(0, 0, 0); position: absolute; top: 0px; left: 0px; display: none; z-index: 1;">
        </div>
        <div id="divgstgd" style="border: 2px solid rgb(0, 0, 0); position: absolute; top: 0px; left: 0px; display: none; z-index: 1;">
        </div>
        <div id="divmail" style="border: 2px solid rgb(0, 0, 0); position: absolute; top: 0px; left: 0px; display: none; z-index: 1;">
        </div>
        <div id="divreference" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>

                        <asp:ListBox ID="lstreference" Width="300px" Height="65px" runat="server" CssClass="btextlist"></asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divbrand" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>

                        <asp:ListBox ID="lstbrand" Width="300px" Height="65px" runat="server" CssClass="btextlist"></asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        <%--  /////////////////anuja--%>
        <div id="divindus" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>

                        <asp:ListBox ID="lstindus" Width="300px" Height="65px" runat="server" CssClass="btextlist"></asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divprosucat" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>

                        <asp:ListBox ID="lstprosubcat" Width="300px" Height="65px" runat="server" CssClass="btextlist"></asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        <%-- /////////////////--%>
        <div id="divclient" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>

                        <asp:ListBox ID="lstclient" Width="350px" Height="85px" runat="server" CssClass="btextlistagen"></asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divrevenuecenternew" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>

                        <asp:ListBox ID="lstrevenuecenternew" Width="350px" Height="85px" runat="server" CssClass="btextlistagen"></asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        <div id="div3" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:ListBox ID="lstclient_multibilling" Width="350px" Height="85px" runat="server"
                            CssClass="btextlistagen"></asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divciragency" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>

                        <asp:ListBox ID="lstciragency" Width="354px" Height="65px" runat="server" CssClass="btextlist"></asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divcirrate" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>

                        <asp:ListBox ID="lstcirrate" Width="354px" Height="65px" runat="server" CssClass="btextlist"></asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divbarter" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>

                        <asp:ListBox ID="lstbarter" Width="354px" Height="65px" runat="server" CssClass="btextlist"></asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divretainer" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>

                        <asp:ListBox ID="lstretainer" Width="254px" Height="65px" runat="server" CssClass="btextlist"></asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divproduct" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>

                        <asp:ListBox ID="lstproduct" Width="254px" Height="65px" runat="server" CssClass="btextlist"></asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divexec" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>

                        <asp:ListBox ID="lstexec" Width="254px" Height="65px" runat="server" CssClass="btextlist"></asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        
         <div id="divpackmgrp" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1; background-color:Navy;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>

                        <asp:ListBox ID="lstpackmgrp" Width="254px" Height="65px" runat="server" CssClass="btextlist"></asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        
         <div id="divpacksgrp" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1;  background-color:Navy;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>

                        <asp:ListBox ID="lstpacksgrp" Width="254px" Height="65px" runat="server" CssClass="btextlist"></asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        
        <div id="divcolexec" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>

                        <asp:ListBox ID="lstcolexec" Width="254px" Height="65px" runat="server" CssClass="btextlist"></asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divdeal" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1000;">
        </div>
        <div id="divpkg" style="position: absolute; top: 0px; left: 0px; height: 90px; width: 200px; border: 1; display: none; background-color: White; z-index: +999;">
        </div>

        <table id="OuterTable" cellspacing="0" cellpadding="0" align="LEFT"
            border="0">
            <tr valign="top">
                <td colspan="2">
                    <uc1:Topbar ID="Topbar1" runat="server" Text="Display Booking"></uc1:Topbar>
                </td>
                <td></td>
            </tr>
            <tr valign="top">
                <td valign="top" id="sectd" style="width: 988px">
                    <table class="RightTable" id="RightTable" border="0">
                        <tr valign="top" style="margin: 10px 0px 5px 0px">
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:ImageButton ID="btnNew" runat="server" Font-Bold="True" BorderColor="DarkGray"
                                            BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small"
                                            OnClick="btnNew_Click"></asp:ImageButton><asp:ImageButton ID="btnSave" runat="server"
                                                Font-Bold="True" BorderColor="DarkGray" BorderStyle="Outset" BackColor="Control"
                                                Font-Size="XX-Small" AccessKey="s" OnClick="btnSave_Click"></asp:ImageButton><asp:ImageButton
                                                    ID="btnModify" runat="server" Font-Bold="True" BorderColor="DarkGray"
                                                    BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" OnClick="btnModify_Click"></asp:ImageButton><asp:ImageButton ID="btnQuery" runat="server" Font-Bold="True"
                                                        BorderColor="DarkGray" BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small"
                                                        OnClick="btnQuery_Click"></asp:ImageButton><asp:ImageButton ID="btnExecute" runat="server"
                                                            Font-Bold="True" BorderColor="DarkGray" BorderStyle="Outset" BackColor="Control"
                                                            Font-Size="XX-Small" OnClick="btnExecute_Click"></asp:ImageButton><asp:ImageButton
                                                                ID="btnCancel" runat="server" Font-Bold="True" BorderColor="DarkGray"
                                                                BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" OnClick="btnCancel_Click"></asp:ImageButton><asp:ImageButton ID="btnfirst" runat="server" Font-Bold="True"
                                                                    BorderColor="DarkGray" BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small"
                                                                    OnClick="btnfirst_Click" Height="16px"></asp:ImageButton><asp:ImageButton ID="btnprevious" runat="server"
                                                                        Font-Bold="True" BorderColor="DarkGray" BorderStyle="Outset" BackColor="Control"
                                                                        Font-Size="XX-Small" OnClick="btnprevious_Click"></asp:ImageButton><asp:ImageButton
                                                                            ID="btnnext" runat="server" Font-Bold="True" BorderColor="DarkGray"
                                                                            BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" OnClick="btnnext_Click"></asp:ImageButton><asp:ImageButton ID="btnlast" runat="server" Font-Bold="True"
                                                                                BorderColor="DarkGray" BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small"
                                                                                OnClick="btnlast_Click"></asp:ImageButton><asp:ImageButton ID="btnDelete" runat="server"
                                                                                    Font-Bold="True" BorderColor="DarkGray" BorderStyle="Outset" BackColor="Control"
                                                                                    Font-Size="XX-Small"></asp:ImageButton><asp:ImageButton ID="btnExit" runat="server"
                                                                                        Font-Bold="True" BorderColor="DarkGray" BorderStyle="Outset" BackColor="Control"
                                                                                        Font-Size="XX-Small"></asp:ImageButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td id="tbl3"></td>
                        </tr>
                        
                                                <tr><td>
                        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="width:auto;margin:0px -25px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><center><b><asp:Label ID="bookingformname1" runat="server"></asp:Label></b></center></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><asp:Label ID="lblcreationdatetime" runat="server" CssClass="TextField"></asp:Label><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table></td></tr>

                        <tr>
                            <td id="tbl1">
                                <table align="left" cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td colspan="9" id="tbl2">
                                            <table width="100%" border="0">
                                                <tr>
                                                    <td class="auto-style7">
                                                        <asp:Label ID="lbdatetime" runat="server" CssClass="TextField" Text="Date/Time"></asp:Label></td>
                                                    <td class="auto-style5">
                                                        <asp:Label ID="lblrevenuecenternew" runat="server" CssClass="TextField" Text="Revenue Center"></asp:Label></td>
                                                    <td class="auto-style2">
                                                        <asp:Label ID="lbbookedby" runat="server" CssClass="TextField" Text="Booked By"></asp:Label></td>
                                                    <td class="auto-style3">
                                                        <asp:Label ID="lbcioid" runat="server" CssClass="TextField" Text="CIO Booking ID"></asp:Label></td>
                                                    <td class="auto-style4">
                                                        <asp:Label ID="lbpreid" runat="server" CssClass="TextField"></asp:Label></td>
                                                    <td class="auto-style6">
                                                        <asp:Label ID="lbbranch" runat="server" CssClass="TextField" Text="Branch"></asp:Label></td>
                                                    <td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style7">

                                                        <asp:TextBox ID="txtdatetime" runat="server" CssClass="btext3" Enabled="False" Width="74px">Date/Time</asp:TextBox>

                                                    </td>
                                                    <td class="auto-style5">

                                                        <asp:TextBox ID="txtrevenuecenternew" runat="server" CssClass="btextforbook" Enabled="False" Width="100px" onkeydown="javascript:return f2query(event);">Revenue Center</asp:TextBox>

                                                    </td>

                                                    <td class="auto-style2">
                                                        <asp:TextBox ID="txtbookedby" runat="server" CssClass="btext3" ReadOnly="true" Enabled="False" Width="85px">Booked By</asp:TextBox>

                                                    </td>
                                                    <td class="auto-style3">
                                                        <asp:TextBox ID="txtciobookid" runat="server" Style="text-align: right;" CssClass="btext3" Enabled="False" Width="80px"></asp:TextBox>

                                                    </td>
                                                    <td class="auto-style4">

                                                        <asp:TextBox ID="txtprevbook" runat="server" CssClass="btext3" ReadOnly="true" Width="101px">Previous Booking</asp:TextBox>

                                                    </td>
                                                    <td class="auto-style6">
                                                        <asp:TextBox ID="txtbranch_name" runat="server" CssClass="btext3" Enabled="False" Width="81px">Branch</asp:TextBox>

                                                    </td>
                                                </tr>


                                                <tr style="display: none">
                                                    <td colspan="5">
                                                        <asp:TextBox ID="txtbranch" runat="server" CssClass="btext3" Enabled="False"></asp:TextBox>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="lbagency" runat="server" CssClass="TextField" Text="Agency"></asp:Label></td>
                                        <td valign="top" id="tdagen" colspan="" class="auto-style8">

                                            <asp:TextBox ID="txtagency" runat="server" CssClass="btextforbook" Enabled="False"
                                                MaxLength="50" onkeyup="javascript:return f2query(event);"></asp:TextBox>
                                            <asp:Button ID="btntempagency" Enabled="true" CssClass="topbutton" runat="server" Style="color: red" Text="New Ag." Height="18px" Width="43px" />
                                            <img src='Images/remarks.jpg' id="agremark" height="15" runat="server" width="20" />
                                        </td>
                                        <td></td>
                                        <td valign="top">
                                            <asp:Label ID="lbclient" runat="server" CssClass="TextField" Text="Client"></asp:Label><asp:DropDownList ID="drpregular" runat="server" CssClass="dropdownforbookreg"
                                                Enabled="False">
                                                <asp:ListItem Value="0" Selected="True">sel</asp:ListItem>
                                                <asp:ListItem Value="RC">RC</asp:ListItem>
                                                <asp:ListItem Value="NRC">NRC</asp:ListItem>
                                                <asp:ListItem Value="TBRC">TBRC</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td valign="top"></td>
                                        <td valign="top" id="tdclient">
                                            <asp:TextBox ID="txtclient" runat="server" CssClass="btextforbook" Enabled="False"
                                                MaxLength="50" onkeyup="javascript:return f2query(event);"></asp:TextBox><img
                                                    src='Images/remarks.jpg' id="clientremark" height="15" width="20" runat="server" />


                                        </td>
                                        <td valign="top" align="left" style="width: 1px"></td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="lbaaddress" runat="server" CssClass="TextField" Text="Address"></asp:Label><img
                                                src='Images/Search.png' id="Imgadvance" onclick='openadvpopup()' runat="server" height="20" width="20" align="right" /></td>
                                        <td class="auto-style8">
                                            <asp:TextBox ID="txtagencyaddress" runat="server" CssClass="btext1forbooknew" TextMode="MultiLine"
                                                Enabled="False"></asp:TextBox>
                                        </td>
                                        <td></td>
                                        <td valign="top">
                                            <asp:Label ID="lbcaddress" runat="server" CssClass="TextField" Text="Address"></asp:Label><img
                                                src='Images/Search.png' id="Imgcli" onclick='openadvpopup1()' runat="server" height="20" width="20" align="right" /></td>
                                        <td valign="top"></td>
                                        <td>
                                            <asp:TextBox ID="txtclientadd" runat="server" CssClass="btext1forbooknew" TextMode="MultiLine"
                                                Enabled="False" MaxLength="500" Width="116px"></asp:TextBox>
                                            <asp:Button Text="Rg" runat="server" ID="regclient" Style="height: 18px; width: 30px; text-align: left;"
                                                Font-Size="X-Small" />

                                        </td>
                                        <td style="width: 1px"></td>
                                    </tr>
                                    <tr id="tremail" runat="server">
                                        <td valign="top">
                                            <asp:Label ID="lblcontact" runat="server" CssClass="TextField"></asp:Label></td>
                                        <td valign="top">
                                            <asp:TextBox ID="txtcontactperson" runat="server" CssClass="btextforbook" MaxLength="50" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td style="width: 1px"></td>
                                        <td valign="top">
                                            <asp:Label ID="lblmailid" runat="server" CssClass="TextField"></asp:Label></td>
                                        <td valign="top"></td>
                                        <td valign="top">
                                            <asp:TextBox ID="txtmailid" runat="server" CssClass="btextforbook" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="lbagescode" runat="server" CssClass="TextField" Text="Agency Sub Code"></asp:Label></td>
                                        <td valign="top" class="auto-style8">
                                            <asp:DropDownList ID="drpagscode" runat="server" CssClass="dropdownforbook" Enabled="False">
                                            </asp:DropDownList>

                                        </td>
                                        <td></td>
                                        <td style="display: none" valign="top">
                                            <asp:Label ID="lblagencytype" runat="server" CssClass="TextField"></asp:Label></td>
                                        <td style="display: none" valign="top"></td>
                                        <td style="display: none" valign="top">
                                            <asp:TextBox ID="txtagencytype" runat="server" CssClass="btextforbook" Enabled="False"></asp:TextBox>

                                        </td>
                                        <td valign="top">
                                            <asp:Label ID="lbmobileno" runat="server" CssClass="TextField"></asp:Label></td>
                                        <td valign="top"></td>
                                        <td valign="top">
                                            <asp:TextBox ID="txtMobile" onkeypress="return notchar2(event);" Enabled="False" MaxLength="11" runat="server" CssClass="btextforbook"></asp:TextBox>

                                        </td>
                                        <td style="width: 1px"></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <!--ageny-->
                                    <tr>
                                        <td valign="top" style="display: none">
                                            <asp:Label ID="lblagencystatus" runat="server" CssClass="TextField"></asp:Label></td>
                                        <td valign="top" style="display: none" class="auto-style8">
                                            <asp:TextBox ID="txtagencystatus" ReadOnly="true" runat="server" CssClass="btextforbook"
                                                Enabled="False"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblagdesignation" runat="server" CssClass="TextField">AG.Designation</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="txtdesignation" ReadOnly="true" runat="server" CssClass="btextforbook"
                                                Enabled="False"></asp:TextBox></td>
                                        <td></td>
                                        <td valign="top">
                                            <asp:Label ID="lblagencypaymode" runat="server" CssClass="TextField"></asp:Label></td>
                                        <td valign="top"></td>
                                        <td valign="top">
                                            <asp:DropDownList ID="txtagencypaymode" runat="server" CssClass="dropdownforbook" Enabled="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="lblagencycreditperiod" runat="server" CssClass="TextField"></asp:Label></td>
                                        <td valign="top" class="auto-style8">
                                            <asp:TextBox ID="txtcreditperiod" runat="server" CssClass="btextforbooktd" Enabled="False"></asp:TextBox>
                                            <asp:Label ID="lbltd" runat="server" CssClass="TextField">TD</asp:Label>
                                            <asp:TextBox ID="txttd" runat="server" CssClass="btextforbooktd" Enabled="False"></asp:TextBox>

                                        </td>
                                        <td></td>
                                        <td valign="top">
                                            <asp:Label ID="lbrono" runat="server" CssClass="TextField" Text="RO No."></asp:Label></td>
                                        <td valign="top"></td>
                                        <td valign="top">
                                            <asp:TextBox ID="txtrono" runat="server" CssClass="btextforbook" Enabled="False"
                                                MaxLength="40"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="lbrodate" runat="server" CssClass="TextField" Text="RO Date"></asp:Label></td>
                                        <td valign="top" class="auto-style8">
                                            <asp:TextBox ID="txtrodate" runat="server" CssClass="btextforbook" Enabled="False" onkeypress="return dateenter(event);"></asp:TextBox><img
                                                src='Images/cal1.gif' id="Img2" onclick='popUpCalendar(this, Form1.txtrodate, "mm/dd/yyyy")'
                                                onfocus="abc()" height="11" width="14" />

                                        </td>
                                        <td></td>
                                        <td valign="top">
                                            <asp:Label ID="lbrostatus" runat="server" CssClass="TextField" Text="Ro Status"></asp:Label></td>
                                        <td valign="top"></td>
                                        <td valign="top">

                                            <asp:DropDownList ID="drprostatus" runat="server" CssClass="dropdownforbook" Enabled="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 1px"></td>
                                    </tr>

                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="lbdockit" runat="server" CssClass="TextField" Text="Dockit No."></asp:Label></td>
                                        <td valign="top" class="auto-style8">

                                            <asp:TextBox ID="txtdockitno1" runat="server" CssClass="btextforbook" Enabled="False"></asp:TextBox>
                                            <%--  <asp:Label ID="btnmail" runat="server" CssClass="TextField" Text="Mail"  ></asp:Label> --%>
                                            <%--  <input type="button" value="Mail" runat="server" style="height:18px;width:42px; color:red" id="btnmail" class ="buttonsmall"  />--%>
                                            <asp:Button ID="btnmail" Enabled="true" CssClass="topbutton" runat="server" Style="color: red" Text="Mail" Height="18px" Width="43px" /></td>
                                        <td></td>
                                        <td valign="top">
                                            <asp:Label ID="lbkey" runat="server" Text="Key No." CssClass="TextField"></asp:Label></td>
                                        <td valign="top"></td>
                                        <td valign="top">
                                            <asp:TextBox ID="txtkeyno" runat="server" CssClass="btextforbook" Enabled="False"
                                                MaxLength="50"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="lbececname" runat="server" CssClass="TextField" Text="Executive Name"></asp:Label></td>
                                        <td valign="top" id="tdexec" class="auto-style8">
                                            <asp:TextBox ID="txtexecname" runat="server" CssClass="btextforbook" MaxLength="50" Enabled="False"></asp:TextBox><input type="button" value="M" runat="server" style="height: 18px; width: 20px; color: red" id="Button1" class="buttonsmall" />
                                            <input type="button" value="T" runat="server" style="height: 18px; width: 20px; color: red" id="btnteam" class="buttonsmall" />
                                        </td>
                                        <td></td>
                                        <td valign="top">
                                            <asp:Label ID="lbexeczone" runat="server" Text="Executive Zone" CssClass="TextField"></asp:Label></td>
                                        <td valign="top"></td>
                                        <td valign="top">
                                            <asp:TextBox ID="txtexeczone" runat="server" CssClass="btextforbook" ReadOnly="True"
                                                Enabled="False"></asp:TextBox>
                                        </td>
                                        <td style="width: 1px"></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="lblagencyoutstand" runat="server" CssClass="TextField"></asp:Label></td>
                                        <td colspan="2" valign="top">
                                            <asp:TextBox ID="txtagencyoutstand" runat="server" CssClass="btextforbook" Enabled="False"
                                                MaxLength="50"></asp:TextBox>
                                            <asp:Label ID="lblteamname" runat="server" CssClass="TextFieldbook"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblretainer" runat="server" CssClass="TextField"></asp:Label></td>
                            </td>
                            <td></td>
                            <td valign="top" id="tdretainer">

                                <asp:TextBox ID="drpretainer" runat="server" CssClass="btextforbook" Enabled="False" MaxLength="50"></asp:TextBox>

                            </td>
                            <td style="width: 1px"></td>
                            <td valign="top"></td>
                            <td valign="top"></td>
                            <td valign="top"></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="lblquotation" runat="server" CssClass="TextField" Text="Quotation No"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtquotationno" runat="server" CssClass="btextforbook" Enabled="False" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="shodi" runat="server" style="display: none;">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:LinkButton ID="showdiv" runat="server" CssClass="TextField">Show</asp:LinkButton></td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <!--ageny-->
                    </table>
                </td>
            </tr>

        </table>





        <table>


            <tr>
                <td colspan="5" valign="top">
                    <div style="display: block" id="divpopup">
                        <table border="1" id="tdpck" cellpadding="0" cellspacing="0">
                            <tr>
                                <td bgcolor="#7daae3">

                                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btnlink">Ad Details |</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton5" runat="server" CssClass="btnlink">Package |</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btnlink">Page Details |</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton4" runat="server" CssClass="btnlink">Rate Details |</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton3" runat="server" CssClass="btnlink">Bill Details |</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton6" runat="server" CssClass="btnlink">Box Details |</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton7" runat="server" CssClass="btnlink">Tear Sheets |</asp:LinkButton>
                                    <asp:ImageButton ID="attachment1" runat="server" CssClass="btnlinkImage" ToolTip="Attachment" ImageUrl="~/Images/index.jpeg"></asp:ImageButton>
                                    <asp:ImageButton ID="attachment2" runat="server" CssClass="btnlinkImage" ToolTip="Other Attachment" ImageUrl="~/Images/index.jpeg"></asp:ImageButton>
                                </td>
                                <td align="right" bgcolor="#7daae3">
                                    <asp:LinkButton ID="hidehref" runat="server" CssClass="btnlinkhide">Hide</asp:LinkButton></td>
                            </tr>

                            <tr>
                                <td colspan="5">
                                    <table cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td>
                                                <table id="tblpackage" style="display: none;" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td valign="top">
                                                            <asp:Label ID="lbcoupan" runat="server" CssClass="TextField"></asp:Label></td>
                                                        <td valign="top" colspan="2">
                                                            <asp:CheckBox ID="chkcoupan" runat="server" CssClass="TextField" />
                                                            &nbsp;&nbsp;
                                                        <asp:Label ID="lbladon" runat="server" CssClass="TextField" Text="Ad On"></asp:Label>

                                                            <asp:CheckBox ID="chkadon" runat="server" CssClass="TextField" />
                                                        </td>
                                                        <td valign="top">
                                                            <asp:Label ID="lbreference" runat="server" Style="display: none;" CssClass="TextField" Text="Reference Id"></asp:Label></td>
                                                        <td valign="top" id="tdref" style="display: none;">
                                                            <asp:TextBox ID="txtreference" runat="server" Style="text-align: left;" CssClass="btextforbookrightsmall"
                                                                Enabled="False" MaxLength="50"></asp:TextBox><input id="btnrefid" type="button" value="Ref" runat="server" class="buttonsmall" style="width: 30px;" enabled="false" />
                                                        </td>
                                                    </tr>
                                                    
                                            <tr>
                                                <td valign="top">
                                                    <asp:Label ID="lblpackmain" runat="server" CssClass="TextField" Text="Package Main Group"></asp:Label>
                                                </td>
                                                
                                                <td>
                                                    <asp:TextBox ID="txtpackmaingrp" runat="server" CssClass="btextforbooksmall" MaxLength="50" style="width: 150px;" onkeyup="javascript:return bindpackmaingrp(event);" ></asp:TextBox>
                                                </td>
                                                 <td></td>
                                                <td>
                                                    <asp:Label ID="lblpacksubgrp" runat="server" CssClass="TextField" Text="Package Sub Group"></asp:Label>
                                                </td>
                                                
                                                <td>
                                                 <asp:TextBox ID="txtpacksubgrp" runat="server" CssClass="btextforbooksmall" MaxLength="50" style="width:150px;" onkeyup="javascript:return bindpackmaingrp(event);" ></asp:TextBox>
                                                </td>
                                            
                                            </tr>
                                                    
                                                    <tr>
                                                        <td valign="top">
                                                            <asp:Label ID="lbpackage" runat="server" CssClass="TextField" Text="Package"></asp:Label></td>
                                                        <td valign="top">
                                                            <asp:ListBox ID="drppackage" SelectionMode="Multiple" runat="server" CssClass="btextlistpacksmall" Width="800" Height="180"></asp:ListBox>

                                                        </td>
                                                        <td></td>
                                                        <td>

                                                            <asp:Button ID="btncopy" runat="server" CssClass="buttcopy" Text=">>>" OnClick="btncopy_Click" Enabled="False" />
                                                            <asp:Button ID="btndel" runat="server" CssClass="buttcopy" Text="<<<" OnClick="btncopy_Click" Enabled="False" /></td>
                                                        <td>
                                                            <asp:ListBox ID="drppackagecopy" runat="server" CssClass="btextlistpacksmall" Height="180"></asp:ListBox>

                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <asp:Label ID="lbselectdate" runat="server" CssClass="TextField" Text="Select Date"></asp:Label></td>
                                                        <td valign="top">
                                                            <asp:TextBox ID="txtdummydate" runat="server" CssClass="btextforbooksmall" onkeypress="return dateenter(event);"></asp:TextBox><img
                                                                src='Images/cal1.gif' id="Img3" onclick='popUpCalendar(this, Form1.txtdummydate, "mm/dd/yyyy")'
                                                                onfocus="abc()" height="11" width="14" />
                                                        </td>
                                                        <td></td>
                                                        <td>
                                                            <asp:Label ID="lbad" runat="server" CssClass="TextField" Text="Label"></asp:Label></td>
                                                        <td>

                                                            <asp:CheckBox ID="chktfn" runat="server" CssClass="TextField" />&nbsp;
                                                                
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <asp:Label ID="lbnoofins" runat="server" CssClass="TextField" Text="No. Of Insertion"></asp:Label></td>
                                                        <td valign="top">

                                                            <asp:TextBox ID="txtinsertion" onkeypress="return isNumberKey(event);" MaxLength="6" runat="server"
                                                                CssClass="btextforbookrightsmall" AutoPostBack="True" OnTextChanged="txtinsertion_TextChanged1"
                                                                Enabled="False"></asp:TextBox>
                                                        </td>
                                                        <td></td>
                                                        <td>
                                                            <asp:Label ID="lbrepdate" runat="server" CssClass="TextField" Text="Repeating Day"></asp:Label></td>
                                                        <td>

                                                            <asp:TextBox ID="txtrepeatingdate" onkeypress="return rateenter(event);" MaxLength="4"
                                                                CssClass="btextforbookrightsmall" runat="server"></asp:TextBox>

                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <asp:Label ID="lbpaid" runat="server" CssClass="TextField" Text="Label"></asp:Label></td>
                                                        <td valign="top">

                                                            <asp:TextBox ID="txtpaid" runat="server" AutoPostBack="True" CssClass="btextforbookrightsmall"
                                                                Enabled="False" MaxLength="10" onkeypress="return notchar2();" OnTextChanged="txtinsertion_TextChanged1"></asp:TextBox>

                                                        </td>
                                                        <td></td>
                                                        <td style="display: none;" id="lbrevtd" runat="server">
                                                            <asp:Label ID="lblrevisedate" runat="server" CssClass="TextField" Text="Revise Date"></asp:Label></td>
                                                        <td style="display: none;" id="txtrevtd" runat="server">
                                                            <asp:TextBox ID="txtrevisedate" runat="server" CssClass="btextforbooksmall" onkeypress="return dateenter(event);"></asp:TextBox><img
                                                                src='Images/cal1.gif' id="Img4" onclick='popUpCalendar(this, Form1.txtrevisedate, "mm/dd/yyyy")'
                                                                onfocus="abc()" height="11" width="14" /></td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <asp:Label ID="lbcurrency" runat="server" CssClass="TextField" Text="Currency Type"></asp:Label></td>
                                                        <td valign="top">

                                                            <asp:DropDownList ID="drpcurrency" runat="server" CssClass="dropdownforbooksmall" Enabled="False">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td></td>
                                                        <td valign="top">
                                                            <asp:Label ID="lbrptcurrency" runat="server" CssClass="TextField" Text="Receipt Currency"></asp:Label></td>
                                                        <td valign="top">

                                                            <asp:DropDownList ID="drprptcurrency" runat="server" CssClass="dropdownforbooksmall" Enabled="False">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <asp:Label ID="lbcontractname" runat="server" CssClass="TextField" Text="Label"></asp:Label></td>
                                                        <td valign="top">

                                                            <asp:TextBox ID="txtcontractname" runat="server" AutoPostBack="True" CssClass="btextforbookrightsmall"
                                                                Enabled="False" MaxLength="10" onkeypress="return notchar2();" OnTextChanged="txtinsertion_TextChanged1"></asp:TextBox>
                                                            <asp:CheckBox ID="chkcontract" runat="server" CssClass="TextField" />

                                                        </td>
                                                        <td></td>
                                                        <td>
                                                            <asp:Label ID="lbcontracttype" runat="server" CssClass="TextField" Text="Label"></asp:Label></td>
                                                        <td>

                                                            <asp:TextBox ID="txtcontracttype" runat="server" AutoPostBack="True" CssClass="btextforbookrightsmall"
                                                                Enabled="False" MaxLength="10" onkeypress="return notchar2();" OnTextChanged="txtinsertion_TextChanged1"></asp:TextBox>

                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <asp:Label ID="lbprintremark" runat="server" Text="Print Remark" CssClass="TextField"></asp:Label></td>
                                                        <td colspan="4" valign="top">

                                                            <asp:TextBox ID="txtprintremark" runat="server" CssClass="btextcapaddsmall" TextMode="MultiLine"
                                                                Enabled="False" MaxLength="500"></asp:TextBox>

                                                        </td>

                                                        <td></td>
                                                        <td></td>
                                                        <td id="tdpaid"></td>
                                                    </tr>
                                                </table>
                                                <table id="pagedetail" style="display: none;" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lbadsizetype" runat="server" CssClass="TextField" Text="Ad Size Type"></asp:Label></td>
                                                        <td valign="top">

                                                            <asp:DropDownList ID="drpadstype" TabIndex="0" runat="server" CssClass="dropdownforbook" Enabled="False">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 15px"></td>
                                                        <td>
                                                            <asp:Label ID="lbadsize" runat="server" CssClass="TextField" Text="Adv Size"></asp:Label></td>
                                                        <td valign="top">
                                                            <asp:Label runat="server" ID="w" CssClass="TextField" Text="W"></asp:Label>
                                                            <asp:TextBox
                                                                ID="txtadsize2" CssClass="btextsmallsizerig" onkeypress="return rateenter(event);"
                                                                runat="server" Enabled="False" TabIndex="0" MaxLength="5"></asp:TextBox>

                                                            <asp:Label runat="server" ID="h" CssClass="TextField" Text="H"></asp:Label>
                                                            <asp:TextBox
                                                                ID="txtadsize1" CssClass="btextsmallsizerig" onkeypress="return rateenter(event);"
                                                                runat="server" Enabled="False" MaxLength="5" TabIndex="0"></asp:TextBox>
                                                            
                                                            
                                                            <asp:Label ID="lbmeasure" runat="server" CssClass="TextFielduom"></asp:Label>
                                                            <asp:CheckBox ID="chkDealerPanel" runat="server" ToolTip="Dealer Panel" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lbpageprem" runat="server" CssClass="TextField"></asp:Label></td>
                                                        <td>

                                                            <asp:DropDownList ID="drppageprem" TabIndex="0" runat="server" CssClass="dropdownforbook" Enabled="False">
                                                            </asp:DropDownList>

                                                        </td>
                                                        <td style="width: 15px"></td>
                                                        <td>
                                                            <asp:Label ID="Label3" runat="server" CssClass="TextField" Text="Dealer Panel"></asp:Label></td>
                                                        <td valign="top">
                                                            <asp:Label runat="server" ID="Label5" CssClass="TextField" Text="W"></asp:Label>
                                                            <asp:TextBox
                                                                ID="txtadsize2dealer" CssClass="btextsmallsizerig" onkeypress="return rateenter(event);"
                                                                runat="server" Enabled="False" MaxLength="5"></asp:TextBox>

                                                            <asp:Label runat="server" ID="Label4" CssClass="TextField" Text="H"></asp:Label>
                                                            <asp:TextBox
                                                                ID="txtadsize1dealer" CssClass="btextsmallsizerig" onkeypress="return rateenter(event);"
                                                                runat="server" Enabled="False" MaxLength="5"></asp:TextBox>
                                                            
                                                            <asp:DropDownList ID="drpdealertype" runat="server" Style="Width: 50px;" CssClass="dropdownforbook" Enabled="False">
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="R" Text="Right Hand L"></asp:ListItem>
                                                                <asp:ListItem Value="L" Text="Left Hand L"></asp:ListItem>
                                                                <asp:ListItem Value="A" Text="L Leader"></asp:ListItem>
                                                                <asp:ListItem Value="B" Text="R Leader"></asp:ListItem>
                                                                <asp:ListItem Value="F" Text="Fix"></asp:ListItem>
                                                                <asp:ListItem Value="V" Text="Var."></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>


                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lbpagepost" runat="server" CssClass="TextField" Text="Page Position"></asp:Label></td>
                                                        <td>

                                                            <asp:DropDownList ID="drppageposition" runat="server" TabIndex="0" CssClass="dropdownforbook"
                                                                Enabled="False">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 15px"></td>
                                                        <td>
                                                            <asp:Label ID="lbcolumn" runat="server" CssClass="TextField"></asp:Label></td>
                                                        <td>

                                                            <asp:TextBox ID="txtcolum" runat="server" CssClass="btextforbookright" TabIndex="0" Enabled="False"
                                                                onkeypress="return notchar2(event);" MaxLength="4"></asp:TextBox>
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lbldiscountprem" runat="server" CssClass="TextField" Text="Discount Prem."></asp:Label></td>
                                                        <td>

                                                            <asp:DropDownList ID="drpdiscountprem" TabIndex="0" runat="server" CssClass="dropdownforbook"
                                                                Enabled="False">
                                                            </asp:DropDownList>
                                                        </td>

                                                        <td style="width: 15px"></td>
                                                        <td>
                                                            <asp:Label ID="Label1" runat="server" CssClass="TextField" Text="Total Area"></asp:Label></td>
                                                        <td>

                                                            <asp:TextBox ID="txttotalarea" onkeypress="return notchar2();" runat="server" CssClass="btextforbookright"
                                                                Enabled="False" MaxLength="8"></asp:TextBox>
                                                            <asp:Label ID="lbmeasuretotal" runat="server" CssClass="TextFielduom"></asp:Label>

                                                        </td>

                                                        <td></td>
                                                    </tr>
                                                    <tr id="translation" runat="server">
                                                        <td>
                                                            <asp:Label ID="lbltranslation" runat="server" CssClass="TextField"></asp:Label></td>
                                                        <td>
                                                            <asp:DropDownList ID="drptranslation" runat="server" CssClass="dropdownforbook"
                                                                Enabled="False">
                                                            </asp:DropDownList>

                                                        </td>
                                                        <td style="width: 15px"></td>
                                                        <td>
                                                            <asp:Label ID="lbltranslationcharges" runat="server" CssClass="TextField"></asp:Label></td>
                                                        <td>

                                                            <asp:TextBox ID="txttranslationcharges" runat="server" CssClass="btextforbookright" Enabled="False"
                                                                onkeypress="return notchar2();"></asp:TextBox>

                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lbpageno" runat="server" CssClass="TextField" Text="Page No."></asp:Label></td>
                                                        <td>

                                                            <asp:TextBox ID="txtpageno" onkeypress="return isNumberKey(event);" runat="server" CssClass="btextforbookright"
                                                                Enabled="False" MaxLength="4"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 15px"></td>
                                                        <td>
                                                            <asp:Label ID="lbpagetyp" runat="server" CssClass="TextField" Text="Page Type"></asp:Label></td>
                                                        <td>

                                                            <asp:DropDownList ID="drppagetype" runat="server" CssClass="dropdownforbook" Enabled="False">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 20px"></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>

                                    </table>


                                    <table id="addetails" style="display: none" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbadtype" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>

                                                <asp:DropDownList ID="drpbooktype" runat="server" Style="width: 100px" CssClass="dropdownforbook" Enabled="False">
                                                </asp:DropDownList><input type="button" value="R" runat="server" style="height: 18px; width: 20px; color: red" id="btnfmg" class="buttonsmall" />
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:Label ID="lbcolor" runat="server" CssClass="TextField" Text="Color"></asp:Label></td>
                                            <td>

                                                <asp:DropDownList ID="drpcolor" runat="server" CssClass="dropdownforbook" Enabled="False">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbadcat" runat="server" CssClass="TextField" Text="Ad Category"></asp:Label></td>
                                            <td>

                                                <asp:DropDownList ID="drpadcategory" runat="server" CssClass="dropdownforbook" AutoPostBack="false"
                                                    Enabled="False">
                                                </asp:DropDownList>
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:Label ID="lbadscat" runat="server" CssClass="TextField" Text="Ad Sub Category"></asp:Label></td>
                                            <td>

                                                <asp:DropDownList ID="drpadsubcategory" runat="server" CssClass="dropdownforbook"
                                                    Enabled="False">
                                                    <asp:ListItem Value="0" Selected="True">Select Ad S Cat</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <%-- Other Sub Categories --%>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbadscat3" runat="server" CssClass="TextField" Text="Ad Sub Category 3"></asp:Label></td>
                                            <td>

                                                <asp:DropDownList ID="drpadcat3" runat="server" CssClass="dropdownforbook"
                                                    Enabled="False">
                                                    <asp:ListItem Value="0" Selected="True">Select Ad S Cat</asp:ListItem>
                                                </asp:DropDownList>

                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:Label ID="lbadscat4" runat="server" CssClass="TextField" Text="Ad Sub Category 4"></asp:Label></td>
                                            <td>

                                                <asp:DropDownList ID="drpadcat4" runat="server" CssClass="dropdownforbook"
                                                    Enabled="False">
                                                    <asp:ListItem Value="0" Selected="True">Select Ad S Cat</asp:ListItem>

                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbadscat5" runat="server" CssClass="TextField" Text="Ad Sub Category 5"></asp:Label></td>
                                            <td>

                                                <asp:DropDownList ID="drpadcat5" runat="server" CssClass="dropdownforbook"
                                                    Enabled="False">
                                                    <asp:ListItem Value="0" Selected="True">Select Ad S Cat</asp:ListItem>
                                                </asp:DropDownList>

                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:Label ID="lbappby" runat="server" CssClass="TextField" Text="App  By"></asp:Label></td>
                                            <td>

                                                <asp:TextBox ID="txtappby" CssClass="btextforbook" runat="server" Enabled="False"></asp:TextBox>

                                            </td>
                                        </tr>
                                        <%-- /////////////////////// --%>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbaudit" runat="server" CssClass="TextField" Text="Audit"></asp:Label>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="txtaudit" CssClass="btextforbook" runat="server" Enabled="False"></asp:TextBox>

                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:Label ID="lbuom" runat="server" CssClass="TextField" Text="UOM"></asp:Label>
                                            </td>
                                            <td>

                                                <asp:DropDownList ID="drpuom" runat="server" CssClass="dropdownforbook" Enabled="False"
                                                    OnSelectedIndexChanged="drpuom_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <%--    ////////////////add anuja/////////////////--%>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblindustry" runat="server" CssClass="TextField" Text="Brand"></asp:Label></td>
                                            <td>

                                                <asp:TextBox ID="txtindustry" runat="server" CssClass="btextforbook" Enabled="true">
                                                </asp:TextBox>
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:Label ID="lblproductcat" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>

                                                <asp:DropDownList ID="drpproductcat" runat="server" CssClass="dropdownforbook" Enabled="true">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbproduct" runat="server" CssClass="TextField" Text="Product"></asp:Label></td>
                                            <td colspan="4">

                                                <asp:TextBox ID="txtproduct" runat="server" CssClass="btextadtype" MaxLength="50"></asp:TextBox>

                                            </td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbbrand" runat="server" CssClass="TextField" Text="Brand"></asp:Label></td>
                                            <td>

                                                <asp:TextBox ID="drpbrand" runat="server" CssClass="btextforbook" Enabled="False">
                                                </asp:TextBox>
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:Label ID="lbvarient" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>

                                                <asp:DropDownList ID="drpvarient" runat="server" CssClass="dropdownforbook" Enabled="true">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <asp:Label ID="lbcamp" runat="server" CssClass="TextField" Text="Label"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtcamp" runat="server" CssClass="btextforbook" Enabled="False"
                                                    MaxLength="50"></asp:TextBox>
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:Label ID="lbcaption" runat="server" CssClass="TextField" Text="Caption"></asp:Label>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="txtcaption" runat="server" TextMode="multiline" CssClass="btextforbook"
                                                    Enabled="False" MaxLength="500"></asp:TextBox>

                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbmat" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="drpmatsta" runat="server" CssClass="dropdownforbook" Enabled="False">
                                                    <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                                    <asp:ListItem Value="attached">Attached-Material</asp:ListItem>
                                                    <asp:ListItem Value="await">Await-Material</asp:ListItem>
                                                    <asp:ListItem Value="Revised">Revised-Material</asp:ListItem>
                                                    <asp:ListItem Value="hardcopy">Hard Copy</asp:ListItem>
                                                    <asp:ListItem Value="softcopy">Soft Copy</asp:ListItem>
                                                    <asp:ListItem Value="cd">CD</asp:ListItem>
                                                    <asp:ListItem Value="asonmatter">As on Matter</asp:ListItem>
                                                    <asp:ListItem Value="repmaterial">Repeat Material</asp:ListItem>
                                                    <asp:ListItem Value="modem">Modem</asp:ListItem>
                                                    <asp:ListItem Value="ftp">FTP</asp:ListItem>
                                                    <asp:ListItem Value="email">E-Mail</asp:ListItem>
                                                    <asp:ListItem Value="compose">Compose</asp:ListItem>
                                                    <asp:ListItem Value="redesign">Re-design</asp:ListItem>
                                                    
                                                    <asp:ListItem Value="other">Others</asp:ListItem>
                                                </asp:DropDownList>

                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:Label ID="lblbartertype" runat="server" CssClass="TextField"></asp:Label></td>

                                            <td>
                                                <asp:TextBox ID="txtbartertype" runat="server" CssClass="btextforbook"
                                                    Enabled="False" MaxLength="50"></asp:TextBox>
                                            </td>
                                            <td></td>
                                        </tr>
                                    </table>

                                    <table id="tblbill" style="display: none;" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblbillcycle" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>

                                                <asp:DropDownList ID="drpbillcycle" runat="server" CssClass="dropdownforbook" Enabled="False">
                                                </asp:DropDownList>

                                            </td>
                                            <td>
                                                <asp:Label ID="lblrevenuecenter" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>

                                                <asp:DropDownList ID="drprevenue" runat="server" CssClass="dropdownforbook" Enabled="False">
                                                </asp:DropDownList>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblpaymenttype" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="drppaymenttype" runat="server" onMouseWheel="return false;" CssClass="dropdownforbook" Enabled="False">
                                                </asp:DropDownList></td>
                                            <td>
                                                <asp:Label ID="lbbillstatus" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="drpbillstatus" runat="server" CssClass="dropdownforbook" Enabled="False">
                                                </asp:DropDownList></td>
                                            <td>&nbsp;</td>

                                        </tr>
                                        <tr id="cashrecvd" style="display: none;">
                                            <td id="Td1" runat="server">
                                                <asp:Label ID="Label2" runat="server" CssClass="TextField" Text="Cash Discount"></asp:Label></td>
                                            <td id="Td2" onkeypress="return notchar2();" runat="server">
                                                <asp:TextBox ID="txtcashdiscount" runat="server" CssClass="btextforbookright">
                                                </asp:TextBox></td>
                                            <td id="Td3" runat="server">
                                                <asp:Label ID="lblcashrecieved" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td id="Td4" onkeypress="return notchar2();" runat="server">
                                                <asp:TextBox ID="drpcashrecieved" runat="server" CssClass="btextforbookright">
                                                </asp:TextBox></td>

                                        </tr>
                                        <tr>
                                            <td id="tdcarname" runat="server" style="display: none">
                                                <asp:Label ID="lbcardname" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td align="left" valign="top" id="tdtxtcarname" style="display: none">
                                                <asp:TextBox ID="txtcardname" runat="server" CssClass="btextforbook"></asp:TextBox></td>
                                            <td id="tdtype" style="display: none">
                                                <asp:Label ID="lbtype" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td id="tddrptyp" style="display: none">
                                                <asp:DropDownList ID="drptype" runat="server" CssClass="dropdownforbook"></asp:DropDownList></td>
                                            <td></td>
                                        </tr>

                                        <tr>
                                            <td id="tdexdat" style="display: none">
                                                <asp:Label ID="lbexdate" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td align="left" valign="top" id="tdtxtexdat" style="display: none;">
                                                <asp:DropDownList ID="drpmonth" runat="server" CssClass="drpsmall">
                                                    <asp:ListItem Selected="True" Value="0">Month</asp:ListItem>
                                                    <asp:ListItem Value="1">Jan</asp:ListItem>
                                                    <asp:ListItem Value="2">Feb</asp:ListItem>
                                                    <asp:ListItem Value="3">Mar</asp:ListItem>
                                                    <asp:ListItem Value="4">Apr</asp:ListItem>
                                                    <asp:ListItem Value="5">May</asp:ListItem>
                                                    <asp:ListItem Value="6">Jun</asp:ListItem>
                                                    <asp:ListItem Value="7">Jul</asp:ListItem>
                                                    <asp:ListItem Value="8">Aug</asp:ListItem>
                                                    <asp:ListItem Value="9">Sep</asp:ListItem>
                                                    <asp:ListItem Value="10">Oct</asp:ListItem>
                                                    <asp:ListItem Value="11">Nov</asp:ListItem>
                                                    <asp:ListItem Value="12">Dec</asp:ListItem>
                                                </asp:DropDownList><asp:DropDownList ID="drpyear" runat="server" CssClass="drpsmall">
                                                    <asp:ListItem Selected="true" Value="0">Year</asp:ListItem>
                                                    <asp:ListItem Value="2008">08</asp:ListItem>
                                                    <asp:ListItem Value="2009">09</asp:ListItem>
                                                    <asp:ListItem Value="2010">10</asp:ListItem>
                                                    <asp:ListItem Value="2011">11</asp:ListItem>
                                                    <asp:ListItem Value="2012">12</asp:ListItem>
                                                    <asp:ListItem Value="2013">13</asp:ListItem>
                                                    <asp:ListItem Value="2014">14</asp:ListItem>
                                                    <asp:ListItem Value="2015">15</asp:ListItem>
                                                    <asp:ListItem Value="2016">16</asp:ListItem>
                                                    <asp:ListItem Value="2017">17</asp:ListItem>
                                                    <asp:ListItem Value="2018">18</asp:ListItem>
                                                    <asp:ListItem Value="2019">19</asp:ListItem>
                                                    <asp:ListItem Value="2020">20</asp:ListItem>
                                                    <asp:ListItem Value="2021">21</asp:ListItem>
                                                    <asp:ListItem Value="2022">22</asp:ListItem>
                                                    <asp:ListItem Value="2023">23</asp:ListItem>
                                                    <asp:ListItem Value="2024">24</asp:ListItem>
                                                    <asp:ListItem Value="2025">25</asp:ListItem>
                                                    <asp:ListItem Value="2026">26</asp:ListItem>
                                                    <asp:ListItem Value="2027">27</asp:ListItem>
                                                    <asp:ListItem Value="2028">28</asp:ListItem>
                                                    <asp:ListItem Value="2029">29</asp:ListItem>
                                                    <asp:ListItem Value="2030">30</asp:ListItem>
                                                </asp:DropDownList></td>
                                            <td id="tdcardno" style="display: none">
                                                <asp:Label ID="lbcardno" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td id="tdtxtcarno" style="display: none">
                                                <asp:TextBox ID="txtcardno" runat="server" MaxLength="20" CssClass="btextforbookright"></asp:TextBox></td>
                                            <td></td>
                                        </tr>

                                        <tr>
                                            <td id="tdchqno" runat="server" style="display: none">
                                                <asp:Label ID="lbchqno" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td id="tdtextchqno" runat="server" style="display: none">
                                                <asp:TextBox ID="ttextchqno" runat="server" CssClass="btextforbook" onkeypress="return rateenter(event)" MaxLength="16"></asp:TextBox></td>
                                            <td id="tdchqamt" runat="server" style="display: none">
                                                <asp:Label ID="lbchqamt" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td align="left" valign="top" id="tdtextchqamt" style="display: none">
                                                <asp:TextBox ID="ttextchqamt" runat="server" CssClass="btextforbook" onkeypress="return rateenter(event)"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td id="tdchqdate" style="display: none">
                                                <asp:Label ID="lbchqdate" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td id="tdtextchqdate" style="display: none">
                                                <asp:TextBox ID="ttextchqdate" runat="server" CssClass="btextforbook"></asp:TextBox></td>
                                            <td id="tdbankname" style="display: none">
                                                <asp:Label ID="lbbankname" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td id="tdtextbankname" style="display: none">
                                                <asp:TextBox ID="ttextbankname" runat="server" CssClass="btextforbook"></asp:TextBox></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td id="tdourbank" style="display: none">
                                                <asp:Label ID="lbourbank" runat="server" Text="Our Bank" CssClass="TextField"></asp:Label></td>
                                            <td id="tdtextourbank" style="display: none">
                                                <asp:DropDownList ID="drpourbank" runat="server" CssClass="dropdownforbook"></asp:DropDownList></td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <asp:Label ID="lblbillsize" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td valign="top" align="left">

                                                <asp:TextBox ID="txtbillwidth" CssClass="btextsmallsizerig" onkeypress="return rateenter(event);" runat="server" Enabled="False"
                                                    MaxLength="4"></asp:TextBox>&nbsp;&nbsp;x&nbsp;&nbsp;
                                                        <asp:TextBox ID="txtbillheight" CssClass="btextsmallsizerig" onkeypress="return rateenter(event);" runat="server" Enabled="False"
                                                            MaxLength="4"></asp:TextBox>
                                                <asp:Label ID="lbbilluom" runat="server" CssClass="TextFielduom"></asp:Label>

                                            </td>
                                            <td>
                                                <asp:Label ID="lblbillto" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>

                                                <asp:DropDownList ID="drpbillto" runat="server" CssClass="dropdownforbook" Enabled="False">
                                                </asp:DropDownList>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td id="tdrec" style="display: none">
                                                <asp:Label ID="lbreceipt" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td align="left" valign="top" id="receipt" style="display: none">

                                                <asp:TextBox ID="txtreceipt" runat="server" CssClass="btextforbookright" Enabled="False"
                                                    MaxLength="4" onkeypress="return notchar2();"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:Label ID="lbbillamtlocal" runat="server" CssClass="TextField" Text="Local Curr. Bill Amt"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtbillamt" runat="server" CssClass="btextforbookright" Enabled="False"
                                                    onkeypress="return notchar2();"></asp:TextBox>
                                                <span id="print" style="display: none">
                                                    <asp:Label ID="lbprint" runat="server" CssClass="TextFieldprint"></asp:Label></span>
                                            </td>


                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbltradedisc" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>

                                                <asp:TextBox ID="txttradedisc" onkeypress="return notchar2(event);" runat="server" CssClass="btextsmallsizerig"
                                                    Enabled="False"></asp:TextBox>
                                                <input cssclass="TextField" type="checkbox" id="chktrade" onclick="blankGross();" disabled="disabled" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lbbillamt" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>

                                                <asp:TextBox ID="txtbillamtlocal" runat="server" CssClass="btextforbookright" Enabled="False"
                                                    onkeypress="return notchar2();"></asp:TextBox>

                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <asp:Button runat="server" Height="20px" Width="100px" ID="multibilling" Text="Multibilling" />
                                            </td>
                                            <td>
                                                <div>
                                                    <input type="button" id="Btnaddrow" runat="server" style="width: 70px; height: 20px; display: none; text-align: center; font-size: 11px; font-family: Verdana;"
                                                        value="Add Row" onclick="javascript: return CreateNewRow();" />
                                                </div>


                                            </td>
                                            <td id="Td5" align="left" runat="server" colspan='1'>
                                                <div>
                                                    <input type="button" id="btnhide" runat="server" style="width: 70px; height: 20px; display: none; text-align: center; font-size: 11px; font-family: Verdana;"
                                                        value="Hide" onclick="javascript: return hide_grid();" />
                                                </div>
                                            </td>
                                        </tr>

                                        <tr id="billhold" runat="server">
                                            <td>
                                                <asp:Label ID="lblholdbill" runat="server" Text="Hold Billing" CssClass="TextField"></asp:Label></td>
                                            <td colspan="4">
                                                <input cssclass="TextField" type="checkbox" id="chkholdbill" disabled="disabled" />
                                            </td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblclientcatdisc" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtclientcatdisc" runat="server" CssClass="btextforbook" Enabled="False"
                                                    MaxLength="500"></asp:TextBox></td>
                                            <td>
                                                <asp:Label ID="lblclientcatamt" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtclientcatam" runat="server" CssClass="btextforbook" Enabled="False"
                                                    MaxLength="500"></asp:TextBox></td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblflatfreqdisc" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtflatfreqdisc" runat="server" CssClass="btextforbook" Enabled="False"
                                                    MaxLength="500"></asp:TextBox></td>
                                            <td>
                                                <asp:Label ID="lblflatfreqamt" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtflatfreqamt" runat="server" CssClass="btextforbook" Enabled="False"
                                                    MaxLength="500"></asp:TextBox></td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblcatdisc" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtcatdisc" runat="server" CssClass="btextforbook" Enabled="False"
                                                    MaxLength="500"></asp:TextBox></td>
                                            <td>
                                                <asp:Label ID="lblcatamt" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtcatamt" runat="server" CssClass="btextforbook" Enabled="False"
                                                    MaxLength="500"></asp:TextBox></td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbbillremark" runat="server" Text="Bill Remark" CssClass="TextField"></asp:Label></td>
                                            <td colspan="4">

                                                <asp:TextBox ID="txtbillremark" runat="server" CssClass="btextadtype" TextMode="MultiLine"
                                                    Enabled="False" MaxLength="500"></asp:TextBox>
                                            </td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                    </table>


                                    <table id="tblrate" style="display: none" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbscheme" runat="server" CssClass="TextField" Text="Scheme Type"></asp:Label></td>
                                            <td>

                                                <asp:TextBox ID="drpscheme" runat="server" CssClass="btextforbookrightsmall" Enabled="False"></asp:TextBox>

                                            </td>
                                            <td style="width: 15px"></td>
                                            <td>
                                                <asp:Label ID="lbratecode" runat="server" CssClass="TextField" Text="Rate Code"></asp:Label></td>
                                            <td>

                                                <asp:DropDownList ID="txtratecode" runat="server" CssClass="btextforbookrightsmalldrop" Enabled="False">
                                                </asp:DropDownList>

                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblcardrate" runat="server" CssClass="TextField"></asp:Label>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="txtcardrate" CssClass="btextforbookrightsmall" runat="server" Enabled="False"></asp:TextBox>

                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:Label ID="lblcardamt" runat="server" CssClass="TextField"></asp:Label>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="txtcardamt" CssClass="btextforbookrightsmall" runat="server" Enabled="False"></asp:TextBox>

                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbdealtype" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>

                                                <asp:TextBox ID="txtdealrate" runat="server" CssClass="btextforbookrightsmall" Enabled="False"></asp:TextBox>

                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:Label ID="lbdeviation" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>

                                                <asp:TextBox ID="txtdeviation" runat="server" CssClass="btextforbookrightsmall" Enabled="False"></asp:TextBox>
                                                <asp:Button ID="btndeal" runat="server" CssClass="buttonsmall" Enabled="False" />
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbagreed" runat="server" CssClass="TextField" Text="Agreed Rate"></asp:Label>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="txtagreedrate" CssClass="btextforbookrightsmall" onpaste="return false;" onkeypress="return rateenter(event);" runat="server" Enabled="False"
                                                    MaxLength="10"></asp:TextBox>
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:Label ID="lbagreamo" runat="server" CssClass="TextField" Text="Agreed Amount"></asp:Label>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="txtagreedamt" onpaste="return false;" CssClass="btextforbookrightsmall" onkeypress="return rateenter(event);" runat="server" Enabled="False"
                                                    MaxLength="10"></asp:TextBox>
                                            </td>
                                            <td>
                                                <input cssclass="TextField" type="checkbox" id="chkgstinc" onclick="gstcal();" disabled="disabled" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbldiscount" runat="server" CssClass="TextField"></asp:Label>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="txtdiscount" CssClass="btextforbookrightsmall" runat="server" Enabled="False"></asp:TextBox>

                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:Label ID="lbldiscpre" runat="server" CssClass="TextField"></asp:Label>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="txtdiscpre" CssClass="btextforbookrightsmall" runat="server" Enabled="False"></asp:TextBox>

                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr id="translationdisc" runat="server">
                                            <td>
                                                <asp:Label ID="lbltranslationdisc" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>

                                                <asp:TextBox ID="txttranslationdisc" runat="server" CssClass="btextforbookrightsmall" Enabled="False"
                                                    onkeypress="return notchar2(event);"></asp:TextBox>

                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:Label ID="lblpospremdisc" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>

                                                <asp:TextBox ID="txtpospremdisc" runat="server" CssClass="btextforbookrightsmall" Enabled="False"
                                                    onkeypress="return notchar2(event);"></asp:TextBox>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbpagepostamt" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>

                                                <asp:TextBox ID="txtpageamt" runat="server" CssClass="btextforbookrightsmall" Enabled="False"></asp:TextBox>

                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:Label ID="lbpremium" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>

                                                <asp:TextBox ID="txtpremper" runat="server" CssClass="btextforbookrightsmall" Enabled="False"></asp:TextBox>

                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbspecialamo" runat="server" CssClass="TextField" Text="Special Discount"></asp:Label>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="txtspedisc" CssClass="btextforbookrightsmall" onkeypress="return rateenter(event);" runat="server" Enabled="False"
                                                    MaxLength="10"></asp:TextBox>
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:Label ID="lbspediscper" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>

                                                <asp:TextBox ID="txtspediscper" runat="server" onkeypress="return rateenter(event);" CssClass="btextforbookrightsmall" Enabled="False"
                                                    MaxLength="10"></asp:TextBox>
                                                <asp:Label ID="lbllocalcurr" runat="server" CssClass="TextField" Text="Local Curr. Amount"></asp:Label>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbspace" runat="server" CssClass="TextField" Text="Space Discount"></asp:Label></td>
                                            <td>

                                                <asp:TextBox ID="txtspacedisc" onkeypress="return rateenter(event);" CssClass="btextforbookrightsmall" runat="server" Enabled="False"
                                                    MaxLength="10" OnTextChanged="txtspacedisc_TextChanged"></asp:TextBox>

                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:Label ID="lbspadiscper" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>

                                                <asp:TextBox ID="txtspadiscper" onkeypress="return rateenter(event);" runat="server" CssClass="btextforbookrightsmall" Enabled="False"
                                                    MaxLength="10"></asp:TextBox>
                                                <asp:TextBox ID="txtgrossamt" runat="server" CssClass="btextforbookrightsmall" Enabled="False"></asp:TextBox>

                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbspechar" runat="server" CssClass="TextField" Text="Special Charges"></asp:Label>
                                            </td>
                                            <td>

                                                <asp:TextBox ID="txtextracharges" CssClass="btextforbookrightsmall" onkeypress="return rateenter(event);" runat="server" Enabled="False"
                                                    MaxLength="10"></asp:TextBox>
                                            </td>
                                            <td></td>

                                            <td>
                                                <div id="addagency" runat="server">
                                                    <asp:Label ID="lblagencyaddcomm" runat="server" CssClass="TextField" Text="Addl Agency Comm."></asp:Label>
                                                </div>
                                            </td>
                                            <td>
                                                <div id="addagencycomm" runat="server">

                                                    <asp:TextBox ID="txtaddagencycommrate" CssClass="btextforbookrightsmall_comm" Style="width: 30px" onkeypress="return notchar2_book(event,this);" runat="server" Enabled="False"
                                                        MaxLength="10"></asp:TextBox><font class="TextField">%</font><asp:TextBox ID="txtaddagencycommrateamt" CssClass="btextforbookrightsmall_comm" onkeypress="return notchar2_book(event,this);" runat="server" Enabled="False"
                                                            MaxLength="10"></asp:TextBox>
                                                </div>

                                            </td>
                                            <td valign="bottom"></td>

                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbgrossamt" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtgrossamtlocal" runat="server" CssClass="btextforbookrightsmall" Enabled="False"></asp:TextBox>

                                            </td>
                                            <td></td>
                                            <td>

                                                <asp:Label ID="lblRetainercomm" runat="server" CssClass="TextField" Text="Retainer Comm."></asp:Label>
                                            </td>
                                            <!--for retainer comm>-->
                                            <td>
                                                <asp:TextBox ID="txtRetainercomm" CssClass="btextforbookrightsmall_comm" Style="width: 30px" runat="server" Enabled="False" onkeypress="return notchar2_book(event,this);"
                                                    MaxLength="10"></asp:TextBox><font class="TextField">%</font><asp:TextBox ID="txtRetainercommamt" CssClass="btextforbookrightsmall_comm" runat="server" Enabled="False" onkeypress="return notchar2_book(event,this);"
                                                        MaxLength="10"></asp:TextBox><asp:Button ID="btnshgrid" runat="server" CssClass="buttonsmall" Text="Get Rate" Enabled="False"></asp:Button>
                                                <asp:Button ID="btnsharing" runat="server" CssClass="buttonsmall" Text="Sharing" Enabled="False" />
                                            </td>
                                            <!--end of retainer comm>-->
                                        </tr>
                                    </table>

                                    <table id="tbbox" style="display: none" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbboxcode" runat="server" CssClass="TextField" Text="Box Code"></asp:Label></td>
                                            <td valign="top">

                                                <asp:DropDownList ID="drpboxcode" runat="server" CssClass="dropdownforbook" Enabled="False"
                                                    OnSelectedIndexChanged="drpboxcode_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbboxno" runat="server" CssClass="TextField" Text="Box No."></asp:Label></td>
                                            <td></td>
                                            <td>

                                                <asp:TextBox ID="txtboxno" runat="server" Enabled="false" CssClass="btextforbook"></asp:TextBox>

                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td colspan="2">

                                                <asp:CheckBox ID="chkage" Text="same as Agency" runat="server" CssClass="TextField" />
                                                <asp:CheckBox ID="chkclie" Text="same as Client" runat="server" CssClass="TextField" />

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbboxadd" runat="server" CssClass="TextField" Text="Box Address"></asp:Label></td>
                                            <td colspan="4">

                                                <asp:TextBox ID="txtboxaddress" onkeypress="return notchar2(event);" MaxLength="500" runat="server"
                                                    CssClass="btextadtype" OnTextChanged="txtinsertion_TextChanged1" Enabled="False"
                                                    TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblcancelcharges" runat="server" CssClass="TextField" Text="Cancle Charges"></asp:Label>
                                            </td>
                                            <td>
                                                <input cssclass="TextField" type="checkbox" id="chkcanclecharges" onclick="blankGross();" disabled="disabled" />
                                            </td>
                                            <td></td>
                                            <td></td>
                                            <td></td>

                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblcoupantype" runat="server" Text="CPN Type" CssClass="TextField"></asp:Label></td>
                                            <td valign="top">
                                                <asp:DropDownList ID="drpcoutype" Enabled="false" runat="server"
                                                    CssClass="dropdownforbook" TabIndex="20">
                                                </asp:DropDownList></td>
                                            <td>
                                                <asp:Label ID="lblcouno" runat="server" Text="CPN No." CssClass="TextField"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtcouno" TabIndex="20" runat="server" CssClass="btextforbookrateqbc" Enabled="false"></asp:TextBox></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblcolexec" runat="server" Text="Coll. Exec." CssClass="TextField"></asp:Label></td>
                                            <td valign="top">
                                                <asp:TextBox ID="txtcolexec" runat="server" CssClass="btext3"></asp:TextBox></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 40px"></td>
                                        </tr>
                                    </table>
                                    <table id="tbvts" style="display: none" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblciragency" runat="server" CssClass="TextField" Text="Circulation Agency"></asp:Label></td>
                                            <td valign="top" colspan="4">

                                                <asp:TextBox ID="txtciragency" runat="server" CssClass="btextadtype" Enabled="False"
                                                    MaxLength="50"></asp:TextBox>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblvts" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td valign="top">

                                                <asp:TextBox ID="txtvts" onkeypress="return notchar2(event);" runat="server" CssClass="btextforbookright"
                                                    Enabled="False" MaxLength="10"></asp:TextBox>

                                            </td>
                                            <td>
                                                <asp:Label ID="lblinvoice" runat="server" CssClass="TextField"></asp:Label></td>

                                            <td>

                                                <asp:TextBox ID="txtinvoice" runat="server" CssClass="btextforbookright" Enabled="False"
                                                    onkeypress="return notchar2(event);" MaxLength="4"></asp:TextBox>&nbsp;
                                                    
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>

                                            <td>
                                                <asp:Label ID="lblciredition" runat="server" Text="Edition" CssClass="TextField"></asp:Label></td>

                                            <td>

                                                <asp:TextBox ID="txtciredition" runat="server" CssClass="btextforbookright" Enabled="False"></asp:TextBox>&nbsp;
                                                    
                                            </td>
                                            <td>
                                                <asp:Label ID="lblcirrate" runat="server" CssClass="TextField" Text="Rate"></asp:Label></td>
                                            <td valign="top">

                                                <asp:TextBox ID="txtcirrate" runat="server" CssClass="btextforbookright"
                                                    Enabled="False"></asp:TextBox>

                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblbilladdress" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td colspan="4">

                                                <asp:TextBox ID="txtbilladdress" TextMode="multiLine" runat="server" CssClass="btextadtype"
                                                    Enabled="False"></asp:TextBox>
                                            </td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 25px"></td>
                                        </tr>
                                    </table>
                    </div>
                </td>
            </tr>
        </table>
        </td>
                                    </tr>
                                    </table>

           
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td align="left" id="tblinsert" runat="server"></td>
            </tr>
        </table>
        <div id="showteamdiv" style="z-index: 0; background-color: #e1e1e1; border-right: thin groove; border-top: thin groove; border-left: thin groove; border-bottom: thin groove; font-size: 8pt; position: absolute; display: none; height: auto; width: 109px; top: 200px; left: 100px;"></div>
        <div id="showselectedition" style="z-index: 0; background-color: #e1e1e1; border-right: thin groove; border-top: thin groove; border-left: thin groove; border-bottom: thin groove; font-size: 8pt; position: absolute; display: none; height: auto; width: 109px; top: 200px; left: 100px;"></div>
        <div style="display: block; position: absolute; left: 540px; top: 155px; height: 180px; width: 548px" id="divOuter">
            <font class="TextField">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Select Edition </font>
            <select id="drpedition" onchange="javascript:return getButtonId();" class="btextforbook" style="height: 17px;">
                <option>--Select--</option>
            </select>
            <font class="TextField">Select Insertion </font>
            <select id="drpinsertion" onchange="javascript:return getButtonId();" class="btextforbook" style="width: 80px; height: 17px;">
                <option>--Select--</option>
            </select>
            <table id="Table1" align="left" border="0" cellpadding="0" cellspacing="0" height="180">

                <tr>
                    <td style="height: 191px; width: 469px;">

                        
                            <asp:Panel ID="Panel1" onmousedown="getImagePosition();" ondoubleclick="return false;" Style="margin-top: 15px; left: 73px; width: 520px;position: absolute;"  runat="server" BackColor="Ivory" BorderWidth="2px" EnableTheming="True" Wrap="True" CssClass="fixdrag1" Height="180px"  ScrollBars="Both">
                            <div id="Divn1" style="width: 60px; height: 80px; border-right: thin groove;Height="180px"  border-top: thin groove; border-left: thin groove; border-bottom: thin groove; position: absolute; font-size: 6pt; visibility: hidden;">
                                &nbsp;
                            </div>
                            <div id="Divpg1" style="width: 20px; height: 10px; border-right: thin groove; border-top: thin groove; border-left: thin groove; border-bottom: thin groove; position: absolute; font-size: 8pt; visibility: hidden; left: 14px; top: 46px;"></div>

                        </asp:Panel>


                    </td>
                </tr>

                <tr>
                    <td align="right">

                        <asp:Button ID="btnPaginatedVol" Enabled="false" CssClass="topbutton" runat="server" Text="PlacedVol" />
                        <asp:Button ID="btnRefresh" Enabled="false" CssClass="topbutton" runat="server" Text="Refresh" />
                        <asp:Button ID="btnPaginate" Enabled="false" CssClass="topbutton" runat="server" Text="Paginate" />
                        <asp:Button ID="btnPreference" Enabled="false" CssClass="topbutton" runat="server" Text="Preference" />
                        <asp:Button ID="btnSpaceCheck" Enabled="false" CssClass="topbutton" Width="100px" runat="server" Text="Space Availability" />
                        <asp:Button ID="btnsavepaginate" CssClass="topbutton" Width="100px" runat="server" Text="Save&Paginate"></asp:Button>

                    </td>
                </tr>
                <tr>
                    <td height="5px"></td>
                </tr>
                <tr>
                    <td>
                        <div id="divspace" style="position: absolute; overflow: auto; height: 100px; display: none; border-right: thin groove; border-top: thin groove; border-left: thin groove; border-bottom: thin groove;">
                            <asp:GridView ID="grd_SpaceCheck" runat="server" Width="480px" Height="50px" AutoGenerateColumns="False" CssClass="dtGrid" AllowPaging="false" OnPageIndexChanging="grd_SpaceCheck_PageIndexChanging" PageSize="4">
                                <Columns>
                                    <asp:BoundField DataField="page_no" HeaderText="Page No" />
                                    <asp:BoundField DataField="page_colour" HeaderText="Colour" />
                                    <asp:BoundField DataField="ad_volume" HeaderText="Page Vol" />
                                    <asp:BoundField HeaderText="No. of Ads" />
                                    <asp:BoundField HeaderText="Ad Vol" />
                                    <asp:BoundField HeaderText="Free Vol" />
                                </Columns>
                                <HeaderStyle BackColor="#7DAAE3" CssClass="dtGridHd12" ForeColor="White" HorizontalAlign="Center" />
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div id="divspace2" style="position: absolute; overflow: auto; height: 100px; display: none; border-right: thin groove; border-top: thin groove; border-left: thin groove; border-bottom: thin groove;">
                            <asp:GridView ID="GridView1" runat="server" Width="480px" Height="50px" AutoGenerateColumns="False" CssClass="dtGrid" AllowPaging="false" OnPageIndexChanging="grd_SpaceCheck_PageIndexChanging" PageSize="4">
                                <Columns>
                                    <asp:BoundField DataField="page_no" HeaderText="Page No" />
                                    <asp:BoundField DataField="page_colour" HeaderText="Colour" />
                                    <asp:BoundField HeaderText="No. of Ads" />
                                    <asp:BoundField DataField="ad_volume" HeaderText="Page Vol" />
                                    <asp:BoundField HeaderText="Ad Vol" />
                                    <asp:BoundField HeaderText="Free Vol" />
                                </Columns>
                                <HeaderStyle BackColor="#7DAAE3" CssClass="dtGridHd12" ForeColor="White" HorizontalAlign="Center" />
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
            </table>

        </div>

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
                    <input id="hiddenclickdate" type="hidden" size="1" name="hiddencompcode" runat="server" />
                    <input id="hiddeninserts" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddenagency" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddencioid" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddenvar" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddenbillto" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddenbillpay" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddenprefix" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddensufix" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddenreceiptno" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddeninsertion" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddenboxno" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddenroadcat" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddenrodatetime" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddenroperm" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddenspacearea" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddenratecode" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddencattype" type="hidden" size="1" name="inserts" runat="server" />&nbsp;
                <input id="hiddenaudit" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddenvat" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddencirculation" type="hidden" size="1" name="inserts" runat="server" />
                    <input type="hidden" id="hiddencompuser" runat="server" />
                    <input type="hidden" id="hiddenadmin" runat="server" />
                    <br />
                    <input id="hiddenscheme" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddenprereceipt" type="hidden" size="1" name="inserts" runat="server" />
                    <input type="hidden" id="pkgname" />
                    <input type="hidden" id="hidval" />
                    <input type="hidden" id="hidcount" />
                    <input type="hidden" id="hiddencalendar" runat="server" />
                    <input type="hidden" id="hiddenadtype" runat="server" />
                    <input type="hidden" id="hidpubdate" runat="server" />
                    <input type="hidden" id="hidpub" runat="server" />
                    <input type="hidden" id="hidpubcent" runat="server" />
                    <input type="hidden" id="hidedition" runat="server" />
                    <input type="hidden" id="hidsuppliment" runat="server" />
                    <input type="hidden" id="hiddenmodifyinsert" runat="server" />
                    <input id="hiddenprevamt" type="hidden" size="1" name="inserts" runat="server" />
                    <input id="hiddenappserverpath" type="hidden" runat="server" />
                    <input id="hiddencenter" runat="server" type="hidden" name="hiddencenter" />
                    <input id="hiddenadsubcategory" runat="server" type="hidden" name="hiddenadsubcategory" />
                    <input id="hiddenadscat3" runat="server" type="hidden" name="hiddenadscat3" />
                    <input id="hiddenadscat4" runat="server" type="hidden" name="hiddenadscat4" />
                    <input id="hiddenadscat5" runat="server" type="hidden" name="hiddenadscat5" />
                    <input id="hiddenafency_retainer" runat="server" type="hidden" name="hiddenadscat5" />
                    <input type="hidden" id="hiddenpaymode" runat="server" />
                    <input type="hidden" id="hiddenclientname" runat="server" />
                    <input type="hidden" id="hiddenprint_rec" runat="server" />
                    <input type="hidden" id="hiddenratecheckdate" runat="server" />
                    <input type="hidden" id="hiddenratepremtype" runat="server" />
                    <input type="hidden" id="hiddenaddAgencyComm" runat="server" />
                    <input type="hidden" id="hiddenuom" runat="server" />
                    <input type="hidden" id="hiddencioidformat" runat="server" />
                    <input type="hidden" id="hiddenbuttonidcheck" runat="server" />
                    <input type="hidden" id="hiddenrostatus" runat="server" />
                    <input type="hidden" id="hiddenhidReceipt" runat="server" />
                    <input type="hidden" id="hiddenuomdesc" runat="server" />
                    <input type="hidden" id="hiddenpkgedition" runat="server" />
                    <input type="hidden" id="hiddenvaliddate" runat="server" />
                    <input type="hidden" id="hiddenschemetype" runat="server" />
                    <input type="hidden" id="hiddeninsertwise" runat="server" />
                    <input type="hidden" id="hiddenboxchrgtype" runat="server" />
                    <input type="hidden" id="hiddenuserdisc" runat="server" />
                    <input type="hidden" id="hiddentradedisc" runat="server" />
                    <input type="hidden" id="retcommtype" runat="server" />
                    <input type="hidden" id="retcomm" runat="server" />
                    <input type="hidden" id="currdate" runat="server" />
                    <input type="hidden" id="agncomm_seq_com" runat="server" />
                    <input type="hidden" id="creditreceipt_allow" runat="server" />
                    <input type="hidden" runat="server" id="hidcash" />
                    <input type="hidden" runat="server" id="hidbackdatereceipt" />
                    <input type="hidden" runat="server" id="hiddencashrecieved" />
                    <input type="hidden" id="hiddenconnect" runat="server" />
                    <input type="hidden" id="hiddencirpub" runat="server" />
                    <input type="hidden" id="hiddenciredi" runat="server" />
                    <input type="hidden" id="hiddenserverip" runat="server" />
                    <input type="hidden" id="hiddenbarteramt" runat="server" />
                    <input type="hidden" id="hiddenstopbarterbooking" runat="server" />
                    <input type="hidden" id="hiddencopybooking" runat="server" />
                    <input type="hidden" id="hiddencutofftime" runat="server" />
                    <input type="hidden" id="hiddenagcommflag" runat="server" />
                    <input type="hidden" id="hidattach1" runat="server" />
                    <input type="hidden" id="hidattach2" runat="server" />
                    <input type="hidden" id="hiddencashdiscper" runat="server" />
                    <input type="hidden" id="hiddenorigbranch" runat="server" />
                    <input type="hidden" id="hiddensepcashier" runat="server" />
                    <input type="hidden" id="hiddenmaxdays" runat="server" />
                    <input type="hidden" id="hidspldisedit" runat="server" />
                    <input type="hidden" id="hidshareman" runat="server" />
                    <input type="hidden" id="hidmultisel" runat="server" />
                    <input type="hidden" id="hidspltd" runat="server" />
                    <input type="hidden" id="hiddenrateauditflag" runat="server" />
                    <input type="hidden" id="hiddenrateauditpreferrence" runat="server" />
                    <input type="hidden" id="hidpremedit" runat="server" />
                    <input type="hidden" id="hidsplpremdiscallow" runat="server" />
                    <input type="hidden" id="hidcurr" runat="server" />
                    <input type="hidden" id="hiddenbillamt" runat="server" />
                    <input type="hidden" id="hidcurrency_convrate" runat="server" />
                    <input type="hidden" id="configclient" runat="server" />
                    <input type="hidden" id="hdnrevise" runat="server" />
                    <input type="hidden" id="hdnbranch_name" runat="server" />
                    <input type="hidden" id="hdnfollodate" runat="server" />
                    <input id="hdnadtrackerbokk" type="hidden" runat="server" />
                    <input id="oldboxno" type="hidden" runat="server" />
                    <input id="hndalert1" type="hidden" runat="server" />
                    <input id="hndagalert1" type="hidden" runat="server" />
                    <input id="hdndefpayment" type="hidden" runat="server" />
                    <input type="hidden" id="hiddentranalpremtype" runat="server" />
                    <input type="hidden" id="hiddencancelcharge" runat="server" />
                    <input type="hidden" id="hiddeneiitagcomm" runat="server" />
                    <input type="hidden" id="hiddisceditgrid" runat="server" />
                    <input type="hidden" id="allowprem_card_disc_rate" runat="server" value="C" />
                    <input type="hidden" id="allowpaidchangeper" runat="server" value="Y" />
                    <input type="hidden" id="hiddenquotation" runat="server" />
                    <input type="hidden" id="ena_adsubcataftbill" runat="server" />
                    <input type="hidden" id="Hdnmodbook" runat="server" />
                    <input type="hidden" id="hdnregclient" runat="server" />
                    <input type="hidden" id="hidnprint" runat="server" />
                    <input type="hidden" id="Hiddenbillclear" runat="server" />
                    <input type="hidden" id="hiddensupplimentflag" runat="server" />
                    <asp:TextBox ID="txtfocus" runat="server" Width="0" Height="0" MaxLength="0"></asp:TextBox>
                    <input type="hidden" id="hiddensupplementbillno" runat="server" />
                    <input type="hidden" id="hiddensupplementbilldate" runat="server" />
                    <input type="hidden" id="hdnvts" runat="server" />
                    <input id="hiddenroduplicacycheck" type="hidden" runat="server" />
                    <input id="hdnchkdetailperm" type="hidden" runat="server" />
                    <input id="hdnprefcomngrd" type="hidden" runat="server" />
                    <input id="hidfmgallow" type="hidden" runat="server" />
                    <input id="hdnclientcatdistype" type="hidden" runat="server" />
                    <input id="hdnflatfreqdisctype" type="hidden" runat="server" />
                    <input id="hdncatdisctype" type="hidden" runat="server" />
                    <input type="hidden" id="hdndepo" runat="server" />
                    <input type="hidden" id="hdnagencyname" runat="server" />
                    <input type="hidden" id="hdnagencyaddress" runat="server" />
                    <input id="hdncopybookingpermission" type="hidden" runat="server" />
                    <input id="hdnteamcode" type="hidden" runat="server" />
                    <input id="hdn_sms_link" type="hidden" runat="server" />
                    <input id="hdn_uid" type="hidden" runat="server" />
                    <input id="hdn_pwd" type="hidden" runat="server" />
                    <input id="hdn_sender" type="hidden" runat="server" />
                    <input id="hdnindus" type="hidden" runat="server" />
                    <input id="hdntxttranslationdisc" type="hidden" runat="server" />
                    <input id="hdntxtpospremdisc" type="hidden" runat="server" />
                    <input id="hdntxtpremper" type="hidden" runat="server" />
                    <input id="hdntxtspediscper" type="hidden" runat="server" />
                    <input id="hdntxtspacedisc" type="hidden" runat="server" />
                    <input id="hdntxtaddagencycommrate" type="hidden" runat="server" />
                    <input id="hdntxtRetainercomm" type="hidden" runat="server" />
                    <input id="hdntxtextracharges" type="hidden" runat="server" />
                    <input id="hdntxtspedisc" type="hidden" runat="server" />
                    <input id="hdntxtspadiscper" type="hidden" runat="server" />
                    <input id="hdnbranchf2req" type="hidden" runat="server" />
                    <input id="hdnrevenuecentcd" type="hidden" runat="server" />
                    <input id="hdnbbrnch" type="hidden" runat="server" />
                    <input id="hdnallformname" type="hidden" name="hdnallformname" runat="server" />
                    <input id="hdnsysdate" type="hidden" name="hdnsysdate" runat="server" />
                    <input id="hdninsertsformail" type="hidden" runat="server" />
                    <input id="hdnloginrevcentname" type="hidden" runat="server" />
                    <input id="hdnloginrevcentcd" type="hidden" runat="server" />


                    <input id="hdnprosubcat" type="hidden" runat="server" />
                    <input id="hdntempagcode" type="hidden" runat="server" />
                    
                    <input type="hidden" runat="server" id="hdnpackmaingrp" />
                    <input type="hidden" runat="server" id="hdnpacksubgrp" />
                    
                </td>
            </tr>
        </table>




    </form>
</body>
</html>
