<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Revenue_master.aspx.cs" Inherits="Revenue_master" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
	<HEAD>
		<title>Display Ad. Booking & Sheduling Revenue Master</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<script language="javascript" src="javascript/revenuemaster.js"></script>
		<script language="javascript" src="javascript/popupcalender.js"></script>
		<script language="javascript" src="javascript/tree.js"></script>
		<script language="javascript" src="javascript/TreeLibrary.js"></script>
		<script language="javascript" src="javascript/datevalidation.js"></script>
		<script language="javascript" src="javascript/permission.js"></script>
		<script language="javascript" src="javascript/Validations.js"></script>
		<LINK href="css/main.css" type="text/css" rel="stylesheet">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">
function openrevenue()
{

window.open('Revenue_type.aspx');	
return false;



} 
function uppercase(a)
		{
		
		document.getElementById(a).value=document.getElementById(a).value.toUpperCase();
		return ;
		
		}
		
		function notchar0()
{

if((event.keyCode>=48 && event.keyCode<=57)||
(event.keyCode==127)||(event.keyCode==37)||
(event.keyCode>=97 && event.keyCode<=122)||
(event.keyCode>=65 && event.keyCode<=90)||
(event.keyCode==9 || event.keyCode==32))
{
return true;
}
else
{
return false;
}
}
function novalue()
{

if((event.keyCode>=0 && event.keyCode<=200))
{
return false;
}
else
{
return false;
}
}
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

		</script>
	</HEAD>
	<body leftmargin="0" 
		id="bdy">
		<form id="Form1" method="post" runat="server">
			<table id="OuterTable" cellSpacing="0" cellPadding="0" width="1000" align="center" border="0">
				<tr vAlign="top">
					<td colSpan="2"></td>
				</tr>
				<tr vAlign="top">
					<td vAlign="top"></td>
					<td vAlign="top">
						<table  class="RightTable" id="RightTable" cellSpacing="0" cellPadding="0" border="0"  align="center">
							<tr vAlign="top">
								<TD><asp:button id="btnNew" runat="server" CssClass="topbutton" Text="New" Width="63px" BorderStyle="Outset"
										BorderColor="DarkGray" Font-Bold="True" Height="24px" Font-Size="XX-Small" BackColor="Control" onclick="btnNew_Click"></asp:button><asp:button id="btnSave" runat="server" Text="Save" Width="63px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Bold="True" Height="24px" Font-Size="XX-Small" BackColor="Control"></asp:button><asp:button id="btnModify" runat="server" Text="Modify" Width="63px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Bold="True" Height="24px" Font-Size="XX-Small" BackColor="Control"></asp:button><asp:button id="btnQuery" runat="server" Text="Query" Width="63px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Bold="True" Height="24px" Font-Size="XX-Small" BackColor="Control"></asp:button><asp:button id="btnExecute" runat="server" Text="Execute" Width="63px" BorderStyle="Outset"
										BorderColor="DarkGray" Font-Bold="True" Height="24px" Font-Size="XX-Small" BackColor="Control"></asp:button><asp:button id="btnCancel" runat="server" Text="Cancel" Width="63px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Bold="True" Height="24px" Font-Size="XX-Small" BackColor="Control"></asp:button><asp:button id="btnfirst" runat="server" Text="First" Width="62px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Bold="True" Height="24px" Font-Size="XX-Small" BackColor="Control"></asp:button><asp:button id="btnprevious" runat="server" Text="Previous" Width="63px" BorderStyle="Outset"
										BorderColor="DarkGray" Font-Bold="True" Height="24px" Font-Size="XX-Small" BackColor="Control"></asp:button><asp:button id="btnnext" runat="server" Text="Next" Width="63px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Bold="True" Height="24px" Font-Size="XX-Small" BackColor="Control"></asp:button><asp:button id="btnlast" runat="server" Text="Last" Width="63px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Bold="True" Height="24px" Font-Size="XX-Small" BackColor="Control"></asp:button><asp:button id="btnDelete" runat="server" Text="Delete" Width="63px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Bold="True" Height="24px" Font-Size="XX-Small" BackColor="Control"></asp:button><asp:button id="btnExit" runat="server" Text="Exit" Width="63px" BorderStyle="Outset" BorderColor="DarkGray"
										Font-Bold="True" Height="24px" Font-Size="XX-Small" BackColor="Control"></asp:button></TD>
							</tr>
							<TR align="left" valign="top">
								<td>
									<table class="Popupbar" width="752" height="23" cellSpacing="0" cellPadding="0" border="0"
										style="WIDTH: 755px; HEIGHT: 23px">
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
									<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="300" border="0" align="left">
										<TR>
											<TD>
												<div style="OVERFLOW: auto; WIDTH: 245px; HEIGHT: 160px"><asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" CssClass="dtGrid" Width="136px"
														Height="90px">
														<SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
														<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
														<Columns>
															<asp:BoundColumn DataField="edition_alias" HeaderText="Edition"></asp:BoundColumn>
															<asp:TemplateColumn></asp:TemplateColumn>
															<asp:BoundColumn Visible="False" ReadOnly="True"></asp:BoundColumn>
														</Columns>
													</asp:datagrid></div>
											</TD>
										</TR>
										<tr>
											<td><asp:button id="btnsubmit" runat="server" CssClass="button1" Text="Submit"></asp:button></td>
										</tr>
									</TABLE>
								</td>
							</tr>
							<TR>
								<TD></TD>
							</TR>
							<TR>
								<TD></TD>
							</TR>
							<tr>
								<td>
									<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="840" border="0" align="center">
										<TR>
											<TD><asp:label id="Label1" runat="server" CssClass="textfield">Share Code<font color="red">*</font></asp:label></TD>
											<TD style="WIDTH: 248px"><asp:textbox onkeypress="return notchar0();" id="txtsharecode" runat="server" CssClass="btext1"
													MaxLength="8" Enabled="False"></asp:textbox></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 14px"><asp:label id="Label2" runat="server" CssClass="textfield">Share Description<font color="red">*</font></asp:label></TD>
											<TD style="HEIGHT: 14px" colSpan="3"><asp:textbox onkeypress="return novalue();" id="txtsharedescription" runat="server" CssClass="btext"
													MaxLength="100" Enabled="False"></asp:textbox></TD>
											<TD style="HEIGHT: 14px"></TD>
											<TD style="HEIGHT: 14px"></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 13px"><asp:label id="Label3" runat="server" CssClass="textfield">Valid From<font color="red">*</font></asp:label></TD>
											<TD style="WIDTH: 248px; HEIGHT: 13px"><asp:textbox id="txtvalidaetdate" runat="server" CssClass="btext1" Enabled="False" MaxLength="8"></asp:textbox>
												<SCRIPT language="javascript">
													if (!document.layers) 
														{
															document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, Form1.txtvalidaetdate, \"mm/dd/yyyy\")' height=14 width=14 >")
														}					
																					
												</SCRIPT>
											</TD>
											<TD style="HEIGHT: 13px"><asp:label id="Label4" runat="server" CssClass="textfield">Valid Till<font color="red">*</font></asp:label></TD>
											<TD style="HEIGHT: 13px"><asp:textbox id="txtvalidatetill" runat="server" CssClass="btext1" Enabled="False" MaxLength="8"></asp:textbox>
												<SCRIPT language="javascript">
													if (!document.layers) 
													{
														document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, Form1.txtvalidatetill, \"mm/dd/yyyy\")' height=14 width=14 >")
													}					
					                          
																					
												</SCRIPT>
											</TD>
										</TR>
										<TR>
											<TD><asp:label id="Label5" runat="server" CssClass="textfield">Remarks</asp:label></TD>
											<TD colSpan="3"><asp:textbox onkeypress="return ClientSpecialchar()" id="txtremarks" runat="server" CssClass="btext"
													MaxLength="200" Enabled="False"></asp:textbox></TD>
											<TD></TD>
											<TD></TD>
										</TR>
									</TABLE>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<INPUT id="hiddencompcode" type="hidden" name="hiddencompcode" runat="server"> <INPUT id="hiddenuserid" type="hidden" name="hiddenuserid" runat="server">
			<INPUT id="hiddendateformat" type="hidden" name="hiddendateformat" runat="server">
			<INPUT id="hiddenusername" type="hidden" size="1" name="Hidden1" runat="server" onserverchange="hiddenusername_ServerChange">
		</form>
	</body>
</HTML>

