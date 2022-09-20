<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Abp_bill.ascx.cs" Inherits="Abp_bill" %>
<link href="css/pratidin_bill.css" type="text/css" rel="Stylesheet" />


<head>
<title></title>
<script type="text/javascript"  language="javascript" src="javascript/billing.js"></script>

    <style type="text/css">
        .style1
        {
            width: 63px;
        }
    </style>

</head>
<p  id="P1" style="page-break-after:always;">

<table style="padding-left:50px">
<tr >
    <td  valign ="top"  align ="center" style="width:640px;padding-left:60px" ><b><asp:Label  ID="line" runat ="server" ></asp:Label></b></td>
    <td  valign ="top"  align ="center" ></td>
    </tr>
<tr>
    <td  valign ="top"  align ="center" style="width:640px;padding-left:60px" ><b><asp:Label CssClass="agecnycodeclasspunehead" ID="lbcompanynametxt1" runat ="server" Font-Names="Times New Roman" Font-Size="16pt"></asp:Label></b></td>
    <td  valign ="top"  align ="center" ></td>
    </tr>
 <tr style="height:30PX;">  
    <td  width="640px" valign ="top"  align ="center"  style="font-size:14px; padding-left:60px">
    <asp:Label   ID="lbwalujadd2" runat ="server" ></asp:Label></td>
    </tr>
 </table>
 
 <table style="padding-left:50px">
 <tr>
 <td style="height:50PX;"></td>
 </tr>
 </table>
 
<table  style="padding-left:50px" cellspacing="0" cellpadding="0"  width="660px" >
<tr>
<td style="width: 660px" valign ="top">

 <table width="660px;"  cellspacing="0" cellpadding="0"  style="border:solid 1px black;">
 <tr style="height:125px;"><td style="width:50px;padding-top:20px;padding-left:5px;" valign="top"><asp:Label CssClass="dataname" ID="lblnameadd" runat ="server"><b>FROM: </b></asp:Label></td>
 
 <td style="width:200px;" valign="middle">
 <table cellpadding="0" cellspacing="0" style="height: 86px"><tr><td style="font-size:11px;font-family :Verdana;"><asp:Label  CssClass="dataname" ID="lbl1" runat ="server"></asp:Label></td></tr><tr><td style="font-size:11px;font-family :Verdana;"><asp:Label  CssClass="dataname" ID="lbl2" runat ="server"></asp:Label></td></tr><tr><td style="width:200px;"><asp:Label  ID="lbl3" CssClass="dataname" runat ="server"></asp:Label></td></tr><tr><td style="width:200px;"><asp:Label  ID="lbl4" CssClass="dataname" runat ="server"></asp:Label><asp:Label CssClass="dataname" ID="lbl5" runat ="server"></asp:Label></td></tr>
 </table></td>
 
 <td style="width:80px;padding-top:20px;padding-left:5px;border-left:solid 1px black;" valign="top"><asp:Label CssClass="dataname" ID="Label10" runat ="server"><b>TO: </b></asp:Label></td>
  <td style="width:360px;" valign="middle">
  <table cellpadding="0" cellspacing="0" style="padding-top:5px; height: 81px;"><tr><td style="width:200px;"><asp:Label  CssClass="dataname" ID="agddxt" runat ="server"></asp:Label></td></tr><tr><td style="width:200px;"><asp:Label CssClass="dataname" ID="agencyaddtxt" runat ="server"></asp:Label></td></tr><tr><td style="width:200px;"><asp:Label  CssClass="dataname" ID="lbcityname" runat ="server"></asp:Label><asp:Label CssClass="dataname" ID="txtpinno" runat ="server"></asp:Label></td></tr><tr><td style="border-top:solid 1px black;width:80px;"><asp:Label  CssClass="dataname" ID="lblclientname" runat ="server"></asp:Label><asp:Label  CssClass="dataname" ID="lblclientnametxt" runat ="server"></asp:Label></td></tr><tr><td style="width:200px;"><asp:Label CssClass="dataname" ID="agencyaddtxt1" runat ="server"></asp:Label></td></tr><tr><td style="width:200px;"><asp:Label  CssClass="dataname" ID="lbcityname1" runat ="server"></asp:Label></td></tr>
 </table></td>
 
 
 

 
 <td style="width:80px;padding-top:20px;padding-left:5px;border-right:solid 1px black;" valign="top"></td>
 <td style="width:360px; border-left:solid 1px black;" valign="middle">
 <table cellpadding="0" cellspacing="0" style="padding-top:3px; height: 81px;">
 <tr style="width:80px">
 <td ><asp:Label  CssClass="dataname" ID="lblbillno" runat ="server"></asp:Label>
 <asp:Label  CssClass="dataname" ID="lblbillnotxt" runat ="server" ></asp:Label> </td>
 </tr>
 
 <tr style="width:80px">
 <td style="font-size:11px;font-family :Verdana;"><asp:Label  CssClass="dataname" ID="lblbilldate" runat ="server"></asp:Label>
 <asp:Label  CssClass="dataname" ID="lblbilldatetxt" runat ="server"></asp:Label> </td>
 </tr>
 
 <tr style="width:80px">
 <td style="font-size:11px;font-family :Verdana;"><asp:Label  ID="lbllast" CssClass="dataname" runat ="server"></asp:Label>
 <asp:Label  ID="lbllasttxt" CssClass="dataname" runat ="server"></asp:Label>
 </td>
 </tr>
 
 </table></td>
 
 </tr></table>
 
 <table cellpadding="0" width="660px" cellspacing="0" style="border:solid 1px black;margin:10px 0px 0px 0px;"><tr align="center"><td>
 <table width="640px"  cellspacing="0" cellpadding="0" style="border:solid 1px black;margin:10px 0px 0px 0px;">
  <tr align="center"><td>
   <table width="640px"  cellspacing="0" cellpadding="0">
 <tr style="height:20px;">
    <td style="width:120px; border-bottom:solid 1px black; border-right:solid 1px black; height: 20px;" colspan="2" align="center"><asp:Label  CssClass="dataname" ID="lblro"  runat="server"></asp:Label></td><td style="width:90px;border-bottom:solid 1px black; border-right:solid 1px black; height: 20px;" align="center"><asp:Label  CssClass="dataname" ID="lblrodate"  runat="server"></asp:Label></td><td style="width:90px;border-bottom:solid 1px black; border-right:solid 1px black; height: 20px;" align="center"><asp:Label  CssClass="dataname" ID="lblkey"  runat="server"></asp:Label></td><td style="width:90px;border-bottom:solid 1px black; border-right:solid 1px black; height: 20px;" align="center"><asp:Label  CssClass="tabro" ID="lblagno"  runat="server"></asp:Label></td><td style="width:90px;border-bottom:solid 1px black; border-right:solid 1px black; height: 20px;" align="center"><asp:Label  CssClass="tabro" ID="lblcaption"  runat="server"></asp:Label></td><td style="width:90px;border-bottom:solid 1px black; height: 20px;" align="center"><asp:Label  CssClass="dataname" ID="lbldes"  runat="server"></asp:Label></td>
 </tr>
 <tr style="height:40px;">
    <td style="width:120px;border-bottom:solid 1px black; border-right:solid 1px black;" colspan="2" align="center"><asp:Label  CssClass="dataname" ID="txtro"  runat="server"></asp:Label></td><td style="width:90px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="dataname" ID="txtrodate"  runat="server"></asp:Label></td><td style="width:90px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="tabro" ID="txtkey"  runat="server"></asp:Label></td><td style="width:90px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="tabro" ID="txtagno"  runat="server"></asp:Label></td><td style="width:90px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="dataname" ID="txtcaption"  runat="server"></asp:Label></td><td style="width:90px;border-bottom:solid 1px black;" align="center"><asp:Label  CssClass="tabro" ID="txtdes"  runat="server"></asp:Label></td>
 </tr>
 
 <tr style="height:20px;">
 <td style="width:60px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="dataname" ID="lblpublication"  runat="server"></asp:Label></td><td style="width:60px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="dataname" ID="lbldate"  runat="server"></asp:Label></td>
    <%--<td style="width:60px;" align="center"><table cellpadding="0" cellspacing="0"><tr><td style="width:50px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="tabro" ID="lblpublication"  runat="server"></asp:Label></td><td style="width:50px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="tabro" ID="lbldate"  runat="server"></asp:Label></td></tr></table></td>--%>
    <td style="width:90px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center" colspan="2"><asp:Label  CssClass="dataname" ID="lblmeasurement"  runat="server"></asp:Label></td><td style="width:70px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="dataname" ID="lblratetype"  runat="server"></asp:Label></td><td style="width:90px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="tabro" ID="lblrate"  runat="server"></asp:Label></td><td style="width:90px;border-bottom:solid 1px black;" align="center"><asp:Label  CssClass="dataname" ID="lbltotal"  runat="server"></asp:Label></td>
 </tr>
 <tr style="height:40px;">
    <%--<td style="width:100px;" align="center"><table cellpadding="0" cellspacing="0"><tr><td style="width:50px;height:40px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="tabro" ID="txtpublication"  runat="server"></asp:Label></td><td style="width:50px;height:40px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="tabro" ID="txtdate"  runat="server"></asp:Label></td></tr></table></td>--%>
    <td style="width:60px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="dataname" ID="txtpublication"  runat="server"></asp:Label></td><td style="width:60px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="dataname" ID="txtdate"  runat="server"></asp:Label></td><td style="width:90px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center" colspan="2"><asp:Label  CssClass="tabro" ID="txtmeasurement"  runat="server"></asp:Label></td><td style="width:70px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="dataname" ID="txtratetype"  runat="server"></asp:Label></td><td style="width:90px;border-bottom:solid 1px black; border-right:solid 1px black;" align="center"><asp:Label  CssClass="tabro" ID="txtrate"  runat="server"></asp:Label></td><td style="width:90px;border-bottom:solid 1px black;" align="center"><asp:Label  CssClass="tabro" ID="txttotal"  runat="server"></asp:Label></td>
 </tr>
 </table>
   <table width="640px"  cellspacing="0" cellpadding="0">
   <tr style="height:150px;">
       <td style="width:370px; border-right:solid 1px black;" align="left"><asp:Label  CssClass="dataname" ID="lbltorat"  runat="server"><b>Total Amount in Words:</b></asp:Label><br /><br /><asp:Label  CssClass="dataname" ID="txtnetpayword"  runat="server"></asp:Label>
       </td>
           
        <td>
        <table cellpadding="0" cellspacing="0">
        <tr valign="top">
        </tr>
        <tr style="height:50px;">
        <td style="width:370px; border-right:solid 1px black;" align="left">
        <asp:Label  CssClass="dataname" ID="Label3"  runat="server"><b>Less Discount</b></asp:Label>
        <asp:Label  CssClass="dataname" ID="txtless1"  runat="server"></asp:Label>
        </td></tr>
        
        <tr style="height:50px;">
        <td style="width:370px; border-right:solid 1px black;" align="left">
        <asp:Label  CssClass="dataname" ID="Label1"  runat="server"><b>Add Commision</b></asp:Label>
        <asp:Label  CssClass="dataname" ID="txtadd1"  runat="server"></asp:Label></td></tr>
        <tr style="height:50px;">
        <td style="width:370px; border-right:solid 1px black;" align="left">
        <asp:Label  CssClass="dataname" ID="Label4"  runat="server"><b>Net Amounts</b></asp:Label>
        </td></tr>
        </table></td>
        
            <td><table cellpadding="0" cellspacing="0"><tr  valign="top"></tr><tr style="height:40px;"><td style="width:90px;" align="center"><asp:Label  CssClass="tabro" ID="txtless"  runat="server"></asp:Label></td></tr><tr style="height:40px;"><td style="width:90px;" align="center"><asp:Label  CssClass="tabro" ID="txtadd"  runat="server"></asp:Label></td></tr><tr style="height:40px;"><td style="width:90px;" align="center"><asp:Label  CssClass="tabro" ID="txtnetrate"  runat="server"></asp:Label></td></tr></table></td></tr>
            
            
   </table>
   
</td>
</tr>

<tr style="width:100%">
<td colspan="7" style="border-top:solid 1px black;" align="left"><asp:Label  CssClass="tabro" ID="Label2"  runat="server"><b>E & O E</b></asp:Label>
</td>
</tr>
 
 <tr>
 <td style="height:70PX;"></td>
 </tr>
 
<tr style="width:100%">
<td colspan="7"  align="left">
<asp:Label  CssClass="tabro" ID="lblname"  runat="server"></asp:Label>
</td>
</tr>



<tr style="width:100%">
<td colspan="7"  align="left">
<asp:Label  CssClass="tabro" ID="lblname1"  runat="server"></asp:Label>
</td>
</tr>

<tr style="width:100%">
<td colspan="7"  style="border-top:solid 1px black;" align="left">
<asp:Label  CssClass="dataname" ID="lblpanno"  runat="server"></asp:Label>
</td>
</tr>

   
<tr style="width:100%">
<td colspan="7" style="border-top:solid 1px black;" align="left">
<asp:Label  CssClass="dataname" ID="lblnote"  runat="server"></asp:Label>
</td>
</tr>



</table></td></tr>
<tr style="height:40px;"></tr>
</table>
</td></tr>

</table>

<table>
 <tr>
 <td style="height:50PX;"></td>
 </tr>
 </table>


<table style="padding-left:50px">
<tr style="padding-left:50px">
    <td  valign ="top"  align ="center" style="width:640px;padding-left:60px" ><b><asp:Label  ID="line1" runat ="server" ></asp:Label></b></td>
    <td  valign ="top"  align ="center" ></td>
    </tr>
<tr style="padding-left:50px">
    <td  valign ="top"  align ="center" style="width:610px;padding-left:60px" ><b><asp:Label CssClass="agecnycodeclasspunehead" ID="lbcompanynametxt2" runat ="server" Font-Names="Times New Roman" Font-Size="16pt"></asp:Label></b></td>
    <td  valign ="top"  align ="center" ></td>
    </tr>
 <tr style="height:30PX;padding-left:50px">  
    <td  width="640px" valign ="top"  align ="LEFT"  style="font-size:14px; padding-left:60px">
    <asp:Label   ID="lbwalujadd1" runat ="server" ></asp:Label></td>
    </tr>
 </table>

</p>
