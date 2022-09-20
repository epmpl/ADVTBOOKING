<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Agencybank_mast.aspx.cs" Inherits="Agencybank_mast" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>bank_master</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<script type="text/javascript" language="javascript" src="javascript/tree.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/bankmaster.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/Validations.js"></script>
	</head>
	<body onkeydown="if(event.keyCode==13){event.keyCode=9;return event.keyCode;}" >
		<form id="Form1" method="post" runat="server">
			<table id="table4" bordercolor="#000000" cellspacing="0" align="center" cellpadding="0" border="1" width="632">
				<tr>
					<td valign="middle" align="center" >
						<div>
							<table class="Righttable" id="Righttable" cellspacing="0" cellpadding="0" align="center"
								border="0">
								<tr valign="top" align="left">
									<td style="height: 31px">
										<table id="table7" style="WIDTH: 656px; HEIGHT: 12px" cellspacing="0" cellpadding="0" width="633"
											align="center" bgcolor="#7daae3" border="0">
											<tr>
												<td align="center" class="btnlink" >Bank Master</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td>
										<table id="table1" align="center" cellpadding="0" cellspacing="0">
											<tr>
												<td align="left"><asp:label id="Country" runat="server" CssClass="NewTextField"></asp:label></td>
												<td align="left"><asp:dropdownlist id="drpcountryname" runat="server" CssClass="dropdown"></asp:dropdownlist></td>
                                                <td align="left">
                                                    <asp:label id="City" runat="server" CssClass="NewTextField"></asp:label></td>
                                                <td>
                                                    &nbsp; &nbsp; &nbsp;
                                                    <asp:dropdownlist id="drpcity" runat="server" CssClass="dropdown" >
                                                        <asp:ListItem Value="0">--Select City--</asp:ListItem>
                                                    </asp:dropdownlist></td>
                                                
                                                
											</tr>
											<tr>
												<td align="left"><asp:label id="BankNo" runat="server" CssClass="NewTextField"></asp:label></td>
												<td align="left"><asp:textbox id="txtbno" runat="server" CssClass="btext1" MaxLength="12"  onkeypress="return Bankacc()"></asp:textbox></td>
                                                <td align="left">
                                                    <asp:label id="ACCNO" runat="server" CssClass="NewTextField"></asp:label></td>
                                                <td>
                                                    &nbsp;&nbsp; &nbsp;&nbsp;
                                                   
                                                    <asp:textbox  id="txtano" runat="server" CssClass="btext1" onkeypress="return Bankacc()"
														 MaxLength="25"></asp:textbox></td>
											</tr>
											<tr>
												<td align="left"><asp:label id="BankName" runat="server" CssClass="NewTextField"></asp:label></td>
												<td align="left" colspan="3"><asp:textbox id="txtname" runat="server" CssClass="btext" MaxLength="30"   onkeypress="return BankSpecialchar()"></asp:textbox></td>
												<td align="left"></td>
											</tr>
											<tr>
												<td align="left"><asp:label id="Branch" runat="server" CssClass="NewTextField"></asp:label></td>
												<td align="left" colspan="3"><asp:textbox id="txtbran" runat="server" CssClass="btext" MaxLength="15" onkeypress="return BankSpecialchar()"></asp:textbox></td>
												<td align="left"></td>
											</tr>
											<tr>
												<td style="height: 26px"></td>
												<td style="height: 26px"></td>
												<td style="height: 26px"></td>
												<td valign="middle" align="right" style="width: 231px" >
                                                    <asp:button id="btnsubmit" runat="server" CssClass="button1"></asp:button><asp:Button ID="clear" runat="server" CssClass="button1" />
                                                    &nbsp; &nbsp;&nbsp;</td>
											</tr>
											<tr>
												<td colspan="4" align="left">
													<div style="OVERFLOW: auto; WIDTH: 587px; HEIGHT: 176px">
														<table id="table2" height="158" width="500" align="left">
															<tr>
																<td align="left"><asp:datagrid id="DataGrid1" runat="server" CssClass="dtGrid" Width="573px" AllowSorting="True"
														AutoGenerateColumns="False">
														<SelectedItemStyle BackColor="#046791"></SelectedItemStyle>
														<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="bank_name" SortExpression="bank_name" HeaderText="Bank Name">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="branch" SortExpression="branch" HeaderText="Branch">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="countryname" SortExpression="countryname" HeaderText="Country">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="cityname" SortExpression="cityname" HeaderText="City">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="bank_no" SortExpression="bank_no" HeaderText="Bank NO.">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="Acount_No" SortExpression="Acount_No" ReadOnly="True" HeaderText="Account No.">
																				<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																			</asp:BoundColumn>
																			<asp:BoundColumn Visible="False" DataField="autobank" ReadOnly="True" HeaderText="contcode">
																				<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																			</asp:BoundColumn>
															<asp:TemplateColumn Visible="False" HeaderText="Update">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:TemplateColumn>
															
															<asp:TemplateColumn Visible="False" HeaderText="Delete">
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:TemplateColumn>
														</Columns>
													</asp:datagrid><input id="hiddencomcode" type="hidden" size="12" name="hiddencomcode" runat="server" />
																	<input id="hiddenuserid" type="hidden" name="hiddenuserid" runat="server"/>
																	<input id="hiddenagevcode" type="hidden" name="hiddenagevcode" runat="server"/>
																	<input id="hiddenagensubcode" type="hidden" size="1" name="hiddenagensubcode" runat="server"/>
																	<input id="hiddenccode" type="hidden" size="1" name="hiddenagensubcode" runat="server" />
																	<input id="hiddenagencycode" type="hidden" size="1" name="hiddenagensubcode" runat="server" />
																	<input id="hiddendateformat" type="hidden" name="hiddendateformat" runat="server" />
																</td>
															</tr>
															<tr align="right">
																<td align="right"><asp:button id="btnclose" runat="server" Text="Close" CssClass="button1" OnClick="btnclose_Click"></asp:button>
																<asp:button id="btndelete" runat="server" CssClass="button1" Enabled="False"></asp:button></td>
															</tr>
														</table>
													</div>
												</td>
											</tr>
										</table>
										<table id="table6" cellspacing="0" cellpadding="0" width="656" align="center" bgcolor="#7daae3"
											border="0">
											<tr>
												<td align="center"  style="height: 18px"></td>
											
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</div>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
