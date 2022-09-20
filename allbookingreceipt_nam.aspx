<%@ Page Language="C#" AutoEventWireup="true" CodeFile="allbookingreceipt_nam.aspx.cs" Inherits="allbookingreceipt_nam" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BOOKING RECEIPT</title>
     <link type="text/css" href="css/main.css" rel="Stylesheet" />
    <link type="text/css" href="css/quotationprint_nam.css" rel="Stylesheet" />
    <script type="text/javascript" language="javascript">
        function print1() {
            window.print();
        }
    </script>

</head>
<body onload="javascript:return print1();">
    <form id="form1" runat="server">
    <div>
    <div id="div1" runat="server" style="vertical-align:top"></div>
    </div>
    <input id="hiddenDateFormat" runat="server" type="hidden" />
    
    </form>
</body>
</html>
