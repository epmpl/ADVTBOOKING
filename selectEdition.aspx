<%@ Page Language="C#" AutoEventWireup="true" CodeFile="selectEdition.aspx.cs" Inherits="selectEdition" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Choose Edition</title>
    <link href="css/booking.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="javascript/bookingMaster.js"></script>
   
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table cellpadding="0" cellspacing="0"><tr><td Class="TextField">Choose Edition</td></tr></table>
    <table><tr><td id="tdtable" runat="server">
   
    </td></tr>
    <tr><td><input type="button" value="Ok" onclick="passVal();" /></td></tr>
    </table>
    </div>
    <input type="hidden" id="hidval" runat="server" />
    </form>
</body>
</html>
