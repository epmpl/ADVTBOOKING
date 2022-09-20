<%@ Page Language="C#" AutoEventWireup="true" CodeFile="fontleading.aspx.cs" Inherits="fontleading" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Font Leading </title>
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
<script type="text/javascript" language="javascript" src="javascript/fontleading.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    
    <table style="margin-left:400px;font-family:Verdana;font-size:20px">
    <tr>
    <td><b>Font Leading</b>
    </td>
    
    </tr>
    
    
    
    </table>
    
    
    
    <div>
    
    <asp:datagrid    id="DataGrid1" runat="server" CssClass="dtGrid" 
                                        AllowSorting="True" AutoGenerateColumns="False" 
											Width="592px" onitemdatabound="DataGrid1_ItemDataBound" >
											<SelectedItemStyle BackColor="#046791"></SelectedItemStyle>
											<HeaderStyle HorizontalAlign="Center" Height="20px" 
                                                CssClass="dtGridHd" BackColor="#7DAAE3" Font-Bold="True" ForeColor="White"></HeaderStyle>
											<Columns>
											
												
												<asp:BoundColumn DataField="LANGNAME" SortExpression="LANGNAME" HeaderText="LANGNAME">
												<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												
													<asp:BoundColumn DataField="FONTSIZE" SortExpression="FONTSIZE" HeaderText="FONTSIZE">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												
												
											
												
														<asp:BoundColumn DataField="FONTLEADING" SortExpression="FONTLEADING" HeaderText="FONTLEADING">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												
												
												
														<asp:BoundColumn DataField="LANGCODE" SortExpression="LANGCODE" HeaderText="LANGCODE"  Visible="true">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												
												
												<asp:BoundColumn DataField="FONTNAME" SortExpression="FONTNAME" HeaderText="FONTNAME"  Visible="true">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
									
											    
											    
											       
											<%--    <asp:TemplateColumn HeaderText="EXECUTIVE">
												<ItemTemplate>
													</ItemTemplate>
												</asp:TemplateColumn>
											    --%>
											    
											    <asp:TemplateColumn HeaderText="Update"  Visible="false">
												<ItemTemplate >
													</ItemTemplate>
												</asp:TemplateColumn>
												
												
												
												
												
												
												
											    
									    
												
												
													
									
											</Columns>
										</asp:datagrid>
    
    
    </div>
    
    
    
    <div>
    <asp:datagrid    id="DataGrid2" runat="server" CssClass="dtGrid" 
                                        AllowSorting="True" AutoGenerateColumns="False" 
											Width="592px" onitemdatabound="DataGrid1_ItemDataBound" >
											<SelectedItemStyle BackColor="#046791"></SelectedItemStyle>
											<HeaderStyle HorizontalAlign="Center" Height="20px" 
                                                CssClass="dtGridHd" BackColor="#7DAAE3" Font-Bold="True" ForeColor="White"></HeaderStyle>
											<Columns>
											
												
												<asp:BoundColumn DataField="LANGNAME" SortExpression="LANGNAME" HeaderText="LANGNAME">
												<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												
													<asp:BoundColumn DataField="FONTSIZE" SortExpression="FONTSIZE" HeaderText="FONTSIZE">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												
												
											
												
														<asp:BoundColumn DataField="FONTLEADING" SortExpression="FONTLEADING" HeaderText="FONTLEADING">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												
												
												
														<asp:BoundColumn DataField="LANGCODE" SortExpression="LANGCODE" HeaderText="LANGCODE"  Visible="true">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
										
											    <asp:BoundColumn DataField="FONTNAME" SortExpression="FONTNAME" HeaderText="FONTNAME"  Visible="true">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
											    
											       
										   <asp:TemplateColumn HeaderText="EXECUTIVE">
												<ItemTemplate>
													</ItemTemplate>
												</asp:TemplateColumn>
											
											
												
												
												
												
												
												
											    
									    
												
												
													
									
											</Columns>
										</asp:datagrid>
    
    
    
    </div>
    
    
    
    <table width="600px">
    <tr>
    <td align="center">
    
    <asp:Button runat="server" ID="btnsubmit" Text="Submit" />
    </td>
    
    
    </tr>
    
    </table>
    
    
      <input id="hiddendateformat" type="hidden" name="hiddendateformat" runat="server"/>
    <input id="hiddencompcode" type="hidden" size="1" name="hiddencomcode" runat="server"/>
   <input id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server"/>
     <input id="Hiddenclientcode" type="hidden" name="hidattach1" runat="server" />
     <input id="Hiddenagencycode" type="hidden" name="hidattach1" runat="server" />
     <input id="hdnglobalid" type="hidden" name="hdnglobalid" runat="server" />
      <input id="hdnexecutive" type="hidden" name="hdnglobalid" runat="server" />
      <input id="hdnclientcode" type="hidden" name="hdnclientcode" runat="server" />
    <input id="hdncode" type="hidden" name="hdncode" runat="server" />
    <input id="hdncodesubcode" type="hidden" name="hdncodesubcode" runat="server" />
    <input id="hiddenedition" type="hidden" name="hiddenedition" runat="server" />
    
    
    
    </form>
</body>
</html>
