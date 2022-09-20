<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DepotIncmaster.aspx.cs" Inherits="DepotIncmaster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<HEAD>
		<title>Display Ad. Booking & Sheduling Depot Inc master</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<script language="javascript" src="javascript/tree.js"></script>
		
		<script language="javascript" src="javascript/popupcalender.js"></script>
		
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="css/main.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="javascript/DepotIncMaster.js"></script>
		<script language="javascript">
		
		function notchar2()
{

if((event.keyCode>=48 && event.keyCode<=57)||
(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==190)||

(event.keyCode==9 || event.keyCode==32)||(event.keyCode==46))
{
return true;
}
else
{
return false;
}
}

function allamountbullet(ab)
		{
		//var fld =document.getElementById(ab).value;
		var fld=ab.value;
		if(fld!="")
			{
			//var expression= ^-{0,1}\d*\.{0,1}\d+$;
			if(fld.match(/^\d+(\.\d{2})?$/i))
			{
			return true;
			}
			else
			{
			alert("Input error")
			//document.getElementById(ab).focus();
			ab.focus();
			return false;
			}
			
			}
	return true;
		}
		
			</script>
	</HEAD>
	<body topmargin="0" leftmargin="5" 
		id="bdy">
		<form id="Form1" method="post" runat="server">
			<table id="OuterTable" width="1000" align="center" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colSpan="2"></td>
				</tr>
				<tr valign="top">
					<td valign="top"></td>
					<td vAlign="top">
						<table cellSpacing="0" cellPadding="0" border="0" id="RightTable" class="RightTable">
							<tr valign="top">
						<table class="RightTable" id="Table1" cellSpacing="0" cellPadding="0" border="0">
							<TR vAlign="top" align="left">
								<td>
									<table class="Popupbar" style="WIDTH: 755px; HEIGHT: 23px" height="23" cellSpacing="0"
										cellPadding="0" width="752" border="0">
										<tr>
											<td bgColor="#7daae3"></td>
										</tr>
									</table>
								</td>
							</TR>
							<tr>
								<td height="25"></td>
							</tr>
							<tr>
								<td>
									<table align="center">
										<TR>
											<TD style="WIDTH: 103px"><asp:label id="Label1" runat="server" CssClass="textfield">Slab From<font color="red">*</font></asp:label></TD>
											<TD><asp:textbox id="txtslabfrom" onkeypress="return notchar2();" runat="server" CssClass="btext1" MaxLength="8"></asp:textbox></TD>
											<td><asp:label id="Label4" runat="server" CssClass="textfield">Slab To<font color="red">*</font></asp:label></td>
											<TD><asp:textbox id="txtslabto" onkeypress="return notchar2();" runat="server" CssClass="btext1" MaxLength="8"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 103px"><asp:label id="Label2" runat="server" CssClass="textfield">Percentage<font color="red">
														*</font></asp:label></TD>
											<TD><asp:textbox id="txtpercentage" onkeypress="return notchar2();" runat="server" CssClass="btext1" MaxLength="10"></asp:textbox></TD>
											<TD><asp:label id="Label5" runat="server" CssClass="textfield">TDS Rate<font color="red"> *</font></asp:label></TD>
											<TD><asp:textbox id="txttdsrate" onkeypress="return notchar2();" runat="server" CssClass="btext1" MaxLength="10"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 103px"><asp:label id="Label3" runat="server" CssClass="textfield">Effective From<font color="red">*</font></asp:label></TD>
											<TD><asp:textbox id="txtvalidityfrom"  runat="server" CssClass="btext1" MaxLength="5"></asp:textbox>
												<SCRIPT language="javascript">
																	if (!document.layers) 
																	{
																		document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, Form1.txtvalidityfrom, \"mm/dd/yyyy\")' height=14 width=14 >")
																	}					
												</SCRIPT>
											</TD>
											<TD><asp:label id="Label6" runat="server" CssClass="textfield">Effective To<font color="red">
														*</font></asp:label></TD>
											<TD><asp:textbox id="txttilldate" runat="server" CssClass="btext1" MaxLength="20"></asp:textbox>
												<SCRIPT language="javascript">
																	if (!document.layers) 
																	{
																		document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, Form1.txttilldate, \"mm/dd/yyyy\")' height=14 width=14 >")
																	}					
												</SCRIPT>
											</TD>
										</TR>
										<tr>
											<td></td>
											<td></td>
											<td></td>
											<td align="right"><asp:button id="btnsubmit" runat="server" Text="Submit" CssClass="button1"></asp:button></td>
										</tr>
									</table>
								</td>
							</tr>
							<TR>
								<TD></TD>
							</TR>
							<TR>
								<TD align="center"><asp:datagrid id="DataGrid1" runat="server" width="506px" AutoGenerateColumns="False" CssClass="dtGrid">
										<SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
										<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="Incentive_Slab_From" HeaderText="Slab From">
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Incentive_Slab_To" HeaderText="Slab To">
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Incent_Rate" HeaderText="Percentage">
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Tds_Rate" HeaderText="TDS Rate">
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Eff_From_Date" HeaderText="Effective From">
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Eff_Till_Date" HeaderText="Effective Till">
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="Incentive_Code" ReadOnly="True" HeaderText="Code"></asp:BoundColumn>
										</Columns>
									</asp:datagrid>
									<asp:Button id="btnselect" runat="server" Text="Select" CssClass="button1"></asp:Button>
									<asp:Button id="btndelete" runat="server" Text="Delete" CssClass="button1" Enabled="False"></asp:Button></TD>
							</TR>
							<TR>
								<TD align="right"></TD>
							</TR>
						</table>
					</td>
					</tr>
					</table>
			<INPUT id="hiddencompcode" type="hidden" size="14" name="hiddencompcode" runat="server">
			<INPUT id="hiddenuserid" type="hidden" size="17" name="hiddenuserid" runat="server">
			<INPUT id="hiddenusername" type="hidden" size="1" name="hiddenusername" runat="server">
			<INPUT id="hiddendateformat" type="hidden" runat="server" onserverchange="hiddendateformat_ServerChange">
		</form>
	</body>
</HTML>

