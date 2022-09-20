<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BillRegisterview.aspx.cs" Inherits="BillRegisterview" EnableEventValidation="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%-------------------------------------------------------------------------------
<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="NewRegisterBillingview.aspx.cs" Inherits="NewRegisterBillingview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
--%>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <link href="css/report.css" rel="stylesheet" type="text/css" />
    
   <script type="text/javascript" language="javascript" src="javascript/rept.js">
     
   
   
   </script>

    <title>Billing Register</title>
    <script type="text/javascript" language="javascript" src="javascript/prototype.js">
    </script>
</head>
<body onload="document.getElementById('btnprint').focus();"   onkeydown ="javascript:return windowop('Billregister2.aspx');">
<form id="form1" runat="server">

<div id="abc" > 


 <%-- <table style="width: 794px" >
  
<tr style="width:100px">
<td align="left" style="width: 69px">
<asp:Button ID="btnprint" runat="server" OnClick="btnprint_Click" Text="Print" />
</td> 

<td align="center"><asp:Label ID="heading" CssClass ="heading" runat ="server"></asp:Label></td>
<td align="right"></td>
</tr>
<tr><td style="width: 69px"></td></tr>
</table>--%>
 <table style="width:100%" >
  
      <tr>
      <td></td>
          <td align="center" style="height: 28px;padding-right:130px" colspan="2"><asp:Label ID="cmpnyname" CssClass ="headingc" runat ="server"></asp:Label></td>
          </tr>
          <tr style="width:100%">


<td align="left" style= "height: 28px;"  >
<asp:Button ID="btnprint" runat="server"  OnClick="btnprint_Click" Text="Print" />
</td>
<td align="center" style="height: 28px;padding-right:130px" colspan="2">
<asp:Label ID="heading" CssClass ="headingp" runat ="server"></asp:Label></td>

</tr>
<tr><td style="width: 69px"></td></tr>

</table>
 <%--   <table align="center">
<tr>
<td><asp:Label ID="heading" CssClass ="heading" runat ="server"></asp:Label></td>
</tr>
<tr><td></td></tr>
</table>--%>
     <table id="table1" cellpadding="0" cellspacing="0" align="center" border="0" >
    <tr >
        <td  class="upper2">DATE FROM:</td><td class="middle2" ><asp:Label ID="lblfrom" CssClass="reporttext2" runat="server" ></asp:Label></td>
    <td  class="upper2" >DATE TO:</td><td class="middle2" ><asp:Label ID="lblto" CssClass="reporttext2" runat="server" ></asp:Label></td>
     <td  class="upper2" >RUN DATE:</td><td class="middle2" ><asp:Label ID="lbldate" CssClass="reporttext2" runat="server" ></asp:Label></td>
<%--        <td  class="upper" style="height: 24px">PAGE</td><td><asp:Label ID="lblpage" CssClass="reporttext" runat="server"></asp:Label></td>

--%>    
        <%--<td  class="upper2"  >EDITION:</td><td class="middle2" ><asp:Label ID="lbedition" CssClass="reporttext2" runat="server" ></asp:Label></td>--%>

</tr>
<tr></tr>
<tr></tr>
<tr></tr>
<tr></tr>
    <%--<tr style="border-bottom:dashed">--%>
    <tr style="border-bottom:dashed">
    <td  class="upper2">PUBLICATION:</td><td class="middle2" ><asp:Label ID="lblcategory" CssClass="reporttext2" runat="server" ></asp:Label></td>
    <td  class="upper2" >EDITION:</td><td class="middle2"><asp:Label ID="lblproduct" CssClass="reporttext2" runat="server"></asp:Label></td>    
    <td  class="upper2">ADTYPE:</td><td class="middle2" ><asp:Label ID="lbladtype" CssClass="reporttext2" runat="server" ></asp:Label></td>
    
    <%--<td  class="upper2" >DATE TO:</td><td class="middle2" ><asp:Label ID="lblto" CssClass="reporttext2" runat="server" ></asp:Label></td>--%>
     <%--<td  class="upper2" >RUN DATE:</td><td class="middle2" ><asp:Label ID="lbldate" CssClass="reporttext2" runat="server" ></asp:Label></td>--%>
     <%--<td  class="upper2" >PAGE:</td><td class="middle2" ><asp:Label ID="Label1"  CssClass="reporttext2" runat="server"  ></asp:Label></td>--%>
          

<%--        <td  class="middle">PUB:</td><td class="middle2"><asp:Label ID="pub" CssClass="reporttext1" runat="server"></asp:Label></td>
--%>     


</tr>
 <tr style="border-bottom:dashed">
<td  class="upper2" >REGION:</td><td class="middle2"><asp:Label ID="lblregion" CssClass="reporttext2" runat="server"></asp:Label></td>    
    <td  class="upper2">AGENCY TYPE:</td><td class="middle2" ><asp:Label ID="lblagtype" CssClass="reporttext2" runat="server" ></asp:Label></td>
    <td  class="upper2">AGENCY CATEGORY:</td><td class="middle2" ><asp:Label ID="lblagcat" CssClass="reporttext2" runat="server" ></asp:Label></td>
    </tr>
    <tr style="border-bottom:dashed">
    <%--<td  class="upper2" ><asp:Label ID="lblgrp" CssClass="reporttext2" runat="server"></asp:Label></td><td class="middle2"><asp:Label ID="lblgroup" CssClass="reporttext2" runat="server"></asp:Label></td>    --%>
<td  class="upper2" >EXECUTIVE:</td><td class="middle2"><asp:Label ID="lblexecutive" CssClass="reporttext2" runat="server"></asp:Label></td>   
<td  class="upper2" >INSERT STATUS:</td><td class="middle2"><asp:Label ID="lblstatus" CssClass="reporttext2" runat="server"></asp:Label></td>    
 
   </tr>
<%--<tr>
<td  class="middle" style="width: 200px">PAGE:</td><td class="middle2" style="width: 400px;"><asp:Label ID="lblpage" CssClass="reporttext" runat="server" Width="202px"></asp:Label></td>

</tr>--%>
     
    </table>
   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <table style="width: 97%" ><tr valign="top"><td id="tblgrid" valign="top" runat="server" style="height: 21px" visible ="true"></td></tr></table>
     <table><tr> <td><input id="hiddendateformat" type="hidden" runat="server" /></td></tr></table>
    <table style="z-index: 100; left: 15px; width:900px; position: absolute; top: 22px">
        <tr>
            
           <%-- <td   align="center" style="width:800px; height: 21px;">
                <asp:Label ID="heading" CssClass ="heading" runat ="server" style="z-index: 100; left: 387px; position: absolute; top: 2px"></asp:Label>
            </td>--%>

            
  
        </tr>
    </table>
    
    
    
     <table id="Table3" align="center">
     <tr>
       
     <td align="center">
    
     <asp:DataGrid ID="DataGrid1" runat="server" CssClass="dtGrid" Width="770px" AutoGenerateColumns="False"  OnItemDataBound="DataGrid1_ItemDataBound" >
     <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
     <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3" >
     
     </HeaderStyle>
     
   
     </asp:DataGrid>
     
     </td>
     </tr>
     </table>
          <table><tr> <td><input id="hiddendatefrom" type="hidden" runat="server" /></td></tr></table>
               <table><tr> <td><input id="hiddendateto" type="hidden" runat="server" /><input id="dscount" type="hidden" runat="server" />
               
               <input id="hiddencioid" type="hidden" runat="server" />
               <input id="hiddenascdesc" type="hidden" runat="server" />
               </td></tr></table>
 
</div>
</form>
</body>

</html>

