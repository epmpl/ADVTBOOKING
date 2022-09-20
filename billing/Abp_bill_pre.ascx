<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Abp_bill_pre.ascx.cs" Inherits="Abp_bill_pre" %>
<link href="css/pratidin_bill.css" type="text/css" rel="Stylesheet" />


<head>
<title></title>
<script type="text/javascript"  language="javascript" src="javascript/billing.js"></script>

    <style type="text/css">
        .style1
        {
            width: 63px;
        }
    </style>

</head>
<p  id="P1" style="page-break-after:always;">
<table  cellspacing="0" cellpadding="0"  width="660px" >
<tr>
<td style="width: 660px" valign ="top" >
 <table width="660px;"  cellspacing="0" cellpadding="0"  style="border:solid 1px black;">
 <tr style="height:125px;"><td style="width:50px;padding-top:20px;padding-left:5px; visibility:hidden;" valign="top"><asp:Label CssClass="dataname" ID="lblnameadd" runat ="server"><b>FROM: </b></asp:Label></td>
 <td style="width:200px;" valign="middle">
 <table cellpadding="0" cellspacing="0" style="height: 86px"><tr><td style="font-size:11px;font-family :Verdana;"><asp:Label  CssClass="dataname" ID="lbl1" runat ="server"></asp:Label></td></tr><tr><td style="font-size:11px;font-family :Verdana;"><asp:Label  CssClass="dataname" ID="lbl2" runat ="server"></asp:Label></td></tr><tr><td style="width:200px;"><asp:Label  ID="lbl3" CssClass="dataname" runat ="server"></asp:Label></td></tr><tr><td style="width:200px;"><asp:Label  ID="lbl4" CssClass="dataname" runat ="server"></asp:Label><asp:Label CssClass="dataname" ID="lbl5" runat ="server"></asp:Label></td></tr>
 </table></td>
 <td style="width:50px;padding-top:20px;padding-left:5px;border-left:solid 1px black;visibility:hidden;" valign="top"><asp:Label CssClass="dataname" ID="Label10" runat ="server"><b>TO: </b></asp:Label></td>
  <td style="width:360px;" valign="middle">
  <table cellpadding="0" cellspacing="0" style="padding-top:5px; height: 81px;"><tr><td style="width:200px;"><asp:Label  CssClass="dataname" ID="agddxt" runat ="server"></asp:Label></td></tr><tr><td style="width:200px;"><asp:Label CssClass="dataname" ID="agencyaddtxt" runat ="server"></asp:Label></td></tr><tr><td style="width:200px;"><asp:Label  CssClass="dataname" ID="lbcityname" runat ="server"></asp:Label><asp:Label CssClass="dataname" ID="txtpinno" runat ="server"></asp:Label></td></tr>
 </table></td></tr></table>
 <table cellpadding="0" width="660px" cellspacing="0" style="border:solid 1px black;margin:10px 0px 0px 0px;"><tr align="center"><td>
 <table width="640px"  cellspacing="0" cellpadding="0" style="border:solid 1px black;margin:10px 0px 0px 0px;">
  <tr align="center"><td>
   <table width="640px"  cellspacing="0" cellpadding="0">
 <tr style="height:20px;visibility:hidden;">
    <td style="width:120px; border-bottom:solid 1px black; border-right:solid 1px black;" colspan="2" align="center"><asp:Label  CssClass="tabro" ID="lblro"  runat="server"></asp:Label></td><td style="width:90px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="tabro" ID="lblrodate"  runat="server"></asp:Label></td><td style="width:90px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="tabro" ID="lblkey"  runat="server"></asp:Label></td><td style="width:70px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="tabro" ID="lblpage"  runat="server"></asp:Label></td><td style="width:90px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="tabro" ID="lblagno"  runat="server"></asp:Label></td><td style="width:90px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="tabro" ID="lblcaption"  runat="server"></asp:Label></td><td style="width:90px;border-bottom:solid 1px black;" align="center"><asp:Label  CssClass="tabro" ID="lbldes"  runat="server"></asp:Label></td>
 </tr>
 <tr style="height:40px;">
    <td style="width:120px;border-bottom:solid 1px black; border-right:solid 1px black;" colspan="2" align="center"><asp:Label  CssClass="tabro" ID="txtro"  runat="server"></asp:Label></td><td style="width:90px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="tabro" ID="txtrodate"  runat="server"></asp:Label></td><td style="width:90px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="tabro" ID="txtkey"  runat="server"></asp:Label></td><td style="width:70px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="tabro" ID="txtpage"  runat="server"></asp:Label></td><td style="width:90px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="tabro" ID="txtagno"  runat="server"></asp:Label></td><td style="width:90px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="tabro" ID="txtcaption"  runat="server"></asp:Label></td><td style="width:90px;border-bottom:solid 1px black;" align="center"><asp:Label  CssClass="tabro" ID="txtdes"  runat="server"></asp:Label></td>
 </tr>
 
 <tr style="height:20px;visibility:hidden;">
 <td style="width:60px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="tabro" ID="lblpublication"  runat="server"></asp:Label></td><td style="width:60px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="tabro" ID="lbldate"  runat="server"></asp:Label></td>
    <%--<td style="width:60px;" align="center"><table cellpadding="0" cellspacing="0"><tr><td style="width:50px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="tabro" ID="lblpublication"  runat="server"></asp:Label></td><td style="width:50px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="tabro" ID="lbldate"  runat="server"></asp:Label></td></tr></table></td>--%>
    <td style="width:90px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center" colspan="2"><asp:Label  CssClass="tabro" ID="lblmeasurement"  runat="server"></asp:Label></td><td style="width:70px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="tabro" ID="lblratetype"  runat="server"></asp:Label></td><td style="width:90px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="tabro" ID="lblrate"  runat="server"></asp:Label></td><td style="width:90px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="tabro" ID="lbladjustment"  runat="server"></asp:Label></td><td style="width:90px;border-bottom:solid 1px black;" align="center"><asp:Label  CssClass="tabro" ID="lbltotal"  runat="server"></asp:Label></td>
 </tr>
 <tr style="height:40px;">
    <%--<td style="width:100px;" align="center"><table cellpadding="0" cellspacing="0"><tr><td style="width:50px;height:40px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="tabro" ID="txtpublication"  runat="server"></asp:Label></td><td style="width:50px;height:40px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="tabro" ID="txtdate"  runat="server"></asp:Label></td></tr></table></td>--%>
    <td style="width:60px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="tabro" ID="txtpublication"  runat="server"></asp:Label></td><td style="width:60px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="tabro" ID="txtdate"  runat="server"></asp:Label></td><td style="width:90px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center" colspan="2"><asp:Label  CssClass="tabro" ID="txtmeasurement"  runat="server"></asp:Label></td><td style="width:70px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="tabro" ID="txtratetype"  runat="server"></asp:Label></td><td style="width:90px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="tabro" ID="txtrate"  runat="server"></asp:Label></td><td style="width:90px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="tabro" ID="txtadjustment"  runat="server"></asp:Label></td><td style="width:90px;border-bottom:solid 1px black;" align="center"><asp:Label  CssClass="tabro" ID="txttotal"  runat="server"></asp:Label></td>
 </tr>
 </table>
   <table width="640px"  cellspacing="0" cellpadding="0">
   <tr style="height:150px;">
       <td style="width:370px; border-right:solid 1px black;" align="left"><asp:Label  CssClass="dataname" ID="lbltorat"  runat="server"><b>Total Amount in Words:</b></asp:Label><br /><br /><asp:Label  CssClass="dataname" ID="txtnetpayword"  runat="server"></asp:Label></td>
            <td><table cellpadding="0" cellspacing="0" ><tr style="height:100px;"><td style="width:180px;border-bottom:solid 1px black; border-right:solid 1px black; padding-right:5px;padding-bottom:15px;visibility:hidden;" align="right" valign="bottom"><asp:Label  CssClass="dataname" ID="Label1"  runat="server"><b>Net Amount</b></asp:Label></td><td style="border-bottom:solid 1px black;"><table cellpadding="0" cellspacing="0"><tr style="height:60px;" valign="top"></tr><tr style="height:40px;"><td style="width:90px;" align="center"><asp:Label  CssClass="tabro" ID="txtnetrate"  runat="server"></asp:Label></td></tr></table></td></tr>
            <tr><td colspan="2" align="left" style="visibility:hidden;"><asp:Label  CssClass="tabro" ID="Label2"  runat="server">E & O E</asp:Label><br /><br /><asp:Label  CssClass="tabro" ID="Label4"  runat="server"><b>Manager-Sales Account</b></asp:Label></td></tr></table></td>
   </tr>
   </table>
   <%--<table cellpadding="0" cellspacing="0">
   <tr><td>
   <asp:Label ID="lblnote" runat="server"><b>NO.</b>Please pay by crossed cheque Draft in favour of ABP Pvt. Ltd.</asp:Label>
   </td></tr>
   </table>--%>
  
</td>
</tr><tr style="width:100%"><td colspan="7" style="border-top:solid 1px black;" align="left"><asp:Label  CssClass="dataname" ID="lblnote"  runat="server"><b>NO.</b>Please pay by crossed cheque Draft in favour of ABP Pvt. Ltd.</asp:Label></td></tr>
</table></td></tr>
<tr style="height:40px;"></tr>
</table></td></tr>
</table>
</p>
