<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RetainerMaster.aspx.cs" EnableEventValidation="false" ValidateRequest="false" Inherits="RetainerMaster" %>

<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx" %>
<%@ Register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Display Ad. Booking & Sheduling News Services Master</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <script language="javascript" type="text/javascript" src="javascript/permission.js"></script>
    <script language="javascript" type="text/javascript" src="javascript/RetainerMaster.js"></script>
    <script language="javascript" type="text/javascript" src="javascript/Validations.js"></script>
    <script language="javascript" type="text/javascript" src="javascript/TreeLibrary.js"></script>
    <script language="javascript" type="text/javascript" src="javascript/givepermission.js"></script>
    <script language="javascript" type="text/javascript" src="javascript/entertotab.js"></script>
    <script language="javascript" type="text/javascript" src="javascript/tree.js"></script>
    <script language="javascript" type="text/javascript" src="javascript/popupcalender.js"></script>
    <link href="css/main.css" type="text/css" rel="stylesheet">
    <script language="javascript">

        if (navigator.appName.indexOf("Microsoft") != -1) {
            document.writeln('<LINK href ="css/main.css" type= "text/css" rel = "stylesheet">');
        }
        else {
            document.writeln('<LINK href ="css/main_mozilla.css" type= "text/css" rel = "stylesheet">');
        }

        ////////////////////bhanu/////////


        var digits = "0123456789";
        var phoneNumberDelimiters = "()- ";
        var validWorldPhoneChars = phoneNumberDelimiters + "+";
        var minDigitsInIPhoneNumber = 1;

        function isInteger(s) {
            var i;
            for (i = 0; i < s.length; i++) {
                var c = s.charAt(i);
                if (((c < "0") || (c > "9"))) return false;
            }
            return true;
        }
        //function trim(s)
        //{   var i;
        //    var returnString = "";
        //    for (i = 0; i < s.length; i++)
        //    {   
        //       var c = s.charAt(i);
        //        if (c != " ") returnString += c;
        //    }
        //    return returnString;
        //}
        function stripCharsInBag(s, bag) {
            var i;
            var returnString = "";
            for (i = 0; i < s.length; i++) {
                var c = s.charAt(i);
                if (bag.indexOf(c) == -1) returnString += c;
            }
            return returnString;
        }

        function checkInternationalPhone(strPhone) {
            var bracket = 3
            strPhone = trim(strPhone)
            if (strPhone.indexOf("+") > 1) return false
            if (strPhone.indexOf("-") != -1) bracket = bracket + 1
            if (strPhone.indexOf("(") != -1 && strPhone.indexOf("(") > bracket) return false
            var brchr = strPhone.indexOf("(")
            if (strPhone.indexOf("(") != -1 && strPhone.charAt(brchr + 2) != ")") return false
            if (strPhone.indexOf("(") == -1 && strPhone.indexOf(")") != -1) return false
            s = stripCharsInBag(strPhone, validWorldPhoneChars);
            return (isInteger(s) && s.length >= minDigitsInIPhoneNumber);
        }

        function ValidateForm(b) {
            var Phone = document.getElementById(b)
            if ((Phone.value == null) || (Phone.value == "")) {
                //		alert("Please Enter your Phone Number")
                //		Phone.focus()
                //		return false
            }
            if (checkInternationalPhone(Phone.value) == false) {
                alert("Please Enter Right Number")
                Phone.value = ""
                Phone.focus()
                return false
            }

            if (document.getElementById(b).value.length < 6 && b != "txtphone1") {
                alert("Min. length can't be less than 6 digit");
                document.getElementById(b).value = "";
                document.getElementById(b).focus();
                return false;
            }
            return true
        }


        ///////////////////////////////

        function notchar2() {
            if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 127) || (event.keyCode == 8) || (event.keyCode == 9)) {
                return true;
            }
            else {
                return false;
            }
        }

        function uppercaseret(a) {

            document.getElementById(a).value = document.getElementById(a).value.toUpperCase();
            return;

        }

        function notchar0(event) {
            //alert(event.which);
            var browser = navigator.appName;
            if (browser != "Microsoft Internet Explorer") {
                if ((event.which >= 48 && event.which <= 57) ||
                (event.which == 127) || (event.which == 37) ||
                (event.which >= 97 && event.which <= 122) ||
                (event.which >= 65 && event.which <= 90) ||
                (event.which == 9 || event.which == 32)) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                if ((event.keyCode >= 48 && event.keyCode <= 57) ||
                (event.keyCode == 127) || (event.keyCode == 37) ||
                (event.keyCode >= 97 && event.keyCode <= 122) ||
                (event.keyCode >= 65 && event.keyCode <= 90) ||
                (event.keyCode == 9 || event.keyCode == 32)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }

        //numeric check
        /*function num()
        {
        if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==32))
        {
        return true;
        }
        else
        {
        alert("Please enter only numeric values");
        return false;
        }
        }*/

        //Special Character Check Validator Function
        function ClientSpecialchar(event) {
            var browser = navigator.appName;
            if (browser != "Microsoft Internet Explorer") {
                if ((event.which >= 48 && event.which <= 57) || (event.which == 8) || (event.which == 189) || (event.which >= 97 && event.which <= 122) || (event.which == 9 || event.which == 32) || (event.which >= 65 && event.which <= 90) || (event.which == 39) || (event.which == 45) || (event.which == 83)) {
                    return true;
                }
                else {

                    return false;
                }
            }
            else {
                if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 8) || (event.keyCode == 189) || (event.keyCode >= 97 && event.keyCode <= 122) || (event.keyCode == 9 || event.keyCode == 32) || (event.keyCode >= 65 && event.keyCode <= 90) || (event.keyCode == 39) || (event.keyCode == 45) || (event.keyCode == 83)) {
                    return true;
                }
                else {

                    return false;
                }
            }
        }

        //Special Character&numeric Check Validator Function
        function ClientSpecialchar1() {

            if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 32)) {
                return true;
            }


            else {
                alert("Please enter only numeric values");
                return false;
            }

            return false;
        }



        /*
        function isEmail(email)
                    {
                    if (document.Form1.txtemailid.value.indexOf("@") != "-1" && document.Form1.txtemailid.value.indexOf(".") != "-1" )
                    return true;
                    else 
                    return false;
                    }
                
        function checkEmail() 
        {
        
        
             if (isEmail(document.Form1.txtemailid.value) == false && document.Form1.txtemailid.value!="")
                        {
                        alert("Enter your correct Email ID");
                        document.Form1.txtemailid.value="";
                        document.Form1.txtemailid.focus();
                    //	document.Form1.txtemailid="";
                        return false;
                        }
        }*/
        //function checkEmail() 
        //{
        //	var theurl=document.getElementById('txtemailid').value;

        //	if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(theurl) || document.getElementById('txtemailid').value=="")
        //	{
        //		return (true)
        //	}
        //	alert("Invalid E-mail Address! Please re-enter.")
        //	document.getElementById('txtemailid').value="";
        //	//alert("mail");
        //	document.getElementById('txtemailid').focus();
        //	return false;
        //}
        function phoneno(event) {
            //alert(event.keyCode);
            var browser = navigator.appName;
            if (event.shiftKey == true)
                return false;
            if (browser != "Microsoft Internet Explorer") {
                if ((event.which == 47) || (event.which == 44)) {
                    return true;
                }



                else if ((event.which == 46)) {
                    return false;
                }


                else if ((event.which >= 48 && event.which <= 57) || (event.which == 9) || (event.which == 0) || (event.which == 8) || (event.which == 11)) {

                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                if ((event.keyCode == 47) || (event.keyCode == 44)) {
                    return true;
                }

                else if ((event.keyCode == 46)) {
                    return false;
                }

                else if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 9) || (event.keyCode == 11) || (event.keyCode == 13) || (event.keyCode == 8) || (event.keyCode == 11)) {

                    return true;
                }
                else {
                    return false;
                }
            }
        }




    </script>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="css/main.css" type="text/css" rel="stylesheet" />
    <link href="css/webcontrol.css" type="text/css" rel="stylesheet">
</head>
<body id="bdy" topmargin="0" leftmargin="0" onload=" document.getElementById('lblsign').disabled=true;loadXML('xml/errorMessage.xml');javascript:return givebuttonpermission('RetainerMaster');" onkeydown="javascript:return tabvalue(event,'txtremarks');" style="background-color: #f3f6fd;">
    <form id="Form1" method="post" runat="server">
        <div id="divempcode" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 0;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:ListBox ID="lstempcode" runat="server" CssClass="btextlist"></asp:ListBox></td>
                </tr>
            </table>
        </div>
        <div id="divmaincdp" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 0;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:ListBox ID="lstmaincdp" Width="400px" Height="120px" runat="server" CssClass="btextlist"></asp:ListBox></td>
                </tr>
            </table>
        </div>
        <div id="divmaincds" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 0;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:ListBox ID="lstmaincds" Width="400px" Height="120px" runat="server" CssClass="btextlist"></asp:ListBox></td>
                </tr>
            </table>
        </div>
        <div id="divagcode" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 0;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:ListBox ID="lstagcode" Width="400px" Height="120px" runat="server" CssClass="btextlist"></asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divgstclty" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 0;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:ListBox ID="lstgstclty" Width="400px" Height="120px" runat="server" CssClass="btextlist"></asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        <div id="div4" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 0;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:ListBox ID="lstretainer" Width="400px" Height="120px" runat="server" CssClass="btextlist"></asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        <table id="OuterTable" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr valign="top">
                <td colspan="2">
                    <uc1:Topbar ID="Topbar1" runat="server" Text="Retainer Master"></uc1:Topbar>
                </td>
            </tr>
            <tr valign="top" style="width: 100%">
                <td valign="top" class="rel">
                    <uc2:Leftbar ID="Leftbar1" runat="server"></uc2:Leftbar>
                </td>
                <td valign="top" style="width: 82.6%">
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
                                                                                BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnExit_Click"></asp:ImageButton>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="barcss">
            <tr>
                <td style="width: 27px;"></td>
                <td style="background-image: url(images/corner-left.jpg); width: 11px; background-position: right center; background-repeat: no-repeat; height: 20px;"></td>
                <td style="width: 135PX; font-family: Verdana; text-align: right; font-size: 10px; background-color: #a0bfeb; height: 20px;"><b>
                    <center>News Services</center>
                </b></td>
                <td style="background-image: url(images/corner-right.jpg); background-repeat: no-repeat; height: 20px; width: 11px"></td>
                <td style="width: 730px">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="background-color: #a0bfeb; width: 770px; height: 3px;"></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table class="headcss" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:LinkButton ID="lbtnStatusDetail" runat="server" CssClass="btnlink_n" OnClick="lbtnStatusDetail_Click">Status Detail |</asp:LinkButton>
                    <asp:LinkButton ID="lbcommdetail" runat="server" CssClass="btnlink_n" OnClick="lbcommdetail_Click">Discount Detail |</asp:LinkButton>
                    <asp:LinkButton ID="lbtnClientPaymode" runat="server" CssClass="btnlink_n">Payment Mode</asp:LinkButton>
                    <asp:LinkButton ID="lblretcomslab" runat="server" CssClass="btnlink_n">|Discount Slab</asp:LinkButton>
                    <%--	<asp:linkbutton id="creaditslab" runat="server" CssClass="btnlink_n" >|Creadit Slab</asp:linkbutton>--%>
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" border="0" class="styl6">

            <tr style="display: none">
                <td>
                    <asp:Label ID="lbPName" runat="server" CssClass="TextField"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="drpPName" runat="server" CssClass="dropdown">
                    </asp:DropDownList>
                </td>
            </tr>

            <tr style="display: none">
                <td>
                    <asp:Label ID="Label1" runat="server" CssClass="AlignTextField"></asp:Label></td>
                <td style="WIDTH: 202px">
                    <asp:DropDownList ID="drppubcent" runat="server" CssClass="dropdown">
                    </asp:DropDownList></td>
            </tr>

            <tr style="display: none">
                <td>
                    <asp:Label ID="lbEdition" runat="server" CssClass="TextField"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="drpEdition" runat="server" CssClass="dropdown">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="display: none">
                <td>
                    <asp:Label ID="lbSuppliment" runat="server" CssClass="TextField"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="drpSuppliment" runat="server" CssClass="dropdown">
                    </asp:DropDownList>
                </td>
            </tr>


            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" CssClass="AlignTextField"></asp:Label></td>
                <td style="WIDTH: 202px" onkeypress="eventcalling(event);">
                    <asp:TextBox ID="txtretainercode" onkeypress="return ClientSpecialchar(event);" Width="145px" runat="server" CssClass="btext1" MaxLength="8"></asp:TextBox></td>
                <td colspan="1">
                    <asp:Label ID="lblbranch" runat="server" CssClass="TextField"></asp:Label></td>
                <td style="WIDTH: 202px">&nbsp;&nbsp;&nbsp;
                                              <asp:DropDownList ID="drpbranch" runat="server" CssClass="dropdown" Width="175px" TabIndex="2">
                                                  <asp:ListItem Value="0">--Select Branch--</asp:ListItem>
                                              </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label12" runat="server" CssClass="AlignTextField"></asp:Label></td>
                <td colspan="3" style="WIDTH: 200px">
                    <asp:TextBox onkeydown="eventcalling(event); return ClientSpecialchar(event);" ID="txtretainername" runat="server" CssClass="btext"
                        MaxLength="150"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblcontact" runat="server" CssClass="AlignTextField"></asp:Label></td>
                <td colspan="3" style="WIDTH: 200px">
                    <asp:TextBox onkeydown="eventcalling(event); return ClientSpecialchar(event);" ID="txtcontact" runat="server" CssClass="btext"
                        MaxLength="150"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="repname" runat="server" CssClass="AlignTextField"></asp:Label></td>
                <td colspan="3" style="WIDTH: 202px">
                    <asp:DropDownList ID="txtrepname" runat="server" Width="485px" CssClass="btext"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" CssClass="AlignTextField"></asp:Label></td>
                <td colspan="3" height="10">
                    <asp:TextBox ID="txtalias" onkeydown="eventcalling(event);return ClientSpecialchar(event);" runat="server" CssClass="btext" MaxLength="150"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label13" runat="server" CssClass="AlignTextField"></asp:Label></td>
                <td colspan="3">
                    <asp:TextBox ID="txtadd1" runat="server" CssClass="btext" MaxLength="50"></asp:TextBox></td>
                <!--onkeypress="return notchar0(event);"-->
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" CssClass="AlignTextField"></asp:Label></td>
                <td colspan="3">
                    <asp:TextBox ID="txtstreet" runat="server" CssClass="btext" MaxLength="50"></asp:TextBox></td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label32" runat="server" CssClass="AlignTextField"></asp:Label></td>
                <td style="WIDTH: 202px">
                    <asp:DropDownList ID="txtcountry" runat="server" Width="150px" CssClass="dropdown">
                    </asp:DropDownList></td>

                <td>
                    <asp:Label ID="Label18" runat="server" CssClass="AlignTextField"></asp:Label></td>
                <td align="left">&nbsp;&nbsp;&nbsp;
												<asp:TextBox ID="txtstate" runat="server" CssClass="btext1" Width="170px" ReadOnly="True"></asp:TextBox></td>

            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" CssClass="AlignTextField"></asp:Label></td>
                <td style="WIDTH: 202px">
                    <asp:DropDownList ID="drpcity" runat="server" Width="150px" CssClass="dropdown">
                        <asp:ListItem Value="0">--select City--</asp:ListItem>
                    </asp:DropDownList></td>

                <td>
                    <asp:Label ID="lblzone" runat="server" CssClass="AlignTextField"></asp:Label></td>
                <td align="left">&nbsp;&nbsp;&nbsp;
											 <asp:DropDownList ID="drpzone" runat="server" Width="175px" CssClass="dropdown">
                                             </asp:DropDownList>
                    <%--<asp:textbox onkeypress="return ClientSpecialchar();" id="txtzone" runat="server" CssClass="btext1"
													MaxLength="15" Enabled="False"></asp:textbox>--%>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label14" runat="server" CssClass="AlignTextField"></asp:Label></td>
                <td style="WIDTH: 202px">
                    <asp:TextBox ID="txtdistrict" runat="server" Width="145px" CssClass="btext1" ReadOnly="True"></asp:TextBox></td>

                <td>
                    <asp:Label ID="lblregion" runat="server" CssClass="AlignTextField"></asp:Label></td>
                <td align="left">&nbsp;&nbsp;&nbsp;
											 <asp:DropDownList ID="drpregion" runat="server" Width="175px" CssClass="dropdown">
                                             </asp:DropDownList>
                    <%--<asp:textbox onkeypress="return ClientSpecialchar();" id="txtzone" runat="server" CssClass="btext1"
													MaxLength="15" Enabled="False"></asp:textbox>--%>
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbltaluka" runat="server" CssClass="AlignTextField"></asp:Label></td>
                <td align="left">
                    <asp:DropDownList ID="drptaluka" runat="server" Width="150px" CssClass="dropdown">
                        <asp:ListItem Value="0">--select Taluka--</asp:ListItem>
                    </asp:DropDownList>
                </td>

                <td>
                    <asp:Label ID="Label11" runat="server" CssClass="AlignTextField" Width="72px"></asp:Label></td>
                <td align="left">&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox onkeypress="return ClientisNumber(event)" ID="txtpincode" runat="server" CssClass="numerictext"
                    MaxLength="12" Width="170px" onpaste="return false;"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label15" runat="server" CssClass="AlignTextField"></asp:Label></td>
                <td style="WIDTH: 202px">
                    <asp:TextBox onchange="return ValidateForm('txtphone1')" ID="txtphone1" runat="server" CssClass="numerictext"
                        Width="48px" MaxLength="15"></asp:TextBox><asp:TextBox ID="txtphone2" runat="server" CssClass="btext1"
                            onkeypress="return ClientisNumberforcompany(event);" Width="94px" MaxLength="60"></asp:TextBox></td>
                <td>
                    <asp:Label ID="mobile" runat="server" CssClass="AlignTextField"></asp:Label></td>
                <td align="left">&nbsp;&nbsp;&nbsp;
												<asp:TextBox ID="txtmobile" runat="server" CssClass="btext1"
                                                    Enabled="false" onkeypress="return phoneno(event);" Width="170px" MaxLength="50"></asp:TextBox></td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label21" runat="server" CssClass="AlignTextField"></asp:Label></td>
                <td style="WIDTH: 202px">
                    <asp:TextBox ID="txtPan" Width="145px" runat="server" CssClass="btext1"
                        MaxLength="10"></asp:TextBox></td>

                <td>
                    <asp:Label ID="Label16" runat="server" CssClass="AlignTextField"></asp:Label></td>
                <td align="left">&nbsp;&nbsp;&nbsp;
												<asp:TextBox onchange="return ValidateForm('txtfax')" ID="txtfax" runat="server" CssClass="numerictext"
                                                    Width="170px" MaxLength="12"></asp:TextBox></td>


            </tr>

            <tr id="trstatus">


                <td>
                    <asp:Label ID="Label31" runat="server" CssClass="AlignTextField"></asp:Label></td>


                <td style="WIDTH: 202px">
                    <asp:TextBox ID="txtstatus1" Width="145px" runat="server" CssClass="btext1"
                        MaxLength="20"></asp:TextBox></td>

                <td>
                    <asp:Label ID="Label23" runat="server" CssClass="AlignTextField"></asp:Label></td>


                <td align="left">&nbsp;&nbsp;&nbsp;
											

	<asp:TextBox ID="txtstatusdate" runat="server" CssClass="btext1"
        ReadOnly="True" Width="170px"></asp:TextBox></td>



            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblcreditlimit" runat="server" CssClass="AlignTextField">Credit Limit</asp:Label></td>
                <td style="WIDTH: 202px">
                    <asp:TextBox ID="txtcreditlimit" runat="server" Width="145px" CssClass="btext1" onkeypress="return ClientisNumber(event);"></asp:TextBox></td>

                <td>
                    <asp:Label ID="Label41" runat="server" CssClass="AlignTextField"></asp:Label></td>
                <td align="left">&nbsp;&nbsp;&nbsp;
												<asp:TextBox onkeypress="return ClientisNumber(event);" ID="txtcreditdays" runat="server" CssClass="numerictext"
                                                    Width="170px" MaxLength="4" onpaste="return false;"></asp:TextBox></td>



            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbloldcod" runat="server" CssClass="AlignTextField">Old Code</asp:Label></td>
                <td style="WIDTH: 202px">
                    <asp:TextBox ID="txtoldcod" runat="server" Width="145px" CssClass="btext1" onkeypress="return ClientisNumber(event);"></asp:TextBox></td>

                <td>
                    <asp:Label ID="lblaccod" runat="server" CssClass="AlignTextField"></asp:Label></td>
                <td align="left">&nbsp;&nbsp;&nbsp;
												<asp:TextBox onkeypress="return ClientisNumber(event);" ID="txtaccod" runat="server" CssClass="numerictext"
                                                    Width="170px" MaxLength="10" onpaste="return false;"></asp:TextBox></td>



            </tr>

            <tr>
                <td style="display: none">









                    <asp:Label ID="Label35" runat="server" CssClass="AlignTextField"></asp:Label></td>
                <td colspan="3" style="display: none">
                    <asp:TextBox ID="txtbox" runat="server" CssClass="btext" MaxLength="200" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" CssClass="AlignTextField"></asp:Label></td>
                <td colspan="3">
                    <asp:TextBox ID="txtemailid" runat="server" CssClass="btextmail1" MaxLength="200" Width="480px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label34" runat="server" CssClass="AlignTextField"></asp:Label></td>
                <td colspan="3">
                    <asp:TextBox ID="txtremarks" runat="server" onkeypress="return notchar0(event);" CssClass="btext" MaxLength="200" TextMode="MultiLine"></asp:TextBox></td>
            </tr>

            <tr>
                <td>
                    <asp:LinkButton ID="lblsign" runat="server"></asp:LinkButton></td>
                <td>
                    <asp:TextBox ID="txtsign" runat="server" Width="145px" CssClass="btext1"></asp:TextBox></td>
                <td>


                    <asp:Label ID="lbemcode" runat="server" CssClass="TextField"></asp:Label></td>


                <td align="left">&nbsp;&nbsp;&nbsp;
											

	                                        <asp:TextBox ID="txtemcode" runat="server" CssClass="btext1" MaxLength="15" Width="170px"></asp:TextBox></td>
            </tr>



            <tr>
                <td>


                    <asp:Label ID="lbmaincdp" runat="server" CssClass="TextField"></asp:Label></td>


                <td colspan="3">


                    <asp:TextBox ID="txtmaincdp" runat="server" CssClass="btext1" MaxLength="15" Width="480px"></asp:TextBox></td>





            </tr>

            <tr>
                <td>


                    <asp:Label ID="lbmaincds" runat="server" CssClass="TextField"></asp:Label></td>


                <td colspan="3">


                    <asp:TextBox ID="txtmaincds" runat="server" CssClass="btext1" MaxLength="15" Width="480px"></asp:TextBox></td>


            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblgstatus" runat="server" CssClass="TextField" Text="Gst Applicable"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="drpgstatus" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                        <asp:ListItem Value="N">No</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="lblgstus" runat="server" CssClass="TextField"></asp:Label>
                </td>
                <td align="left">&nbsp;&nbsp;&nbsp;
                                                <asp:DropDownList ID="drpgstus" runat="server" CssClass="dropdown" Width="170px">
                                                    <asp:ListItem Value="Y">Registered</asp:ListItem>
                                                    <asp:ListItem Value="N">Unregistered</asp:ListItem>
                                                </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblgst" runat="server" CssClass="TextField"></asp:Label></td>
                \
                    <td>
                        <asp:TextBox ID="txtgstin" runat="server" CssClass="btext" MaxLength="15" Width="141px"></asp:TextBox></td>
                <td>
                    <asp:Label ID="lblgstdt" runat="server" CssClass="TextField"></asp:Label></td>
                <td align="left">&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtgstdt" runat="server" Width="170px"></asp:TextBox>
                    <img alt="Calender" src='Images/cal1.gif' id="Img2" onclick='popUpCalendar(this, Form1.txtgstdt, "mm/dd/yyyy")' onfocus="abc()" height="14" width="14" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblgstclty" runat="server" CssClass="TextField"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtgstclty" runat="server" CssClass="btext" Width="137px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblattachment" runat="server" CssClass="TextField"></asp:Label>

                    <asp:ImageButton ID="attachment1" runat="server" CssClass="btnlinkImage" ToolTip="Attachment" ImageUrl="~/Images/index.jpeg"></asp:ImageButton>
                    <%-- <asp:ImageButton ID="attachment2" runat="server" CssClass="btnlinkImage" ToolTip="Other Attachment" ImageUrl="~/Images/index.jpeg" ></asp:ImageButton>--%>
                </td>
            </tr>





        </table>
        <input id="hiddenuserid" type="hidden" size="3" name="Hidden1" runat="server">
        <input id="formname" type="hidden" size="3" name="Hidden1" runat="server">

        <input id="hiddencompcode" type="hidden" size="4" name="Hidden1" runat="server">
        <input id="hiddenusername" type="hidden" size="1" name="Hidden1" runat="server" onserverchange="hiddenusername_ServerChange">
        <input id="hiddenauto" type="hidden" size="4" name="Hidden1" runat="server">
        <input id="hiddenchk" type="hidden" size="4" name="Hidden1" runat="server">
        <input id="hiddensubmod" type="hidden" size="4" name="Hidden1" runat="server">
        <input id="hiddenretcode" type="hidden" size="4" name="Hidden1" runat="server">
        <input id="hidden1s" type="hidden" size="4" name="Hidden1" runat="server">
        <input id="hidden2s" type="hidden" size="4" name="Hidden1" runat="server">
        <input id="hidden3s" type="hidden" size="4" name="Hidden1" runat="server">
        <input id="hidden4s" type="hidden" size="4" name="Hidden1" runat="server">
        <input id="hidden1" type="hidden" size="4" name="Hidden1" runat="server">
        <input id="hidden2" type="hidden" size="4" name="Hidden1" runat="server">
        <input id="hidden3" type="hidden" size="4" name="Hidden1" runat="server">
        <input id="hidden12s" type="hidden" size="4" name="Hidden1" runat="server">
        <input id="hidden22s" type="hidden" size="4" name="Hidden1" runat="server">
        <input id="hidden32s" type="hidden" size="4" name="Hidden1" runat="server">
        <input id="hidden42s" type="hidden" size="4" name="Hidden1" runat="server">
        <input id="hiddensaurabh" type="hidden" size="4" name="Hidden1" runat="server">
        <input id="hiddendateformat" type="hidden" name="hiddendateformat" runat="server" />
        <input type="hidden" id="hidattachment" runat="server" />
        <input type="hidden" id="hidattach2" runat="server" />


        <input id="hiddenmaincdp" type="hidden" name="ip1" runat="server" />
        <input id="hiddenmaincds" type="hidden" name="ip1" runat="server" />

        <input type="hidden" id="hdn_cds_unit" runat="server" />
        <input id="ip1" type="hidden" name="ip1" runat="server" />
        <input type="hidden" runat="server" id="hdempcode" />
        <input type="hidden" runat="server" id="hdnagcode" />
        <input type="hidden" runat="server" id="hdncdsubcd" />
        <input id="hdngstclty" type="hidden" name="hdngstclty" runat="server" />
    </form>
</body>
</html>
