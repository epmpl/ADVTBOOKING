<%@ Control Language="C#" AutoEventWireup="true" CodeFile="kannad_prabha_pdf.ascx.cs" Inherits="kannad_prabha_pdf" %>

<link href="css/pratidin_bill.css" type="text/css" rel="Stylesheet" />

<head>
<%--<title>UDAYAVANI BILL REPRINT</title>--%>
<script type="text/javascript"  language="javascript" src="javascript/billing.js">function TABLE1_onclick() {

}

</script>

    <style type="text/css">
        .style2
        {
            height: 100px;
            width: 330px;
        }
        .style3
        {
            width: 87px;
        }
        .style5
        {
            width: 109px;
        }
        .style8
        {
            width: 109px;
            height: 19px;
        }
        .style10
        {
            width: 253px;
        }
        .style11
        {
            width: 130px;
        }
    </style>

</head>
<%--<p  id="P1" style="page-break-after:always;">--%>
<table  cellspacing="0" cellpadding="0"  width="660px" style="page-break-after:always;">
<tr>
<td style="width: 660px" valign ="top" >

<table  style="vertical-align :top " width="660px" cellspacing="0" cellpadding="0" >
<tr>
<td style="width:350px;" valign="middle">
 <table cellpadding="0" cellspacing="0"><tr><td style="font-size:11px;font-family;" align="right"><asp:Label  ID="Label12" runat ="server">ORIGINAL</asp:Label></td></tr><tr><td style="font-size:9px;font-family :Verdana;width:350px; height: 12px;" ><asp:Label  ID="pubadd"  runat ="server"></asp:Label></td></tr><tr><td style="font-size:9px;font-family :Verdana;width:260px; height: 13px;"><asp:Label  ID="pub_ph" runat ="server"></asp:Label></td></tr>
 </table></td>
 
 <td align="left" style="width:270px;">
 <asp:Label  ID="Label27" style="font-size:16px;font-family :Times New Roman;" runat ="server"><b>KANNADA PRABHA <br />PUBLICATIONS LTD.</b></asp:Label><br />
 <asp:Label  ID="Label28" style="font-size:9px;font-family :Verdana;width:270px;" runat ="server">Regd. Office:No.1,Queen's Road Bangalore-560 001.<br /> Phone No. : 22866893/94/95/96</asp:Label></td>
</tr>
<%--<tr>
<td align="center" style="font-size:11px;font-family :Verdana;" colspan="2"><asp:Label ID="Label12"  runat="server">Office & Press : 20 PRAFULLA SARKAR STREET, KOLKATA- 700 072</asp:Label></td>
</tr>
<tr>
<td align="right" style="font-size:11px;font-family :Verdana;width:450px"><asp:Label ID="Label13"  runat="server">PHONE:2210-8400-05,FAX:(033)2212-7977</asp:Label></td>
<td align="center" style="font-size:11px;font-family :Verdana;"><asp:Label ID="lblorg"  runat="server"></asp:Label></td>
</tr>
<tr><td></td></tr>--%>
<tr><td colspan="3" style="font-size:11px;font-family :Verdana;" align="left"><asp:Label  ID="Label9" runat ="server">Dr.</asp:Label></td></tr>
 </table>
 
 <table width="660px;"  cellspacing="0" cellpadding="0" >
 <tr >
 <td  >
 <table cellpadding="0" cellspacing="0"   border="1"  >
      <tr valign="top"><td height="15px;"> <asp:Label  ID="agddxt" runat ="server" ></asp:Label></td></tr>
 
  
     <tr valign="middle"> <td  height="15px;"class="style10"><asp:Label  ID="agencyaddtxt" runat ="server"></asp:Label></td></tr>

     <tr >
     <td  class="style10"  height="15px;"><asp:Label  ID="lbcityname" runat ="server"></asp:Label><asp:Label ID="txtpinno" runat ="server"></asp:Label></td></tr>
 </table></td>
 <td style="width:500px; padding-left:10px;" >
 <table  cellpadding="0" cellspacing="0"  width="500px;">
 <tr width="500px"><td    valign="top" colspan="3" align="left"><asp:Label  ID="Label29" style="font-size:8px;font-family :Verdana;" runat ="server">Corporate Office:EXPRESS GARDENS,No. 29 Second  <br />Main Road Ambattur Industrial Estate Chenni-600 058.</asp:Label></td></tr>
 <tr>
 <td style="font-size:11px;font-family :Verdana;" class="style11" ><asp:Label  ID="Label6" runat ="server"><b>CODE:</b></asp:Label></td>
     <td style="font-size:11px;font-family :Verdana; " align="left" ><asp:Label  ID="lblcode" runat ="server"></asp:Label></td></tr><tr>
 <td style="font-size:11px;font-family :Verdana;" class="style11"><asp:Label  ID="l8" runat ="server"><b>BILL NO.:</b></asp:Label></td><td style="font-size:11px;font-family :Verdana; " align="left"><asp:Label  ID="lbbillno" runat ="server"></asp:Label></td></tr><tr>
 <td style="font-size:11px;font-family :Verdana;" class="style11"><asp:Label  ID="Label5" runat ="server"><b>DATE:</b></asp:Label></td><td style="font-size:11px;font-family :Verdana; " align="left"><asp:Label  ID="lbldate" runat ="server"></asp:Label></td></tr><tr>
 <td style="font-size:11px;font-family :Verdana;" class="style11"><asp:Label  ID="Label31" runat ="server"><b>PUBLICATION / PACKAGE:</b></asp:Label></td><td style="font-size:11px;font-family :Verdana; " align="left"><asp:Label  ID="lblpacname" runat ="server"></asp:Label></td></tr>
 </table></td>
 <%--<td style="width:200px;"></td>--%></tr></table>
 
 <table cellpadding="0" cellspacing="0">
 <tr><td style="width:260px;" valign="middle">
 <table cellpadding="0" cellspacing="0" style="width: 163px; height: 78px;">
 <tr><td style="font-size:11px;font-family :Verdana;width:200px;border-right:dotted 2px black;"><asp:Label  ID="Label1" runat ="server"><b>ADVERTISER</b></asp:Label></td></tr>
 <tr><td style="font-size:11px;font-family :Verdana;width:200px;border-right:dotted 2px black;"><asp:Label  ID="Label2" runat ="server"><b>S.B.NO</b></asp:Label></td></tr>
 <tr><td style="font-size:11px;font-family :Verdana;width:200px;border-right:dotted 2px black;"><asp:Label  ID="Label4" runat ="server"><b>PRODUCT KEY</b></asp:Label></td></tr>
 <tr><td style="font-size:11px;font-family :Verdana;width:200px;border-right:dotted 2px black;"><asp:Label  ID="Label24" runat ="server"><b>ORDER REF. NO. AND DATE</b></asp:Label></td></tr>
 <tr><td style="font-size:11px;font-family :Verdana;width:200px;border-right:dotted 2px black;"><asp:Label  ID="Label25" runat ="server"><b>MONTH.</b></asp:Label></td></tr>
 </table></td>
  <td style="width:200px;" valign="middle">
 <table cellpadding="0" cellspacing="0"><tr><td style="font-size:11px;font-family :Verdana;width:200px;"><asp:Label  ID="lblclientname" runat ="server"></asp:Label></td></tr><tr><td style="font-size:11px;font-family :Verdana;width:200px;"><asp:Label  ID="cioid" runat ="server"></asp:Label></td></tr><tr><td style="font-size:11px;font-family :Verdana;width:200px;"><asp:Label  ID="lblproductkey" runat ="server"></asp:Label></td></tr><tr><td style="font-size:11px;font-family :Verdana;width:200px;"><asp:Label  ID="lblcatro" runat ="server"></asp:Label></td></tr><tr><td style="font-size:11px;font-family :Verdana;width:200px;"><asp:Label  ID="lblmonth11" runat ="server"></asp:Label></td></tr>
 </table></td>
 <td style="font-size:11px;font-family :Verdana;width:200px;" valign="bottom" align="right"><asp:Label  ID="Label33" runat ="server">PAN NO: AADCK9066C</asp:Label><br /><asp:Label  ID="lblpan" runat ="server"></asp:Label></td>
 <%--<td style="font-size:11px;font-family :Verdana;width:200px;" valign="bottom" align="right"><asp:Label  ID="lblpan" runat ="server"></asp:Label></td></tr>--%>
 </tr></table>
 
 <table width="660px"  cellspacing="0" cellpadding="0" style="margin:10px 0px 0px 0px;" id="TABLE1" onclick="return TABLE1_onclick()">
 <tr><td>
<%-- <hr style="border:solid 1px black;" />
 <table width="660px"  cellspacing="0" cellpadding="0">
 <tr style="border-bottom:solid 1px black;border-top:solid 1px black;"><td style="font-size:11px;font-family :Verdana;width:200px;" align="left"><asp:Label ID="Label35"  runat="server">PUBLISHED AT/ON/PUBLICATION </asp:Label></td><td style="font-size:11px;font-family :Verdana;width:150px;" align="left"><asp:Label ID="lblmonth"  runat="server"></asp:Label></td><td style="font-size:11px;font-family :Verdana;padding-right:20px;" align="right"><asp:Label ID="lblpancomp"  runat="server"></asp:Label></td></tr>
</table>
  <hr style="border:solid 1px black;" />--%>
  </td></tr>
 <tr><td>
 <table  width="660px"   cellspacing="0" cellpadding="0" style ="vertical-align :top;" >
  <hr style="border:solid 1px black;" />
<tr>
 
<td valign ="top" style ="height :250px;">
       <asp:Label  id="dynamictable"  runat ="server"></asp:Label>
       </td>
  </tr>
  </table>
  
  </td></tr>
  <tr><td>
  <hr style="border:solid 1px black;" />
   <table width="660px"  cellspacing="0" cellpadding="0">
 <tr><td style="font-size:11px;font-family :Verdana;width:40px;" align="center"><asp:Label ID="Label19"  runat="server"><b>COL :</b></asp:Label></td><td style="font-size:11px;font-family :Verdana;width:40px;" align="center"><asp:Label ID="lblcol"  runat="server"></asp:Label></td><td style="font-size:11px;font-family :Verdana;width:40px;" align="center"><asp:Label ID="Label20"  runat="server"><b>CMS :</b></asp:Label></td><td style="font-size:11px;font-family :Verdana;width:40px;" align="center"><asp:Label ID="lblcms"  runat="server"></asp:Label></td><td style="font-size:11px;font-family :Verdana;width:40px;" align="center"><asp:Label ID="Label21"  runat="server"><b>WORDS :</b></asp:Label></td><td style="font-size:11px;font-family :Verdana;width:40px;" align="center"><asp:Label ID="lblword"  runat="server"></asp:Label></td><td style="font-size:11px;font-family :Verdana;width:40px;" align="center"><asp:Label ID="Label22"  runat="server"><b>LINES :</b></asp:Label></td><td style="font-size:11px;font-family :Verdana;width:40px;" align="center"><asp:Label ID="lblline"  runat="server"></asp:Label></td>
     <td style="font-size:11px;font-family :Verdana;" align="center" class="style3"><asp:Label ID="Label23"  runat="server"><b>TOTAL SPACE :</b></asp:Label></td><td style="font-size:11px;font-family :Verdana;width:100px;" align="center"><asp:Label ID="lbltspace"  runat="server"></asp:Label></td></tr>
     
 
 </table>
<%-- <hr style="border:solid 2px black;" />--%>
   <table width="600px"  cellspacing="0" cellpadding="0" style="margin:10px 0px 0px 0px;">
   <tr ><td  ></td>
   <td></td>
   <td></td>
   <td style="font-size:11px;font-family :Verdana;" align="right">
   <asp:Label ID="Label32"  runat="server">Rs.</asp:Label></td></tr>
   <tr>
   <td  width="360px;" rowspan="10"><table cellpadding="0" cellspacing="0" align="center">
   <tr width="380px;"><td ><asp:Label  ID="agddxt12" runat ="server"></asp:Label></td></tr>
     <tr  ><td width="280px;" ><asp:Label  ID="agencyaddtxt1" runat ="server"></asp:Label></td>
     </tr><tr>
     <td style="width:280px;font-size:11px;font-family :Verdana;">
     <asp:Label  ID="lbcityname1" runat ="server"></asp:Label></td> </tr></table>
     </td>
       <td style="font-size:11px;font-family :Verdana;"  align="left" class="style8">
       <asp:Label ID="Label43"  runat="server">Rate</asp:Label></td>
       <td></td>
       <td  style="font-size:11px;font-family :Verdana;"align="right">
       <asp:Label ID="lblamt"  runat="server"></asp:Label></td></tr>
   <tr><td style="font-size:11px;font-family :Verdana;"  align="left" class="style5">
   <asp:Label ID="lblgrosss"  runat="server">Gross</asp:Label></td><td></td><td style="font-size:11px;font-family :Verdana;" align="right"><asp:Label ID="lblgross"  runat="server"></asp:Label></td></tr>
  <tr id="tr_prem" runat="server"><td style="font-size:11px;font-family :Verdana;" 
           align="left" class="style5">
           <asp:Label ID="Label13"  runat="server">Premium</asp:Label></td>
           
           <td style="font-size:11px;font-family :Verdana;"><asp:Label ID="lblprper"  runat="server"></asp:Label></td>
           <td style="font-size:11px;font-family :Verdana;" align="right">
           <asp:Label ID="lblpramt"  runat="server"></asp:Label></td></tr>
  <tr id="tr_spe_crg" runat="server"><td style="font-size:11px;font-family :Verdana;" 
           align="left" class="style5"><asp:Label ID="Label26"  runat="server">Special Charge</asp:Label></td><td style="font-size:11px;font-family :Verdana;"></td><td style="font-size:11px;font-family :Verdana;" align="right"><asp:Label ID="txtspec_charge"  runat="server"></asp:Label></td></tr>
   <tr id="spel_dis" runat="server"><td style="font-size:11px;font-family :Verdana;" 
           align="left" class="style5"><asp:Label ID="Label8"  runat="server">Discount 1</asp:Label></td><td style="font-size:11px;font-family :Verdana;"><asp:Label ID="lblspec"  runat="server"></asp:Label></td><td style="font-size:11px;font-family :Verdana;" align="right"><asp:Label ID="lblspecialdis"  runat="server"></asp:Label></td></tr>
  <tr id="tr_cash_dis" runat="server"><td style="font-size:11px;font-family :Verdana;" 
           align="left" class="style5"><asp:Label ID="Label3"  runat="server">Discount 2</asp:Label></td><td style="font-size:11px;font-family :Verdana;"><asp:Label ID="lblcaspr"  runat="server"></asp:Label></td><td style="font-size:11px;font-family :Verdana;" align="right"><asp:Label ID="lblcasamt"  runat="server"></asp:Label></td></tr>
   <tr id="trade_dis" runat="server"><td style="font-size:11px;font-family :Verdana;" 
           align="left" class="style5"><asp:Label ID="Label7"  runat="server">Trade Disc.</asp:Label></td><td style="font-size:11px;font-family :Verdana;"><asp:Label ID="lbltrade"  runat="server"></asp:Label></td><td style="font-size:11px;font-family :Verdana;" align="right"><asp:Label ID="lbltradedis"  runat="server"></asp:Label></td></tr>
   <tr><td style="font-size:11px;font-family :Verdana;" 
           align="left" class="style5"><asp:Label ID="Label10"  runat="server">Net Amount</asp:Label></td><td></td><td style="font-size:11px;font-family :Verdana;" align="right"><asp:Label ID="lblnetamt"  runat="server"></asp:Label></td></tr>
  <tr id="tr_box_amt" runat="server"><td style="font-size:11px;font-family :Verdana;" 
           align="left" class="style5"><asp:Label ID="Label15"  runat="server">Box Amt</asp:Label></td><td style="font-size:11px;font-family :Verdana;"></td><td style="font-size:11px;font-family :Verdana;" align="right"><asp:Label ID="lblboxamt"  runat="server"></asp:Label></td></tr>
   <tr><td style="font-size:11px;font-family :Verdana;" 
           align="left" class="style5"><asp:Label ID="Label11"  runat="server">Amount Payable</asp:Label></td><td></td><td style="font-size:11px;font-family :Verdana;" align="right"><asp:Label ID="lblamt_pay"  runat="server"></asp:Label></td></tr>
   <%--<tr><td colspan="4" style="font-size:11px;font-family :Verdana;" align="left"><asp:Label ID="Label30" runat="server"></asp:Label></td></tr>--%>
   </table>
   <table width="600px" cellpadding="0" cellspacing="0"><tr><td colspan="4" style="font-size:11px;font-family :Verdana; height: 13px;" align="left"><asp:Label ID="lblamtword" runat="server"></asp:Label></td></tr></table>
  <tr>
 <td>
 <table>
 <tr>
 <td>
<table   width="660px" cellspacing="0" cellpadding="0" border="0" >
<tr><td>
  <hr style="border:solid 2px black;" />
<table   width="660px" cellspacing="0" cellpadding="0" border="0" >
  <tr>
  <td valign="top" class="style2">
  <table cellpadding ="0" cellspacing="0" width="450px"  ><tr >
  <td   colspan="6"><asp:Label ID="Label14" runat ="server" >E.& O.E</asp:Label></td></tr><tr style="border-bottom:solid 1px black;">
  <td   >
  <asp:Label ID="lblnote" runat ="server" >
 1. Remittance should be made by crossed Account Payee Cheque/DemandDraft payable to KANNAD PRABHA PUBLICATIONS LTD. While remitting please quote Bill No. 2. Only official receipts
 issued by us will be binding on us.3. This bill can be ignored if remittance has been made already. 4. The bill is payable immediately on receipt unless otherwise agreed 5. No objection or
 complaint concerning the bill shall be entertained if not received by us within 15 days agter presentation of this bill. All such complaints should be addressed  to Accountant(Advertisement). 6. All disputes in respect of this bill
 are subject to jurisdiction of Banglore Courts. 
</asp:Label></td></tr><tr>
<td style="font-size:9px;font-family :Verdana;border-top:solid 1px black;"><asp:Label ID="Label16" runat ="server" >Encl.: VOUCHER TEAR SHEETS</asp:Label></td>
</tr></table>
  </td>
<td align="right"   style="font-size:9px;font-family :Verdana;">
    <table cellpadding="0" cellspacing="0" 
        ><tr><td valign="top" ><asp:Label ID="Label17" runat ="server" > For <b>Kannada Prabha Publications Ltd.</b> </asp:Label></td></tr><tr>
        <td height="60px;"></td></tr><tr><td style="font-size:9px;font-family :Verdana; vertical-align:bottom;"><asp:Label ID="lbl11" runat ="server" >Accountant(Advertisement)</asp:Label></td></tr></table>
</td>
 </tr>  
  </table></td></tr>
  <tr><td style="font-size:9px;font-family :Verdana;"><asp:Label ID="Label18" runat ="server" >E.& O.E</asp:Label></td>
</tr></table>
  <hr style="border:solid 2px black;" />
</td>
</tr>
  </table>
 
 </td>
 </tr>
</td>
</tr>
</table>




</td></tr> 


 
 </table>
<%--</p>--%>
