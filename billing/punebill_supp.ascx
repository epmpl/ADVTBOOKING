<%@ Control Language="C#" AutoEventWireup="true" CodeFile="punebill_supp.ascx.cs" Inherits="punebill_supp" %>



<link href="css/billingStyleSheet.css" type="text/css" rel="Stylesheet" />

<head>
<title>PUNE FINAL BILL</title>

</head>
<div id="showtable" runat ="server" style="position:absolute;top:0px;left:0px;border:none;display:block;z-index:0;">

<table style="border:solid 1px black" cellspacing="0" cellpadding="0"><tr><td>



<table  style="border-bottom:solid 1px black" width="650px" cellspacing="0" cellpadding="0" >
<tr>
     <td  rowspan="2" valign ="middle"  align ="center" style="width:10px"><img src="Images/pune.jpg" height ="40px"/></td>
     <td  valign ="middle"  align ="center" style="font-family:Times New Roman ;font-size:20px;font-weight :bold " ><asp:Label CssClass="dateclasspuneheading" ID="lbcompanyname" runat ="server"></asp:Label></td>
     <td  valign ="middle"  align ="center" style="font-family:Verdana UI;font-size:20px;font-weight :bold" ><u><asp:Label CssClass="dateclasspuneheading" ID="lbbilltype" runat ="server"></asp:Label></u></td>
 </tr>
 
 <tr>
    <td valign ="middle"  align ="left" colspan="3" style="border-bottom:solid 1px black;font-size:13px"><asp:Label ID="lbcompaddress" runat ="server"></asp:Label></td>
 </tr>
 </table>
 <table width="650px" cellspacing="0" cellpadding="0" style="border-bottom:solid 1px black">
 <tr>
 <td>
 <table width="450px" cellspacing="0" cellpadding="0">
 <tr>
 <td align ="left" width="100px" ><asp:Label CssClass="agecnycodeclasspune" ID="agencytxt" runat ="server"></asp:Label></td>
 <td colspan="3" align ="left" valign ="top" ><asp:Label CssClass="dateclasspune" ID="agddxt" runat ="server"></asp:Label></td>
 </tr>
 <tr>
 <td align ="left"  ><asp:Label CssClass="agecnycodeclasspune" ID="lbclientadd" runat ="server"></asp:Label></td>
 <td colspan="3" align ="left" ><asp:Label CssClass="dateclasspune" ID="lbaddress" runat ="server"></asp:Label></td>
 </tr>
 <tr><td  colspan="3">&nbsp;</td></tr>
 <tr>
 <td align ="left"  ><asp:Label CssClass="agecnycodeclasspune" ID="lbclientna" runat ="server"></asp:Label></td>
 <td colspan="3" align ="left" ><asp:Label CssClass="dateclasspune" ID="txtcliname" runat ="server"></asp:Label></td>
 </tr>
 <tr>
  <td align ="left" ><asp:Label CssClass="agecnycodeclasspune" ID="lbcap" runat ="server"></asp:Label></td>
 <td colspan="3" align ="left" ><asp:Label CssClass="dateclasspune" ID="lbcaption" runat ="server"></asp:Label></td>
</tr>
</table></td>
<td>
<table width="200px" cellspacing="0" cellpadding="0">
<tr>
 <td valign ="top" align ="left"  ><asp:Label CssClass="agecnycodeclasspune" ID="lbinvoiceno" runat ="server"></asp:Label></td>
 <td colspan="2" valign ="top" align ="left" ><asp:Label CssClass="dateclasspune" ID="txtinvoice" runat ="server"></asp:Label></td>
</tr>
<tr>
<td align ="left" ><asp:Label CssClass="agecnycodeclasspune" ID="lbdate" runat ="server"></asp:Label></td>
<td colspan="2" align ="left" ><asp:Label CssClass="dateclasspune" ID="runtxt" runat ="server"></asp:Label></td>
</tr>
<tr>
<td align="left"><asp:Label CssClass="agecnycodeclasspune" ID="lbddate" runat ="server"></asp:Label></td>
<td colspan="2" align="left"><asp:Label CssClass="dateclasspune" ID="ldduedate" runat ="server"></asp:Label></td>
</tr>
<tr>
<td align ="left" ><asp:Label CssClass="agecnycodeclasspune" ID="lbadtype" runat ="server"></asp:Label></td>
<td colspan="2" align ="left" ><asp:Label CssClass="dateclasspune" ID="adcat" runat ="server"></asp:Label></td>
</tr>
<tr>
<td align ="left" ><asp:Label CssClass="agecnycodeclasspune" ID="lbrodat" runat ="server"></asp:Label></td>
<td colspan="2" align ="left" ><asp:Label CssClass="dateclasspune" ID="lbronodate" runat ="server"></asp:Label></td>
</tr>
</table>
</td>
</tr>
</table>
<table width="650px" cellspacing="0" cellpadding="0" style="border-bottom:solid 1px black" >
<tr>
<td >
<table width ="450px" cellspacing="0" cellpadding="0"><tr>
<td align="left"  width ="100px"><asp:Label CssClass="agecnycodeclasspune" ID="lbpackagena" runat ="server"></asp:Label></td>
<td  style="height: 14px" align ="left"><asp:Label CssClass="dateclasspune" ID="txtpackname" runat ="server"></asp:Label></td>
</tr></table>
</td>
<td ><table width ="200px" cellspacing="0" cellpadding="0"><tr>
<td><asp:Label CssClass="agecnycodeclasspune" ID="lbpackagerate" runat ="server"></asp:Label></td>
<td colspan="2"><asp:Label CssClass="dateclasspune" ID="lbpakgrate" runat ="server"></asp:Label></td>
</tr></table></td>
</tr></table>

<table width="650px" cellspacing="0" cellpadding="0" style="border-bottom:solid 1px black" ><tr>
       <td valign="top" style="border-right:solid 1px black">
       <table cellspacing="0" cellpadding="0"><tr><td colspan="2">
        <table cellspacing="0" cellpadding="0"  width="450px"   class="table1" >
            <tr><td colspan="2"   valign="top" align="left"  id="tabledy" runat ="server" style="height: 18px">
               <asp:Label ID="dynamictable" runat="server" CssClass ="dateclasspune" ></asp:Label>                       
                 </td></tr>
                 
                 </table>
                 
                </td></tr>
        </table>
       </td>
 
       <td >
        <table  width="200" cellspacing="0" cellpadding="0">
        <tr>
            <td style="height: 19px" align="left"><asp:Label CssClass="agecnycodeclasspune" ID="lbinsertionnumber" runat ="server"></asp:Label> </td>
            <td style="height: 19px" align="right"><asp:Label CssClass="dateclasspune" ID="insertiontxt" runat ="server"></asp:Label></td>
        </tr>
        
        <tr>
            <td align="left"> <asp:Label  ID="lblamount" runat ="server"  CssClass="agecnycodeclasspune"></asp:Label></td>
            <td align="right"><asp:Label   ID="amount1" runat ="server"  CssClass="dateclasspune"></asp:Label></td>
        </tr>
     
        <tr>
            <td align="left"><asp:Label CssClass="agecnycodeclasspune" ID="lbextpre" runat ="server"></asp:Label></td>
            <td align="right"><asp:Label CssClass="dateclasspune" ID="lbextrapre" runat ="server"></asp:Label></td>
        </tr>
        
        
        <tr>
            <td align="left"><asp:Label CssClass="agecnycodeclasspune" ID="lbgr" runat ="server"></asp:Label></td>
            <td align="right"><asp:Label CssClass="dateclasspune" ID="txtgr" runat ="server"></asp:Label></td>
        </tr>
              

        <tr>
            <td align="left"><asp:Label CssClass="agecnycodeclasspune" ID="lbtrade1" runat ="server"></asp:Label></td>
            <td align="right"><asp:Label CssClass="dateclasspune" ID="txtdiscal" runat ="server"></asp:Label></td>
        </tr>
                

        <tr>
            <td align="left"><asp:Label CssClass="agecnycodeclasspune" ID="lbadtd" runat ="server"></asp:Label></td>
            <td align="right"><asp:Label CssClass="dateclasspune" ID="lbadtdtxt" runat ="server"></asp:Label></td>
        </tr>
               

        <tr style="border-bottom:solid 1px black">
            <td align="left"><asp:Label CssClass="agecnycodeclasspune" ID="lblnetpayable" runat ="server"></asp:Label></td>
            <td align="right"><asp:Label CssClass="dateclasspune" ID="netpay" runat ="server"></asp:Label></td>
        </tr>
           
  <tr>
        <td style="border-top:solid 1px black;  height:50px" colspan="2">&nbsp;</td>
  </tr>
  <tr valign="bottom">
        <td style="border-top :solid 1px black" valign="bottom" align="center" colspan="2" class="agecnycodeclasspune" >Advt.Manager/Accountant</td>
  </tr>  </table></td>
  </tr>
   <tr ><td><table cellspacing="0" cellpadding="0" style="border-right:solid 1px black" width="451px"><tr>
                 <td align="left"><asp:Label ID="lbinwords" runat="server" CssClass ="agecnycodeclasspune" Text="In Words Rupees  :"></asp:Label></td>
                 <td align="left" style="font-size:9px;" ><asp:Label ID="lbwordinrupees" runat="server" CssClass ="dateclasspune" ></asp:Label></td>
                 </tr>  </table>
                 </td>         
  <td > </td></tr>
  </table>
    
    
<table width="650px" cellspacing="0" cellpadding="0" >
<tr  >
<td   colspan="4" style="font-size:10px;font-family :Arial; height: 54px;border-bottom :solid 1px black" align ="left"><b>Terms & Condition : 1)</b>Payment Should be made in favour of <b><asp:Label CssClass="dateclasspune" ID="lbterms" runat ="server"></asp:Label>. 2)</b>Only official receipt
issued by us will binding on us.<b>3) </b>Objection or complaint regarding the bill (if any) should be brought to our notice within 15 days
from the presentation of the bill,falling which the bill become fully payable. <b>4)</b> All payment should be made according to the credit
limits to avoid interest,which will be levied @24% per annum.<b>5)</b>All disputes are subjected to <b><asp:Label CssClass="dateclasspune" ID="lbnaam" runat ="server"></asp:Label></b> Jurisdiction only.</td>

</tr>

<tr>

<td align="left"  valign ="bottom" style="WIDTH:200PX;font-size:10px;"><asp:Label CssClass="agecnycodeclasspune" ID="lbemail" runat ="server"></asp:Label><asp:Label CssClass="BORDEREMAIL" ID="lbemailtxt" runat ="server"></asp:Label></td>

<td valign ="bottom" style="font-size:10px;"  > <asp:Label CssClass="agecnycodeclasspune"  ID="EOU" runat ="server">E.&O.E.</asp:Label></td>

<td align="right"  valign ="bottom" colspan ="2"  style="font-size:10px;" ><asp:Label  CssClass="BORDERPAN" ID="lbpune" runat ="server"></asp:Label><asp:Label  CssClass="dateclasspune" ID="lbpunetxt" runat ="server"></asp:Label></td>


</tr>
<tr>
<td colspan="5">
<table>
<tr>
<td valign ="bottom" style="WIDTH:200PX;font-size:10px; height: 15px;"><asp:Label ID="lbltan" runat="server" CssClass="agecnycodeclasspune" Text="Tan No - MUMS40215A"></asp:Label></td>
<td valign ="bottom" style="WIDTH:300PX;font-size:10px; height: 15px;"><asp:Label ID="Label1" runat="server" CssClass="agecnycodeclasspune" Text="Service Tax No - AALFS7192JST001"></asp:Label></td>
<td valign ="bottom" style="WIDTH:200PX;font-size:10px; height: 15px;"><asp:Label ID="Label2" runat="server" CssClass="agecnycodeclasspune" Text="Pan No - AALFS7192J"></asp:Label></td>

</tr>
</table>
</td></tr>
</table>


</td>
</tr></table>
</div> 
