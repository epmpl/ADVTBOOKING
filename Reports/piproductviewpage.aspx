<%@ Page Language="C#" AutoEventWireup="true" CodeFile="piproductviewpage.aspx.cs" Inherits="piproductviewpage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <link href="css/report.css" rel="stylesheet" type="text/css" />
  <script type="text/javascript" language="javascript" src="javascript/rept.js">
  function maximize()
        {
        window.moveTo(0,0)            
        window.resizeTo(screen.availWidth, screen.availHeight)
         }
        maximize();
  </script>


    <title>PI Report</title>
    <script type="text/javascript" language="javascript" src="javascript/prototype.js">
<script language="javascript" type="text/javascript">
// <!CDATA[

function table1_onclick() {

}

// ]]>
</script>
</head>
<body onload="document.getElementById('btnprint').focus();" onkeydown="javascript:return windowop('pireport.aspx');">
    <form id="form1" runat="server">

<%--<table style="width: 794px" >
  
<tr style="width:100px">
<td align="left" style="width: 69px" >
<asp:Button ID="btnprint" runat="server" OnClick="btnprint_Click" Text="Print" /></td>

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
<%--<input type="button" id="btnprint" value ="Print"  runat ="server"  onclick="javascript:return printbtn();"   />

    <form id="form1" runat="server">
    <table align="center">
<tr>
<td><asp:Label ID="heading" CssClass ="heading" runat ="server"></asp:Label></td>
</tr>
<tr><td></td></tr>
</table>--%>
    
     <table id="table1" cellpadding="0" cellspacing="0" align="center" border="0" <%--onclick="return table1_onclick()"--%> >
 <tr>
        <td class="upper2" >DATE FROM:</td><td class="middle2"><asp:Label ID="lblfrom" CssClass="reporttext1" runat="server" ></asp:Label></td>
       <td class="upper2" >DATE TO:</td><td class="middle2"><asp:Label ID="lblto" CssClass="reporttext1" runat="server" ></asp:Label></td>
        <td  class="upper2" >RUN DATE:</td><td><asp:Label ID="lbldate" CssClass="reporttext2" runat="server"></asp:Label></td>
        <%--<td  class="upper2" >PUBCENTER:</td><td><asp:Label ID="pcenter" CssClass="reporttext2" runat="server" Width="98px" Height="15px"></asp:Label></td>--%>
        <%--<td  class="upper2">AGENCY:</td><td class="middle2"><asp:Label ID="lbAgencyna" CssClass="reporttext2" runat="server"></asp:Label></td><%--<td class="upper2">EDITION:</td><td class="middle2"><asp:Label ID="lbedition" CssClass="reporttext2" runat="server"></asp:Label></td>
--%>
    </tr>
        <tr style="border-bottom:dashed">
        <%-- <td  class="upper2" >ADCATGORY:</td><td "middle2"> <asp:Label ID="Adcat" CssClass="reporttext2" runat="server"></asp:Label></td>--%>
         <td  class="upper2">PRODUCT:</td><td class="middle2"> <asp:Label ID="lblproduct" CssClass="reporttext2" runat="server"></asp:Label></td>
         <td  class="upper2">REGION:</td><td class="middle2"> <asp:Label ID="lblregion" CssClass="reporttext2" runat="server"></asp:Label></td>
        <td  class="upper2">ADTYPE:</td><td class="middle2"> <asp:Label ID="lbladtype" CssClass="reporttext2" runat="server"></asp:Label></td>
        
        <%-- <td  class="upper2">UOM:</td><td class="middle2"> <asp:Label ID="lbluom" CssClass="reporttext2" runat="server"></asp:Label></td>--%>

         <%--<td  class="upper2">RUN DATE:</td><td class="middle2"> <asp:Label ID="lbldate" CssClass="reporttext2" runat="server"></asp:Label></td>--%>
         
         <%--<td  class="upper2" >PRODUCT:</td><td class="middle2" > <asp:Label ID="lbclient" CssClass="reporttext2" runat="server"></asp:Label></td>
          <td  class="upper" >REGION:</td><td class="middle2"> <asp:Label ID="lblpage" CssClass="reporttext2" runat="server"></asp:Label></td>--%>

<%--        <td  class="middle">PUB:</td><td class="middle2"><asp:Label ID="pub" CssClass="reporttext1" runat="server"></asp:Label></td>
--%>     </tr>
     
     
     
     <tr style="border-bottom:dashed">
    <td  class="upper2">PUBLICATION:</td><td class="middle2"> <asp:Label ID="lblpublication" CssClass="reporttext2" runat="server"></asp:Label></td>
  <td  class="upper2">AGENCY TYPE:</td><td class="middle2" ><asp:Label ID="lblagtype" CssClass="reporttext2" runat="server" ></asp:Label></td>
    
   </tr>
     
    </table>  
         <table width="100%"><tr valign="top"><td  valign="top" id="tblgrid" runat="server"></td></tr></table>


    
    
      <%-- <table id="Table3" align="center">
     <tr>
       
     <td align="center">
    
     <asp:DataGrid ID="DataGrid1" runat="server" CssClass="dtGrid" Width="770px" AutoGenerateColumns="False"  OnItemDataBound="DataGrid1_ItemDataBound" >
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
			
			  <asp:BoundColumn DataField="Area" HeaderText="Area" SortExpression="Area">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
				
			 <asp:BoundColumn DataField="RevenueCenter" HeaderText="RevenueCenter" SortExpression="RevenueCenter">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			 <asp:BoundColumn DataField="Rate" HeaderText="Rate" SortExpression="Rate">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			<asp:BoundColumn DataField="Premium" HeaderText="Premium" SortExpression="Premium">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			<asp:BoundColumn DataField="BillRemark" HeaderText="BillRemark" SortExpression="BillRemark">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			<asp:BoundColumn DataField="Color" HeaderText="Color" SortExpression="Color">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			<asp:BoundColumn DataField="Category" HeaderText="Category" SortExpression="Category">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>

			
			 <asp:BoundColumn DataField="SubCategory" HeaderText="SubCategory" SortExpression="SubCategory">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			 <asp:BoundColumn DataField="Package" HeaderText="Package" SortExpression="Package">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			 <asp:BoundColumn DataField="BillAmt" HeaderText="BillAmt" SortExpression="BillAmt">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			<asp:BoundColumn DataField="AgencyComm" HeaderText="AgencyComm" SortExpression="AgencyComm">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
   

     </Columns>
     </asp:DataGrid>
     
     </td>
     </tr>
     </table>--%>
 <table id="xlsgrid" align="center">
     <tr>
       
     <td align="center">
    <%-- <asp:UpdatePanel ID="UpdatePanel12" runat="server"><ContentTemplate>--%>
     <asp:DataGrid ID="DataGrid1" runat="server" CssClass="dtGrid" Width="770px" AutoGenerateColumns="False" OnItemDataBound="DataGrid1_ItemDataBound"  >
     <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
     <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3" >     
     </HeaderStyle>
     </asp:DataGrid>
     <%--</ContentTemplate></asp:UpdatePanel>--%>
     </td>
     </tr>
     </table>

         <table><tr> <td><input id="hiddendateformat" type="hidden" runat="server" /></td></tr></table>
                  <table><tr> <td><input id="hiddendatefrom" type="hidden" runat="server" /></td></tr></table>
               <table><tr> <td><input id="hiddendateto" type="hidden" runat="server" /></td></tr></table>
               <table><tr> <td> <input id="hiddencioid" type="hidden" runat="server" onTextChange="hiddencioid_TextChange" />
               <input id="hiddenascdesc" type="hidden" runat="server" /></td></tr></table>
 

    </form>
</body>
</html>

