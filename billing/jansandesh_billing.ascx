<%@ Control Language="C#" AutoEventWireup="true" CodeFile="jansandesh_billing.ascx.cs" Inherits="jansandesh_billing" %>
<link href="css/jansandesh.css" type="text/css" rel="Stylesheet" />

<head><title>JANSANDESH BILL </title><script type="text/javascript"  language="javascript" src="javascript/billing.js"></script>
    <style type="text/css">
        .style1
        {
            border-bottom:thin solid;
            border-left:thin solid;
        }
    </style>
</head>
<p  id="P1" style="page-break-after:always;border:solid 1px black; width: 663px; ">
<table style="vertical-align:top;width:660px" cellspacing="0" cellpadding="0" border="1px"><tr><td>

<table  style="vertical-align:top;width:660px" cellspacing="0" cellpadding="0">
<%--<tr><td colspan="2" align="center" CssClass="agecnycodeclasspune"><b>ADVERTISHMENT INVOICE</b></td></tr>--%>
<tr>
<td>
<table>
<tr>
<td><asp:Label CssClass="agecnycodeclasspune" ID="pagestatus" runat ="server" aling="left" width="10%"></asp:Label></td>
</tr>
<tr><td><asp:Label  CssClass="agecnycodeclasspune" ID="lbcompaddress" runat ="server"></asp:Label></td>
</tr>
<tr><td><asp:Label CssClass="agecnycodeclasspune" ID="lbemailtxt" runat ="server"></asp:Label></td>
</tr>
</table>
    
</td>
<td  align="right" valign="top"width="330px">
<table>
<tr>
<td><img src="Images/Haribhoomi.jpg" style="height: 41px"/></td>
</tr>
<tr><td align="center"><b>INVOICE</b></td></tr>
</table>
    
</td>
</tr>

</table>
</td></tr></table>


<table style="vertical-align:top;width:660px" cellspacing="0" cellpadding="0">
<tr>
<td>
<table style="vertical-align:top;width:330px" cellspacing="0" cellpadding="0">
<tr><td ><asp:Label CssClass="agecnycodeclasspune" ID="lblto" runat ="server" Text="To,"></asp:Label></td></tr>
<tr><td ><asp:Label CssClass="agecnycodeclasspune" ID="lblagencycode" runat ="server"></asp:Label></td><td>&nbsp;</td>
    
</tr>
<tr><td ><asp:Label CssClass="agecnycodeclasspune" ID="lblagencyname" runat ="server"></asp:Label></td><td>:<asp:Label CssClass="agecnycodeclasspune" ID="agddxt" runat ="server"></asp:Label></td></tr>
<tr><td ><asp:Label CssClass="agecnycodeclasspune" ID="lbladd" runat="server"></asp:Label></td><td>:<asp:Label CssClass="agecnycodeclasspune" ID="agencyaddtxt" runat ="server"></asp:Label></td></tr>
</table>
</td>
<td>

<table style="vertical-align:top;width:330px;;" cellspacing="0" cellpadding="0" border="1">
<tr>
    <td><asp:Label CssClass="agecnycodeclasspune" ID="lbinvoiceno" runat ="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="txtinvoice" runat="server" CssClass="agecnycodeclasspune"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label CssClass="agecnycodeclasspune" ID="lblbilldt" runat ="server"></asp:Label><asp:Label ID="txtdt" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td>
</tr>
<tr><td><asp:Label ID="lbladrelpar" runat ="server" CssClass="agecnycodeclasspune"><b>Advertiser:</b></asp:Label>&nbsp;<asp:Label ID="txtcliname" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td></tr>
<tr>
    <td style="border-bottom:1px;"><asp:Label CssClass="agecnycodeclasspune" ID="lblcap" runat="server"></asp:Label>/<asp:Label CssClass="agecnycodeclasspune" ID="publ" runat ="server"></asp:Label>:&nbsp;&nbsp;<asp:Label ID="txtcaption"  CssClass="agecnycodeclasspune" runat="server"></asp:Label></td>
  
</tr>
<tr>
    <td style="border-bottom:1px;"><asp:Label CssClass="agecnycodeclasspune" ID="lblrefno" runat="server"></asp:Label>:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label CssClass="agecnycodeclasspune" ID="txtrefno" runat="server"></asp:Label>-&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label CssClass="agecnycodeclasspune" ID="txtrodate" runat="server"></asp:Label></td>
  
</tr>
    <tr><td><asp:Label ID="lblkey" CssClass="agecnycodeclasspune" runat="server"></asp:Label>:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="txtkey" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td>
  
</tr>
<tr><td></td><td></td></tr>
</table>
</td>
</tr>
</table>

<table  width="660px"   cellspacing="0" cellpadding="0" style="border-bottom:solid 1px black;vertical-align :top" >
<tr>
    <td valign ="top" width="660px" style="border-bottom:solid 1px black;height: 120px;" >
           <asp:Label  id="dynamictable"  runat ="server"></asp:Label>
       </td>
 </tr>
</table>

<table style="vertical-align:top;width:660px" cellspacing="0" cellpadding="0">
<tr>
<td>
<table style="vertical-align:top;width:660px" cellspacing="0" cellpadding="0" >
 <tr>
     <td width="500px"><b><asp:Label CssClass="agecnycodeclasspune" ID="lbadtype" runat ="server"></asp:Label></b>:&nbsp<asp:Label CssClass="agecnycodeclasspune" ID="adcat" runat ="server"></asp:Label></td>
     <td align="right" width="100px"><asp:Label ID="lb_total"  CssClass="agecnycodeclasspune" runat="server"></asp:Label></td>
     <td align="left" class="style1"><asp:Label ID="lb_totalamt" runat="server" CssClass ="agecnycodeclasspune"></asp:Label></td>
 </tr>
 <tr>
 <td width="500px">&nbsp;</td>
     <td align="right" width="100px"><asp:Label  CssClass="agecnycodeclasspune" ID="lbtrade1" runat ="server"></asp:Label></td>
     <td align="left" class="style1"><asp:Label ID="txtdiscal"  CssClass="agecnycodeclasspune" runat="server"></asp:Label></td>
 </tr>
 <tr>
  <td width="500px">&nbsp;</td>
     <td align="right" width="100px"><asp:Label ID="Label5"  CssClass="agecnycodeclasspune" runat="server"></asp:Label></td>
     <td align="left" class="style1"><asp:Label ID="Label8"  CssClass="agecnycodeclasspune" runat="server"></asp:Label>&nbsp;</td>
 </tr>
 <tr>
  <td width="500px">&nbsp;</td>
     <td align="right" width="100px"><asp:Label ID="Label2"  CssClass="agecnycodeclasspune" runat="server">Other charges</asp:Label></td>
     <td class="style1"><asp:Label ID="Label9"  CssClass="agecnycodeclasspune" runat="server"></asp:Label>&nbsp;</td>
 </tr>
 <tr>
  <td width="500px">&nbsp;</td>
     <td align="right" width="100px"><asp:Label ID="Label3" CssClass="agecnycodeclasspune" runat="server">(+/-)</asp:Label></td>
     <td class="style1"><asp:Label ID="Label10" CssClass="agecnycodeclasspune" runat="server"></asp:Label>&nbsp;</td>
 </tr>
 <tr>
  <td width="500px">&nbsp;</td>
     <td align="right" width="100px"><asp:Label  CssClass="agecnycodeclasspune" ID="lblnetpayable" runat ="server"></asp:Label></td>
     <td class="style1"><asp:Label ID="netpay" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td>
 </tr>
 <tr>
 <td width="530px" colspan="2"><asp:Label ID="lbwordin" runat="server" CssClass ="insertiontxtclass2" ><b>Net Amount in words : </b>&nbsp;</asp:Label><b><asp:Label ID="lbwordinrupees" runat="server" CssClass="insertiontxtclass2"  ></asp:Label></b></td>
 </tr>
</table>
</td>
<%--<td>
<table style="vertical-align:top;width:160px" cellspacing="0" cellpadding="0" border="1px">
 <tr><td align="left"><asp:Label ID="lb_totalamt" runat="server" CssClass ="agecnycodeclasspune"></asp:Label></td></tr>
 <tr><td align="left"><asp:Label ID="txtdiscal"  CssClass="agecnycodeclasspune" runat="server"></asp:Label></td></tr>
 <tr><td align="left"><asp:Label ID="Label8"  CssClass="agecnycodeclasspune" runat="server"></asp:Label></td></tr>
 <tr><td align="left"><asp:Label ID="Label9"  CssClass="agecnycodeclasspune" runat="server"></asp:Label></td></tr>
 <tr><td align="left"><asp:Label ID="Label10" CssClass="agecnycodeclasspune" runat="server"></asp:Label></td></tr>
 <tr><td align="left"><asp:Label ID="netpay" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td></tr>
</table>

</td>--%>
</tr>
</table>
<table   width="660px" cellspacing="0" cellpadding="0" border="1px" >
  <tr>
  <td  style="font-size:9px;font-family :Times New Roman; height: 54px;border-bottom :solid 1px black;width: 335px;border-right:solid 1px black;">
 <asp:Label ID="hidedata" runat ="server" ></asp:Label>
  </td></tr></table>







</p>