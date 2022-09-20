<%@ Control Language="C#" AutoEventWireup="true" CodeFile="vigilant_media.ascx.cs" Inherits="vigilant_media" %>


<link href="css/billingStyleSheet.css" type="text/css" rel="Stylesheet" />

<head>
<title>PUNE FINAL BILL</title>

    <style type="text/css">
        .style1
        {
            width: 209px;
        }
        .style2
        {
            font-family : Verdana;
            color: Black;
            font-size : 10PX;
            width: 109px;
        }
        .style3
        {
            width: 499px;
        }
        .style4
        {
            width: 509px;
        }
        .style5
        {
            width: 184px;
        }
        .style6
        {
            height: 13px;
            width: 87px;
        }
        .style7
        {
            height: 11px;
        }
    </style>

</head>

<table style="border:solid 0px black;height:530; width: 750px;" cellspacing="0" 
    cellpadding="0" align="center">
 <tr><td><table cellpadding="0" cellspacing="0"  style="border:solid 1px black;vertical-align:top; width: 750px;">
<tr><td>



<table    width="750px" height="60px;" cellspacing="0" cellpadding="0"  >
<tr>
     <%--<td  valign ="middle"  align ="center" 
         style="font-family:Times New Roman ;font-size:20px;font-weight :bold " 
         class="style1" >DAILY POST</td>
     <td  valign ="middle"  align ="center" style="font-family:Verdana UI;font-size:20px;font-weight :bold" ><u><asp:Label CssClass="dateclasspuneheading" ID="lbbilltype" runat ="server" Text="INVOICE"></asp:Label></u></td>--%>
     <td   valign ="middle"  align ="center" style="width:750px"><img src="Images/header_bill.jpg" height ="40px"/></td>
     <%--<td  valign ="middle"  align ="center" style="font-family:Times New Roman ;font-size:20px;font-weight :bold " ><asp:Label CssClass="dateclasspuneheading" ID="lbcompanyname" runat ="server"></asp:Label></td>--%>
 </tr>
 <%--
 <tr>
 <td colspan="3"></td>
    <td valign ="middle"  align ="center" style="border-bottom:solid 0px black;font-size:13px"><asp:Label ID="lbcompaddress" runat ="server"></asp:Label></td>
 </tr>--%>
 </table></td></tr>
 <tr><td>
 <table cellspacing="0" cellpadding="0" style="vertical-align:top; width: 762px;">
 <tr>
 <td style="border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000;width:280px; border-top-style: solid; border-top-width: 1px; border-top-color: #000000;">
 <table cellspacing="0" cellpadding="0" style="width: 280px">
 <tr>
 <td style="font-family: verdana; font-size: 10px; font-weight: bold;padding-left:10px;" 
         class="style7" >To</td>
 </tr>
 <tr>
 
 <td align ="left" style="height: 13px;padding-left:10px;" ><asp:Label CssClass="dateclasspune" ID="agencytxt" runat ="server"></asp:Label></td>
 </tr>
 <tr>
 <td align ="left"  style="height: 13px;padding-left:10px;"><asp:Label CssClass="dateclasspune" ID="lbclientadd" runat ="server"></asp:Label></td>

 </tr>
 <tr><td  colspan="3">&nbsp;</td></tr>

 
</table></td>
<td valign="top" 
         
                                        style="border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000; border-top-style: solid; border-top-width: 1px; border-top-color: #000000;" 
                                        class="style5">
<table width="218px" cellspacing="0" cellpadding="0">


<tr>

 <td valign ="top" align ="left" style="height: 13px;padding-left:10px;"><asp:Label CssClass="agecnycodeclasspune" ID="lbinvoiceno" runat ="server" Text="Bill Number:"></asp:Label></td>
 <td colspan="2" valign ="top"  style="height: 13px" align="left"><asp:Label CssClass="dateclasspune" ID="txtinvoice"  runat ="server" ></asp:Label></td>
</tr>
<tr>

<td align ="left" style="height: 13px;padding-left:10px;"><asp:Label CssClass="agecnycodeclasspune" ID="lbdate" runat ="server" Text="Bill Date:"></asp:Label></td>
<td colspan="2"  align="left" ><asp:Label CssClass="dateclasspune" ID="runtxt" runat ="server"></asp:Label></td>
</tr>
<tr>
<td align="left" style="height: 13px;padding-left:10px;"><asp:Label CssClass="agecnycodeclasspune" ID="lbddate" runat ="server" Text="Booking ID:"></asp:Label></td>
<td colspan="2"  align="left"><asp:Label CssClass="dateclasspune" ID="lb_booking_id" runat ="server"></asp:Label></td>
</tr>
<tr>
<td align="left" style="height: 13px;padding-left:10px;"><asp:Label CssClass="agecnycodeclasspune" ID="Label3" runat ="server" Text="Scheme Type:"></asp:Label></td>
<td colspan="2"  align="left"><asp:Label CssClass="dateclasspune" ID="lblschemetype" runat ="server"></asp:Label></td>
</tr>

</table>
</td>

<td valign="top" 
                                        style="border-bottom-style: solid;border-bottom-width: 1px; border-bottom-color: #000000; border-top-style: solid; border-top-width: 1px; border-top-color: #000000;">

<table  cellspacing="0" cellpadding="0" 
        style="width: 260px; height: 56px; margin-right: 0px;">

<tr>
 <td align ="left" style="padding-left:10px;" class="style6" ><asp:Label CssClass="agecnycodeclasspune" ID="lbclientna" runat ="server" Text="ClientName:"></asp:Label></td>
 <td colspan="3" align ="left" ><asp:Label CssClass="dateclasspune" ID="txtcliname" runat ="server"></asp:Label></td>
 </tr>

<tr>

<td align ="left" style="padding-left:10px;" class="style6" ><asp:Label CssClass="agecnycodeclasspune" ID="lbrodat" runat ="server" Text="RO&Date:"></asp:Label></td>
<td colspan="2" align ="left" ><asp:Label CssClass="dateclasspune" ID="lbronodate" runat ="server"></asp:Label></td>
</tr>

 
 <tr>
<td align ="left"  style="padding-left:10px;" class="style6" ><asp:Label CssClass="agecnycodeclasspune" ID="lbadtype" runat ="server" Text="Ad Type :" ></asp:Label></td>
<td colspan="2" align ="left" style="height: 15px" ><asp:Label CssClass="dateclasspune" ID="adcat" runat ="server"></asp:Label></td>


</tr>

 <tr>
<td align ="left" style="padding-left:10px;" class="style6" ><asp:Label CssClass="agecnycodeclasspune" ID="Label1" runat ="server" Text="Box No :"></asp:Label></td>
<td colspan="2" align ="left" style="height: 15px" ><asp:Label CssClass="dateclasspune" ID="Label2" runat ="server"></asp:Label></td>


</tr>



</table>


</td>
</tr>
</table>


<table width="750px" height="192px;" cellspacing="0" cellpadding="0" style="border-bottom:solid 0px black" ><tr>
       <td valign="top" style="border-right:solid 0px black">
       <table cellspacing="0" cellpadding="0"><tr><td style="height: 37px">
        <table cellspacing="0" cellpadding="0"  width="750px"   class="table1" >
            <tr><td  width="750px" valign="top" align="left"  id="tabledy" runat ="server" style="height: 18px">
               <asp:Label ID="dynamictable" runat="server" CssClass ="dateclasspune" ></asp:Label>                       
                 </td></tr>
                 
                 </table>
                 
                </td></tr>
        </table>
       </td>
 
   
  </tr>

  </table>
    
    
    <table cellpadding="0" cellspacing="0" 
                                
                                style="border-top: 1px solid #000000; border-bottom: 1px solid #000000; width: 762px; ">
    <tr>
    <td class="style4">
<table cellspacing="0" cellpadding="0" border="0" style="width: 509px" >

   <tr ><td><table cellspacing="0" cellpadding="0" style="width: 510px" ><tr>
                 <td align="left" 
                     style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000;padding-left:10px;"><asp:Label ID="lbinwords" runat="server" CssClass ="agecnycodeclasspune" Text="Amount (in words):"></asp:Label></td>
                 <td align="left" 
                     style="font-size:9px; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000;" ><asp:Label ID="lbwordinrupees" runat="server" CssClass ="dateclasspune" ></asp:Label></td>
                 </tr>  </table>
                 </td>         
  </tr>





<tr >
<td style="padding-left:10px; font-family: verdana; font-size: 11px; font-weight: bold;"><b>*TERMS & CONDITION</b></td>

</tr>
<tr >
<td style="padding-left:10px; font-family: verdana; font-size: 9px;" >•While making payment please quote bill no & date and pay by crossed cheques /Demand Drafts</td>

</tr>

<tr>
<td  style="padding-left:10px; font-family: verdana; font-size: 9px;" >payable at <b>CHANDIGARH</b> in favour of <b>VIGILANT MEDIA PVT.LTD.</b></td>

</tr>
<tr>
<td style="padding-left:10px; font-family: verdana; font-size: 9px;" >•Accredited Agencies:Payment should be made as per INS Rules.</td>

</tr>



<tr>
<td style="padding-left:10px; font-family: verdana; font-size: 9px;" >•Interest @24% per annum is liable to be charged on bills not paid with in the stipulated period</td>

</tr>

<tr>
<td style="padding-left:10px; font-family: verdana; font-size: 9px;" >•All Claims are subject to the jurisdiction of Chandigarh Court</td>
</tr>
<tr>
<td style="padding-left:10px; font-family: verdana; font-size: 9px;" >ADVERTISEMENT CUTTING /VOUCHER TEAR SHEET ENCLOSED</td>
</tr>

</table>
<table>
<tr>
<td style="padding-left:10px; font-family: verdana; font-size: 9px;" ><b>Bill Remark:</b></td>
<td style="padding-left:10px; font-family: verdana; font-size: 9px;" ><asp:Label CssClass="dateclasspune" ID="lblremark" runat ="server">ADVERTISEMENT CUTTING /VOUCHER TEAR SHEET ENCLOSED</asp:Label></td>
</tr>
</table>
</td>
<td width="200px" valign="top"  >
<table cellspacing="0" cellpadding="0" 
        
        
        style="border-left: 1px solid #000000; border-bottom: 1px solid #000000; width: 250px; margin-top: 0px;"  >
<tr><td style="border-right-style: solid; border-right-width: 1px; border-right-color: #000000; padding-right:10px;font-size:11px; font-family: verdana;" 
        class="style2" align="right"><b>GROSS AMOUNT</b></td><td class="dateclasspune" align="right" ><asp:Label ID="lbl_gross" runat="server"></asp:Label></td></tr>
<tr><td style="border-right-style: solid; border-right-width: 1px; border-right-color: #000000;padding-right:10px;" 
        class="style2" align="right"><b>Trade Discount</b></td><td class="dateclasspune"  align="right"><asp:Label ID="lbl_trade" runat="server"></asp:Label></td></tr>
<tr><td style="border-right-style: solid; border-right-width: 1px; border-right-color: #000000;padding-right:10px;" 
        class="style2" align="right"><b>Addl. Ag Com.</b></td ><td class="dateclasspune"  align="right"><asp:Label ID="lbl_add" runat="server"></asp:Label></td></tr>
<tr><td style="border-right-style: solid; border-right-width: 1px; border-right-color: #000000;padding-right:10px;" 
        class="style2" align="right"><b>Extra Discount</b></td><td class="dateclasspune"  align="right"><asp:Label ID="lbl_extra" runat="server"></asp:Label></td></tr>
<tr><td style="border-right-style: solid; border-right-width: 1px; border-right-color: #000000;padding-right:10px;" 
        class="style2" align="right"><b>Box Charges</b></td><td class="dateclasspune"  align="right"><asp:Label ID="lbl_box" runat="server"></asp:Label></td></tr>
<tr><td style="border-right-style: solid; border-right-width: 1px; border-right-color: #000000;padding-right:10px; font-family: Verdana; font-size: 11px; color: #000000; font-weight: bold;" 
        class="style2" align="right"><B>
    NET PAYABLE</B></td><td class="dateclasspune"  align="right"><asp:Label ID="lbl_net" runat="server"></asp:Label></td></tr>
</table>
</td>
</tr>
</table>

<table cellspacing="0" cellpadding="0" align="left" style="width: 762px" >
<tr>
<td class="style3"></td>
<td width="200px" style="height:13px; text-decoration: underline;" ><b>Authorised Signature</b></td>
</tr>
<tr align="center">
<td 
        
        style="background-color: #2C2C2C; font-family: 'Times New Roman', Times, serif; color: #FFFFFF" 
        class="style3" ><B>THANK YOU FOR ADVERTISING WITH US </B></td>

<td  class="dateclasspune"  width="200px" style="height:13px;" >*Subject to Encashment of Cheque.</td>

</tr>

</table>

</td>
</tr></table>
</td></tr></table>
<table>
<tr>
<td height="30px;"></td>
</tr>
</table>


