<%@ Page Language="C#" AutoEventWireup="true" CodeFile="popupsupplement.aspx.cs" Inherits="popupsupplement" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Supplement Issue Date</title>
    <script type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>
	<script type="text/javascript" language="javascript" src="javascript/datevalidation.js"></script>
	<script type="text/javascript" language="javascript" src="javascript/SupplimentMaster.js"></script>
	<script type="text/javascript" language="javascript">
	function datecurr(event)
{
var browser=navigator.appName;
if(browser!="Microsoft Internet Explorer")
 {
  if ((event.which>=48 && event.which<=57)||(event.which==47)||(event.which==11) ||(event.which==8))
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
   if ((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==47)||(event.keyCode==11))
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
	<link href="css/main.css" type="text/css" rel="stylesheet"/>

</head>
<body>
      <form id="Form1" method="post" runat="server">
			<table id="Table4" borderColor="#000000" cellspacing="0" cellpadding="0" width="639" border="1" ms_2d_layout="TRUE">
				<tr>
					<td>
						<table id="Table2"  cellspacing="0" cellpadding="0" width="633"
							align="center" bgColor="#7daae3" border="0" >
							<tr>
								<td class="btnlink" align="center">Supplement Issue Date</td>
							</tr>
						</table>
						<table id="Table1" align="center" style="WIDTH: 600px; HEIGHT: 216px; "  cellspacing="0" cellpadding="0"
							width="562"  border="0">
							<tr>
							</tr>
							<tr>
									<td style="width: 601px">
									<table id="Table5"  cellspacing="0" cellpadding="0"
										align="center" width="600px" border="0">
										  <tr height="10px">
                                            <td>
                                            </td>
                                            <td colspan="4">
                                                </td>
                                            <td>
                                            </td>
                                        </tr>
										<tr>
											<td><asp:Label id="lbsupplementname" runat="server" CssClass="TextField"></asp:Label></td>
											<td colspan="4"><asp:textbox id="txteditionname" ReadOnly="True"  runat="server" CssClass="btext"
													MaxLength="50"></asp:textbox></td>
										      <td colspan="1">
                                            </td>
										
											</tr>
										<tr>
											<td ><asp:Label id="lbdate" runat="server" CssClass="TextField"></asp:Label></td>
											<%--<asp:DropDownList id="txtdate" runat="server" CssClass="dropdown" >
											<asp:ListItem Selected="True" Value="0">First Cycle</asp:ListItem>
											<asp:ListItem  Value="1">1</asp:ListItem>
                                        <asp:ListItem  Value="2">2</asp:ListItem>
                                        <asp:ListItem  Value="3">3</asp:ListItem>
                                        <asp:ListItem  Value="4">4</asp:ListItem>
                                        <asp:ListItem  Value="5">5</asp:ListItem>
                                        <asp:ListItem  Value="6">6</asp:ListItem>
                                        <asp:ListItem  Value="7">7</asp:ListItem>
                                        <asp:ListItem  Value="8">8</asp:ListItem>
                                        <asp:ListItem  Value="9">9</asp:ListItem>
                                        <asp:ListItem  Value="10">10</asp:ListItem>
                                        <asp:ListItem  Value="11">11</asp:ListItem>
                                        <asp:ListItem  Value="12">12</asp:ListItem>
                                        <asp:ListItem  Value="13">13</asp:ListItem>
                                        <asp:ListItem  Value="14">14</asp:ListItem>
                                        <asp:ListItem  Value="15">15</asp:ListItem>
                                        <asp:ListItem  Value="16">16</asp:ListItem>
                                        <asp:ListItem  Value="17">17</asp:ListItem>
                                        <asp:ListItem  Value="18">18</asp:ListItem>
                                        <asp:ListItem  Value="19">19</asp:ListItem>
                                        <asp:ListItem  Value="20">20</asp:ListItem>
                                        <asp:ListItem  Value="21">21</asp:ListItem>
                                        <asp:ListItem  Value="22">22</asp:ListItem>
                                        <asp:ListItem  Value="23">23</asp:ListItem>
                                        <asp:ListItem  Value="24">24</asp:ListItem>
                                        <asp:ListItem  Value="25">25</asp:ListItem>
                                        <asp:ListItem  Value="26">26</asp:ListItem>
                                        <asp:ListItem  Value="27">27</asp:ListItem>
                                        <asp:ListItem  Value="28">28</asp:ListItem>
                                        <asp:ListItem  Value="29">29</asp:ListItem>
                                        <asp:ListItem  Value="30">30</asp:ListItem>
                                        <asp:ListItem  Value="31">31</asp:ListItem></asp:DropDownList>--%>
											<td ><asp:textbox onkeypress="return datecurr(event);" MaxLength="10" id="txtdate" runat="server" CssClass="btext1" onpaste="return false;" ></asp:textbox>
												<img src='Images/cal1.gif' id="div123"  onclick='popUpCalendar(this, Form1.txtdate, "mm/dd/yyyy")' onfocus=abc();  height=14 width=14> 
												</td>
										
											<td><asp:Label id="lbaddate" runat="server" CssClass="TextField"></asp:Label></td>
											<%--<td align="center"><asp:DropDownList  id="txtaddate" runat="server" CssClass="dropdown">
											<asp:ListItem Selected="True" Value="0">Second Cycle</asp:ListItem>
											<asp:ListItem  Value="1">1</asp:ListItem>
                                        <asp:ListItem  Value="2">2</asp:ListItem>
                                        <asp:ListItem  Value="3">3</asp:ListItem>
                                        <asp:ListItem  Value="4">4</asp:ListItem>
                                        <asp:ListItem  Value="5">5</asp:ListItem>
                                        <asp:ListItem  Value="6">6</asp:ListItem>
                                        <asp:ListItem  Value="7">7</asp:ListItem>
                                        <asp:ListItem  Value="8">8</asp:ListItem>
                                        <asp:ListItem  Value="9">9</asp:ListItem>
                                        <asp:ListItem  Value="10">10</asp:ListItem>
                                        <asp:ListItem  Value="11">11</asp:ListItem>
                                        <asp:ListItem  Value="12">12</asp:ListItem>
                                        <asp:ListItem  Value="13">13</asp:ListItem>
                                        <asp:ListItem  Value="14">14</asp:ListItem>
                                        <asp:ListItem  Value="15">15</asp:ListItem>
                                        <asp:ListItem  Value="16">16</asp:ListItem>
                                        <asp:ListItem  Value="17">17</asp:ListItem>
                                        <asp:ListItem  Value="18">18</asp:ListItem>
                                        <asp:ListItem  Value="19">19</asp:ListItem>
                                        <asp:ListItem  Value="20">20</asp:ListItem>
                                        <asp:ListItem  Value="21">21</asp:ListItem>
                                        <asp:ListItem  Value="22">22</asp:ListItem>
                                        <asp:ListItem  Value="23">23</asp:ListItem>
                                        <asp:ListItem  Value="24">24</asp:ListItem>
                                        <asp:ListItem  Value="25">25</asp:ListItem>
                                        <asp:ListItem  Value="26">26</asp:ListItem>
                                        <asp:ListItem  Value="27">27</asp:ListItem>
                                        <asp:ListItem  Value="28">28</asp:ListItem>
                                        <asp:ListItem  Value="29">29</asp:ListItem>
                                        <asp:ListItem  Value="30">30</asp:ListItem>
                                        <asp:ListItem  Value="31">31</asp:ListItem></asp:DropDownList>--%>
                                        <td><asp:textbox onkeypress="return datecurr(event);" MaxLength="10" id="txtaddate" runat="server" CssClass="btext1" onpaste="return false;" ></asp:textbox>
												<img src='Images/cal1.gif' id="div456" onclick='popUpCalendar(this, Form1.txtaddate, "mm/dd/yyyy")'  onfocus=abc();  height=14 width=14>&nbsp;
                                                &nbsp;</td>
												<%--<img src='Images/cal1.gif' id="div456" onclick='popUpCalendar(this, Form1.txtaddate, "mm/dd/yyyy")'  onfocus=abc();  height=14 width=14>&nbsp;
                                                &nbsp;--%>
										</tr>
										<tr>
										<td colspan="5" style="height: 19px"></td>
                                            <td colspan="1" style="height: 19px" >
                                            </td>
										</tr>
										<tr>
											<td></td>
											<td colspan="4" align="right" style="height: 24px"><asp:button id="btnsubmit" runat="server" CssClass="button1" OnClick="btnsubmit_Click" >
											</asp:button><asp:Button ID="btnclear" runat="server" CssClass="button1" />&nbsp;&nbsp;&nbsp;
                                                &nbsp; &nbsp;</td>
                                            <td align="right" colspan="1" >
                                            </td>
                                               
										</tr>
													
											</table>
									<div id="divgrid1" runat="server" style="OVERFLOW: auto; WIDTH: 600px; HEIGHT: 125px">
									<table id="Table3"  align="left">
											<tr>
											<td align="left">
												<asp:datagrid id="DataGrid1" runat="server" CssClass="dtGrid" Width="570px" AutoGenerateColumns="False">
													<SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
													<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
																					<Columns>
															<asp:TemplateColumn>
														     <ItemStyle HorizontalAlign="Center"></ItemStyle>
													        </asp:TemplateColumn>
													        <asp:BoundColumn Visible="False" DataField="suppdate_code" ReadOnly="True" HeaderText="suppdate_code" >
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
															</asp:BoundColumn>
															
															<asp:BoundColumn DataField="Supp_Alias" HeaderText="Supplement Name" SortExpression="Supp_Alias">
																						<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
																					</asp:BoundColumn>
																					<asp:BoundColumn DataField="Date_Supplement" HeaderText="Date" SortExpression="Date_Supplement">
																						<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                                            Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
																					</asp:BoundColumn>
																					<asp:BoundColumn DataField="AdditionalDate_Supp" HeaderText="Additional Date" SortExpression="AdditionalDate_Supp">
																						<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                                            Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
																					</asp:BoundColumn>
                                                          							
													        
																</Columns>
													</asp:datagrid>
													</td>
											</tr>
									</table>
									</div>
									<table><tr><td><input type="hidden" size="12" name="hiddencomcode" runat="server" id="hiddencompcode"/>
													<input id="hiddenuserid" type="hidden" name="hiddenuserid" runat="server"/> 
													<input id="hiddensuppcode" type="hidden" name="hiddensuppcode" runat="server" />
													<input id="hiddenperiodicity" type="hidden" size="1" name="hiddenperiodicity" runat="server"/>
													<input id="hiddendateformat" type="hidden" size="1" name="hiddenagensubcode" runat="server"/>
														<input id="hiddenshow" type="hidden" size="1" name="hiddenshow" runat="server"/>
												<input id="hiddenfdate" type="hidden" name="hiddeneditdate" runat="server" />
	                                           <input id="hiddentaddate" type="hidden" name="hiddeneditaddate" runat="server" />
													</td></tr></table>
									<div id="divgrid21" runat="server" style="OVERFLOW: auto; WIDTH: 600px; HEIGHT: 125px">
									<table id="Table7"  align="left">
											<tr>
											<td align="left">
												<asp:datagrid id="DataGrid2" runat="server" CssClass="dtGrid" Width="570px" AutoGenerateColumns="False">
													<SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
													<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
																					<Columns>
													        <asp:BoundColumn Visible="False" DataField="suppdate_code" ReadOnly="True" HeaderText="suppdate_code" >
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
															</asp:BoundColumn>
															
															<asp:BoundColumn DataField="Supp_Alias" HeaderText="Supplement Name" SortExpression="Supp_Alias">
																						<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
																					</asp:BoundColumn>
																					<asp:BoundColumn DataField="Date_Supplement" HeaderText="Date" SortExpression="Date_Supplement">
																						<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                                            Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
																					</asp:BoundColumn>
																					<asp:BoundColumn DataField="AdditionalDate_Supp" HeaderText="Additional Date" SortExpression="AdditionalDate_Supp">
																						<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                                            Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
																					</asp:BoundColumn>
                           		        
																</Columns>
													</asp:datagrid>
													</td>
											</tr>
										</table>
									</div>
									<tr align="right">
												<td align="right" colspan=2>
                                                    <asp:Button ID="btnclose" runat="server" CssClass="button1" OnClick="btnclose_Click"  /><asp:Button ID="btndelete" runat="server" CssClass="button1" /></td>
                                      </tr>
								</td>
							</tr>
						</table>
						<table id="Table6" style="WIDTH: 634px; HEIGHT: 19px" cellspacing="0" cellpadding="0" width="634"
							align="center" bgcolor="#7daae3" border="0">
							<tr>
								<td align="center"></td>
							</tr>
						</table>
					<div></div>
					</td>
				</tr>
			</table>
		</form>
    </body>
</html>
