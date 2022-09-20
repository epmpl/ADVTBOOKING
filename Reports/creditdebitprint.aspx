<%@ Page Language="C#" AutoEventWireup="true" CodeFile="creditdebitprint.aspx.cs" Inherits="Reports_creditdebitprint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<script type="text/javascript" language ="javascript" >
    function print1() {
        window.print();
    }
 </script>
<body onload="javascript:return print1();">
     <form id="form1" runat="server">
    <table cellpadding = "0" cellspacing = "0" width = "100%">
 
      <tr>
            <td width = "100%" id = "viewprint" runat = "server" valign = "top" height = "23px"></td>
          
       </tr>
   </table>
 <input id="hiddendateformat" runat="server" style="width: 77px" type="hidden" />
     
    </form>
</body>
</html>

