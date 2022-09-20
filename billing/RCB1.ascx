<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RCB1.ascx.cs" Inherits="RCB1" %>

<link href="css/billingStyleSheet.css" type="text/css" rel="Stylesheet" />

<head>
<title>PUNE BILL REPRINT</title>
<script type="text/javascript"  language="javascript" src="javascript/billing.js"></script>

    <style type="text/css">
        .style3
        {
            width: 535px;
        }
        .style4
        {
            width: 340px;
            height: 18px;
        }
        .style5
        {
            width: 61px;
        }
        .style6
        {
            height: 13px;
        }
        .style7
        {
            width: 535px;
            height: 13px;
        }
        .style9
        {
            width: 535px;
            height: 18px;
        }
    </style>

</head>
<p style="page-break-after:always">
<table style="border:solid 1px black;margin-left:46px;margin-top:20px " cellspacing="0" cellpadding="0"  width="686px"    >
<tr>
<td style="width: 686px" valign ="top" >
<div>
<table>
<tr >

<td class="style5">
         <table style="vertical-align :top;" 
        cellspacing="0" cellpadding="0">
        <tr>
        <td>
<img alt="Images/mcmlogo1.gif" src ="Images/4cplus.jpg"
        style="height: 66px; width: 90px"/>
        </td>
        </tr>
        </table>
</td>
<td>
<table  style="border-bottom:solid 1px black;vertical-align :top; width: 595px;" 
        cellspacing="0" cellpadding="0" >
 <tr>

    <%-- <td  valign ="middle"  align ="center" class="style2"><img alt="Images/mcmlogo1.gif" src = "Images/mcmlogo1.jpg" height ="40px"/></td>--%>
   <%--  <td rowspan="2" valign ="middle"  align ="center" style="width:10px"><img src="Images/pune.jpg" height ="40px"/></td>--%>
     <td  valign ="middle"  align ="center" 
         style="font-family:Times New Roman ;font-size:15px;font-weight :bold" 
         class="style9"><asp:Label CssClass="dateclasspuneheading" ID="lbcompanyname" runat ="server"></asp:Label></td>
     <td  valign ="middle"  align ="center" 
         style="font-family:Verdana UI;font-size:15px;font-weight :bold" class="style4" ><u><asp:Label  ID="lbbilltype" runat ="server" Text="TAX INVOICE" Font-Names="Verdana"></asp:Label></u></td>
 </tr>
 
 <tr>
    <td valign ="middle"  align ="center" 
         style="font-family:Arial ; border-bottom:solid 0px black;font-size:10px" 
         class="style7"><asp:Label ID="lbcompaddress" runat ="server"></asp:Label></td>
         
    <td  valign ="middle"  align ="center" 
         style="font-family:Verdana UI;font-size:10px;" class="style4" ><asp:Label  ID="lblbilltyp" runat ="server" Font-Names="Verdana"></asp:Label></td>
    
 </tr>
 <tr>
 <td valign ="middle"  align ="center" 
         style="font-family:Arial ; border-bottom:solid 0px black;font-size:10px" 
         class="style3"><asp:Label ID="Label2" runat ="server" text="Phone 5135000,5135011"></asp:Label></td>
         
         <td valign ="middle"  align ="center" 
         style="font-family:Arial ; border-bottom:solid 0px black;font-size:10px" 
         class="style8"><asp:Label ID="Label4" runat ="server" Text="VAT:-300047105" ></asp:Label></td>

 </tr>
 <tr>
 <td valign ="middle"  align ="center" 
         style="font-family:Arial ; border-bottom:solid 0px black;font-size:10px" 
         class="style3"><asp:Label ID="Label3" runat ="server" text="Fax: 977-1-5135001 Email:finance@kantipur.com.np"></asp:Label></td>
 </tr>
 </table>
 </td>
 </tr>
 </table>
 </div>
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
  <td align ="left" ><b><asp:Label CssClass="agecnycodeclasspune" ID="Label5" runat ="server" text="Premium:"></asp:Label></b></td>
 <td colspan="3" align ="left" ><asp:Label CssClass="dateclasspune" ID="lblpageprem" runat ="server"></asp:Label></td>
</tr>
</table></td>


<td valign="top" >
<table cellspacing="0" cellpadding="0" style="width: 210px">
<tr>
 <td valign ="top" align ="left"  ><b> <asp:Label CssClass="agecnycodeclasspune" ID="lbinvoiceno" runat ="server"></asp:Label></b></td>
 <td colspan="2" valign ="top" align ="left" ><asp:Label CssClass="dateclasspune" ID="txtinvoice" runat ="server"></asp:Label></td>
</tr>
<tr>
 <td valign ="top" align ="left"  ><b> <asp:Label CssClass="agecnycodeclasspune" ID="Label8" runat ="server" Text="Id. No."></asp:Label></b></td>
 <td colspan="2" valign ="top" align ="left" ><asp:Label CssClass="dateclasspune" ID="lblciono" runat ="server"></asp:Label></td>
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
<td style="height: 33px" >
<table width ="483px" cellspacing="0" cellpadding="0"><tr>
<td align="left"  width ="100px" style="height: 14px"><b><asp:Label CssClass="agecnycodeclasspune" ID="lbpackagena" runat ="server"></asp:Label><b></td>
<td  style="height: 14px" align ="left"><asp:Label CssClass="insertiontxtclass" ID="txtpackname" runat ="server"></asp:Label></td>
</tr></table>
</td>
<td style="height: 33px" >
    <table cellspacing="0" cellpadding="0" 
        style="width: 211px; height: 13px;"><tr>
<td style="height: 13px"><b><asp:Label CssClass="agecnycodeclasspune" ID="lbpackagerate" runat ="server"></asp:Label><b></td>
<td colspan="2" style="height: 13px"><asp:Label CssClass="dateclasspune" ID="lbpakgrate" runat ="server"></asp:Label></td>
</tr></table></td>
</tr></table>


<table width="686px"   cellspacing="0" cellpadding="0" style="border-bottom:solid 1px black" >
<tr>

<td valign ="top" style ="height :100px;border-right:solid 1px black"   >
       <asp:Label  id="dynamictable"  runat ="server"   style="border-right:solid 1px black" ></asp:Label>
      
       
                                 
                
     
       </td>
       <td id="fnd_next_pg" runat="server" valign ="bottom"   >
              <table id="tbl_next_pg" runat="server"  
                  style="vertical-align :bottom; width: 209px;"   cellspacing="0" 
                  cellpadding="0"  > 
        <tr>
            <td  align="left" class="style6"><b> <asp:Label CssClass="agecnycodeclasspune" ID="lbinsertionnumber" runat ="server"></asp:Label></b> </td>
            <td align="right" class="style6"><asp:Label CssClass="dateclasspune" ID="insertiontxt" runat ="server"></asp:Label></td>
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
            <td align="left" style ="padding-bottom :5PX;"><b><asp:Label CssClass="agecnycodeclasspune" ID="lbadtd" runat ="server"></asp:Label></b></td>
            <td align="right"><asp:Label CssClass="dateclasspune" ID="lbadtdtxt" runat ="server"></asp:Label></td>
        </tr>
        <%--new add--%>
         <tr>
            <td align="left" style ="padding-bottom :5PX;"><b><asp:Label CssClass="agecnycodeclasspune" ID="lblfreqnc" runat ="server"></asp:Label></b></td>
            <td align="right"><asp:Label CssClass="dateclasspune" ID="txtfrequenc" runat ="server"></asp:Label></td>
        </tr>
         <tr>
            <td align="left" style ="padding-bottom :5PX;"><b><asp:Label CssClass="agecnycodeclasspune" ID="lblcashdisc" runat ="server"></asp:Label></b></td>
            <td align="right"><asp:Label CssClass="dateclasspune" ID="txtcashdisc" runat ="server"></asp:Label></td>
        </tr> 
        <tr>
            <td align="left" style ="padding-bottom :5PX;"><b><asp:Label CssClass="agecnycodeclasspune" ID="lblcashtyp" runat ="server"></asp:Label></b></td>
            <td align="right"><asp:Label CssClass="dateclasspune" ID="txtcashtype" runat ="server"></asp:Label></td>
        </tr> 
        
         <tr>
            <td align="left" style ="padding-bottom :5PX;"><b><asp:Label CssClass="agecnycodeclasspune" ID="lblclient" runat ="server"></asp:Label></b></td>
            <td align="right"><asp:Label CssClass="dateclasspune" ID="txtclientc" runat ="server"></asp:Label></td>
        </tr> 
        
         
        
         <tr>
            <td align="left" style ="padding-bottom :5PX;"><b><asp:Label CssClass="agecnycodeclasspune" ID="lblcatedis" runat ="server"></asp:Label></b></td>
            <td align="right"><asp:Label CssClass="dateclasspune" ID="txtcatedisc" runat ="server"></asp:Label></td>
        </tr> 
             
        
          <tr >
            <td align="left" style ="padding-bottom :5PX;border-bottom:solid 1px black;" ><b><asp:Label CssClass="agecnycodeclasspune" ID="lbtrade1" runat ="server"></asp:Label></b></td>
            <td align="right" style="border-bottom:solid 1px black;"><asp:Label CssClass="dateclasspune" ID="txtdiscal" runat ="server"></asp:Label></td>
        </tr>
        
                   
        
          <tr>
            <td align="left" style ="padding-bottom :5PX;" ><b><asp:Label CssClass="agecnycodeclasspune" ID="Label1" runat ="server" Text = "Sales Amount"></asp:Label></b></td>
            <td align="right"><asp:Label CssClass="dateclasspune" ID="Lblsalesamt" runat ="server"></asp:Label></td>
        </tr>
               
        
         <tr>
            <td align="left" style ="padding-bottom :5PX;"><b><asp:Label CssClass="agecnycodeclasspune" ID="lblvatamt" runat ="server"></asp:Label></b></td>
            <td align="right"><asp:Label CssClass="dateclasspune" ID="txtvatamt" runat ="server"></asp:Label></td>
        </tr> 
<%--end here--%>
        <tr style="border-bottom:solid 1px black">
            <td align="left" style="height: 13px"><b><asp:Label CssClass="agecnycodeclasspune" ID="lblnetpayable" runat ="server"></asp:Label></b></td>
            <td align="right" style="height: 13px"><asp:Label CssClass="dateclasspune" ID="netpay" runat ="server"></asp:Label></td>
        </tr>
           
<tr>
	 <td style="border-top:solid 1px black;  height:100px;" colspan="2" align="center" valign="bottom">
        <%--</td></tr>
        <tr>
        <td valign ="middle" id="tdimg" align ="center" style="width:10px" colspan="2" runat="server">--%>
        <%--<img src="Images/signature.jpg" height ="80px"/>--%><div id="divimg" runat="server" style="overflow:auto;"></div></td>
  </tr>
  <tr valign="bottom" >
 <td style="display:none; border-top :solid 1px black; padding-top :1PX;" valign="middle" align="center" colspan="2" class="agecnycodeclasspune" > Advt.Manager/Accountant</td>
  </tr> 
  
  
  
   </table>
<%--     </div>--%>
       </td>
 
      
  
  
  </tr>
  
  
  
  
<tr><td>
   
   <table cellspacing="0" cellpadding="0" style="border-right:solid 1px black" width="486px"><tr>

                 <td align="left" style="font-size:9px;" ><b><asp:Label ID="lbwordinrupees" runat="server" CssClass ="dateclasspune" ></asp:Label></b></td>
                 </tr>  </table>
                 
                 
                 
                 
                 </td>         
  <td > </td></tr>
  </table>
  
<table width="686px" cellspacing="0" cellpadding="0" >

<tr style="height: 54px;">
<td style="text-align:Left";>
<asp:Label  ID="Label6" runat="server"  CssClass="BORDEREMAIL" style="text-align:Left";><b> Prepared By</b></asp:Label>
</td>
<td style="text-align:center";>
<asp:Label  ID="Label7" runat="server"  CssClass="BORDEREMAIL" style="text-align:center";><b>Checked By</b></asp:Label>
</td>
<td style="text-align:right";>
<asp:Label  ID="Label9" runat="server"  CssClass="BORDEREMAIL" style="text-align:right";><b>Account Officer </b></asp:Label>
</td>
</tr>
</table>

  <table  width="685px" cellspacing="0" cellpadding="0"><tr>
<td colspan="5">

<table width="685px" cellspacing="0" cellpadding="0" >
<tr >
<td colspan="3" >
    <div style="width: 600px; font-size:15px;" 
        runat="server" id="lblmatter"></div>
    </td>

</tr>

</table>
<table  width="685px" cellspacing="0" cellpadding="0">
<%--<tr>
<td   valign ="bottom" style="height: 19px" >
 <asp:Label  ID="Label19" runat="server"  CssClass="BORDEREMAIL"><b> </b></asp:Label>
<b><asp:Label  class="agecnycodeclasspune" ID="lbemail" runat ="server"></asp:Label></b>
<asp:Label  ID="Label13" runat="server"  CssClass="BORDEREMAIL"><b> </b></asp:Label>
<asp:Label CssClass="BORDEREMAIL" ID="lbemailtxt" runat ="server"></asp:Label>
 <asp:Label  ID="Label4" runat="server"  CssClass="BORDEREMAIL"><b> </b></asp:Label>
 <asp:Label  ID="Label5" runat="server"  CssClass="BORDEREMAIL"><b> </b></asp:Label>
 <asp:Label  ID="Label12" runat="server"  CssClass="BORDEREMAIL"><b> </b></asp:Label>
 <asp:Label CssClass="BORDEREMAIL"  ID="EOU" runat ="server"><b> E.O&.E </b></asp:Label>
 <asp:Label  ID="Label6" runat="server"  CssClass="BORDEREMAIL"><b> </b></asp:Label>
 <asp:Label  ID="Label2" runat="server"  CssClass="BORDEREMAIL"><b> </b></asp:Label>
 <asp:Label  ID="Label7" runat="server"  CssClass="BORDEREMAIL"><b> </b></asp:Label>
 <asp:Label  ID="Label14" runat="server"  CssClass="BORDEREMAIL"><b> </b></asp:Label>
<asp:Label  ID="lbltan" runat="server"  CssClass="BORDEREMAIL"><b> Tan No: </b> <b> </b> MUMS40215A </asp:Label>
<asp:Label  ID="Label8" runat="server"  CssClass="BORDEREMAIL"><b> </b></asp:Label>
<asp:Label  ID="Label1" runat="server"  CssClass="BORDEREMAIL"><b> </b></asp:Label>
<asp:Label  ID="Label15" runat="server"  CssClass="BORDEREMAIL"><b> </b></asp:Label>
<asp:Label  ID="Label16" runat="server"  CssClass="BORDEREMAIL"><b> </b></asp:Label>
<asp:Label align="right" ID="lblserv" runat="server"  CssClass="BORDEREMAIL"><b> Service Tax No: </b>  <b> </b> AALFS7192JST001 </asp:Label>
<asp:Label  ID="Label9" runat="server"  CssClass="BORDEREMAIL"><b> </b></asp:Label>
<asp:Label  ID="Label10" runat="server"  CssClass="BORDEREMAIL"><b> </b></asp:Label>
<asp:Label  ID="Label17" runat="server"  CssClass="BORDEREMAIL"><b> </b></asp:Label>
<asp:Label  ID="Label3" runat="server"  CssClass="BORDEREMAIL"><b> </b></asp:Label>
<b><asp:Label align="right" ID="lbpune" runat ="server" class="agecnycodeclasspune"></asp:Label></b>
<asp:Label  ID="Label18" runat="server"  CssClass="BORDEREMAIL"><b> </b></asp:Label>
<asp:Label  ID="Label11" runat="server"  CssClass="BORDEREMAIL"><b> </b></asp:Label>
<asp:Label align="right" CssClass="dateclasspune" ID="lbpunetxt" runat ="server"></asp:Label></td>

</tr>--%>
<tr  >


<td  colspan="3" style="font-size:10px;font-family :Arial;" >
<b><asp:Label ID="hidedata" runat ="server" ></asp:Label></b>



</td>



<%--<td   colspan="4" style="font-size:10px;font-family :Arial; height: 54px;border-bottom :solid 1px black" align ="left"><b>Terms & Condition : 1)</b>Payment Should be made in favour of <b><asp:Label CssClass="dateclasspune" ID="lbterms" runat ="server"></asp:Label>. 2)</b>Only official receipt
issued by us will binding on us.<b>3) </b>Objection or complaint regarding the bill (if any) should be brought to our notice within 15 days
from the presentation of the bill,falling which the bill become fully payable. <b>4)</b> All payment should be made according to the credit
limits to avoid interest,which will be levied @24% per annum.<b>5)</b>All disputes are subjected to <b><asp:Label CssClass="dateclasspune" ID="lbnaam" runat ="server"></asp:Label></b> Jurisdiction only.</td>--%>

</tr>



</table>
</td></tr></table>
 
    


</td>
</tr>
</table></p>