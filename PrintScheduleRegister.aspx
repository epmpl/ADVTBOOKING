<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintScheduleRegister.aspx.cs" Inherits="PrintScheduleRegister" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="css/report.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
    <%--<div>
    
    </div>--%>
    <table style="width: 100%" >
       <tr style="width:100px">
          <td align="left" style="width: 69px; height: 28px;"></td>
          <td align="center" style="height: 28px"><asp:Label ID="heading" CssClass ="heading" runat ="server"></asp:Label></td>
          <td align="right" style="height: 28px"></td>
      </tr>
       <tr><td style="width: 69px"></td></tr>
    </table>
      <table id="table1" cellpadding="0" cellspacing="0" align="center" border="0" >
    <tr>
        <td  class="upper2">DATE FROM:</td><td class="middle2" ><asp:Label ID="lblfrom" CssClass="reporttext2" runat="server" ></asp:Label></td>
        <td  class="upper2" >DATE TO:</td><td class="middle2" ><asp:Label ID="lblto" CssClass="reporttext2" runat="server" ></asp:Label></td>
        <td  class="upper2" >RUN DATE:</td><td class="middle2" ><asp:Label ID="lbldate" CssClass="reporttext2" runat="server" ></asp:Label></td>
  
    </tr>
    <tr style="border-bottom:dashed">
         <td class="upper2">PUBLICATION:</td><td class="middle2"><asp:Label ID="lblpublication" CssClass="reporttext2" runat="server"></asp:Label></td>    
    </tr>
    <tr style="border-bottom:dashed">
        <td  class="upper3">PUBLICATION CENTER:</td><td class="middle2"><asp:Label ID="lblpublicationcenter" CssClass="reporttext2" runat="server"></asp:Label></td>
        <td  class="upper2" >ADTYPE:</td><td class="middle2"><asp:Label ID="lbadtype" CssClass="reporttext2" runat="server"></asp:Label></td>
         <td  class="upper2" >ADCATEGORY:</td><td class="middle2"><asp:Label ID="lbadcategory" CssClass="reporttext2" runat="server"></asp:Label></td>
    </tr>
</table>
     <table width="80%" style="vertical-align:top"><tr><td id="div1" runat="server" align="center" valign="top"></td></tr></table>
    <input runat="server" id="hiddencioid" type="hidden"/>
     <input runat="server" id="hiddenascdesc" type="hidden"/>
     <input id="hiddendatefrom" type="hidden" runat="server" />
     <input id="hiddendateto" type="hidden" runat="server" />
     <input id="hiddendateformat" type="hidden" runat="server"/>
    </form>
</body>
</html>
