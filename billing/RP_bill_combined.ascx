<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RP_bill_combined.ascx.cs" Inherits="RP_bill_combined" %>


<link href="css/billingStyleSheet.css" type="text/css" rel="Stylesheet" />

<head>
<title>Rajasthan Patrika</title>

    <style type="text/css">
        .style2
        {
            font-family : Verdana;
            color: Black;
            font-size : 10PX;
            width: 129px;
        }
        .style3
        {
            width: 732px;
        }
        .style4
        {
            width: 609px;
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
        .style8
        {
            font-family : Verdana;
            color: Black;
            font-size : 10PX;
            width: 109px;
            height: 12px;
        }
        .style9
        {
            font-family : Verdana;
            color: Black;
            font-size : 10PX;
            height: 12px;
        }
        .style10
        {
            width: 100%;
        }
        .style11
        {
            font-family : Verdana;
            color: Black;
            font-size : 10PX;
            width: 20px;
        }
        .style12
        {
            width: 290px;
        }
        .style13
        {
            height: 37px;
            width: 751px;
        }
        .style14
        {
            width: 313px;
        }
        .style15
        {
            height: 18px;
            width: 829px;
        }
    </style>

</head>
<table cellpadding="0" cellspacing="0" width: 897px; margin-right: 0px;">
<tr style="height:40px"><td>
</td></tr></table>
<p style="page-break-after:always;">
 <table cellpadding="0" cellspacing="0"  
    style="border:solid 1px black;vertical-align:top; width: 897px; margin-right: 0px;">
<tr><td>



<table    width="900px" height="60px;" cellspacing="0" cellpadding="0"  >
<tr>
         <td style="font-family: 'Arial Black'; font-size: 13px; font-weight: normal;" 
         valign="bottom" class="style12">Branch :<asp:Label 
                                            CssClass="agecnycodeclasspune" ID="lblbrnch" runat ="server"></asp:Label></td>
         <td   valign ="middle" id="divimg" runat="server" align ="center" 
             class="style14"></td><%--<img src="Images/RPLMast.jpg" height ="40px"/>--%>
     <td  valign ="middle"  align ="right" style="font-family:Verdana UI;font-size:20px;font-weight :bold;padding-right:20px" ><u><asp:Label CssClass="dateclasspuneheading" ID="orgdup" runat ="server"></asp:Label></u></td>
    </tr>
<tr>
<td class="style12"><asp:Label CssClass="agecnycodeclasspune" ID="pubadd" runat ="server"></asp:Label></td>
<td align="center" 
        
        style="padding-right:40px;font-family: verdana; font-size: 12px; font-weight: bold; font-style: normal" 
        class="style14">
        rajasthan patrika pvt. ltd.</td>
<td></td>
</tr>
<tr>
<td class="style12"><asp:Label CssClass="agecnycodeclasspune" ID="pubtel" runat ="server"></asp:Label></td>
<td align="center" 
        
        style="padding-right:40px;font-family: verdana; font-size: 10px; font-weight: normal" 
        class="style14">
    Regd. Office :Kesargarh, J.L.N Marg, Jaipur</td>
<td></td>
</tr>
<tr>
<td class="style12"><asp:Label CssClass="agecnycodeclasspune" ID="pubfax" runat ="server"></asp:Label></td>
<td align="center" 
        
        style="padding-right:40px;font-family: verdana; font-size: 10px; font-weight: normal" 
        class="style14">internet 
    edition : www.patrika.com</td>
<td></td>
</tr>
<tr>
<td class="style12"><asp:Label CssClass="agecnycodeclasspune" ID="pubpan" runat ="server"></asp:Label></td>
<td align="center" class="style14" ><asp:Label CssClass="dateclasspune" ID="lblmailid" runat ="server"></asp:Label></td>
<td></td>
</tr>
 </table></td></tr>
 <tr><td>
 <table cellspacing="0" cellpadding="0" style="vertical-align:top; width: 899px;">
 <tr>
 <td style="border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000;width:280px; border-top-style: solid; border-top-width: 1px; border-top-color: #000000;">
 <table cellspacing="0" cellpadding="0" style="width: 330px">
 <tr>
 <td style="font-family: verdana; font-size: 10px; font-weight: bold;padding-left:10px;" 
         class="style7" >To</td>
 </tr>
 <tr>
 
 <td align ="left" style="height: 13px;padding-left:10px;" ><asp:Label CssClass="dateclasspune" ID="agencytxt" runat ="server"></asp:Label></td>
 </tr>
 <tr>
 <td align ="left"  style="height: 13px;padding-left:10px;"><asp:Label CssClass="dateclasspune" ID="agencyaddtxt" runat ="server"></asp:Label></td>

 </tr>
 <tr><td  colspan=&nbsp;</td></tr>

 
</table></td>
<td valign="top" 
         
                                        style="border-right-style: solid; border-bottom-style: solid; border-right-width: 1px; border-bottom-width: 1px; border-right-color: #000000; border-bottom-color: #000000; border-top-style: solid; border-top-width: 1px; border-top-color: #000000;" 
                                        class="style5">
<table cellspacing="0" cellpadding="0" style="width: 238px">


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
        style="width: 328px; height: 56px; margin-right: 0px;">

<tr>
 <td align ="left" style="padding-left:10px;" class="style6" ><asp:Label CssClass="agecnycodeclasspune" ID="lbclientna" runat ="server" Text="ClientName:"></asp:Label></td>
 <td colspan="3" align ="left" ><asp:Label CssClass="dateclasspune" ID="txtcliname" runat ="server"></asp:Label></td>
 </tr>

<tr>

<td align ="left" style="padding-left:10px;" class="style6" ><asp:Label CssClass="agecnycodeclasspune" ID="lbrodat" runat ="server" Text="RO&Date:"></asp:Label></td>
<td colspan="2" align ="left" ><asp:Label CssClass="dateclasspune" ID="lbronodate" runat ="server"></asp:Label></td>
</tr>

 
 <tr>
<td align ="left"  style="padding-left:10px;" class="style6" ><asp:Label CssClass="agecnycodeclasspune" ID="lbadtype" runat ="server" Text="Caption :" ></asp:Label></td>
<td colspan="2" align ="left" style="height: 15px" ><asp:Label CssClass="dateclasspune" ID="adcat" runat ="server"></asp:Label></td>


</tr>

 <tr>
<td align ="left" style="padding-left:10px;" class="style6" ><asp:Label CssClass="agecnycodeclasspune" ID="Label1" runat ="server" Text="Key No. :"></asp:Label></td>
<td colspan="2" align ="left" style="height: 15px" ><asp:Label CssClass="dateclasspune" ID="lblkeyno" runat ="server"></asp:Label></td>


</tr>



</table>


</td>
</tr>
</table>


<table height="192px;" cellspacing="0" cellpadding="0" 
                    style="border-bottom:solid 0px black; width: 898px;" ><tr>
       <td valign="top" style="border-right:solid 0px black">
       <table cellspacing="0" cellpadding="0"><tr><td class="style13">
        <table cellspacing="0" cellpadding="0"   class="table1" >
            <tr><td valign="top" align="left"  id="tabledy" runat ="server" class="style15">
               <asp:Label ID="dynamictable" runat="server" CssClass ="dateclasspune" ></asp:Label>                       
                 </td></tr>
                 
                 </table>
                 
                </td></tr>
        </table>
       </td>
 
   
  </tr>

  </table>
    
    
    <table cellpadding="0" cellspacing="0" id="tblamt" runat="server" style="border-top: 1px solid #000000; width: 898px; ">
    <tr>
    <td class="style4">
<table cellspacing="0" cellpadding="0" border="0" style="width: 609px" >
   <tr ><td>
   <table cellspacing="0" cellpadding="0" style="width: 609px" >
   <tr>
    <td align="left"  style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000;padding-left:10px; width:150px;"><asp:Label ID="lbinwords" runat="server" CssClass ="agecnycodeclasspune" Text="Amount (in words):"></asp:Label></td>
    <td align="left" style="font-size:9px; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #000000;" ><asp:Label ID="lbwordinrupees" runat="server" CssClass ="dateclasspune" ></asp:Label></td>
   </tr>  
   </table>
   </td> </tr>
<tr>
<td></td>

</tr>
<tr >
<td align="right" style="font-family: verdana; font-size: 9px">&nbsp;</td>

</tr>

<tr>
<td  style=" font-family: verdana; font-size: 9px;" >encls: 
    tearsheet-jaipur/jodhpur/udaipur/kota/bikaner/sikar/bhilwara/sriganganagar/alwar/bangalore/ahmedabad/ajmer/<br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;surat/chennai/pali/banswara/kolkata/bhopal/indore/jabalpur/gwalior/raipur/bilaspur/dailynews/ntj/nti</td>

</tr>
<tr>
<td style="padding-left:10px; font-family: verdana; font-size: 9px;" >&nbsp;</td>

</tr>

</table>
</td>
<td width="280px" valign="top"  >
<table cellspacing="0" cellpadding="0" 
        
        
        
        
        style="border-left: 1px solid #000000; border-bottom: 1px none #000000; width: 290px; margin-top: 0px; margin-left: 0px;"  >
<tr><td style="border-right-style: solid; border-right-width: 1px; border-right-color: #000000;font-size:11px; font-family: verdana;" 
        class="style2" align="left"><b>Gross Amount</b></td><td></td><td class="dateclasspune" align="right" ><asp:Label ID="lbl_gross" runat="server"></asp:Label></td></tr>
<tr><td style="border-right-style: solid; border-right-width: 1px; border-right-color: #000000;" 
        class="style2" align="left"><b>Trade Discount</b></td><td class="style11" align="right"><asp:Label ID="lbl_tradisper" runat="server"></asp:Label></td><td class="dateclasspune"  align="right"><asp:Label ID="lbl_trade" runat="server"></asp:Label></td></tr>
<tr><td style="border-right-style: solid; border-right-width: 1px; border-right-color: #000000;" 
        class="style2" align="left"><b>Series Discount</b></td ><td></td><td class="dateclasspune"  align="right"><asp:Label ID="lbl_add" runat="server"></asp:Label></td></tr>
<tr><td style="border-right-style: solid; border-right-width: 1px; border-right-color: #000000;" 
        class="style2" align="left"><b>Extra Discount</b></td><td class="style11" align="right"><asp:Label ID="lbl_extradisper" runat="server"></asp:Label></td><td class="dateclasspune"  align="right"><asp:Label ID="lbl_extra" runat="server"></asp:Label></td></tr>
<tr><td style="border-right-style: solid; border-right-width: 1px; border-right-color: #000000;" 
        class="style2" align="left"><b>Box Charges</b></td><td></td><td class="dateclasspune"  align="right"><asp:Label ID="lbl_box" runat="server"></asp:Label></td></tr>
<tr><td style="border-right-style: solid; border-right-width: 1px; border-right-color: #000000;" 
        class="style2" align="left"><b>Bullet Charges</b></td><td></td><td class="dateclasspune"  align="right"><asp:Label ID="lblbullet" runat="server"></asp:Label></td></tr>
<tr><td style="border-right-style: solid; border-right-width: 1px; border-right-color: #000000;" 
        class="style2" align="left"><b>Trans. Charges</b></td><td></td><td class="dateclasspune"  align="right"><asp:Label ID="lbltranslation" runat="server"></asp:Label></td></tr>
<tr><td style="border-right-style: solid; border-right-width: 1px; border-right-color: #000000;font-family: Verdana; font-size: 11px; color: #000000; font-weight: bold;" 
        class="style8" align="left"><B>
    NET PAYABLE</B></td><td></td><td class="style9"  align="right"><asp:Label ID="lbl_net" runat="server"></asp:Label></td></tr>
</table>
</td>
</tr>
</table>

                            <table cellpadding="0" style=" border-top: 1px solid #000000;" cellspacing="0" class="style10" width="80%">
                                <tr>
                                    <td style="font-family: verdana; font-size: 9px">
                                        e.&amp;.o.e</td>
                                    <td style="font-family: verdana; font-size: 10px;padding-right:10px;" align="right">
                                        for rajasthan patrika</td>
                                </tr>
                                </table>
                                <table cellpadding="0" cellspacing="0" class="style10" >
                                <tr>
                                    <td style="font-family: verdana; font-size: 9px" height="1">
                                        NOTE: 1.<b> Payments should be made in the name of <%--RAJASTHAN PATRIKA PRIVATE LIMITED--%> 
                                        <asp:Label  CssClass="agecnycodeclasspune" ID="lblcompnam" runat ="server"></asp:Label>.</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="font-family: verdana; font-size: 9px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 2. Payment should be 
                                        accompanied with Bill detail &amp; TDS deduction if applicable.</tr>
                                <tr>
                                    <td style="font-family: verdana; font-size: 9px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        3. objections.if any.should be loged within15 days from the receipt of bill.</td>
                                </tr>
                                <tr>
                                    <td style="font-family: verdana; font-size: 9px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        4. for any dispute the jurisdiction of the competent court shall be <asp:Label 
                                            CssClass="agecnycodeclasspune" ID="lblbranch" runat ="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-family: verdana; font-size: 9px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        5. for non INS accredited agencies with credit facility / government - this bill 
                                        shall accrue and become due for the payment on the</td>
                                    
                                </tr>
                                <tr>
                                    <td style="font-family: verdana; font-size: 9px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        thirtieth day from the day of publication of advertisement.</td>
                                   
                                </tr>
                                <tr>
                                    <td style="font-family: verdana; font-size: 9px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <b>6. interest @ 18% p.a will be charged on delayed payment.</b></td>
                                   
                                </tr>
                                <%--<tr>
                                    <td style="font-family: verdana; font-size: 9px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <b>5. payments should be made in the name of RAJASTHAN PATRIKA PRIVATE LIMITED only 
                                        and should accompany details.</b></td>
                                   
                                </tr>--%>
                                 <tr>
                                    <td style="font-family: verdana; font-size: 9px" ><b>Bill Remark:</b><asp:Label CssClass="dateclasspune" ID="lblremark" runat ="server"></asp:Label></td>
                                </tr>
                            </table>

<table cellspacing="0" cellpadding="0" align="left" style="width: 897px" >
<tr>
<td class="style3"></td>
<td width="250px" style="height:13px; text-decoration: underline;" ><b>Authorised Signature</b></td>
</tr>
<tr align="center">
<td 
        
        style="background-color: #2C2C2C; font-family: 'Times New Roman', Times, serif; color: #FFFFFF" 
        class="style3" ><B>THANK YOU FOR ADVERTISING WITH US </B></td>

<td  class="dateclasspune"  width="250px" style="height:13px;" ><%--*Subject to Encashment of Cheque.--%></td>

</tr>

</table>

</td>
</tr></table></p><%--
</td></tr></table>
<table>
<tr>
<td height="30px;"></td>
</tr>
</table>--%>