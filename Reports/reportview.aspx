<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" Debug="true" CodeFile="reportview.aspx.cs" Inherits="Reportview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <link href="css/report.css" rel="stylesheet" type="text/css" />
    <link href="css/main.css" type="text/css" rel="stylesheet" />
   <script type="text/javascript" language="javascript" src="javascript/rept.js">

   function maximize()
        {
        window.moveTo(0,0)            
        window.resizeTo(screen.availWidth, screen.availHeight)
         }
        maximize();
  </script>
<script type="text/javascript" language="javascript" src="javascript/prototype.js"></script>
   <title>All Ads of A Day</title>
   
</head>
<body onload="document.getElementById('btnprint').focus();" onkeydown ="javascript:return windowreort();">
<form id="form1" runat="server">

<div id="abc">


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
    <tr >
        <td  class="upper2" valign="top" >PUBLICATION:</td><td class="middle2"  valign="top"><asp:Label ID="lblpub" CssClass="reporttext2" runat="server" ></asp:Label></td>
        <td  class="upper2" valign="top" >PUB CENTER:</td><td class="middle2"  valign="top"><asp:Label ID="pcenter" CssClass="reporttext2" runat="server" ></asp:Label></td>
   
        <td  class="upper2" valign="top" >EDITION:</td><td class="middle2" valign="top"><asp:Label ID="lbedition" CssClass="reporttext2" runat="server" ></asp:Label></td>
<td  class="upper2" valign="top" >AGENCY TYPE:</td><td class="middle2" valign="top"><asp:Label ID="lblagtype" CssClass="reporttext2" runat="server" ></asp:Label></td>

</tr>
<tr></tr>
<tr></tr>
<tr></tr>
<tr></tr>
    <tr style="border-bottom:dashed">
    <td  class="upper2" valign="top" >DATE FROM:</td><td class="middle2" valign="top"><asp:Label ID="lblfrom" CssClass="reporttext2" runat="server" ></asp:Label></td>
    <td  class="upper2" valign="top" >DATE TO:</td><td class="middle2" valign="top"><asp:Label ID="lblto" CssClass="reporttext2" runat="server" ></asp:Label></td>
    <td></td>  <td></td>
     <td  class="upper2" valign="top">RUN DATE:</td><td class="middle2" valign="top"><asp:Label ID="lbldate" CssClass="reporttext2" runat="server" ></asp:Label></td>
</tr>

<tr></tr>
<tr></tr>
<tr></tr>
<tr></tr>
 <tr style="border-bottom:dashed">
    <td  class="upper2" valign="top" >AD TYPE:</td><td class="middle2" valign="top"><asp:Label ID="lbladtype" CssClass="reporttext2" runat="server" ></asp:Label></td>
    
     <td  class="upper2" valign="top" >AD CATEGORY:</td><td class="middle2" valign="top"><asp:Label ID="lbladcatg" CssClass="reporttext2" runat="server" ></asp:Label></td>
   <td  class="upper2" valign="top" >AD SUBCAT:</td><td class="middle2" valign="top" ><asp:Label ID="lbladsubcat" CssClass="reporttext2" runat="server"  ></asp:Label></td>
     

</tr>


     
    </table>
   
     <table  style="width: 100%;vertical-align:top;" border="0"><tr valign="top" style="vertical-align:top">
     <td valign="top" id="tblgrid" runat="server" style="height: 21px;vertical-align:top;" visible ="true">
     </td></tr>
     </table>
     <table><tr> <td><input id="hiddendateformat" type="hidden" runat="server" /></td></tr></table>
    <table style="z-index: 100; left: 15px; width:900px; position: absolute; top: 22px">
        <tr>
       </tr>
    </table>
          <table><tr> <td><input id="hiddendatefrom" type="hidden" runat="server" /></td></tr></table>
               <table><tr> <td><input id="hiddendateto" type="hidden" runat="server" /><input id="dscount" type="hidden" runat="server" /></td></tr></table>
   <input id="hiddenascdesc" type="hidden" runat="server" />
   <input id="hiddencioid" type="hidden" runat="server" />
		
			<table width="100%"><tr><td id="Td1" runat="server"></td></tr>
     <tr><td><asp:Label ID="dynamictable" runat="server" ></asp:Label> </td></tr>
   
    </table>
			<td  rowspan="2">
            <asp:Label id="errLabel" runat="server" Width="335px" Height="24px"></asp:Label></TD>
            
                 <%--<table id="Table3" align="center">
     <tr>
       
     <td align="center">
     <asp:DataGrid ID="DataGrid1" runat="server" CssClass="dtGrid" Width="770px" AutoGenerateColumns="False" OnItemDataBound="DataGrid1_ItemDataBound"  >
     <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
     <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3" >
     
     </HeaderStyle>
     
     <Columns>
     
      <asp:BoundColumn  HeaderText="S.No" >
     <ItemStyle HorizontalAlign="Left"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
        
     <asp:BoundColumn DataField="CIOID" HeaderText="Booking ID" SortExpression="CIOID">
     <ItemStyle HorizontalAlign="Left"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          
          <asp:BoundColumn DataField="edition" HeaderText="Edition" SortExpression="edition">
     <ItemStyle HorizontalAlign="Left"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          
           <asp:BoundColumn DataField="Ins.Date" HeaderText="Publish Date" SortExpression="Ins.Date">
     <ItemStyle HorizontalAlign="Left"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          
         
          <asp:BoundColumn DataField="Agency" HeaderText="Agency" SortExpression="Agency">
			<ItemStyle HorizontalAlign="Left"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			  <asp:BoundColumn DataField="Client" HeaderText="Client" SortExpression="Client">
			<ItemStyle HorizontalAlign="Left"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			  <asp:BoundColumn DataField="Package" HeaderText="Package" SortExpression="Package">
			<ItemStyle HorizontalAlign="Left"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			  <asp:BoundColumn DataField="Depth" HeaderText="Depth" SortExpression="Depth">
			<ItemStyle HorizontalAlign="Right"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			  <asp:BoundColumn DataField="Width" HeaderText="Width" SortExpression="Width">
			<ItemStyle HorizontalAlign="Right"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			  <asp:BoundColumn DataField="Area" HeaderText="Area" SortExpression="Area">
			<ItemStyle HorizontalAlign="Right"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			 <asp:BoundColumn DataField="Color_code" HeaderText="Color" SortExpression="Hue">
			<ItemStyle HorizontalAlign="Left"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			 <asp:BoundColumn DataField="Page" HeaderText="Page Position" SortExpression="Page">
			<ItemStyle HorizontalAlign="Left"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
		
			
			 <asp:BoundColumn DataField="PagePremium" HeaderText="Page Prem" >
			<ItemStyle HorizontalAlign="Left"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			 <asp:BoundColumn DataField="PositionPremium" HeaderText="Position Prem" >
			<ItemStyle HorizontalAlign="Left"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			 <asp:BoundColumn DataField="BulletPremium" HeaderText="Eye Catcher" >
			<ItemStyle HorizontalAlign="Left"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			 <asp:BoundColumn DataField="RoNo." HeaderText="Ro No." SortExpression="AdType">
			<ItemStyle HorizontalAlign="Left"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			 <asp:BoundColumn DataField="RoStatus" HeaderText="Ro Status" SortExpression="AdType">
			<ItemStyle HorizontalAlign="Left"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			
			 <asp:BoundColumn DataField="AdCat" HeaderText="AdCat" SortExpression="AdCat">
			<ItemStyle HorizontalAlign="Left"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			 <asp:BoundColumn DataField="CardRate" HeaderText="CardRate" SortExpression="CardRate">
			<ItemStyle HorizontalAlign="Right"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			 <asp:BoundColumn DataField="AgreedRate" HeaderText="AgreedRate" SortExpression="AgreedRate">
			<ItemStyle HorizontalAlign="Right"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			 <asp:BoundColumn DataField="Amt" HeaderText="Amt" SortExpression="Amt">
			<ItemStyle HorizontalAlign="Right"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			 <asp:BoundColumn DataField="Cap" HeaderText="Caption" SortExpression="Cap">
			<ItemStyle HorizontalAlign="Left"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			 <asp:BoundColumn DataField="Key" HeaderText="Key No." SortExpression="Key">
			<ItemStyle HorizontalAlign="Left"></ItemStyle>
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
     <asp:DataGrid ID="DataGrid1" runat="server" CssClass="dtGrid" Width="770px" AutoGenerateColumns="False" OnItemDataBound="DataGrid1_ItemDataBound"  >
     <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
     <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3" >     
     </HeaderStyle>
     </asp:DataGrid>
     </td>
     </tr>
     </table>
			
     </form>
</body>

</html>
