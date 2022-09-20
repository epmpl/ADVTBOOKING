<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintDeviationReport.aspx.cs" Inherits="Reports_PrintDeviationReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Deviation Report</title>
     <link href="css/report.css" rel="stylesheet" type="text/css"/>
</head>
<body onload="window.print();">
   <form id="form1" runat="server">
<%--   <table style="width: 794px" >
        <tr style="width:100px">
            <td align="left" style="width: 69px" ></td> 
            <td align="center"><asp:Label ID="heading" CssClass ="heading" runat ="server"></asp:Label></td>
            <td align="right"></td>
        </tr>
        <tr><td style="width: 69px"></td></tr>
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
        <td  class="upper2" >PUBLICATION:</td><td><asp:Label ID="lblpub" CssClass="reporttext2" runat="server"></asp:Label></td>
        <td  class="upper2" >PUB CENTER:</td><td><asp:Label ID="pcenter" CssClass="reporttext2" runat="server"></asp:Label></td>
          <td  class="upper2">AGENCY TYPE:</td><td class="middle2" ><asp:Label ID="lblagtype" CssClass="reporttext2" runat="server" ></asp:Label></td>
           <td class="upper2">EDITION:</td><td class="middle2"><asp:Label ID="lbedition" CssClass="reporttext2" runat="server"></asp:Label></td>
       
 
    </tr>
     <tr style="border-bottom:dashed">
        
         <td  class="upper2">DATE FROM:</td><td class="middle2"> <asp:Label ID="lblfrom" CssClass="reporttext2" runat="server"></asp:Label></td>
         <td  class="upper2">TO DATE :</td><td class="middle2"> <asp:Label ID="lblto" CssClass="reporttext2" runat="server"></asp:Label></td>
         <td  class="upper2">RUN DATE:</td><td class="middle2"> <asp:Label ID="lbldate" CssClass="reporttext2" runat="server"></asp:Label></td>
         <td  class="upper2" >CLIENT:</td><td class="middle2" > <asp:Label ID="lbclient" CssClass="reporttext2" runat="server"></asp:Label></td>
    </tr>
     
    </table>
         <table width="100%"><tr valign="top"><td id="div1" runat="server" valign="top"></td></tr></table>

              <table><tr> <td><input id="hiddendateformat" type="hidden" runat="server" /></td></tr></table>
               <table><tr> <td><input id="hiddendatefrom" type="hidden" runat="server" /></td></tr></table>
               <table><tr> <td><input id="hiddendateto" type="hidden" runat="server" /></td></tr></table>
               
          <table>
               <tr>
                  <td><input id="hiddenascdesc" type="hidden" runat="server" /></td>
                  <td> <input id="hiddencioid" type="hidden" runat="server"  /></td>
               </tr>
         </table>

    </form>
</body>
</html>
