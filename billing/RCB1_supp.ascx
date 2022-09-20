<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RCB1_supp.ascx.cs" Inherits="RCB1_supp" %>


<link href="css/billingStyleSheet.css" type="text/css" rel="Stylesheet" />

<head>
<title>PUNE SUPP. BILL REPRINT</title>
<script type="text/javascript"  language="javascript" src="javascript/billing.js"></script>

</head>
<div style="page-break-after:always;">

<table style="border:solid 1px black;margin-left:46px;margin-top:20px;  width:686px; "  cellspacing="0" cellpadding="0"    >
<tr>
<td style="width: 686px" valign ="top" >

<table  style="border-bottom:solid 1px black;vertical-align :top " width="686px" cellspacing="0" cellpadding="0" >
   <tr> <title>PUNE SUPP. BILL REPRINT</title><tr>
 <tr>
     <td  rowspan="2" valign ="middle"  align ="center" style="width:10px"><img src="Images/pune.jpg" height ="40px"/></td>
     <td  valign ="middle"  align ="center" style="font-family:Times New Roman ;font-size:20px;font-weight :bold " ><asp:Label CssClass="dateclasspuneheading" ID="lbcompanyname" runat ="server"></asp:Label></td>
     <td  valign ="middle"  align ="center" style="font-family:Verdana UI;font-size:20px;font-weight :bold" ><u><asp:Label  ID="lbbilltype" runat ="server" Text="INVOICE" Font-Names="Verdana"></asp:Label></u></td>
 </tr>
 
 <tr>
    <td valign ="middle"  align ="center" style="font-family:Arial ; border-bottom:solid 0px black;font-size:10px"><asp:Label ID="lbcompaddress" runat ="server"></asp:Label></td>
 </tr>
  <tr>
 <%--<td valign ="middle"  align ="center" style="font-family:Arial ; border-bottom:solid 0px black;font-size:10px"><asp:Label ID="Label20" runat ="server"></asp:Label></td>--%>
    <td valign ="middle"  align ="left" style="font-family:Arial ; border-bottom:solid 0px black;font-size:10px" colspan="3"><asp:Label ID="lbladdress" runat ="server"></asp:Label></td>
 </tr>
 </table>
 <table width="686px" cellspacing="0" cellpadding="0" style="border-bottom:solid 1px black">
 <tr>
 

 <td valign="top">
 <table width="483px" cellspacing="0" cellpadding="0" >
 <tr>
 <td align ="left" width="100px" valign ="top"   ><b> <asp:Label CssClass="agecnycodeclasspune" ID="agencytxt" runat ="server"></asp:Label></b></td>
 <td  align ="left" valign ="top" ><asp:Label CssClass="dateclasspune" ID="agddxt" runat ="server"></asp:Label></td>
 </tr>
 <tr>
 <td align ="left"  valign="top" ><b><asp:Label CssClass="agecnycodeclasspune" ID="lbclientadd" runat ="server"></asp:Label></b></td>
 <td colspan="3" align ="left" ><asp:Label CssClass="dateclasspune" ID="lbaddress" runat ="server"></asp:Label></td>
 </tr>
 <tr>
 <td align ="left" width="100px"   ><b><asp:Label CssClass="agecnycodeclasspune" ID="lbclientna" runat ="server"></asp:Label></b></td>
 <td colspan="3" align ="left" ><asp:Label CssClass="dateclasspune" ID="txtcliname" runat ="server"></asp:Label></td>
 </tr>
 <tr>
  <td align ="left" ><b><asp:Label CssClass="agecnycodeclasspune" ID="lbcap" runat ="server"></asp:Label></b></td>
 <td colspan="3" align ="left" ><asp:Label CssClass="dateclasspune" ID="lbcaption" runat ="server"></asp:Label></td>
</tr>
<tr>
<td align ="left" ><b><asp:Label CssClass="agecnycodeclasspune" ID="lblronon" runat ="server"></asp:Label></b></td>
<td colspan="2" align ="left" ><asp:Label CssClass="dateclasspune" ID="txtronon" runat ="server"></asp:Label></td>
</tr>
</table></td>


<td valign="top" >
<table width="200px" cellspacing="0" cellpadding="0">
<tr>
 <td valign ="top" align ="left"  ><b> <asp:Label CssClass="agecnycodeclasspune" ID="lbinvoiceno" runat ="server"></asp:Label></b></td>
 <td colspan="2" valign ="top" align ="left" ><asp:Label CssClass="dateclasspune" ID="txtinvoice" runat ="server"></asp:Label></td>
</tr>
<tr>
<td align ="left" ><b><asp:Label CssClass="agecnycodeclasspune" ID="lbdate" runat ="server"></asp:Label></b></td>
<td colspan="2" align ="left" ><asp:Label CssClass="dateclasspune" ID="runtxt" runat ="server"></asp:Label></td>
</tr>
<tr>
<td align="left"><b><asp:Label CssClass="agecnycodeclasspune" ID="lbddate" runat ="server"></asp:Label></b></td>
<td colspan="2" align="left"><asp:Label CssClass="dateclasspune" ID="ldduedate" runat ="server"></asp:Label></td>
</tr>
<tr>
<td align ="left" ><b><asp:Label CssClass="agecnycodeclasspune" ID="lbadtype" runat ="server"></asp:Label></b></td>
<td colspan="2" align ="left" ><asp:Label CssClass="dateclasspune" ID="adcat" runat ="server"></asp:Label></td>
</tr>
<tr>
<td align ="left" ><b><asp:Label CssClass="agecnycodeclasspune" ID="lbrodat" runat ="server"></asp:Label></b></td>
<td colspan="2" align ="left" ><asp:Label CssClass="dateclasspune" ID="lbronodate" runat ="server"></asp:Label></td>
</tr>
</table>
</td>
</tr>
</table>
<table width="686px" cellspacing="0" cellpadding="0" style="border-bottom:solid 1px black" >
<tr>
<td>
<table width ="483px" cellspacing="0" cellpadding="0"><tr>
<td align="left"  width ="100px" style="height: 14px"><b><asp:Label CssClass="agecnycodeclasspune" ID="lbpackagena" runat ="server"></asp:Label><b></td>
<td  style="height: 14px" align ="left"><asp:Label CssClass="insertiontxtclass" ID="txtpackname" runat ="server"></asp:Label></td>
</tr></table>
</td>
<td><table width ="200px" cellspacing="0" cellpadding="0"><tr>
<td style="height: 13px"><b><asp:Label CssClass="agecnycodeclasspune" ID="lbpackagerate" runat ="server"></asp:Label><b></td>
<td colspan="2" style="height: 13px"><asp:Label CssClass="dateclasspune" ID="lbpakgrate" runat ="server"></asp:Label></td>
</tr></table></td>
</tr></table>


<table width="686px"   cellspacing="0" cellpadding="0" style="border-bottom:solid 1px black" >
<tr>

<td valign ="top" style ="border-right:solid 1px black">
       <asp:Label  id="dynamictable"  runat ="server"   style="border-right:solid 1px black" ></asp:Label></td>
       <td id="Td1" runat="server" valign ="top"   >
              <table id="tbl_next_pg" runat="server" width="200"  style="vertical-align :bottom ;"   cellspacing="0" cellpadding="0"  > 
        <tr>
            <td  align="left"><b> <asp:Label CssClass="agecnycodeclasspune" ID="lbinsertionnumber" runat ="server"></asp:Label></b> </td>
            <td align="right"><asp:Label CssClass="dateclasspune" ID="insertiontxt" runat ="server"></asp:Label></td>
        </tr>
      
        <tr>
            <td align="left" style ="padding-bottom :5PX;" ><b> <asp:Label  ID="lblamount" runat ="server"  CssClass="agecnycodeclasspune"></asp:Label></b></td>
            <td align="right"><asp:Label   ID="amount1" runat ="server"  CssClass="dateclasspune"></asp:Label></td>
        </tr>
        <tr>
            <td  style ="padding-bottom :5PX;" align="left"><b><asp:Label CssClass="agecnycodeclasspune" ID="lbextpre" runat ="server"></asp:Label></b></td>
            <td align="right"><asp:Label CssClass="dateclasspune" ID="lbextrapre" runat ="server"></asp:Label></td>
        </tr>
        
        
        <tr >
            <td style ="padding-bottom :5PX;"    align="left"><b><asp:Label CssClass="agecnycodeclasspune" ID="lbgr" runat ="server"></asp:Label></b></td>
            <td align="right"><asp:Label CssClass="dateclasspune" ID="txtgr" runat ="server"></asp:Label></td>
        </tr>
            

        <tr>
            <td align="left" style ="padding-bottom :5PX;" ><b><asp:Label CssClass="agecnycodeclasspune" ID="lbtrade1" runat ="server"></asp:Label></b></td>
            <td align="right"><asp:Label CssClass="dateclasspune" ID="txtdiscal" runat ="server"></asp:Label></td>
        </tr>
                

        <tr>
            <td align="left" style ="padding-bottom :5PX;"><b><asp:Label CssClass="agecnycodeclasspune" ID="lbadtd" runat ="server"></asp:Label></b></td>
            <td align="right"><asp:Label CssClass="dateclasspune" ID="lbadtdtxt" runat ="server"></asp:Label></td>
        </tr>
               

        <tr style="border-bottom:solid 1px black">
            <td align="left" style="height: 19px"><b><asp:Label CssClass="agecnycodeclasspune" ID="lblnetpayable" runat ="server"></asp:Label></b></td>
            <td align="right" style="height: 19px"><asp:Label CssClass="dateclasspune" ID="netpay" runat ="server"></asp:Label></td>
        </tr>
           
<tr>
	 <td style="border-top:solid 1px black;  height:100px; vertical-align:bottom;" colspan="2" align="center">
       
         <div id="divimg" runat="server" style="overflow:auto; vertical-align:bottom;" ></div></td>
  </tr>
   
  
  
  
   </table>
<%--     </div>--%>
       </td>
 
      
  
  
  </tr>
  
  
  
  
<tr  ><td>
   
   <table cellspacing="0" cellpadding="0" style="border-right:solid 1px black" width="483px"><tr>

                 <td align="left" style="font-size:9px; border-right:solid 1px black" ><asp:Label ID="lbwordinrupees" runat="server" CssClass ="dateclasspune" ></asp:Label></td>
                 </tr>  </table>
                 
                 
                 
                 
                 </td>         
   <td style="border-top :solid 1px black; vertical-align:bottom; border-right:solid 1px black;border-left:solid 1px black;"   align="center" colspan="2" class="agecnycodeclasspune" > Advt.Manager/Accountant</td>
</tr>
  </table>
  
  <table width="686px" cellspacing="0" cellpadding="0" >
<tr  >


<td  colspan="3" style="font-size:10px;font-family :Arial; height: 54px;border-bottom :solid 1px black" >
<asp:Label ID="hidedata" runat ="server" ></asp:Label>



</td>



<%--<td   colspan="4" style="font-size:10px;font-family :Arial; height: 54px;border-bottom :solid 1px black" align ="left"><b>Terms & Condition : 1)</b>Payment Should be made in favour of <b><asp:Label CssClass="dateclasspune" ID="lbterms" runat ="server"></asp:Label>. 2)</b>Only official receipt
issued by us will binding on us.<b>3) </b>Objection or complaint regarding the bill (if any) should be brought to our notice within 15 days
from the presentation of the bill,falling which the bill become fully payable. <b>4)</b> All payment should be made according to the credit
limits to avoid interest,which will be levied @24% per annum.<b>5)</b>All disputes are subjected to <b><asp:Label CssClass="dateclasspune" ID="lbnaam" runat ="server"></asp:Label></b> Jurisdiction only.</td>--%>

</tr>

</table>



  <table  width="685px" cellspacing="0" cellpadding="0" style="border:solid 1px black;"><tr>
<td colspan="5">
<table  width="685px" cellspacing="0" cellpadding="0">
<tr>
<td   valign ="bottom" style="height: 19px" >
 <asp:Label  ID="Label19" runat="server"  ><b> </b></asp:Label>
<b><asp:Label  class="agecnycodeclasspune" ID="lbemail" runat ="server"></asp:Label></b>
<asp:Label  ID="Label13" runat="server"  CssClass="BORDEREMAIL1"><b> </b></asp:Label>
<asp:Label CssClass="BORDEREMAIL" ID="lbemailtxt" runat ="server"></asp:Label>
 <asp:Label  ID="Label4" runat="server"  ><b> </b></asp:Label>
 <asp:Label  ID="Label5" runat="server"  ><b> </b></asp:Label>
 <asp:Label  ID="Label12" runat="server"  ><b> </b></asp:Label>
 <asp:Label CssClass="BORDEREMAIL1"  ID="EOU" runat ="server"><b>E.O&.E</b></asp:Label>
 <asp:Label  ID="Label6" runat="server"  ><b> </b></asp:Label>
 <asp:Label  ID="Label2" runat="server"  ><b> </b></asp:Label>
 <asp:Label  ID="Label7" runat="server"  ><b> </b></asp:Label>
 <asp:Label  ID="Label14" runat="server"  ><b> </b></asp:Label>
<asp:Label  ID="lbltan" runat="server"  CssClass="BORDEREMAIL1"><b>*Tan No: </b> <b> </b> MUMS40215A *</asp:Label>
<asp:Label  ID="Label8" runat="server"  ><b> </b></asp:Label>
<asp:Label  ID="Label1" runat="server"  ><b> </b></asp:Label>
<asp:Label  ID="Label15" runat="server"  ><b> </b></asp:Label>
<asp:Label  ID="Label16" runat="server"  ><b> </b></asp:Label>
<asp:Label align="right" ID="lblserv" runat="server"  CssClass="BORDEREMAIL1"><b> Service Tax No: </b>  <b> </b> AALFS7192JST001*</asp:Label>
<asp:Label  ID="Label9" runat="server"  ><b> </b></asp:Label>
<asp:Label  ID="Label10" runat="server"  ><b> </b></asp:Label>
<asp:Label  ID="Label17" runat="server"  ><b> </b></asp:Label>
<asp:Label  ID="Label3" runat="server"  ><b> </b></asp:Label>
<b><asp:Label align="right" ID="lbpune" runat ="server" class="agecnycodeclasspune"></asp:Label></b>
<asp:Label  ID="Label18" runat="server"  CssClass="BORDEREMAIL1"><b> </b></asp:Label>
<asp:Label  ID="Label11" runat="server"  ><b> </b></asp:Label>
<asp:Label align="right" CssClass="dateclasspune" ID="lbpunetxt" runat ="server"></asp:Label></td>

</tr>
</table>
</td></tr></table>
 
    


</td>
</tr>
</table>
</div>