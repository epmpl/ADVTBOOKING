<%@ Control Language="C#" AutoEventWireup="true" CodeFile="receipt.ascx.cs" Inherits="receipt" %>
<link href="css/StyleSheet.css" type="text/css" rel="Stylesheet" />
<div style="padding-left:40px; padding-top:20px"><table style="border:solid 1px black" cellpadding="0" cellspacing="0"><tr><td>
     <table  style="border-bottom:solid 1px black" width="610px" cellspacing="0" cellpadding="0" >
 <tr>
     <td  valign ="middle"  align ="center" ><img src="Images/tnie.jpg" height ="40px"/></td>
     <td  valign ="middle"  align ="center" ><b><asp:Label CssClass="agecnycodeclasspunehead" ID="lbcompanynametxt" runat ="server" Font-Names="Times New Roman" Font-Size="17pt"></asp:Label></b></td>
     <td  valign ="middle"  align ="center" ></td>
 </tr>
 
 <tr>
    <td  height="20px" width="70px" valign ="middle"  align ="left"  style="font-size:14px">
    <asp:Label CssClass="agecnycodeclasspunerec1" ID="lbwaluj" runat ="server"></asp:Label></td>
    <td  height="20px" width="610px" valign ="middle"  align ="left"  style="font-size:14px">
    <asp:Label  CssClass="agecnycodeclasspunerec" ID="lbwalujadd" runat ="server" ></asp:Label></td>
<%--     <td valign ="middle"  align ="left" colspan="2" style="font-size:14px"><asp:Label  CssClass="agecnycodeclasspunerec" ID="lbwalujadd" runat ="server" ></asp:Label></td>--%>

 </tr>
 <tr>
    <td colspan="2" height="20px" valign ="middle"  align ="left" style="font-size:14px"><asp:Label CssClass="agecnycodeclasspunerec1" ID="lbbranch" runat ="server"></asp:Label><asp:Label  CssClass="agecnycodeclasspunerec" ID="lbbranchtxt" runat ="server" Font-Size="Small"></asp:Label></td>
<%--    <td valign ="middle"  align ="left" colspan="2" style="font-size:14px"><asp:Label  CssClass="agecnycodeclasspunerec" ID="lbbranchtxt" runat ="server"></asp:Label></td>--%>

 </tr>
 </table>
 
 
 <table width="610px" style="border-bottom: solid 1px black;border-top:solid 1px black;" cellpadding="0" cellspacing="0">
 <tr>
 <td style="width: 200px; "></td>
 <td style="width: 210px;height:25px;font-size:20px;" align="center" ><b style="font-family: Verdana">RECEIPT</b></td>
 <td style="width: 200px; " align="right"><asp:Label CssClass="agecnycodeclasspunerec" ID="lbbilltype" runat ="server" Font-Size="Medium"></asp:Label></td>
 </tr>
 </table>
 
 <table width="610px" cellpadding="0" cellspacing="0">
 <tr style="width:28px">
 
 <td style="width:410px"><asp:Label CssClass="agecnycodeclasspunerec1" ID="lbpro" runat ="server"></asp:Label> 
    <asp:Label CssClass="agecnycodeclasspunerec" ID="lbprotxt" runat ="server"></asp:Label> </td>
 <td style="width:200px"><asp:Label CssClass="agecnycodeclasspunerec1" ID="lbdate" runat ="server"></asp:Label> 
 <asp:Label CssClass="agecnycodeclasspunerec" ID="lbdatetxt" runat ="server"></asp:Label> </td>

 </tr>
  <tr style="width:25px">
  
 <td style="width:410px; height: 19px;"><asp:Label CssClass="agecnycodeclasspunerec1" ID="Label6" runat ="server"></asp:Label> 
<asp:Label CssClass="agecnycodeclasspunerec1" ID="Label7" runat ="server"></asp:Label> </td>
 <td style="width:200px; height: 19px;"><asp:Label CssClass="agecnycodeclasspunerec1" ID="lbrec" runat ="server" Font-Size="Small"></asp:Label> 
<asp:Label CssClass="agecnycodeclasspunerec" ID="lbrectxt" runat ="server" Font-Size="Small" Font-Names="Times New Roman"></asp:Label> </td>

 </tr>
  </table>
  
  
  <table style="width:610px" cellpadding="0" cellspacing="0">
  <tr style="height:25px">
   <td style="width:110px"><asp:Label CssClass="agecnycodeclasspunerec1" ID="lbrecevied" runat ="server"></asp:Label> </td>
   <td style="width:10px"><asp:Label CssClass="agecnycodeclasspune" ID="lbsym" runat ="server" Text=":"></asp:Label> </td>
   <td style="border-bottom:solid 1px black" colspan=4><asp:Label CssClass="agecnycodeclasspunerec" ID="lbreceviedtxt" runat ="server"></asp:Label>&nbsp;</td>
  </tr>
 
  <tr style="height:25px">
   <td style="width:110px"><asp:Label CssClass="agecnycodeclasspunerec1" ID="lbclient" runat ="server"></asp:Label> </td>
   <td style="width:10px"><asp:Label CssClass="agecnycodeclasspune" ID="lbsym1" runat ="server" Text=":"></asp:Label> </td>
   <td style="border-bottom:solid 1px black" colspan=4><asp:Label CssClass="agecnycodeclasspunerec" ID="lbclienttxt" runat ="server"></asp:Label>&nbsp; </td>
  </tr>
  <tr style="height:25px">
   <td style="width:110px"><asp:Label CssClass="agecnycodeclasspunerec1" ID="lbpay" runat ="server"></asp:Label> </td>
   <td style="width:10px"><asp:Label CssClass="agecnycodeclasspune" ID="lbsym2" runat ="server" Text=":"></asp:Label> </td>
   <td style="border-bottom:solid 1px black; width: 54px;"><asp:Label CssClass="agecnycodeclasspunerec" ID="lbpaytxt" runat ="server"></asp:Label>&nbsp; </td>
   <td style="border-bottom:solid 1px black; width: 133px;"><asp:Label CssClass="agecnycodeclasspunerec" ID="lblChqNo" runat ="server"></asp:Label>
   <asp:Label CssClass="agecnycodeclasspunerec" ID="txtChequeNo" runat ="server"></asp:Label></td>
     
   <td style="border-bottom:solid 1px black; width: 141px;"><asp:Label CssClass="agecnycodeclasspunerec" ID="lblChqDt" runat ="server"></asp:Label>
   <asp:Label CssClass="agecnycodeclasspunerec" ID="txtChequeDate" runat ="server"></asp:Label></td>
       
   <td style="border-bottom:solid 1px black"><asp:Label CssClass="agecnycodeclasspunerec" ID="lblBank" runat ="server"></asp:Label>
   <asp:Label CssClass="agecnycodeclasspunerec" ID="txtBankName" runat ="server"></asp:Label></td>
   
  
  </tr>  
  
   
  <tr style="height:25px">
   <td style="width:110px"><asp:Label CssClass="agecnycodeclasspunerec1" ID="lbbill" runat ="server"></asp:Label> </td>
   <td style="width:10px"><asp:Label CssClass="agecnycodeclasspune" ID="lbsym3" runat ="server" Text=":"></asp:Label> </td>
   <td style="border-bottom:solid 1px black"  colspan=4><asp:Label CssClass="agecnycodeclasspunerec" ID="lbbilltxt" runat ="server"></asp:Label>&nbsp; </td>
  </tr>
  
  <tr style="height:25px">
   <td style="width:110px"><asp:Label CssClass="agecnycodeclasspunerec1" ID="lbinword" runat ="server"></asp:Label> </td>
   <td style="width:10px"><asp:Label CssClass="agecnycodeclasspune" ID="lbsym4" runat ="server" Text=":"></asp:Label> </td>
   <td style="border-bottom:solid 1px black" colspan=4><asp:Label CssClass="agecnycodeclasspunerec" ID="lbinwordtxt" runat ="server"></asp:Label>&nbsp; </td>
  </tr>
  </table>
 
 
 <table style="width:610px" cellpadding="0" cellspacing="0">
 <tr style="height:25px">
 <td style="width:120px; "></td>
  <td style="width:140px; "></td>
<td style="width:150px;" align="right"><asp:Label CssClass="agecnycodeclasspunerec1" ID="rs" runat ="server" Text="Rs." Font-Size="Small" Height="16px"></asp:Label></td>
 <td style="width:140px;border-bottom:solid 1px black;border-left:solid 1px black;height:25px;"><asp:Label CssClass="agecnycodeclasspunerec" ID="lbamounttxt" runat ="server" Font-Size="Small" ></asp:Label></td>
  </tr>
 <tr style="height:32px">
 
<td valign="bottom"  style="width:160px; height: 32px;"><asp:Label CssClass="agecnycodeclasspunerec1" ID="lbcustsign" runat ="server" ></asp:Label></td>
<td valign="bottom" align="right" style="width:160px; height: 32px;"><asp:Label CssClass="agecnycodeclasspunerec1" ID="lbsign" runat ="server" ></asp:Label></td>
<td valign="bottom" colspan="2" align="right" style="height: 32px" ><asp:Label CssClass="agecnycodeclasspunerec1" ID="lbsubj" runat ="server" ></asp:Label></td>

 </tr>
 
 </table></td></tr>
 </table>
 <table><tr><td style="height:50px;"></td></tr></table>
    </div>