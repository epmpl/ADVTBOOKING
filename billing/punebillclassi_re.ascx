<%@ Control Language="C#" AutoEventWireup="true" CodeFile="punebillclassi_re.ascx.cs" Inherits="punebillclassi_re" %>

<link href="css/billingStyleSheet.css" type="text/css" rel="Stylesheet" />

<head>
<title>PUNE CLASSI BILL</title>

<script language="javascript" type="text/javascript">
// <!CDATA[

function TABLE1_onclick() {

}

// ]]>
</script>
</head>

<table  class ="break">
<tr>
<td>


<table style="border:solid 1px black" cellspacing="0" cellpadding="0" id="TABLE1" onclick="return TABLE1_onclick()"><tr><td>




 <table  style="border-bottom:solid 1px black" width="650px" cellspacing="0" cellpadding="0" >
 <tr>
     <td  valign ="middle"  align ="left"  ><img src="Images/pune.jpg" height ="60px"/></td>
    <td  valign ="middle"  align ="center" style="font-family:Times New Roman ;font-size:20px;font-weight :bold " ><asp:Label CssClass="dateclasspuneheading" ID="lbcompanyname" runat ="server"></asp:Label></td>
      <td  valign ="middle"  align ="center" style="font-family:Verdana UI;font-size:20px;font-weight :bold" ><u><asp:Label CssClass="dateclasspuneheading" ID="lbbilltype" runat ="server" Text="INVOICE"></asp:Label></u></td>
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
 <table width="650px" cellspacing="0" cellpadding="0" style="border-bottom:solid 1px black">
 <tr>
 <td valign="top" >
 <table width="450px" cellspacing="0" cellpadding="0" style ="vertical-align :top ;">
 <tr>
 <td style="height: 13px" valign ="top" ><asp:Label CssClass="agecnycodeclasspune" ID="agencytxt" runat ="server"></asp:Label></td>
 <td colspan="3" style="height: 13px"><asp:Label CssClass="dateclasspune" ID="agddxt" runat ="server"></asp:Label></td>
 </tr>
 <tr><td  ><asp:Label CssClass="agecnycodeclasspune" ID="space2" runat ="server"></asp:Label></td></tr>
 <tr>
 <td style="height: 13px" ><asp:Label CssClass="agecnycodeclasspune" ID="lbagencyadd" runat ="server"></asp:Label></td>
 <td colspan="3" style="height: 13px"><asp:Label CssClass="dateclasspune" ID="lbagencyaddtxt" runat ="server"></asp:Label></td>
 </tr>
 <tr><td ><asp:Label CssClass="agecnycodeclasspune" ID="space4" runat ="server"></asp:Label></td></tr>
 <tr><td ><asp:Label CssClass="agecnycodeclasspune" ID="space3" runat ="server"></asp:Label></td></tr>
 <tr>
<%-- <td style="height: 13px" ><asp:Label CssClass="agecnycodeclasspune" ID="lbclientna" runat ="server"></asp:Label></td>
 <td colspan="3" style="height: 13px"><asp:Label CssClass="dateclasspune" ID="txtcliname" runat ="server"></asp:Label></td>
--%> </tr>
 <tr><td  ><asp:Label CssClass="agecnycodeclasspune" ID="space5" runat ="server"></asp:Label></td></tr>
</table></td>
<td style="height: 100px" valign ="top" >
<table width="200px" cellspacing="0" cellpadding="0">
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



<table width="650px" cellspacing="0" cellpadding="0" style="border-bottom:solid 1px black" ><tr>
       <td valign="top" style="border-right:solid 1px black">
       <table cellspacing="0" cellpadding="0"><tr><td>
        <table cellspacing="0" cellpadding="0"  width="650px"   class="table1" >
            <tr><td colspan="2"   valign="top" align="left"  id="tabledy" runat ="server" style="height: 18px">
               <asp:Label ID="dynamictable" runat="server" CssClass ="dateclasspune" ></asp:Label>                       
                 </td></tr>
                 
                 </table>
                 
                </td></tr>
        </table>
       </td>
 
       <td >
        </td></tr>
  </table>
  
  
  <table width="650px" cellspacing="0" cellpadding="0"  border="1">
        <tr>
<td  style="font-size:13px;border-bottom:solid 1px black;">
<asp:Label ID="total" runat ="server" CssClass="agecnycodeclasspune" >Total</asp:Label>

</td>
<td style="font-size:13px;border-bottom:solid 1px black" align ="right" >
<asp:Label ID="txttotal" runat ="server" ></asp:Label>

</td>


</tr>
                     
  </table>
    
<table width="650px" cellspacing="0" cellpadding="0" >
<tr  >
<td   colspan="4" style="font-size:10px;font-family :Arial; height: 54px;border-bottom :solid 1px black" align ="left"><b>Terms & Condition : 1)</b>Payment Should be made in favour of <b><asp:Label CssClass="dateclasspune" ID="lbterms" runat ="server"></asp:Label>. 2)</b>Only official receipt
issued by us will binding on us.<b>3) </b>Objection or complaint regarding the bill (if any) should be brought to our notice within 15 days
from the presentation of the bill,falling which the bill become fully payable. <b>4)</b> All payment should be made according to the credit
limits to avoid interest,which will be levied @24% per annum.<b>5)</b>All disputes are subjected to <b><asp:Label CssClass="dateclasspune" ID="lbnaam" runat ="server"></asp:Label></b> Jurisdiction only.</td>

</tr>
<tr>
<td>
<table width="650px"  cellspacing="0" cellpadding="0" >
<tr>

<td align="left" valign ="bottom" ><asp:Label CssClass="agecnycodeclasspune" ID="lbemail" runat ="server"></asp:Label><asp:Label CssClass="dateclasspune" ID="lbemailtxt" runat ="server"></asp:Label></td>

<td   valign ="bottom"  ><asp:Label CssClass="agecnycodeclasspune" ID="lbeoe" runat ="server" Text="E.&O.E."></asp:Label></td>

<td align="right" colspan ="2"  valign ="bottom" ><asp:Label CssClass="agecnycodeclasspune" ID="lbpune" runat ="server"></asp:Label><asp:Label CssClass="dateclasspune" ID="lbpunetxt" runat ="server"></asp:Label></td>


</tr>
</table>
</td>
</tr></table>
</td>
</tr>
</table>
</td> 
</tr> 
</table> 