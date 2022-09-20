<%@ Control Language="C#" AutoEventWireup="true" CodeFile="haribhoomi_display_gst.ascx.cs" Inherits="haribhoomi_display_gst" %>

<link href="css/udyavanibill.css" type="text/css" rel="Stylesheet" />
<meta http-equiv="cache-control" content="no-cache" />
<head><title>HARIBHOOMI BILL</title>
<script type="text/javascript"  language="javascript" src="javascript/billing.js"></script>
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
        .style5
        {
            width: 907px;
        }
        .style6
        {
            height: 54px;
            width: 907px;
        }
        .auto-style1
        {
            width: 337px;
        }
        .auto-style2
        {
            width: 236%;
        }
        .auto-style3
        {
            height: 20px;
            width: 236%;
        }
    </style>
</head>
<div  id="tbl_id" runat="server" >
<table  style="border:solid 1px black;width:660px;" cellpadding="0" cellspacing="0" >
<tr>
<td>
<table style="vertical-align:top;width:660px;height:120px;border-bottom:solid 1px black;" cellspacing="0" cellpadding="0" >
<tr>
<td>

<table  style="vertical-align:top;width:660px; height: 109px;" cellspacing="0" 
        cellpadding="0">
<tr><td align="center" class="auto-style1" colspan="3" ><asp:Label style="text-align:center;" CssClass="agecnycodeclasspune" ID="pagestatus" runat ="server" ></asp:Label></td></tr>
<tr>
<td class="auto-style1">
<table cellspacing="0" cellpadding="0" width="100%;">
<td class="auto-style2"><img src="Images/Image1-43.jpg" 
        style="height: 96px; width:256px"/></td>


<tr><td style="display:none;" class="auto-style3"><asp:Label CssClass="agecnycodeclasspune" ID="lbemailtxt" runat ="server"></asp:Label></td>
</tr>
<tr><td style="display:none;" class="auto-style3"><asp:Label CssClass="agecnycodeclasspune" ID="lbemail" runat ="server">E.mail</asp:Label>:-<asp:Label CssClass="agecnycodeclasspune" ID="txtmailid" runat ="server">
</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</td></tr>
<tr><td style="display:none;" class="auto-style2"><asp:Label CssClass="agecnycodeclasspune" ID="lbpune" runat ="server">Pan No:</asp:Label>
<asp:Label CssClass="agecnycodeclasspune" ID="txtpanno" runat ="server"></asp:Label><asp:Label ID="lbltan" runat="server" CssClass="agecnycodeclasspune"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblservices" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td></tr>

</table>
    
</td>

<td  align="right" valign="top" style="width:600px" colspan="2">
<table cellspacing="0" cellpadding="0" >
<tr>
<td style="width:100%;height:20px" align="left"><asp:Label CssClass="agecnycodeclasspune" ID="lbcompanyname" runat ="server" Font-Size="Large" ></asp:Label></td>
</tr>
<tr><td style="width:100%;height:20px" align="left"><asp:Label  CssClass="agecnycodeclasspune" ID="lbcompaddress" runat ="server"></asp:Label></td>
</tr>
</tr>
<tr style="display:none;">
<td><img src="../Images/ambika.jpg"  style="height: 10px; width:189px;" visible="false"/></td>
</tr>
<tr><td align="center"></td></tr>
</table>
    
</td>
</tr>
<tr><td align="right" class="auto-style1" ></td></tr>
<tr>
    <td class="auto-style1"  style="width:460px; border-top:solid 1px black; background-color:#00BFFF; "><asp:Label CssClass="agecnycodeclasspune" ID="lable" runat ="server" Text="Invoice No.:"></asp:Label>
        <asp:Label ID="lbbillno" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td>
    <td align="left" style="width:460px; border-top:solid 1px black; background-color:#00BFFF; "><b>GST/Tax Invoice</b></td>
    <td class="auto-style1"  style="width:460px; border-top:solid 1px black; background-color:#00BFFF; "align="right"><asp:Label CssClass="agecnycodeclasspune" ID="Label8" runat ="server" Text="Bill Date:"></asp:Label>
        <asp:Label ID="lbbilldt" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td>
</tr>
</table>
</td></tr></table>


<table style="vertical-align:top;width:660px"   cellspacing="0" cellpadding="0">
<tr>
<td>
<table style="vertical-align:top;width:330px" cellspacing="0" cellpadding="0">
<tr><td ><asp:Label CssClass="agecnycodeclasspune" ID="lblto" runat ="server" Text="To,"></asp:Label></td></tr>
<tr><%--<td ><asp:Label CssClass="agecnycodeclasspune" ID="lbltextmain" runat ="server"></asp:Label>--%>
</td><td ><asp:Label CssClass="agecnycodeclasspune" ID="agddxt" runat ="server"></asp:Label></td></tr>
</table>
<table>
<tr ><%--<td style="vertical-align:top;height:50px;padding-left:40px;width:50px;" ><asp:Label CssClass="agecnycodeclasspune" ID="Label2" runat ="server">&nbsp;</asp:Label></td>--%><td style="vertical-align:top;height:50px;textalign:left;" colspan="2" ><asp:Label CssClass="agecnycodeclasspune" ID="agencyaddtxt" runat ="server"></asp:Label></td></tr>
</table>
<table>
<tr><td style="vertical-align:bottom;"><asp:Label CssClass="agecnycodeclasspune" ID="lblagencycode" runat ="server"></asp:Label>&nbsp&nbsp<asp:Label ID="txtagcode" CssClass="agecnycodeclasspune" runat="server"></asp:Label></td>
    
</tr>

</table>

</td>
<td>





<table style="vertical-align:top;width:327px;" cellspacing="0" cellpadding="0" border="0">
<tr>
    <%--<td  class="style1" style="display:none;"><asp:Label CssClass="agecnycodeclasspune" ID="lbinvoiceno" runat ="server"></asp:Label></td>
    <td class="style2" style="display:none;">:<asp:Label ID="txtinvoice" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td>
    <td  class="style2" align="right" style="display:none;"><asp:Label CssClass="agecnycodeclasspune" ID="lblbilldt" runat ="server"></asp:Label></td>
    <td  class="style2" style="display:none;"><asp:Label ID="billdt" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td>--%>
</tr>

<tr>
    <td  class="style1"><asp:Label CssClass="agecnycodeclasspune" ID="lblrefno" runat="server"></asp:Label></td><td width="82.5" class="style2">:<asp:Label CssClass="agecnycodeclasspune" ID="txtrefno" runat="server"></asp:Label></td><td class="style2">&nbsp;</td><td  class="style2"><asp:Label CssClass="agecnycodeclasspune" ID="txtrodate" runat="server"></asp:Label></td>
  
</tr>

<tr><td class="style1"><asp:Label ID="Label12" runat ="server" CssClass="agecnycodeclasspune" Text="Booking ID"></asp:Label>
</td><td  colspan="3" class="style2">:<asp:Label ID="lbookid" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td >
  
</tr>

<tr><td class="style1"><asp:Label ID="lbladrelpar" runat ="server" CssClass="agecnycodeclasspune"></asp:Label>
</td><td  colspan="3" class="style2">:<asp:Label ID="txtcliname" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td >
  
</tr>
  
<tr>
    <%--<td  class="style1""><asp:Label CssClass="agecnycodeclasspune" ID="lblcap" runat="server"></asp:Label>/<asp:Label CssClass="agecnycodeclasspune" ID="publ" runat ="server"></asp:Label></td><td colspan="3" class="style2">:<asp:Label ID="txtcaption"  CssClass="agecnycodeclasspune" runat="server"></asp:Label></td>--%>
     <td  class="style1" ><asp:Label CssClass="agecnycodeclasspune" ID="lbcrditdys" runat ="server" Text="Credit Days"></asp:Label></td>
     <%--<td class="style2" style="display:none;">:<asp:Label ID="txt60days" runat="server" CssClass="agecnycodeclasspune" Text="60 Days" ></asp:Label></td>--%>
    <td class="style2" >:<asp:Label ID="txtcrdys" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td>
    <td  class="style2" colspan="3"  ><asp:Label ID="Label15" runat="server" CssClass="agecnycodeclasspune" Text=""></asp:Label></td>
    <td  class="style2" align="right" style="display:none;"><asp:Label CssClass="agecnycodeclasspune" ID="lbdudt" runat ="server" Text="Dues Date:-"></asp:Label></td>
    <td  class="style2" style="display:none;"><asp:Label ID="txtduedys" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td>
    
  
</tr>
    <tr><td  class="style3"><asp:Label ID="lblkey" CssClass="agecnycodeclasspune" runat="server"></asp:Label></td><td>:<asp:Label ID="txtkey" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td><td>&nbsp;</td><td>&nbsp;</td>
  
</tr>
<tr><td></td><td></td></tr>
</table>





</td>
</tr>
</table>

<table  width="660px"   cellspacing="0" cellpadding="0" style="border-bottom:solid 1px black;vertical-align :top" >
<tr>
    <td valign ="top"style="border-bottom:solid 1px black;width:660px" >
           <asp:Label  id="dynamictable"  runat ="server" Width="660px"></asp:Label>
       </td>
 </tr>
</table>

<table style="vertical-align:top;width:660px; "  cellspacing="0" cellpadding="0">
<tr>
<td>
<table style="vertical-align:top;width:660px" cellspacing="0" cellpadding="0" >
<tr>
  <td class="style5" style=" border-right:solid 1px black; "><b><asp:Label CssClass="agecnycodeclasspune" ID="lbadtype" runat ="server"></asp:Label></b>:&nbsp<asp:Label CssClass="agecnycodeclasspune" ID="adcat" runat ="server"></asp:Label>
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b><asp:Label CssClass="agecnycodeclasspune" ID="Label13" runat ="server" Text="VTS Attached"></asp:Label></b>:&nbsp<asp:Label CssClass="agecnycodeclasspune" ID="txtvts" runat ="server"></asp:Label>
  </td>
    <td align="left" style="width:140px"><asp:Label ID="lblpagepr"  CssClass="agecnycodeclasspune" runat="server">page prim.</asp:Label></td>
     <td align="center"  style="width:100px;text-align:right;"class="style1" ><asp:Label ID="lb_pageprm" runat="server" CssClass ="agecnycodeclasspune"></asp:Label></td>
 </tr>
 
 <tr>
  <td class="style5" style="display:none; border-right:solid 1px black; ""><b><asp:Label CssClass="agecnycodeclasspune" ID="lbladman" runat ="server" Text="Advertisement Manager"></asp:Label></b>:&nbsp<asp:Label CssClass="agecnycodeclasspune" ID="advman" runat ="server"></asp:Label></td>
    <td align="left" style="width:140px"><asp:Label ID="Label10"  CssClass="agecnycodeclasspune" runat="server"></asp:Label></td>
     <td align="left"  style="width:100px;text-align:right;"class="style1" ><asp:Label ID="Label11" runat="server" CssClass ="agecnycodeclasspune"></asp:Label></td>
 </tr>
 
 <tr>
     <td style="font-size:11px;font-family :Times New Roman;  border-right:solid 1px black; "" class="style6">
  <asp:Label ID="hidedata" runat ="server" ></asp:Label></td>
     <td align="left" style="width:140px"><asp:Label ID="lb_total"  CssClass="agecnycodeclasspune" runat="server"></asp:Label></td>
     <td align="center"  style="width:100px;text-align:right;"class="style1" ><asp:Label ID="lb_totalamt" runat="server" CssClass ="agecnycodeclasspune" align="center"></asp:Label></td>
 </tr>
 <tr>
 <td style="border-top:dashed 1px black; border-right:solid 1px black; "" class="style5"><b><asp:Label CssClass="agecnycodeclasspune" ID="Label3" runat ="server"></asp:Label></b>&nbsp<asp:Label CssClass="agecnycodeclasspune" ID="Label5" runat ="server"></asp:Label></td>
 <td align="left" style="width:140px; border-top:dashed 1px black;"><asp:Label ID="splchagr"  CssClass="agecnycodeclasspune" runat="server"></asp:Label></td>
 <td class="style1" style="width:100px; border-top:dashed 1px black;text-align:right;" ><asp:Label ID="Label9"  CssClass="agecnycodeclasspune" runat="server"></asp:Label>&nbsp;</td>
 </tr>
 <tr>
 <td class="style5" style=" border-right:solid 1px black; "><asp:Label CssClass="agecnycodeclasspune" ID="Label27" runat ="server"></asp:Label></td>
     <td align="left" style="width:140px;" ><asp:Label  CssClass="agecnycodeclasspune" ID="lbtrade1" runat ="server"></asp:Label>&nbsp<asp:Label ID="trddisc_per"  CssClass="agecnycodeclasspune" runat="server"> <b>%</b></asp:Label></td>
     <td align="center" style="width:100px;text-align:right;"  class="style1"><asp:Label ID="txtdiscal"  CssClass="agecnycodeclasspune" runat="server" align="center"></asp:Label></td>
 </tr>
 
  <tr>
 <td class="style5" style=" border-right:solid 1px black; "><asp:Label CssClass="agecnycodeclasspune" ID="Label2" runat ="server"></asp:Label></td>
     <td align="left" style="width:140px;"  ><asp:Label  CssClass="agecnycodeclasspune" ID="Label16" runat ="server"></asp:Label>&nbsp<asp:Label ID="Label17"  CssClass="agecnycodeclasspune" runat="server"> <b>%</b></asp:Label></td>
     <td align="center" style="width:100px;text-align:right;"  class="style1"><asp:Label ID="Label18"  CssClass="agecnycodeclasspune" runat="server" align="center"></asp:Label></td>
 </tr>
     <tr>
 <td class="style5" style=" border-right:solid 1px black; "><asp:Label CssClass="agecnycodeclasspune" ID="Label19" runat ="server"></asp:Label></td>
     <td align="left" style="width:140px;" ><asp:Label  CssClass="agecnycodeclasspune" ID="Label20" runat ="server"></asp:Label>&nbsp<asp:Label ID="Label21"  CssClass="agecnycodeclasspune" runat="server"> <b>%</b></asp:Label></td>
     <td align="center" style="width:100px;text-align:right;"  class="style1"><asp:Label ID="Label22"  CssClass="agecnycodeclasspune" runat="server" align="center"></asp:Label></td>
 </tr>
     <tr>
 <td class="style5" style=" border-right:solid 1px black; "><asp:Label CssClass="agecnycodeclasspune" ID="Label23" runat ="server"></asp:Label></td>
     <td align="left" style="width:140px;" ><asp:Label  CssClass="agecnycodeclasspune" ID="Label24" runat ="server"></asp:Label>&nbsp<asp:Label ID="Label25"  CssClass="agecnycodeclasspune" runat="server"> <b>%</b></asp:Label></td>
     <td align="center" style="width:100px;text-align:right;"  class="style1"><asp:Label ID="Label26"  CssClass="agecnycodeclasspune" runat="server" align="center"></asp:Label></td>
 </tr>
     <tr>
<td class="style5" style=" border-right:solid 1px black; "><b><asp:Label CssClass="agecnycodeclasspune" ID="Label7" runat ="server">Amount Rs.</asp:Label></b>:&nbsp<asp:TextBox CssClass="agecnycodeclasspune" ID="txtrupees" runat="server" Width="166px"></asp:TextBox></td>
     <td align="left" style="width:140px;" ><asp:Label  CssClass="agecnycodeclasspune" ID="Label28" runat ="server"></asp:Label>&nbsp<asp:Label ID="Label29"  CssClass="agecnycodeclasspune" runat="server"> <b>%</b></asp:Label></td>
     <td align="center" style="width:100px;text-align:right;"  class="style1"><asp:Label ID="Label30"  CssClass="agecnycodeclasspune" runat="server" align="center"></asp:Label></td>
 </tr>
 <tr>
  <td class="style5" style=" border-right:solid 1px black; "><asp:Label ID="lbwordin" runat="server" CssClass ="insertiontxtclass2" ><b>Net Amount in words : Rupees </b>&nbsp;</asp:Label><b><asp:Label ID="lbwordinrupees" runat="server" CssClass="insertiontxtclass2"  ></asp:Label></b></td>
     <td align="left" style="width:140px"><asp:Label  CssClass="agecnycodeclasspune" ID="lblnetpayable" runat ="server"></asp:Label></td>
     <td class="style1" style="width:100px;text-align:right;" ><asp:Label ID="netpay" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td>
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
<td align="left" style="font-size:9px;font-family :Times New Roman;border-top:1px solid black;height:10px;"><asp:Label ID="Label6" runat ="server" ><b>.</b></asp:Label></td>
</tr>
</table>
<table   width="660px" cellspacing="0" cellpadding="0">
  <tr >

 <td  style="font-size:11px;font-family :Times New Roman; height:54px;width:166px;" align="left">
 <b><asp:Label ID="Label14" runat ="server" Text="YES BANK LTD. <BR> A/c No.-000181400006370 <BR> RTGS/IFSC- YESB0000001 <BR> MICR CODE-400532002" align="left"></asp:Label></b> </td>
  
  <td  style="font-size:11px;font-family :Times New Roman; height:54px;width:166px;vertical-align:top;" align="right" >
 <b><asp:Label ID="hribhomi_text" runat ="server" align="right" ></asp:Label></b> </td>
  

  </tr></table>
  <table  width="660px">
<tr>
<td style="width:90px"><asp:Label ID="lbl_remark" runat="server" style="font-size:12px;font-family :Verdana; height: 14px;vertical-align:top;"><b>Remarks:-</b></asp:Label>
</td>
<td style="font-size:10px;font-family :Verdana; height: 14px;vertical-align:middle;width:100%"> 
<asp:Label ID="txt_remark" runat="server"></asp:Label>
</td></tr>
</table>
  <table width="660px" style="height:20px" cellspacing="0" cellpadding="0">
  <tr>
  <td style="width:500px; " align="left"><asp:Label  ID="Label4" runat ="server"  CssClass="agecnycodeclasspune"><b>E.& O.E.</b></asp:Label></td>
  <td align="right"><asp:Label ID="Label1" runat ="server"  style="text-align:right;"  CssClass="agecnycodeclasspune"><b>Authorised Signatory</b></asp:Label></td>
  </tr>
  </table>
  </td></tr></table>

<table style="visibility:hidden;"><tr><td >

<asp:Label CssClass="agecnycodeclasspune" ID="lblagencyname" runat ="server"></asp:Label></td><td>:
<asp:Label CssClass="agecnycodeclasspune" ID="lbladd" runat="server"></asp:Label></td><td>:

</td></tr></table> 

</div>

