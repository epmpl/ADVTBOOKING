<%@ Control Language="C#" AutoEventWireup="true" CodeFile="udayvani_bill_classi_priw.ascx.cs" Inherits="udayvani_bill_classi_priw" %>
    <link href="css/billingStyleSheet.css" type="text/css" rel="Stylesheet" />
    
        <head>
<title>UDAYVANI CLASSI BILL</title>

<script language="javascript" type="text/javascript">
// <!CDATA[

function TABLE1_onclick() {

}

// ]]>
</script>
</head>

<table    class ="breakcls"  style="margin-top:20px" >
<tr>
<td valign="top">


<table style="border:solid 1px black;width:650px;margin-left :0px;" cellspacing="0" cellpadding="0" id="TABLE1" onclick="return TABLE1_onclick()"><tr><td>




<tr>
<td style="width: 650px" valign ="top" >

<table  style="border-bottom:solid 1px black;vertical-align :top " width="650px" cellspacing="0" cellpadding="0" >
<tr>
 <td   align="right" valign="top"width="330px"><B>BILL</B></td>

 <td align="center" ><img src="Images1/Manipal-Group-Logo-copy.jpg" height ="40px"/></td>


</tr>
 
 
 </table>
 <table width="650px" cellspacing="0" cellpadding="0" style="border-bottom:solid 1px black">
  <tr >
  <td >
 <table width="300px" cellspacing="0" cellpadding="0"  border="0" style="border:solid 1px black">
 <tr>
    <td   align ="left" style="padding-left:5px;" ><b><asp:Label CssClass="agecnycodeclasspune" ID="lblto" runat ="server" Text="To,"></asp:Label></b></td>
    <td  align ="left" width="10%" valign ="top" style="height:13px;" ><asp:Label CssClass="agecnycodeclasspune" ID="agddxt" runat ="server" Text="Ag:Code:"></asp:Label>
 <asp:Label CssClass="agecnycodeclasspune" ID="lblagncode" runat ="server" ></asp:Label></td>
 </tr>
 <tr>
 <td align ="left"  valign ="top" style="height:13px;padding-left:15px;"    ><b> <asp:Label CssClass="agecnycodeclasspune" ID="lblagencytxt" runat ="server"></asp:Label></b></td>
 
 </tr>
 <tr>
 <td align ="left"  style="height: 13px;padding-left:15px;"><b><asp:Label CssClass="agecnycodeclasspune" ID="lbclientadd" runat ="server"></asp:Label></b></td>
 
 </tr>
 <tr>
 <td   align ="left" style="padding-left:15px;" ><b><asp:Label CssClass="agecnycodeclasspune" ID="lbcityname" runat ="server"></asp:Label>
<asp:Label CssClass="agecnycodeclasspune" ID="lblpinno" runat ="server"></asp:Label></b></td>
 </tr>
 <tr><td  >&nbsp;</td></tr>
 <tr>
 <tr>
  <td   align ="left" style="padding-left:15px;width:250" ><b><asp:Label CssClass="agecnycodeclasspune" ID="lbcontectp" runat ="server" Text="Contect Person :"></asp:Label>
 <asp:Label CssClass="agecnycodeclasspune" ID="lbcontectpn" runat ="server" Text="Media Manager"></asp:Label></b></td>
</tr>
</table>
<table>

     <tr align="center">
         
        <td style="font-size:10px;font-family :Verdana; height: 15px;width: 300px;vertical-align:top;" ><asp:Label ID="lbladrelpar" runat ="server" CssClass="dateclasspune"><b>Advertisament Release Particulars</b></asp:Label></td>
        </tr>
</table>

</td>


<td valign="bottom" >
<table width="350px" cellspacing="0" cellpadding="0">

<tr ><td colspan="4" style="height: 11px" align="center"><asp:Label ID="lbcomp_name" style="font-size:15"  runat="server"><B>MANIPAL MEDIA NETWORK LTD</B></asp:Label></td></tr>
<tr><td colspan="4" align="center" ><asp:Label ID="lbcomp_add" CssClass="dateclasspune" runat="server"><b>Regd.office:Udayvani Building, Tile Factory Road,Manipal-576104</b></asp:Label></td></tr>
<tr><td colspan="4" align="center"><asp:Label ID="lbcomp_ph" CssClass="dateclasspune" runat="server"><b>Ph:91-820-2205000,2571152 fax:2570563,2570846</b></asp:Label></td></tr>
<tr><td colspan="4" align="center"><asp:Label ID="lbcomp_email" CssClass="dateclasspune" runat="server"><b>email:accounts.advt@manipalmedia.com</b></asp:Label></td></tr>
<tr><td><asp:Label ID="Label6" runat="server" CssClass="dateclasspune"><B>Member:ABC & INS</B></asp:Label></td><td></td><td></td><td><asp:Label ID="Label3" CssClass="dateclasspune" runat="server"><B>PAN:AAACM 8839Q</B></asp:Label></td></tr>
<tr>

<td align ="left" style="height: 13px" ><b><asp:Label CssClass="agecnycodeclasspune" ID="Label1" runat ="server">Publication</asp:Label></b></td>
<td  align ="left" style="height: 13px" ><asp:Label CssClass="dateclasspune" ID="Label_pub" runat ="server"></asp:Label></td>

 <td valign ="top" align ="left" style="height: 13px"  ><b> <asp:Label CssClass="agecnycodeclasspune" ID="lbinvoiceno" runat ="server">Bill No.</asp:Label></b></td>
 <td  valign ="top" align ="left" style="height: 13px" ><asp:Label CssClass="dateclasspune" ID="txtinvoice" runat ="server"></asp:Label></td>
</tr>
<tr>

<td align ="left" style="height: 13px" ><b><asp:Label CssClass="agecnycodeclasspune" ID="lbadtype" runat ="server">Ad Type</asp:Label></b></td>
<td align ="left" style="height: 13px" ><asp:Label CssClass="dateclasspune" ID="adcat" runat ="server"></asp:Label></td>

<td align ="left" ><b><asp:Label CssClass="agecnycodeclasspune" ID="lbdate" runat ="server">Date</asp:Label></b></td>
<td  align ="left" ><asp:Label CssClass="dateclasspune" ID="runtxt" runat ="server"></asp:Label></td>
</tr>
<tr>
<td align="left"  ><b><asp:Label CssClass="agecnycodeclasspune" ID="lbpackagena" runat ="server">Package</asp:Label></b></td>
<td  align ="left"><asp:Label CssClass="dateclasspune" ID="txtpackname" runat ="server"></asp:Label></td>

<td align="left"><b><asp:Label CssClass="agecnycodeclasspune" ID="lbddate" runat ="server">Due Date</asp:Label></b></td>
<td align="left"><asp:Label CssClass="dateclasspune" ID="ldduedate" runat ="server"></asp:Label></td>
</tr>


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
                             
                 
                 
                 </td>
                 </tr>
                 
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
<tr>
<td class='insertiontxtclass3'>UDAYAVANI</td>
<td class='insertiontxtclass3'>TARANGA</td>
<td class='insertiontxtclass3'>ROOPATARA</td>
<td class='insertiontxtclass3'>TUSHARA</td>
<td class='insertiontxtclass3'>TUNTURU</td>
<td class='insertiontxtclass3'>www.udayavani.com</td>
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
