<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RCB_RP.ascx.cs" Inherits="RCB_RP" %>
<link href="css/StyleSheet.css" type="text/css" rel="Stylesheet" />
<style type="text/css">
    .style1
    {
        width: 501px;
    }
</style>
<div id="showtable" style="padding-left:40px; padding-top:6px;border:none;display:block;z-index:0;">
<p style="page-break-after:always"> 
<table style="border:solid 1px black" cellspacing="0" cellpadding="0"><tr><td style="width: 690px">




 <table  style="border-bottom:solid 1px black;vertical-align:top;" width="690px" cellspacing="0" cellpadding="0" >
 <tr>
     <td  valign="bottom" align ="center" style="height:40px;" ><div id="divimg" runat="server" ></div></td><%--<img src="Images/pune.jpg" height ="40px"/>--%>
     <td  valign ="middle"  style="height:40px;"  id="divimglogo" runat="server" align ="center" ><asp:Label ID="lblpublications" runat ="server" Font-Bold="True" Font-Names="Times New Roman" Font-Size="20px"></asp:Label></td>
     <td  valign ="middle"  align ="center" style="height:40px;" ><u><asp:Label ID="Label1" runat ="server" Text="Receipt-Cum-Bill" Font-Bold="True" Font-Names="Verdana" Font-Size="14px"></asp:Label>
         </u><br />
         <asp:Label ID="lbbilltype" runat ="server" CssClass="dateclasspune" Font-Bold="True" Font-Names="Times New Roman" Font-Size="14px"></asp:Label></td>
 </tr>
 
 <tr>
    <td valign ="top" align ="center" colspan="2" style="font-size:14px; height: 17px;">
    <asp:Label ID="lbcompaddress" runat ="server" CssClass="dateclasspune"></asp:Label></td>
    
 </tr>
 </table>
 <table width="690px" cellspacing="0" cellpadding="0" style="border-bottom:solid 1px black">
 <tr>
 <td>
 <table width="500px" cellspacing="0" cellpadding="0">
 <tr >
 <td style="width:140px"><asp:Label CssClass="agecnycodeclasspunehead" ID="agencytxt" runat ="server" Font-Size="8"></asp:Label></td> 
 <td  ><asp:Label CssClass="dateclasspune" ID="agddxt" runat ="server" Font-Size="8"></asp:Label></td>
 </tr>
 <tr>
 <td style="width:140px"><asp:Label CssClass="agecnycodeclasspunehead" ID="lbclientadd" runat ="server" Font-Size="8"></asp:Label></td>
 <td ><asp:Label CssClass="dateclasspune" ID="lbaddress" runat ="server" Font-Size="8"></asp:Label></td>
 </tr>

 <tr>
 <td style="width:140px"><asp:Label CssClass="agecnycodeclasspunehead" ID="lbclientna" runat ="server" Font-Size="8"></asp:Label></td>
 <td ><asp:Label CssClass="dateclasspune" ID="txtcliname" runat ="server" Font-Size="8"></asp:Label></td>
 </tr>
 <tr>
  <td style="width:140px"><asp:Label CssClass="agecnycodeclasspunehead" ID="lbcap" runat ="server" Font-Size="8"></asp:Label></td>
 <td ><asp:Label CssClass="dateclasspune" ID="lbcaption" runat ="server" Font-Size="8"></asp:Label></td>
</tr>
</table></td>
<td>
<table width="190px" cellspacing="0" cellpadding="0">
<tr>
 <td ><asp:Label CssClass="agecnycodeclasspunehead" ID="lbrcb" runat ="server" ></asp:Label></td>
 <td ><asp:Label CssClass="dateclasspune" ID="lbrcbtxt" runat ="server" ></asp:Label></td>
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
<%--<table width="690px" cellspacing="0" cellpadding="0" style="border-bottom:solid 1px black" >
<tr>
<td >
<table width ="500px" cellspacing="0" cellpadding="0"><tr>
<td style="width :110px "><asp:Label CssClass="agecnycodeclasspunehead" ID="lbpackagena" runat ="server" Font-Size="8"></asp:Label></td>
<td align="left" ><asp:Label CssClass="dateclasspune" ID="txtpackname" runat ="server" Font-Size="8"></asp:Label></td>
</tr></table>
</td>
<td ><table width ="190px" cellspacing="0" cellpadding="0"><tr>
<td style="width :110px " ><asp:Label CssClass="agecnycodeclasspunehead" ID="lbpackagerate" runat ="server" Font-Size="8"></asp:Label></td>
<td align="left"><asp:Label CssClass="dateclasspune" ID="lbpakgrate" runat ="server" Font-Size="8"></asp:Label></td>
</tr></table></td>
</tr></table>--%>


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
 
       <td valign="top" >
        <table  width="190" cellspacing="0" cellpadding="0" style="">
        <tr id="tr1" runat="server">
            <td><asp:Label CssClass="agecnycodeclasspunehead" ID="lbinsertionnumber" runat ="server"></asp:Label> </td>
            <td align="right" ><asp:Label CssClass="dateclasspune" ID="insertiontxt" runat ="server"></asp:Label></td>
            
        </tr>
         <tr>
            <td style="height: 12px;padding-left:2px;"><asp:Label CssClass="agecnycodeclasspunehead" ID="lblextra" runat ="server"></asp:Label></td>
            <td align="right" style="height: 12px"><asp:Label CssClass="dateclasspune" ID="txtextra" runat ="server"></asp:Label></td>
            
        </tr>
        <tr id="tr2" runat="server">
            <td style="padding-left:2px;"><asp:Label  ID="lblamount" runat ="server"  CssClass="agecnycodeclasspunehead"></asp:Label></td>
            <td align="right"><asp:Label   ID="txtgrossamt" runat ="server"  CssClass="dateclasspune"></asp:Label></td>
            
        </tr>
       <%-- <tr id="tr3" runat="server">
            <td style="height: 12px"><asp:Label CssClass="agecnycodeclasspunehead" ID="lbextpre" runat ="server"></asp:Label></td>
            <td align="right" style="height: 12px"><asp:Label CssClass="dateclasspune" ID="lbextrapre" runat ="server"></asp:Label></td>
            
        </tr>--%>
     
       <%-- <tr id="tr4" runat="server">
            <td><asp:Label CssClass="agecnycodeclasspunehead" ID="lbgr" runat ="server"></asp:Label></td>
            <td align="right"><asp:Label CssClass="dateclasspune" ID="txtagr" runat ="server"></asp:Label></td>
            
        </tr>--%>
       <%-- <tr id="tr5" runat="server">
            <td><asp:Label CssClass="agecnycodeclasspunehead" ID="lbtrade1" runat ="server"></asp:Label></td>
            <td align="right"><asp:Label CssClass="dateclasspune" ID="txtdiscal" runat ="server"></asp:Label></td>
            
        </tr>

        <tr id="tr6" runat="server">
            <td style="height: 12px"><asp:Label CssClass="agecnycodeclasspunehead" ID="lbadtd" runat ="server"></asp:Label></td>
            <td align="right" style="height: 12px"><asp:Label CssClass="dateclasspune" ID="lbadtdtxt" runat ="server"></asp:Label></td>
            
        </tr>
         <tr id="tr7" runat="server">
            <td style="height: 12px"><asp:Label CssClass="agecnycodeclasspunehead" ID="lblcashdisc" runat ="server"></asp:Label></td>
            <td align="right" style="height: 12px"><asp:Label CssClass="dateclasspune" ID="lblcashdisctxt" runat ="server"></asp:Label></td>
            
        </tr>--%>
          <tr id="tr8" runat="server">
            <td style="height: 12px;padding-left:2px;"><asp:Label CssClass="agecnycodeclasspunehead" ID="lblbox" runat ="server"></asp:Label></td>
            <td align="right" style="height: 12px"><asp:Label CssClass="dateclasspune" ID="lblboxtxt" runat ="server"></asp:Label></td>
            
        </tr>
        <tr>
            <td style="height: 12px;padding-left:2px;"><asp:Label CssClass="agecnycodeclasspunehead" ID="lblbullot" runat ="server"></asp:Label></td>
            <td align="right" style="height: 12px"><asp:Label CssClass="dateclasspune" ID="txtbullot" runat ="server"></asp:Label></td>
            
        </tr>
       
         <tr>
            <td style="height: 12px;padding-left:2px;"><asp:Label CssClass="agecnycodeclasspunehead" ID="lbltrans" runat ="server"></asp:Label></td>
            <td align="right" style="height: 12px"><asp:Label CssClass="dateclasspune" ID="txtranscrg" runat ="server"></asp:Label></td>
            
        </tr>
         <tr>
            <td style="height: 12px;padding-left:2px;"><asp:Label CssClass="agecnycodeclasspunehead" ID="lblextramt" runat ="server"></asp:Label></td>
            <td align="right" style="height: 12px"><asp:Label CssClass="dateclasspune" ID="txtextramt" runat ="server"></asp:Label></td>
            
        </tr>
       <%-- <tr id="tr9" runat="server">
            <td style="height: 12px"><asp:Label CssClass="agecnycodeclasspunehead" ID="lblprevbill" runat ="server"></asp:Label></td>
            <td align="right" style="height: 12px"><asp:Label CssClass="dateclasspune" ID="lblprevbilltxt" runat ="server"></asp:Label></td>
            
        </tr>--%>
        <tr style="border-bottom:solid 1px black" id="tr10" runat="server">
            <td style="padding-left:2px;"><asp:Label CssClass="agecnycodeclasspunehead" ID="lblnetpayable" runat ="server"></asp:Label></td>
            <td align="right"><asp:Label CssClass="dateclasspune" ID="netpay" runat ="server"></asp:Label></td>
            
        </tr>
           
    <tr>
        <td style="border-top:solid 1px black;font-family: Verdana; font-size: 10px; font-weight: bold;padding-left:2px;padding-top:2px;"  colspan="2">For RPPL</td>
  </tr>
  <%--<tr valign="bottom">
        <td style=" height: 20px;" valign="bottom" align="center" colspan="2">
            <b><span style="font-size: 11pt">Cashier</span></b></td>
  </tr> --%>
 <%-- <tr>
        <td style="height:50px" colspan="2">
            <strong><span style="font-size: 11pt"></span></strong></td>
  </tr>--%>
<%--   <tr valign="bottom">
        <td style="border-top:solid 1px black; height: 3px;" valign="bottom" align="left" colspan="2"><b><span style="font-size: 11pt"></span></b></td>
  </tr> --%>
  
  
   </table>
           <strong><span ></span></strong></td>
  </tr>
   <tr ><td><table style="border-right:solid 1px black; width: 501px;"; 
           cellspacing="0" cellpadding="0">
   <tr>
                 <td align="left" style="height: 19px; width: 101px; border-top:solid 1px black;"><asp:Label ID="lblcat" runat="server" CssClass ="agecnycodeclasspunehead"    Text="Category        :"></asp:Label></td>
                 <td align="left" style="height: 19px; border-top:solid 1px black; " ><asp:Label ID="lblcatdata" runat="server" CssClass ="dateclasspune" ></asp:Label></td>
                 </tr>
   <tr>
                 <td align="left" style="height: 19px; width: 101px; border-top:solid 1px black;"><asp:Label ID="lbinwords" runat="server" CssClass ="agecnycodeclasspunehead" Text="In Words Rupees :"></asp:Label></td>
                 <td align="left" style="height: 19px; border-top:solid 1px black; " ><asp:Label ID="lbwordinrupees" runat="server" CssClass ="dateclasspune" ></asp:Label></td>
                 </tr>  </table>
                 </td>         
  <td  style="font-size: 11pt;" valign="bottom" align="center">&nbsp; &nbsp;<b><span 
          style="font-size: 11pt">Cashier</span></b></td></tr>
  </table>
<table width="690px" cellspacing="0" cellpadding="0" >
<tr>
<td align="left" class="style1" style="font-family: verdana; font-size: 9px">NOTE : 
    1. Objection, if any, should be loaded within 5 days from the date of published.</td><td align="right" 
                                    style="font-family: verdana; font-size: 9px">&nbsp;</td>
                                <td>
                                    &nbsp;</td>
</tr></table>

 <table width="690px" cellspacing="0" cellpadding="0" >
<tr >
<td align="left" style="font-family: verdana; font-size: 9px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    2. The advertisement accepted is subject to the approval of the publication who 
    may reject the&nbsp;</td>
</tr>
<tr >
<td align="left" style="font-family: verdana; font-size: 9px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    advertisement without assigning any reason thereof.</td>
</tr>
<tr >
<td align="left" style="font-family: verdana; font-size: 9px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    3. To be published in Hindi/English only.&nbsp;</td>
</tr>
<tr >
<td align="left" style="font-family: verdana; font-size: 9px; font-weight: bold;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    4. &nbsp;Due to any reason, if any advertisement could not publish on desired date, 
    it would be published in the</td>
</tr>
<tr >
<td align="left" style="font-family: verdana; font-size: 9px; font-weight: bold">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    very next available edition. No confirmation or gurantee could be given for any 
    specific date.&nbsp;</td>
</tr>
<tr >
<td align="left" style="font-family: verdana; font-size: 9px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    5. please bring cash memo while collecting the box letters.&nbsp;</td>
</tr>
<tr >
<td align="left" style="font-family: verdana; font-size: 9px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    6. For any dispute the jurisdiction of the competent court
    <asp:Label ID="lblbranch" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
    &nbsp;.</td>
</tr>
<%--<tr >
<td align="right" style="font-family: verdana; font-size: 11pt"><b>Customer 
    Signature</b></td>
</tr>--%>
</table>
<table width="690px" cellspacing="0" cellpadding="0" >
<tr >
<td colspan="3" >
    <div style="border-style: solid; border-color: #C0C0C0; width: 200px; font-size:15px;" 
        runat="server" id="lblmatter"></div>
    </td>
<td align="right" style="font-family: verdana; font-size: 11pt" colspan="2" valign="bottom"><b>Customer 
    Signature</b></td>
</tr>

</table>

</td>
</tr></table>

</p> 
 <table><tr><td style="height:10px;"></td></tr></table>
</div>