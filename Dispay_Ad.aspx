<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dispay_Ad.aspx.cs" Inherits="Dispay_Ad" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<HEAD>
		<title>Display Ad. Booking & Sheduling AdSize Dispay_Ad</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="javascript/adsizedisplay.js"></script>
		<LINK href="css/main.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function notchar2()
{
if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9 || event.keyCode==32))
{
return true;
}
else
{
return false;
}
}

		
		
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 64px; POSITION: absolute; TOP: 40px" borderColor="#000000"
				cellSpacing="0" cellPadding="0" width="500" bgColor="#ffffff" border="1" align="center">
				<TR>
					<TD><TABLE id="Table4" style="WIDTH: 491px;" cellSpacing="1" cellPadding="1" width="491" align="center"
							bgColor="#7daae3" border="0">
							<TR>
								<TD class="btnlink">Display Advertizement Details</TD>
							</TR>
						</TABLE>
						<TABLE id="Table1" style="WIDTH: 456px; HEIGHT: 96px" cellSpacing="0" cellPadding="0" width="456"
							border="0" align="center">
							<TR>
								<TD colSpan="3"></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>
									<asp:label id="Label2" runat="server" CssClass="textfield">Description</asp:label></TD>
								<TD>
									<asp:label id="Label3" runat="server" CssClass="textfield">Height</asp:label></TD>
								<TD>
									<asp:label id="Label4" runat="server" CssClass="textfield">Width</asp:label></TD>
							</TR>
							<TR>
								<TD>
									<asp:label id="Label5" runat="server" CssClass="textfield">Minimum Size</asp:label></TD>
								<TD>
									<asp:textbox onkeypress="return notchar2();" id="btnminheight" runat="server" CssClass="btext1"></asp:textbox></TD>
								<TD>
									<asp:textbox onkeypress="return notchar2();" id="btnminwidth" runat="server" CssClass="btext1"></asp:textbox></TD>
							</TR>
							<TR>
								<TD width="20"></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 152px">
									<asp:label id="Label6" runat="server" CssClass="textfield">Maximum Size</asp:label></TD>
								<TD>
									<asp:textbox onkeypress="return notchar2();" id="btnmaxheight" runat="server" CssClass="btext1"></asp:textbox></TD>
								<TD>
									<asp:textbox onkeypress="return notchar2();" id="btnmaxwidth" runat="server" CssClass="btext1"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 152px"><INPUT id="hiddencompcode" type="hidden" runat="server" size="1"></TD>
								<TD><INPUT id="hiddenuserid" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" runat="server"><INPUT id="hiddensizecode" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" runat="server"></TD>
								<TD align="right">
									<asp:button id="btnsubmit" runat="server" CssClass="button1" Text="Submit"></asp:button>&nbsp;&nbsp;</TD>
							</TR>
						</TABLE>
						<TABLE id="Table2" style="WIDTH: 456px; HEIGHT: 152px" cellSpacing="1" cellPadding="1"
							width="456" border="0" align="center">
							<TR>
								<TD>
									<asp:datagrid id="DataGrid1" runat="server" CssClass="dtGrid" Width="448px" AutoGenerateColumns="False">
										<SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
										<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="min_height" HeaderText="Minimum Height">
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="max_height" HeaderText="Maximum Height">
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="min_width" HeaderText="Minimum width">
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="max_width" HeaderText="Maximum Width">
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="display_code" ReadOnly="True" HeaderText="Size Code"></asp:BoundColumn>
										</Columns>
									</asp:datagrid></TD>
							</TR>
							<TR>
								<TD align="right">
									<asp:button id="btnselect" runat="server" CssClass="button1" Text="Select"></asp:button>
									<asp:button id="btndelete" runat="server" CssClass="button1" Text="Delete" Enabled="False"></asp:button>&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
