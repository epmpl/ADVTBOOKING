<%@ Page Language="C#" AutoEventWireup="true" CodeFile="uompermagency.aspx.cs" Inherits="uompermagency"  EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>UOM Wise Permission</title>
    	<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<script type="text/javascript" language="javascript" src="javascript/tree.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/uompermagency.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/capital.js"></script>
		<script language="javascript" src="javascript/entertotab.js"></script>
		<script language="javascript" src="javascript/gridsize.js"></script>
</head>
<body onkeypress="eventcalling(event);">
    <form id="form1" runat="server">
   <table id="tab2"  style="border-color:#000000;" cellspacing="0" align="center" cellpadding="0" border="1" width="632">
				<tr>
					<td valign="middle" align="center" >
						<div>
							<table class="Righttable" id="Righttable" cellspacing="0" cellpadding="0" align="center"
								border="0">
								<tr valign="top" align="left">
									<td style="height: 31px">
										<table id="tab3" style="WIDTH: 656px; HEIGHT: 12px" cellspacing="0" cellpadding="0" width="633"
											align="center" bgcolor="#7daae3" border="0">
											<tr>
												<td align="center" class="btnlink" >UOM Wise Permission</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td>
										<table id="table1" align="center" cellpadding="0" cellspacing="0">
											<tr>
												<td align="left" style="height: 19px"><asp:label id="lbladtype" runat="server" CssClass="NewTextField"></asp:label></td>
												<td align="left" style="height: 19px"><asp:dropdownlist id="drpadtype" runat="server" CssClass="dropdown">
												</asp:dropdownlist></td>
                                                <td align="left" style="height: 19px">
                                                    <asp:label id="lblcat" runat="server" CssClass="NewTextField"></asp:label></td>
                                                <td style="width: 240px; height: 19px;" align="right">
                                                    &nbsp; &nbsp;
                                                    <asp:dropdownlist id="drpcat" runat="server" CssClass="dropdown" >
                                                        <asp:ListItem Value="0">--Select Category--</asp:ListItem>
                                                    </asp:dropdownlist>
                                                    &nbsp;&nbsp; &nbsp;
                                                </td>
                                                
                                                
											</tr>
											<tr>
												<td align="left" style="height: 19px"><asp:label id="lbluom" runat="server" CssClass="NewTextField"></asp:label></td>
												<td align="left" style="height: 19px"><asp:dropdownlist id="drpuom" runat="server" CssClass="dropdown">
												 </asp:dropdownlist></td>
                                              
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
																			<asp:BoundColumn DataField="uom_name" SortExpression="uom_name" ReadOnly="True" HeaderText="UOM">
																				<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																			</asp:BoundColumn>
																			<asp:BoundColumn DataField="adtype" SortExpression="adtype" ReadOnly="True" HeaderText="Adtype">
																				<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																			</asp:BoundColumn>
																			<asp:BoundColumn DataField="category" SortExpression="category" ReadOnly="True" HeaderText="Category">
																				<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																			</asp:BoundColumn>
																				<asp:BoundColumn Visible="False" DataField="seq_no" ReadOnly="True" HeaderText="Seq">
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
																			<asp:BoundColumn DataField="uom_name" SortExpression="uom_name" ReadOnly="True" HeaderText="Uom">
																				<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																			</asp:BoundColumn>
																			<asp:BoundColumn DataField="adtype" SortExpression="adtype" ReadOnly="True" HeaderText="Adtype">
																				<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																			</asp:BoundColumn>
																			<asp:BoundColumn DataField="category" SortExpression="category" ReadOnly="True" HeaderText="Category">
																				<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																			</asp:BoundColumn>
																			
																			<asp:BoundColumn Visible="False" DataField="seq_no" ReadOnly="True" HeaderText="Seq">
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
												<asp:button id="btnclose" runat="server" CssClass="button1" ></asp:button><asp:button id="btndelete" runat="server" CssClass="button1" Enabled="False"></asp:button>
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
																	<input id="hiddenseq" type="hidden" size="1" name="hiddenagensubcode" runat="server" />
																	<input id="hiddenagencycode" type="hidden" size="1" name="hiddenagensubcode" runat="server" />
																	<input id="hiddendateformat" type="hidden" size="1"  name="hiddendateformat" runat="server" />
																	<input id="hiddenuom" type="hidden" size="1"  name="hiddendateformat" runat="server" />
																	<input id="hiddencate" type="hidden" size="1"  name="hiddendateformat" runat="server" />
															       <input id="hiddensaurabh" type="hidden" name="hiddenuserid" runat="server"/>
															         <input id="hiddenadtyp" type="hidden" name="hiddenuserid" runat="server"/>
											
										</td>
										</tr>
										
										</table>
										<table id="tab4" cellspacing="0" cellpadding="0" width="656" align="center" bgcolor="#7daae3"
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
