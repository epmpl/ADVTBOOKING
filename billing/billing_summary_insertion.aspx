<%@ Page Language="C#" AutoEventWireup="true" CodeFile="billing_summary_insertion.aspx.cs" Inherits="billing_summary_insertion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <link href="css/report.css" rel="stylesheet" type="text/css" />
    <link href="css/main.css" type="text/css" rel="stylesheet" />
   <script type="text/javascript" language="javascript" src="javascript/rept.js">

 
  </script>

   <title>Billing Summary Insertion Wise</title>
   <%--<script type="text/javascript" language="javascript" src="javascript/rept.js"></script>  --%>
   
</head>
<body >
<form id="form1" runat="server">

<div id="abc">


  <table style="width: 794px" >
  
<tr style="width:100px">
<td align="left" style="width: 69px; height: 28px;">

<td align="center" style="height: 28px"><asp:Label ID="heading" CssClass ="heading" runat ="server">Billing Summary(InsertionWise)</asp:Label></td>
<td align="right" style="height: 28px"></td>
</tr>
<tr><td style="width: 69px"></td></tr>
</table>

   
     <table style="width: 97%"><tr><td id="tblgrid" runat="server" style="height: 21px" visible ="true"></td></tr></table>
     <table><tr> <td><input id="hiddendateformat" type="hidden" runat="server" /></td></tr></table>
    <table style="z-index: 100; left: 15px; width:900px; position: absolute; top: 22px">
        <tr>
            
         

            
  
        </tr>
    </table>
          <table><tr> <td><input id="hiddendatefrom" type="hidden" runat="server" /></td></tr></table>
               <table><tr> <td><input id="hiddendateto" type="hidden" runat="server" /><input id="dscount" type="hidden" runat="server" /></td></tr></table>
   <input id="hiddenascdesc" type="hidden" runat="server" />
   <input id="hiddencioid" type="hidden" runat="server" />
		
     </form>
</body>

</html>
