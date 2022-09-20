<%@ Control Language="C#" AutoEventWireup="true" CodeFile="punebillclassi.ascx.cs" Inherits="punebillclassi" %>
<link href="css/billingStyleSheet.css" type="text/css" rel="Stylesheet" />

<head>
<title>PUNE CLASSI BILL</title>

</head>
<div id="showtable" runat ="server" style="position:absolute;top:0px;left:0px;border:none;display:block;z-index:0;">

<table style="border:solid 1px black" cellspacing="0" cellpadding="0"><tr><td>




 <table  style="border-bottom:solid 1px black" width="670px" cellspacing="0" cellpadding="0" >
 <tr>
     <td  valign ="middle"  align ="center" ><img src="Images/pune.jpg" height ="60px"/></td>
     <td  valign ="middle"  align ="center" style="font-size:18px"><b>SHREE AMBIKA PRINTER & PUBLICATION</b></td>
     <td  valign ="middle"  align ="center" ><u>INVOICE</u></td>
 </tr>
 
 <tr>
    <td  valign ="middle"  align ="left"  style="font-size:14px"><asp:Label CssClass="agecnycodeclasspune" ID="lbwaluj" runat ="server"></asp:Label></td>
     <td valign ="middle"  align ="left" colspan="2" style="font-size:14px"><asp:Label ID="lbwalujadd" runat ="server"></asp:Label></td>

 </tr>
 <tr>
    <td valign ="middle"  align ="left" style="font-size:14px"><asp:Label CssClass="agecnycodeclasspune" ID="lbbranch" runat ="server"></asp:Label></td>
    <td valign ="middle"  align ="left" colspan="2" style="font-size:14px"><asp:Label ID="lbbranchtxt" runat ="server"></asp:Label></td>

 </tr>
 </table>
 <table width="680px" cellspacing="0" cellpadding="0" style="border-bottom:solid 1px black">
 <tr>
 <td valign ="top"   >
 <table width="400px" cellspacing="0" cellpadding="0"  >
 <tr>
 <td  valign ="top" ><asp:Label CssClass="agecnycodeclasspune" ID="agencytxt" runat ="server"></asp:Label></td>
 <td colspan="3" valign ="top" ><asp:Label CssClass="dateclasspune" ID="agddxt" runat ="server"></asp:Label></td>
 </tr>
 <tr><td  ><asp:Label CssClass="agecnycodeclasspune" ID="space2" runat ="server"></asp:Label></td></tr>
 <tr>
 <td style="height: 13px" ><asp:Label CssClass="agecnycodeclasspune" ID="lbagencyadd" runat ="server"></asp:Label></td>
 <td colspan="3" style="height: 13px"><asp:Label CssClass="dateclasspune" ID="lbagencyaddtxt" runat ="server"></asp:Label></td>
 </tr>
 <tr><td ><asp:Label CssClass="agecnycodeclasspune" ID="space4" runat ="server"></asp:Label></td></tr>
 <tr><td ><asp:Label CssClass="agecnycodeclasspune" ID="space3" runat ="server"></asp:Label></td></tr>
 
 <tr><td  ><asp:Label CssClass="agecnycodeclasspune" ID="space5" runat ="server"></asp:Label></td></tr>
</table></td>
<td >
<table width="270px" cellspacing="0" cellpadding="0">
<tr>
 <td><asp:Label CssClass="agecnycodeclasspune" ID="lbinvoiceno" runat ="server"></asp:Label></td>
 <td colspan="2"><asp:Label CssClass="dateclasspune" ID="txtinvoice" runat ="server"></asp:Label></td>
</tr>
<tr>
<td><asp:Label CssClass="agecnycodeclasspune" ID="lbdate" runat ="server"></asp:Label></td>
<td colspan="2"><asp:Label CssClass="dateclasspune" ID="runtxt" runat ="server"></asp:Label></td>
</tr>
<tr>
<td><asp:Label CssClass="agecnycodeclasspune" ID="lbcreditdate" runat ="server"></asp:Label></td>
<td colspan="2"><asp:Label CssClass="dateclasspune" ID="lbcreditdatetxt" runat ="server"></asp:Label></td>
</tr>
<tr>
<td><asp:Label CssClass="agecnycodeclasspune" ID="lbadtype" runat ="server"></asp:Label></td>
<td colspan="2"><asp:Label CssClass="dateclasspune" ID="lbadtypetxt" runat ="server"></asp:Label></td>
</tr>
<tr>
<td ><asp:Label CssClass="agecnycodeclasspune" ID="lbadcat" runat ="server"></asp:Label></td>
<td colspan="2" ><asp:Label CssClass="dateclasspune" ID="lbadcattxt" runat ="server"></asp:Label></td>
</tr>
<tr>
<td ><asp:Label CssClass="agecnycodeclasspune" ID="lbformonth" runat ="server"></asp:Label></td>
<td colspan="2" ><asp:Label CssClass="dateclasspune" ID="lbformonthtxt" runat ="server"></asp:Label></td>
</tr>
 <tr><td  ><asp:Label CssClass="agecnycodeclasspune" ID="space6" runat ="server"></asp:Label></td></tr>
</table>
</td>
</tr>
</table>
<%--<table width="650px" cellspacing="0" cellpadding="0" style="border-bottom:solid 1px black" >
<tr>
<td >
<table width ="450px" cellspacing="0" cellpadding="0"><tr>
<td  ><asp:Label CssClass="agecnycodeclasspune" ID="lbpackagena" runat ="server"></asp:Label></td>
<td colspan="3" style="height: 14px"><asp:Label CssClass="dateclasspune" ID="txtpackname" runat ="server"></asp:Label></td>
</tr></table>
</td>
<td ><table width ="200px" cellspacing="0" cellpadding="0"><tr>
<td><asp:Label CssClass="agecnycodeclasspune" ID="lbpackagerate" runat ="server"></asp:Label></td>
<td colspan="2"><asp:Label CssClass="dateclasspune" ID="lbpakgrate" runat ="server"></asp:Label></td>
</tr></table></td>
</tr></table>--%>


<table width="670px" cellspacing="0" cellpadding="0" style="border-bottom:solid 1px black" ><tr>
       <td valign="top" style="border-right:solid 1px black;border-top:solid 1px black;">
       <table cellspacing="0" cellpadding="0"><tr><td>
        <table cellspacing="0" cellpadding="0"  width="670px"   class="table1" >
            <tr><td colspan="2"   valign="top" align="left"  id="tabledy" runat ="server" style="height: 18px">
               <asp:Label ID="dynamictable" runat="server" CssClass ="dateclasspune" ></asp:Label>                       
                 </td></tr>
                 
                 </table>
                 
                </td></tr>
        </table>
       </td>
 
       <td >
        <%--<table  width="200" cellspacing="0" cellpadding="0">
        <tr>
            <td style="height: 19px"><asp:Label CssClass="agecnycodeclasspune" ID="lbinsertionnumber" runat ="server"></asp:Label> </td>
            <td style="height: 19px"><asp:Label CssClass="dateclasspune" ID="insertiontxt" runat ="server"></asp:Label></td>
        </tr>
        <tr><td CssClass="agecnycodeclasspune" colspan="2">&nbsp;</td></tr>
        <tr>
            <td><asp:Label  ID="lblamount" runat ="server"  CssClass="agecnycodeclasspune"></asp:Label></td>
            <td><asp:Label   ID="amount1" runat ="server"  CssClass="dateclasspune"></asp:Label></td>
        </tr>
        <tr><td CssClass="agecnycodeclasspune" colspan="2">&nbsp;</td></tr>
        <tr>
            <td><asp:Label CssClass="agecnycodeclasspune" ID="lbextpre" runat ="server"></asp:Label></td>
            <td><asp:Label CssClass="dateclasspune" ID="lbextrapre" runat ="server"></asp:Label></td>
        </tr>
        <tr><td CssClass="agecnycodeclasspune" colspan="2">&nbsp;</td></tr>
        
        <tr>
            <td><asp:Label CssClass="agecnycodeclasspune" ID="lbgr" runat ="server"></asp:Label></td>
            <td><asp:Label CssClass="dateclasspune" ID="txtgr" runat ="server"></asp:Label></td>
        </tr>
              <tr><td CssClass="agecnycodeclasspune" colspan="2">&nbsp;</td></tr>

        <tr>
            <td><asp:Label CssClass="agecnycodeclasspune" ID="lbtrade1" runat ="server"></asp:Label></td>
            <td><asp:Label CssClass="dateclasspune" ID="txtdiscal" runat ="server"></asp:Label></td>
        </tr>
                <tr><td CssClass="agecnycodeclasspune" colspan="2">&nbsp;</td></tr>

        <tr>
            <td><asp:Label CssClass="agecnycodeclasspune" ID="lbadtd" runat ="server"></asp:Label></td>
            <td><asp:Label CssClass="dateclasspune" ID="lbadtdtxt" runat ="server"></asp:Label></td>
        </tr>
                <tr><td CssClass="agecnycodeclasspune" colspan="2">&nbsp;</td></tr>

        <tr style="border-bottom:solid 1px black">
            <td><asp:Label CssClass="agecnycodeclasspune" ID="lblnetpayable" runat ="server"></asp:Label></td>
            <td><asp:Label CssClass="dateclasspune" ID="netpay" runat ="server"></asp:Label></td>
        </tr>
           
  <tr>
        <td style="border-top:solid 1px black;  height:50px" colspan="2">&nbsp;</td>
  </tr>
  <tr valign="bottom">
        <td style="border-bottom:solid 1px black" valign="bottom" align="center" colspan="2"><b>Advt. Manager /Accountant</b></td>
  </tr>  </table>
  
  </td>--%>
 <%-- </tr>
   <tr ><td ><table cellspacing="0" cellpadding="0" style="border-right:solid 1px black" width="451px"><tr>
                 <td align="left"><asp:Label ID="lbinwords" runat="server" CssClass ="agecnycodeclasspune" Text="In Words Rupees  :"></asp:Label></td>
                 <td align="left" ><asp:Label ID="lbwordinrupees" runat="server" CssClass ="dateclasspune" ></asp:Label></td>
                 </tr>  </table>
                 </td>         
  <td style="height: 32px" >--%> </td></tr>
  </table>
    
<table width="670px" cellspacing="0" cellpadding="0"  style="font-size:13px;border-bottom:solid 1px black">
<tr>
<td colspan ="4" style="font-size:13px;border-bottom:solid 1px black;">
<asp:Label ID="total" runat ="server" CssClass="agecnycodeclasspune" >Total</asp:Label>

</td>
<td style="font-size:13px;border-bottom:solid 1px black" colspan ="2" align ="right" >
<asp:Label ID="txttotal" runat ="server" ></asp:Label>

</td>


</tr>
<tr >
<td colspan="6" style="font-size:13px;border-bottom:solid 1px black"><b>Terms & Condition : 1)</b>Payment Should be made in favour of <b>"Shree Ambika Printer & Publication". 2)</b>Only official receipt
issued by us will binding on us.<b>3) </b>Objection or complaint regardingthe bill (if any) should be brought to our notice within 15 days
from the presentation of the bill,falling which the bill become fully payable. <b>4)</b> All payment should be made according to the credit 
limits to avoid interest,which will be levied @24% per annum.<b>5)</b>All disputesare subjected to <b>AURANGABAD</b> Jurisdiction only.</td>
</tr>
<tr>
<td align="left" style="height: 13px"><asp:Label CssClass="agecnycodeclasspune" ID="lbemail" runat ="server"></asp:Label></td>
<td style="height: 13px"><asp:Label CssClass="dateclasspune" ID="lbemailtxt" runat ="server"></asp:Label></td>
<td style="height: 13px"><asp:Label CssClass="agecnycodeclasspune" ID="lbeoe" runat ="server" Text="E.&O.E."></asp:Label></td>

<td align="right" style="height: 13px"><asp:Label CssClass="agecnycodeclasspune" ID="lbpune" runat ="server"></asp:Label></td>
<td style="height: 13px"><asp:Label CssClass="dateclasspune" ID="lbpunetxt" runat ="server"></asp:Label></td>

</tr>
</table>
</td>
</tr></table>
</div> 