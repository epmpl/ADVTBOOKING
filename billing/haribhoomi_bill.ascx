<%@ Control Language="C#" AutoEventWireup="true" CodeFile="haribhoomi_bill.ascx.cs" Inherits="haribhoomi_bill" %>
<link href="css/udyavanibill.css" type="text/css" rel="Stylesheet" />

<head><title>HARIBHOOMI BILL </title><script type="text/javascript"  language="javascript" src="javascript/billing.js"></script></head>
<p  id="P1" style=" page-break-after:always ; width: 660px; ">
<table>
<table  style="vertical-align :top ;width="660px" cellspacing="0" cellpadding="0" >
<tr>
<td  align="center" valign="top"width="100%"><B>BILL</B></td>
<td> <asp:Label CssClass="agecnycodeclasspune" ID="pagestatus" runat ="server" aling="left" width="10%"></asp:Label></td>
</table>
<table width="660px"  cellspacing="0" cellpadding="0" >
<tr > <td >
<table style="border-top:solid 1px black;border-right:solid 1px black;vertical-align :top " width="300px" cellspacing="0" cellpadding="0"  border="0">
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
 <tr><td style="border-top:solid 1px black;" ><asp:Label CssClass="agecnycodeclasspune" ID="Label12" runat ="server" Text="From:-"></asp:Label><asp:Label CssClass="agecnycodeclasspune" ID="agname" runat ="server"></asp:Label></td></tr>
<tr>
<td   align ="left" style="padding-left:30px;width:225px;visibility:hidden;" ><b><asp:Label CssClass="agecnycodeclasspune" ID="lbcontectp" runat ="server" Text="Contact Person :"></asp:Label>
<asp:Label CssClass="agecnycodeclasspune" ID="lbcontectpn" runat ="server" ></asp:Label></b></td>
</tr>
<tr ><td style="font-size:12px;font-family :Times New Roman; vertical-align:top;border-top:solid 1px black;" align='center'  class="dateclasspune2"><asp:Label ID="lbladrelpar" runat ="server" CssClass="dateclasspune"><b>Advertisement Release Particulars</b></asp:Label></td></tr></table>      
</td>
<td valign="top" >
<table width="30px">
<tr>
<td  align="left" valign="top" style="visibility:hidden;"><img src="Images1/Manipal-Group-Logo-copy.jpg" height ="50px"/></td>
<td>
<table width="310px" cellspacing="0" cellpadding="0">
<tr ><td colspan="4" style="height: 11px" align="center"><asp:Label ID="lbcomp_name" style="font-size:12"  runat="server"><%--<B>HARI BHOOMI</B>--%></asp:Label></td></tr>
<tr><td colspan="4" align="center" >
<asp:Label ID="branchadd" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
</td></tr>
<tr><td colspan="4" align="center">
<asp:Label ID="bhranchadd1" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
</td></tr>
</table></td></tr></table>
<table width="360px" cellspacing="0" cellpadding="0">
<tr>
<td style="visibility:hidden" ><asp:Label ID="Label6" runat="server" CssClass="dateclasspune"><b>Member:ABC & INS</b></asp:Label></td>
<td align='right'><asp:Label ID="Label3" CssClass="dateclasspune" runat="server"><b>PAN:AACCH0077K</b></asp:Label></td>
</tr>
</table>
<table width="360px" style="border-top:solid 1px black;" cellspacing="0" cellpadding="0">
<tr >
<td align ="left" style="height: 13px" class="insertiontxtclass4" ><b><asp:Label CssClass="agecnycodeclasspune" ID="Label1" runat ="server">Publication</asp:Label></b></td>
<td  align ="left" style="height: 13px" class="insertiontxtclass_last" ><asp:Label CssClass="insertiontxtclass2" ID="lblpubname" runat ="server"></asp:Label></td>
<td valign ="top" align ="left" style="height: 13px"  class="insertiontxtclass4" ><b> <asp:Label CssClass="agecnycodeclasspune" ID="lbinvoiceno" runat ="server">Bill No.</asp:Label></b></td>
<td  valign ="top" align ="left" style="height: 13px" class="display2" ><asp:Label CssClass="dateclasspune" ID="txtinvoice" runat ="server"></asp:Label></td>
</tr>
<tr>
<td align ="left" style="height: 16px" class="insertiontxtclass4"  ><b><asp:Label CssClass="agecnycodeclasspune" ID="lbadtype" runat ="server">Ad Type</asp:Label></b></td>
<td align ="left" style="height: 15px" class="insertiontxtclass_last"  ><asp:Label CssClass="dateclasspune" ID="adcat" runat ="server"></asp:Label></td>
<td align ="left" class="insertiontxtclass4" ><b><asp:Label CssClass="agecnycodeclasspune" ID="lbdate" runat ="server">Date</asp:Label></b></td>
<td  align ="left" class="display2" ><asp:Label CssClass="dateclasspune" ID="runtxt" runat ="server"></asp:Label></td>
</tr>
<tr>
<td align="left" class="display1"><b><asp:Label CssClass="agecnycodeclasspune" ID="lbpackagena" runat ="server">Package</asp:Label></b></td>
<td align ="left" class="insertiontxtclassCLA"><asp:Label CssClass="dateclasspune" ID="txtpackname" runat ="server"></asp:Label></td>
<td align="left" class="display1"><b><asp:Label CssClass="agecnycodeclasspune" ID="lbddate" runat ="server">Due Date</asp:Label></b></td>
<td align="left" ><asp:Label CssClass="dateclasspune" ID="ldduedate" runat ="server"></asp:Label></td>
</tr>
</table>
</td>
</tr>
</table>
<table  width="660px"   cellspacing="0" cellpadding="0" style="border-bottom:solid 1px black;vertical-align :top" >
<tr>
<td valign ="top" style ="height :150px;">
<asp:Label  id="dynamictable"  runat ="server"></asp:Label></td></tr>
<tr ><td>
<table  style="border-top:solid 1px black;" cellspacing="0" cellpadding="0"  width="660px"><tr>
<td width='335px'></td>
<td width='100px'></td>
<td width='155px'style="height: 12px;" align="right"  ><asp:Label ID="lb_total" runat="server" CssClass ="dateclasspune" ><b>Total:-</b></asp:Label></td>
<td style="height: 12px" align="center" ><asp:Label ID="lb_totalamt" runat="server" CssClass ="dateclasspune"></asp:Label></td>
</tr>  
</table>
</td>         
<td > </td></tr>
</table>
<table   width="660px" cellspacing="0" cellpadding="0" border="0" >
<tr>
<td  style="font-size:8.5px;font-family :Times New Roman; height: 54px;border-bottom :solid 1px black;width: 335px;border-right:solid 1px black;">
<asp:Label ID="Label4" runat ="server" ></asp:Label>
</td>
<td style="font-size:10px;font-family :Verdana; height: 54px;width: 335px;vertical-align:top;" >
<table width='335px' cellspacing="0" cellpadding="0" >
<tr valign="top">
<td  align="center"width='60px'  class="insertiontxtclass4" style="height: 13px" ><asp:Label ID="Label5" runat ="server" CssClass="dateclasspune_uday" >Gross</asp:Label></td>
<td  align="center"class="insertiontxtclass4" style="height: 13px" ><asp:Label ID="Label7" runat ="server" CssClass="dateclasspune_uday" >Agency Commission</asp:Label></td>
<td  align="center"class="insertiontxtclass4" style="height: 13px" ><asp:Label ID="Label8" runat ="server" CssClass="dateclasspune_uday" >Spl.Discount</asp:Label></td>
<td width='30px' class="insertiontxtclass4" style="height: 13px" ><asp:Label ID="Label9" runat ="server" CssClass="dateclasspune_uday" >Box/ ExtraChg</asp:Label></td>
<td  class="insertiontxtclass4" style="height: 13px" ><asp:Label ID="Label10" runat ="server" CssClass="dateclasspune_uday" >Net Amount</asp:Label></td>
<td  class="newhead" style="height: 13px" ><asp:Label ID="Label11" runat ="server" CssClass="dateclasspune_uday" >Rounded Off</asp:Label></td>
</tr>
<tr>
<td align='center' class="insertiontxtclass_last" style="height: 13px" ><asp:Label ID="lblgross" runat ="server"  CssClass="dateclasspune" ></asp:Label></td>
<td align='center' class="insertiontxtclass_last" style="height: 13px" ><asp:Label ID="lbltradedis" runat ="server" CssClass="dateclasspune" ></asp:Label></td>
<td align='center'  class="insertiontxtclass_last" style="height: 13px" ><asp:Label ID="lbladddis" runat ="server"  CssClass="dateclasspune"></asp:Label></td>
 <td align='center' class="insertiontxtclass_last" style="height: 13px" ><asp:Label ID="lblextra" runat ="server" CssClass="dateclasspune" ></asp:Label></td>
<td align='center' class="insertiontxtclass_last" style="height: 13px" ><asp:Label ID="lblnetamt" runat ="server" CssClass="dateclasspune"></asp:Label></td>
<td align='center' class="display2" style="height: 13px" ><b><asp:Label ID="lblround" runat ="server" CssClass="dateclasspune"></asp:Label></b></td>
</tr>

</table>
<table  width='335px' cellspacing="0" cellpadding="0" style="border-bottom:solid 1px black;">
<td  width="105px"align="left" style="font-size:9px; height: 12px;" ><asp:Label ID="lbwordinrupees" runat="server" CssClass ="insertiontxtclass2" ><b>Net Amount in words : </b></asp:Label></td>
<td align="left"><b><asp:Label ID="rupeetxt" runat="server" CssClass="insertiontxtclass2"  ></asp:Label></b>
</td>
</table>

<table width='335px' cellspacing="0" cellpadding="0">
<tr align="right">
<td  style="font-size:10px;font-family :Verdana; height: 14px;vertical-align:top; visibility:hidden;"  align="left"><asp:Label ID="Label2" runat ="server" CssClass="dateclasspune"><b>VTS ENCLOSED</b></asp:Label></td>

<td  style="font-size:10px;font-family :Verdana; height: 14px;vertical-align:top;"  align="left"><asp:Label ID="Label18" runat ="server" CssClass="dateclasspune">For<b> Hari Bhoomi</b></asp:Label></td>
</tr>
</table>
<table  width='335px' cellspacing="0" cellpadding="0" style="height: 65px">
<tr><td align="right" valign="bottom" style="padding-right:10px;"><div id="divimg" runat="server" style="overflow:auto;"></div></td></tr></table>
</td>
</tr>
</table>
<table  style="border-bottom:solid 1px black;" width="655px">
<tr  style="border-bottom:solid 1px black;">
<td width="90px"><asp:Label ID="lbl_remark" runat="server" style="font-size:12px;font-family :Verdana; height: 14px;vertical-align:middle;"><b>Remarks:-</b></asp:Label>
</td>
<td width="100%" style="font-size:10px;font-family :Verdana; height: 14px;vertical-align:middle;"> 
<asp:Label ID="txt_remark" runat="server"></asp:Label>
</td></tr>
</table>
<table width="660px" cellspacing="0" cellpadding="0" >
<tr>
<td valign ="bottom" style="font-size:10px; height: 12px;" ><b><asp:Label ID="ENCLOSER" runat="server">Enclosed: Tear  Sheet</asp:Label></b></td>
<td valign ="bottom" style="font-size:10px; height: 12px;"></td>
<td valign ="bottom"  align="right" style="font-size:10px; height: 12px;">
<b> <asp:Label CssClass="agecnycodeclasspune"  ID="EOU" runat ="server"> E.& O.E.</asp:Label></b> </td>
<td align="right"  valign ="bottom"   style="font-size:10px; height: 12px;" ><asp:Label  CssClass="BORDERPAN" ID="lbpune" runat ="server"><b></asp:Label><asp:Label  CssClass="dateclasspune" ID="lbpunetxt" runat ="server">Billing /Advt. Incharge</asp:Label><b></td>
</tr>
</table>
</table>
</p>

<table><td hight="40px"></td></table>