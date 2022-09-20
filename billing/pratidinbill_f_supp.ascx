<%@ Control Language="C#" AutoEventWireup="true" CodeFile="pratidinbill_f_supp.ascx.cs" Inherits="pratidinbill_f_supp" %>

<link href="css/pratidin_bill.css" type="text/css" rel="Stylesheet" />

<head>
<%--<title>UDAYAVANI BILL REPRINT</title>--%>
<script type="text/javascript"  language="javascript" src="javascript/billing.js"></script>

    <style type="text/css">
        .style1
        {
            width: 63px;
        }
    </style>

</head>
<%--<p  id="P1" style="page-break-after:always;">--%>
<table  cellspacing="0" cellpadding="0"  width="660px">
<tr>
<td style="width: 660px" valign ="top" >

<table  style="vertical-align :top " width="660px" cellspacing="0" cellpadding="0" >
<tr>

 <td  align="center" colspan="2"><img src="C:\Inetpub\wwwroot\webdir1\images1\EML.jpg" height ="60px"/></td>
</tr>
<tr>
<td align="center" style="font-size:11px;font-family :Verdana;" colspan="2"><asp:Label ID="Label12"  runat="server">Office & Press : 20 PRAFULLA SARKAR STREET, KOLKATA- 700 072</asp:Label></td>
</tr>
<tr>
<td align="right" style="font-size:11px;font-family :Verdana;width:450px"><asp:Label ID="Label13"  runat="server">PHONE:2210-8400-05,FAX:(033)2212-7977</asp:Label></td>
<td align="center" style="font-size:11px;font-family :Verdana;"><asp:Label ID="lblorg"  runat="server"></asp:Label></td>
</tr>
<tr><td></td></tr>
 </table>
 <hr style="border-bottom:solid 1px black;"></hr>
 <table width="660px;"  cellspacing="0" cellpadding="0" >
 <tr style="height:125px;"><td style="width:80px;font-size:11px;font-family :Verdana;"><asp:Label ID="lblnameadd" runat ="server"><b>NAME & ADDRESS</b></asp:Label></td>
 <td style="width:200px;" valign="middle">
 <%--<asp:Label ID="lblclintadd" runat ="server"></asp:Label>--%>
 <table cellpadding="0" cellspacing="0"><tr><td style="font-size:11px;font-family :Verdana;width:200px;"><asp:Label  ID="agddxt" runat ="server"></asp:Label></td></tr><tr><td style="font-size:11px;font-family :Verdana;width:200px;"><asp:Label  ID="agencyaddtxt" runat ="server"></asp:Label></td></tr><tr><td style="font-size:11px;font-family :Verdana;width:200px;"><asp:Label  ID="lbcityname" runat ="server"></asp:Label><asp:Label ID="txtpinno" runat ="server"></asp:Label></td></tr>
 </table></td>
 <td style="width:180px;"></td>
 <td style="width:200px;"><table cellpadding="0" cellspacing="0"><tr><td style="font-size:11px;font-family :Verdana;"><asp:Label  ID="l8" runat ="server"><b>BILL NO.: </b></asp:Label></td><td style="font-size:11px;font-family :Verdana; width:100px" align="left"><asp:Label  ID="lbbillno" runat ="server"></asp:Label></td></tr><tr><td style="font-size:11px;font-family :Verdana;"><asp:Label  ID="Label5" runat ="server"><b>DATE: </b></asp:Label></td><td style="font-size:11px;font-family :Verdana; width:100px" align="left"><asp:Label  ID="lbldate" runat ="server"></asp:Label></td></tr><tr><td style="font-size:11px;font-family :Verdana;"><asp:Label  ID="Label6" runat ="server"><b>CODE: </b></asp:Label></td><td style="font-size:11px;font-family :Verdana; width:100px" align="left"><asp:Label  ID="lblcode" runat ="server"></asp:Label></td></tr>
 </table></td></tr></table>
  <hr size="1px" />
 <table width="660px"  cellspacing="0" cellpadding="0" style="border:solid 1px black;margin:10px,0px;">
 <tr><td style="width:330px;font-size:10px;font-family :Verdana; height:20px;"><asp:Label ID="Label14" runat="server">TO THE COST OF YOUR ADVERTISEMENT AS UNDER</asp:Label></td><td style="width:80px;font-size:11px;font-family :Verdana; width:70px;" align="left"><asp:Label ID="lblclient"  runat="server"><b>CLIENT</b></asp:Label></td><td style="width:80px;font-size:10px;font-family :Verdana; width:260px;" align="left"><asp:Label ID="lblclientname" runat="server"></asp:Label></td></tr>
 </table>
  <hr size="1px" />
 <table width="660px"  cellspacing="0" cellpadding="0" style="border:solid 1px black;margin:10px 0px 0px 0px;">
 <tr><td>
 <table width="660px"  cellspacing="0" cellpadding="0">
 <tr style="border-bottom:solid 1px black;"><td  style="font-size:11px;font-family :Verdana; height:20px;border-bottom:solid 1px black; width:60px;" align="left"><asp:Label ID="lblissue" runat="server"><b>ISSUE: </b></asp:Label><asp:Label ID="lblisname"  runat="server"></asp:Label></td><td style="font-size:11px;font-family :Verdana;border-bottom:solid 1px black; width:70px;" align="right"><asp:Label ID="lblloc"  runat="server"><b>LOCATION: </b></asp:Label></td><td style="font-size:11px;font-family :Verdana;border-bottom:solid 1px black;" align="left"><asp:Label ID="lbllocval"  runat="server"></asp:Label></td><td style="font-size:11px;font-family :Verdana;border-bottom:solid 1px black;" align="right"><asp:Label ID="lblpage"  runat="server"><b>PAGE: </b></asp:Label></td><td style="font-size:11px;font-family :Verdana;border-bottom:solid 1px black;" align="left"><asp:Label ID="lblpageval"  runat="server"></asp:Label></td></tr>
 </table>
 <hr size="2px" />
 </td></tr>
<%-- <tr><td>
<table width="660px"  cellspacing="0" cellpadding="0">
 <tr><td style="font-size:11px;font-family :Verdana; height:13px;border-right:solid 1px black;width:90px;border-bottom:solid 1px black;" align="center"><asp:Label ID="Label15" runat="server">ORDER NUMBER</asp:Label></td><td style="font-size:11px;font-family :Verdana; border-right:solid 1px black;width:70px;border-bottom:solid 1px black;" align="center"><asp:Label ID="Label16" runat="server">ORDER DATE</asp:Label></td><td><table cellpadding="0" cellspacing="0"><tr><td colspan="3" align="center" style="font-size:11px;font-family :Verdana; border-right:solid 1px black; border-bottom:solid 1px black;width:250px;border-bottom:solid 1px black;" align="center"><asp:Label ID="Label17"  runat="server">PARTICULARS</asp:Label></td></tr><tr><td style="font-size:11px;font-family :Verdana;border-right:solid 1px black;width:80px;border-bottom:solid 1px black;" align="center"><asp:Label ID="Label22" runat="server">ADVT. DATE</asp:Label></td><td style="font-size:11px;font-family :Verdana;border-right:solid 1px black;width:80px;border-bottom:solid 1px black;" align="center"><asp:Label ID="Label23" runat="server">SIZE</asp:Label></td><td style="font-size:11px;font-family :Verdana;border-right:solid 1px black;width:90px;border-bottom:solid 1px black;" align="center"><asp:Label ID="Label24"  runat="server">TYPE OF ADVT.</asp:Label></td></tr></table></td><td style="font-size:11px;font-family :Verdana;border-right:solid 1px black;width:70px;border-bottom:solid 1px black;" align="center"><asp:Label ID="Label19" runat="server">TOTAL SPACE</asp:Label></td><td style="font-size:11px;font-family :Verdana; border-right:solid 1px black;width:90px;border-bottom:solid 1px black;" align="center"><asp:Label ID="Label20"  runat="server">UNIT</asp:Label></td><td style="font-size:11px;font-family :Verdana;width:100px;border-bottom:solid 1px black;" align="center"><asp:Label ID="Label21"  runat="server">RATE</asp:Label></td></tr>
 </table>
 </td></tr>--%>
 <tr><td>
 <table  width="660px"   cellspacing="0" cellpadding="0"  >
<tr>

<td valign ="top" style ="height :150px;">
       <asp:Label  id="dynamictable"  runat ="server"></asp:Label>
       </td>
  </tr>
  </table>
  
  </td></tr>
  <tr><td>
   <hr size="2px" />
   <table width="660px"  cellspacing="0" cellpadding="0" id="netamttab" runat="server">
 <tr><td style="font-size:11px;font-family :Verdana;border-right:solid 1px black;border-top:solid 1px black;border-bottom:solid 1px black;width:70px;" align="center"><asp:Label ID="Label31"  runat="server"><b>AMOUNT</b></asp:Label></td><td style="font-size:11px;font-family :Verdana;border-right:solid 1px black;border-top:solid 1px black;border-bottom:solid 1px black;width:70px;" align="center"><asp:Label ID="Label32"  runat="server"><b>EXTRAAMT FOR SPL POSITION</b></asp:Label></td><td style="font-size:11px;font-family :Verdana;border-right:solid 1px black;border-top:solid 1px black;border-bottom:solid 1px black;width:70px;" align="center"><asp:Label ID="Label33"  runat="server"><b>EXTRA AMT FOR SPL DAY</b></asp:Label></td><td style="font-size:11px;font-family :Verdana;border-right:solid 1px black;border-top:solid 1px black;border-bottom:solid 1px black;width:70px;" align="center"><asp:Label ID="Label25"  runat="server"><b>EXTRA AMT FOR COLOR</b></asp:Label></td><td style="font-size:11px;font-family :Verdana;border-right:solid 1px black;border-top:solid 1px black;border-bottom:solid 1px black;width:70px;" align="center"><b>GROSS AMT</b><asp:Label ID="Label26" CssClass="dateclasspune" runat="server"></asp:Label></td><td style="font-size:11px;font-family :Verdana;border-right:solid 1px black;border-top:solid 1px black;border-bottom:solid 1px black;width:90px;" align="center"><asp:Label ID="Label27"  runat="server"><b>SPL DISCOUNT % AMOUNT</b></asp:Label></td><td style="font-size:11px;font-family :Verdana;border-right:solid 1px black;border-top:solid 1px black;border-bottom:solid 1px black;width:90px;" align="center"><asp:Label ID="Label28"  runat="server"><b>TRADE DISCOUNT % AMOUNT</b></asp:Label></td><td style="font-size:11px;font-family :Verdana;border-right:solid 1px black;border-top:solid 1px black;border-bottom:solid 1px black;width:50px;" align="center"><asp:Label ID="Label29"  runat="server"><b>BOX CHRG.</b></asp:Label></td><td style="font-size:11px;font-family :Verdana;border-top:solid 1px black;border-bottom:solid 1px black;width:80px;" align="center"><asp:Label ID="Label30"  runat="server"><b>NET AMOUNT</b></asp:Label></td></tr>
 <tr><td style="font-size:11px;font-family :Verdana;border-right:solid 1px black;border-bottom:solid 1px black;width:70px;" align="center"><asp:Label ID="lblamt"  runat="server"></asp:Label></td><td style="font-size:11px;font-family :Verdana;border-right:solid 1px black;border-bottom:solid 1px black;width:70px;" align="center"><asp:Label ID="lblexamt_pos"  runat="server"></asp:Label></td><td style="font-size:11px;font-family :Verdana;border-right:solid 1px black;border-bottom:solid 1px black;width:70px;" align="center"><asp:Label ID="lblexamt_day"  runat="server"></asp:Label></td><td style="font-size:11px;font-family :Verdana;border-right:solid 1px black;border-bottom:solid 1px black;width:70px;" align="center"><asp:Label ID="lblexamt_col"  runat="server"></asp:Label></td><td style="font-size:11px;font-family :Verdana;border-right:solid 1px black;border-bottom:solid 1px black;width:70px;" align="center"><asp:Label ID="lblgross"  runat="server"></asp:Label></td><td style="font-size:11px;font-family :Verdana;border-right:solid 1px black;border-bottom:solid 1px black;width:90px;" align="center"><asp:Label ID="lbladddis"  runat="server"></asp:Label></td><td style="width:90px;"><table cellpadding="0" cellspacing="0"><tr><td style="font-size:11px;font-family :Verdana;border-right:solid 1px black;border-bottom:solid 1px black;width:30px;" align="center"><asp:Label ID="lbltrade"  runat="server"></asp:Label></td><td style="font-size:11px;font-family :Verdana;border-right:solid 1px black;border-bottom:solid 1px black;width:61px;" align="center"><asp:Label ID="lbltradedis"  runat="server"></asp:Label></td></tr></table></td><td style="font-size:11px;font-family :Verdana;border-right:solid 1px black;border-bottom:solid 1px black;width:50px;" align="center"><asp:Label ID="lblboxchrg"  runat="server"></asp:Label></td><td style="font-size:11px;font-family :Verdana;width:80px;border-bottom:solid 1px black;" align="center"><asp:Label ID="lblnetamt" runat="server"></asp:Label></td></tr>
 </table>
 <hr size="2px" />
   <table width="660px"  cellspacing="0" cellpadding="0">
   <tr style="height:70px;" id="trate" runat="server"><td style="font-size:11px;font-family :Verdana;" align="left"><asp:Label ID="Label43"  runat="server"><b>Rupees: </b></asp:Label><asp:Label ID="lblamtword"  runat="server"></asp:Label></td></tr>
   <tr style="height:70px;"><td style="font-size:11px;font-family :Verdana;" align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label45" runat="server"><b>SCODE: </b></asp:Label><asp:Label ID="txtscode" runat="server"></asp:Label>
       <asp:Label ID="lbratecod" runat="server"><b>RCODE: </b></asp:Label><asp:Label ID="txtratecode" runat="server"></asp:Label></td></tr>
   </table>
   
  
</td>
</tr>
</table></td></tr></table>
 <hr />
<table   width="660px" cellspacing="0" cellpadding="0" border="0" >
  <tr>
  <td  style="font-size:10px;font-family :Verdana; height: 154px;width: 455px;" valign="top">
  <asp:Label ID="Label4" runat ="server" >
 All remittances should be made payable to: <b>PRATIDIN PRAKASHANI LTD.</b> by<br />
crossed A/c. Payee Cheque/Draft. The bill must be paid within stipulated time as<br /> 
mentioned here in below:<br /> 
For Accredited Agents: As per norms of INS<br /> 
For Non-Accredited Agents:Immediately on receipt unless otherwise agreed.<br /> 
No objection or complaint cencerning this bill shall be entertained if not received<br /> 
by us within fifteen days after presentation of this bill.<br /> 
</asp:Label>
  </td>
<td align="right"  style="font-size:10px;font-family :Verdana;"><table cellpadding="0" cellspacing="0" style="vertical-align:top;"><tr><td valign="bottom"> <img src="images\signature.jpg" height ="40px"/></td></tr><tr><td valign="bottom"><asp:Label ID="Label1" runat ="server" >For <b>PRATIDIN PRAKASHANI LTD.</b> </asp:Label></td></tr></table></td>
 </tr>
  
  </table>

  
  <table width="660px" cellspacing="0" cellpadding="0" >
 


<tr style="width:385px">
<td valign ="bottom" style="font-size:11px;font-family :Verdana;" >PAN:</td>

<td valign ="bottom" style="font-size:11px;font-family :Verdana;"><asp:Label ID="lbpan" runat ="server"></asp:Label></td>

<td align="left" style="font-size:11px;font-family :Verdana;">VAT No.:</td>
<td valign ="bottom" style="font-size:11px;font-family :Verdana;"><asp:Label ID="Label2" runat ="server"></asp:Label></td>

</tr>

</table>



<table width="660px">
<tr>
<td style="font-size:11px;font-family :Verdana;"><b>Enclo:VR/TEAR SHEETS</b></td>
<td style="font-size:11px;font-family :Verdana;"><b>E.& O.E.</b></td>
<td style="font-size:11px;font-family :Verdana;"><b>PREPARED BY</b></td>
<td style="font-size:11px;font-family :Verdana;"><b>CHECKED BY</b></td>
<td style="font-size:11px;font-family :Verdana;">GENERAL MANAGER</td>
<td style="font-size:11px;font-family :Verdana;">FINANCE</td>
</tr>
</table>
<%--</p>--%>

