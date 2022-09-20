<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RCB_V.ascx.cs" Inherits="RCB_V" %>


<%--<link href="css/billingStyleSheet.css" type="text/css" rel="Stylesheet" />--%>
<link rel="stylesheet" type="text/css" href="css/booking.css" />
<head>
<title>PUNE FINAL BILL</title>

    <style type="text/css">
        .table1
        {
            width: 813px;
        }
        .style20
        {
            font-family: Verdana;
            color: Black;
            font-size: 12px;
            height: 19px;
        }
        .style33
        {
            width: 744px;
        }
        .style63
        {
            width: 153px;
        }
        .style71
        {
            width: 128px;
        }
        .style72
        {
            width: 143px;
        }
        .style74
        {
            height: 85px;
        }
        .style75
        {
            width: 842px;
        }
        .style76
        {
            width: 436px;
        }
        .style77
        {
            height: 19px;
        }
        .style78
        {
            width: 436px;
            height: 19px;
        }
        .style79
        {
            height: 19px;
            width: 169px;
        }
        .style80
        {
            height: 13px;
            width: 169px;
        }
        .style81
        {
            height: 19px;
            width: 170px;
        }
        .style82
        {
            height: 13px;
            width: 170px;
        }
        .style83
        {
            width: 186px;
        }
        .style84
        {
            width: 268px;
        }
        .style85
        {
            width: 255px;
        }
        .style86
        {
            float: left;
            width: 845px;
        }
        .style87
        {
            height: 75px;
            width: 846px;
        }
        .style88
        {
            height: 17px;
        }
        .style89
        {
            width: 145px;
        }
        .style90
        {
            width: 227px;
        }
        .style91
        {
            width: 284px;
        }
        #images1
        {
            width: 853px;
        }
        .style92
        {
            height: 75px;
            width: 851px;
        }
        .style93
        {
            width: 362px;
        }
        .style94
        {
            width: 196px;
        }
        </style>

</head>
<p id="div_p" runat="server" cssclass="fontbold">

<div id="outerdiv">
<table cellpadding="0" cellspacing="0" style="vertical-align:top; width: 1683px; margin-right: 34px;"  
        id="outertable">
<tr>
<td class="style86">

<table id="images"  >
<tr>
<td   valign ="top"  align ="left" style="width:750px"><img src="Images/Untitled1.jpg" height ="40px"/></td>
<td   valign ="top"  align ="center" style="width:750px"><img src="Images/Untitled.jpg" height ="40px"/></td>
<td   valign ="top"  align ="right" class="style85"><img src="Images/Untitled2.jpg" height ="40px"/></td>
 </tr>
 </table>
 
 <table id="adderes" 
        style="width:838px; height:20px; border-top:solid 1px #000000;">
 <tr>
 <td class="style83">
 <table cellspacing="0" cellpadding="0" >
 <tr><td style="background-color:Gray; border-top:solid 1px black;border-bottom:solid 1px black;" 
         align="center" class="style84"><b><asp:Label ID="Label16" runat="server" CssClass ="dateclasspune"><font color="white">RECEIPT - CUM - BILL</font></asp:Label></b></td></tr>
 <tr><td align="center" class="style84"><b><asp:Label ID="Label17" runat="server" CssClass ="dateclasspune"  align="center">O R I G I N A L</asp:Label></b></td></tr>
 </table>
 </td>
 <td style="width:350px;">
 <table cellspacing="0" cellpadding="0">
 <tr><td><b><asp:Label ID="txtcompanyname" font-size="15px" runat="server"></asp:Label></b></td></tr>
 <tr><td><asp:Label ID="txtcompnameaddress" runat="server" CssClass ="dateclasspune" ></asp:Label></td></tr>
 <tr><td><asp:Label ID="txtbranchdetails" runat="server" CssClass ="dateclasspune" ></asp:Label></td></tr>
 </table>
 </td>
 </tr>
 </table>
 
 <table  id="agencyadderess" style="width:838px;">
  <tr><td align ="left" style="padding-left:10px;border-top:solid 1px #000000;" 
          class="style79" ><asp:Label CssClass="dateclasspune" ID="Label3" runat ="server"><b>Agency Name </b></asp:Label></td>
      <td style="border-top:solid 1px #000000;" class="style77"><asp:Label CssClass="dateclasspune" ID="agencytxt" runat ="server"></asp:Label></td></tr>
  <tr><td align ="left"  style="border-top:solid 1px #000000; padding-left:10px;" 
          class="style80"><asp:Label CssClass="dateclasspune" ID="Label8" runat ="server"><b>Client Name & Address </b></asp:Label></td><td style="border-top:solid 1px #000000;"><asp:Label CssClass="dateclasspune" ID="lbclientadd" runat ="server"></asp:Label></td></tr>
 </table>
 
 <table style="width:750px;" id="datatable">
 <tr><td width="450px">
<table cellspacing="0" cellpadding="0" border="0" 
         style="width: 511px; height: 384px;"  >
<tr><td valign="top" align="left"  id="tabledy" runat ="server" style="height: 18px;border-top: 1px solid #000000;"><asp:Label ID="dynamictable" runat="server" CssClass ="dateclasspune" ></asp:Label></td></tr>  
</table>
</td>
<td width="330px">
<table cellspacing="0" cellpadding="0"  style="width: 320px; margin-top: 0px; height: 388px;"  >
 <tr>
 <td style="border-left: 1px solid #000000;border-right: 1px solid #000000;border-top: 1px solid #000000; padding-left:10px;" 
         class="style89"><b>RCB No.</b></td><td class="style20"  align="left" style="border-top: 1px solid #000000;padding-left:10px"><asp:Label ID="txtrecept" runat="server"></asp:Label></td></tr>
 <tr><td style="padding-left:10px;border-left: 1px solid #000000;border-right: 1px solid #000000; " 
         class="style89"><b>RO Date</b></td><td class="style20"  align="left" style="padding-left:10px;"><asp:Label ID="txtdate" runat="server"></asp:Label></td></tr>
 <tr><td style="padding-left:10px;border-left: 1px solid #000000;border-right: 1px solid #000000; " 
         class="style89"><b>RO No.</b></td><td class="style20"  align="left"  style="padding-left:10px;"><asp:Label ID="lblrelodno" runat="server"></asp:Label></td></tr>
 <tr><td style="padding-left:10px;border-left: 1px solid #000000;border-right: 1px solid #000000; " 
         class="style89"><b>Booking Date</b></td><td class="style20" style="padding-left:10px;"><asp:Label ID="txtinsertiondate" runat="server"></asp:Label></td></tr>
 <tr><td style="padding-left:10px;border-left: 1px solid #000000;border-right: 1px solid #000000; " 
         class="style89"><b>Lines</b></td><td class="style20"  style="padding-left:10px;"><asp:Label ID="txtlines" runat="server"></asp:Label></td></tr>
 <tr><td style="padding-left:10px;border-left: 1px solid #000000;border-right: 1px solid #000000; " 
         class="style89"><b>Paid insertions</b></td><td class="style20" style="padding-left:10px;"><asp:Label ID="txtpaidinsertion" runat="server"></asp:Label></td></tr>
 <tr><td style="padding-left:10px;border-left: 1px solid #000000;border-right: 1px solid #000000; " 
         class="style89" ><b>Free insertions</b></td><td class="style20" style="padding-left:10px;"><asp:Label ID="txtunpaidinsertion" runat="server"></asp:Label></td></tr>
 <tr><td style="padding-left:10px;border-left: 1px solid #000000;border-right: 1px solid #000000; " 
         class="style89"><b>Total insertions</b></td><td class="style20" style="padding-left:10px;"><asp:Label ID="txttotalinsertion" runat="server"></asp:Label></td></tr>
 <tr><td style="padding-left:10px;border-left: 1px solid #000000;border-right: 1px solid #000000; " 
         class="style89"><b>.</b></td><td style="height:87px;" class="style20" style="padding-left:10px;"><asp:Label ID="txtvv" runat="server"></asp:Label></td></tr>            
</table>
</td>
</tr>
 </table>
 
 <table style="width:750px;border-top: 1px solid #000000;" id="grosamt"><tr><td>
 <table cellspacing="0" cellpadding="0" style="width: 509px; height: 65px; margin-top: 0px;"><tr>
 <td align="center" class="style72" ><asp:Label ID="Label2" runat="server">Remarks </asp:Label></td>
<td style="width:429px;"><asp:Label ID="txtremark" runat="server" CssClass ="dateclasspune" ></asp:Label></td>
</tr></table></td>
<td><table style="width: 320px; height: 65px; margin-top: 0px;"  >
 <tr><td class="style63" style="border-left: 1px solid #000000;border-right: 1px solid #000000;"><b>Gross Amount</b></td><td class="style20" ><asp:Label ID="lbl_gross" runat="server"></asp:Label></td></tr>
 <tr><td class="style63" style="border-left: 1px solid #000000;border-right: 1px solid #000000;"><b>Trade Discount</b></td><td class="style20"><asp:Label ID="lbl_trade" runat="server"></asp:Label></td></tr>
<tr><td class="style63" style="border-left: 1px solid #000000;border-right: 1px solid #000000;"><b>Net Payble</b></td><td  class="style20"><asp:Label ID="lbl_net" runat="server"></asp:Label></td></tr></table>
</td></tr></table>

<table style="width:750px;" id="mattertable">
<tr>
<td>
<table style="width:834px;" border="0">
<tr><td class="style71" style="border-top: 1px solid #000000;"><asp:Label ID="Label7" runat="server"  Text="Payment Mode:"></asp:Label></td>
<td style="border-top: 1px solid #000000;"><asp:Label ID="txtpaymode" runat="server" CssClass ="style20" ></asp:Label></td></tr>
<tr><td class="style71"style="border-bottom: 1px solid #000000;border-top: 1px solid #000000;" ><asp:Label ID="Label9" runat="server"  Text="Rupees in words:"></asp:Label></td>
<td style="border-bottom: 1px solid #000000;border-top: 1px solid #000000;"><asp:Label ID="lbwordinrupees" runat="server" CssClass ="style20" ></asp:Label></td></tr></table>
<table style="width:834px;" border="0"><tr><%--<td class="style74" valign="top" style="border-bottom: 1px solid #000000;"><asp:Label ID="Label11" runat="server"  Text="Matter:"></asp:Label></td>--%>
<td class="style74" valign="top" style="border-bottom: 1px solid #000000;font-size: 15px;"><asp:Label ID="lblmatter" runat="server" CssClass ="style20" ></asp:Label></td></tr></table>
<table style="width:834px;" border="0"><tr><td class="style71"  style="border-bottom: 1px solid #000000;background-color:Gray;"><font color="white"><asp:Label ID="Label4"  runat="server"  Text="Category "></asp:Label></td>
<td style="border-bottom: 1px solid #000000;"><asp:Label ID="txtadcat" runat="server" CssClass ="style20" ></asp:Label></td></tr>
<tr><td class="style71"><asp:Label ID="lbinwords" runat="server"  Text="Sub- Category "></asp:Label></td>
<td><asp:Label ID="txtsubcat" runat="server" CssClass ="style20" ></asp:Label></td></tr></table>

</td>
</tr>
</table>

<table  style="width:750px;" id="termtable">
<tr>
<td>
<table  style="width:835px;">
 <tr><td style="font-size: 11px;border-top: 1px solid #000000; font-family: verdana"><b>Note :</b> *Publishing dates as per R.O.</td></tr>
 <tr><td style="font-size: 11px; font-family: verdana">*No refund/ partially refund/ upgradation/ degradation/ cancellation if once advertisement is published.</td></tr>
 <tr><td style="font-size: 11px; font-family: verdana">*Objection  if any should be raised within 2 days from the date of publication.</td></tr>
 <tr><td style="font-family: verdana; font-size: 11px">*Advertisement may be rejected without assigning any reason even  after accepting it.</td></tr>
 <tr><td style="font-family: verdana; font-size: 11px">* In case, advt. could not be published on scheduled date, it would be published on very next date.</td></tr>
 <tr><td style="font-family: verdana; font-size: 11px">*All disputes are subject to jurisdiction of  Nagpur Courts only..</td> </tr>
</table>
</td>
</tr>
</table>
<table  style="width:839px;" id="phonetable">
<tr>
<td class="style75">
<table  style="width:839px;">
<tr>
<%--CIIN No. U99999MH1973PTC016613--%>
 <td style="font-family: verdana; font-size: 10px; vertical-align:bottom; width:250px;" align="left"><asp:Label ID="lblcin" runat ="server" Text="."></asp:Label></td>
<%--INCOME TAX PAN No. AAACL-18881--%>
<td style="font-family: verdana; font-size: 10px; vertical-align:bottom; width:250px;" align="left"><asp:Label ID="lblpan" runat ="server" Text="."></asp:Label></td>
<td style="font-family: verdana; font-size: 10px; vertical-align:bottom; width:250px;" align="left"><asp:Label ID="Label6" runat ="server" Text="."></asp:Label></td>
</tr>
<tr>
<%--Fax No. 0712-2545555--%>
<td style="font-family: verdana; font-size: 10px; vertical-align:bottom; width:250px;" align="left"><img src="Images/fax.jpg"  width="20px"; height ="20px"; alt="" /><asp:Label ID="lblfax" runat ="server" Text="."></asp:Label></td>
<%--Email ID- classifieds@lokmat.com--%>
<td style="font-family: verdana; font-size: 10px; vertical-align:bottom; width:250px;" align="left"><img src="Images/email.jpg"  width="20px";height="20px";  alt="" /><asp:Label ID="lblemail" runat ="server" Text="."></asp:Label></td>
<%--Phone No. 0712-2423527 (10 Lines)--%>
<td style="font-family: verdana; font-size: 10px; vertical-align:bottom; width:250px;" align="left"><img src="Images/phone.jpg"  width="20px";height="20px"; alt="" /><asp:Label ID="lblphone" runat ="server" Text="."></asp:Label></td>
</tr>
</table>
</td>
</tr>
</table>
 
 <table style="width:840px; height: 79px;" id="Table2">
<tr>
<td align="right" 
        style="vertical-align:bottom; font-size:18px;border-top:solid 1px black;" 
        class="style87"><asp:Label ID="Label21" runat="server"><b>Cashier / Accountant</b></asp:Label></td>
</tr>
</table>
 </td>
<%-- ////////////////////////center td/////////////////////////--%>
<td><table style="height:1092px; width:10px;" cellspacing="0" cellpadding="0" align="center">
<tr><td><b><img src="Images/scissors_new.png"  width="20px"; alt="" /></b></td></tr> 
<tr><td><b><img src="Images/scissors_new.png"  width="20px"; alt="" /></b></td></tr> 
<tr><td><b><img src="Images/scissors_new.png"  width="20px"; alt="" /></b></td></tr> 
<tr><td><b><img src="Images/scissors_new.png"  width="20px"; alt="" /></b></td></tr> 
<tr><td><b><img src="Images/scissors_new.png"  width="20px"; alt="" /></b></td></tr> 
<tr><td><b><img src="Images/scissors_new.png"  width="20px"; alt="" /></b></td></tr> 
<tr><td><b><img src="Images/scissors_new.png"  width="20px"; alt="" /></b></td></tr>

</table></td>
 <td><table style="height:1092px; width:10px;" ></table></td> 
<%--////////////////////third td//////////////////////////////--%>
<td style="width:750px; float:left;">

<table id="images1"><tr>
<td   valign ="top"  align ="left" style="width:750px"><img src="Images/Untitled1.jpg" height ="40px" alt="" /></td>
<td   valign ="top"  align ="center" style="width:750px"><img src="Images/Untitled.jpg" height ="40px" alt=""/></td>
<td   valign ="top"  align ="right" class="style33"><img src="Images/Untitled2.jpg" height ="40px" alt=""/></td>
 </tr>
 </table>
 <table id="adderes1" style="width:853px; border-top:solid 1px #000000;">
  <tr>
 <td class="style90">
 <table cellspacing="0" cellpadding="0" >
 <tr><td  style="background-color:Gray; border-top:solid 1px black;border-bottom:solid 1px black;" 
         align="center" class="style91"><b><asp:Label ID="Label5" runat="server" CssClass ="dateclasspune" ><font color="white">RECEIPT - CUM - BILL</font></asp:Label></b></td></tr>
 <tr><td align="center" class="style91"><b><asp:Label ID="Label10" runat="server" CssClass ="dateclasspune" >O F F I C E - C O P Y</asp:Label></b></td></tr>
 </table>
 </td>
 <td class="style93">
 <table cellspacing="0" cellpadding="0">
 <tr><td><b><asp:Label ID="Label12" font-size="15px" runat="server"></asp:Label></b></td></tr>
 <tr><td><asp:Label ID="Label13" runat="server" CssClass ="dateclasspune" ></asp:Label></td></tr>
 <tr><td><asp:Label ID="Label14" runat="server" CssClass ="dateclasspune" ></asp:Label></td></tr>
 </table>
 </td>
 </tr>
 </table>
 
 <table  id="agencyadderess1" style="width:855px;">
  <tr><td align ="left" style="padding-left:10px; border-top:1px solid #000000;" 
          class="style81" ><asp:Label CssClass="dateclasspune" ID="Label15" runat ="server"><b>Agency Name</b></asp:Label></td>
      <td style="border-top:solid 1px #000000;" class="style78"><asp:Label CssClass="dateclasspune" ID="Label18" runat ="server"></asp:Label></td></tr>
  <tr><td align ="left"  style="padding-left:10px; border-top:1px solid #000000;" 
          class="style82"><asp:Label CssClass="dateclasspune" ID="Label19" runat ="server"><b>Client Name & Address</b></asp:Label></td>
      <td style="border-top:solid 1px #000000;" class="style76"><asp:Label CssClass="dateclasspune" ID="Label20" runat ="server"></asp:Label></td></tr>
 </table>
 
 <table style="width:855px;" id="datatable1">
 <tr><td width="450px">
<table cellspacing="0" cellpadding="0" border="0" style="width: 509px; height: 384px;"  >
<tr><td valign="top" align="left"  id="Td11" runat ="server" style="height: 18px;border-top: 1px solid #000000;"><asp:Label ID="dynamic2" runat="server" CssClass ="dateclasspune" ></asp:Label></td></tr>  
</table>
</td>
<td width="320px">
<table cellspacing="0" cellpadding="0" border="0" style="width: 320px; margin-top: 0px; height: 388px;"  >
 <tr><td style="border-left: 1px solid #000000;border-right: 1px solid #000000;border-top: 1px solid #000000; padding-left:10px;"><b>RCB No.</b></td><td class="style20"  align="left" style="border-top: 1px solid #000000;padding-left:10px;"><asp:Label ID="Label22" runat="server"></asp:Label></td></tr>
 <tr><td style="border-left: 1px solid #000000;border-right: 1px solid #000000; padding-left:10px;"><b>RO Date</b></td><td class="style20"  align="left" style="padding-left:10px;"><asp:Label ID="Label23" runat="server"></asp:Label></td></tr>
 <tr><td style="border-left: 1px solid #000000;border-right: 1px solid #000000; padding-left:10px;"><b>RO No.</b></td><td class="style20"  align="left" style="padding-left:10px;" ><asp:Label ID="Label24" runat="server"></asp:Label></td></tr>
 <tr><td style="border-left: 1px solid #000000;border-right: 1px solid #000000; padding-left:10px;"><b>Booking Date</b></td><td class="style20" style="padding-left:10px;"><asp:Label ID="Label25" runat="server"></asp:Label></td></tr>
 <tr><td style="border-left: 1px solid #000000;border-right: 1px solid #000000; padding-left:10px;"><b>Lines</b></td><td class="style20" style="padding-left:10px;" ><asp:Label ID="Label26" runat="server"></asp:Label></td></tr>
 <tr><td style="border-left: 1px solid #000000;border-right: 1px solid #000000; padding-left:10px;"><b>Paid insertions</b></td><td class="style20" style="padding-left:10px;"><asp:Label ID="Label27" runat="server"></asp:Label></td></tr>
 <tr><td style="border-left: 1px solid #000000;border-right: 1px solid #000000; padding-left:10px;" ><b>Free insertions</b></td><td class="style20" style="padding-left:10px;"><asp:Label ID="Label28" runat="server"></asp:Label></td></tr>
 <tr><td style="border-left: 1px solid #000000;border-right: 1px solid #000000; padding-left:10px;"><b>Total insertions</b></td><td class="style20" style="padding-left:10px;"><asp:Label ID="Label29" runat="server"></asp:Label></td></tr>
 <tr><td style="border-left: 1px solid #000000;border-right: 1px solid #000000; padding-left:10px;"><b>.</b></td><td style="height:87px;" class="style20" style="padding-left:10px;"><asp:Label ID="Label30" runat="server"></asp:Label></td></tr>            
</table>
</td>
</tr>
 </table>
 
 <table style="width:854px; border-top: 1px solid #000000;" id="grosamt1"><tr><td>
 <table cellspacing="0" cellpadding="0" style="width: 509px; height: 65px; margin-top: 0px;" border="0"><tr>
 <td align="center" class="style72"><asp:Label ID="Label31" runat="server">Remarks:</asp:Label></td>
<td style="width:429px;"><asp:Label ID="Label32" runat="server" CssClass ="dateclasspune" ></asp:Label></td>
</tr></table></td>
<td><table cellspacing="0" cellpadding="0" style="width: 320px; height: 65px; margin-top: 0px;" border="0">
 <tr><td style="border-left: 1px solid #000000;border-right: 1px solid #000000;" 
         class="style94"><b>Gross Amount</b></td><td class="style20" ><asp:Label ID="Label33" runat="server"></asp:Label></td></tr>
 <tr><td style="border-left: 1px solid #000000;border-right: 1px solid #000000;" 
         class="style94"><b>Trade Discount</b></td><td class="style20"><asp:Label ID="Label34" runat="server"></asp:Label></td></tr>
<tr><td style="border-left: 1px solid #000000;border-right: 1px solid #000000;" 
        class="style94"><b>Net Payble</b></td><td  class="style20"><asp:Label ID="Label36" runat="server"></asp:Label></td></tr></table>
</td></tr></table>

<table style="width:750px;" id="Table1">
<tr>
<td>
<table style="width:851px;" border="0">
<tr><td class="style71" style="border-top: 1px solid #000000;"><asp:Label ID="Label37" runat="server"  Text="Payment Mode:"></asp:Label></td>
<td style="border-top: 1px solid #000000;"><asp:Label ID="Label38" runat="server" CssClass ="style20" ></asp:Label></td></tr>
<tr><td class="style71" style="border-bottom: 1px solid #000000;border-top: 1px solid #000000;"><asp:Label ID="Label39" runat="server"  Text="Rupees in words:"></asp:Label></td>
<td style="border-bottom: 1px solid #000000;border-top: 1px solid #000000;"><asp:Label ID="Label40" runat="server" CssClass ="style20" ></asp:Label></td></tr></table>
<table style="width:850px;"><tr><%--<td class="style74" valign="top" style="border-bottom: 1px solid #000000;"><asp:Label ID="Label41" runat="server"  Text="Matter:"></asp:Label></td>--%>
<td class="style74" valign="top" style="border-bottom: 1px solid #000000;"><asp:Label ID="Label42" runat="server" CssClass ="style20" ></asp:Label></td></tr></table>
<table style="width:852px;"><tr><td class="style71" style="border-bottom: 1px solid #000000;background-color:Gray;"><font color="white"><asp:Label ID="Label43" runat="server"  Text="Category "></asp:Label></td>
<td style="border-bottom: 1px solid #000000;"><asp:Label ID="Label44" runat="server" CssClass ="style20" ></asp:Label></td></tr>
<tr><td class="style71"><asp:Label ID="Label45" runat="server"  Text="Sub- Category "></asp:Label></td>
<td><asp:Label ID="Label46" runat="server" CssClass ="style20" ></asp:Label></td></tr></table>
</td></tr>
</table>


<table  style="width:840px;" id="termtable1">
<tr>
<td>
<table  style="width:851px;">
 <tr><td style="font-size: 11px;border-top: 1px solid #000000; font-family: verdana"><b>Note:</b> *Publishing dates as per R.O.</td></tr>
 <tr><td style="font-size: 11px; font-family: verdana">*No refund/ partially refund/ upgradation/ degradation/ cancellation if once advertisement is published.</td></tr>
 <tr><td style="font-size: 11px; font-family: verdana">*Objection  if any should be raised within 2 days from the date of publication.</td></tr>
 <tr><td style="font-family: verdana; font-size: 11px">*Advertisement may be rejected without assigning any reason even  after accepting it.</td></tr>
 <tr><td style="font-family: verdana; font-size: 11px">* In case, advt. could not be published on scheduled date, it would be published on very next date.</td></tr>
 <tr><td style="font-family: verdana; font-size: 11px" 
         class="style88">*All disputes are subject to jurisdiction of  Nagpur Courts only..</td> </tr>
</table>
</td>
</tr>
</table>

<table  style="width:839px;" id="phonetable1">
<tr>
<td class="style75">
<table  style="width:850px;">
<tr>
<%--CIIN No. U99999MH1973PTC016613--%>
 <td style="font-family: verdana; font-size: 10px; vertical-align:bottom; width:250px;" align="left"><asp:Label ID="Label47" runat ="server" Text="."></asp:Label></td>
<%--INCOME TAX PAN No. AAACL-18881--%>
<td style="font-family: verdana; font-size: 10px; vertical-align:bottom; width:250px;" align="left"><asp:Label ID="Label49" runat ="server" Text="."></asp:Label></td>
<td style="font-family: verdana; font-size: 10px; vertical-align:bottom; width:250px;" align="left"><asp:Label ID="Label51" runat ="server" Text="."></asp:Label></td>
</tr>
<tr>
<%--Fax No. 0712-2545555--%>
<td style="font-family: verdana; font-size: 10px; vertical-align:bottom; width:250px;" align="left"><img src="Images/fax.jpg"  width="20px"; height ="20px"; alt="" /><asp:Label ID="Label48" runat ="server" Text="."></asp:Label></td>
<%--Email ID- classifieds@lokmat.com--%>
<td style="font-family: verdana; font-size: 10px; vertical-align:bottom; width:250px;" align="left"><img src="Images/email.jpg"  width="20px"; height ="20px"; alt="" /><asp:Label ID="Label50" runat ="server" Text="."></asp:Label></td>
<%--Phone No. 0712-2423527 (10 Lines)--%>
<td style="font-family: verdana; font-size: 10px; vertical-align:bottom; width:250px;" align="left"><img src="Images/phone.jpg"  width="20px"; height ="20px"; alt="" /><asp:Label ID="Label52" runat ="server" Text="."></asp:Label></td>
</tr>
</table>
</td>
</tr>
</table>

<table style="width:843px;" id="signaturetable">
<tr>
<td align="right" 
        style="vertical-align:bottom; font-size:18px; border-top:solid 1px black;" 
        class="style92"><asp:Label ID="Label53" runat="server"><b>Customer's Singnature</b></asp:Label></td>
</tr>
</table>
 
</td>
<%--///////////////////////////////////////////////--%>
</tr>
</table>
</div>

</p>

