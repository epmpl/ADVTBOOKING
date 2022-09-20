<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RCB_CLASSIFIED.ascx.cs" Inherits="RCB_CLASSIFIED" %>


<link href="css/billingStyleSheet.css" type="text/css" rel="Stylesheet" />

<head>


<script language="javascript" type="text/javascript">
// <!CDATA[

function TABLE1_onclick() {

}

// ]]>
</script>
</head>

<table    class ="breakcls">
<tr>
<td valign="top">


<table style="border:solid 1px black;width:650px;margin-left :20px;" cellspacing="0" cellpadding="0" id="TABLE1" onclick="return TABLE1_onclick()"><tr><td>




 <table  style="border-bottom:solid 1px black" width="650px" cellspacing="0" cellpadding="0" >
 <tr>
     <td  valign ="middle"  align ="left"  ><img src="Images/pune.jpg" height ="40px"/></td>
    <td  valign ="middle"  align ="LEFT" style="font-family:Times New Roman ;font-size:18px;font-weight :bold " ><b><asp:Label CssClass="dateclasspuneheading" ID="lbcompanyname" runat ="server" Font-Names="Times New Roman" Font-Bold="True"></asp:Label></b></td>
    

      <td  valign ="middle"  align ="center" style="font-family:Verdana UI;font-size:20px;font-weight :bold" ><u><b><asp:Label CssClass="dateclasspuneheading" ID="lbbilltype" runat ="server" Text="INVOICE" Font-Names="Verdana"></asp:Label></b></u></td>
 </tr>
 
 <tr>
    <td  valign ="middle"  align ="left"  style="font-size:14px"><b> <asp:Label CssClass="agecnycodeclasspune" ID="lbwaluj" runat ="server"></asp:Label></b></td>
     <td valign ="middle"  align ="left" colspan="2" style="font-size:14px"><b><asp:Label ID="lbwalujadd" runat ="server"></asp:Label></b></td>

 </tr>
 <tr>
    <td valign ="middle"  align ="left" style="font-size:14px"><b> <asp:Label CssClass="agecnycodeclasspune" ID="lbbranch" runat ="server" Width="87px"></asp:Label></b> </td>
    <td valign ="middle"  align ="left" colspan="2" style="font-size:14px"><b><asp:Label ID="lbbranchtxt" runat ="server"></asp:Label></b>  </td>

 </tr>
 </table>
 <table width="650px" cellspacing="0" cellpadding="0" style="border-bottom:solid 1px black">
 <tr>
 <td valign="top">
 <table width="450px" cellspacing="0" cellpadding="0" style ="vertical-align :top ;">
 <tr>
 <td style="height: 13px;width :90px;" valign ="top" ><b> <asp:Label CssClass="agecnycodeclasspune" ID="agencytxt" runat ="server"></asp:Label></b> </td>
 <td colspan="3" style="height: 13px"><asp:Label CssClass="dateclasspune" ID="agddxt" runat ="server"></asp:Label></td>
 </tr>
 <tr><td  ><b> <asp:Label CssClass="agecnycodeclasspune" ID="space2" runat ="server"></asp:Label></b> </td></tr>
 <tr>
 <td style="height: 13px" ><b><asp:Label CssClass="agecnycodeclasspune" ID="lbagencyadd" runat ="server"></asp:Label></b></td>
 <td colspan="3" style="height: 13px"><asp:Label CssClass="dateclasspune" ID="lbagencyaddtxt" runat ="server"></asp:Label></td>
 </tr>
 <tr><td ><asp:Label CssClass="agecnycodeclasspune" ID="space4" runat ="server"></asp:Label></td></tr>
 <tr><td ><asp:Label CssClass="agecnycodeclasspune" ID="space3" runat ="server"></asp:Label></td></tr>
 <tr>
<%-- <td style="height: 13px" ><asp:Label CssClass="agecnycodeclasspune" ID="lbclientna" runat ="server"></asp:Label></td>
 <td colspan="3" style="height: 13px"><asp:Label CssClass="dateclasspune" ID="txtcliname" runat ="server"></asp:Label></td>
--%> </tr>
 <tr><td  ><asp:Label CssClass="agecnycodeclasspune" ID="space5" runat ="server"></asp:Label></td></tr>
</table></td>
<td style="height: 80px" valign ="top"  align ="right"  >
<table width="200px" cellspacing="0" cellpadding="0">
<tr>
 <td align ="left" ><b><asp:Label CssClass="agecnycodeclasspune" ID="lbinvoiceno" runat ="server"></asp:Label></b></td>
 <td colspan="2" align ="left"><asp:Label CssClass="dateclasspune" ID="txtinvoice" runat ="server"></asp:Label></td>
</tr>
<tr>
<td align ="left" ><b><asp:Label CssClass="agecnycodeclasspune" ID="lbdate" runat ="server"></asp:Label></b></td>
<td colspan="2" align ="left"><asp:Label CssClass="dateclasspune" ID="runtxt" runat ="server"></asp:Label></td>
</tr>
<tr>
<td align ="left" ><b><asp:Label CssClass="agecnycodeclasspune" ID="lbcreditdate" runat ="server"></asp:Label></b></td>
<td colspan="2" align ="left"><asp:Label CssClass="dateclasspune" ID="lbcreditdatetxt" runat ="server"></asp:Label></td>
</tr>
<tr>
<td align ="left" style="height: 13px" ><asp:Label CssClass="agecnycodeclasspune" ID="lbadtype" runat ="server"></asp:Label></td>
<td colspan="2" align ="left" style="height: 13px"><asp:Label CssClass="dateclasspune" ID="lbadtypetxt" runat ="server"></asp:Label></td>
</tr>
<tr>
<td align ="left"  ><b><asp:Label CssClass="agecnycodeclasspune" ID="lbadcat" runat ="server"></asp:Label></b></td>
<td colspan="2"align ="left" ><asp:Label CssClass="dateclasspune" ID="lbadcattxt" runat ="server"></asp:Label></td>
</tr>
<tr>
<td align ="left" style="height: 13px"  ><b><asp:Label CssClass="agecnycodeclasspune" ID="lbformonth" runat ="server" Width="99px"></asp:Label></b></td>
<td colspan="2" align ="left" style="height: 13px"><asp:Label CssClass="dateclasspune" ID="lbformonthtxt" runat ="server"></asp:Label></td>
</tr>
 <tr><td  ><b><asp:Label CssClass="agecnycodeclasspune" ID="space6" runat ="server"></asp:Label></b></td></tr>
</table>
</td>
</tr>
</table>



<table width="650px" cellspacing="0" cellpadding="0" style="border-bottom:solid 1px black" ><tr>
       <td valign="top" style="border-right:solid 0px black; height: 56px;">
       <table cellspacing="0" cellpadding="0"><tr><td>
        <table cellspacing="0" cellpadding="0"  width="650px"   class="table1" >
            <tr><td colspan="2"   valign="top" align="left"  id="tabledy" runat ="server" style="height: 18px">
               <asp:Label ID="dynamictable" runat="server" CssClass ="dateclasspune" ></asp:Label>                       
                 </td></tr>
                 
                 </table>
                 
                </td></tr>
        </table>
       </td>
 
       <td style="height: 56px" >
        </td></tr>
  </table>
  
  
  <table width="650px" cellspacing="0" cellpadding="0"  border="0">
  

        <tr>
<%--<td  style="font-size:13px;border-bottom:solid 1px black;">
<asp:Label ID="lbtotal" runat ="server" CssClass="agecnycodeclasspune" ></asp:Label>

</td>
<td style="font-size:13px;border-bottom:solid 1px black" align ="right" >
<asp:Label ID="txttotal" runat ="server" ></asp:Label>

</td>--%>


</tr>
<%--  <tr  >

<td  valign="bottom"   colspan="2"  rowspan ="2" style="font-size:13px;border-bottom:solid 1px black; height: 10px;" align ="right" >
<asp:Label ID="Label234" runat ="server" ></asp:Label>

</td>
  
  </tr>--%>

                     
  </table>
    
<table width="650px" id="TBL_NEW" runat ="server"  cellspacing="0" cellpadding="0"  >
<tr  >


<%--
<td  colspan="3" style="font-size:10px;font-family :Arial; height: 54px;border-bottom :solid 1px black" >
<asp:Label ID="hidedata" runat ="server" ></asp:Label>



</td>--%>

</tr>
<tr>
<td>
<table width="650px"  cellspacing="0" cellpadding="0" >

<tr>

<td align="left" valign ="bottom" style="height: 13px" ><b><asp:Label CssClass="agecnycodeclasspune" ID="lbemail" runat ="server"></asp:Label></b><asp:Label CssClass="dateclasspune" ID="lbemailtxt" runat ="server"></asp:Label></td>

<td   valign ="bottom" style="height: 13px"  > <b><asp:Label CssClass="agecnycodeclasspune" ID="EOU" runat ="server" ></asp:Label></b></td>

<td align="right" colspan ="2"  valign ="bottom" style="height: 13px" ><b><asp:Label CssClass="agecnycodeclasspune" ID="lbpune" runat ="server"></asp:Label></b><asp:Label CssClass="dateclasspune" ID="lbpunetxt" runat ="server"></asp:Label></td>


</tr>
</table>
</td>
</tr></table>
</td>
</tr>
</table>
</td> 
</tr> 
</table>

