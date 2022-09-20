<%@ Page EnableEventValidation="false" Language="C#" AutoEventWireup="true" CodeFile="DealReportView.aspx.cs" Inherits="DealReportView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DealReportView</title>
     <link href="css/report.css" rel="stylesheet" type="text/css" />
     	<script type="text/javascript" language="javascript" src="javascript/DealReport.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="abc">



  <table style="width: 794px" >
  <tr>
          <td align="center" style="height: 28px" colspan="3"><asp:Label ID="cmpnyname" CssClass ="headingc" runat ="server"></asp:Label></td>
          </tr>
<tr style="width:100px">


<td align="left" style= "height: 28px;width:50px;"  >
<asp:Button ID="btnprint" runat="server"   Text="Print"  />
</td>
<td align="center" style="height: 28px;padding-right:30px" colspan="2">
<asp:Label ID="heading" CssClass ="headingp" runat ="server"></asp:Label></td>

</tr>
<tr><td style="width: 69px"></td></tr>
</table>
  <table id="table1" cellpadding="0" cellspacing="0" align="center" border="0" >
    <tr>
        <td  class="upper2">DATE FROM:</td><td class="middle2" ><asp:Label ID="lblfrom" CssClass="reporttext2" runat="server" ></asp:Label></td>
        <td  class="upper2" >DATE TO:</td><td class="middle2" ><asp:Label ID="lblto" CssClass="reporttext2" runat="server" ></asp:Label></td>
        <td  class="upper2" >RUN DATE:</td><td class="middle2" ><asp:Label ID="lbldate" CssClass="reporttext2" runat="server" ></asp:Label></td>
  
    </tr>
    <tr style="border-bottom:dashed">
    <td class="upper2">
    <asp:Label ID="pubnamelb" CssClass="reporttext2" runat="server">ADTYPE:</asp:Label>
    </td>
    <td class="middle2"><asp:Label ID="lbladtype" CssClass="reporttext2" runat="server"></asp:Label></td> 
        <td colspan="2"></td>
         <td class="upper2"  align="right" style="width:170px" >DEALTYPE:</td>
         <td class="middle2"><asp:Label ID="lbldealtype" CssClass="reporttext2" runat="server"></asp:Label></td>    
   
</tr>
    </table>
      <table style="width: 97%"><tr valign="top"><td  valign="top" id="tblgrid" runat="server" style="height: 21px" visible ="true"></td></tr>
      <tr><td id="tblgrid1" colspan="19" runat="server" style="height: 21px" visible ="true"></td></tr></table>
       <table id="xlsgrid" align="center">
     <tr>
       
     <td align="center">
     <asp:DataGrid ID="DataGrid1" runat="server" CssClass="dtGrid" Width="770px" 
             AutoGenerateColumns="False" onitemdatabound="DataGrid1_ItemDataBound"   >
     <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
     <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3" >     
     </HeaderStyle>
     </asp:DataGrid>
     </td>
     </tr>
     </table>
    </div>
    <input id="hiddendateformat" type="hidden" runat="server" />
    </form>
</body>
</html>
