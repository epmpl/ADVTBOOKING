<%@ Page Language="C#" AutoEventWireup="true" CodeFile="insertion_wise_supp.aspx.cs" Inherits="insertion_wise_supp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
        <title>Insertion Wise(supp)</title>
<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<link href="css/booking.css" type="text/css" rel="stylesheet"/>
		<link href="css/report.css" type="text/css" rel="stylesheet"/>
				<script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
				<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
				  <script language="javascript" src="javascript/insertion_wise_supp.js" type="text/javascript"></script>
				  
				  				  <script language="javascript">


</script>  
				  <style type="text/css">
    .hiddencol
    {
        display:none;
    }
   
</style>
</head>
<body>
       <form id="form1" runat="server" >
     
  
    		<table width="1005" border="0" cellspacing="0" cellpadding="0" align="center" style="WIDTH: 1005px; HEIGHT: 358px">
<tr>
<td width="100%" bordercolor="#1"><img src="images/img_02A.jpg" width="1004" border="0" />
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>




</td>
</tr>
<tr>
<td width="100%" bordercolor="#1"><img src="images/top.jpg" width="1004" border="0" /></td>
</tr>
<tr>
<td width="100%" bordercolor="#1"><img src="images/top.jpg" width="1004" border="0" /></td>
</tr>
<tr>
<td style="height: 505px"><table width="985" border="0" cellspacing="0" cellpadding="0" style="WIDTH: 985px; HEIGHT: 486px">
<tr>

<td width="200" style="WIDTH: 200px"><img src="images/leftbar.jpg" style="WIDTH: 193px; HEIGHT: 483px" height="483" width="193" /></td>

<td valign="top" style="width: 77%">


<table cellpadding="0" cellspacing="0" width="100%" style ="top :100px; vertical-align:top"><tr><td align="center">
<div id="divgrid1"  runat="server" style="display:block;OVERFLOW: auto; vertical-align:top; WIDTH: 800px;height:500px;" >
<table id="Table3" align="center">
<tr>

<td align="center">
<asp:UpdatePanel ID="UpdatePanel12" runat="server"><ContentTemplate>
<asp:DataGrid ID="DataGrid1" runat="server" CssClass="dtGrid" Width="770px"  AutoGenerateColumns="False"  OnItemDataBound="DataGrid1_ItemDataBound"  >
<SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
<Columns>
<%--<asp:TemplateColumn HeaderText="Audit"></asp:TemplateColumn>--%>
<asp:BoundColumn DataField="cio_booking_id" HeaderText="Booking Id" SortExpression="Edition_Alias">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
<HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
</asp:BoundColumn>



<asp:BoundColumn  HeaderText="Invoice_No" DataField="BILL_NO"  >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
<HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
</asp:BoundColumn>



<asp:BoundColumn DataField="Agency" HeaderText="Agency" SortExpression="Date_Edition">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
<HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
</asp:BoundColumn>
<asp:BoundColumn DataField="no_of_insertion" HeaderText="Insertions" SortExpression="Date_Edition">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
<HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
</asp:BoundColumn>

<asp:BoundColumn DataField="edition" HeaderText="Edition" SortExpression="Date_Edition">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
<HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
</asp:BoundColumn>
<asp:BoundColumn SortExpression="Client" DataField="client" HeaderText="Client" ReadOnly="True" Visible="true">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
<HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
</asp:BoundColumn>

<asp:BoundColumn SortExpression="Gross Amount" DataField="gross_rate" HeaderText="GrossAmount" ReadOnly="True" Visible="true">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
<HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
</asp:BoundColumn>

<asp:BoundColumn SortExpression="Commission" DataField="Commission" HeaderText="Commission" ReadOnly="True" Visible="true">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
<HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
</asp:BoundColumn>

<asp:BoundColumn SortExpression="NetAmount" HeaderText="Net_Amount" ReadOnly="True" Visible="FALSE">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
<HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
</asp:BoundColumn>



<asp:BoundColumn SortExpression="Bill_remarks"  ReadOnly="True" DataField="Bill_remarks" HeaderText="Bill.Ins." Visible="true">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
<HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
</asp:BoundColumn>


<asp:BoundColumn SortExpression="Status" DataField="status" ReadOnly="True" HeaderText="Status" Visible="true">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
<HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
</asp:BoundColumn>


<asp:BoundColumn SortExpression="Totalinsertion" DataField="total" ReadOnly="True" HeaderText="Status" Visible="false">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
<HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
</asp:BoundColumn>

<asp:BoundColumn  ReadOnly="True" HeaderText="PrintNo" Visible="true"  DataField="PrintCount">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
<HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
</asp:BoundColumn>

<asp:BoundColumn  ReadOnly="True" HeaderText="Publish Date" Visible="true"  DataField="pub_date">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
<HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
</asp:BoundColumn> 

    <asp:TemplateColumn HeaderText="Spl disc">
	    <HeaderStyle Width="50px"></HeaderStyle>
	    <ItemStyle HorizontalAlign="Center"></ItemStyle>
	    <ItemTemplate>
		    <asp:CheckBox id="CheckBox2" CssClass="textfield" runat="server"></asp:CheckBox>
	    </ItemTemplate>
    </asp:TemplateColumn>
   
    <asp:TemplateColumn HeaderText="Trade disc">
	    <HeaderStyle Width="50px"></HeaderStyle>
	    <ItemStyle HorizontalAlign="Center"></ItemStyle>
	    <ItemTemplate>
		    <asp:CheckBox id="CheckBox3" CssClass="textfield" runat="server"></asp:CheckBox>
	    </ItemTemplate>
    </asp:TemplateColumn>
    
 <asp:TemplateColumn  >
<HeaderTemplate>
<input id="Checkbox4"  type="checkbox" name="Checkbox4" runat="server" onclick="SelectHi('DataGrid1',this,'Checkbox4');" />                    </HeaderTemplate>


		<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"   > 
		
		</HeaderStyle>
		<ItemStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle" ></ItemStyle>
		<ItemTemplate >
			<asp:CheckBox ID="CheckBox1" CssClass="TextField1" Runat="server"   />
		</ItemTemplate>
	</asp:TemplateColumn>
	
	
	
	
	
	
	










</Columns>
</asp:DataGrid>
</ContentTemplate></asp:UpdatePanel>
</td>
</tr>
</table>
</div>
</td>

</tr></table>


<table style ="width:880px;">

<tr align ="right">
<td>
<table><tr>

<td class="style1" style="font-size:11px;font-family :Verdana;" align="left"><asp:Label  ID="Label6" runat ="server"><b>To Not to show Special discount or the Trade discount on bill,please select the checkbox for respective head for each each bill. By default they are shown on bill.</b></asp:Label></td>






<td align="center">  
<td align="right">
<asp:Button ID="btnprv"   ForeColor="White" runat="server" BackColor="#7DAAE3" Text ="BillPreview" CssClass="buttonnew"/>
</td>
<td align="right">


<asp:Button ID="btngenrate" ForeColor="White"  runat="server" Text ="BillGenerate"  CssClass="buttonnew" BackColor="#7DAAE3" Width="93px"  />
</td>

</td></tr>


<tr>


<TD class="style1"></TD>
<TD></TD>
<TD></TD>
<td align="center" colspan="2">
<td align="right">
<asp:Button ID="btnprint"  ForeColor="White" runat="server" Text ="BillPrint" CssClass="buttonnew" BackColor="#7DAAE3" />
</td>
</td>

<td  >

<asp:Button ID="btn_mail"  ForeColor="White" runat="server" Text ="BillMail" CssClass="buttonnew" BackColor="#7DAAE3" />
</td>
</tr>
</table>






</tr>

</table >




<%--garima--%>











<table >












<input id="hiddendateformat" type="hidden" runat="server" />
<input id="hiddendateformat1" type="hidden" runat="server" />





<input id="hiddenascdesc" type="hidden" runat="server" />
<input id="hiddencioid" type="hidden" runat="server" />
<td><input id="hiddenolddate" type="hidden" name="hiddenolddate" runat="server" /></td>

<input id="hiddencompcode" type="hidden" size="1" name="hiddencompcode" runat="server" />
<input id="hidden1" type="hidden" size="1" name="hiddencompcode" runat="server" />
<input id="hiddenradio" type="hidden" size="1" name="hiddencompcode" runat="server" />
<input id="hiddenrowcount" type="hidden" size="1"  runat="server" />

<asp:UpdatePanel ID="updatehidden" runat="server"><ContentTemplate><input id="hiddenbooking" type="hidden"   runat="server" />
<input id="hiddeninsertion" type="hidden"   runat="server" />

<input id="hiddenfromdate" type="hidden"   runat="server" />
<input id="hiddendateto" type="hidden"   runat="server" />
<input id="hiddenclient" type="hidden"   runat="server" />
<input id="hiddencheck" type="hidden"   runat="server" />
<input id="hiddenbillstatus" type="hidden"   runat="server" />
<input id="hiddendisplaybill" type="hidden"  runat="server" />
<input id="hiddenclsbill" type="hidden"   runat="server" />
<input id="hiddenclsbillnew" type="hidden"   runat="server" />
<input id="hiddenadtype" type="hidden"   runat="server" />
<input id="hiddenfdate" type="hidden"   runat="server" />
<input id="hiddentdate" type="hidden"   runat="server" />
<input id="hiddenbillcycle" type="hidden"   runat="server" />



</ContentTemplate></asp:UpdatePanel>
</td>
</tr>
</table>


    
</td>
</tr>
            </table>


    
    </form>
</body>
</html>
