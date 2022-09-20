<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoBookingdata.aspx.cs" Inherits="RoBooking_data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
    <script language="javascript" src="javascript/ROapproval.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <table style="width:auto;">
				<tr>
				<td>
                    <asp:datagrid id="DataGrid2" runat="server" CssClass="dtGrid" Width="538px"
														AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanged="DataGrid2_PageIndexChanged" OnItemDataBound="DataGrid2_ItemDataBound"  >
														<SelectedItemStyle BackColor="#046791" ></SelectedItemStyle>
														<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
														<Columns>
															<asp:BoundColumn DataField="Insert_Id" HeaderText="INSERT_ID">
																<ItemStyle HorizontalAlign="Left" BackColor="White" BorderColor="#7DAAE3"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="Premium" HeaderText="PREMIUM">
																<ItemStyle HorizontalAlign="Left" BackColor="White" BorderColor="#7DAAE3"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="NEGAMOUNT" HeaderText="NEGAMOUNT">
																<ItemStyle HorizontalAlign="Left" BackColor="White" BorderColor="#7DAAE3"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="Edition" HeaderText="EDITION">
																<ItemStyle HorizontalAlign="Left" BackColor="White" BorderColor="#7DAAE3"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="sizebookstatus" HeaderText="SIZEBOOK">
																<ItemStyle HorizontalAlign="Left" BackColor="White" BorderColor="#7DAAE3"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="Bill_Amt" HeaderText="BILL_AMT.">
																<ItemStyle HorizontalAlign="Left" BackColor="White" BorderColor="#7DAAE3"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="Insert_Date" HeaderText="INSERT_DATE">
																<ItemStyle HorizontalAlign="Left" BackColor="White" BorderColor="#7DAAE3"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="Card_Rate" HeaderText="CARDRETE">
																<ItemStyle HorizontalAlign="Left" BackColor="White" BorderColor="#7DAAE3"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="NEGRATE" HeaderText="NEGRATE">
																<ItemStyle HorizontalAlign="Left" BackColor="White" BorderColor="#7DAAE3"></ItemStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn HeaderText="Accept Data">
                                                                <ItemTemplate>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="Reject Data">
                                                                <ItemTemplate>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
														</Columns>
														<FooterStyle HorizontalAlign="Center" Height="20px" Font-Bold="True" />
                        <PagerStyle NextPageText="Next" PrevPageText="Prev" Font-Bold="True" BackColor="#7DAAE3" />
													</asp:datagrid>
				</td>
				</tr>
				
			</table>
			<input type="hidden" runat="server" id="bkid" />
    </form>
</body>
</html>
