<%@ Control Language="C#" AutoEventWireup="true" CodeFile="haribhoomi_privew.ascx.cs" Inherits="haribhoomi_privew" %>
<link href="css/udyavanibill.css" type="text/css" rel="Stylesheet" />
<meta http-equiv="cache-control" content="no-cache" />
<head><title>HARIBHOOMI BILL </title><script type="text/javascript"  language="javascript" src="javascript/billing.js"></script>
    <style type="text/css">
        .style1
        {
            border-bottom:thin solid;
            border-left:thin solid;
        }
        .style2
        {
         border-bottom:thin solid;
        }
        .style3
        {
        border-left:thin solid;
        }
        .style4
        {
            border-bottom:thin solid;
            
        }
    </style>
</head>
<p  id="P1" style=" page-break-after:always; width:660px;">
<table  style="border:solid 1px black;width:660px;" cellpadding="0" cellspacing="0" >
<tr>
<td>
<table style="vertical-align:top;width:660px;height:120px;border-bottom:solid 1px black;" cellspacing="0" cellpadding="0" >
<tr>
<td>

<table  style="vertical-align:top;width:660px; height: 109px;" cellspacing="0" 
        cellpadding="0">
<tr><td align="right" width="460px" CssClass="agecnycodeclasspune" ><b>Advertisement Bill</b></td><td width="200px" align="right"  style="visibility:hidden;" ><asp:Label style="text-align:right;" CssClass="agecnycodeclasspune" ID="pagestatus" runat ="server" ></asp:Label></td></tr>
<tr>
<td width="560px;">
<table cellspacing="0" cellpadding="0" width="100%;">
<tr>
<td width="100%;" height="20px"><asp:Label CssClass="agecnycodeclasspune" ID="lbcompanyname" runat ="server"></asp:Label></td>
</tr>
<tr><td width="100%;" height="20px"><asp:Label  CssClass="agecnycodeclasspune" ID="lbcompaddress" runat ="server"></asp:Label></td>
</tr>
<tr><td width="100%;" height="20px"><asp:Label CssClass="agecnycodeclasspune" ID="lbemailtxt" runat ="server"></asp:Label></td>
</tr>
<tr><td width="100%;" height="20px"><asp:Label CssClass="agecnycodeclasspune" ID="lbemail" runat ="server">E.mail</asp:Label>:-<asp:Label CssClass="agecnycodeclasspune" ID="txtmailid" runat ="server">
</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label CssClass="agecnycodeclasspune" ID="lbpune" runat ="server">Pan No:</asp:Label>
<asp:Label CssClass="agecnycodeclasspune" ID="txtpanno" runat ="server"></asp:Label></td></tr>



<tr><td style="padding-left:300px;" ><asp:Label ID="lblbookingtype" runat="server" CssClass="agecnycodeclasspune"  ></asp:Label></td>
    <td>
        &nbsp;</td>
    </tr>
</table>
    
</td>
<td  align="right" valign="top" width="200px">
<table cellspacing="0" cellpadding="0" >
<tr>
<td></td>
</tr>
<tr>
<td><img src="Images/Statesman_logo.png" style="height: 55px; width:189px;"/></td>
</tr>
<tr><td align="center"></td></tr>
</table>
    
</td>
</tr>

</table>
</td></tr></table>


<table style="vertical-align:top;width:660px"   cellspacing="0" cellpadding="0">
<tr>
<td>
<table style="vertical-align:top;width:330px" cellspacing="0" cellpadding="0">
<tr><td ><asp:Label CssClass="agecnycodeclasspune" ID="lblto" runat ="server" Text="To,"></asp:Label></td></tr>
<tr><td ><asp:Label CssClass="agecnycodeclasspune" ID="lbltextmain" runat ="server"></asp:Label></td><td ><asp:Label CssClass="agecnycodeclasspune" ID="agddxt" runat ="server" style="display:none;"></asp:Label></td></tr>
</table>
<table>
<tr ><td style="vertical-align:top;padding-left:40px;" ></td><td style="vertical-align:top;" ><asp:Label CssClass="agecnycodeclasspune" ID="agencyaddtxt" runat ="server"></asp:Label></td></tr>
<tr ><td style="vertical-align:top;padding-left:40px;vertical-align:top;" ></td><td style="vertical-align:top;" ><asp:Label CssClass="agecnycodeclasspune" ID="agencyadd2" runat ="server"></asp:Label></td></tr>
</table>
<table>

<tr><td style="vertical-align:bottom;"><asp:Label CssClass="agecnycodeclasspune" 
        ID="lblagencytype" runat ="server">Agency Type</asp:Label>
    <asp:Label ID="txtagencytype" CssClass="agecnycodeclasspune" runat="server"></asp:Label></td>
    
</tr>

<tr><td style="vertical-align:bottom;"><asp:Label CssClass="agecnycodeclasspune" ID="lblagencycode" runat ="server">Agency Code</asp:Label>&nbsp&nbsp<asp:Label ID="txtagcode" CssClass="agecnycodeclasspune" runat="server"></asp:Label></td>
    
</tr>

</table>

</td>
<td>





<table style="vertical-align:top;width:327px;" cellspacing="0" cellpadding="0" border="0">
<tr cellspacing="0" cellpadding="0" >
    <td  class="style1"><asp:Label CssClass="agecnycodeclasspune" ID="lbinvoiceno" runat ="server"></asp:Label></td>
    <td class="style2">:<asp:Label ID="txtinvoice" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td>
    <td  class="style2" align="right"><asp:Label CssClass="agecnycodeclasspune" ID="lblbilldt" runat ="server"></asp:Label></td>
    <td  class="style2"><asp:Label ID="billdt" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td>
</tr>

<tr>
    <td  class="style1"><asp:Label CssClass="agecnycodeclasspune" ID="lblbookingid" 
            runat ="server" Text="Booking Id"></asp:Label></td>
    <td class="style2">:<asp:Label ID="txtbookingid" runat="server" 
            CssClass="agecnycodeclasspune"></asp:Label></td>
    <td  class="style2" align="right">&nbsp;</td>
    <td  class="style2">&nbsp;</td>
</tr>

<tr>
    <td  class="style1"><asp:Label CssClass="agecnycodeclasspune" ID="lblrefno" runat="server"></asp:Label></td><td width="82.5" class="style2">:<asp:Label CssClass="agecnycodeclasspune" ID="txtrefno" runat="server"></asp:Label></td><td class="style2">&nbsp;</td><td  class="style2"><asp:Label CssClass="agecnycodeclasspune" ID="txtrodate" runat="server"></asp:Label></td>
  
</tr>



<tr><td class="style1"><asp:Label ID="lbladrelpar" runat ="server" CssClass="agecnycodeclasspune"></asp:Label>
</td><td  colspan="3" class="style2">:<asp:Label ID="txtcliname" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td >
  
</tr>
  
<tr>
    <td  class="style1""><asp:Label CssClass="agecnycodeclasspune" ID="lblcap" runat="server"></asp:Label>/<asp:Label CssClass="agecnycodeclasspune" ID="publ" runat ="server"></asp:Label></td><td colspan="3" class="style2">:<asp:Label ID="txtcaption"  CssClass="agecnycodeclasspune" runat="server"></asp:Label></td>
  
</tr>
    <tr><td  class="style3"><asp:Label ID="lblkey" CssClass="agecnycodeclasspune" runat="server"></asp:Label></td><td>:<asp:Label ID="txtkey" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td><td>&nbsp;</td><td>&nbsp;</td>
  
</tr>
<tr><td></td><td></td></tr>
</table>





</td>
</tr>
</table>

<table  width="660px"   cellspacing="0" cellpadding="0" style="border-bottom:solid 1px black;vertical-align :top" >
<tr spacing="0" cellpadding="0">
    <td valign ="top" width="660px" style="border-bottom:solid 1px black;height: 500px;" >
           <asp:Label  id="dynamictable"  runat ="server"></asp:Label>
       </td>
 </tr>
</table>

<table style="vertical-align:top;width:660px" cellspacing="0" cellpadding="0">
<tr>
<td>
<table style="vertical-align:top;width:660px" cellspacing="0" cellpadding="0" >
 <tr>
     <td width="500px"><b><asp:Label CssClass="agecnycodeclasspune" ID="lbadtype" runat ="server"></asp:Label></b>:&nbsp<asp:Label CssClass="agecnycodeclasspune" ID="adcat" runat ="server"></asp:Label></td>
     <td align="left" width="100px"><asp:Label ID="lb_total"  CssClass="agecnycodeclasspune" runat="server"></asp:Label></td>
     <td align="left"  width="50px"class="style1"><asp:Label ID="lb_totalamt" runat="server" CssClass ="agecnycodeclasspune"></asp:Label></td>
 </tr>
 <tr>
 <td width="470px">&nbsp;</td>
     <td align="left" width="150px"><asp:Label  CssClass="agecnycodeclasspune" ID="lbtrade1" runat ="server"></asp:Label>&nbsp<asp:Label ID="trddisc_per"  CssClass="agecnycodeclasspune" runat="server"> <b>%</b></asp:Label></td>
     <td align="left" width="50px" class="style1"><asp:Label ID="txtdiscal"  CssClass="agecnycodeclasspune" runat="server"></asp:Label></td>
 </tr>
 
 <tr>
  <td width="500px">&nbsp;</td>
     <td align="left" width="100px"><asp:Label ID="splchagr"  CssClass="agecnycodeclasspune" runat="server"></asp:Label></td>
     <td class="style1" width="50px"><asp:Label ID="Label9"  CssClass="agecnycodeclasspune" runat="server"></asp:Label>&nbsp;</td>
 </tr>
 
 <tr>
  <td width="500px">&nbsp;</td>
     <td align="left" width="100px"><asp:Label ID="lblboxcharge"   Text="Box Charge"
             CssClass="agecnycodeclasspune" runat="server"></asp:Label></td>
     <td class="style1" width="50px"><asp:Label ID="Label10"  
             CssClass="agecnycodeclasspune" runat="server"></asp:Label></td>
 </tr>
 <tr>
  <td width="500px"><asp:Label ID="lbwordin" runat="server" CssClass ="insertiontxtclass2" ><b>Net Amount in words : Rupees </b>&nbsp;</asp:Label><b><asp:Label ID="lbwordinrupees" runat="server" CssClass="insertiontxtclass2"  ></asp:Label></b></td>
     <td align="left" width="100px"><asp:Label  CssClass="agecnycodeclasspune" ID="lblnetpayable" runat ="server"></asp:Label></td>
     <td class="style1" width="50px"><asp:Label ID="netpay" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td>
 </tr>

</table>
</td>
<%--<td>
<table style="vertical-align:top;width:160px" cellspacing="0" cellpadding="0" border="1px">
 <tr><td align="left"><asp:Label ID="lb_totalamt" runat="server" CssClass ="agecnycodeclasspune"></asp:Label></td></tr>
 <tr><td align="left"><asp:Label ID="txtdiscal"  CssClass="agecnycodeclasspune" runat="server"></asp:Label></td></tr>
 <tr><td align="left"><asp:Label ID="Label8"  CssClass="agecnycodeclasspune" runat="server"></asp:Label></td></tr>
 <tr><td align="left"><asp:Label ID="Label9"  CssClass="agecnycodeclasspune" runat="server"></asp:Label></td></tr>
 <tr><td align="left"><asp:Label ID="Label10" CssClass="agecnycodeclasspune" runat="server"></asp:Label></td></tr>
 <tr><td align="left"><asp:Label ID="netpay" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td></tr>
</table>

</td>--%>
</tr>
</table>
<table width="660px" cellspacing="0" cellpadding="0">
<tr>
<td align="left" style="font-size:9px;font-family :Times New Roman;border-top:1px solid black;height:10px;"><asp:Label ID="Label6" runat ="server" style="display:none;" ><b>E.& O.E.</b></asp:Label></td>
</tr>
</table>
<table   width="660px" cellspacing="0" cellpadding="0">
  <tr><td style="font-size:11px;font-family :Times New Roman; height:54px;width:494px;">
  <asp:Label ID="hidedata" runat ="server" ></asp:Label></td>

 
  
  <td  style="font-size:11px;font-family :Times New Roman; height:54px;width:166px;display:none;" align="right">
 <b><asp:Label ID="hribhomi_text" runat ="server" style="display:none;" ></asp:Label></b> </td>
  

  </tr></table>
  <table  width="660px">
<tr>
<td width="90px"><asp:Label ID="lbl_remark" runat="server" style="font-size:12px;font-family :Verdana; height: 14px;vertical-align:middle;display:none;"><b>Remarks:-</b></asp:Label>
</td>
<td width="100%" style="font-size:10px;font-family :Verdana; height: 14px;vertical-align:middle;display:none;"> 
<asp:Label ID="txt_remark" runat="server" style="display:none;"></asp:Label>
</td></tr>
</table>
  <table width="660px" height="20px" cellspacing="0" cellpadding="0">
  <tr>
  <td width="500px" align="right"><asp:Label  ID="Label4" runat ="server"  CssClass="agecnycodeclasspune"  style="display:none;"><b>Manager(Advt.)</b></asp:Label></td>
  <td align="right"><asp:Label ID="Label1" runat ="server"  style="text-align:right;display:none;"  CssClass="agecnycodeclasspune" ><b>Accountant&nbsp&nbsp&nbsp&nbsp</b></asp:Label></td>
  </tr>
  </table>
  </td></tr></table>


</p>

<table style="visibility:hidden;"><td >

<asp:Label CssClass="agecnycodeclasspune" ID="lblagencyname" runat ="server"></asp:Label></td><td>:
<asp:Label CssClass="agecnycodeclasspune" ID="lbladd" runat="server"></asp:Label></td><td>:

</td></table> 
