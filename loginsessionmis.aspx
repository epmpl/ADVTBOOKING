<%@ Page Language="C#" AutoEventWireup="true" CodeFile="loginsessionmis.aspx.cs" Inherits="loginsessionmis" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" type="text/javascript">
    
function openbookingModify() {

    if (document.getElementById('hiddenadtype').value == "DI0") {
        win = window.open('"http://cio87/adbooking_new/Booking_master.aspx?cioid=' + document.getElementById('hiddencioid').value , '', 'width=' + screen.availWidth + ',height=' + screen.availHeight + ',resizable=1,left=0,top=0,scrollbars=yes');
    }
    else if (document.getElementById('hiddenadtype').value == "CL0") {
    win = window.open('"http://cio87/adbooking_new/Classified_Booking.aspx?cioid=' + document.getElementById('hiddencioid').value, '', 'width=' + screen.availWidth + ',height=' + screen.availHeight + ',resizable=1,left=0,top=0,scrollbars=yes');
    }
//    document.getElementById('hiddenmodify').value = "1";
}

   </script>
</head>
<body onload="openbookingModify();">
    <form id="form1" runat="server">
    
    </form>
</body>
</html>
