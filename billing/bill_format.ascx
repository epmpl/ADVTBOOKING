<%@ Control Language="C#" AutoEventWireup="true" CodeFile="bill_format.ascx.cs" Inherits="bill_format" %>
<%--<link href="css/pratidin_bill.css" type="text/css" rel="Stylesheet" />
<link href="css/billingStyleSheet.css" type="text/css" rel="Stylesheet" />--%>
<link href="css/bill_format.css" type="text/css" rel="Stylesheet" />
<head>
<title></title>
<script type="text/javascript"  language="javascript" src="javascript/bill_format.js"></script>

    <style type="text/css">
        .style1
        {
            width: 63px;
        }
    </style>

</head>

<p  id="P1" style="page-break-after:always;">


<table  style="border-right:solid 1px black;border-top:solid 1px black;border-bottom:solid 1px black;margin-bottom:-4px"  width="660px;"  cellspacing="0" cellpadding="0"> 
<tr>
    <td  valign ="bottom"  align ="left"  >
    <img src="Images/PDEnglishMagazineLogo.jpg" height ="62px"/>
    </td>
    </tr>
    </table>

<table width="660px;"  cellspacing="0" cellpadding="0"  style="border:solid 1px black;"> 
<tr style="height:20px;">
<td align="left" valign ="bottom" >
<asp:Label CssClass="dataname" ID="lblnameadd" runat ="server"><b>TO:</b></asp:Label><br/></td>
 </tr>
</table>
 
<table  border="1"  cellspacing="0" cellpadding="0" style="height:40px" width ="660px"  class ="table1"  >

 
<%--<table width="660px;"  cellspacing="0" cellpadding="0"  style="border:solid 1px black;"> 
--%><tr style="height:125px;">
<td align="left" valign ="top" >
 <table  style="height: 86px" width="300px;">
 <tr><td style="font-size:11px;font-family :Verdana;"><asp:Label  CssClass="dataname" ID="lblagencyname" runat ="server"></asp:Label></td></tr>
 <tr><td style="font-size:11px;font-family :Verdana;"><asp:Label  CssClass="dataname" ID="lblagencyadd1" runat ="server"></asp:Label></td></tr>
 <tr><td style="width:200px;"><asp:Label  ID="lblagencyadd2" CssClass="dataname" runat ="server"></asp:Label></td></tr>
 <tr><td style="width:200px;"><asp:Label  ID="lblcity" CssClass="dataname" runat ="server"></asp:Label></td></tr>
 <tr><td style="width:200px;"><asp:Label CssClass="dataname" ID="lblstate" runat ="server"></asp:Label></td></tr>
 <tr>
 
<td  align="left"class ="newhead1"><label id="lbclient"  runat ="server">Client:</label> 
<asp:Label ID="txtheadoffice"   runat ="server" CssClass="extrasizeclass"></asp:Label></td> 
</tr> 
 
 
 </table>


 <td style="width:50px;padding-top:20px;padding-left:0px;border-right:solid 1px black;"valign="top"></td>
 <td style="width:300px; border-left:solid 1px black;" valign="middle">

 <table cellpadding="0" cellspacing="0" style=" height: 81px;" width="300px;">
 <tr style="width:80px">
 <td><asp:Label  CssClass="dataname" ID="lblinvoiceno" runat ="server"></asp:Label></td>
  <td style="font-size:11px;font-family :Verdana;"><asp:Label  CssClass="dataname" ID="txtinvoiceno" runat ="server" ></asp:Label> </td>
 </tr>
 
 <tr style="width:100px">
 <td style="font-size:11px;font-family :Verdana;"><asp:Label  CssClass="dataname" ID="lblinvoicedate" runat ="server"></asp:Label></td>
 <td style="font-size:11px;font-family :Verdana;"><asp:Label  CssClass="dataname" ID="txtinvoicedate" runat ="server"></asp:Label> </td>
 </tr>
 
 <tr style="width:80px">
 <td style="font-size:11px;font-family :Verdana;"><asp:Label  ID="lblrefno" CssClass="dataname" runat ="server"></asp:Label></td>
 <td style="font-size:11px;font-family :Verdana;"><asp:Label  ID="lblrefnotxt" CssClass="dataname" runat ="server"></asp:Label></td>
 </tr>
 <tr>
 <td style="font-size:11px;font-family :Verdana;"><asp:Label  ID="Lbllzr" CssClass="dataname" runat ="server"></asp:Label></td>
 <td style="font-size:11px;font-family :Verdana;"><asp:Label  ID="lbllzrtxt" CssClass="dataname" runat ="server"></asp:Label></td>
 
 </tr>
 <tr>
 <td  align="left"class ="newhead"><label id="lblrepcode"  runat ="server">Rep.Name:</label> </td> 
<td align ="left"  class="newhead"><asp:Label ID="lblrepnametxt"   runat ="server" CssClass="extrasizeclass"></asp:Label></td>
 
 
 </tr>
 </table>
 </td>
 </td>
 </tr>
 </table>

  <table   cellspacing="0" cellpadding="0"  style="height:40px" width ="660px"  class ="table1"  >
  <tr>
  <td></td>
  </tr>
  </table>
<%--
  <table  border="1"  cellspacing="0" cellpadding="0" width ="660px" class ="table1">
 <tr>
 
<td  align="left"class ="newhead1"><label id="lbclient"  runat ="server">Client:</label> </td> 
<td align ="left"  class="newhead"><asp:Label ID="txtheadoffice"   runat ="server" CssClass="extrasizeclass"></asp:Label></td>
 
 <td  align="left"class ="newhead"><label id="lblrepcode"  runat ="server">Rep.Name:</label> </td> 
<td align ="left"  class="newhead"><asp:Label ID="lblrepnametxt"   runat ="server" CssClass="extrasizeclass"></asp:Label></td>
 
 
 </tr>
 </table>--%>
 
 
 
  <table    style="border-top:solid 1px black;border-bottom:solid 1px black ;height:40px;"  cellspacing="0" cellpadding="0" width ="660px"  class ="table1"  >
 <tr>
<td>
<td style="padding-left:100px"  align="left" class ="newhead1"><label id="lblDetails"  runat ="server">Details:</label> </td> 

 <td  align="right" class ="newhead"><label id="lblAmt"  runat ="server">Amount:</label> </td> 
 
 


 <table cellpadding="0" cellspacing="0" style="height:86px"  width="660px">
 
 <tr>
<td valign ="top" width="660px" >
       <asp:Label  id="dynamictable"  runat ="server"></asp:Label>
      
 
 <tr><td><asp:Label  CssClass="dataname" ID="lblpublication" runat ="server"></asp:Label></td>
  <td align="right" class ="newhead1"><asp:Label ID="amount1" runat ="server" CssClass="extrasizeclass"></asp:Label></td></tr>
 <tr><td style="padding-left:100px;"><asp:Label  CssClass="dataname" ID="lbllang" runat ="server"></asp:Label></td></tr>
 <tr><td style="padding-left:100px;"><asp:Label  ID="lbledition" CssClass="dataname" runat ="server"></asp:Label></td></tr>
 <tr><td style="padding-left:100px;"><asp:Label  ID="lbledition2" CssClass="dataname" runat ="server"></asp:Label></td></tr>
 <tr><td style="padding-left:100px;"><asp:Label  ID="lblpagetype" CssClass="dataname" runat ="server"></asp:Label></td></tr>
 <tr><td style="padding-left:100px;"><asp:Label CssClass="dataname" ID="lblcolor" runat ="server"></asp:Label></td></tr>
 <tr><td style="padding-left:100px;"><asp:Label  ID="lblcaption" CssClass="dataname" runat ="server"></asp:Label>
 <asp:Label ID="txtcaptionname"   runat ="server" CssClass="extrasizeclass"></asp:Label></td></tr>
<tr><td style="width:200px; padding-left:100px;"><asp:Label  ID="lblremark" CssClass="dataname" runat ="server"></asp:Label>
 <asp:Label ID="lblremtxt"   runat ="server" CssClass="extrasizeclass"></asp:Label></tr>
 <tr><td style="width:200px; padding-left:100px;"><asp:Label CssClass="dataname" ID="lblissue" runat ="server"></asp:Label></td></tr>
  </td>
  </tr>
 </table>
 </td>
  </tr>
  </table>
  
  <table   cellspacing="0" cellpadding="0"   style="border-top:solid 1px black;border-bottom:solid 1px black ;height:40px;"  width ="660px"  class ="table1"  >
  <tr>
  <td  align="left" class ="newhead1"><label id="lbltotal"  runat ="server">Total:</label></td> 
  
  <td align="right" class ="newhead1"><asp:Label ID="lbltotaltext"   runat ="server" CssClass="extrasizeclass"></asp:Label></td>
  </tr>
  </table>
   
   
    <table   cellspacing="0" cellpadding="0"   width ="660px"  class ="table1"  >
  <tr>
  
  
  <td  style="padding-left:635px ;width:660px" class ="newhead"><asp:Label ID="lbadtdtxt"   runat ="server" CssClass="extrasizeclass"></asp:Label></td>
  </tr>
  </table>
   
   <table cellpadding="0" cellspacing="0" style="height:35px; width:660px">
   
    
   <tr>
  
  <td  align="right" class ="newhead"><label id="lbldec"  runat ="server"></label></td> 
  
  <td style="padding-left:400px ;width:660px" class ="newhead">Less Discount @  <asp:Label ID="txttradedis1" runat ="server"></asp:Label> </td>
  <td  style="border-bottom:solid 1px black;height:40px;" class ="newhead"><asp:Label ID="txtdiscal"   runat ="server" CssClass="extrasizeclass"></asp:Label></td>
 <td></td>
 <%--<td style="border-bottom:solid 1px black;height:40px;"></td>--%>
 </tr>
  </table>
  
  <table cellpadding="0" cellspacing="0"   width="660px">
  
 <tr>
  <td align="right" class ="newhead" >
  
  <label id="lblbillamt" runat ="server" CssClass="extrasizeclass"></label>
  <td   style="border-top:solid 0px black; border-bottom:solid 0px black"  align="right" class ="newhead"><asp:Label ID="netpay"   runat ="server" CssClass="extrasizeclass"></asp:Label></td>
  </td>
    </tr>
  </table>
  
   <table cellpadding="0" cellspacing="0" style="height:35px" width="660px">
  <td align="left" class ="newhead">Rs.<asp:Label ID="lblrupees" runat ="server" CssClass="extrasizeclass"></asp:Label></td>
  </table>
  <table cellpadding="0" cellspacing="0" style="height: 86px" width="660px">
  <td align="left" class ="newhead" style="width:250px">E.& O.E<label id="Label2"  runat ="server"></label></td> 
  </table> 
 <table cellpadding="0" cellspacing="0" style="height: 86px" width="660px">
 
 <td  align="left"class ="newhead" style="width:450px"><label id="lblcomment"  runat ="server">Company Should not be liable for any special indirect or consequencial damage
whatsover. No claim for damages or labour or other expenses or material
furnished will be allowed unless authrised in writing. All Payments be drawn by
cheque or Draft in favour of Pratiyogita Darpan, Payable at Agra.</label></td>
 


 <td align="right" valign ="top" class ="newhead" style="width:250px"><label id="lblcomment1"  runat ="server">for PRATIYOGITA DARPAN</label></td> 
<tr></tr>
<tr></tr>
 <%--<td  align="right" class ="newhead" style="width:660px"><label id="lbllast"  runat ="server">Biling Department</label></td>
--%>
  </table>
  
<table width="660px;"  cellspacing="0" cellpadding="0" > 
<tr style="height:20px;">
<td align="right" valign ="top" >

<asp:Label CssClass="dataname" ID="lbllast" runat ="server"><b>Biling Department</b></asp:Label><br/></td>
 </tr>
</table>
  </p>
 