<%@ Control Language="C#" AutoEventWireup="true" CodeFile="seaexpressbill_print.ascx.cs" Inherits="seaexpressbill_print" %>
<link href="css/udyavanibill.css" type="text/css" rel="Stylesheet" />
<head>
<title>SEA EXPRESS BILL PRINT</title>
<script type="text/javascript"  language="javascript" src="javascript/billing.js"></script>
</head>
<style type="text/css">
    .style1
    {
        height: 150px;
        width: 672px;
    }
    .style3
    {
        width: 657px;
    }
    .style4
    {
        border-bottom: solid 1px black;
        border-right: solid 1px black;
        color: Black;
        background-color: Gray;
        height: 13px;
        width: 126px;
    }
    .style5
    {
        border-bottom: solid 1px black;
        border-right: solid 1px black;
        color: Black;
        height: 13px;
        width: 126px;
    }
    .style6
    {
        border-bottom: solid 1px black;
        border-right: solid 1px black;
        color: Black;
        background-color: Gray;
        height: 13px;
        width: 96px;
    }
    .style7
    {
        border-bottom: solid 1px black;
        border-right: solid 1px black;
        color: Black;
        height: 13px;
        width: 96px;
    }
    .style8
    {
        border-bottom: solid 1px black;
        border-right: solid 1px black;
        color: Black;
        background-color: Gray;
        height: 13px;
        width: 141px;
    }
    .style9
    {
        border-bottom: solid 1px black;
        border-right: solid 1px black;
        color: Black;
        height: 13px;
        width: 141px;
    }
    .style10
    {
        border-bottom: solid 1px black;
        border-right: solid 1px black;
        color: Black;
        background-color: Gray;
        height: 13px;
        width: 84px;
    }
    .style11
    {
        border-bottom: solid 1px black;
        border-right: solid 1px black;
        color: Black;
        height: 13px;
        width: 84px;
    }
    .style12
    {
        width: 672px;
    }
</style>

<p  id="P1">
<table style="border:solid 1px black;margin-top:20px " cellspacing="0" cellpadding="0"  width="660px"    >
<tr>
<td valign ="top" class="style3" >

<table  style="vertical-align :top; width: 667px;" cellspacing="0" cellpadding="0" >
<tr>
<td  align="right" valign="top"width="330px"><B>ADVERTISEMENT BILL</B></td>

<td  align="center" style=" padding-right:30px;" ><img src="Images1/Sea_pring_logo.jpg" height ="30px"/></td>

</tr>
 
 
 </table>
 <table width="660px"  cellspacing="0" cellpadding="0" >
 <tr > <td >
 <table style="border-top:solid 1px black;border-right:solid 1px black;vertical-align :top; height: 110px; width: 302px;" 
         cellspacing="0" cellpadding="0"  border="0">
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
  <td   align ="left" style="padding-left:30px;width:225px; visibility:hidden;" ><b><asp:Label CssClass="agecnycodeclasspune" ID="lbcontectp" runat ="server" Text="Contact Person :"></asp:Label>
 <asp:Label CssClass="agecnycodeclasspune" ID="lbcontectpn" runat ="server" ></asp:Label></b></td>
</tr>
<tr ><td style="font-size:12px;font-family :Times New Roman; vertical-align:top;border-top:solid 1px black;" align='center'  class="dateclasspune2">
<asp:Label ID="lbladrelpar" runat ="server" CssClass="dateclasspune"><b>Advertisement Release Particulars</b></asp:Label></td></tr></table>      
</td>
<td valign="top" >
<table style="width: 366px">
<tr>
<td>
<table cellspacing="0" cellpadding="0" style="width: 359px">
<tr ><td colspan="4" style="height: 11px; padding-right:20px;" align="center"><asp:Label ID="lbcomp_name" style="font-size:12"  runat="server"><B>Sea Print Media and Publication Ltd.</B></asp:Label></td></tr>
<tr><td colspan="4" align="center" ><asp:Label ID="lbcomp_add" CssClass="dateclasspune" runat="server"><b>Express House,Manas Nagar X-ing ,M.G.-2 Shahganj,Agra-282010</b></asp:Label></td></tr>
<tr><td colspan="4" align="center"><asp:Label ID="lbcomp_ph" CssClass="dateclasspune" runat="server"><b>Ph.No.:-09837099999,0562-3021655 Fax.No.0562-3021640</b></asp:Label></td></tr>
<tr><td colspan="4" align="center"><asp:Label ID="lbcomp_email" CssClass="dateclasspune" runat="server"><b>Email:advt@theseaexpress.com</b></asp:Label></td></tr>
</table></td></tr></table>
<table cellspacing="0" cellpadding="0" style="height: 13px; width: 360px">
<tr>
<td style="visibility:hidden;" ><asp:Label ID="Labe1l6" runat="server" CssClass="dateclasspune"><b>Member:ABC & INS</b></asp:Label></td>
<%--<td align='right' style="visibility:hidden;"><asp:Label ID="Label3" CssClass="dateclasspune" runat="server"><b>Service Tax No.AAJCA1068LSD002</b></asp:Label></td>
--%><td align='right' style="hight:10px;" ><asp:Label ID="Label6" runat="server" CssClass="dateclasspune"><b>PAN:-AAPCS5172D</b></asp:Label></td>
</tr>

</table>

<table style="border-top:solid 1px black; width: 368px;" cellspacing="0" 
        cellpadding="0">
<tr >
<td align ="left" style="height: 13px" class="insertiontxtclass4" ><b><asp:Label CssClass="agecnycodeclasspune" ID="Label1" runat ="server">Publication</asp:Label></b></td>
<td  align ="left" style="height: 13px" class="insertiontxtclass_last" ><asp:Label CssClass="insertiontxtclass2" ID="lblpubname" runat ="server"></asp:Label></td>

 <td valign ="top" width='53px' align ="left" style="height: 13px"  class="insertiontxtclass4" ><b> <asp:Label CssClass="agecnycodeclasspune" ID="lbinvoiceno" runat ="server">Bill No.</asp:Label></b></td>
 <td  valign ="top" align ="left" style="height: 13px; padding-left:2px;"  width='53px' class="display2" ><asp:Label CssClass="dateclasspune" ID="txtinvoice" runat ="server"></asp:Label></td>
</tr>
<tr>

<td align ="left" style="height: 16px" class="insertiontxtclass4"  ><b><asp:Label CssClass="agecnycodeclasspune" ID="lbadtype" runat ="server">Ad Type</asp:Label></b></td>
<td align ="left" style="height: 15px" class="insertiontxtclass_last"  ><asp:Label CssClass="dateclasspune" ID="adcat" runat ="server"></asp:Label></td>

<td align ="left" width='53px' class="insertiontxtclass4" ><b><asp:Label CssClass="agecnycodeclasspune" ID="lbdate" runat ="server">Date</asp:Label></b></td>
<td  align ="left"style=" padding-left:2px;" class="display2"  width='53px'><asp:Label CssClass="dateclasspune" ID="runtxt" runat ="server"></asp:Label></td>
</tr>
<tr>

<td align="left" class="display1"><b><asp:Label CssClass="agecnycodeclasspune" ID="lbpackagena" runat ="server">Tariff Plan/Package</asp:Label></b></td>
<td align ="left" class="insertiontxtclassCLA"><asp:Label CssClass="dateclasspune" ID="txtpackname" runat ="server"></asp:Label></td>
<td align="left" width='53px' class="display1"><b><asp:Label CssClass="agecnycodeclasspune" ID="lbddate" runat ="server">Due Date</asp:Label></b></td>
<td align="left" width='53px' style="padding-left:2px;" width='53px'><asp:Label CssClass="dateclasspune" ID="ldduedate" runat ="server"></asp:Label></td>
</tr>
</table>
</td>
</tr>

</table>




<table   cellspacing="0" cellpadding="0" 
                        
                        style="border-bottom:solid 1px black;vertical-align :top;" >
<tr>

<td valign ="top" class="style1">
       <asp:Label  id="dynamictable"  runat ="server"></asp:Label>
       </td>
  </tr>
 <tr ><td class="style12">
   <table  style="width: 670px;" cellspacing="0" 
         cellpadding="0"><tr>
<%--         border-top:solid 1px black;        <td align="left"><asp:Label ID="lbinwords" runat="server" CssClass ="agecnycodeclasspune" Text="In Words Rupees  :"></asp:Label></td>--%>
                 <%--<td  width='105px'align="left" style="font-size:9px; height: 12px;" ><asp:Label ID="lbwordinrupees" runat="server" CssClass ="insertiontxtclass2" ><b>Net Amount in words : </b></asp:Label></td>
                 <td align="left"><asp:Label ID="rupeetxt" runat="server" CssClass="insertiontxtclass2"  ></asp:Label>
                 </td>--%>
                 <td width='535px'></td>
                 
                 <td width='55px'style="height: 12px;border-top:solid 1px black;border-left:solid 1px black;border-right:solid 1px black;  " align="center"  ><asp:Label ID="lb_total" runat="server" CssClass ="dateclasspune" ><b>Total:-</b></asp:Label></td>
                  <td width='53px' style="height: 12px;border-top:solid 1px black;  " align="center" ><asp:Label ID="lb_totalamt" runat="server" CssClass ="dateclasspune"></asp:Label></td>
                 </tr>  
                 </table>
                 </td>         
  </tr>
  </table>
  <table   width="660px" cellspacing="0" cellpadding="0" border="0" >
  <tr>
  <td style="font-size:10px;font-family :Verdana; height: 54px;vertical-align:top;" >
  <table cellspacing="0" cellpadding="0" style="width: 670px; height: 43px" >
  <tr valign="top">
  <td  align="center"  class="style6" ><asp:Label ID="Label5" runat ="server" CssClass="dateclasspune_uday" >Gross Amount</asp:Label></td>
  <td  align="center"class="style4" ><asp:Label ID="Label7" runat ="server" CssClass="dateclasspune_uday" >(-)Applicable Discount</asp:Label></td>
  <td  align="center"class="style8" ><asp:Label ID="Label8" runat ="server" CssClass="dateclasspune_uday" >Addl.Disc(if Any)</asp:Label></td>
<%--   <td  class="insertiontxtclass4" style="height: 13px" ><asp:Label ID="Label2" runat ="server" CssClass="dateclasspune_uday" >Extra</asp:Label></td>
--%>  <td align="center"  class="style10" ><asp:Label ID="Label9" runat ="server" CssClass="dateclasspune_uday" >Special Charges</asp:Label></td>
  <td align="center"  class="insertiontxtclass4" style="height: 13px" ><asp:Label ID="Label10" runat ="server" CssClass="dateclasspune_uday" >Net Amount</asp:Label></td>
  <td align="center"  class="newhead" style="height: 13px" ><asp:Label ID="Label11" runat ="server" CssClass="dateclasspune_uday" >Rounded Off</asp:Label></td>
  </tr>
    <tr>
  <td align='center' class="style7" ><asp:Label ID="lblgross" runat ="server"  CssClass="dateclasspune" ></asp:Label></td>
  <td align='center' class="style5" ><asp:Label ID="lbltradedis" runat ="server" CssClass="dateclasspune" ></asp:Label></td>
  <td align='center'  class="style9" ><asp:Label ID="lbladddis" runat ="server"  CssClass="dateclasspune"></asp:Label></td>
<%--  <td align='center'  class="insertiontxtclass_last" style="height: 13px" ><asp:Label ID="lblext" runat ="server"  CssClass="dateclasspune"></asp:Label></td>
--%>  <td align='center' class="style11" ><asp:Label ID="lblextra" runat ="server" CssClass="dateclasspune" ></asp:Label></td>
  <td align='center' class="insertiontxtclass_last" style="height: 13px" ><asp:Label ID="lblnetamt" runat ="server" CssClass="dateclasspune"></asp:Label></td>
  <td align='center' class="display2" style="height: 13px" ><b><asp:Label ID="lblround" runat ="server" CssClass="dateclasspune"></asp:Label></b></td>
  </tr>
   
    </table>
    <table cellspacing="0" cellpadding="0" 
          style="border-bottom:solid 1px black; width: 670px; height: 25px;">
     <td  width="145px"align="left" style="font-size:9px; height: 12px;" ><asp:Label ID="lbwordinrupees" runat="server" CssClass ="insertiontxtclass2" ><b>Net Payable Amount in words : </b></asp:Label></td>
                 <td align="left"><b><asp:Label ID="rupeetxt" runat="server" CssClass="insertiontxtclass2"  ></asp:Label></b>
                 </td>
                 <td align="right" valign="bottom" style="padding-right:10px;">
     <div id="divimg" runat="server" style="overflow:auto;"></div>
     </td>
                 </table>
    
    <%-- <table width='335px' cellspacing="0" cellpadding="0">
         <tr align="right">
           <td  style="font-size:10px;font-family :Verdana; height: 54px;vertical-align:top; visibility:hidden; "  align="left"><asp:Label ID="Label2" runat ="server" CssClass="dateclasspune"><b>VTS ENCLOSED</b></asp:Label></td>

                 <td  style="font-size:10px;font-family :Verdana; height: 54px;vertical-align:top;" ><asp:Label ID="Label18" runat ="server" CssClass="dateclasspune">For<b> Manipal Media Network Limited</b></asp:Label></td>
        </tr>
     </table>--%>
     <table width='335px' cellspacing="0" cellpadding="0">
         <tr align="right">
  
        </tr>
     </table>
     <table  width='335px' cellspacing="0" cellpadding="0" >
     <tr></tr></table>
  </td>
  
</tr>
 </tr>
  </td>
   <td  style="font-size:10px;font-family :Times New Roman; height: 54px;border-bottom :solid 1px black;width: 660px;">
  <asp:Label ID="Label4" runat ="server"   width="669px" ><b><u>Terms & Conditions:</u></b><br />
1:&nbsp;Amount once paid is non refundable however if required can be adjusted against subsequent bookings.<br />
2:&nbsp;In Case of non realistion of cheque Rs.250/-shall be charged as bank charges and also interest @24% per annum shall be charged on the outstanding amount.<br />
3:&nbsp;Payment must be accompained with bill no.and date and made to Authorised Representatives of the Company only.<br /> 
4:&nbsp;Interest @18% on the bill amount will be charged for the payment delayed after Due date.<br /> 
5:&nbsp;All disputes are subject to AGRA jurisdiction only.<br /> 
</asp:Label>
  </td>
  </table>
  <table cellspacing="0" cellpadding="0" style="width: 670px" >
  <tr>
  <td style="font-size:9px;font-family :Times New Roman; border-bottom :solid 1px black;width: 660px;">
  <asp:Label ID="Label13" runat ="server" >
 <b>ALL Payments must be by Crossed Cheque/Demand drafts drawm in favor off &nbsp;"SEA PRINT MEDIA AND PUBLICATION LTD." payable at Agra.</b><br />
 <b>This is a computer generated document and do not require a signature.</b>
  </asp:Label>
  
  </td>
  </tr>
  </table>

  
  <table cellspacing="0" cellpadding="0" style="width: 670px" >
 <tr>
<td valign ="bottom" style="font-size:10px; height: 12px;" ><b><asp:Label ID="ENCLOSER" runat="server">Enclosed: "The Sea Express" NEWSPAPER TEAR SHEET</asp:Label></b></td>
<td valign ="bottom" style="font-size:10px; height: 12px;"></td>
<td></td>
<td align="right"  valign ="bottom"   style="font-size:10px; height: 12px; visibility:hidden;" ><asp:Label  CssClass="BORDERPAN" ID="lbpune" runat ="server"><b></asp:Label><asp:Label  CssClass="dateclasspune" ID="lbpunetxt" runat ="server">Authorised Signatory</asp:Label><b>
</td>


</tr>
<tr>
<td valign ="bottom"  align="left" style="font-size:10px; height: 12px;">
<b> <asp:Label CssClass="agecnycodeclasspune"  ID="Label12" runat ="server"> E.& O.E.</asp:Label></b> </td>
</tr>
</table>
</td>
</tr>
</table>
<%--<table   style="visibility:hidden; height:40px;width:660px;"><tr><td></td></tr></table>
--%>
</p>