<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pageprview1.aspx.cs" Inherits="pageprview1" %>

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


    <title>Page Premium Report</title>
     <script type="text/javascript" language="javascript" src="javascript/prototype.js"></script>

<script language="javascript" type="text/javascript">

// <!CDATA[

function table1_onclick() {

}

// ]]>
</script>
</head>
<body onload="document.getElementById('btnprint').focus();"onkeydown ="javascript:return windowreport5();">
    <form id="form1" runat="server">

<%--<table style="width: 794px" >
    <tr>
          <td align="center" style="height: 28px" colspan="3"><asp:Label ID="cmpnyname" CssClass ="headingc" runat ="server"></asp:Label></td>
          </tr>
          <tr style="width:100px">


<td align="left" style= "height: 28px;"  >
<asp:Button ID="btnprint" runat="server"  OnClick="btnprint_Click" Text="Print" />
</td>
<td align="left" style="height: 28px;padding-left:220px" colspan="2">
<asp:Label ID="heading" CssClass ="headingp" runat ="server"></asp:Label></td>

</tr>
<tr><td style="width: 69px"></td></tr>

</table>--%>

     <table style="width:100%" >
  
      <tr><td></td>
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
     <table id="table1" cellpadding="0" cellspacing="0" align="center" border="0" onclick="return table1_onclick()" >
 <tr>
        <td class="upper2" >PAGE PREMIUM:</td><td class="middle2"><asp:Label ID="lblpagepr" CssClass="reporttext2" runat="server" ></asp:Label></td>
       <td class="upper2" >POSITION:</td><td class="middle2"><asp:Label ID="lblposition" CssClass="reporttext2" runat="server" ></asp:Label></td>
        <td  class="upper2" >PUBLICATION:</td><td><asp:Label ID="lblpub" CssClass="reporttext2" runat="server"></asp:Label></td>
        <td  class="upper2" >PUB CENTER:</td><td><asp:Label ID="pcenter" CssClass="reporttext2" runat="server" Width="98px" Height="15px"></asp:Label></td>
        <%--<td  class="upper2">AGENCY:</td><td class="middle2"><asp:Label ID="lbAgencyna" CssClass="reporttext2" runat="server"></asp:Label></td>--%>
        <td class="upper2">EDITION:</td><td class="middle2"><asp:Label ID="lbedition" CssClass="reporttext2" runat="server"></asp:Label></td>

    </tr>
        <tr style="border-bottom:dashed">
        <%-- <td  class="upper2" >ADCATGORY:</td><td "middle2"> <asp:Label ID="Adcat" CssClass="reporttext2" runat="server"></asp:Label></td>--%>
         <td  class="upper2">DATE FROM:</td><td class="middle2"> <asp:Label ID="lblfrom" CssClass="reporttext2" runat="server"></asp:Label></td>
         <td  class="upper2">DATE TO:</td><td class="middle2"> <asp:Label ID="lblto" CssClass="reporttext2" runat="server"></asp:Label></td>
         <td  class="upper2">RUN DATE:</td><td class="middle2"> <asp:Label ID="lbldate" CssClass="reporttext2" runat="server"></asp:Label></td>
         <td  class="upper2">ADTYPE:</td><td class="middle2" ><asp:Label ID="lbladtype" CssClass="reporttext2" runat="server" ></asp:Label></td>
         <td  class="upper2">AGENCY TYPE:</td><td class="middle2" ><asp:Label ID="lblagtype" CssClass="reporttext2" runat="server" ></asp:Label></td>
 
   
         <%--<td  class="upper2" >CLIENT:</td><td class="middle2" > <asp:Label ID="lbclient" CssClass="reporttext2" runat="server"></asp:Label></td>--%>
          <%--<td  class="upper" >PAGE:</td><td class="middle2"> <asp:Label ID="lblpage" CssClass="reporttext2" runat="server"></asp:Label></td>--%>

<%--        <td  class="middle">PUB:</td><td class="middle2"><asp:Label ID="pub" CssClass="reporttext1" runat="server"></asp:Label></td>
--%>     </tr>

     
    </table>
         <table width="100%"><tr valign="top"><td id="tblgrid" runat="server" valign="top"></td></tr></table>


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
    
     <asp:DataGrid ID="DataGrid1" runat="server" CssClass="dtGrid" Width="770px" AutoGenerateColumns="False"   OnItemDataBound="DataGrid1_ItemDataBound" >
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
          
           <asp:BoundColumn DataField="Ins.date" HeaderText="Publish date" SortExpression="Ins.date">
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
			
			<asp:BoundColumn DataField="Page" HeaderText="Page Position" SortExpression="Page">
			<ItemStyle HorizontalAlign="Left"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			
			<asp:BoundColumn DataField="PagePremiumcd" HeaderText="Page Premium" SortExpression="PagePremiumcd">
			<ItemStyle HorizontalAlign="Left"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
		
			
			<asp:BoundColumn DataField="PositionPremium" HeaderText="Position Premium" SortExpression="PositionPremium">
			<ItemStyle HorizontalAlign="Left"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
				<asp:BoundColumn DataField="BulletPremium" HeaderText="Eye Catcher Premium" SortExpression="BulletPremium">
			<ItemStyle HorizontalAlign="Left"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			<asp:BoundColumn DataField="RoNo." HeaderText="RoNo." SortExpression="RoNo.">
			<ItemStyle HorizontalAlign="Left"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>

			
			 <asp:BoundColumn DataField="RoStatus" HeaderText="RoStatus" SortExpression="RoStatus">
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
			
			
			
			 <asp:BoundColumn DataField="AgreedRate" HeaderText="Rate" SortExpression="AgreedRate">
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
         <table><tr> <td><input id="hiddendateformat" type="hidden" runat="server" /></td></tr></table>
                  <table><tr> <td><input id="hiddendatefrom" type="hidden" runat="server" /></td></tr></table>
               <table><tr> <td><input id="hiddendateto" type="hidden" runat="server" /></td></tr></table>
 
<input id="hiddenascdesc" type="hidden" runat="server" />
   <input id="hiddencioid" type="hidden" runat="server" />
    </form>
</body>
</html>
