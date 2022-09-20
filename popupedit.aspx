<%@ Page Language="C#" AutoEventWireup="true" CodeFile="popupedit.aspx.cs" Inherits="popupedit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Edition Issue Date</title>
   	<script type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>
	<script type="text/javascript" language="javascript" src="javascript/datevalidation.js"></script>
	<script type="text/javascript" language="javascript" src="javascript/EditorMaster.js"></script>
	<script type="text/javascript" language="javascript">
function dateenter(event)
{
var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer")
 {
    if((event.which>=47 && event.which<=57))
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
     if((event.keyCode>=47 && event.keyCode<=57))
    {
    return true;
    }
    else
    {
    return false;
    }
 }   
}	
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
			<table id="Table4" borderColor="#000000" cellspacing="0" align="center" cellpadding="0" width="639" border="1" ms_2d_layout="TRUE">
				<tr>
					<td>
						<table id="Table2"  cellspacing="0" cellpadding="0" width="633"
							align="center" bgColor="#7daae3" border="0" >
							<tr>
								<td class="btnlink" align="center">Edition Issue Date</td>
							</tr>
						</table>
						<table id="Table1" align="center" style="WIDTH: 600px; HEIGHT: 216px; "  cellspacing="0" cellpadding="0"
							width="562"  border="0">
							
							<tr>
								<td style="width: 601px">
									<table id="Table5" width="600px" cellspacing="0" cellpadding="0"
										align="center" border="0">
                                        <tr height="10px">
                                            <td>
                                            </td>
                                            <td colspan="4">
                                                </td>
                                            <td>
                                            </td>
                                        </tr>
										
										<tr>
											<td><asp:Label id="lbeditionname" runat="server" CssClass="TextField"></asp:Label></td>
											<td colspan="4"><asp:textbox id="txteditionname" runat="server" ReadOnly="True"  CssClass="btext"
													MaxLength="50"></asp:textbox></td>
                                            <td colspan="1">
                                            </td>
											</tr>
										<tr>
											<td><asp:Label id="lbdate" runat="server" CssClass="TextField"></asp:Label></td>
											<td align="left"><asp:DropDownList  id="txtdate" runat="server" CssClass="dropdown" >
											<asp:ListItem Selected="True" Value="0">First Cycle</asp:ListItem>
                                        <asp:ListItem  Value="01">01</asp:ListItem>
                                        <asp:ListItem  Value="02">02</asp:ListItem>
                                        <asp:ListItem  Value="03">03</asp:ListItem>
                                        <asp:ListItem  Value="04">04</asp:ListItem>
                                        <asp:ListItem  Value="05">05</asp:ListItem>
                                        <asp:ListItem  Value="06">06</asp:ListItem>
                                        <asp:ListItem  Value="07">07</asp:ListItem>
                                        <asp:ListItem  Value="08">08</asp:ListItem>
                                        <asp:ListItem  Value="09">09</asp:ListItem>
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
                                        <asp:ListItem  Value="31">31</asp:ListItem>
                                       </asp:DropDownList>
											</td>
											<%--<td><asp:textbox onkeypress="return datecurr(event);"  id="txtdate" runat="server" CssClass="btext1" MaxLength="10"></asp:textbox>
												<img src='Images/cal1.gif' id="div123"  onclick='popUpCalendar(this, Form1.txtdate, "mm/dd/yyyy")' onfocus=abc();  height=14 width=14> --%>
												
										
											<td><asp:Label id="lbaddate" runat="server" CssClass="TextField"></asp:Label></td>
											<td align="center"><asp:DropDownList  id="txtaddate" runat="server" CssClass="dropdown" >
											<asp:ListItem Selected="True" Value="0">Second Cycle</asp:ListItem>
											<asp:ListItem  Value="01">1</asp:ListItem>
                                        <asp:ListItem  Value="02">02</asp:ListItem>
                                        <asp:ListItem  Value="03">03</asp:ListItem>
                                        <asp:ListItem  Value="04">04</asp:ListItem>
                                        <asp:ListItem  Value="05">05</asp:ListItem>
                                        <asp:ListItem  Value="06">06</asp:ListItem>
                                        <asp:ListItem  Value="07">07</asp:ListItem>
                                        <asp:ListItem  Value="08">08</asp:ListItem>
                                        <asp:ListItem  Value="09">09</asp:ListItem>
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
                                        <asp:ListItem  Value="31">31</asp:ListItem>
											</asp:DropDownList>                                            
												
                                            </td>
											<%--<td align="right"><asp:textbox onkeypress="return datecurr(event);"  id="txtaddate" runat="server" CssClass="btext1" MaxLength="10"></asp:textbox>                                            
												<img src='Images/cal1.gif' id="div456" onclick='popUpCalendar(this, Form1.txtaddate, "mm/dd/yyyy")'  onfocus=abc();  height=14 width=14>
                                                &nbsp;
                                            </td>--%>
                                            
                                            
                                            
                                            <tr>
                                            	<td><asp:Label id="lblyear" runat="server" CssClass="TextField"></asp:Label></td>
											<td><asp:DropDownList  id="drpyear" runat="server" CssClass="dropdown" ></asp:DropDownList></td>
                                            
										</tr>
										<tr>
										<td colspan="5" style="height: 19px"></td>
                                            <td colspan="1" style="height: 19px" >
                                            </td>
										</tr>
										<tr>
											<td></td>
											<td colspan="4" align="right" style="height: 24px"><asp:button id="btnsubmit" runat="server" CssClass="button1" OnClick="btnsubmit_Click1" >
											</asp:button><asp:Button ID="btnclear" runat="server" CssClass="button1" />&nbsp;&nbsp;&nbsp;
                                                &nbsp; &nbsp;</td>
                                            <td align="right" colspan="1" >
                                            </td>
                                               
										</tr>
										<tr height="20px"><td></td></tr>			
													
													
													
											</table>
									<div id="divgrid1" runat="server" style="OVERFLOW: auto; WIDTH: 600px; HEIGHT: 125px">
										<table id="Table3" align="left">
											<tr>
											<td align="left" >
												<asp:datagrid id="DataGrid1" runat="server" CssClass="dtGrid" Width="570px" AutoGenerateColumns="False">
													<SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
													<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
																					<Columns>
															<asp:TemplateColumn>
														     <ItemStyle HorizontalAlign="Center"></ItemStyle>
													        </asp:TemplateColumn>
													        <asp:BoundColumn Visible="False" DataField="editdate_code" ReadOnly="True" HeaderText="editdate_code" >
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
															</asp:BoundColumn>
															
															<asp:BoundColumn DataField="Edition_Alias" HeaderText="Edition Name " SortExpression="Edition_Alias">
																						<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
																					</asp:BoundColumn>
																					<asp:BoundColumn DataField="Date_Edition" HeaderText="First Cycle" SortExpression="Date_Edition">
																						<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                                            Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
																					</asp:BoundColumn>
																					<asp:BoundColumn DataField="AdditionalDate_Edit" HeaderText="Second Cycle" SortExpression="AdditionalDate_Edit">
																						<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                                            Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
																					</asp:BoundColumn>
																					
																					
																						<asp:BoundColumn DataField="Year" HeaderText="Year" SortExpression="Year">
																						<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                                            Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
																					</asp:BoundColumn>
																					
																					
																					
																					
																					
																					
                                                          							
													        
																</Columns>
													</asp:datagrid>
													</td>
											</tr>
											<tr align="right">
												<td align="right" style="width: 579px">
                                                    </td>
                                                    
											</tr>
										</table>
									</div>
									<table>
									<tr><td><input type="hidden" size="12" name="hiddencomcode" runat="server" id="hiddencompcode"/>
													<input id="hiddenuserid" type="hidden" name="hiddenuserid" runat="server"/> 
													<input id="hiddeneditcode" type="hidden" name="hiddeneditcode" runat="server"/>
													<input id="hiddenperiodicity" type="hidden" name="hiddenperiodicity" runat="server"/>
													<input id="hiddendateformat" type="hidden" size="1" name="hiddenagensubcode" runat="server"/>
													<input id="hiddenshow" type="hidden" size="1" name="hiddenshow" runat="server"/>
													<input id="htext" type="hidden" size="1" name="htext" runat="server"/>
												
													</td></tr>
									</table>
									<div id="divgrid2" runat="server" style="OVERFLOW: auto; WIDTH: 600px; HEIGHT: 125px">
										<table id="Table7" align="left">
											<tr>
											<td align="left" >
												<asp:datagrid id="DataGrid2" runat="server" CssClass="dtGrid" Width="570px" AutoGenerateColumns="False" OnSelectedIndexChanged="DataGrid2_SelectedIndexChanged">
													<SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
													<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
																					<Columns>
													        <asp:BoundColumn Visible="False" DataField="editdate_code" ReadOnly="True" HeaderText="editdate_code" >
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
															</asp:BoundColumn>
															
															<asp:BoundColumn DataField="Edition_Alias" HeaderText="Edition Name " SortExpression="Edition_Alias">
																						<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
																					</asp:BoundColumn>
																					<asp:BoundColumn DataField="Date_Edition" HeaderText="First Cycle" SortExpression="Date_Edition">
																						<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                                            Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
																					</asp:BoundColumn>
																					<asp:BoundColumn DataField="AdditionalDate_Edit" HeaderText="Second Cycle" SortExpression="AdditionalDate_Edit">
																						<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                                            Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
																					</asp:BoundColumn>
																					
																					
																				<asp:BoundColumn DataField="Year" HeaderText="Year" SortExpression="Year">
																						<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                                            Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
																					</asp:BoundColumn>
	
																					
																					
                                                          							
													        
																</Columns>
													</asp:datagrid>
														</td>
											</tr>
											<tr align="right">
												<td align="right" style="width: 579px">
                                                    </td>
                                                    
											</tr>
										</table>
									</div>
									</tr>
									<tr><td align="right" style="width: 601px">
                                                    <asp:Button ID="btnclose" runat="server" CssClass="button1" OnClick="btnclose_Click" /><asp:Button ID="btndelete" runat="server" CssClass="button1" />
                                        &nbsp;&nbsp; &nbsp; &nbsp;
                                    </td>
							</tr>
							<tr>
								<td align="center" height="20px" style="width: 601px"></td>
							</tr>
						</table>
                        <table id="Table6" style="WIDTH: 634px; HEIGHT: 19px" cellspacing="0" cellpadding="0" width="634"
							align="center" bgcolor="#7daae3" border="0">
							<tr>
								<td align="center"></td>
							</tr>
						</table>
   
       </td>
       </tr>
       </table>
        
        
					
					
		</form>
</body>
</html>
