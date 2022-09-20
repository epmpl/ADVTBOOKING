<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adBookingType.aspx.cs" Inherits="adBookingType" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Booking Type</title>
    <link href="css/main.css" type="text/css" rel="stylesheet" />
    <script language="javascript" src="javascript/entertotab.js"></script>
    <script language="javascript">
    function openQBC()
    {
       
          win=window.open('QBC.aspx?bookingtype='+document.getElementById('drptype').value,'','width='+screen.availWidth+',height='+screen.availHeight+',resizable=1,left=0,top=0,scrollbars=yes');
          win.focus();
          self.close();
    }
    </script>
</head>
<body onload="document.getElementById('drptype').focus();" onkeydown="javascript:return tabvalue(event);">
    <form id="form1" runat="server">
    <div>
    <table align="center" border="1" bordercolor="#000000" cellpadding="0"
                    cellspacing="0"><tr><td>
     <table align="center" bgcolor="#7daae3" border="0" cellpadding="0" cellspacing="0"
                                style="width:100%;height:100%">
                                <tr>
                                    <td align="center" class="btnlink">
                                        Booking Type</td>
                                </tr>
                            </table>
                            <table align="center" style="height:100%;margin-top:20px;">
                            
                            <tr valign="bottom"><td align="center" valign="middle"><asp:Label ID="lbltype" runat="server" CssClass="TextField" Text="Select Booking Type"></asp:Label></td>
                            <td valign="middle">
                                                    <asp:DropDownList ID="drptype" TabIndex="0" runat="server" CssClass="dropdown"></asp:DropDownList></td>
                            </tr>
                            
                           
                            
                            <tr><td></td>
                            <td align="right"><asp:Button ID="btnSubmit" TabIndex="0" runat="server" CssClass="button1" Text="Submit" /></td>
                            </tr>
                            </table>
    </td></tr></table>
    </div>
    </form>
</body>
</html>
