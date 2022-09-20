<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintDealReport.aspx.cs" Inherits="Reports_PrintDealReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Print Deal Report</title>
    <link href="css/report.css" rel="stylesheet" type="text/css" />
</head>
<body onload="window.print();">
    <form id="form1" runat="server">
     <table width="100%" style="vertical-align:top"><tr><td id="div1" runat="server" align="center" valign="top"></td></tr></table>
     <input id="hiddendateformat" type="hidden" runat="server" />
    </form>
</body>
</html>
