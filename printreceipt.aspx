<%@ Page Language="C#" AutoEventWireup="true" CodeFile="printreceipt.aspx.cs" Inherits="printreceipt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Print Receipt</title>
    <script language="javascript" src="javascript/bookingMaster.js" type="text/javascript"></script>
    <link href="css/booking.css" type="text/css" rel="stylesheet" />
</head>
<body >
    <form id="form1" runat="server">
    <div>
    <table><tr ><td id="to" runat="server" class="printTextField" align="left"></td><td align="right">
        <asp:Button ID="Button1" runat="server" CssClass="buttonsmall" Text="Print" /></td></tr>
    
    <tr><td id="printrem" align="left" runat="server" class="printTextField"></td></tr><tr><td></td></tr><tr><td id="ad" runat="server" class="printTextField" align="left"></td></tr></table>
    </div>
    </form>
</body>
</html>
