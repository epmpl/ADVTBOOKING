<%@ Page Language="C#" AutoEventWireup="true" CodeFile="targetanalisis_view_print.aspx.cs" Inherits="Reports_targetanalisis_view_print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Target Analisis Report</title>
      <link href="css/new_main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language ="javascript" >
       function print1() 
       {
           window.print();
       }
   </script>
</head>
<body onload="print1();">
    <form id="form1" runat="server">
    <div>
     <div>
     <table width="100%"><tr><td valign="top" id="tblgrid" runat="server"></td></tr></table>
    </div>
    </div>
    </form>
</body>
</html>
