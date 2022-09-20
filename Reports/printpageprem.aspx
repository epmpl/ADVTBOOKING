<%@ Page Language="C#" AutoEventWireup="true" CodeFile="printpageprem.aspx.cs" Inherits="printpageprem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Page Premium Report</title>
    <link href="css/report.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            height: 0px;
            width: 175px;
            font-size: 12px;
            font-family: Arial;
            font-weight: bolder;
            text-align: left;
        }
    </style>
</head>
<body onload="window.print();">
    <form id="form1" runat="server">
 <%--      <table style="width:100%">
       
           <tr>
          <td align="center" style="height: 28px" colspan="3"><asp:Label ID="cmpnyname" CssClass ="headingc" runat ="server"></asp:Label></td>
          </tr>
           <tr>
          <td align="center" style="height: 28px" colspan="3"><asp:Label ID="heading" CssClass ="headingc" runat ="server"></asp:Label></td>
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
     <table id="table1" cellpadding="0" cellspacing="0" align="center" border="0" onclick="return table1_onclick()" >
 <tr>
        <td class="style1">PAGE PREMIUM:</td><td class="middle2"><asp:Label ID="lblpagepr" CssClass="reporttext2" runat="server" ></asp:Label></td>
       <td class="upper2" >POSITION:</td><td class="middle2"><asp:Label ID="lblposition" CssClass="reporttext2" runat="server" ></asp:Label></td>
        <td  class="upper2" >PUBLICATION:</td><td><asp:Label ID="lblpub" CssClass="reporttext2" runat="server"></asp:Label></td>
        <td  class="upper2" >PUB CENTER:</td><td><asp:Label ID="pcenter" CssClass="reporttext2" runat="server" Width="98px" Height="15px"></asp:Label></td>
       <td  class="upper2" >EDITION:</td><td><asp:Label ID="lbedition" CssClass="reporttext2" runat="server" Width="98px" Height="15px"></asp:Label></td>
       
    </tr>
        <tr style="border-bottom:dashed">
         <td  class="style1">DATE FROM:</td><td class="middle2"> <asp:Label ID="lblfrom" CssClass="reporttext2" runat="server"></asp:Label></td>
         <td  class="upper2">DATE TO:</td><td class="middle2"> <asp:Label ID="lblto" CssClass="reporttext2" runat="server"></asp:Label></td>
         <td  class="upper2">RUN DATE:</td><td class="middle2"> <asp:Label ID="lbldate" CssClass="reporttext2" runat="server"></asp:Label></td>
         <td  class="upper2">ADTYPE:</td><td class="middle2" ><asp:Label ID="lbladtype" CssClass="reporttext2" runat="server" ></asp:Label></td>
         <td  class="upper2">AGENCY TYPE:</td><td class="middle2" ><asp:Label ID="lblagtype" CssClass="reporttext2" runat="server" ></asp:Label></td>
 
     </tr>
     
    </table>
    
   <table width="100%" cellspacing='0px' cellpadding = '0px' border='0' ><tr valign="top"><td id="div1" runat="server" align="center" valign="top"></td></tr></table>
   
    <input runat="server" id="hiddencioid" type="hidden"/>
     <input runat="server" id="hiddenascdesc" type="hidden"/>
      <input runat="server" id="hiddendateformat" type="hidden"/>
    </form>
</body>
</html>
