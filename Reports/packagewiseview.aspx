<%@ Page Language="C#" AutoEventWireup="true" CodeFile="packagewiseview.aspx.cs" Inherits="packagewiseview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <link href="css/report.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="javascript" src="javascript/rept.js">
   
  
   </script>
   <script type="text/javascript" language="javascript" src="javascript/prototype.js"></script>
    <title>Package Wise Report</title>
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
        <td  class="upper2">PACKAGE:</td><td><asp:Label ID="lbpackage" CssClass="reporttext" runat="server"></asp:Label></td>   
        
        </tr>

   
    <tr style="border-bottom:dashed">
    <td  class="upper2">DATE FROM:</td><td class="middle2" ><asp:Label ID="lblfrom" CssClass="reporttext2" runat="server" >hgjhj</asp:Label></td>
    <td  class="upper2" >DATE TO:</td><td class="middle2" ><asp:Label ID="lblto" CssClass="reporttext2" runat="server" ></asp:Label></td>
     <td  class="upper2" >RUN DATE:</td><td class="middle2" ><asp:Label ID="lbldate" CssClass="reporttext2" runat="server" ></asp:Label></td>
    
</tr>
   
   <tr style="border-bottom:dashed">
    <td  class="upper2">PUBLICATION:</td><td class="middle2" ><asp:Label ID="lblpublication" CssClass="reporttext2" runat="server" >hgjhj</asp:Label></td>
    <td  class="upper2" >PUB CENTER:</td><td class="middle2" ><asp:Label ID="lblpubcent" CssClass="reporttext2" runat="server" ></asp:Label></td>
     <td  class="upper2" >EDITION:</td><td class="middle2" ><asp:Label ID="lbledition" CssClass="reporttext2" runat="server" ></asp:Label></td>
    
</tr>
   
    </table>
   
     <table style="width: 97%"><tr><td id="tblgrid" runat="server" style="height: 21px" visible ="true"></td></tr></table>
      <table style="width: 97%"><tr><td id="Td1" runat="server" style="height: 21px" visible ="true"></td></tr></table>
     <table>
       <tr>
     <td align="center">
     
     <asp:DataGrid ID="DataGrid1" runat="server" CssClass="dtGrid" Width="770px" AutoGenerateColumns="False" OnItemDataBound="DataGrid1_ItemDataBound">
     <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
     <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3" >
     
     </HeaderStyle>
     
    
  
    
     <Columns>
     
     
      <asp:BoundColumn  HeaderText="S.No" >
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
        
     <asp:BoundColumn DataField="Package" HeaderText="Package" SortExpression="Package">
     <ItemStyle HorizontalAlign="Left"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          
          <asp:BoundColumn DataField="GrossAmt" HeaderText="GrossAmt" SortExpression="GrossAmt">
     <ItemStyle HorizontalAlign="Right"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
         
          <asp:BoundColumn DataField="Trade_disc" HeaderText="Agency TD(%)" SortExpression="Trade_disc">
			<ItemStyle HorizontalAlign="Right"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			  <asp:BoundColumn DataField="Agency_DisVal" HeaderText="Agency TD(Amt)" SortExpression="Agency_DisVal">
			<ItemStyle HorizontalAlign="Right"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			  <asp:BoundColumn DataField="AgencyAddlTD(%)" HeaderText="AgencyAddl TD(%)" SortExpression="AgencyAddlTD(%)">
			<ItemStyle HorizontalAlign="Right"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			 <asp:BoundColumn DataField="AgencyAddlTDAmt" HeaderText="AgencyAddl TD(Amt)" SortExpression="AgencyAddlTDAmt">
			<ItemStyle HorizontalAlign="Right"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			
			  <asp:BoundColumn DataField="NETAMT" HeaderText="NETAMT" SortExpression="NETAMT">
			<ItemStyle HorizontalAlign="Right"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
		
			<asp:BoundColumn DataField="RetComm(%)" HeaderText="RetComm(%)" SortExpression="RetComm(%)">
			<ItemStyle HorizontalAlign="Right"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			<asp:BoundColumn DataField="RetCommAmt" HeaderText="RetComm(Amt)" SortExpression="RetCommAmt">
			<ItemStyle HorizontalAlign="Right"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			<asp:BoundColumn DataField="ActualBuss" HeaderText="Actual Bussiness" SortExpression="ActualBuss">
			<ItemStyle HorizontalAlign="Right"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
		
		   </Columns>
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
