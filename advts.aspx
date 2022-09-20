<%@ Page Language="C#" AutoEventWireup="true" CodeFile="advts.aspx.cs" Inherits="advts" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>VTS</title>
    <link href="css/booking.css" type="text/css" rel="stylesheet" />

    <script language="javascript" src="javascript/entertotabbooking.js"></script>

    <script language="javascript" src="javascript/Validations.js" type="text/javascript"></script>

    <script language="javascript" src="javascript/popupcalender.js" type="text/javascript"></script>

    <script language="javascript">
        var browser = navigator.appName;
        function dateenter(event) {
            //if((event.keyCode>=46 && event.keyCode<=57)|| (event.keyCode>=96 && event.keyCode<=105) || (event.keyCode==111) || (event.keyCode==127) || (event.keyCode==191) ||(event.keyCode==8)||(event.keyCode==9) || (event.keyCode==13))
            if ((event.keyCode >= 46 && event.keyCode <= 57) || (event.keyCode == 111) || (event.keyCode == 127) || (event.keyCode == 191) || (event.keyCode == 8) || (event.keyCode == 9) || (event.keyCode == 13)) {
                return true;
            }
            else {
                return false;
            }
        }
        function notchar2() {

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
        function insertagency() {
            if (document.activeElement.id == "lstcirrate") {
                if (document.getElementById('lstcirrate').value == "0") {
                    alert("Please select the Cir. Rate");
                    return false;
                }
                document.getElementById("divcirrate").style.display = "none";

                var page = document.getElementById('lstcirrate').value;
                document.getElementById('hiddencirpub').value = trim(page.toString().split('+')[0]);
                //   document.getElementById('hiddenciredi').value=trim(page.toString().split('+')[1].split('(')[0]);
                var pagename = document.getElementById('lstcirrate').options[document.getElementById('lstcirrate').selectedIndex].text.split('+');

                //   document.getElementById('txtciredition').value=trim(pagename[1].toString()).split('(')[0];
                //   document.getElementById('txtcirrate').value=trim(pagename[1].toString()).split('(')[1].replace(')','');
                if (pagename[1].toString().lastIndexOf("(") >= 0) {
                    document.getElementById('txtcirrate').value = pagename[1].toString().substring(pagename[1].toString().lastIndexOf("(") + 1, pagename[1].toString().length - 1);
                    document.getElementById('txtciredition').value = pagename[1].toString().substring(0, pagename[1].toString().lastIndexOf("(") - 1);
                    document.getElementById('hiddenciredi').value = document.getElementById('txtciredition').value;
                }
                document.getElementById('txtcirrate').focus();

                return false;
            }
        }    
   
    </script>

</head>
<body onload="onloadCall();" onkeydown="javascript:return tabvalue(event);">
    <form id="form1" runat="server">
    <div id="divciragency" style="position: absolute; top: 0px; left: 0px; border: none;
        display: none; z-index: 1;">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:ListBox ID="lstciragency" Width="354px" Height="65px" runat="server" CssClass="btextlist">
                    </asp:ListBox>
                </td>
            </tr>
        </table>
    </div>
    <div id="divcirrate" style="position: absolute; top: 0px; left: 0px; border: none;
        display: none; z-index: 1;">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:ListBox ID="lstcirrate" Width="354px" Height="65px" runat="server" CssClass="btextlist">
                    </asp:ListBox>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table align="center" border="1" bordercolor="#000000" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <table align="center" bgcolor="#7daae3" border="0" cellpadding="0" cellspacing="0"
                        style="width: 100%; height: 100%">
                        <tr>
                            <td align="center" class="btnlink">
                                VTS
                            </td>
                        </tr>
                    </table>
                    <table align="center" style="height: 100%; margin-top: 20px;">
                        <tr>
                            <td>
                                <asp:Label ID="lblvts" runat="server" Text="No. of Copies" CssClass="TextField"></asp:Label>
                            </td>
                            <td valign="top">
                                <asp:TextBox ID="txtvts" onkeypress="return notchar2();" runat="server" CssClass="btextforbookright"
                                    Enabled="true" MaxLength="10"></asp:TextBox>
                            </td>
                            <td valign="top">
                                <asp:Label ID="lbrodate" runat="server" CssClass="TextField" Text="Publish Date"></asp:Label>
                            </td>
                            <td valign="top">
                                <asp:TextBox ID="txtpubdate" runat="server" CssClass="btextforbook" onkeypress="return dateenter(event);"></asp:TextBox><img
                                    src='Images/cal1.gif' id="Img2" onclick='popUpCalendar(this, form1.txtpubdate, "mm/dd/yyyy")'
                                    onfocus="abc()" height="11" width="14" />
                        </tr>
                        <tr valign="bottom">
                            <td>
                                <asp:Label ID="lblciredition" runat="server" Text="Edition" CssClass="TextField"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtciredition" runat="server" CssClass="btextforbookright" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblcirrate" runat="server" CssClass="TextField" Text="Rate"></asp:Label>
                            </td>
                            <td valign="top">
                                <asp:TextBox ID="txtcirrate" runat="server" CssClass="btextforbookright" Enabled="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td align="right">
                                <asp:Button ID="btnSubmit" TabIndex="0" runat="server" CssClass="button1" Text="Submit" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <input type="hidden" id="hiddencompcode" runat="server" />
        <input type="hidden" id="hiddencenter" runat="server" />
        <input type="hidden" id="hiddencirpub" runat="server" />
        <input type="hidden" id="hiddenciredi" runat="server" />
        <input type="hidden" id="hiddenid" runat="server" />
        <input type="hidden" id="hiddendateformat" runat="server" />
        <input type="hidden" id="hiddenmode" runat="server" />
    </div>
    </form>
</body>
</html>
