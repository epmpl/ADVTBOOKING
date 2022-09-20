<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Modbukclient.aspx.cs" Inherits="Modbukclient" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Client</title>

<LINK href="css/main.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="javascript/permission.js"></script>
		<script language="javascript" src="javascript/Validations.js"></script>
		<script language="javascript" src="javascript/datevalidation.js"></script>
		<script language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/Modbukclient.js"></script>
		
<style type="text/css">
.hiddencol
{
display:none;
}

    .style1
    {
        width: 549px;
    }

</style>

</head>
<body onload="javascript:return loadfirst();">
<form id="form1" runat="server" >


<table width="1005" border="0" cellspacing="0" cellpadding="0" align="center" style="WIDTH: 1005px; HEIGHT: 358px">
<tr>
<td width="100%" bordercolor="#1"><img src="images/img_02A.jpg" width="1004" border="0" />
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
</td>
</tr>

<tr>
<td width="100%" bordercolor="#1" style="height: 5px"><img src="images/top.jpg" width="1004" border="0" /></td>
</tr>
<tr>
<td style="height: 505px">
<table width="985" border="0" cellspacing="0" cellpadding="0" style="WIDTH: 985px; HEIGHT: 400px">
<tr>

<%--<td width="200" style="WIDTH: 200px"><img src="images/leftbar.jpg" style="WIDTH: 193px; HEIGHT: 483px" height="483" width="193" /></td>--%>

<td valign="top" style="width: 98%">


<table cellpadding="0" cellspacing="0" width="100%" style ="top :100px; vertical-align:top"><tr><td align="center" >
<%--<div id="divgrid1"  runat="server" style="display:block;OVERFLOW: auto; vertical-align:top; height:400px;" >--%>
<table id="Table3" align="center" width="100%">
<tr>
<td align="center">&nbsp;
    </td></tr>
    <tr>
<td align="center">
<div id="divgrid1"  runat="server" style="display:block;OVERFLOW: auto; vertical-align:top; height:300px;" >
<asp:UpdatePanel ID="UpdatePanel12" runat="server"><ContentTemplate>
<asp:DataGrid ID="DataGrid1" runat="server" CssClass="dtGrid"  AutoGenerateColumns="False"  OnItemDataBound="DataGrid1_ItemDataBound"  >
<SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
<Columns>
<asp:BoundColumn  HeaderText="S.No" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
<HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
 Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
</asp:BoundColumn>
			
<asp:BoundColumn DataField="cio_booking_id" HeaderText="Booking Id" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
<HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
</asp:BoundColumn>


<asp:BoundColumn DataField="Agency_Name" HeaderText="Agency" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
<HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
</asp:BoundColumn>


<asp:BoundColumn SortExpression="Client" DataField="Client_code" HeaderText="Client" ReadOnly="True" Visible="true">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
<HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
</asp:BoundColumn>


<asp:BoundColumn DataField="Package_Name" HeaderText="Package" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
<HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
Font-Underline="False" ForeColor="White" HorizontalAlign="Center"  />
</asp:BoundColumn>

<asp:BoundColumn  ReadOnly="True" HeaderText="Publish Date" Visible="false" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
<HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
</asp:BoundColumn> 

    
 <asp:TemplateColumn  >
<HeaderTemplate>
<input id="Checkbox4"  type="checkbox" name="Checkbox4" runat="server" onclick="javascript:return SelectHi('DataGrid1',this,'Checkbox4');" /></HeaderTemplate>


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
</div>
</td>
</tr>
</table>
<%--</div>--%>
</td>

</tr></table>


<table  style="width:98%;">

<tr align ="right">
<td>
<table><tr>
<td align="right" colspan="3">
<asp:Button ID="btnupdate" style="width:70px;height:30px;font-size:11px;font-family:arial; margin-right: 0px;" ForeColor="White" runat="server" BackColor="#7DAAE3" Text ="Update" />
</td>
<td align="right" >
<asp:Button ID="btnclose"  
        style="width:70px;height:30px;font-size:11px;font-family:arial; margin-right: 0px;" 
        ForeColor="White" runat="server" BackColor="#7DAAE3" Text ="Close" />
</td>
</tr>

</table>






</tr>

</table >




<%--garima--%>











</table>












<input id="hiddendateformat" type="hidden" runat="server" />
<input id="hiddendateformat1" type="hidden" runat="server" />





<input id="hiddenascdesc" type="hidden" runat="server" />
<input id="hiddencioid" type="hidden" runat="server" />
<td><input id="hiddenolddate" type="hidden" name="hiddenolddate" runat="server" /></td>


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
<input id="hdnagncycod" type="hidden"   runat="server" />
<input id="hiddenbillformat" type="hidden"   runat="server" />
<input id="adtypehdn" type="hidden"   runat="server" />


<input id="hiddencompcode" type="hidden"   runat="server" />
<input id="hiddenuserid" type="hidden"   runat="server" />
<input id="uomhdn" type="hidden"   runat="server" />



</ContentTemplate></asp:UpdatePanel>
</td>
</tr>
</table>


</td>
</tr>
</table>
<div id="imgprogress" style="display:none" runat="server"><img src="Images/Progress1.gif" />  </div>
</form>
</body>
</html>
