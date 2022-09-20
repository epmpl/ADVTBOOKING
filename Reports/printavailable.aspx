<%@ Page Language="C#" AutoEventWireup="true" CodeFile="printavailable.aspx.cs" Inherits="Reports_printavailable" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Available Premium Report</title>
     <link href="css/report.css" rel="stylesheet" type="text/css" />
     <link href="Reports/css/report.css" rel="stylesheet" type="text/css" />
</head>
<body onload="window.print();">
    <form id="form1" runat="server">
    <%-- <table style="width:100%">
 <tr style="width:100px">

<td align="center" colspan='18'><asp:Label ID="heading" CssClass ="heading" runat ="server"></asp:Label></td>

</tr>
</table>--%>
   <table style="width:100%" >
   <tr>
          <td align="center" style="height: 28px" colspan="3"><asp:Label ID="cmpnyname" CssClass ="headingc" runat ="server"></asp:Label></td>
          </tr>
           <tr>
          <td align="center" style="height: 28px" colspan="3"><asp:Label ID="heading" CssClass ="headingp" runat ="server"></asp:Label></td>
          </tr>

</table>
 <table id="table1" cellpadding="0" cellspacing="0" align="center" border="0"  >
 <tr>
        <td class="upper2" >PAGE:</td><td class="middle2"><asp:Label ID="lblpagepr" CssClass="reporttext1" runat="server" ></asp:Label></td>
       <td class="upper2" >POSITION:</td><td class="middle2"><asp:Label ID="lblposition" CssClass="reporttext1" runat="server" ></asp:Label></td>
        <td  class="upper2" >PUBLICATION:</td><td><asp:Label ID="lblpub" CssClass="reporttext2" runat="server"></asp:Label></td>
        <td class="upper2">EDITION:</td><td class="upper2333" width="15%"><asp:Label ID="lbledition" CssClass="reporttext2" runat="server"></asp:Label></td>
       
    </tr>
        <tr style="border-bottom:dashed">
         <td  class="upper2">DATE FROM:</td><td class="middle2"> <asp:Label ID="lblfrom" CssClass="reporttext2" runat="server"></asp:Label></td>
         <td  class="upper2">DATE TO:</td><td class="middle2"> <asp:Label ID="lblto" CssClass="reporttext2" runat="server"></asp:Label></td>
         <td  class="upper2">RUN DATE:</td><td class="middle2"> <asp:Label ID="lbldate" CssClass="reporttext2" runat="server"></asp:Label></td>
         
          </tr>
     
    </table>
    
     <table width="100%" ><tr valign="top"><td id="div1" runat="server" align="center" valign="top"></td></tr></table>
   
    <input runat="server" id="hiddencioid" type="hidden"/>
     <input runat="server" id="hiddenascdesc" type="hidden"/>
      <input runat="server" id="hiddendateformat" type="hidden"/>

    </form>
</body>
</html>
