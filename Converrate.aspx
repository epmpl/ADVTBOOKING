<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Converrate.aspx.cs" Inherits="Converrate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>Conversion Rate</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<script type="text/javascript" language="javascript" src="javascript/currencymaster.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/Validations.js"></script>
	
		<script type="text/javascript" language="javascript" src="javascript/datevalidation.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
	
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
			<script type="text/javascript" language="javascript">
			function datecurr(event)
		{
		    return false;
		 if ((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==47)||(event.keyCode==11))
	{
		
		return true;
	}
	else
	{
		return false;
	}
	
		
		
		
		}
		function notchar2()
{

if((event.keyCode>=48 && event.keyCode<=57)||
(event.keyCode==47)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==190)||

(event.keyCode==9 || event.keyCode==32))
{
return true;
}
else
{
return false;
}
}

function notcharrate(e)
{
var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer")
 {
 if((e.which>=48 && e.which<=57)||
(e.which==127)||(e.which==8)||(e.which==190)||

(e.which==9 || e.which==32)||(e.which==46))
{
return true;
}
else
{
return false;
}
}
else
{
if((e.keyCode>=48 && e.keyCode<=57)||
(e.keyCode==127)||(e.keyCode==8)||(e.keyCode==190)||

(e.keyCode==9 || e.keyCode==32)||(e.keyCode==46))
{
return true;
}
else
{
return false;
}
}
}


		
			</script>
	</head>
	<body onload="loadXML('xml/errorMessage.xml');"   onkeypress="eventcalling(event);" onkeydown="javascript:return tabvalue(event);">
		<table height="672" cellspacing="0" cellpadding="0" width="419" border="0" ms_2d_layout="TRUE">
			<tr valign="top">
				<td width="419" height="672">
					<form id="Form1" method="post" runat="server">
						<table height="402" cellspacing="0" cellpadding="0" width="660" border="0" ms_2d_layout="TRUE">
							<tr valign="top">
								<td width="27" height="8"></td>
								<td width="633"></td>
							</tr>
							<tr valign="top">
								<td height="394"></td>
								<td>
									<table id="Table4" bordercolor="#000000"  cellspacing="0" cellpadding="0" width="632"
										align="center" border="1">
										<tr vAlign="middle">
											<td>
												<table id="Table3" cellspacing="0" cellpadding="0" width="633" align="center" bgColor="#7daae3"
													border="0">
													<tr>
														<td class="btnlink" align="center" style="height: 10px">Conversion Rate</td>
													</tr>
												</table>
												<table id="Table5" cellspacing="0" cellpadding="0" width="597" align="center" border="0">
													<tr>
														<td>
															<table id="Table9" cellspacing="0" cellpadding="0" width="585" align="center" border="0">
																<tr>
																	<td colspan="4" height="19"></td>
																</tr>
																<tr>
																	<td>
																		<asp:label id="ConversionRate" runat="server" CssClass="TextField"></asp:label></td>
																	<td>
																		<asp:textbox onkeypress="return notcharrate(event);" id="txtconrate" runat="server"  CssClass="btext1" MaxLength="10" style="text-align:right" ></asp:textbox></td>
																	<td align="left"><asp:label id="lblcurrency" runat="server" CssClass="TextField"></asp:label>
																	<td> <asp:DropDownList ID="drpcurrency" runat="server" CssClass="dropdowns"></asp:DropDownList>
																</tr>
																<tr>
																	<td>
																		<asp:label id="EffectiveFrom" runat="server" CssClass="TextField"></asp:label></td>
																	<td>
																		<asp:textbox onkeypress="return datecurr(event);" id="txteffrate" ReadOnly="true" runat="server" CssClass="btext1" MaxLength="10"></asp:textbox>
																		<script type="text/javascript" language="javascript">
                                    										
									                                    if (!document.layers) 
									                                        {
									                                        document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, Form1.txteffrate, \"mm/dd/yyyy\")' height=14 width=14> ") 
									                                        } 
																		                                    </script>
																	</td>
																	<td>
																		<asp:label id="EffectiveTill" runat="server" CssClass="TextField" ></asp:label></td>
																	<td>
																		<asp:textbox  onkeypress="return datecurr(event);" id="txtefftill"  ReadOnly="true" runat="server" CssClass="btext1" MaxLength="10"></asp:textbox>
																		<script type="text/javascript" language="javascript">					
								                                    if (!document.layers) 
							                                         {
								                                        document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, Form1.txtefftill, \"mm/dd/yyyy\")' height=14  width=14> ") 
								                                        }
																		 </script>
																	</td>
																</tr>
																<tr>
																<td><asp:Label ID="lblunit" runat="server" CssClass="TextField"></asp:Label></td>
																 <td colspan="3"><asp:textbox onkeypress="return notcharrate(event);" id="txtunit" runat="server"  CssClass="btext1" MaxLength="10" style="text-align:right" ></asp:textbox></td>
																</tr>
																<tr>
																	<td height="10"></td>
																	<td height="10"></td>
																	<td height="10"></td>
																	<td height="10"></td>
																</tr>
																<tr>
																	<td></td>
																	<td></td>
																	<td></td>
																	<td align="right"></td>
																</tr>
																<tr>
																	<td></td>
																	<td></td>
																	<td></td>
																	<td align="right">
																		<asp:button id="btnsubmit" runat="server" CssClass="button1" Text="Submit" OnClick="btnsubmit_Click"></asp:button><asp:button id="btnclear" runat="server" CssClass="button1" Text="Submit"></asp:button></td>
																</tr>
															</table>
															
																<table id="Table1" align="center">
																	<tr>
																		<td align="center" height="127">
																		   <div id="divdatagrid2" runat="server" >
    
																			<asp:datagrid id="DataGrid2" runat="server" CssClass="dtGrid" Width="576px"  AllowSorting="True" AutoGenerateColumns="False" OnItemDataBound="DataGrid2_ItemDataBound" OnSortCommand="abc" >
																				<SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
																				<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
																				<Columns>
																					<asp:TemplateColumn>
																						<ItemStyle HorizontalAlign="Center"></ItemStyle>
																					</asp:TemplateColumn>
																					<asp:BoundColumn DataField="Conv_Rate" HeaderText="Convert Rate" SortExpression="Conv_Rate">
																						<ItemStyle HorizontalAlign="Center"></ItemStyle>
																					</asp:BoundColumn>
																					<asp:BoundColumn DataField="CONV_CURRENCY" HeaderText="Currency" SortExpression="currency">
																						<ItemStyle HorizontalAlign="Center"></ItemStyle>
																					</asp:BoundColumn>
																					<asp:BoundColumn DataField="Valid_From_Date" HeaderText="Valid From" SortExpression="Valid_From_Date">
																						<ItemStyle HorizontalAlign="Center"></ItemStyle>
																					</asp:BoundColumn>
																					<asp:BoundColumn DataField="Valid_Till_Date" HeaderText="Valid To" SortExpression="Valid_Till_Date">
																						<ItemStyle HorizontalAlign="Center"></ItemStyle>
																					</asp:BoundColumn>
																					<asp:BoundColumn Visible="False" DataField="Convert_code" ReadOnly="True" HeaderText="Convert_code" >
																						<ItemStyle HorizontalAlign="Center"></ItemStyle>
																					</asp:BoundColumn>
																					<asp:BoundColumn DataField="UNIT" HeaderText="Unit" SortExpression="UNIT">
																						<ItemStyle HorizontalAlign="Center"></ItemStyle>
																					</asp:BoundColumn>
																				</Columns>
																			</asp:datagrid>
																			
																			</div>
																			
																		
																		   <div id="divdatagrid1" runat="server" >
    
																			<asp:datagrid id="DataGrid1" runat="server" CssClass="dtGrid" Width="576px"  AllowSorting="False" AutoGenerateColumns="False" OnItemDataBound="DataGrid1_ItemDataBound">
																				<SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
																				<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
																				<Columns>
																						<asp:BoundColumn Visible="False" DataField="Convert_code" ReadOnly="True" HeaderText="Convert_code" >
																						<ItemStyle HorizontalAlign="Center"></ItemStyle>
																					</asp:BoundColumn>
																					<asp:BoundColumn DataField="Conv_Rate" HeaderText="Convert Rate" SortExpression="Conv_Rate">
																						<ItemStyle HorizontalAlign="Center"></ItemStyle>
																					</asp:BoundColumn>
																					<asp:BoundColumn DataField="CONV_CURRENCY" HeaderText="Currency" SortExpression="CONV_CURRENCY">
																						<ItemStyle HorizontalAlign="Center"></ItemStyle>
																					</asp:BoundColumn>
																					<asp:BoundColumn DataField="Valid_From_Date" HeaderText="Valid From" SortExpression="Valid_From_Date">
																						<ItemStyle HorizontalAlign="Center"></ItemStyle>
																					</asp:BoundColumn>
																					<asp:BoundColumn DataField="Valid_Till_Date" HeaderText="Valid To" SortExpression="Valid_Till_Date">
																						<ItemStyle HorizontalAlign="Center"></ItemStyle>
																					</asp:BoundColumn>
																					<asp:BoundColumn DataField="UNIT" HeaderText="Unit" SortExpression="UNIT">
																						<ItemStyle HorizontalAlign="Center"></ItemStyle>
																					</asp:BoundColumn>
																				</Columns>
																			</asp:datagrid></div>
																			<input id="hiddencompcode" type="hidden" size="1" name="hiddencompcode" runat="server"/>
																			<input id="hiddencurrcode" type="hidden" size="1" name="Hidden1" runat="server"/>
																			<input id="hiddenuserid" type="hidden" size="1" name="hiddenuserid" runat="server"/>
																			<input id="hiddendateformat" type="hidden" size="1" name="hiddendateformat" runat="server" />
																			<input id="hiddenshow" type="hidden" size="1" name="hiddenshow" runat="server" />
																			<input id="hidfrom" type="hidden" size="1" name="hiddenshow" runat="server" />
																			<input id="hidto" type="hidden" size="1" name="hiddenshow" runat="server" />
																			</td>
																			
																			
																			
																			
																			
																					</tr>
																	
																	<tr >
																		<td align="right">
																			<asp:button id="btnclose" runat="server" CssClass="button1" Text="Close" OnClick="btnclose_Click"></asp:button><asp:button id="btndelete" runat="server" CssClass="button1" Text="Delete" Enabled="False"></asp:button></td>
																	</tr>
																</table>
															
														</td>
													</tr>
												</table>
												<table id="Table6" cellspacing="0" cellpadding="0" width="634" align="center" bgcolor="#7daae3"
													border="0">
													<tr>
														<td align="center"></td>
													</tr>
												</table>
												<div></div>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</form>
				</td>
			</tr>
		</table>
	</body>
</html>
