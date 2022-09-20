<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bookingdetailview.aspx.cs" Inherits="Reports_bookingdetailview" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <link href="css/report.css" rel="stylesheet" type="text/css" />
       <%--<script type="text/javascript" language="javascript" src="javascript/bookview.js">
       function maximize()
        {
        window.moveTo(0,0)            
        window.resizeTo(screen.availWidth, screen.availHeight)
         }
        maximize();
       </script>    --%>  
     
        <script type="text/javascript" language="javascript" src="javascript/prototype.js">
  </script>

    <title>Booking Detail Report</title>
    <script type="text/javascript" language="javascript" src="javascript/prototype.js"></script>
<script language="javascript" type="text/javascript">
 
// <!CDATA[

    function table1_onclick() {

    }

// ]]>
</script>
</head>
<body  >
<%--onload="document.getElementById('btnprint').focus();"--%>
<%--onkeydown ="javascript:return windowreport7();"--%>
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
      <td align="left" >
      <asp:Button ID="btnprint" runat="server"  OnClick="btnprint_Click" Text="Print" />
      </td>

          <td align="center" style="height: 28px;" colspan="5"><asp:Label ID="cmpnyname" CssClass ="headingc" runat ="server"></asp:Label></td>
          </tr>
          <tr style="width:100%">


<td align="left" style=" width:300px;">
<asp:Label ID="heading" CssClass ="headingp" runat ="server"></asp:Label></td>

 <td   align="right"  style=" padding-left:330px" class="upper2">DATE FROM:</td><td class="middle2">
 <asp:Label ID="lblfrom" CssClass="reporttext2" runat="server"></asp:Label></td>
 <td align="right" class="upper2"> TO DATE: </td><td class ="middle2">
         <asp:Label ID="lblto" CssClass="reporttext2" runat="server"></asp:Label></td>

</tr>


</table>
    <div>
    <table style="width:1000px">
        <tr><td id="subregrepDiv" runat ="server" ></td>
       </tr>
       </table> 
    </div>
     <table id="table1" cellpadding="0" cellspacing="0" align="center" border="0"  >
    <tr><%--<td  class="upper2">AGENCY:</td><td class="middle2"><asp:Label ID="lbAgencyna" CssClass="reporttext2" runat="server"></asp:Label></td>--%>
        
        <td  class="upper2" >PUBLICATION:</td><td><asp:Label ID="lblpub" CssClass="reporttext2" runat="server"></asp:Label></td>
        <td  class="upper2" >PUB CENT:</td><td><asp:Label ID="pcenter" CssClass="reporttext2" runat="server"></asp:Label></td>
          <td  class="upper2">BRANCH:</td><td class="middle2" ><asp:Label ID="lblagtype" CssClass="reporttext2" runat="server" ></asp:Label></td>
 
        <td class="upper2">EDITION:</td><td class="middle2"><asp:Label ID="lbedition" CssClass="reporttext2" runat="server"></asp:Label></td>

    </tr>
        <tr style="border-bottom:dashed">
        <%-- <td  class="upper2" >ADCATGORY:</td><td "middle2"> <asp:Label ID="Adcat" CssClass="reporttext2" runat="server"></asp:Label></td>--%>
        
         <%--<td  class="upper2"></td><td class="middle2"> <asp:Label ID="lbclient" CssClass="reporttext2" runat="server" Visible="false"></asp:Label></td>--%>
         <td class="upper2" >AGENCY TYPE:</td><td class="middle2"><asp:Label ID="lbladtype" CssClass="reporttext2" runat="server" ></asp:Label></td>
         
        <%--<td  class="upper" >PAGE:</td><td class="middle2"> <asp:Label ID="lblpage" CssClass="reporttext2" runat="server"></asp:Label></td>--%>

<%--        <td  class="middle">PUB:</td><td class="middle2"><asp:Label ID="pub" CssClass="reporttext1" runat="server"></asp:Label></td>
--%>
<td  class="upper2"></td><td class="middle2"> <asp:Label ID="Label1" CssClass="reporttext2" runat="server" Visible="false"></asp:Label></td>
<td  class="upper2"></td><td class="middle2"> <asp:Label ID="lbclient" CssClass="reporttext2" runat="server" Visible="false"></asp:Label></td>
      <td  class="upper2" >RUN DATE:</td><td class="middle2" > <asp:Label ID="lbldate" CssClass="reporttext2" runat="server"></asp:Label></td>     
     </tr>
    <%-- start from here--%>
     <tr><%--<td  class="upper2">AGENCY:</td><td class="middle2"><asp:Label ID="lbAgencyna" CssClass="reporttext2" runat="server"></asp:Label></td>--%>
        
        <td  class="upper2" >ADTYPE:</td><td><asp:Label ID="lbltype" CssClass="reporttext2" runat="server"></asp:Label></td>
        <td  class="upper2" >ADCATEGORY:</td><td><asp:Label ID="lblcat" CssClass="reporttext2" runat="server"></asp:Label></td>
          <td  class="upper2">AD SUB CATEGORY:</td><td class="middle2" ><asp:Label ID="lblsubcat" CssClass="reporttext2" runat="server" ></asp:Label></td>
 
        <td class="upper2"></td><td class="middle2"><asp:Label ID="L56" CssClass="reporttext2" runat="server"></asp:Label></td>

    </tr>
     
    </table>
         <table width="100%"><tr valign="top"><td valign="top" id="tblgrid" runat="server"></td></tr></table>

         <table><tr> <td><input id="hiddendateformat" type="hidden" runat="server" /></td></tr></table>
                  <table><tr> <td><input id="hiddendatefrom" type="hidden" runat="server" /></td></tr></table>
               <table><tr> <td><input id="hiddendateto" type="hidden" runat="server" /></td></tr></table>
               
                  <table>
               <tr>
                  <td><input id="hiddenascdesc" type="hidden" runat="server" /></td>
  <td> <input id="hiddencioid" type="hidden" runat="server"  /></td></tr>
  <input id="hidden1" type="hidden" runat="server" />
   <input id="hidden2" type="hidden" runat="server" />
   <td><input id="hiddenolddate" type="hidden" name="hiddenolddate" runat="server" /></td>
						<td><input id="hidden3" type="hidden" runat="server" /></td>
                         <td><input id="hiddendateformat1" type="hidden" runat="server" /></td>
		 <input id="hiddencompcode" type="hidden" name="hiddencompcode" runat="server" />
		 <input id="hiddendppub1" type="hidden" name="hiddendppub1" runat="server" />
		 <input id="hiddenuseid" type="hidden" name="hiddenuseid" runat="server" />
    <input id="hiddenadcat" type="hidden" name="hiddenadcat" runat="server" />
     <input id="hiddenadsubcat" type="hidden" name="hiddenadsubcat" runat="server" />
      <input id="hiddenadcatname" type="hidden" name="hiddenadcatname" runat="server" />
     <input id="hiddenadsubcatname" type="hidden" name="hiddenadsubcatname" runat="server" />
      <input id="hiddenedition" type="hidden" name="hiddenedition" runat="server" />
      <input id="hiddeneditionname" type="hidden" name="hiddeneditionname" runat="server" />
      <input id="hdnagency1" name="hdnagency1" runat="server" type="hidden" />
      <input id="hdnagencytxt" name="hdnagencytxt" runat="server" type="hidden" />

<input id="hdnclient1" name="hdnagency1" runat="server" type="hidden" />
						<input id="hdnclienttxt" name="hdnagencytxt" runat="server" type="hidden" />
						<input id="hdncompcode" name="hdnagencytxt" runat="server" type="hidden" />
  
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
