<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SchemeDetails.aspx.cs" Inherits="SchemeDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<HEAD>
		<title>Display Ad. Booking & Sheduling SchemeDetails</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="javascript/SchemeDetails.js"></script>
		<script language="javascript" src="javascript/popupcalender.js"></script>
		<script language="javascript" src="javascript/datevalidation.js"></script>
		<script language="javascript" src="javascript/Validations.js"></script>
		<link href="css/main.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" borderColor="#000000" cellSpacing="0" cellPadding="0" align="center"
				border="1" WIDTH="712" HEIGHT="250">
				<TBODY>
					<TR vAlign="middle">
						<TD>
							<TABLE id="Table3" align="center" bgColor="#7daae3" border="0" WIDTH="712">
								<TR>
									<TD class="btnlink" align="center">Scheme Details</TD>
								</TR>
							</TABLE>
							<TABLE id="Table5" width="677" align="center" border="0">
								<TR>
									<TD>
										<TABLE id="Table9" width="697" align="center" border="0">
											<TR>
												<TD><asp:label id="Label2" runat="server" Width="80px" CssClass="TEXTFIELD">Paid Ins.</asp:label></TD>
												<TD><asp:textbox id="txtPaidIns" runat="server" CssClass="btext1" onkeypress="return ClientisNumber()"
														MaxLength="8"></asp:textbox>
												</TD>
												<TD><asp:label id="Label1" runat="server" Width="112px" CssClass="TEXTFIELD"> Free Ins Edtion</asp:label></TD>
												<TD><asp:textbox id="txtfreinsedi" runat="server" CssClass="btext1" MaxLength="8" ontextchanged="txtfreinsedi_TextChanged"></asp:textbox></TD>
											</TR>
											<TR>
												<TD><asp:label id="Label6" runat="server" Width="80px" CssClass="TEXTFIELD">Free Ins</asp:label></TD>
												<TD><asp:textbox id="txtFreeIns" runat="server" onkeypress="return ClientisNumber()" CssClass="btext1"
														MaxLength="8"></asp:textbox></TD>
												<TD><asp:label id="Label3" runat="server" Width="136px" CssClass="TEXTFIELD">Scheme Valid From</asp:label></TD>
												<TD><asp:textbox id="txtSchValFrom" runat="server" CssClass="btext1"></asp:textbox>
													<SCRIPT language="javascript">
										
									if (!document.layers) 
									    {
									    document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, Form1.txtSchValFrom, \"mm/dd/yyyy\")' height=14 width=14> ") 
									    } 
													</SCRIPT>
												</TD>
											</TR>
											<TR>
												<TD><asp:label id="Label4" runat="server" Width="104px" CssClass="TEXTFIELD">Dis No. of Ins.</asp:label></TD>
												<TD><asp:textbox id="txtDisNoOfIns" onkeypress="return ClientisNumber()" runat="server" CssClass="btext1"
														MaxLength="8"></asp:textbox></TD>
												<TD><asp:label id="label16" runat="server" Width="128px" CssClass="TEXTFIELD">Scheme Valid Till</asp:label></TD>
												<TD><asp:textbox id="txtSchValTill" runat="server" CssClass="btext1"></asp:textbox>
													<SCRIPT language="javascript">					
								if (!document.layers) 
							     {
								    document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, Form1.txtSchValTill, \"mm/dd/yyyy\")' height=14  width=14> ") 
								    }
													</SCRIPT>
												</TD>
											</TR>
											<TR>
												<TD><asp:label id="Label5" runat="server" Width="96px" CssClass="TEXTFIELD">Dis Type</asp:label></TD>
												<TD><asp:dropdownlist id="drpDisType" runat="server" CssClass="dropdown">
														<asp:ListItem Value="0">Select</asp:ListItem>
														<asp:ListItem Value="F">Fixed</asp:ListItem>
														<asp:ListItem Value="P">Percentage</asp:ListItem>
													</asp:dropdownlist></TD>
												<TD><asp:label id="label17" runat="server" Width="144px" CssClass="TEXTFIELD">Scheme Cons Period</asp:label></TD>
												<TD><asp:textbox id="SchConPeriod" onkeypress="return ClientisNumber()" runat="server" CssClass="btext1"
														MaxLength="3"></asp:textbox></TD>
											</TR>
											<TR>
												<TD><asp:label id="Label7" runat="server" Width="96px" CssClass="TEXTFIELD">Discount</asp:label></TD>
												<TD><asp:textbox id="txtdiscount" runat="server" onkeypress="return ClientisNumber()" CssClass="btext1"
														MaxLength="8"></asp:textbox></TD>
												<TD><asp:label id="label18" runat="server" Width="128px" CssClass="TEXTFIELD">Cons Period Type</asp:label></TD>
												<TD><asp:dropdownlist id="ConsPeriodType" runat="server" CssClass="dropdown">
														<asp:ListItem Value="0">Select</asp:ListItem>
														<asp:ListItem Value="D">Day</asp:ListItem>
														<asp:ListItem Value="W">Week</asp:ListItem>
													</asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD align="right" colSpan="4"><asp:button id="btnsubmit" runat="server" CssClass="button1" Text="Submit"></asp:button></TD>
											</TR>
											<TR>
												<TD colSpan="4">
													<TABLE id="Table1" align="center">
														<TR>
															<TD align="center">
																<div style="OVERFLOW: auto; WIDTH: 710px; HEIGHT: 150px">
																	<asp:datagrid id="DataGrid1" runat="server" CssClass="dtGrid" Width="685px" AllowSorting="True"
																		AutoGenerateColumns="False">
																		<SelectedItemStyle BackColor="#046791"></SelectedItemStyle>
																		<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd" BackColor="#7DAAE3"></HeaderStyle>
																		<Columns>
																			<asp:TemplateColumn>
																				<ItemTemplate>
																					<asp:CheckBox id="CheckBox1" CssClass="textfield1" Runat="server"></asp:CheckBox>
																				</ItemTemplate>
																			</asp:TemplateColumn>
																			<asp:BoundColumn DataField="Paid_Ins" HeaderText="Paid Ins">
																				<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																			</asp:BoundColumn>
																			<asp:BoundColumn DataField="Free_Ins" HeaderText="Free Ins.">
																				<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																			</asp:BoundColumn>
																			<asp:BoundColumn DataField="Disc_on_Ins" HeaderText="Dis on No. of Ins.">
																				<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																			</asp:BoundColumn>
																			<asp:BoundColumn Visible="False" DataField="Disc_Type" ReadOnly="True" HeaderText="Dis. Type">
																				<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																			</asp:BoundColumn>
																			<asp:BoundColumn DataField="Discount" HeaderText="Discount">
																				<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																			</asp:BoundColumn>
																			<asp:BoundColumn DataField="Free_Ins_Edition" HeaderText="Free Ins In Edition">
																				<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																			</asp:BoundColumn>
																			<asp:BoundColumn DataField="Valid_From_Date" HeaderText="Scheme Valid From" DataFormatString="{0:d}">
																				<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																			</asp:BoundColumn>
																			<asp:BoundColumn DataField="Valid_Till_Date" HeaderText="Scheme Valid Till" DataFormatString="{0:d}">
																				<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																			</asp:BoundColumn>
																			<asp:BoundColumn DataField="Cons_Period" HeaderText="Scheme Cosns Period">
																				<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																			</asp:BoundColumn>
																			<asp:BoundColumn DataField="Cons_Period_Type" HeaderText="Cons.Period Type">
																				<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																			</asp:BoundColumn>
																			<asp:BoundColumn Visible="False" DataField="sch_code" HeaderText="code">
																				<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																			</asp:BoundColumn>
																		</Columns>
																	</asp:datagrid>
																</div>
																<INPUT id="hiddendateformat" type="hidden" name="hiddendateformat" runat="server"><INPUT id="hiddenccode" type="hidden" size="10" name="hiddenccode" runat="server"><INPUT id="hiddencompcode" type="hidden" size="5" name="hiddencomcode" runat="server"><INPUT id="hiddenuserid" type="hidden" size="5" name="hiddenuserid" runat="server"><INPUT id="hiddenagevcode" type="hidden" size="5" name="hiddenagevcode" runat="server"><INPUT id="hiddenSchemeCode" type="hidden" size="5" name="hiddenagensubcode" runat="server"></TD>
														</TR>
														<TR align="right">
															<TD align="right">
																<asp:button id="btnselect" runat="server" CssClass="button1" Text="Select"></asp:button>
																<asp:button id="btndelete" runat="server" CssClass="button1" Text="Delete" Enabled="False"></asp:button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
										<TABLE id="Table6" style="WIDTH: 689px; HEIGHT: 19px" cellSpacing="0" cellPadding="0" width="689"
											align="center" bgColor="#7daae3" border="0">
											<TR>
												<TD align="center"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
