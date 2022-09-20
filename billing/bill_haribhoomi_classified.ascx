<%@ Control Language="C#" AutoEventWireup="true" CodeFile="bill_haribhoomi_classified.ascx.cs" Inherits="bill_haribhoomi_classified" %>

<link href="css/billingStyleSheet.css" type="text/css" rel="Stylesheet" />
<link href="css/udyavanibill.css" type="text/css" rel="Stylesheet" />


<head>
<title>HARIBHOOMI BILL PRINT</title>
<script type="text/javascript"  language="javascript" src="javascript/billing.js"></script>
</head>
<p  id="P1" >

<table style="border:solid 1px black;margin-top:20px; page-break-after:always;" cellspacing="0" cellpadding="0"  width="658px"    >

<td style="width: 680px;border:solid 1px" valign ="top" >

<table  style="vertical-align :top ;height:35px;" width="660px" cellspacing="0" cellpadding="0" >
<tr>
<td  align="center"  valign="middle" width="100%"><B>BILL</B></td>
<td  style="visibility:hidden;"> <asp:Label CssClass="agecnycodeclasspune" ID="pagestatus" runat ="server" aling="left" width="10%"></asp:Label></td>
</tr>
 
 </table>
<table width="660px"  cellspacing="0" cellpadding="0" >
 <td style="border-right:solid 1px black;border-top:solid 1px black;border-bottom:solid 1px black" >
 <table   width="300px" cellspacing="0" cellpadding="0"  border="0" 
         style="height: 79px">

 <tr valign="top">
  <td   align ="left" style="padding-left:5px;" ><b><asp:Label CssClass="agecnycodeclasspune" ID="lblto" runat ="server" Text="To,"></asp:Label></b></td>
 </tr>
 <tr>
  <td  align ="left" valign ="top" style="padding-left:30px;" ><asp:Label CssClass="agecnycodeclasspune" ID="agddxt" runat ="server"></asp:Label></td>
    </tr>
 <tr>
  <td align ="left"  valign ="top"  style="padding-left:30px;"><b> <asp:Label CssClass="agecnycodeclasspune" ID="lbaddress" runat ="server"></asp:Label></b></td>
 </tr>
 <tr><td></td></tr>
 <tr><td style="border-top:solid 1px black;"><asp:Label CssClass="agecnycodeclasspune" ID="Label1" runat ="server" Text="From:-"></asp:Label><asp:Label CssClass="agecnycodeclasspune" ID="agname" runat ="server"></asp:Label></td></tr>
</table>
<table   width="300px" cellspacing="0" cellpadding="0"  border="0" >
<tr>
<td style="font-size:12px;font-family :Times New Roman; vertical-align:top;border-top:solid 1px black;" align='center'  class="dateclasspune2">
<asp:Label ID="lbladrelpar" runat ="server" CssClass="dateclasspune"><b>Advertisement Release Particulars</b></asp:Label></td></tr>

</table>
<td  align="center">

<table   width="310px" cellspacing="0" cellpadding="0">
<tr ><td colspan="4" style="height: 11px" align="center"><asp:Label CssClass="agecnycodeclasspune" ID="lbcompanyname" runat ="server"></asp:Label></td></tr>
<tr><td colspan="4" align="center" style="font-size:9px;font-family :Times New Roman;" >
    <asp:Label ID="lbcompaddress" runat ="server"></asp:Label>
    </td></tr>
<tr><td  align="center" style="font-size:9px;font-family :Times New Roman;">
    <asp:Label CssClass="dateclasspune" ID="lbemailtxt" runat ="server"></asp:Label>
    </td></tr>

</table>
<table width="360px" cellspacing="0" cellpadding="0">

<tr>
<td  width="250px"></td>
<td style="font-size:9px;font-family :Times New Roman;" ><asp:Label CssClass="dateclasspune"   ID="lbpune" runat ="server"><b></asp:Label></td>
<td style="font-size:9px;font-family :Times New Roman;"><asp:Label  CssClass="dateclasspune" ID="lbpunetxt" runat ="server"><b></asp:Label></td>
</tr>

</table>
 <table width="360px" style="border-top:solid 1px black;" cellspacing="0"       cellpadding="0">
<tr >
<td align ="left" style="height: 13px" class="insertiontxtclass4" ><b><asp:Label CssClass="agecnycodeclasspune" ID="publ" runat ="server"></asp:Label></b></td>
<td  align ="left" style="height: 13px" class="insertiontxtclass_last" ><asp:Label CssClass="dateclasspune" ID="publication_value" runat ="server"></asp:Label></td>

 <td valign ="top" align ="left" style="height: 13px"  class="insertiontxtclass4" ><b><asp:Label CssClass="agecnycodeclasspune" ID="lbinvoiceno" runat ="server"></asp:Label></b></td>
 <td  valign ="top" align ="left" style="height: 13px" class="display2" ><asp:Label CssClass="dateclasspune" ID="txtinvoice" runat ="server"></asp:Label></td>
</tr>
<tr>

<td align ="left" style="height: 16px" class="insertiontxtclass4"  ><b><asp:Label CssClass="agecnycodeclasspune" ID="lbadtype" runat ="server"></asp:Label></b></td>
<td align ="left" style="height: 15px" class="insertiontxtclass_last"  ><asp:Label CssClass="dateclasspune" ID="adcat" runat ="server"></asp:Label></td>

<td align ="left" class="insertiontxtclass4" ><b><asp:Label CssClass="agecnycodeclasspune" ID="lbdate" runat ="server"></asp:Label></b></td>
<td  align ="left" class="display2" ><asp:Label CssClass="dateclasspune" ID="runtxt" runat ="server"></asp:Label></td>
</tr>
<tr>

<td align="left" class="display1"><b><asp:Label CssClass="agecnycodeclasspune" ID="lbpackagena" runat ="server"></asp:Label></b></td>
<td align ="left" class="insertiontxtclassCLA"><asp:Label CssClass="dateclasspune" ID="txtpackname" runat ="server"></asp:Label></td>
<td align="left" class="display1"><b><asp:Label CssClass="agecnycodeclasspune" ID="lbddate" runat ="server"></asp:Label></b></td>
<td align="left" ><asp:Label CssClass="dateclasspune" ID="ldduedate" runat ="server"></asp:Label></td>
</tr>
</table>
</td>
</td>
</table>
<table   cellspacing="0" cellpadding="0" style="border-bottom:solid 1px black" >
<tr>

<table  width="660px"   cellspacing="0" cellpadding="0" style="border-bottom:solid 1px black;vertical-align :top" >
<tr>
<td valign ="top" width="660px" style="border-bottom:solid 1px black;height: 120px;" >
       <asp:Label  id="dynamictable"  runat ="server"></asp:Label>
       </td>
  </tr>
   <tr ><td>
   
    <table  style="border-top:solid 1px black;" cellspacing="0" cellpadding="0"  width="660px"><tr>
                 <td width='335px'></td>
                 <td width='120px'></td>
                 <td width='155px'style="height: 12px;" align="right"><asp:Label ID="lb_total" runat="server" CssClass ="dateclasspune" ><b>Total:-</b></asp:Label></td>
                  <td style="height: 12px" align="center" ><asp:Label ID="lb_totalamt" runat="server" CssClass ="dateclasspune"></asp:Label></td>
                 </tr>  
                 </table>
          </td></tr>
 
  </table>
  
  
  <table   width="660px" cellspacing="0" cellpadding="0" border="0" >
  <tr>
  <td  style="font-size:9px;font-family :Times New Roman; height: 54px;border-bottom :solid 1px black;width: 335px;border-right:solid 1px black;">
 <asp:Label ID="hidedata" runat ="server" ></asp:Label>
  </td>
  <td style="font-size:10px;font-family :Verdana; height: 54px;width: 335px;vertical-align:top;" >
  <table width='335px' cellspacing="0" cellpadding="0" >
  <tr valign="top">
  <td  align="center"  width='60px'  class="insertiontxtclass4" style="height: 13px" ><asp:Label CssClass="agecnycodeclasspune" ID="lblamount" runat ="server"  ></asp:Label></b></td>
  <td  align="center" class="insertiontxtclass4" style="height: 13px" ><asp:Label  CssClass="agecnycodeclasspune" ID="lbtrade1" runat ="server"></asp:Label></td>
  <td  align="center" class="insertiontxtclass4" style="height: 13px" ><asp:Label  CssClass="agecnycodeclasspune" ID="lbadtd" runat ="server"></asp:Label></td>
  <td width="30px" class="insertiontxtclass4" style="height: 13px" ><asp:Label  CssClass="agecnycodeclasspune" ID="lbextpre" runat ="server"></asp:Label></td>
  <td  class="insertiontxtclass4" style="height: 13px" ><asp:Label  CssClass="agecnycodeclasspune" ID="lblnetpayable" runat ="server"></asp:Label></td>
  <td  class="newhead" style="height: 13px" ><asp:Label ID="roundoff" runat ="server" CssClass="dateclasspune_uday" ></asp:Label></td>
  </tr>
    <tr>
  <td align='center' class="insertiontxtclass_last" style="height: 13px" ><asp:Label CssClass="dateclasspune" ID="amount1" runat ="server"  ></asp:Label></td>
  <td align='center' class="insertiontxtclass_last" style="height: 13px" ><asp:Label CssClass="dateclasspune" ID="txtdiscal" runat ="server"></asp:Label></td>
  <td align='center'  class="insertiontxtclass_last" style="height: 13px" ><asp:Label CssClass="dateclasspune" ID="lbadtdtxt" runat ="server"></asp:Label></td>
  <td align='center' class="insertiontxtclass_last" style="height: 13px" ><asp:Label CssClass="dateclasspune" ID="lbextrapre" runat ="server"></asp:Label></td>
  <td align='center' class="insertiontxtclass_last" style="height: 13px" ><asp:Label CssClass="dateclasspune" ID="netpay" runat ="server"></asp:Label></td>
  <td align='center' class="insertiontxtclass_last"style="height: 13px" ><b><asp:Label CssClass="dateclasspune" ID="round_text" runat ="server"></asp:Label></b></td>
  </tr>
   
    </table>
    <table  width='335px' cellspacing="0" cellpadding="0" style="border-bottom:solid 1px black;">
     <td  width="105px" align="left" style="font-size:9px; height: 12px;" ><asp:Label ID="lbwordin" runat="server" CssClass ="insertiontxtclass2" ><b>Net Amount in words : </b></asp:Label></td>
                 <td align="left"><b><asp:Label ID="lbwordinrupees" runat="server" CssClass="insertiontxtclass2"  ></asp:Label></b>
                 </td>
                 </table>

     <table width='335px' cellspacing="0" cellpadding="0">
         <tr align="right">
  <td  style="font-size:10px;font-family :Verdana; height: 14px;vertical-align:top; visibility:hidden;"  align="left"><asp:Label ID="Label4" runat ="server" CssClass="dateclasspune"><b>VTS ENCLOSED</b></asp:Label></td>

                 <td  style="font-size:10px;font-family :Verdana; height: 14px;vertical-align:top;"  align="left"><asp:Label ID="Label18" runat ="server" CssClass="dateclasspune">For<b> Hari Bhoomi</b></asp:Label></td>
        </tr>
     </table>
     <table  width='335px' cellspacing="0" cellpadding="0" style="height: 65px">
     <tr><td align="right" valign="bottom" style="padding-right:10px;"><div id="divimg" runat="server" style="overflow:auto;"></div></td></tr></table>
  </td>
  

 </tr>
  
  </table>
  <table  style="border-bottom:solid 1px black;" width="655px">

   <tr  style="border-bottom:solid 1px black;">
            <td width="90px"><asp:Label ID="lbl_remark" runat="server" style="font-size:12px;font-family :Verdana; height: 14px;vertical-align:middle;"><b>Remarks:-</b></asp:Label>
            </td>
            <td width="100%" style="font-size:10px;font-family :Verdana; height: 14px;vertical-align:middle;"> 
            <asp:Label ID="txt_remark" runat="server"></asp:Label>
            </td></tr>

  </table>

        <table width="655px" cellpadding="0" cellspacing="0" border="0">
            <tr>
            <td valign ="bottom" style="font-size:10px;font-family :Verdana; height: 14px;vertical-align:top;" ><b><asp:Label  runat="server">Enclosed: Tear  Sheet</asp:Label></b></td>
            <td valign ="bottom" style="font-size:10px;font-family :Verdana; height: 14px;vertical-align:top;"><b><asp:Label  runat ="server"> E.& O.E.</asp:Label></b> </td>
            <td align="right"  style="font-size:10px;font-family :Verdana; height: 14px;vertical-align:top;"><b><asp:Label  runat ="server">Billing /Advt. Incharge</asp:Label></b></td>
            </tr>                       
        </table>

                 
</tr>
</td>
</table>
</p>
