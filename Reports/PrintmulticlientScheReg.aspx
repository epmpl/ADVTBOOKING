<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintmulticlientScheReg.aspx.cs" Inherits="PrintmulticlientScheReg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Multi Client Schedule Register Report</title>
    <link href="css/report.css" rel="stylesheet" type="text/css"/>
</head>
<body onload="window.print();">
    <form id="form1" runat="server">
  
    <table><tr valign="top"><td valign="top" id="headttd" runat="server" align="center" >
    <%--<table style="width: 100%" id="tblheading" runat="server">
    <tr >
          <td align="center" colspan="3" style="height: 28px"><asp:Label ID="cmpnyname" CssClass ="headingc" runat ="server"></asp:Label></td>
          </tr>
           <tr >
          <td align="center" colspan="3" style="height: 28px"><asp:Label ID="heading" CssClass ="headingp" runat ="server"></asp:Label></td>
          </tr>
       <tr><td style="width: 69px"></td></tr>
       
    </table>
      <table width="100%" id="tblheader" cellpadding="0" cellspacing="0" align="center" border="0" runat="server" >
    <tr><td colspan="2"></td><td  class="upper2" align="right" style="padding-left:58px" >DATE FROM:</td><td class="middle2" ><asp:Label ID="lblfrom" CssClass="reporttext2" runat="server" ></asp:Label></td>
        <td  class="upper2" >DATE &nbsp;TO:</td><td class="middle2" ><asp:Label ID="lblto" CssClass="reporttext2" runat="server" ></asp:Label></td>
        </tr>
    <tr>
        <td class="upper2">PUBLICATION:</td><td class="middle2" align="left" style="padding-right:39px"><asp:Label ID="lblpublication" CssClass="reporttext2" runat="server"></asp:Label></td>    
        <td  class="upper2" style="width:600px">PUBLICATION CENTER:</td><td class="middle2" ><asp:Label ID="lblpublicationcenter" CssClass="reporttext2" runat="server"></asp:Label></td>
        <td  class="upper2" >ADTYPE:</td><td class="middle2"><asp:Label ID="lbadtype" CssClass="reporttext2" runat="server"></asp:Label></td>
         <td  class="upper2" >ADCATEGORY:</td><td class="middle2"><asp:Label ID="lbadcategory" CssClass="reporttext2" runat="server"></asp:Label></td>
   
   
  
    </tr>
    <tr>
        <td class="middle2" ><asp:Label ID="lbldate" CssClass="reporttext2" runat="server" Visible="false" ></asp:Label></td>
      
    </tr>
 
</table>--%>

</td></tr></table>


     <table width="100%" style="vertical-align:top"><tr><td id="div1" runat="server" align="center" valign="top"></td></tr></table>
    <input runat="server" id="hiddencioid" type="hidden"/>
     <input runat="server" id="hiddenascdesc" type="hidden"/>
     <input id="hiddendatefrom" type="hidden" runat="server" />
     <input id="hiddendateto" type="hidden" runat="server" />
     <input id="hiddendateformat" type="hidden" runat="server"/>
    </form>
</body>
</html>
