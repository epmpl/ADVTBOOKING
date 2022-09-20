<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Advance_Deposit_Receipt.aspx.cs"
    Inherits="Advance_Deposit_Receipt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Advance Deposit Receipt</title>

    <script type="text/javascript" language="javascript" src="javascript/jquery.min.js"></script>

    <script language="javascript">
        var jq = jQuery.noConflict();
        jq(document).ready(function() {
            setTimeout(function() {
                window.print();
            }, 500);
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div id="temp_div" runat="server">
        <input type="button" id="btnprint" runat="server" style="width: 70px; height: 22px;
            text-align: center; font-size: 11px; font-family: Verdana;" value="Print" onclick="javascript:return window.parent.location='Advance_Deposit_Receipt_Print.aspx';" />
    </div>
    <div width="100%" id="view" style="margin-top: 5px;" valign="top" runat="server">
    </div>
    </form>
</body>
</html>
