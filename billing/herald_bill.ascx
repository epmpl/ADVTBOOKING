<%@ Control Language="C#" AutoEventWireup="true" CodeFile="herald_bill.ascx.cs" Inherits="herald_bill" %>


<link href="css/udyavanibill.css" type="text/css" rel="Stylesheet" />

<head>
<title>HERALD BILL PRINT</title>
<script type="text/javascript"  language="javascript" src="javascript/billing.js"></script>

</head>
<p  id="P1">
<table style="width:660px;" ><tr><td>

<table style="margin-top:20px; height:200; " cellspacing="0" cellpadding="0"  width="660px">
<%--<tr >
    <td  valign ="top"  align ="center" style="width:640px;padding-left:60px" ><b><asp:Label  ID="line" runat ="server" ></asp:Label></b></td>
    <td  valign ="top"  align ="center" ></td>
    </tr>--%>
<tr  align="center">
    <td  style="width:660px;padding-left:60px;" align ="center" >
    <b>
    <asp:Label CssClass="agecnycodeclasspunehead" ID="lbcompanynametxt1" runat ="server" Font-Names="Times New Roman" Font-Size="18pt"></asp:Label></b>
    </td>
    </tr>

 <tr style="height:10PX;">  
    <td   style="width:640px;padding-left:60px;" valign ="top"  align ="center"  >
    <asp:Label   ID="line1" runat ="server"  CssClass="dateclasspune_uday1"   Font-Size="10pt"></asp:Label></td>
    </tr>
    <tr style="height:10PX;">  
    <td   style="width:640px;padding-left:60px;" valign ="top"  align ="center"  >
    <asp:Label   ID="line2" runat ="server"  CssClass="dateclasspune_uday1"   Font-Size="10pt"></asp:Label></td>
    </tr>
    <tr style="height:10PX;">  
    <td   style="width:640px;padding-left:60px;" valign ="top"  align ="center"  >
    <asp:Label   ID="line3" runat ="server"  CssClass="dateclasspune_uday1"   Font-Size="10pt"></asp:Label></td>
    </tr>
 
 <tr>

<tr>
<td  align="center" valign="top"  style="width:100%; height:120;" ><b>BILL</b></td>
</tr>
 </table>
 <table>
 <tr><td style="height:80;"></td></tr>
</table> 
 <table width="660px"  cellspacing="0" cellpadding="0" >
 <tr > <td >
 <table style=" padding-left:50px;vertical-align :top " width="300px" cellspacing="0" cellpadding="0"  border="0">
 <tr>
    <td   align ="left" style="padding-left:5px;" ><b><asp:Label CssClass="agecnycodeclasspune" ID="lblto" runat ="server" Text="To,"></asp:Label></b></td>
 </tr>
 <tr>
  <td  align ="left" valign ="top" style="padding-left:30px;" ><asp:Label CssClass="agecnycodeclasspune" ID="agddxt" runat ="server"></asp:Label></td>
   
 </tr>
 <tr>
 
 <td align ="left"  style="padding-left:30px;"><b> <asp:Label CssClass="agecnycodeclasspune" ID="agencyaddtxt" runat ="server"></asp:Label></b></td>
 </tr>
 
 <tr>
 <td   align ="left" style="padding-left:30px;" ><b><asp:Label CssClass="agecnycodeclasspune" ID="lbcityname" runat ="server"></asp:Label>
<asp:Label CssClass="agecnycodeclasspune" ID="txtpinno" runat ="server"></asp:Label></b></td>
 </tr>
 <tr><td >&nbsp;</td></tr>
 <tr>

</tr>
<tr >
<td align ="left" valign ="top" style="padding-left:30px;">
<asp:Label ID="lbladrelpar" runat ="server" Font-Size="10pt" CssClass="dateclasspune"><b>Advertisement Release Particulars</b></asp:Label></td>
</tr>

</table>      
</td>


<td cellspacing="0" cellpadding="0" >
<table width="360px" cellspacing="0" cellpadding="0">
<tr>
<td><asp:Label ID="Label6" runat="server"  Font-Size="10pt"  CssClass="dateclasspune"><b>Member:ABC & INS</b></asp:Label></td>
<td align='right'><asp:Label ID="Label3"  Font-Size="10pt"  CssClass="dateclasspune" runat="server"><b>PAN:AAACH4589K</b></asp:Label></td>
</tr>

</table>

<table width="100%" style="border-top:solid 1px black;border-bottom:solid 1px black;" cellspacing="0" cellpadding="0">
<tr >
<td align ="left" style="height: 13px" class="insertiontxtclass4" ><b><asp:Label CssClass="agecnycodeclasspune" ID="Label1" runat ="server">Publication</asp:Label></b></td>
<td  align ="left" style="height: 13px" class="insertiontxtclass_last" ><asp:Label CssClass="insertiontxtclass2" ID="lblpubname" runat ="server"></asp:Label></td>

 <td valign ="top" align ="left" style="height: 13px"  class="insertiontxtclass4" ><b> <asp:Label CssClass="agecnycodeclasspune" ID="lbinvoiceno" runat ="server">Bill No.</asp:Label></b></td>
 <td  valign ="top" align ="left" style="height: 13px" class="display2" ><b><asp:Label CssClass="dateclasspune" ID="txtinvoice"  Font-Size="12pt"  runat ="server"></asp:Label></b></td>
</tr>
<tr>

<td align ="left" style="height: 16px" class="insertiontxtclass4"  ><b><asp:Label CssClass="agecnycodeclasspune" ID="lbadtype" runat ="server">Ad Type</asp:Label></b></td>
<td align ="left" style="height: 15px" class="insertiontxtclass_last"  ><asp:Label CssClass="dateclasspune" ID="adcat" runat ="server"></asp:Label></td>

<td align ="left" class="insertiontxtclass4" ><b><asp:Label CssClass="agecnycodeclasspune" ID="lbdate" runat ="server">Date</asp:Label></b></td>
<td  align ="left" class="display2" ><asp:Label CssClass="dateclasspune" ID="runtxt" runat ="server"></asp:Label></td>
</tr>
<tr>

<td align="left" class="insertiontxtclass4"><b><asp:Label CssClass="agecnycodeclasspune" ID="lbpackagena" runat ="server">RONo.</asp:Label></b></td>
<td align ="left" class="insertiontxtclass_last"><asp:Label CssClass="dateclasspune" ID="txtpackname" runat ="server"></asp:Label></td>
<td align="left" class="insertiontxtclass4"><b><asp:Label CssClass="agecnycodeclasspune" ID="lbddate" runat ="server">Due Date</asp:Label></b></td>
<td align="left" class="insertiontxtclass_last"><b><asp:Label CssClass="dateclasspune" ID="ldduedate" runat ="server"></asp:Label></td>
</tr>
</table>
</td>
</tr>

</table>
<table  width="660px"   cellspacing="0" cellpadding="0" style="vertical-align :top" >
<tr>

<td valign ="top" style ="height :150px;">
       <asp:Label  id="dynamictable"  runat ="server"></asp:Label>
       </td>
  </tr>
 <tr ><td>
   <table cellspacing="0" cellpadding="0"  width="660px"><tr>
<%--                 <td align="left"><asp:Label ID="lbinwords" runat="server" CssClass ="agecnycodeclasspune" Text="In Words Rupees  :"></asp:Label></td>--%>
                 
                 <td style="height: 12px; border-top:solid 1px black;" align="right"  ><asp:Label ID="lb_total" runat="server"  Font-Size="11pt"  CssClass ="dateclasspune" ><b>Total Rs.</b></asp:Label>:-</td>
                  <td style="height: 12px;width:90px;border-top:solid 1px black;" align="center" ><b><asp:Label ID="lb_totalamt" runat="server"  Font-Size="11pt"  CssClass ="dateclasspune"></asp:Label></b></td>
                 </tr>  
   <tr><td style="height:12px;" align="right"><asp:Label ID="Label9" runat ="server"  CssClass="dateclasspune_uday"  Font-Size="11pt"   Text="Other Surcharges Rs. "></asp:Label>:-</td>
   <td style="height: 12px;width:90px " align="center"><asp:Label ID="lblextra" Font-Size="11pt" runat ="server" CssClass="dateclasspune" Font-Bold="true"  ></asp:Label></td></tr>
                 <tr>
                 <td style="height: 12px;border-top:solid 1px black;border-bottom:solid 1px black;" align="right"  ><b><asp:Label   Font-Size="11pt"  CssClass="agecnycodeclasspune" ID="Label20"  Text="Net Payable Rs." runat="server"></asp:Label></b></td>

<td  style="height: 12px;width:90px;border-top:solid 1px black;border-bottom:solid 1px black;" align="center" ><b><asp:Label  CssClass="agecnycodeclasspune" ID="Label21" Font-Size="11pt" runat="server"></asp:Label></b></td>
</tr>
                
                 </table>
                 </td>         
  <td > </td></tr>
  </table>
  <table   width="660px" cellspacing="0" cellpadding="0" border="0"  >
  <tr>
  <td   align="left" style="font-family :Times New Roman; height: 24px;" ><asp:Label ID="Label12" runat="server" CssClass ="insertiontxtclass2" Font-Size="10pt" ><b>Rupees</b> :<asp:Label ID="totalruptxt" runat="server" CssClass="insertiontxtclass2" Font-Size="10pt" Font-Bold="true" ></asp:Label></asp:Label></td>
                 <td style="height: 12px;" align="right" >
                 </td>
  </tr>
  <tr>
  
  <td  style="font-size:8.5px;font-family :Times New Roman; height:35px;width: 335px;"  align="left" >
  <asp:Label ID="Label4" runat ="server"  CssClass="dateclasspune_uday1"   Font-Size="12pt"><b><u>Terms & Conditions</u>:-</b><br/></asp:Label>
  </td>
   <td  style="font-size:10px;font-family :Verdana; height: 14px;" align="right" ><asp:Label ID="Label18" Font-Size="10pt" runat ="server" CssClass="dateclasspune"><b>For   HERALD PUBLICATION PRIVATE LIMITED</b></asp:Label>
                 </td>
  <tr>
  <td  align="left"  style="font-size:8.5px;font-family :Times New Roman; height: 24px;width:335px;">
  <asp:Label ID="lbl1" runat ="server" CssClass="dateclasspune_uday1"   Font-Size="10pt"></asp:Label></td>
 <td></td>
  </tr>
  
  <tr>
  <td  align="left"  style="font-size:8.5px;font-family :Times New Roman; height: 24px;width: 335px;">
  <asp:Label ID="lbl2" runat ="server" CssClass="dateclasspune_uday1"   Font-Size="10pt"></asp:Label></td>
  <td></td>
  </tr>
  
  <tr>
  <td  align="left"  style="font-size:8.5px;font-family :Times New Roman; height: 24px;width: 335px;">
  <asp:Label ID="lbl3" runat ="server" CssClass="dateclasspune_uday1"   Font-Size="10pt"></asp:Label></td>
   <td></td>
  </tr>
  <tr>
  <td  align="left"   style="font-size:8.5px;font-family :Times New Roman; height: 24px;width: 335px;">
  <asp:Label ID="lbl4" runat ="server" CssClass="dateclasspune_uday1"   Font-Size="10pt"></asp:Label></td>
   <td  align="right"  valign ="bottom"   style=" height: 25px; " >
<asp:Label  CssClass="dateclasspune_uday1"  Font-Size="10pt" ID="lbpunetxt"  runat ="server">Authorised Signatory</asp:Label>
</td>
  </tr>
  
 </tr>
 </table>
<table  width="660px" cellspacing="0" cellpadding="0" border="0">
<tr><td   align ="left" style="padding-left:30px;width:343px; visibility:hidden;" ><b><asp:Label CssClass="agecnycodeclasspune" ID="Label16" runat ="server" Text="Contact Person :"></asp:Label>
 <asp:Label CssClass="agecnycodeclasspune" ID="Label17" runat ="server" ></asp:Label></b></td><td></td></tr>
<tr><td align="center" style="width: 330px;"><asp:Label id="lblvj" runat ="server" ></asp:Label></td><td  align="center" style="width: 330px;"><asp:Label id="Label19" runat ="server" ></asp:Label></td></tr>

<tr><td style="width: 343px">
<table><tr><td>
  <table width='335px' cellspacing="0" cellpadding="0" style="visibility:hidden;" >
  <tr></tr>
  <tr></tr>
  <tr valign="top">
  <td  align="center" class="insertiontxtclass4" ><asp:Label ID="Label5" runat ="server" CssClass="dateclasspune_uday" >Gross</asp:Label></td>
  <td  align='center'class="insertiontxtclass4" style="height: 13px" ><asp:Label ID="Label7" runat ="server" CssClass="dateclasspune_uday" >(-)Trade Discount</asp:Label></td>
  <td  align='center'class="insertiontxtclass4" style="height: 13px" ><asp:Label ID="Label8" runat ="server" CssClass="dateclasspune_uday" >Addl Disc</asp:Label></td>
<%--   <td  class="insertiontxtclass4" style="height: 13px" ><asp:Label ID="Label2" runat ="server" CssClass="dateclasspune_uday" >Extra</asp:Label></td>
--%>  <td  class="insertiontxtclass4" style="height: 13px;width:30px;" ></td>
  <td  class="insertiontxtclass4" style="height: 13px" ><asp:Label ID="Label10" runat ="server" CssClass="dateclasspune_uday" >Net Amount</asp:Label></td>
  <td  class="newhead" style="height: 13px" ><asp:Label ID="Label11" runat ="server" CssClass="dateclasspune_uday" >Rounded Off</asp:Label></td>
  </tr>
    <tr>
  <td align='center' class="insertiontxtclass_last" style="height: 13px" ><asp:Label ID="lblgross" runat ="server"  CssClass="dateclasspune" ></asp:Label></td>
  <td align='center' class="insertiontxtclass_last" style="height: 13px" ><asp:Label ID="lbltradedis" runat ="server" CssClass="dateclasspune" ></asp:Label></td>
  <td align='center'  class="insertiontxtclass_last" style="height: 13px" ><asp:Label ID="lbladddis" runat ="server"  CssClass="dateclasspune"></asp:Label></td>
<%--  <td align='center'  class="insertiontxtclass_last" style="height: 13px" ><asp:Label ID="lblext" runat ="server"  CssClass="dateclasspune"></asp:Label></td>
--%>  <td align='center' class="insertiontxtclass_last" style="height: 13px" ></td>
  <td align='center' class="insertiontxtclass_last" style="height: 13px" ><asp:Label ID="lblnetamt" runat ="server" CssClass="dateclasspune"></asp:Label></td>
  <td align='center' class="display2" style="height: 13px" ><b><asp:Label ID="lblround" runat ="server" CssClass="dateclasspune"></asp:Label></b></td>
  </tr>
    </table>
</td></tr></table></td>
<td> <table  width='335px'style="visibility:hidden;">
     <td  align="left" ><asp:Label ID="lbwordinrupees" runat="server" CssClass ="insertiontxtclass2" ><b> </b></asp:Label>
     </td>
                 <td align="left"><b><asp:Label ID="rupeetxt" runat="server" CssClass="insertiontxtclass2"></asp:Label></b>
                 </td>
                 </table></td>
</tr>
</table>



<table style="margin-top:20px;"  cellspacing="0" cellpadding="0"  width="660px">
<tr>
<td valign ="top" style="height:10px; width:335px;"  align="left"  ><asp:Label CssClass="dateclasspune_uday1"  ID="lblcomp" runat ="server"  Font-Size="10pt"  ></asp:Label></td>

<td valign ="top" style=" height: 12px; padding-left:60px;"  align="right"><asp:Label ID="lbladdres" runat="server" CssClass="dateclasspune_uday1"   Font-Size="10pt"></asp:Label></td>

</tr>
<tr>
<td valign ="top"  align="left"  style="font-size:10px; height: 16px;" ><asp:Label CssClass="dateclasspune_uday2" ID="lblcom" runat="server"  Font-Size="11pt"></asp:Label></td>

<td style="height:10px; width:335px;"></td>
</tr>
<tr><td  valign ="top"  align="left" style="font-size:10px; height: 15px;" ><table>
<td valign ="top" align="center" style="font-size:10px; height: 18px;" ><b><asp:Label CssClass="dateclasspune_uday2" ID="lblbill1"  Font-Size="12pt" runat="server"></asp:Label></b></td>
<td valign ="top" align="center" style="font-size:10px; height: 18px;" ><b><asp:Label  CssClass="dateclasspune_uday2" ID="txtinvoice1" Font-Size="12pt" runat="server"></asp:Label></b></td>
</table></td>

<td ></td>
</tr>
</table>
<table valign ="top" style="margin-top:20px;"  cellspacing="0" cellpadding="0"  width="660px">
<tr>
<td valign ="top"  style="width:550;"><asp:Label  CssClass="agecnycodeclasspune" ID="Label15" runat="server"></asp:Label></td>
<td valign ="top" align="right"style="font-size:10px; height: 18px;" ><b><asp:Label  CssClass="agecnycodeclasspune" ID="lblgrosss" Font-Size="11pt" runat="server"></asp:Label>:- </b> </td>

<td valign ="top"  align="center" style="font-size:10px; height: 18px;" ><b><asp:Label  CssClass="agecnycodeclasspune" ID="lblgross2" Font-Size="11pt" runat="server"></asp:Label></b></td>
</tr>
<tr>
<td valign ="top" style="width:550;"><asp:Label  CssClass="agecnycodeclasspune" ID="Label2" runat="server"></asp:Label></td>
<td valign ="top"  align="right" style="font-size:10px; height: 18px;"  ><b><asp:Label CssClass="agecnycodeclasspune" Font-Size="11pt"  ID="lblless1" runat="server"></asp:Label><asp:Label CssClass="agecnycodeclasspune" Font-Size="11pt"  ID="trdiscpercentage" runat="server"></asp:Label>%:-</b> </td>
<td valign ="top" align="center" style="font-size:10px; height: 18px;"  ><b><asp:Label CssClass="agecnycodeclasspune" Font-Size="11pt" ID="lbltradedis1" runat="server"></asp:Label></b></td>
</tr>
<tr>
<td valign ="top" style="width:550;"><asp:Label  CssClass="agecnycodeclasspune" ID="Label13" runat="server"></asp:Label></td>

<td  valign ="top"  align="right" style="font-size:18px; height: 18px;"><b><asp:Label  CssClass="agecnycodeclasspune" ID="vjl13" runat="server"></asp:Label></b> </td>


<td valign ="top"  align="center" style="font-size:18px; height: 18px;"><b><asp:Label  CssClass="agecnycodeclasspune" ID="vjl14"  runat="server"></asp:Label></b> </td>

</tr>
<tr>
<td valign ="top" style="height:20px;width:550"><asp:Label  CssClass="agecnycodeclasspune" ID="Label14" Font-Size="11pt" runat="server"></asp:Label></td>
<td valign ="top" align="right" style="font-size:18px; height: 18px; "  ><b><asp:Label  CssClass="agecnycodeclasspune" ID="bllnet" Font-Size="11pt" runat="server"></asp:Label>:-</b> </td>
<td valign ="top"  align="center" style="font-size:18px; height: 18px;"  ><b><asp:Label  CssClass="agecnycodeclasspune" ID="lblround1" Font-Size="11pt" runat="server"></asp:Label></b></td>
<td style="visibility:hidden; height:90px;"></td>
</tr>

</table>
<%--<table ><tr><td style="visibility:hidden; height:8px;width:660px;"></td></tr></table>
--%>
</td></tr>
</table>

</p>
