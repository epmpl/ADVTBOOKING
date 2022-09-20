<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RCB.ascx.cs" Inherits="RCB" %>
<link href="css/StyleSheet.css" type="text/css" rel="Stylesheet" />
<div id="showtable" runat="server" style="padding-left:40px; padding-top:6px;border:none;display:block;z-index:0;">
   
    <table style="border:solid 1px black" cellspacing="0" cellpadding="0"><tr><td style="width: 690px">




 <table  style="border-bottom:solid 1px black;vertical-align:top;" width="690px" cellspacing="0" cellpadding="0" >
 <tr>
     <td  valign="bottom" align ="center" style="height:40px;" ><div id="lblimg" runat="server" style="margin-top :15px;width:150px;" height="30" width="70" ></div></td><%--<img src="Images/pune.jpg" height ="40px"/>--%>
     <td  valign ="middle"  align ="center" style="height:40px;" ><asp:Label ID="lblpublications" runat ="server" Font-Bold="True" Font-Names="Times New Roman" Font-Size="20px"></asp:Label></td>
     <td  valign ="middle"  align ="center" style="height:40px;" ><u><asp:Label ID="Label1" runat ="server" Text="Receipt-Cum-Bill" Font-Bold="True" Font-Names="Verdana" Font-Size="14px"></asp:Label>
         </u><br />
         <asp:Label ID="lbbilltype" runat ="server" CssClass="dateclasspune" Font-Bold="True" Font-Names="Times New Roman" Font-Size="14px"></asp:Label></td>
 </tr>
 
 <tr>
     <td valign ="top" align ="center"  style="border-bottom:solid 1px black;font-size:14px; height: 17px;"></td>
    <td valign ="top" align ="LEFT" colspan="2" style="border-bottom:solid 1px black;font-size:14px; height: 17px;">
    <asp:Label ID="lbcompaddress" runat ="server" CssClass="dateclasspune"></asp:Label></td>
    
 </tr>
 </table>
 <table width="690px" cellspacing="0" cellpadding="0" style="border-bottom:solid 1px black">
 <tr>
 <td>
 <table width="500px" cellspacing="0" cellpadding="0">
 <tr >
 <td style="width:100px"><asp:Label CssClass="agecnycodeclasspunehead" ID="agencytxt" runat ="server" Font-Size="8"></asp:Label></td> 
 <td  ><asp:Label CssClass="dateclasspune" ID="agddxt" runat ="server" Font-Size="8"></asp:Label></td>
 </tr>
 <tr>
 <td style="width:100px; border-top:solid 1px black;"><asp:Label CssClass="agecnycodeclasspunehead" ID="lbclientadd" runat ="server" Font-Size="8"></asp:Label></td>
 <td style="border-top:solid 1px black;"><asp:Label CssClass="dateclasspune" ID="lbaddress" runat ="server" Font-Size="8"></asp:Label></td>
 </tr>

 <tr>
 <td style="width:100px"><asp:Label CssClass="agecnycodeclasspunehead" ID="lbclientna" runat ="server" Font-Size="8"></asp:Label></td>
 <td ><asp:Label CssClass="dateclasspune" ID="txtcliname" runat ="server" Font-Size="8"></asp:Label></td>
 </tr>
 <tr>
  <td style="width:100px"><asp:Label CssClass="agecnycodeclasspunehead" ID="lbcap" runat ="server" Font-Size="8"></asp:Label></td>
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
<td><asp:Label CssClass="agecnycodeclasspunehead" ID="Label2" runat ="server">Ad Sub Cat:</asp:Label></td>
<td colspan="2"><asp:Label CssClass="dateclasspune" ID="Label3" runat ="server"></asp:Label></td>
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
<td style="width :110px "><asp:Label CssClass="agecnycodeclasspunehead" ID="lbpackagena" runat ="server" Font-Size="8"></asp:Label></td>
<td align="left" ><asp:Label CssClass="dateclasspune" ID="txtpackname" runat ="server" Font-Size="8"></asp:Label></td>
</tr></table>
</td>
<td ><table width ="190px" cellspacing="0" cellpadding="0"><tr>
<td style="width :110px " ><asp:Label CssClass="agecnycodeclasspunehead" ID="lbpackagerate" runat ="server" Font-Size="8"></asp:Label></td>
<td align="left"><asp:Label CssClass="dateclasspune" ID="lbpakgrate" runat ="server" Font-Size="8"></asp:Label></td>
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
 
       <td valign="top" >
        <table  width="190" cellspacing="0" cellpadding="0">
        <tr id="tr1" runat="server">
            <td><asp:Label CssClass="agecnycodeclasspunehead" ID="lbinsertionnumber" runat ="server"></asp:Label> </td>
            <td align="right" ><asp:Label CssClass="dateclasspune" ID="insertiontxt" runat ="server"></asp:Label></td>
            
        </tr>
             <tr id="tr6" runat="server">
            <td style="height: 12px"><asp:Label CssClass="agecnycodeclasspunehead" ID="lbadtd" runat ="server"></asp:Label></td>
            <td align="right" style="height: 12px"><asp:Label CssClass="dateclasspune" ID="lbadtdtxt" runat ="server"></asp:Label></td>
            
        </tr>
        <tr id="tr2" runat="server">
            <td ><asp:Label  ID="lblamount" runat ="server"  CssClass="agecnycodeclasspunehead"></asp:Label></td>
            <td align="right"><asp:Label   ID="txtgrossamt" runat ="server"  CssClass="dateclasspune"></asp:Label></td>
            
        </tr>
        <tr id="tr3" runat="server">
            <td style="height: 12px"><asp:Label CssClass="agecnycodeclasspunehead" ID="lbextpre" runat ="server"></asp:Label></td>
            <td align="right" style="height: 12px"><asp:Label CssClass="dateclasspune" ID="lbextrapre" runat ="server"></asp:Label></td>
            
        </tr>
     
        <tr id="tr4" runat="server">
            <td><asp:Label CssClass="agecnycodeclasspunehead" ID="lbgr" runat ="server"></asp:Label></td>
            <td align="right"><asp:Label CssClass="dateclasspune" ID="txtagr" runat ="server"></asp:Label></td>
            
        </tr>
        <tr id="tr5" runat="server">
            <td><asp:Label CssClass="agecnycodeclasspunehead" ID="lbtrade1" runat ="server"></asp:Label></td>
            <td align="right"><asp:Label CssClass="dateclasspune" ID="txtdiscal" runat ="server"></asp:Label></td>
            
        </tr>

       
         <tr id="tr7" runat="server">
            <td style="height: 12px"><asp:Label CssClass="agecnycodeclasspunehead" ID="lblcashdisc" runat ="server"></asp:Label></td>
            <td align="right" style="height: 12px"><asp:Label CssClass="dateclasspune" ID="lblcashdisctxt" runat ="server"></asp:Label></td>
            
        </tr>
          <tr id="tr8" runat="server">
            <td style="height: 12px"><asp:Label CssClass="agecnycodeclasspunehead" ID="lblbox" runat ="server"></asp:Label></td>
            <td align="right" style="height: 12px"><asp:Label CssClass="dateclasspune" ID="lblboxtxt" runat ="server"></asp:Label></td>
            
        </tr>
        <tr id="tr9" runat="server">
            <td style="height: 12px"><asp:Label CssClass="agecnycodeclasspunehead" ID="lblprevbill" runat ="server"></asp:Label></td>
            <td align="right" style="height: 12px"><asp:Label CssClass="dateclasspune" ID="lblprevbilltxt" runat ="server"></asp:Label></td>
            
        </tr>
        <tr style="border-bottom:solid 1px black" id="tr10" runat="server">
            <td style="border-bottom:solid 1px black;"><asp:Label CssClass="agecnycodeclasspunehead" ID="lblnetpayable" runat ="server"></asp:Label></td>
            <td align="right" style="border-bottom:solid 1px black;"><asp:Label CssClass="dateclasspune" ID="netpay" runat ="server"></asp:Label></td>
            
        </tr>
             <tr>
        <td style="border-top:solid 1px black;  height:12px" colspan="2">&nbsp;</td>
  </tr>
              <tr id="tr11" runat="server">
            <td style="height: 12px" ><asp:Label CssClass="agecnycodeclasspunehead" ID="Label4" runat ="server">Paymode Name:</asp:Label></td>
            <td align="right" style="height: 12px"><asp:Label CssClass="dateclasspune" ID="lblpay" runat ="server"></asp:Label></td>
            
        </tr>
          <tr id="tr12" runat="server">
            <td style="height: 12px"><asp:Label CssClass="agecnycodeclasspunehead" ID="Label6" runat ="server">Cheque No.:</asp:Label></td>
            <td align="right" style="height: 12px"><asp:Label CssClass="dateclasspune" ID="lblchno" runat ="server"></asp:Label></td>
            
        </tr>
        <tr id="tr13" runat="server">
            <td style="height: 12px"><asp:Label CssClass="agecnycodeclasspunehead" ID="Label8" runat ="server">Date:</asp:Label></td>
            <td align="right" style="height: 12px"><asp:Label CssClass="dateclasspune" ID="lblchkdt" runat ="server"></asp:Label></td>
            
        </tr>
        <tr style="border-bottom:solid 1px black" id="tr14" runat="server">
            <td><asp:Label CssClass="agecnycodeclasspunehead" ID="Label10" runat ="server">Bank Name:</asp:Label></td>
            <td align="right"><asp:Label CssClass="dateclasspune" ID="lblbanknm" runat ="server"></asp:Label></td>
            
        </tr>
           
  <tr>
        <td style="border-top:solid 1px black;  height:12px" colspan="2">&nbsp;</td>
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
           <strong><span >&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; </span></strong></td>
  </tr>
   <tr ><td><table style="border-right:solid 1px black"; cellspacing="0" cellpadding="0" width="500px">
   <tr>
                 <td align="left" style="height: 19px; width: 101px; border-top:solid 1px black;"><asp:Label ID="lblcat" runat="server" CssClass ="agecnycodeclasspunehead"    Text="Category3        :"></asp:Label></td>
                 <td align="left" style="height: 19px; width: 101px; border-top:solid 1px black; " ><asp:Label ID="lblcatdata" runat="server" CssClass ="dateclasspune" ></asp:Label></td>
                 </tr>
        <tr>
                 <td align="left" style="height: 19px; width: 101px; border-top:solid 1px black;"><asp:Label ID="Label5" runat="server" CssClass ="agecnycodeclasspunehead"    Text="Category4       :"></asp:Label></td>
                 <td align="left" style="height: 19px; width: 101px; border-top:solid 1px black; " ><asp:Label ID="Label7" runat="server" CssClass ="dateclasspune" ></asp:Label></td>
                 </tr>
   <tr>
                 <td align="left" style="height: 19px; width: 101px; border-top:solid 1px black;"><asp:Label ID="lbinwords" runat="server" CssClass ="agecnycodeclasspunehead" Text="In Words Rupees :"></asp:Label></td>
                 <td align="left" style="height: 19px; border-top:solid 1px black; " ><asp:Label ID="lbwordinrupees" runat="server" CssClass ="dateclasspune" ></asp:Label></td>
                 </tr>  </table>
                 </td>         
  <td  style="border-top:solid 1px black"; "font-size: 11pt;" valign="middle">&nbsp; &nbsp;<b>Customer Signature</b></td></tr>
  </table>
    
<table width="690px" cellspacing="0" cellpadding="0" >
<tr >
<td colspan="5" style="font-size:13px" height=40px><asp:Label ID="lblmatter" runat ="server" Width="675px" Height="70px"></asp:Label>
    </td>
</tr>
<tr>
<td align="left" style="height: 15px; border-top:solid 1px black;"><asp:Label CssClass="agecnycodeclasspunehead" ID="lbemail" runat ="server" Width="58px"></asp:Label></td>
<td style="width: 232px; height: 15px; border-top:solid 1px black;" align="center">    
    <asp:Label CssClass="dateclasspune" ID="lbemailtxt" runat ="server" Width="328px"></asp:Label></td>
<td style="width:30; height: 15px;"></td>
<td align="right" style="height: 15px; border-top:solid 1px black;" ><asp:Label CssClass="dateclasspune" ID="lbpune" runat ="server" Width=70px></asp:Label></td>
<td style="width:50; height: 15px; border-top:solid 1px black;"><asp:Label CssClass="dateclasspune" ID="lbpunetxt" runat ="server"></asp:Label></td>

</tr>
</table>

</td>
</tr></table>

 <table><tr><td style="height:10px;"></td></tr></table>
</div>