<%@ Page Language="C#" AutoEventWireup="true" CodeFile="categorywiseedition.aspx.cs" EnableEventValidation="false" Inherits="categorywiseedition" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>Display Ad. Booking & Sheduling Category Wise Edition</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<script type="text/javascript"language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/AdCategoryMaster.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/Validations.js"></script>
		<script language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript"language="javascript">
		
		
	function alpha1()
{
if((event.keyCode>=65 && event.keyCode<=90) ||(event.keyCode>=97 && event.keyCode<=122)||(event.keyCode==32))
{
return true;
}

else
{
//alert("Please Enter only Alphabet Values");
return false;
}
}



function phone()
{
if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==32))
{
return true;
}
else
{
//alert("Please enter only numeric values");
return false;
}
}

	
function Table5_onclick() {

}

		</script>
</head>
	<body onload="return disablecheck();" onkeydown="javascript:return tabvalue(event);">
	
	
	
		<form id="Form1" method="post" runat="server">
		 <input type="hidden" size="12" name="hiddencompcode" runat="server" id="hiddencomcode"/>
													<input id="hiddenuserid" type="hidden" name="hiddenuserid" runat="server"/> 
													<input id="hiddenadcatcode" type="hidden" name="hiddencatcode" runat="server"/>
													<input id="hiddendateformat" type="hidden" size="1" name="hiddenagensubcode" runat="server"/>
													<%--<input id="hiddencatmodify" type="hidden" name="hiddencatmodify" runat="server"/>--%>
			<table id="Table4" style="Z-INDEX: 101; LEFT: 24px; WIDTH: 639px; POSITION: absolute; TOP: 16px; HEIGHT: 370px"
				bordercolor="#000000" cellspacing="0" cellpadding="0" width="639" border="1">
				<tr>
					<td>
						<table id="Table2" style="WIDTH: 633px; HEIGHT: 15px" cellspacing="0" cellpadding="0" width="633"
							align="center" bgcolor="#7daae3" border="0" >
							<tr>
								<td class="btnlink" align="center" style="height: 10px">Category Wise Edition</td>
							</tr>
						</table>
						<table id="Table1"cellspacing="0" cellpadding="0" width="562" align="center" border="0">
							<tr>
							</tr>
							<tr>
								<td align="center" >
									<table id="Table5" width="585px" cellspacing="0" cellpadding="0"
										align="center" border="0" <%--onclick="return Table5_onclick()"--%>>
										<tr>
										<td height="10px"></td>
										</tr>
										
										<tr>
											<td style="height: 18px"><asp:Label id="lbeditionname" runat="server" CssClass="TextField"></asp:Label><font color="red">*</font></td>
											<td style="height: 18px">
												<asp:dropdownlist id="drpednname" runat="server" CssClass="dropdown"></asp:dropdownlist></td>
										
										</tr>
										<tr>
											<td height="30px"></td>
										</tr>
                                        <tr>
                                            <td align="left" colspan="4" rowspan="3">
                                            
                                            <table id="Table7"  height="85px" cellspacing="0" cellpadding="0" width="576" border="1" align="center">
													<tr>
														<td valign="top" align="center" bgcolor="#7daae3" colspan="8"><asp:Label id="lbeditionday" runat="server" ForeColor="White"  CssClass="TextField"></asp:Label></td>
													</tr>
													<tr valign="top">
														<td align="center"><asp:Label id="Label12" runat="server" CssClass="TextField">SUN</asp:Label></td>
														<td align="center"><asp:Label id="Label13" runat="server" CssClass="TextField">MON</asp:Label></td>
														<td align="center"><asp:Label id="Label14" runat="server" CssClass="TextField">TUE</asp:Label></td>
														<td align="center"><asp:Label id="Label15" runat="server" CssClass="TextField">WED</asp:Label></td>
														<td align="center"><asp:Label id="Label16" runat="server" CssClass="TextField">THU</asp:Label></td>
														<td align="center"><asp:Label id="Label17" runat="server" CssClass="TextField">FRI</asp:Label></td>
														<td align="center"><asp:Label id="Label19" runat="server" CssClass="TextField">SAT</asp:Label></td>
														<td align="center"><asp:Label id="Label18" runat="server" CssClass="TextField">ALL</asp:Label></td>
													</tr>
													<tr valign="top">
														<td align="center"><asp:CheckBox id="CheckBox1" runat="server" CssClass="textfield"></asp:CheckBox></td>
														<td align="center"><asp:CheckBox id="CheckBox2" runat="server" CssClass="textfield"></asp:CheckBox></td>
														<td align="center"><asp:CheckBox id="CheckBox3" runat="server" CssClass="textfield"></asp:CheckBox></td>
														<td align="center"><asp:CheckBox id="CheckBox4" runat="server" CssClass="textfield"></asp:CheckBox></td>
														<td align="center"><asp:CheckBox id="CheckBox5" runat="server" CssClass="textfield"></asp:CheckBox></td>
														<td align="center"><asp:CheckBox id="CheckBox6" runat="server" CssClass="textfield"></asp:CheckBox></td>
														<td align="center"><asp:CheckBox id="CheckBox7" runat="server" CssClass="textfield"></asp:CheckBox></td>
														<td align="center"><asp:CheckBox id="CheckBox8" runat="server" CssClass="textfield"></asp:CheckBox></td>
													</tr>
												</table>
                                            
                                            
                                            
                                            
                                            </td>
                                          
                                        </tr>
                                    
                                        <tr>
                                            <td align="left">
                                            </td>
                                            <td align="left">
                                            </td>
                                            <td align="left">
                                            </td>
                                            <td align="left">
                                            </td>
                                        </tr>
										<tr>
											<td height="30px"></td>
										</tr>
										<tr>
										<td height="50px"></td>
										<td></td>
										<td></td>
											<td colspan="1" align="right" style="height: 24px"><asp:button id="btnsubmit1" runat="server" CssClass="button1" Width="56px" OnClick="btnsubmit1_Click"></asp:button><asp:Button ID="btnclear1" runat="server" CssClass="button1" /></td>
                                               
										</tr>
										<tr>
											<td></td>
											<td></td>
											<td></td>
											<td></td>
										</tr>
									</table>
									
									<div id="Divgrid1" runat="server" style="OVERFLOW: auto; WIDTH: 587px; HEIGHT: 100px">
										<table id="Table3" align="center" cellpadding="0" cellspacing="0">
											<tr>
												<td style="height: 110px"><asp:datagrid id="DataGrid1" runat="server" CssClass="dtGrid" Width="554px" 
														cellpadding="0" AutoGenerateColumns="False" DESIGNTIMEDRAGDROP="775" OnItemDataBound="DataGrid1_ItemDataBound1" AllowSorting="True">
														<SelectedItemStyle Font-Size="XX-Small" Font-Names="Trebuchet MS" HorizontalAlign="Center" VerticalAlign="Middle"></SelectedItemStyle>
														<HeaderStyle Height="20px" CssClass="dtGridHd" BackColor="#7DAAE3"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn>
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle"></ItemStyle>
															
															</asp:TemplateColumn>
                                                            <asp:BoundColumn DataField="Edcode" HeaderText="EditionName" SortExpression="Edcode">
                                                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
                                                            </asp:BoundColumn>
                                                            <asp:TemplateColumn HeaderText="Sun">
                                                            
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle"></ItemStyle>
																
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="Mon"> 
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle"></ItemStyle>
																
                                                            
                                                            
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="Tue">
                                                            
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle"></ItemStyle>
																
                                                            
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="Wed">
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle"></ItemStyle>
																
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="Thu">
                                                            
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle"></ItemStyle>
																
                                                            
                                                            </asp:TemplateColumn>
                                                            
                                                            <asp:TemplateColumn HeaderText="Fri">
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle"></ItemStyle>
																
                                                            
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="Sat">
                                                            
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle"></ItemStyle>
																
                                                            
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="All">
                                                            
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle"></ItemStyle>
																																
                                                            </asp:TemplateColumn>
															<asp:TemplateColumn Visible="False" HeaderText="Update">
																<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:TemplateColumn>
															<asp:TemplateColumn Visible="False" HeaderText="Delete">
																<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:TemplateColumn>
                                                            <asp:BoundColumn DataField="sun" HeaderText="Sun" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="mon" HeaderText="mon" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="tue" HeaderText="tue" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="wed" HeaderText="wed" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="thu" HeaderText="thu" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="fri" HeaderText="fri" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="sat" HeaderText="sat" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="all" HeaderText="all"
                                                                Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="STAT_CODE" HeaderText="Code" ReadOnly="True" Visible="False">
                                                            </asp:BoundColumn>
														</Columns>
													</asp:datagrid>
                                                   </td>
											</tr>
											</table>
									</div>
									<div  id="Divgrid2" runat="server" style="OVERFLOW: auto; WIDTH: 587px; HEIGHT: 100px">
										<table id="Table8" align="center" cellpadding="0" cellspacing="0">
											<tr>
												<td><asp:datagrid id="DataGrid2" runat="server" CssClass="dtGrid" Width="554px" OnSortCommand="abc"
														cellpadding="0" AutoGenerateColumns="False" DESIGNTIMEDRAGDROP="775" OnItemDataBound="DataGrid2_ItemDataBound1" AllowSorting="True"> 
														<SelectedItemStyle Font-Size="XX-Small" Font-Names="Trebuchet MS" HorizontalAlign="Center" VerticalAlign="Middle"></SelectedItemStyle>
														<HeaderStyle Height="20px" CssClass="dtGridHd" BackColor="#7DAAE3"></HeaderStyle>
														<Columns>
                                                            <asp:BoundColumn DataField="Edcode" HeaderText="EditionName" SortExpression="Edcode">
                                                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
                                                            </asp:BoundColumn>
                                                           
                                                            <asp:TemplateColumn HeaderText="Sun">
                                                            
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle"></ItemStyle>
																
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="Mon"> 
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle"></ItemStyle>
																
                                                            
                                                            
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="Tue">
                                                            
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle"></ItemStyle>
																
                                                            
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="Wed">
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle"></ItemStyle>
																
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="Thu">
                                                            
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle"></ItemStyle>
																
                                                            
                                                            </asp:TemplateColumn>
                                                            
                                                            <asp:TemplateColumn HeaderText="Fri">
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle"></ItemStyle>
																
                                                            
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="Sat">
                                                            
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle"></ItemStyle>
																
                                                            
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="All">
                                                            
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle"></ItemStyle>
																																
                                                            </asp:TemplateColumn>
															<asp:TemplateColumn Visible="False" HeaderText="Update">
																<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:TemplateColumn>
															<asp:TemplateColumn Visible="False" HeaderText="Delete">
																<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:TemplateColumn>
                                                            <asp:BoundColumn DataField="sun" HeaderText="Sun" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="mon" HeaderText="mon" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="tue" HeaderText="tue" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="wed" HeaderText="wed" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="thu" HeaderText="thu" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="fri" HeaderText="fri" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="sat" HeaderText="sat" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="all" HeaderText="all" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="STAT_CODE" HeaderText="Code" ReadOnly="True" Visible="False">
                                                            </asp:BoundColumn>
														</Columns>
													</asp:datagrid>
                                                   
													
												</td>
											</tr>
											
											<%--<tr align="right">
												<td align="right">
                                                    <asp:Button ID="Button1" runat="server" CssClass="button1" OnClick="btnclose1_Click" /><asp:Button ID="Button2" runat="server" CssClass="button1" /></td>
                                                    
											</tr>--%>
										</table>
									</div>
									 <input type="hidden" size="12" name="hiddencompcode" runat="server" id="hchk1"/>
                      <input type="hidden" size="12" name="hiddencompcode" runat="server" id="hchk2"/>
                       <input type="hidden" size="12" name="hiddencompcode" runat="server" id="hchk3"/>
                        <input type="hidden" size="12" name="hiddencompcode" runat="server" id="hchk4"/>
                         <input type="hidden" size="12" name="hiddencompcode" runat="server" id="hchk5"/>
                          <input type="hidden" size="12" name="hiddencompcode" runat="server" id="hchk6"/>
                           <input type="hidden" size="12" name="hiddencompcode" runat="server" id="hchk7"/>
                            <input type="hidden" size="12" name="hiddencompcode" runat="server" id="hchk8"/>
            <input id="hiddenadcatcode1" type="hidden" name="hiddenadcatcode" runat="server"/>
            <input id="hiddenshow" type="hidden" name="hiddenadcatcode" runat="server"/>
			<input id="hiddenedition" type="hidden" name="hiddenadcatcode" runat="server"/>
			<input id="hiddenedition1" type="hidden"	name="hiddenEdcode"	 runat="server" />
			<input id="hiddenname" type="hidden"	name="hiddenEdcode"	 runat="server" />
			<input id="hiddenmodify" type="hidden"	name="hiddenEdcode"	 runat="server" />
			<input id="hiddencode" type="hidden"	name="hiddenEdcode"	 runat="server" />
				
								</td>
            <td style ="display:none"><asp:TextBox ID="txtedition" runat="server"></asp:TextBox></td>
							</tr>
							<tr align="right">
							<td align="right">
                             <asp:Button ID="btnclose1" runat="server" CssClass="button1" OnClick="btnclose1_Click" /><asp:Button ID="btndelete1" runat="server" CssClass="button1" /></td>
                        </tr>
							<%--<tr cellspacing="0" style="WIDTH: 666px; HEIGHT: 15px" cellpadding="0" width="633" align="center" bgcolor="#7daae3" border="0">
											
							<td align="center" height="15px"></td>
							</tr>--%>
							<tr style="width:100px; HEIGHT: 15px"></tr>
							
						</table>
						<table id="Table6" style="WIDTH: 633px; HEIGHT: 15px" cellspacing="0" cellpadding="0" width="633"
							align="center" bgcolor="#7daae3" border="0" >
							<tr>
								<td align="center" style="height: 10px"></td>
							</tr>
						</table>
						
					</td>
				</tr>
						<%--<tr align="right">
							<td align="right">
                             <asp:Button ID="btnclose1" runat="server" CssClass="button1" OnClick="btnclose1_Click" /><asp:Button ID="btndelete1" runat="server" CssClass="button1" /></td>
                        </tr>
							<tr cellspacing="0" cellpadding="0" width="634" align="center" bgcolor="#7daae3" border="0">
											
							<td align="center" height="15px"></td>
							</tr>--%>
						
			</table>
						<%--<table id="Table6"  cellspacing="0" cellpadding="0" width="634"
							align="center" bgcolor="#7daae3" border="0">
							<tr>
								<td align="center" height="15px"></td>
							</tr>
						</table>--%>
					<div>
                       
                    </div>
                    
		</form>
	</body>
</html>

