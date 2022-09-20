<%@ Control Language="C#" AutoEventWireup="true" CodeFile="dainik_pdf.ascx.cs" Inherits="dainik_pdf" %>







<head>

<script type="text/javascript"  language="javascript" src="javascript/billing.js"></script>
    <style type="text/css">
        .style1
        {
            visibility: hidden;
            height: 10px;
        }
        .style2
        {
            height: 10px;
        }
    </style>
</head>
<div  id="div_p" runat="server" valign="top;">

<table border="1" cellspacing="0" cellpadding="0"  width="666px"  valign="top;"    >
<tr>
<td style="width: 660px" valign ="top" >

<table  style="vertical-align :top " width="660px" cellspacing="0" cellpadding="0" >
<tr>
<td  align="right" valign="top"width="330px"><B>ADVERTISEMENT BILL</B></td>

<td  align="center" style=" padding-right:30px;" ><img src="Images1/arp_logo.gif" height ="30px"/></td>

</tr>
 
 
 </table>
 <table width="660px"  cellspacing="0" cellpadding="0" >
 <tr > <td >
 <table border="1" width="300px" cellspacing="0" cellpadding="0" >
 <tr>
    <td   align ="left" style="padding-left:5px;" ><b><asp:Label style="font-size :11px;font-family :Times New Roman;color:Black ;font-weight:bold;" ID="lblto" runat ="server" Text="Agency Name And Address:"></asp:Label></b></td>
 </tr>
 <tr>
 
 <td  align ="left" valign ="top" style="padding-left:30px;" ><asp:Label style="font-size :11px;font-family :Times New Roman;color:Black ;font-weight:bold;" ID="agddxt" runat ="server"></asp:Label></td>
   
 </tr>
 <tr>
 
 <td align ="left"  style="padding-left:30px;"><b> <asp:Label style="font-size :11px;font-family :Times New Roman;color:Black ;font-weight:bold;" ID="agencyaddtxt" runat ="server"></asp:Label></b></td>
 </tr>
 
 <tr>
 <td   align ="left" style="padding-left:30px;" ><b><asp:Label style="font-size :11px;font-family :Times New Roman;color:Black ;font-weight:bold;" ID="lbcityname" runat ="server"></asp:Label>
<asp:Label style="font-size :11px;font-family :Times New Roman;color:Black ;font-weight:bold;" ID="txtpinno" runat ="server"></asp:Label></b></td>
 </tr>
 <tr><td style="border-top:solid 1px black; display:none"  id="client" runat="server"><b><asp:Label style="font-size :11px;font-family :Times New Roman;color:Black ;font-weight:bold;" ID="shipingto" runat ="server" Text="Client Name And Address:"></asp:Label>
</b></td></tr>
 <tr>
  <td   align ="left" style="padding-left:30px;width:225px; " ><b><asp:Label style="font-size :11px;font-family :Times New Roman;color:Black ;font-weight:bold;" ID="compnyname" runat ="server" ></asp:Label></b></td></tr>
<tr><td   align ="left" style="padding-left:30px;width:225px; " > <b><asp:Label style="font-size :11px;font-family :Times New Roman;color:Black ;font-weight:bold;" ID="compnyaddres" runat ="server" ></asp:Label></b></td></tr>
<tr>
 <td   align ="left" style="padding-left:30px;" ><b><asp:Label style="font-size :11px;font-family :Times New Roman;color:Black ;font-weight:bold;" ID="clientcity" runat ="server"></asp:Label>
<asp:Label style="font-size :11px;font-family :Times New Roman;color:Black ;font-weight:bold;" ID="clientcitypin" runat ="server"></asp:Label></b></td>
 </tr>
 <tr><td id="client1" runat="server" style="display:none" >&nbsp;</td></tr>
 <tr><td id="client2" runat="server" style="display:none" >&nbsp;</td></tr>
<tr ><td style="font-size:12px;font-family :Times New Roman; vertical-align:top;border-top:solid 1px black;" align='center'  style="background-color:Gray;">


<asp:Label ID="lbladrelpar" runat ="server" style="background-color:Gray;"><b>Advertisement Release Particulars</b>
</asp:Label></td></tr></table>  



    
</td>


<td valign="top" >
<table width="30px" align="right">
<tr>

<td align="right">
<table width="355px" cellspacing="0" cellpadding="0" border="0" ALIGN="right">
<tr  align="right"><td colspan="4" style="height: 11px" align="center"><asp:Label ID="lbcomp_name" style="font-size:12"  runat="server"><B>DAINIK SAVERA</B></asp:Label></td></tr>
<tr><td colspan="4" align="center" ><asp:Label ID="lbcomp_add" style="background-color:Gray;" runat="server"><b>S-9,INDUSTRIAL AREA, JALANDHAR(PUNJAB)</b></asp:Label></td></tr>
<tr><td colspan="4" align="center"><asp:Label ID="lbcomp_ph" style="background-color:Gray;" runat="server"><b>Ph:0181 2291616-17-18 fax:2290001,2292827</b></asp:Label></td></tr>
<tr><td colspan="4" align="center"><asp:Label ID="lbcomp_email" style="background-color:Gray;" runat="server"><b>email:dainiksavera.jal@gmail.com</b></asp:Label></td></tr>
</table></td></tr>


</table>
<table width="360px" cellspacing="0" cellpadding="0" align="right">
<tr>
<%--<td><asp:Label ID="Label6" runat="server" CssClass="dateclasspune"><b>Member:ABC & INS</b></asp:Label></td>
--%>
<td><asp:Label ID="Label6" runat="server" style="background-color:Gray;"><b>PAN:</b></asp:Label></td>
<td align='right'><asp:Label ID="Label3" style="background-color:Gray;" runat="server"><b>Service Tax No.</b></asp:Label></td>
</tr>


</table>

<table width="360px" border="1" cellspacing="0" cellpadding="0" align="right">
<tr >
<td align ="left" style="height: 13px;border-bottom:solid 1px black;border-right:solid 1px black;color:Black;background-color:Gray;" ><b><asp:Label style="font-size :11px;
	font-family :Times New Roman;color:Black ;font-weight:bold;" ID="Label1" runat ="server">Publication</asp:Label></b></td>
<td  align ="left" style="height: 13px;border-bottom:solid 1px black;border-right:solid 1px black;color:Black ;" ><asp:Label style="font-family :Times New Roman ;font-size :10px;color:Black ;" ID="lblpubname" runat ="server"></asp:Label></td>

 <td valign ="top" align ="left" style="height: 13px;border-bottom:solid 1px black;border-right:solid 1px black;color:Black;background-color:Gray;" ><b> <asp:Label style="font-size :11px;	font-family :Times New Roman;color:Black ;font-weight:bold;" ID="lbinvoiceno" runat ="server">Bill No.</asp:Label></b></td>
 <td  valign ="top" align ="left" style="height: 13px;font-family :Times New Roman ;border-bottom:solid 1px;border-color:Black;font-size :10px;" ><asp:Label style="font-size :11px;	font-family :Times New Roman;color:Black ;font-weight:bold;" ID="txtinvoice" runat ="server"></asp:Label></td>
</tr>
<tr>

<td align ="left" style="height: 16px;border-bottom:solid 1px black;border-right:solid 1px black;color:Black;background-color:Gray;"  ><b><asp:Label style="font-size :11px;	font-family :Times New Roman;color:Black ;font-weight:bold;" ID="lbadtype" runat ="server">Ad Type</asp:Label></b></td>
<td align ="left" style="height: 15px;border-bottom:solid 1px black;border-right:solid 1px black;color:Black;"   ><asp:Label style="font-size :11px;	font-family :Times New Roman;color:Black ;font-weight:bold;" ID="adcat" runat ="server"></asp:Label></td>

<td align ="left" style="border-bottom:solid 1px black;border-right:solid 1px black;color:Black;background-color:Gray;"><b><asp:Label style="font-size :11px;	font-family :Times New Roman;color:Black ;font-weight:bold;" ID="lbdate" runat ="server">Date</asp:Label></b></td>
<td  align ="left" style="border-bottom:solid 1px black;border-right:solid 1px black;color:Black ;"><asp:Label style="font-size :11px;	font-family :Times New Roman;color:Black ;font-weight:bold;" ID="runtxt" runat ="server"></asp:Label></td>
</tr>

<tr>

<td align="left" style="border-right:solid 1px;border-color:Black;background-color:Gray;"><b><asp:Label style="font-size :11px;	font-family :Times New Roman;color:Black ;font-weight:bold;" ID="lbpackagena" runat ="server">Package.</asp:Label></b></td>
<td align ="left"style="border-right:solid 1px;border-color:Black;"><asp:Label style="font-size :11px;	font-family :Times New Roman;color:Black ;font-weight:bold;" ID="txtpackname" runat ="server"></asp:Label></td>
<td align="left" style="border-right:solid 1px;border-color:Black;background-color:Gray;"><b><asp:Label style="font-size :11px;	font-family :Times New Roman;color:Black ;font-weight:bold;" ID="lbddate" runat ="server">Due Date</asp:Label></b></td>
<td align="left" ><asp:Label style="font-size :11px;	font-family :Times New Roman;color:Black ;font-weight:bold;" ID="ldduedate" runat ="server"></asp:Label></td>

</tr>
</table>
</td>
</tr>

</table>

<table   cellspacing="0" cellpadding="0" border="0" >
<tr>

<td valign ="top" style ="height :150px;" width="660px" >
       <asp:Label  id="dynamictable"  runat ="server"></asp:Label>
              
     
       </td>
      
  
  
  </tr>
  
  
  
  
 <tr ><td>
   
   <table  border="1" cellspacing="0" cellpadding="0"  width="666px"><tr>

              
                 <td width='600px'style="height: 12px;" align="right"  ><asp:Label ID="lb_total" runat="server" style="background-color:Gray;" ><b>Total:-</b></asp:Label></td>
                  <td width='66px' style="height: 12px" align="center" ><asp:Label ID="lb_totalamt" runat="server" style="background-color:Gray;"></asp:Label></td>
                
                 </tr>  
                 
                 </table>
                 
                 
                 
                 
                 </td>         
 </tr>
  </table>
  
  
  
  
 
  <table    cellspacing="0" cellpadding="0" border="0" width="666PX" >
  
  <tr  >
  <td   width="400px;"  >
  <asp:Label ID="Label4" runat ="server" Font-Size="XX-Small"   ><b><u>Terms & Conditions:</u></b><br />
1:&nbsp;Payment shall be made by A/c payee cheque or Bank Draft favouring "DAINIK SAVERA A/C"  payable at <b>JALANDHAR.</b><br /> 
2:&nbsp;Payment must be accompained with bill no.and date and made to Authorised Representatives of the Company only.<br /> 
3:&nbsp;Official  Receipts issued by the Company with signature of Authorised Signatories will only be binding on the Company.<br /> 
4:&nbsp;All communications regarding the bills must be made to  the Manager-Advt Accounts. No objection or complaint regarding
this bill will not be entertained unless it is logged within 15 days of the presentation of the bill.<br /> 
5:&nbsp;Interest @18% on the bill amount will be charged for the delayed payment.<br /> 
6:&nbsp;All disputes are subject to JALANDHAR jurisdiction only.<br /> 
</asp:Label>
  </td>
  

  
  <td width="266px;" style="font-size:6px;font-family :Verdana; height: 54px;vertical-align:top;" ALIGN="center"  valign="TOP">
  <table width="260px;" cellspacing="0" cellpadding="0" border="1" >
  <tr valign="top" >
  <td  width='50px'  style="border-bottom:solid 1px black;border-right:solid 1px black;color:Black ; background-color:Gray;height:13px;" ><asp:Label ID="Label5" runat ="server" style="font-size :9px;font-family :Times New Roman;color:Black ;font-weight:bold;" >Gross</asp:Label></td>
  <td  align="center" style="height: 13px; background-color:Gray;" ><asp:Label ID="Label12" runat ="server" style="font-size :9px;font-family :Times New Roman;color:Black ;font-weight:bold;"></asp:Label><asp:Label ID="Label7" runat ="server" style="font-size :9px;font-family :Times New Roman;color:Black ;font-weight:bold;" >(-)TD.</asp:Label></td>
  <td  align="center"  style="height: 13px;background-color:Gray;" ><asp:Label ID="Label13" runat ="server" style="font-size :9px;font-family :Times New Roman;color:Black ;font-weight:bold;"></asp:Label><asp:Label ID="Label8" runat ="server" style="font-size :9px;font-family :Times New Roman;color:Black ;font-weight:bold;" >Addl Disc</asp:Label></td>
<%--   <td  class="insertiontxtclass4" style="height: 13px" ><asp:Label ID="Label2" runat ="server" CssClass="dateclasspune_uday" >Extra</asp:Label></td>
--%>  <td width='30px' style="height: 13px;border-bottom:solid 1px black;border-right:solid 1px black;color:Black ; background-color:Gray;height:13px;" ><asp:Label ID="Label9" runat ="server" style="font-size :9px;font-family :Times New Roman;color:Black ;font-weight:bold;" >Box/ ExtraChg</asp:Label></td>
  <td  style="height: 13px;border-bottom:solid 1px black;border-right:solid 1px black;color:Black ; background-color:Gray;height:13px;" ><asp:Label ID="Label10" runat ="server" style="font-size :9px;font-family :Times New Roman;color:Black ;font-weight:bold;" >Net Amt.</asp:Label></td>
  <td  style="height: 13px;font-family:Verdana;font-size:small ; background-color:Gray;"><asp:Label ID="Label11" runat ="server" style="font-size :9px;font-family :Times New Roman;color:Black ;" >Rund Off</asp:Label></td>
  </tr>
    <tr>
  <td align='center' style="height:13px;border-bottom:solid 1px black;border-right:solid 1px black;color:Black ;" ><asp:Label ID="lblgross" runat ="server"  style="font-family :Times New Roman;color:Black ;font-size :10PX;" ></asp:Label></td>
  <td align='center' style="height:13px;border-bottom:solid 1px black;border-right:solid 1px black;color:Black ;" ><asp:Label ID="lbltradedis" runat ="server"  style="font-family :Times New Roman;color:Black ;font-size :10PX;"></asp:Label></td>
  <td align='center'  style="height:13px;border-bottom:solid 1px black;border-right:solid 1px black;color:Black ;" ><asp:Label ID="lbladddis" runat ="server"   style="font-family :Times New Roman;color:Black ;font-size :10PX;"></asp:Label></td>
<%--  <td align='center'  class="insertiontxtclass_last" style="height: 13px" ><asp:Label ID="lblext" runat ="server"  style="background-color:Gray;"></asp:Label></td>
--%>  <td align='center' style="height:13px;border-bottom:solid 1px black;border-right:solid 1px black;color:Black ;" ><asp:Label ID="lblextra" runat ="server"  style="font-family :Times New Roman;color:Black ;font-size :10PX;" ></asp:Label></td>
  <td align='center' style="height:13px;border-bottom:solid 1px black;border-right:solid 1px black;color:Black ;" ><asp:Label ID="lblnetamt" runat ="server"  style="font-family :Times New Roman;color:Black ;font-size :10PX;"></asp:Label></td>
  <td align='center' style="font-family :Times New Roman ;height: 13px" ><b><asp:Label ID="lblround" runat ="server"  style="font-family :Times New Roman;color:Black ;font-size :10PX;"></asp:Label></b></td>
  </tr>
  
  
  <tr>


<td  colspan="3" align="left" style="font-size:9px; height: 12px;" ><asp:Label ID="lbwordinrupees" runat="server" style="font-family :Times New Roman ;font-size :10px;color:Black ;" >Net Amount in words:</asp:Label></td>
<td  colspan="3"   align="left"  ><asp:Label ID="rupeetxt" runat="server" style="font-family :Times New Roman ;font-size :10px;color:Black ;"  ></asp:Label>
</td></tr>


<tr>

                 <td   width='260px' colspan="6" align="right">
             
                 <asp:Label ID="Label18" runat ="server" style="background-color:Gray;font-size:9px; ">For<b> Grace News And Media Network Ltd.</b>
                 </asp:Label></td>
   
   </tr>
    </table>
    
    
    
    
    

    
   
    
     <table  width='260px' cellspacing="0" cellpadding="0" style="height: 10px" border="0">
     <tr><td align="right" valign="bottom" >     <div id="divimg" runat="server" style="overflow:auto;"></div></td></tr></table>
     
     
     
  </td></tr>
  
   <tr >
   
   <td colspan="2">
   <table  width="666px;">
   <tr>
<td valign ="bottom" style="font-size:10px; height: 8px;" ><b><asp:Label ID="ENCLOSER" runat="server">Enclosed: "DAINIK SAVERA" NEWSPAPER TEAR SHEET</asp:Label></b></td>
<td valign ="bottom" style="font-size:10px; height:8px;"></td>
<td valign ="bottom"  align="center" style="font-size:10px; height: 8px;">
<b> <asp:Label style="font-size :11px;font-family :Times New Roman;color:Black ;font-weight:bold;"  ID="EOU" runat ="server"> E.& O.E.</asp:Label></b> </td>

<td align="right"  valign ="bottom"   style="font-size:10px; height: 12px;" ><asp:Label  CssClass="BORDERPAN" ID="lbpune" runat ="server"><b></asp:Label><asp:Label  style="background-color:Gray;" ID="lbpunetxt" runat ="server">Authorised Signatory</asp:Label><b></td>
</tr>
</table>
</td>

</tr>
  
  
  </table> 
  
  
  
  

  
  
  


  

  
  




</td>
 </tr>
  
  </table>


  
</div>

