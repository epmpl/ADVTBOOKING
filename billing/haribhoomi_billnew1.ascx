<%@ Control Language="C#" AutoEventWireup="true" CodeFile="haribhoomi_billnew1.ascx.cs" Inherits="haribhoomi_billnew1" %>
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
<tr><td style="width:200px" align="right"  style="visibility:hidden;" ><asp:Label style="text-align:right;" CssClass="agecnycodeclasspune" ID="pagestatus" runat ="server" ></asp:Label></td></tr>
<tr>
<td style="width:360px;">
<table cellspacing="0" cellpadding="0" width="100%;">
<td><img src="Images/national_duniya2.jpg" style="height: 32px; width:175px; padding-left:30px;"/></td>


<tr><td style="width:100%;height:20px"><asp:Label CssClass="agecnycodeclasspune" ID="lbemailtxt" runat ="server"></asp:Label></td>
</tr>
<tr><td style="width:100%;height:20px"><asp:Label CssClass="agecnycodeclasspune" ID="lbemail" runat ="server">E.mail</asp:Label>:-<asp:Label CssClass="agecnycodeclasspune" ID="txtmailid" runat ="server">
</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</td></tr>
<tr><td><asp:Label CssClass="agecnycodeclasspune" ID="lbpune" runat ="server">Pan No:</asp:Label>
<asp:Label CssClass="agecnycodeclasspune" ID="txtpanno" runat ="server"></asp:Label><asp:Label ID="lbltan" runat="server" CssClass="agecnycodeclasspune"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblservices" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td></tr>

</table>
    
</td>
<td  align="right" valign="top" style="width:400px">
<table cellspacing="0" cellpadding="0" >
<tr>
<td style="width:100%;height:20px"><asp:Label CssClass="agecnycodeclasspune" ID="lbcompanyname" runat ="server" Font-Size="X-Large"></asp:Label></td>
</tr>
<tr><td style="width:100%;height:20px"><asp:Label  CssClass="agecnycodeclasspune" ID="lbcompaddress" runat ="server"></asp:Label></td>
</tr>
</tr>
<tr style="display:none;">
<td><img src="../Images/ambika.jpg"  style="height: 10px; width:189px;" visible="false"/></td>
</tr>
<tr><td align="center"></td></tr>
</table>
    
</td>
</tr>
<tr><td align="right" style="width:460px;border-top:bold 1px solid;" ></td></tr>
<tr><td align="center" style="width:460px; border-top:solid 1px black; background-color:#00BFFF; " colspan="3" ><b>Advertisement Bill</b></td></tr>
</table>
</td></tr></table>


<table style="vertical-align:top;width:660px"   cellspacing="0" cellpadding="0">
<tr>
<td>
<table style="vertical-align:top;width:330px" cellspacing="0" cellpadding="0">
<tr><td ><asp:Label CssClass="agecnycodeclasspune" ID="lblto" runat ="server" Text="To,"></asp:Label></td></tr>
<tr><td ><asp:Label CssClass="agecnycodeclasspune" ID="lbltextmain" runat ="server"></asp:Label></td><td ><asp:Label CssClass="agecnycodeclasspune" ID="agddxt" runat ="server"></asp:Label></td></tr>
</table>
<table>
<tr ><td style="vertical-align:top;height:50px;padding-left:40px;width:50px;" ><asp:Label CssClass="agecnycodeclasspune" ID="Label2" runat ="server">&nbsp;</asp:Label></td><td style="vertical-align:top;height:50px;" ><asp:Label CssClass="agecnycodeclasspune" ID="agencyaddtxt" runat ="server"></asp:Label></td></tr>
</table>
<table>
<tr style="display:none;"><td style="vertical-align:bottom;"><asp:Label CssClass="agecnycodeclasspune" ID="lblagencycode" runat ="server"></asp:Label>&nbsp&nbsp<asp:Label ID="txtagcode" CssClass="agecnycodeclasspune" runat="server"></asp:Label></td>
    
</tr>

</table>

</td>
<td>





<table style="vertical-align:top;width:327px;" cellspacing="0" cellpadding="0" border="0">
<tr>
    <td  class="style1"><asp:Label CssClass="agecnycodeclasspune" ID="lbinvoiceno" runat ="server"></asp:Label></td>
    <td class="style2">:<asp:Label ID="txtinvoice" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td>
    <td  class="style2" align="right"><asp:Label CssClass="agecnycodeclasspune" ID="lblbilldt" runat ="server"></asp:Label></td>
    <td  class="style2"><asp:Label ID="billdt" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td>
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
<tr>
    <td valign ="top"style="border-bottom:solid 1px black;height: 300px;width:660px" >
           <asp:Label  id="dynamictable"  runat ="server"></asp:Label>
       </td>
 </tr>
</table>

<table style="vertical-align:top;width:660px; "  cellspacing="0" cellpadding="0">
<tr>
<td>
<table style="vertical-align:top;width:660px" cellspacing="0" cellpadding="0" >
<tr>
  <td class="style5"><b><asp:Label CssClass="agecnycodeclasspune" ID="lbadtype" runat ="server"></asp:Label></b>:&nbsp<asp:Label CssClass="agecnycodeclasspune" ID="adcat" runat ="server"></asp:Label></td>
    <td align="left" style="width:140px"><asp:Label ID="lblpagepr"  CssClass="agecnycodeclasspune" runat="server">page prim.</asp:Label></td>
     <td align="center"  style="width:100px"class="style1"><asp:Label ID="lb_pageprm" runat="server" CssClass ="agecnycodeclasspune"></asp:Label></td>
 </tr>
 
 <tr>
  <td class="style5"><b><asp:Label CssClass="agecnycodeclasspune" ID="lbladman" runat ="server" Text="Advertisement Manager"></asp:Label></b>:&nbsp<asp:Label CssClass="agecnycodeclasspune" ID="advman" runat ="server"></asp:Label></td>
    <td align="left" style="width:140px"><asp:Label ID="Label10"  CssClass="agecnycodeclasspune" runat="server"></asp:Label></td>
     <td align="left"  style="width:100px"class="style1"><asp:Label ID="Label11" runat="server" CssClass ="agecnycodeclasspune"></asp:Label></td>
 </tr>
 
 <tr>
     <td style="font-size:11px;font-family :Times New Roman; " class="style6">
  <asp:Label ID="hidedata" runat ="server" ></asp:Label></td>
     <td align="left" style="width:140px"><asp:Label ID="lb_total"  CssClass="agecnycodeclasspune" runat="server"></asp:Label></td>
     <td align="center"  style="width:100px"class="style1"><asp:Label ID="lb_totalamt" runat="server" CssClass ="agecnycodeclasspune" align="center"></asp:Label></td>
 </tr>
 <tr>
 <td style="border-top:dashed 1px black;" class="style5"><b><asp:Label CssClass="agecnycodeclasspune" ID="Label3" runat ="server"></asp:Label></b>:&nbsp<asp:Label CssClass="agecnycodeclasspune" ID="Label5" runat ="server"></asp:Label></td>
 <td align="left" style="width:140px; border-top:dashed 1px black;"><asp:Label ID="splchagr"  CssClass="agecnycodeclasspune" runat="server"></asp:Label></td>
 <td class="style1" style="width:100px; border-top:dashed 1px black;" align="center"><asp:Label ID="Label9"  CssClass="agecnycodeclasspune" runat="server"></asp:Label>&nbsp;</td>
 </tr>
 <tr>
 <td class="style5"><b><asp:Label CssClass="agecnycodeclasspune" ID="Label7" runat ="server">Amount Rs.</asp:Label></b>:&nbsp<asp:Label 
         ID="txtrupees" runat="server" 
         style="height:18px; width:100px; border:0px solid black;" Height="28px" 
         Width="103px"></asp:Label></td>
     <td align="left" style="width:140px;" ><asp:Label  CssClass="agecnycodeclasspune" ID="lbtrade1" runat ="server"></asp:Label>&nbsp<asp:Label ID="trddisc_per"  CssClass="agecnycodeclasspune" runat="server"> <b>%</b></asp:Label></td>
     <td align="center" style="width:100px;"  class="style1"><asp:Label ID="txtdiscal"  CssClass="agecnycodeclasspune" runat="server" align="center"></asp:Label></td>
 </tr>
 
 
 <tr>
  <td class="style5"><asp:Label ID="lbwordin" runat="server" CssClass ="insertiontxtclass2" ><b>Net Amount in words : Rupees </b>&nbsp;</asp:Label><b><asp:Label ID="lbwordinrupees" runat="server" CssClass="insertiontxtclass2"  ></asp:Label></b></td>
     <td align="left" style="width:140px"><asp:Label  CssClass="agecnycodeclasspune" ID="lblnetpayable" runat ="server"></asp:Label></td>
     <td class="style1" style="width:100px" align="center"><asp:Label ID="netpay" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td>
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
<td align="left" style="font-size:9px;font-family :Times New Roman;border-top:1px solid black;height:10px;"><asp:Label ID="Label6" runat ="server" ><b>E.& O.E.</b></asp:Label></td>
</tr>
</table>
<table   width="660px" cellspacing="0" cellpadding="0">
  <tr >

 
  
  <td  style="font-size:11px;font-family :Times New Roman; height:54px;width:166px;" align="right">
 <b><asp:Label ID="hribhomi_text" runat ="server" ></asp:Label></b> </td>
  

  </tr></table>
  <table  width="660px">
<tr>
<td style="width:90px"><asp:Label ID="lbl_remark" runat="server" style="font-size:12px;font-family :Verdana; height: 14px;vertical-align:middle;"><b>Remarks:-</b></asp:Label>
</td>
<td style="font-size:10px;font-family :Verdana; height: 14px;vertical-align:middle;width:100%"> 
<asp:Label ID="txt_remark" runat="server"></asp:Label>
</td></tr>
</table>
  <table width="660px" style="height:20px" cellspacing="0" cellpadding="0">
  <tr>
  <td style="width:500px" align="right"><asp:Label  ID="Label4" runat ="server"  CssClass="agecnycodeclasspune"><b>Manager(Advt.)</b></asp:Label></td>
  <td align="right"><asp:Label ID="Label1" runat ="server"  style="text-align:right;"  CssClass="agecnycodeclasspune"><b>Accountant&nbsp&nbsp&nbsp&nbsp</b></asp:Label></td>
  </tr>
  </table>
  </td></tr></table>

<table style="visibility:hidden;"><tr><td >

<asp:Label CssClass="agecnycodeclasspune" ID="lblagencyname" runat ="server"></asp:Label></td><td>:
<asp:Label CssClass="agecnycodeclasspune" ID="lbladd" runat="server"></asp:Label></td><td>:

</td></tr></table> 

</div>