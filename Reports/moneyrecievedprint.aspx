<%@ Page Language="C#" AutoEventWireup="true" CodeFile="moneyrecievedprint.aspx.cs" Inherits="Reports_moneyrecievedprint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <link href="css/report.css" rel="stylesheet" type="text/css" />
     <link href="Reports/css/report.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="javascript" src="javascript/rept.js">
   
  
   </script>
   <script type="text/javascript" language="javascript" src="javascript/prototype.js"></script>
    <title>Money Recieved Report</title>
</head>
<body onload="window.print();">
    <form id="form1" runat="server">
    <table style="width:100%" >
   <tr>
          <td align="center" style="height: 28px" colspan="3"><asp:Label ID="cmpnyname" CssClass ="headingc" runat ="server"></asp:Label></td>
          </tr>
           <tr>
          <td align="center" style="height: 28px" colspan="3"><asp:Label ID="heading" CssClass ="headingp" runat ="server"></asp:Label></td>
          </tr>

</table>
 <table id="table1" cellpadding="0" cellspacing="0" align="center" border="0" >
    <tr>
        
        <td  class="upper2">AGENCY:</td><td class="middle2"><asp:Label ID="lbagency" CssClass="reporttext" runat="server"></asp:Label></td>
        <td  class="upper2">CLIENT:</td><td><asp:Label ID="lbclient" CssClass="reporttext" runat="server"></asp:Label></td>   
        <td  class="upper2">PAYMODE:</td><td><asp:Label ID="lbpaymode" CssClass="reporttext" runat="server"></asp:Label></td>   
        
        </tr>
<tr></tr>
<tr></tr>
<tr></tr>
<tr></tr>
   
    <tr style="border-bottom:dashed">
    <td  class="upper2">DATE FROM:</td><td class="middle2" ><asp:Label ID="lblfrom" CssClass="reporttext2" runat="server" >hgjhj</asp:Label></td>
    <td  class="upper2" >DATE TO:</td><td class="middle2" ><asp:Label ID="lblto" CssClass="reporttext2" runat="server" ></asp:Label></td>
     <td  class="upper2" >RUN DATE:</td><td class="middle2" ><asp:Label ID="lbldate" CssClass="reporttext2" runat="server" ></asp:Label></td>
    
</tr>
   
    </table>
<table width="100%" style="vertical-align:top"><tr valign="top"><td valign="top" id="div1" runat="server" align="center" ></td></tr></table>
    <input runat="server" id="hiddencioid" type="hidden"/>
     <input runat="server" id="hiddenascdesc" type="hidden"/>
     <input id="hiddendatefrom" type="hidden" runat="server" />
     <input id="hiddendateto" type="hidden" runat="server" />
     <input id="hiddendateformat" type="hidden" runat="server"/>
    </form>
</body>
</html>
