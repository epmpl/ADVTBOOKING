<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Pubrebateview.aspx.cs" Inherits="Pubrebateview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
 <script type="text/javascript" language="javascript" src="javascript/rept.js">
 function maximize()
        {
        window.moveTo(0,0)            
        window.resizeTo(screen.availWidth, screen.availHeight)
         }
        maximize();
 </script>
<head id="Head1" runat="server">
    <title>Rebate Report Publication Wise</title>
    <script type="text/javascript" language="javascript" src="javascript/prototype.js"></script>

    <link href="css/report.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
     <table style="width: 794px" >
  
<tr style="width:100px">
<td align="left" style="width: 69px">
    &nbsp;<%--<input type="button" id="btnprint" value ="Print"  runat ="server"  onserverclick="btnprint_ServerClick"   />--%></td> 

<td align="center"><asp:Label ID="heading" CssClass ="heading" runat ="server"></asp:Label></td>
<td align="right"></td>
</tr>
<tr><td style="width: 69px"></td></tr>
</table>
 <table id="table1" cellpadding="0" cellspacing="0" align="center" border="0" >
   <tr >
        <%--<td class="upper2">ADTYPE:</td><td class="middle2"  ><asp:Label ID="lbladtype" CssClass="reporttext2" runat="server" ></asp:Label></td>--%>
        <td  class="upper2">PRODUCT:</td><td class="middle2"  ><asp:Label ID="lblproduct" CssClass="reporttext2" runat="server" ></asp:Label></td>
        <td  class="upper2">CATEGORY:</td><td class="middle2"  ><asp:Label ID="lblcategory" CssClass="reporttext2" runat="server" ></asp:Label></td>
<%--        <td  class="upper" style="height: 24px">PAGE</td><td><asp:Label ID="lblpage" CssClass="reporttext" runat="server"></asp:Label></td>

--%>    
        <td  class="upper2"  >EDITION:</td><td class="middle2" ><asp:Label ID="lbedition" CssClass="reporttext2" runat="server" ></asp:Label></td>

</tr>
<tr></tr>
<tr></tr>
<tr></tr>
<tr></tr>
    <%--<tr style="border-bottom:dashed">--%>
    <tr style="border-bottom:dashed">
    <%--<td  class="upper2" >ADCATGORY:</td><td class="middle2"><asp:Label ID="Adcat" CssClass="reporttext2" runat="server"></asp:Label></td>    --%>
    <td  class="upper2">DATE FROM:</td><td class="middle2" ><asp:Label ID="lblfrom" CssClass="reporttext2" runat="server" >hgjhj</asp:Label></td>
    <td  class="upper2" >DATE TO:</td><td class="middle2" ><asp:Label ID="lblto" CssClass="reporttext2" runat="server" ></asp:Label></td>
     <td  class="upper2" >RUN DATE:</td><td class="middle2" ><asp:Label ID="lbldate" CssClass="reporttext2" runat="server" ></asp:Label></td>
     <%--<td  class="upper2" >PAGE:</td><td class="middle2" ><asp:Label ID="Label1"  CssClass="reporttext2" runat="server"  ></asp:Label></td>--%>
          

<%--        <td  class="middle">PUB:</td><td class="middle2"><asp:Label ID="pub" CssClass="reporttext1" runat="server"></asp:Label></td>
--%>     


</tr>
<%--<tr>
<td  class="middle" style="width: 200px">PAGE:</td><td class="middle2" style="width: 400px;"><asp:Label ID="lblpage" CssClass="reporttext" runat="server" Width="202px"></asp:Label></td>

</tr>--%>
     
    </table>
         <table style="width: 97%"><tr><td id="tblgrid" runat="server" style="height: 21px" visible ="true"></td></tr><tr><td>    <asp:Label ID="dynamictable" runat="server"></asp:Label> </td></tr></table>
<table id="Table3" align="center">
     <tr>
       
     <td align="center">
     <asp:UpdatePanel ID="UpdatePanel12" runat="server"><ContentTemplate>
     <asp:DataGrid ID="DataGrid1" runat="server" CssClass="dtGrid" Width="770px" AutoGenerateColumns="False" OnItemDataBound="DataGrid1_ItemDataBound" >
     <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
     <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3" >
     
     </HeaderStyle>
     
    
  
    
     <Columns>
     
     <asp:BoundColumn HeaderText="S.No">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
        
     <asp:BoundColumn DataField="CIOID" HeaderText="CIOID Id" SortExpression="CIOID">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          
          <asp:BoundColumn DataField="Agency" HeaderText="Agency" SortExpression="Agency">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			  <asp:BoundColumn DataField="Client" HeaderText="Client" SortExpression="Client">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
							
			  <asp:BoundColumn DataField="Publication" HeaderText="Publication" SortExpression="Publication">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			  <asp:BoundColumn DataField="AdType" HeaderText="AdType" SortExpression="AdType">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			  <asp:BoundColumn DataField="PaymentType" HeaderText="PaymentType" SortExpression="PaymentType">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			 
			
			  <asp:BoundColumn DataField="Area" HeaderText="Area" SortExpression="Area">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			 <asp:BoundColumn DataField="BillAmt" HeaderText="BillAmt" SortExpression="BillAmt">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			<asp:BoundColumn DataField="BillStatus" HeaderText="BillStatus" SortExpression="BillStatus">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			 
			 <asp:BoundColumn DataField="BillableArea" HeaderText="BillableArea" SortExpression="BillableArea">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			
			
			 <asp:BoundColumn DataField="CardRate" HeaderText="CardRate" SortExpression="CardRate">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			 <asp:BoundColumn DataField="AgreedRate" HeaderText="AgreedRate" SortExpression="AgreedRate">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			 <asp:BoundColumn DataField="Disc" HeaderText="Disc" SortExpression="Disc">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
				
			 <asp:BoundColumn DataField="RevenueCenter" HeaderText="RevenueCenter" SortExpression="RevenueCenter">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			
          
     </Columns>
     </asp:DataGrid>
     </ContentTemplate></asp:UpdatePanel>
     </td>
     </tr>
     </table>
     
     
      <table><tr> <td><input id="hiddendateformat" type="hidden" runat="server" /></td></tr></table>
      <table><tr> <td><input id="hiddendateto" type="hidden" runat="server" /><input id="dscount" type="hidden" runat="server" />
               <input id="hiddencioid" type="hidden" runat="server"  />
               <input id="hiddenascdesc" type="hidden" runat="server" />
               </td></tr></table>
 
    </form>
</body>
</html>

