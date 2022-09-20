<%@ Control Language="C#" AutoEventWireup="true" CodeFile="dmhbill_formate.ascx.cs" Inherits="dmhbill_formate" %>

<link href="css/udyavanibill.css" type="text/css" rel="Stylesheet" />



<head><title>DMH BILL </title>

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
    </style>
</head>
<p id=div_p runat="server">
<table width="670px" cellpadding="0" cellspacing="0" border="1"><tr>
<td >

<table width="640px" cellpadding="0" cellspacing="0" style="border:solid 2px black;">
<tr><td colspan="2">&nbsp;</td></tr>

<tr><td  colspan="2" style="border-top:solid 2px black;border-bottom:solid 2px black;"><img src="Images/republikein.jpg" height ="60px" width="720px"/></td>
<%--<td style="font-size:15px;text-align:left;border-top:solid 2px black;border-bottom:solid 2px black;background-image:url(Images/republeiken1.jpg)" valign="baseline">a division of democratic media holding(Pty)Ltd.</td>
--%>
</tr>
<tr><td height="24px" colspan="2"></td></tr>
<tr>
    <td colspan="2">
    <table border="0" cellpadding="0" cellspacing="20" width="640px" >
    <tr valign="top">
    <td >
        <table align="center" style="border:solid 2px black;" width="213px" cellpadding="0" cellspacing="0">
        <tr><td ><asp:Label ID="lblpo" runat="server" CssClass="agecnycodeclasspune"></asp:Label> </td><td><asp:Label ID="txtpono" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td></tr>
        <tr><td ><asp:Label ID="lbltel" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td><td><asp:Label ID="txtlbltel" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td></tr>
        <tr><td ><asp:Label ID="lblfax" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td><td><asp:Label ID="txtlblfax" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td></tr>
        <tr><td ><asp:Label runat="server" ID="lblmail" CssClass="agecnycodeclasspune"></asp:Label></td><td><asp:Label ID="txtlblmail" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td></tr>
        </table>
     </td>
     <td >
             <table align="center" style="border:solid 2px black;" width="213px" cellpadding="0" cellspacing="0">
        <tr><td  colspan="2" style="font-size:x-large" align="center"><asp:Label ID="lblinv" runat="server">Tax Invoice Copy</asp:Label></td></tr>
     
     </table>
     <table align="center"  width="213px" cellpadding="0" cellspacing="0" border="0">
      <tr><td></td></tr>
      <tr><td style="text-align:center;"><asp:Label ID="lblregnr" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td><td style="text-align:left;"><asp:Label ID="txtlblregnr" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td></tr>
      <tr><td style="text-align:center;"><asp:Label ID="lblcoreg" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td><td style="text-align:left;"><asp:Label ID="txtlblcoregt" runat="server" CssClass="agecnycodeclasspune"></asp:Label></tr>
       </table>
     </td>
     
     <td style="padding-left:30px">
         <table align="right" style="border:solid 2px black;" width="180px" cellpadding="0" cellspacing="0">
        <tr><td style="border-right:solid 2px black;text-align:center;"><asp:Label ID="lbldt" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td><td style="text-align:center;"><asp:Label CssClass="agecnycodeclasspune" ID="lblpg" runat="server"></asp:Label></td></tr>
   
      <tr><td style="border-right:solid 2px black;text-align:center;"><asp:Label ID="txtlbldt" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td><td style="text-align:center;"><asp:Label ID="txtlblpg" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td></tr>
     <tr><td colspan="2" align="center" style="border-top:solid 2px black;"><asp:Label ID="lblinvno" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td></tr>
      <tr><td colspan="2" align="center"><asp:Label ID="txtlblinvno" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td></tr>
       </table>
     
     </td>
     </tr>
        </table>
    </td>
</tr>

<tr>
<td style="padding-left:20px;"><asp:Label ID="lblsold" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td><td><asp:Label ID="lblship" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td>
</tr>
<tr>
<td style="padding-left:20px;">
<table width="330px" height="100px"  style="border:solid 2px black;" cellpadding="0" cellspacing="0">
<tr valign="top">
<td>
<asp:Label ID="lbladd" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
</td>

</tr>

</table>

</td>
<td>
<table width="330px" height="100px" style="border:solid 2px black;" cellpadding="0" cellspacing="0">
<tr valign="top">
<td>
<asp:Label ID="Label1" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
</td>

</tr>

</table>
</td>

</tr>
<tr><td colspan="2" style="padding-top:3px;padding-left:20px">
<table width="680px" style="border:solid 2px black;" cellpadding="0" cellspacing="0" height="30px">
<tr>
<td align="center"><asp:Label ID="lblordno" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td>
<td align="center"><asp:Label ID="lblordrdt" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td>
<td align="center"><asp:Label ID="lblcustno" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td>
<td align="center"><asp:Label ID="lblsalspr" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td>
<td align="center"><asp:Label ID="lblponmbr" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td>
<td align="center"><asp:Label ID="lblform" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td>
</tr>
<tr>
<td align="center"><asp:Label ID="txtlblordno" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td>
<td align="center"><asp:Label ID="txtlblordrdt" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td>
<td align="center"><asp:Label ID="txtlblcustno" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td>
<td align="center"><asp:Label ID="txtlblsalspr" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td>
<td align="center"><asp:Label ID="txtlblponmbr" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td>
<td align="center"><asp:Label ID="txtlblform" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td>
</tr>
</table>


</td></tr>


<tr>
<td colspan="2" style="padding-top:3px;padding-left:20px">

<table  width="678px"   cellspacing="0" cellpadding="0" style="border-bottom:solid 1px black;border-top:solid 1px black;border-right:solid 1px black;border-left:solid 1px black;vertical-align :top" >
<tr spacing="0" cellpadding="0">
    <td valign ="top" width="678px" style="border-bottom:solid 1px black;height: 400px;" >
           <asp:Label  id="dynamictable"  runat ="server" CssClass="agecnycodeclasspune"></asp:Label>
       </td>
 </tr>
</table>
</td>

</tr>

<tr valign="top">
<td colspan="4" style="padding-left:20px;padding-bottom:5px;">
<table width="670px" border="1" cellpadding="0" cellspacing="0" style="border:solid 2px black;">
<tr valign="top">
<td >

<table width="400px" cellpadding="0" cellspacing="0" style="padding-left:10px;">
<tr>
<td colspan="4" >

<asp:Label ID="lblnb" runat="server" CssClass="agecnycodeclasspune"></asp:Label>
</td>
</tr>
<tr valign="top">
<td >
<asp:Label ID="lblbank" runat="server" CssClass="agecnycodeclasspune">Bank Detail:</asp:Label>
</td>
</tr>
<tr><td><asp:Label ID="lblfnb" runat="server" CssClass="agecnycodeclasspune">FNB:</asp:Label><asp:Label  CssClass="agecnycodeclasspune" runat="server" ID="txtlblfnb"></asp:Label></td><td align="right"><asp:Label ID="lblsch" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td><td align="right"><asp:Label ID="txtlblsch" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td></tr>
<tr><td><asp:Label ID="lblbrnch" runat="server" CssClass="agecnycodeclasspune"></asp:Label><asp:Label  CssClass="agecnycodeclasspune" runat="server" ID="txtlblbrnch"></asp:Label></td><td align="right"><asp:Label ID="lblvatno" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td><td align="right"><asp:Label ID="txtlblvat" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td></tr>
<tr><td><asp:Label ID="lblacnt" runat="server" CssClass="agecnycodeclasspune"></asp:Label><asp:Label  CssClass="agecnycodeclasspune" runat="server" ID="txtlblacnt"></asp:Label></td></tr>
<tr><td><asp:Label ID="lbltel1" runat="server" CssClass="agecnycodeclasspune"></asp:Label><asp:Label  CssClass="agecnycodeclasspune" runat="server" ID="txtlbltel1"></asp:Label></td></tr>
<tr><td><asp:Label ID="lblfax1" runat="server" CssClass="agecnycodeclasspune"></asp:Label><asp:Label  CssClass="agecnycodeclasspune" runat="server" ID="txtlblfax1"></asp:Label></td></tr>
<tr><td></td></tr>
</table>



</td>
<td>
<table width="135px" cellpadding="0" cellspacing="0" >
<tr><td align="center"><asp:Label ID="lblsubttl" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td></tr>
<tr><td align="center"><asp:Label ID="lblvatttl" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td></tr>
<tr><td>&nbsp;</td></tr>
<tr><td>&nbsp;</td></tr>
<tr><td>&nbsp;</td></tr>



<tr><td align="center"><asp:Label runat="server" ID="lblamnt" CssClass="agecnycodeclasspune"></asp:Label></td></tr>
</table>

</td>

<td >
<table width="135px" cellpadding="0" cellspacing="0">
<tr><td style="text-align:right;"><asp:Label ID="txtlblsubttl" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td></tr>
<tr><td style="text-align:right;"><asp:Label ID="txtlblvattl" runat="server" CssClass="agecnycodeclasspune"></asp:Label></td></tr>
<tr><td>&nbsp;</td></tr>
<tr><td>&nbsp;</td></tr>
<tr><td>&nbsp;</td></tr>



<tr><td style="text-align:right;border-top:solid 2px black;"><asp:Label runat="server" ID="txtlblamt" CssClass="agecnycodeclasspune"></asp:Label></td></tr>
</table>

</td>
</tr>




</table>



</td>



</tr>











</table>























</td></tr></table>
</p>

