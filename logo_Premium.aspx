<%@ Page Language="C#" AutoEventWireup="true" CodeFile="logo_Premium.aspx.cs" Inherits="logo_Premium" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title>Logo Premium Child</title>
    
     <script language="javascript" src="javascript/logo_premium.js" type="text/javascript"></script>
      <script language="javascript" src="javascript/logopremmast.js" type="text/javascript"></script>
       <script language="javascript" type="text/javascript" src="javascript/popupcalender.js"></script>
       <script language="javascript" type="text/javascript" src="javascript/datevalidation.js"></script>
    <LINK href="css/main.css" type="text/css" rel="stylesheet" />
    
</head>


<body>
    <form id="form1" runat="server">
    <div>
     <table style="margin-left:140px;" id="Table3" align="center" bgcolor="#7daae3" border="0" cellpadding="0" cellspacing="0"
                                width="593">
                                <tr>
                                    <%--<td align="center" class="btnlink">Edition wise logo Premium Rate
                                        </td>--%>
                                </tr>
                            </table>
    <table style ="margin-left:100px;">
    <tr>
                                   <tr>
                                    <td align="center" class="btnlink">
                                        </td>
                                </tr>
                                        
                                </tr>
    <tr>
                                  
    							 <td><asp:Label ID="edition" runat="server" CssClass="TextField"></asp:Label></td>
    							 
							  <td><asp:DropDownList ID="DropDownList1" runat="server" CssClass="btext1" 
                                     
                                      >
                                      
							
							  </asp:DropDownList>
							 </td>
							
    </tr>
    
    
    
    
    
    
        <tr>
                                  
    							 <td><asp:label id="lblfromdate" runat="server" Text="From Date" CssClass="TextField">From Date<font color="red">*</asp:label></td>
    							 
							  <td><asp:textbox         MaxLength="10" id="txtfrom" runat="server" CssClass="btext1"     onpaste="return false;"></asp:textbox>
													<SCRIPT language="javascript">
													    if (!document.layers) {
													        document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtfrom, \"mm/dd/yyyy\")' height=14  width=14>")
													    }
													</SCRIPT></td>
													
													<td><asp:label id="Label2" runat="server" Text="To Date" CssClass="TextField">To Date<font color="red">*</asp:label></td>
													
													<td>
													
													<asp:textbox        MaxLength="10" id="txtto" runat="server" CssClass="btext1"     onpaste="return false;"></asp:textbox>
													<SCRIPT language="javascript">
													    if (!document.layers) {
													        document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtto, \"mm/dd/yyyy\")' height=14  width=14>")
													    }
													</SCRIPT>
													
													
													</td>
							
    </tr>
    
    
    
    
    
    <tr>
    
							 <td><asp:Label ID="premium" runat="server" CssClass="TextField"></asp:Label></td>
							  <td><asp:DropDownList ID="drpremium" runat="server" CssClass="btext1"  >
							  <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
							  <asp:ListItem Value="fix" Text="Fixed"></asp:ListItem>
							    <asp:ListItem Value="per" Text="Percenteage"></asp:ListItem>
							  </asp:DropDownList>
							  
							 <td><asp:Label ID="Label1" runat="server" CssClass="TextField"></asp:Label></td>
							  <td>
							  
							 <asp:TextBox ID="txtamount" runat="server" CssClass="btext1" MaxLength="6" onkeypress="javascript:return isnumKey(event)"></asp:TextBox></td>
							
							   
						
							 </tr>
							 <td align="right">
                                                    <asp:Button ID="btnSubmit" 
                runat="server" CssClass="button1" 
                                                        Height="24px" 
                onclick="btnSubmit_Click1" />
                                                        
                                                      
                                                </td></table>
							 <div id="Divgrid1" style="OVERFLOW:auto" runat="server">
							 <table id="Table2" align="center">
								<tr>
								<td align="center">
									
									<asp:datagrid    id="DataGrid1" runat="server" CssClass="dtGrid" 
                                        AllowSorting="True" AutoGenerateColumns="False" 
											Width="592px" onitemdatabound="DataGrid1_ItemDataBound" >
											<SelectedItemStyle BackColor="#046791"></SelectedItemStyle>
											<HeaderStyle HorizontalAlign="Center" Height="20px" 
                                                CssClass="dtGridHd" BackColor="#7DAAE3" Font-Bold="True" ForeColor="White"></HeaderStyle>
											<Columns>
												<asp:TemplateColumn>
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
											<asp:CheckBox ID="CheckBox1" CssClass="textfield1" Runat="server" />
										</ItemTemplate>
												</asp:TemplateColumn>
												
												<asp:BoundColumn DataField="EDITION" SortExpression="EDITION" HeaderText="EDITION">
												<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="PREMIUM" SortExpression="PREMIUM" HeaderText="PREMIUM">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="AMOUNT" SortExpression="AMOUNT" HeaderText="AMOUNT">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												
												
												<asp:BoundColumn DataField="VALIDFROM" SortExpression="VALIDFROM" HeaderText="VALIDFROM">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												
												
												
												<asp:BoundColumn DataField="VALIDTO" SortExpression="VALIDTO" HeaderText="VALIDTO">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												
												<asp:BoundColumn Visible ="false"  DataField="LOGOPREMIUMDETCODE" SortExpression="LOGOPREMIUMDETCODE" HeaderText="LOGOPREMIUMDETCODE">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
													
									
											</Columns>
										</asp:datagrid>
										</td>
				                  		</tr>
				                		</table>
				                		</div>
									<div id="Divgrid2" style="OVERFLOW: auto" runat="server">
								<table id="Table5" align="center">
								<tr>
								<td align="center">
									
									<asp:datagrid id="DataGrid2" runat="server" CssClass="dtGrid" AllowSorting="True" AutoGenerateColumns="False" 
											Width="592px">
											<SelectedItemStyle BackColor="#046791"></SelectedItemStyle>
											<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd" BackColor="#7DAAE3"></HeaderStyle>
											<Columns>
												
												<asp:BoundColumn DataField="EDITION" SortExpression="EDITION" HeaderText="EDITION" >
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="PREMIUM" SortExpression="PREMIUM" HeaderText="PREMIUM">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="AMOUNT" SortExpression="AMOUNT" HeaderText="AMOUNT">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												
												
												
													
													<asp:BoundColumn DataField="VALIDFROM" SortExpression="VALIDFROM" HeaderText="VALIDFROM">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												
												
													<asp:BoundColumn DataField="VALIDTO" SortExpression="VALIDTO" HeaderText="VALIDTO">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
													<asp:BoundColumn Visible="false" DataField="LOGOPREMIUMDETCODE" SortExpression="LOGOPREMIUMDETCODE" HeaderText="LOGOPREMIUMDETCODE">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												
												
												
											</Columns>
											<PagerStyle HorizontalAlign="Center"></PagerStyle>
										</asp:datagrid>
										</td>
				                  		</tr>
				                  		</table>
							 
							 
						
    
    </div>
    
    <table  style="margin-left:100px;" width="80%">
    <td align="right"><asp:button id="btnclose" text="Close" runat="server" CssClass="button1"></asp:button><asp:button id="btndelete" text="Delete" runat="server" CssClass="button1" ></asp:button></td>
    
    </table>
    <input id="hiddencompcode" type="hidden" name="hiddencompcode" runat="server" />
     <input id="hdnmodify" type="hidden" name="hiddenuserid" runat="server" />
      <input id="hiddenuserid" type="hidden" name="hiddenuserid" runat="server" />
      <input id="hdnlogo" type="hidden" name="hdnlogo" runat="server" />
       <input id="hdnsequenceno" type="hidden" name="hdnlogo" runat="server" />
         <INPUT id="hiddendateformat" type="hidden" name="hiddendateformat" runat="server" />
         <input id="hiddenfdate" type="hidden" name="hdnlogo" runat="server" />
           <input id="hiddentdate" type="hidden" name="hdnlogo" runat="server" />
           
           
      
    </form>
</body>
</html>
