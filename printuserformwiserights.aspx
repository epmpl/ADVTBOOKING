<%@ Page Language="C#" AutoEventWireup="true" CodeFile="printuserformwiserights.aspx.cs" Inherits="printuserformwiserights" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
   <script type="text/javascript" language="javascript" src="javascript/reportdrop.js"></script>
    <script language="javascript" src="javascript/prototype.js" type="text/javascript"></script>
    <script language ="javascript" type="text/javascript" ></script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Form Wise rights</title>
     <link href="css/userformwiserights.css" type="text/css" rel="Stylesheet" />
</head>
<script type="text/javascript" language ="javascript" >
     function print1()
     {
     window.print();
     }
    </script>
<body onload="javascript:return print1();">
     <form id="form1" runat="server" style="margin-bottom:0px; margin-top:0px; margin-right:0px;">
   <table cellpadding="0" cellspacing="0" width="100%"> <tr>
            <td width="100%" id="report" runat="server" valign="top" height="23px"></td>
        </tr>
    </table>
     <table>
     
        <tr> <td id="subsubrut" runat="server"></td></tr></table>
         <input type="hidden" id="hdncompcode" runat="server" name="hdncompcode" />
     <input type="hidden" id="dateformat" runat="server" name="dateformat" />
     <input type="hidden" id="hdnunitcode" runat="server" name="hdnunitcode" />
     <input type="hidden" runat="server" id="hdnuserid" />
    </form>
</body>
</html>
