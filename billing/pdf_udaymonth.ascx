<%@ Control Language="C#" AutoEventWireup="true" CodeFile="pdf_udaymonth.ascx.cs" Inherits="pdf_udaymonth" %>

<link href="css/udyavanibill.css" type="text/css" rel="Stylesheet" />

<head>

<script type="text/javascript"  language="javascript" src="javascript/billing.js"></script>

</head>
<p  id="P1" style="margin-top:0px">
<table  cellspacing="0" cellpadding="0"  width="660px" border="1" style="margin-top:-20px;">
<tr>
<td style="width: 660px" valign ="top" >
<table  style="vertical-align :top " width="660px" cellspacing="0" cellpadding="0" border="1">
<tr>
<td  align="center" valign="top"  style="width:100%;"><b>BILL</b></td>
</tr>
 </table>
 <table width="660px"  cellspacing="0" cellpadding="0"  border="1">
 <tr > <td >
 <table style="border-top:solid 1px black;border-right:solid 1px black;vertical-align :top " width="300px" cellspacing="0" cellpadding="0"  border="0">
 <tr>
    <td   align ="left" style="padding-left:5px;" ><b><asp:Label style="font-size :11px;font-family :Times New Roman;color:Black ;font-weight:bold;" ID="lblto" runat ="server" Text="To,"></asp:Label></b></td>
 </tr>
 <tr>
  <td  align ="left" valign ="top" style="padding-left:30px;" ><asp:Label style="font-size :11px;font-family :Times New Roman;color:Black ;font-weight:bold;"  ID="agddxt" runat ="server"></asp:Label></td>
   
 </tr>
 <tr>
 
 <td align ="left"  style="padding-left:30px; height: 13px;"><b> <asp:Label style="font-size :11px;font-family :Times New Roman;color:Black ;font-weight:bold;"  ID="agencyaddtxt" runat ="server"></asp:Label></b></td>
 </tr>
 
 <tr>
 <td   align ="left" style="padding-left:30px;" ><b><asp:Label style="font-size :11px;font-family :Times New Roman;color:Black ;font-weight:bold;"  ID="lbcityname" runat ="server"></asp:Label>
<asp:Label style="font-size :11px;font-family :Times New Roman;color:Black ;font-weight:bold;"  ID="txtpinno" runat ="server"></asp:Label></b></td>
 </tr>
 <tr><td >&nbsp;</td></tr>
 <tr>
  <td   align ="left" style="padding-left:30px;width:225px" ><b><asp:Label style="font-size :11px;font-family :Times New Roman;color:Black ;font-weight:bold;"  ID="lbcontectp" runat ="server" Text="Contact Person :"></asp:Label>
 <asp:Label style="font-size :11px;font-family :Times New Roman;color:Black ;font-weight:bold;"  ID="lbcontectpn" runat ="server" ></asp:Label></b></td>
</tr>
<tr ><td style="font-size:12px;font-family :Times New Roman; vertical-align:top;border-top:solid 1px black;" align='center'  class="dateclasspune2"><asp:Label ID="lbladrelpar" runat ="server" ><b>Advertisement Release Particulars</b></asp:Label></td></tr></table>      
</td>


<td cellspacing="0" cellpadding="0" >
<table width="30px">
<tr>
<td  align="left" valign="top" ><div id="divimg1" runat="server" ></div></td>
<td>
<table width="310px" cellspacing="0.1" cellpadding="0.1">
<tr ><td colspan="4" style="height: 11px" align="left"><asp:Label ID="lbcomp_name" style="font-size:12"  runat="server"><b>MANIPAL MEDIA NETWORK LTD</b></asp:Label></td></tr>
<tr><td colspan="4" align="center" style="height: 12px" ><asp:Label ID="lbcomp_add" CssClass="dateclasspune" runat="server"><b>Regd.office:Udayavani Building, Udayavani Road,Manipal-576104</b></asp:Label></td></tr>
<tr><td colspan="4" align="center"><asp:Label ID="lbcomp_ph" CssClass="dateclasspune" runat="server"><b>Ph:+91-820-2205000,2571152 fax:2570563,2570846</b></asp:Label></td></tr>
<tr><td colspan="4" align="center"><asp:Label ID="lbcomp_email" CssClass="dateclasspune" runat="server"><b>email:accounts.advt@manipalmedia.com</b></asp:Label></td></tr>
</table></td></tr></table>
<table width="300px" cellspacing="0" cellpadding="0" border="0">
<tr>
<td><asp:Label ID="Label6" runat="server" style="font-family :Times New Roman;color:Black ;font-size :10px;"><b>Member:ABC & INS</b></asp:Label></td>
<td align='right'><asp:Label ID="Label3" style="font-family :Times New Roman;color:Black ;font-size :10px;" runat="server"><b>PAN:AAACM 8839Q</b></asp:Label></td>
</tr>

</table>

<table width="100%" style="border-top:solid 1px black;border-bottom:solid 1px black;" cellspacing="0" cellpadding="0">
<tr >
<td align ="left" style="height: 13px" class="insertiontxtclass4" ><b><asp:Label style="font-size :11px;font-family :Times New Roman;color:Black ;font-weight:bold;"  ID="Label1" runat ="server">Publication</asp:Label></b></td>
<td  align ="left" style="height: 13px" class="insertiontxtclass_last" ><asp:Label CssClass="insertiontxtclass2" ID="lblpubname" runat ="server"></asp:Label></td>

 <td valign ="top" align ="left" style="height: 13px"  class="insertiontxtclass4" ><b> <asp:Label style="font-size :11px;font-family :Times New Roman;color:Black ;font-weight:bold;"  ID="lbinvoiceno" runat ="server">Bill No.</asp:Label></b></td>
 <td  valign ="top" align ="left" style="height: 13px" class="display2" ><asp:Label CssClass="dateclasspune" ID="txtinvoice" runat ="server"></asp:Label></td>
</tr>
<tr>

<td align ="left" style="height: 16px" class="insertiontxtclass4"  ><b><asp:Label style="font-size :11px;font-family :Times New Roman;color:Black ;font-weight:bold;"  ID="lbadtype" runat ="server">Ad Type</asp:Label></b></td>
<td align ="left" style="height: 15px" class="insertiontxtclass_last"  ><asp:Label CssClass="dateclasspune" ID="adcat" runat ="server"></asp:Label></td>

<td align ="left" class="insertiontxtclass4" ><b><asp:Label style="font-size :11px;font-family :Times New Roman;color:Black ;font-weight:bold;"  ID="lbdate" runat ="server">Date</asp:Label></b></td>
<td  align ="left" class="display2" ><asp:Label CssClass="dateclasspune" ID="runtxt" runat ="server"></asp:Label></td>
</tr>
<tr>

<td align="left" class="display1"><b><asp:Label style="font-size :11px;font-family :Times New Roman;color:Black ;font-weight:bold;"  ID="lbpackagena" runat ="server">RONo.</asp:Label></b></td>
<td align ="left" class="insertiontxtclassCLA"><asp:Label CssClass="dateclasspune" ID="txtpackname" runat ="server"></asp:Label></td>
<td align="left" class="display1"><b><asp:Label style="font-size :11px;font-family :Times New Roman;color:Black ;font-weight:bold;"  ID="lbddate" runat ="server">Due Date</asp:Label></b></td>
<td align="left" ><asp:Label CssClass="dateclasspune" ID="ldduedate" runat ="server"></asp:Label></td>
</tr>
</table>
</td>
</tr>

</table>
<table  width="660px"   cellspacing="0" cellpadding="0" style="border-bottom:solid 1px black;vertical-align :top" >
<tr>

<td valign ="top" style ="height :150px;">
       <asp:Label  id="dynamictable"  runat ="server"></asp:Label>
                                
                
     
       </td>
      
  
  
  </tr>
  
  
  
  
 <tr ><td>
   
   <table cellspacing="0" cellpadding="0"  style="border-top:solid 1px black;" width="660px"><tr>
<%--                 <td align="left"><asp:Label ID="lbinwords" runat="server" CssClass ="agecnycodeclasspune" Text="In Words Rupees  :"></asp:Label></td>--%>
                
                 <td   style="width:330px;"></td>
                 <td   style="width:360px;"></td>
                 <td style="height: 12px;width:155px;" align="right"  ><asp:Label ID="lb_total" runat="server" CssClass ="dateclasspune" ><b>Total:-</b></asp:Label></td>
                  <td style="height: 12px;width:90px " align="center" ><asp:Label ID="lb_totalamt" runat="server" CssClass ="dateclasspune"></asp:Label></td>
                
                 </tr>  
                 
                 </table>
                 
                 
                 
                 
                 </td>         
  <td > </td></tr>
  </table>
  
  
  
  <table   width="660" cellspacing="0" cellpadding="0" border="1" >
  <tr>
  <td  style="font-size:6px;font-family :Times New Roman; height: 54px;border-bottom :solid 1px black;width: 320px;border-right:solid 1px black;vertical-align:top;">
  <asp:Label ID="Label4" runat ="server" ><b><u>Terms & Conditions:</u></b>
                <br />1:&nbsp;Payment shall be made by A/c payee cheque or Bank Draft favouring 
                <b>"MANIPAL MEDIA &nbsp;&nbsp;&nbsp;&nbsp;NETWORK LIMITED"</b> 
                payable at <b>MANIPAL.</b>
                <br />
                2:&nbsp;All payments & communications regarding the bill must be made to the Manager - Advt
                &nbsp;&nbsp;&nbsp;&nbsp;Accounts. No objection or complaint
                regarding this bill will be entertained unless it is logged 
                &nbsp;&nbsp;&nbsp;&nbsp;within 15 days of presentation of the bill.<br />

                3:&nbsp;Payment must be accompanied with bill no.and
                date and made to Authorised Representatives &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;of 
                the Company only.<br />
                4:&nbsp;Official  Receipts issued by the Company 
                with signature of Authorised Signatories will only be
                &nbsp;&nbsp;&nbsp;&nbsp;binding on the Company.<br /> 

                5:&nbsp;Interest @20% on the bill amount will be charged for the delayed payment.<br /> 
                6:&nbsp;All disputes are subject to Manipal jurisdiction only.<br /></asp:Label>
  </td>
  <td style="font-size:10px;font-family :Verdana; height: 54px;width: 300px;vertical-align:top;" >
  <table width='300px' cellspacing="0" cellpadding="0" >
  <tr valign="top">
  <td  align="center"  style="height: 13px;border-bottom:solid 1px black;border-right:solid 1px black;color:Black ;background-color:Gray; " ><asp:Label ID="Label5" runat ="server" style="font-size :9px;font-family :Times New Roman;color:Black ;font-weight:bold;" >Gross</asp:Label></td>
  <td  align='center'style="height: 13px;border-bottom:solid 1px black;border-right:solid 1px black;color:Black ;background-color:Gray; "  ><asp:Label ID="Label7" runat ="server"  style="font-size :9px;font-family :Times New Roman;color:Black ;font-weight:bold;">(-)Trade Discount</asp:Label></td>
  <td  align='center' style="height: 13px;border-bottom:solid 1px black;border-right:solid 1px black;color:Black ;background-color:Gray; "  ><asp:Label ID="Label8" runat ="server"  style="font-size :9px;font-family :Times New Roman;color:Black ;font-weight:bold;">Addl Disc</asp:Label></td>
    <%--   <td  class="insertiontxtclass4" style="height: 13px" ><asp:Label ID="Label2" runat ="server" CssClass="dateclasspune_uday" >Extra</asp:Label></td>
    --%> 
 <td  style="height: 13px;border-bottom:solid 1px black;border-right:solid 1px black;color:Black ;background-color:Gray; "  ><asp:Label ID="lblboxcr" runat ="server"  style="font-size :9px;font-family :Times New Roman;color:Black ;font-weight:bold;"></asp:Label></td>
  <td  style="height: 13px;border-bottom:solid 1px black;border-right:solid 1px black;color:Black ;background-color:Gray; "  ><asp:Label ID="lblnetamt1" runat ="server"  style="font-size :9px;font-family :Times New Roman;color:Black ;font-weight:bold;"></asp:Label></td>
  <td  class="newhead" style="height: 13px" ><asp:Label ID="Label11" runat ="server"  style="font-size :9px;font-family :Times New Roman;color:Black ;font-weight:bold;">Rounded Off</asp:Label></td>
  </tr>
    <tr>
  <td align='center'  style="height: 13px;border-bottom:solid 1px black;border-right:solid 1px black;color:Black ;" ><asp:Label ID="lblgross" runat ="server"  CssClass="dateclasspune" ></asp:Label></td>
  <td align='center' style="height: 13px;border-bottom:solid 1px black;border-right:solid 1px black;color:Black ;" ><asp:Label ID="lbltradedis" runat ="server" CssClass="dateclasspune" ></asp:Label></td>
  <td align='center'  style="height: 13px;border-bottom:solid 1px black;border-right:solid 1px black;color:Black ;" ><asp:Label ID="lbladddis" runat ="server"  CssClass="dateclasspune"></asp:Label></td>
<%--  <td align='center'  class="insertiontxtclass_last" style="height: 13px" ><asp:Label ID="lblext" runat ="server"  CssClass="dateclasspune"></asp:Label></td>
--%>  <td align='center' style="height: 13px;border-bottom:solid 1px black;border-right:solid 1px black;color:Black ;" ><asp:Label ID="lblextra" runat ="server" CssClass="dateclasspune" ></asp:Label></td>
  <td align='center' style="height: 13px;border-bottom:solid 1px black;border-right:solid 1px black;color:Black ;"><asp:Label ID="lblnetamt" runat ="server" CssClass="dateclasspune"></asp:Label></td>
  <td align='center' class="display2" style="height: 13px" ><b><asp:Label ID="lblround" runat ="server" CssClass="dateclasspune"></asp:Label></b></td>
  </tr>
   
    </table>
    <table  width='335px' cellspacing="0" cellpadding="0" style="border-bottom:solid 1px black;">
     <td  align="left" style="font-size:9px; height: 12px;width:105px;" ><asp:Label ID="lbwordinrupees" runat="server" CssClass ="insertiontxtclass2" ><b>Net Amount in words : </b></asp:Label>
     </td>
                 <td align="left"><b><asp:Label ID="rupeetxt" runat="server" CssClass="insertiontxtclass2"></asp:Label></b>
                 </td>
                 </table>
    
     <table width='335px' cellspacing="0" cellpadding="0">
         <tr align="right">
  <td  style="font-size:10px;font-family :Verdana; height: 14px;vertical-align:top; visibility:hidden;"  align="left"><asp:Label ID="Label2" runat ="server" CssClass="dateclasspune"><b>VTS ENCLOSED</b></asp:Label></td>

                 <td  style="font-size:10px;font-family :Verdana; height: 14px;vertical-align:top;" ><asp:Label ID="Label18" runat ="server" CssClass="dateclasspune">For<b> Manipal Media Network Limited</b></asp:Label></td>
        </tr>
     </table>
     <table  width='335px' cellspacing="0" cellpadding="0" style="height: 65px">
     <tr><td align="right" valign="bottom" style="padding-right:10px;"><div id="divimg" runat="server" style="overflow:auto;"></div></td></tr></table>
  </td>
  

 </tr>
  
  </table>

  
  <table width="660px" cellspacing="0" cellpadding="0" >
 


<tr>
<td valign ="bottom" style="font-size:10px; height: 12px;" ><b><asp:Label ID="ENCLOSER" runat="server">Enclosed: Tear  Sheet</asp:Label></b></td>
<td valign ="bottom" style="font-size:10px; height: 12px;"></td>
<td valign ="bottom"  align="right" style="font-size:10px; height: 12px;">
<b> <asp:Label style="font-size :11px;font-family :Times New Roman;color:Black ;font-weight:bold;"   ID="EOU" runat ="server"> E.& O.E.</asp:Label></b> </td>

<td align="right"  valign ="bottom"   style="font-size:10px; height: 12px;" ><asp:Label  CssClass="BORDERPAN" ID="lbpune" runat ="server"></asp:Label><b><asp:Label  CssClass="dateclasspune" ID="lbpunetxt" runat ="server">Authorised Signatory</asp:Label></b></td>


</tr>


</table>



<table width="660px" style="border-top:solid 1px black;">
<tr>
<td style="border-right:solid 1px black;"class="insertiontxtclass3">UDAYAVANI</td>
<td style="border-right:solid 1px black;"class="insertiontxtclass3">TARANGA</td>
<td style="border-right:solid 1px black;" class="insertiontxtclass3">ROOPATARA</td>
<td style="border-right:solid 1px black;"class="insertiontxtclass3">TUSHARA</td>
<td style="border-right:solid 1px black;"class="insertiontxtclass3">TUNTURU</td>
<td class="insertiontxtclass3">www.udayavani.com</td>
</tr>
</table>
</td>
</tr>
</table><asp:Literal ID="lit_pagebreak" runat="server"></asp:Literal>

</p>
