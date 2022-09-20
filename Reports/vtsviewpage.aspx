<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation ="false"  CodeFile="vtsviewpage.aspx.cs" Inherits="Reports_vtsviewpage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <link href="css/report.css" rel="stylesheet" type="text/css" />
      
      <%-- function maximize()
        {
        window.moveTo(0,0)            
        window.resizeTo(screen.availWidth, screen.availHeight)
         }
        maximize();--%>

 <script type="text/javascript"  language="javascript" src="javascript/VTSREPT.js"></script>
    <title>VTS REPORT</title>
    <script type="text/javascript" language="javascript" src="javascript/prototype.js"></script>
<script language="javascript" type="text/javascript">
 
// <!CDATA[

function table1_onclick() {

}

// ]]>
</script>
</head>
<body  >

    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
    
<%--    <table style="width: 794px" >
  
<tr style="width:100px">
<td align="left" style="width: 69px" ><asp:Button ID="btnprint" runat="server" OnClick="btnprint_Click" Text="Print" /></td> 

<td align="center"><asp:Label ID="heading" CssClass ="heading" runat ="server"></asp:Label></td>
<td align="right"></td>
</tr>
<tr><td style="width: 69px"></td></tr>
</table>--%>
  <table style="width:100%" >
  
      <tr>
      
      <td align="left" style= "height: 28px;"  >
<asp:Button ID="btnprint" runat="server"  OnClick="btnprint_Click" Text="Print" />
</td> <tr valign="top">
          <td align="center" style="height: 28px;" colspan="2"><asp:Label ID="comp_name" CssClass ="headingc" runat ="server"></asp:Label></td>
          </tr>
          <tr valign="top"><td align="center" style="height: 28px;" colspan="2"><asp:Label ID="report_name" CssClass ="headingc" runat ="server"></asp:Label></td>
          
          </tr>
          
          <%--<tr style="width:100%">
           


<td align="center">
<asp.Label ID="title" CssClass="headingp"  runat ="server"></asp.label></td>
<td align="center" style="padding-right:120px">
<asp:Label ID="heading" CssClass ="headingp" runat ="server"></asp:Label></td>


</tr>--%>


</table>
 <%--<div>
    <table style="width:1000px">
        <tr><td id="subregrepDiv" runat ="server" ></td>
       </tr>
       </table> 
    </div>--%>
    
     <table id="table1" width="90%" cellpadding="0" cellspacing="0" align="center" border="0"  >
    <tr valign="top"><%--<td  class="upper2">AGENCY:</td><td class="middle2"><asp:Label ID="lbAgencyna" CssClass="reporttext2" runat="server"></asp:Label></td>--%>
        <%--<td class="upper2" >ADTYPE:</td><td class="middle2"><asp:Label ID="lbladtype" CssClass="reporttext2" runat="server" ></asp:Label></td>--%>
        <td   class="upper2" >Publication:</td><td><asp:Label ID="lblpub" CssClass="reporttext2" runat="server"></asp:Label></td>
        <td  class="upper2" >PubCenter:</td><td><asp:Label ID="pcenter" CssClass="reporttext2" runat="server"></asp:Label></td>
          <td  class="upper2">Branch:</td><td class="middle2" ><asp:Label ID="lbbranch" CssClass="reporttext2" runat="server" ></asp:Label></td>
          <td  class="upper2">Client type:</td><td class="middle2" ><asp:Label ID="lblclientype" CssClass="reporttext2" runat="server" ></asp:Label></td>
           <td  class="upper2">Adtype:</td><td class="middle2" ><asp:Label ID="lbladtype" CssClass="reporttext2" runat="server" ></asp:Label></td>
            
 
        
    </tr>
        <tr valign="top" style="border-bottom:dashed">
        <%-- <td  class="upper2" >ADCATGORY:</td><td "middle2"> <asp:Label ID="Adcat" CssClass="reporttext2" runat="server"></asp:Label></td>--%>
         <td   valign='top' class="upper2">Edition:</td><td class="middle2"> <asp:Label ID="lbedition" CssClass="reporttext2" runat="server"></asp:Label></td>
         <td  valign='top'class="upper2">Date From :</td><td class="middle2"> <asp:Label ID="lblfrom" CssClass="reporttext2" runat="server"></asp:Label></td>
         <td  valign='top'class="upper2">To Date </td><td class="middle2"> <asp:Label ID="lblto" CssClass="reporttext2" runat="server"></asp:Label></td>
       
         <td style="width:400px;"  class="upper2">Run Date:</td><td class="middle2"> <asp:Label ID="lbldate" CssClass="reporttext2" runat="server"></asp:Label></td>
       
          <%--<td  class="upper" >PAGE:</td><td class="middle2"> <asp:Label ID="lblpage" CssClass="reporttext2" runat="server"></asp:Label></td>--%>

<%--        <td  class="middle">PUB:</td><td class="middle2"><asp:Label ID="pub" CssClass="reporttext1" runat="server"></asp:Label></td>
--%>     </tr>
     
    </table>
         <table width="90%"><tr valign="top"><td valign="top" id="tblgrid" runat="server"></td></tr></table>

         <table><tr> <td><input id="hiddendateformat" type="hidden" runat="server" /></td></tr></table>
                  <table><tr> <td><input id="hiddendatefrom" type="hidden" runat="server" /></td></tr></table>
               <table><tr> <td><input id="hiddendateto" type="hidden" runat="server" /></td></tr></table>
               
                  <table>
               <tr>
                  <td><input id="hiddenascdesc" type="hidden" runat="server" /></td>
  <td> <input id="hiddencioid" type="hidden" runat="server"  /></td></tr>
  
  </table>
<%--<table>
 <tr>
     <td align="left">
     <asp:UpdatePanel ID="UpdatePanel12" runat="server"><ContentTemplate>
     <asp:DataGrid ID="DataGrid1" runat="server" CssClass="dtGrid" Width="770px" AutoGenerateColumns="False" OnItemDataBound="DataGrid1_ItemDataBound">
     <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
     <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3" >
     
     </HeaderStyle>
     <Columns>
     <asp:BoundColumn  HeaderText="S.No" >
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
			
			
			
			
			
			  <asp:BoundColumn DataField="Area" HeaderText="Area" SortExpression="Area">
			<ItemStyle HorizontalAlign="Right"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			 <asp:BoundColumn DataField="Hue" HeaderText="Color" SortExpression="Hue">
			<ItemStyle HorizontalAlign="Left"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			
			
			 <asp:BoundColumn DataField="BookDate" HeaderText="BookDate" SortExpression="BookDate">
			<ItemStyle HorizontalAlign="Left"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			 <asp:BoundColumn DataField="RoNo" HeaderText="RoNo." SortExpression="RoNo">
			<ItemStyle HorizontalAlign="Left"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			 <asp:BoundColumn DataField="RoStatus" HeaderText="RoStatus" SortExpression="RoStatus">
			<ItemStyle HorizontalAlign="Left"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
							
			 <asp:BoundColumn DataField="Adcat" HeaderText="Adcat" SortExpression="Adcat">
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
			
			
			 <asp:BoundColumn DataField="AgreedRate" HeaderText="AgreedRate" SortExpression="AgreedRate">
			<ItemStyle HorizontalAlign="Right"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			 <asp:BoundColumn DataField="Deviation(%)" HeaderText="%Dev" SortExpression="%Dev">
			<ItemStyle HorizontalAlign="Right"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			 <asp:BoundColumn DataField="Status" HeaderText="Status" SortExpression="Status">
			<ItemStyle HorizontalAlign="Left"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			<asp:BoundColumn DataField="booked_by" HeaderText="BookedBy" SortExpression="BookedBy">
			<ItemStyle HorizontalAlign="Left"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			 <asp:BoundColumn DataField="audit" HeaderText="AuditBy" SortExpression="AuditBy">
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
