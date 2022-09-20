<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RCB_GST.ascx.cs" Inherits="RCB_GST" %>

<link href="css/StyleSheet.css" type="text/css" rel="Stylesheet" />
<div id="showtable" style="padding-left:40px; padding-top:6px;border:none;display:block;z-index:0;">
<p style="page-break-after:always"> 
<table style="border:solid 1px black; vertical-align:top;" cellspacing="0" cellpadding="0"><tr><td style="width: 690px">




 <table  style="border-bottom:solid 1px black;vertical-align:top;" width="690px" cellspacing="0" cellpadding="0" >
 <tr>
     <td  valign ="middle"  align ="center" ><img src="Images/pune.jpg" height ="50px"/></td>
     <td  valign ="middle"  align ="center" ><asp:Label ID="lblpublications" runat ="server" Font-Bold="True" Font-Names="Times New Roman" Font-Size="20px"></asp:Label></td>
     <td  valign ="middle"  align ="center" style="width:150px;" ><u><asp:Label ID="Label1" runat ="server"  Font-Bold="True" Font-Names="Verdana" Font-Size="13px"></asp:Label><br />
         <br /></u>
         <asp:Label ID="lbbilltype" runat ="server" CssClass="dateclasspune"></asp:Label></td>
 </tr>
 
 <tr>
    <td valign ="middle"  align ="center" colspan="3" style="border-bottom:solid 1px black;font-size:14px; height: 17px;">
    <asp:Label ID="lbcompaddress" runat ="server" CssClass="dateclasspune"></asp:Label></td>
    
 </tr>
 </table>
 <table width="690px" cellspacing="0" cellpadding="0" style="border-bottom:solid 1px black">
 <tr>
 <td>
 <table width="500px" cellspacing="0" cellpadding="0">
 <tr>
 <td><asp:Label CssClass="agecnycodeclasspunehead" ID="agencytxt" runat ="server"></asp:Label></td> 
 <td colspan="3"><asp:Label CssClass="dateclasspune" ID="agddxt" runat ="server"></asp:Label></td>
 </tr>
 <tr>
 <td ><asp:Label CssClass="agecnycodeclasspunehead" ID="lbclientadd" runat ="server"></asp:Label></td>
 <td colspan="3"><asp:Label CssClass="dateclasspune" ID="lbaddress" runat ="server"></asp:Label></td>
 </tr>

 <tr>
 <td ><asp:Label CssClass="agecnycodeclasspunehead" ID="lbclientna" runat ="server"></asp:Label></td>
 <td colspan="3"><asp:Label CssClass="dateclasspune" ID="txtcliname" runat ="server"></asp:Label></td>
 </tr>
 <tr>
  <td><asp:Label CssClass="agecnycodeclasspunehead" ID="lbcap" runat ="server"></asp:Label></td>
 <td colspan="3"><asp:Label CssClass="dateclasspune" ID="lbcaption" runat ="server"></asp:Label></td>
</tr>
</table></td>
<td>
<table width="190px" cellspacing="0" cellpadding="0">
<tr>
 <td ><asp:Label CssClass="agecnycodeclasspunehead" ID="lbrcb" runat ="server"></asp:Label></td>
 <td colspan="2" style="height: 19px"><asp:Label CssClass="dateclasspune" ID="lbrcbtxt" runat ="server"></asp:Label></td>
</tr>
<tr>
<td><asp:Label CssClass="agecnycodeclasspunehead" ID="lbdate" runat ="server"></asp:Label></td>
<td colspan="2"><asp:Label CssClass="dateclasspune" ID="runtxt" runat ="server"></asp:Label></td>
</tr>
<tr>
<td><asp:Label CssClass="agecnycodeclasspunehead" ID="lbadtype" runat ="server"></asp:Label></td>
<td colspan="2"><asp:Label CssClass="dateclasspune" ID="adcat" runat ="server"></asp:Label></td>
</tr>
<tr>
<td><asp:Label CssClass="agecnycodeclasspunehead" ID="lbrodat" runat ="server"></asp:Label></td>
<td colspan="2"><asp:Label CssClass="dateclasspune" ID="lbronodate" runat ="server"></asp:Label></td>
</tr>
</table>
</td>
</tr>
</table>
<table width="690px" cellspacing="0" cellpadding="0" style="border-bottom:solid 1px black" >
<tr>
<td >
<table width ="500px" cellspacing="0" cellpadding="0"><tr>
<td style="width :90px; height: 12px;"><asp:Label CssClass="agecnycodeclasspunehead" ID="lbpackagena" runat ="server"></asp:Label></td>
<td colspan="3" align="left" style="height: 12px" ><asp:Label CssClass="dateclasspune" ID="txtpackname" runat ="server"></asp:Label></td>
</tr></table>
</td>
<td ><table width ="190px" cellspacing="0" cellpadding="0"><tr>
<td style="height: 12px"><asp:Label CssClass="agecnycodeclasspunehead" ID="lbpackagerate" runat ="server"></asp:Label></td>
<td colspan="2" style="height: 12px"><asp:Label CssClass="dateclasspune" ID="lbpakgrate" runat ="server"></asp:Label></td>
</tr></table></td>
</tr></table>


<table width="690px" cellspacing="0" cellpadding="0" style="border-bottom:solid 1px black" ><tr>
       <td valign="top" style="border-right:solid 1px black">
       <table cellspacing="0" cellpadding="0"><tr><td colspan="2">
        <table cellspacing="0" cellpadding="0"  width="500px"   class="table1" >
            <tr><td colspan="2"   valign="top" align="left"  id="tabledy" runat ="server" style="height: 18px">
               <asp:Label ID="dynamictable" runat="server" CssClass ="dateclasspune" ></asp:Label>                       
                 </td></tr>
                 
                 </table>
                 
                </td></tr>
        </table>
       </td>
 
       <td >
        <table  width="190" cellspacing="0" cellpadding="0">
        <tr>
            <td><asp:Label CssClass="agecnycodeclasspunehead" ID="lbinsertionnumber" runat ="server"></asp:Label> </td>
            <td align=right ><asp:Label CssClass="dateclasspune" ID="insertiontxt" runat ="server"></asp:Label></td>
            
        </tr>
        <tr>
            <td ><asp:Label  ID="lblamount" runat ="server"  CssClass="agecnycodeclasspunehead"></asp:Label></td>
            <td align=right><asp:Label   ID="txtgrossamt" runat ="server"  CssClass="dateclasspune"></asp:Label></td>
            
        </tr>
        <tr>
            <td style="height: 12px"><asp:Label CssClass="agecnycodeclasspunehead" ID="lbextpre" runat ="server"></asp:Label></td>
            <td align=right style="height: 12px"><asp:Label CssClass="dateclasspune" ID="lbextrapre" runat ="server"></asp:Label></td>
            
        </tr>
     
        <tr>
            <td><asp:Label CssClass="agecnycodeclasspunehead" ID="lbgr" runat ="server"></asp:Label></td>
            <td align="right"><asp:Label CssClass="dateclasspune" ID="txtagr" runat ="server"></asp:Label></td>
            
        </tr>
        <tr>
            <td><asp:Label CssClass="agecnycodeclasspunehead" ID="lbtrade1" runat ="server"></asp:Label></td>
            <td align=right><asp:Label CssClass="dateclasspune" ID="txtdiscal" runat ="server"></asp:Label></td>
            
        </tr>

        <tr>
            <td style="height: 12px"><asp:Label CssClass="agecnycodeclasspunehead" ID="lbadtd" runat ="server"></asp:Label></td>
            <td align=right style="height: 12px"><asp:Label CssClass="dateclasspune" ID="lbadtdtxt" runat ="server"></asp:Label></td>
            
        </tr>
            <tr style="border-bottom:solid 1px black;">
            <td  style ="border-bottom:solid 1px black; height: 12px;"><b><asp:Label CssClass="agecnycodeclasspunehead" ID="Label20" runat ="server">Taxable Value</asp:Label></b></td>
            <td align="right" style="height: 13px; border-bottom:solid 1px black;"><asp:Label CssClass="dateclasspune" ID="Label21" runat ="server"></asp:Label></td>
        </tr>       
                  
  <tr  id="tr7" runat="server">
      <td align="left" style ="height: 13px" ><asp:Label  CssClass="agecnycodeclasspunehead" ID="lblcgst" runat ="server"></asp:Label>&nbsp<asp:Label ID="Label22"  CssClass="agecnycodeclasspune" runat="server"> <b>%</b></asp:Label></td>
     <td align="right" style="height: 13px"><asp:Label ID="Label23"  CssClass="dateclasspune" runat="server" align="center"></asp:Label></td>
 </tr>
     <tr  id="tr8" runat="server">
 
     <td align="left" style ="height: 13px" ><asp:Label  CssClass="agecnycodeclasspunehead" ID="lblsgst" runat ="server"></asp:Label>&nbsp<asp:Label ID="Label26"  CssClass="agecnycodeclasspune" runat="server"> <b>%</b></asp:Label></td>
     <td align="right" style="height: 13px"><asp:Label ID="Label27"  CssClass="dateclasspune" runat="server" align="center"></asp:Label></td>
 </tr>
     <tr  id="tr9" runat="server">
 
     <td align="left" style ="height: 13px" ><asp:Label  CssClass="agecnycodeclasspunehead" ID="lbligst" runat ="server"></asp:Label>&nbsp<asp:Label ID="Label30"  CssClass="agecnycodeclasspune" runat="server"> <b>%</b></asp:Label></td>
     <td align="right" style="height: 13px"><asp:Label ID="Label31"  CssClass="dateclasspune" runat="server" align="center"></asp:Label></td>
 </tr>
     <tr id="tr10" runat="server">

     <td align="left" style ="height:13px;" ><asp:Label  CssClass="agecnycodeclasspunehead" ID="lblcess" runat ="server"></asp:Label>&nbsp<asp:Label ID="Label34"  CssClass="agecnycodeclasspune" runat="server"> <b>%</b></asp:Label></td>
     <td align="right" style="height: 13px;" ><asp:Label ID="Label35"  CssClass="dateclasspune" runat="server" ></asp:Label></td>
 </tr> 
        <tr style="border-bottom:solid 1px black">
            <td><asp:Label CssClass="agecnycodeclasspunehead" ID="lblnetpayable" runat ="server"></asp:Label></td>
            <td align=right><asp:Label CssClass="dateclasspune" ID="netpay" runat ="server"></asp:Label></td>
            
        </tr>
           
  <tr>
        <td style="border-top:solid 1px black;  height:70px" colspan="2">&nbsp;</td>
  </tr>
  <tr valign="bottom">
        <td style="border-bottom:solid 1px black; height: 20px;" valign="bottom" align="center" colspan="2"><b><span style="font-size: 11pt">Advt. Manager /Accountant</span></b></td>
  </tr> 
  <tr>
        <td style="height:50px" colspan="2">
            <strong><span style="font-size: 11pt"></span></strong></td>
  </tr>
   <tr valign="bottom">
        <td style="border-top:solid 1px black; height: 3px;" valign="bottom" align="center" colspan="2"><b><span style="font-size: 11pt"></span></b></td>
  </tr> 
  
  
   </table>
           <strong><span style="border-bottom:solid 1px black">&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; </span></strong></td>
  </tr>
   <tr ><td><table style="border-right:solid 1px black"; cellspacing="0" cellpadding="0" width="500px"><tr>
                 <td align="left" style="height: 19px; width: 101px;"><asp:Label ID="lbinwords" runat="server" CssClass ="agecnycodeclasspunehead" Text="In Words Rupees :"></asp:Label></td>
                 <td align="left" style="height: 19px" ><asp:Label ID="lbwordinrupees" runat="server" CssClass ="dateclasspune" ></asp:Label></td>
                 </tr>  </table>
                 </td>         
  <td style="border-top:solid 1px black"; "font-size: 11pt">&nbsp; &nbsp; &nbsp;&nbsp;<b> Customer Signature</b></td></tr>
  </table>
    
<table width="690px" cellspacing="0" cellpadding="0" >
<tr >
<td colspan="5" style="font-size:13px" height=40px><asp:Label ID="lblmatter" runat ="server" Width="675px" Height="70px"></asp:Label>
    </td>
</tr>
<tr>
<td align="left" style="height: 15px"><asp:Label CssClass="agecnycodeclasspunehead" ID="lbemail" runat ="server" Width="58px"></asp:Label></td>
<td style="width: 232px; height: 15px;" align="center">    
    <asp:Label CssClass="dateclasspune" ID="lbemailtxt" runat ="server" Width="328px"></asp:Label></td>
<td style="width:30; height: 15px;"></td>
<td align="right" style="height: 15px"; ><asp:Label CssClass="dateclasspune" ID="lbpune" runat ="server" Width=70px></asp:Label></td>
<td style="width:50; height: 15px;"><asp:Label CssClass="dateclasspune" ID="lbpunetxt" runat ="server"></asp:Label></td>

</tr>
</table>

</td>
</tr></table>
</p> 
 <table><tr><td style="height:10px;"></td></tr></table>
</div>