<%@ Page Language="C#" AutoEventWireup="true" CodeFile="moneyrecievedview.aspx.cs" Inherits="moneyrecievedview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<link href="css/report.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="javascript" src="javascript/rept.js">
   
  
   </script>
   <script type="text/javascript" language="javascript" src="javascript/prototype.js"></script>
    <title>Money Recieved Report</title>
</head>
<body onload="document.getElementById('btnprint').focus();" >
    <form id="form1" runat="server">
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

     <table id="table1" cellpadding="0" cellspacing="0" align="center" border="0" >
    <tr>
        
        <td  class="upper2">AGENCY:</td><td class="middle2"><asp:Label ID="lbagency" CssClass="reporttext" runat="server"></asp:Label></td>
        <td  class="upper2">CLIENT:</td><td><asp:Label ID="lbclient" CssClass="reporttext" runat="server"></asp:Label></td>   
        <td  class="upper2">PAYMODE:</td><td><asp:Label ID="lbpaymode" CssClass="reporttext" runat="server"></asp:Label></td>   
        
        </tr>
<tr></tr>
<tr></tr>
<tr></tr>
<tr></tr>
   
    <tr style="border-bottom:dashed">
    <td  class="upper2">DATE FROM:</td><td class="middle2" ><asp:Label ID="lblfrom" CssClass="reporttext2" runat="server" >hgjhj</asp:Label></td>
    <td  class="upper2" >DATE TO:</td><td class="middle2" ><asp:Label ID="lblto" CssClass="reporttext2" runat="server" ></asp:Label></td>
     <td  class="upper2" >RUN DATE:</td><td class="middle2" ><asp:Label ID="lbldate" CssClass="reporttext2" runat="server" ></asp:Label></td>
    
</tr>
   
    </table>
   
     <table style="width: 100%"><tr valign="top"> <td  valign="top" id="tblgrid" runat="server" style="height: 21px" visible ="true"></td></tr></table>
     <table>
       <tr>
     <td align="center">
     
     <asp:DataGrid ID="DataGrid1" runat="server" CssClass="dtGrid" Width="770px" AutoGenerateColumns="False" OnItemDataBound="DataGrid1_ItemDataBound">
     <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
     <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3" >
     
     </HeaderStyle>
     
    
  
    
   
     </asp:DataGrid>
     
     </td>
     </tr>
     </table>
     <input id="hiddendatefrom" type="hidden" runat="server" />
      <input id="hiddendateto" type="hidden" runat="server" />
      <input id="dscount" type="hidden" runat="server" />
      <input id="hiddencioid" type="hidden" runat="server"  />
      <input id="hiddenascdesc" type="hidden" runat="server" />
      <input id="hiddendateformat" type="hidden" runat="server" />
       
    </form>
</body>
</html>
