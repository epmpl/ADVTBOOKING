<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="bank_master.aspx.cs" Inherits="bank_master" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>Agency Master Bank Master</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<script type="text/javascript" language="javascript" src="javascript/tree.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/bankmaster.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/capital.js"></script>
		<script language="javascript" src="javascript/entertotab.js"></script>
		<script language="javascript" src="javascript/gridsize.js"></script>
	</head>
	<body onkeydown="javascript:return tabvalue(event);" onkeypress="eventcalling(event);" >
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
												<td align="left" style="height: 19px"><asp:label id="Country" runat="server" CssClass="NewTextField"></asp:label></td>
												<td align="left" style="height: 19px"><asp:dropdownlist id="drpcountryname" runat="server" CssClass="dropdown"></asp:dropdownlist></td>
                                                <td align="left" style="height: 19px">
                                                    <asp:label id="City" runat="server" CssClass="NewTextField"></asp:label></td>
                                                <td style="width: 240px; height: 19px;" align="right">
                                                    &nbsp; &nbsp;
                                                    <asp:dropdownlist id="drpcity" runat="server" CssClass="dropdown" >
                                                        <asp:ListItem Value="0">--Select City--</asp:ListItem>
                                                    </asp:dropdownlist>
                                                    &nbsp;&nbsp; &nbsp;
                                                </td>
                                                
                                                
											</tr>
											<tr>
												<td align="left"><asp:label id="BankNo" runat="server" CssClass="NewTextField"></asp:label></td>
												<td align="left"><asp:textbox id="txtbno" runat="server" CssClass="btext1" MaxLength="12"  onkeydown="return Bankacc(event)"></asp:textbox></td>
                                                <td>
                                                    <asp:label id="ACCNO" runat="server" CssClass="NewTextField"></asp:label></td>
                                                <td align="right">
                                                    &nbsp;&nbsp;
                                                   
                                                    <asp:textbox  id="txtano" runat="server" CssClass="btext1" onkeypress="javascript:return ischarKey(event);"
														 MaxLength="25"></asp:textbox>
                                                    &nbsp;&nbsp; &nbsp;
                                                </td>
											</tr>
											<tr>
												<td align="left"><asp:label id="BankName" runat="server" CssClass="NewTextField"></asp:label></td>
												<td align="left" colspan="3"><asp:textbox id="txtname" runat="server" CssClass="btext" MaxLength="30"   onkeypress="return BankSpecialchar(event)"></asp:textbox></td>
												<td align="left"></td>
											</tr>
											<tr>
												<td align="left"><asp:label id="Branch" runat="server" CssClass="NewTextField"></asp:label></td>
												<td align="left" colspan="3"><asp:textbox id="txtbran" runat="server" CssClass="btext" MaxLength="30" onkeypress="return BankSpecialchar(event)"></asp:textbox></td>
												<td align="left"></td>
											</tr>
                                            <tr>
                                                <td align="left">
                                                </td>
                                                <td align="left" colspan="3" height="10px">
                                                </td>
                                                <td align="left">
                                                </td>
                                            </tr>
											<tr>
												<td></td>
												<td></td>
												<td></td>
												<td align="right">
                                                    <asp:button id="btnsubmit" runat="server" CssClass="button1" OnClick="btnsubmit_Click"></asp:button><asp:Button ID="clear" runat="server" CssClass="button1" />
                                                    &nbsp; &nbsp;&nbsp; </td>
											</tr>
											<tr>
												<td colspan="4" align="right">
													<div id="Div1" runat="server" style="OVERFLOW: auto; WIDTH: 572px; HEIGHT: 125px">
														<asp:datagrid id="DataGrid1" runat="server" CssClass="dtGrid" Width="550px" cellpadding="0" AutoGenerateColumns="False"
																		AllowSorting="True" >
																		<SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
																		<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
																		<Columns>
																			<asp:TemplateColumn>
																				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																				<ItemTemplate>
																					<asp:CheckBox id="CheckBox1" runat="server"></asp:CheckBox>
																				</ItemTemplate>
																			</asp:TemplateColumn>
																			<asp:BoundColumn DataField="bank_name" SortExpression="bank_name" ReadOnly="True" HeaderText="Bank Name">
																				<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																			</asp:BoundColumn>
																			<asp:BoundColumn DataField="branch" SortExpression="branch" ReadOnly="True" HeaderText="Branch">
																				<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																			</asp:BoundColumn>
																			<asp:BoundColumn DataField="countryname" SortExpression="countryname" ReadOnly="True" HeaderText="Country">
																				<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																			</asp:BoundColumn>
																			<asp:BoundColumn DataField="cityname" SortExpression="cityname" ReadOnly="True" HeaderText="City">
																				<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																			</asp:BoundColumn>
																			<asp:BoundColumn DataField="bank_no" SortExpression="bank_no" ReadOnly="True" HeaderText="Bank NO.">
																				<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
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
																				<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																			</asp:TemplateColumn>
																			<asp:TemplateColumn Visible="False" HeaderText="Delete">
																				<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																			</asp:TemplateColumn>
																		</Columns>
																	</asp:datagrid>
																	
															
                                                      
													</div>
																									
													<div id="Div2" runat="server" style="OVERFLOW: auto; WIDTH: 572px; HEIGHT: 125px">
														<asp:datagrid id="DataGrid2" runat="server" CssClass="dtGrid" Width="550px" cellpadding="0" AutoGenerateColumns="False"
																		AllowSorting="True" >
																		<SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
																		<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
																		<Columns>
																			<asp:BoundColumn DataField="bank_name" SortExpression="bank_name" ReadOnly="True" HeaderText="Bank Name">
																				<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																			</asp:BoundColumn>
																			<asp:BoundColumn DataField="branch" SortExpression="branch" ReadOnly="True" HeaderText="Branch">
																				<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																			</asp:BoundColumn>
																			<asp:BoundColumn DataField="countryname" SortExpression="countryname" ReadOnly="True" HeaderText="Country">
																				<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																			</asp:BoundColumn>
																			<asp:BoundColumn DataField="cityname" SortExpression="cityname" ReadOnly="True" HeaderText="City">
																				<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																			</asp:BoundColumn>
																			<asp:BoundColumn DataField="bank_no" SortExpression="bank_no" ReadOnly="True" HeaderText="Bank NO.">
																				<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
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
																				<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																			</asp:TemplateColumn>
																			<asp:TemplateColumn Visible="False" HeaderText="Delete">
																				<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																			</asp:TemplateColumn>
																		</Columns>
																	</asp:datagrid>
																		
                                                      
													</div>
												<asp:button id="btnclose" runat="server" CssClass="button1" OnClick="btnclose_Click"></asp:button><asp:button id="btndelete" runat="server" CssClass="button1" Enabled="False"></asp:button>
                                                    &nbsp;&nbsp;
                                                </td>
											</tr>
										</table>
										<table>
										<tr>
										<td>
										                    <input id="hiddencomcode" type="hidden" size="1" name="hiddencomcode" runat="server" />
																	<input id="hiddenuserid" type="hidden" size="1"  name="hiddenuserid" runat="server"/>
																	<input id="hiddenagevcode" type="hidden" size="1"  name="hiddenagevcode" runat="server"/>
																	<input id="hiddenagensubcode" type="hidden" size="1" name="hiddenagensubcode" runat="server"/>
																	<input id="hiddenccode" type="hidden" size="1" name="hiddenagensubcode" runat="server" />
																	<input id="hiddenagencycode" type="hidden" size="1" name="hiddenagensubcode" runat="server" />
																	<input id="hiddendateformat" type="hidden" size="1"  name="hiddendateformat" runat="server" />
																	<input id="hiddencountry" type="hidden" size="1"  name="hiddendateformat" runat="server" />
																	<input id="hiddencity" type="hidden" size="1"  name="hiddendateformat" runat="server" />
															       <input id="hiddensaurabh" type="hidden" name="hiddenuserid" runat="server"/>
											
										</td>
										</tr>
										
										</table>
										<table id="table6" cellspacing="0" cellpadding="0" width="656" align="center" bgcolor="#7daae3"
											border="0">
											<tr>
												<td align="center"  style="height: 18px">
												
												                    	</td>
											
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