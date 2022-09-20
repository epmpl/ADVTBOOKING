<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeFile="reportstatus.aspx.cs" Inherits="reportstatus" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <link href="css/report.css" rel="stylesheet" type="text/css" />
       <script type="text/javascript" language="javascript" src="javascript/rept.js">
       function maximize()
        {
        window.moveTo(0,0)            
        window.resizeTo(screen.availWidth, screen.availHeight)
         }
        maximize();
       </script>
        <script type="text/javascript" language="javascript" src="javascript/prototype.js">
</script>



    <title>Status Based Ad List</title>
</head>
<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
<%--<table style="width: 894px" >
  
<tr style="width:100px">
<td align="left" style="width: 69px" ><asp:Button ID="btnprint" runat="server" Text="Print" OnClick="btnprint_Click1" /></td> 

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
<%--//<td><asp:Label ID="lbstatus"  runat ="server"></asp:Label></td>--%>

<%--</tr>
<tr><td></td></tr>
</table>--%>
    <table id="table1" cellpadding="0" cellspacing="0" align="center" border="0" >
    <tr>
         <td  class="upper2" style="width: 300px" >PUBLICATION:</td><td><asp:Label ID="lblpub" CssClass="reporttext2" runat="server"></asp:Label></td>
        <td  class="upper2"  >PUB CENTER:</td><td><asp:Label ID="pcenter" CssClass="reporttext2" runat="server"></asp:Label></td>
        <td  class="upper2"  >EDITION:</td><td class="middle2" ><asp:Label ID="lbedition" CssClass="reporttext2" runat="server" ></asp:Label></td>
        <td  class="upper2"  >STATUS:</td><td class="middle2" ><asp:Label ID="lbstatus" CssClass="reporttext2" runat="server" ></asp:Label></td>
       
    </tr>
    <tr style="border-bottom:dashed">
         <td  class="upper2" >DATE FROM:</td><td class="middle2"><asp:Label ID="lblfrom" CssClass="reporttext2" runat="server">hgjhj</asp:Label></td>
      <td  class="upper2" >DATE TO:</td><td class="middle2"><asp:Label ID="lblto" CssClass="reporttext2" runat="server"></asp:Label></td>
      <td  class="upper2" >RUN DATE:</td><td class="middle2"><asp:Label ID="lbldate" CssClass="reporttext2" runat="server"></asp:Label></td>
        <td  class="upper2" >AGENCY TYPE:</td><td class="middle2"><asp:Label ID="lblagtype" CssClass="reporttext2" runat="server"></asp:Label></td>
      
        
    </tr>

          <tr style="border-bottom:dashed">
    <td  class="upper2" valign="top" >AD TYPE:</td><td class="middle2" valign="top"><asp:Label ID="lbladtype" CssClass="reporttext2" runat="server" >hgjhj</asp:Label></td>
    <td  class="upper2" ></td><td class="middle2" ></td>
     <td  class="upper2" valign="top" >AD CATEGORY:</td><td class="middle2" valign="top"><asp:Label ID="lbladcatg" CssClass="reporttext2" runat="server" ></asp:Label></td>
      


</tr>
     
    </table>
     <table width="100%" ><tr valign="top"><td id="tblgrid" runat="server" style="height: 21px" valign="top"></td></tr><tr valign="top"><td valign="top">    <asp:Label ID="dynamictable" runat="server"></asp:Label> </td></tr>
   
    </table>
     <table><tr> <td><input id="hiddendateformat" type="hidden" runat="server" /></td></tr></table>
          <table><tr> <td><input id="hiddendatefrom" type="hidden" runat="server" /></td></tr></table>
               <table><tr> <td><input id="hiddendateto" type="hidden" runat="server" /></td></tr></table>
               <table>
               <tr>
                  <td><input id="hiddenascdesc" type="hidden" runat="server" /></td>
  <td> <input id="hiddencioid" type="hidden" runat="server"  /></td></tr>
  </table>
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
<%--<table id="Table3" align="center">
     <tr>
       
     <td align="center">
     <asp:UpdatePanel ID="UpdatePanel12" runat="server"><ContentTemplate>
     <asp:DataGrid ID="DataGrid1" runat="server" CssClass="dtGrid" Width="770px" AutoGenerateColumns="False" OnItemDataBound="DataGrid1_ItemDataBound"  >
     <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
     <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3" >
     
     </HeaderStyle>
     
    
  
    
     <Columns>
     
     <asp:BoundColumn HeaderText="S.No">
     <ItemStyle HorizontalAlign="Left"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
        
     <asp:BoundColumn DataField="CIOID" HeaderText="Booking Id" SortExpression="CIOID">
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
			
			
			
			 <asp:BoundColumn DataField="AdCat" HeaderText="AdCat" SortExpression="AdCat">
			<ItemStyle HorizontalAlign="Left"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			<asp:BoundColumn DataField="RateCode" HeaderText="RateCode" SortExpression="RateCode">
			<ItemStyle HorizontalAlign="Left"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			 <asp:BoundColumn DataField="CardRate" HeaderText="CardRate" SortExpression="CardRate">
			<ItemStyle HorizontalAlign="Right"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			 <asp:BoundColumn DataField="Amt" HeaderText="Amt" SortExpression="Amt">
			<ItemStyle HorizontalAlign="Right"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			 <asp:BoundColumn DataField="Disc" HeaderText="Disc" SortExpression="Disc">
			<ItemStyle HorizontalAlign="Right"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			
			<asp:BoundColumn DataField="Status" HeaderText="Status" SortExpression="Status">
			<ItemStyle HorizontalAlign="Left"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			<asp:BoundColumn DataField="MatStatus" HeaderText="MatStatus" SortExpression="MatStatus">
			<ItemStyle HorizontalAlign="Left"></ItemStyle>
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
     </ContentTemplate></asp:UpdatePanel>
     </td>
     </tr>
     </table>--%>
 
    
    </form>
</body>
</html>
