<%@ Page Language="C#" AutoEventWireup="true" CodeFile="targetanalisis_view.aspx.cs" Inherits="Reports_targetanalisis_view" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Target Analisis Report</title>
     <link href="css/new_main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table style="width:100%" >

<tr valign="top">
        <td align="left" >
        <asp:Button ID="btnprint" runat="server"  Text="Print" />
        </td></tr></table>
     <table cellpadding="0" cellspacing="0" width="100%">
       <tr>
           <td width="100%" id="view" runat="server"></td>
       </tr>
   </table>
    </div>
    </form>
</body>
</html>
