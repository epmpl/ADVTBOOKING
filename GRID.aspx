<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GRID.aspx.cs" Inherits="GRID" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    
		<LINK href="css/main.css" type="text/css" rel="stylesheet">
			<LINK href="css/grid.css" type="text/css" rel="stylesheet">
		
		<%--<style type="text/css" rel="stylesheet>
		.font_aditya
		{
			font-family:4CAadita;
		}
		
		</style>--%>
    
</head>
<body>
    <form id="form1" runat="server">
    
    					 <table cellpadding="0" cellspacing="0" width="100%"><tr><td align="center">
    					
    					
     <div id="divgrid1"  runat="server" style="display:BLOCK; OVERFLOW: auto; WIDTH: 900px;">
     <table><tr><td><asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:Timer ID="Timer1" runat="server" Interval="2000000000" OnTick="Timer1_Tick">
</asp:Timer>
<br />
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<asp:Label runat="server" ID="lblTime" Font-Bold="True" CssClass="TextField" />
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
</Triggers>
</asp:UpdatePanel></td></tr></table>
     <table id="Table3" align="LEFT">
      <tr><td  style="COLOR:#5050A4;font-family:Arial;font-size:small;">Classified Bookings</td></tr>
      
     <tr> 
         
     <td align="center">
     <div style="overflow:auto;height:180px" >
     
     <asp:DataGrid ID="DataGrid1" runat="server" CssClass="dtGrid" Width="770px" AutoGenerateColumns="False" OnItemDataBound="DataGrid1_ItemDataBound">
     <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
     <HeaderStyle HorizontalAlign="Center" Height="15px" ForeColor="White" CssClass="DataGridFixedHeader" BackColor="#7DAAE3" Font-Names="Arial"></HeaderStyle>
     <Columns>

         <asp:TemplateColumn HeaderText="SN."></asp:TemplateColumn>
         
       <%--  <asp:TemplateColumn HeaderText="Audit"></asp:TemplateColumn>--%>
     <asp:BoundColumn DataField="cio_booking_id" HeaderText="Booking Id" SortExpression="Edition_Alias">
     <ItemStyle HorizontalAlign="Center" ></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" 
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          
          <asp:BoundColumn DataField="Client_code" HeaderText="Client Name" SortExpression="Date_Edition">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			<%--<asp:BoundColumn DataField="audit" HeaderText="Audited By" SortExpression="Date_Edition">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			<asp:BoundColumn DataField="FILENAME" HeaderText="Mat_status" SortExpression="Mat_st">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			--%>

                <asp:BoundColumn HeaderText="Auditors Comment"  DataField="AUDIT_COMMENT" ReadOnly="True" >
    <ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
          
          
     </Columns>
     </asp:DataGrid>     
    </div>
     
     </td>
  
     </tr>
     </table>
    </div>
     </td></tr></table>
     
     
     		 <table cellpadding="0" cellspacing="0" width="100%"><tr><td align="center">
     <div id="div1"  runat="server" style="display:BLOCK; OVERFLOW: auto; WIDTH: 900px;">
     <table id="Table1" align="left">
     <tr><td style="COLOR:#5050A4;font-family:Arial;;font-size:small;">Display Bookings</td></tr>
     <tr>       
     <td align="center">
     <div style="overflow:auto;height:180px" >
     
     <asp:DataGrid ID="DataGrid2" runat="server" CssClass="dtGrid" Width="770px" AutoGenerateColumns="False" OnItemDataBound="DataGrid2_ItemDataBound" >
     <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
     <HeaderStyle HorizontalAlign="Center" Height="15px" ForeColor="White" CssClass="DataGridFixedHeader" BackColor="#7DAAE3" Font-Names="Arial"></HeaderStyle>
     <Columns>
   
         <asp:TemplateColumn HeaderText="SN."></asp:TemplateColumn>
         <%--<asp:TemplateColumn HeaderText="Audit"></asp:TemplateColumn>--%>
     <asp:BoundColumn DataField="cio_booking_id" HeaderText="Booking Id" SortExpression="Edition_Alias">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          <asp:BoundColumn DataField="Client_code" HeaderText="Client Name" SortExpression="Date_Edition">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
		<%--	<asp:BoundColumn DataField="audit" HeaderText="Audited By" SortExpression="Date_Edition">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			<asp:BoundColumn DataField="FILENAME" HeaderText="Mat_status" SortExpression="Mat_st">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			

          --%>
                <asp:BoundColumn HeaderText="Auditors Comment"  DataField="AUDIT_COMMENT" ReadOnly="True" >
    <ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
          
          
     </Columns>
     </asp:DataGrid>     
    </div>
     
     </td>
  
     </tr>
     </table>
    </div>
     </td></tr></table>
     
     
     			<INPUT id="hiddencompcode" runat="server" type="hidden" NAME="hiddencompcode"> <INPUT id="hiddenuserid" runat="server" type="hidden" NAME="hiddenuserid">
			<INPUT id="hiddenusername" runat="server" type="hidden" NAME="username">
			<INPUT id="hiddencompuser" runat="server" type="hidden" NAME="username2">
			<INPUT id="hiddenadmin" runat="server" type="hidden" NAME="username1">
			<INPUT id="hiddencompname" runat="server" type="hidden" NAME="username1">
			<input id="hiddencenter" runat="server" type="hidden" name="hiddencenter" />

    </form>
</body>
</html>
