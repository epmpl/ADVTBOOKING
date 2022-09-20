<%@ Page Language="C#" AutoEventWireup="true" CodeFile="matterprev_new.aspx.cs" Inherits="matterprev_new" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Ad Preview</title>
    <link href="css/booking.css" type="text/css" rel="stylesheet" />
    <script language="javascript" src="javascript/classified.js" type="text/javascript"></script>
    <script language=javascript>
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="position:absolute;word-wrap: break-word">
    <%--<iframe runat="server" width="500px" height="400px" style="position:static" id="iframe"></iframe>--%>
    <table width=100%><tr><td id="td1"  runat="server"></td></tr>
   
    </table>
    <table><tr><td></td></tr></table>
    <input type="hidden" runat="server" id="hid1" />
    <input type="hidden" runat="server" id="Hiddeninser" />
    <input type="hidden" runat="server" id="hiddenagencyratecode" />
    <input type="hidden" runat="server" id="hiddendatabasename" />
    <input type="hidden" runat="server" id="hiddenagencycode" />
    </div> 
    </form>
</body>
</html>
