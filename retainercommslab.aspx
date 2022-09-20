<%@ Page Language="C#" AutoEventWireup="true" CodeFile="retainercommslab.aspx.cs" Inherits="retainercommslab" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Retainer Comm. Slab Detail</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
		<meta content="C#" name="CODE_LANGUAGE" />
		<meta content="JavaScript" name="vs_defaultClientScript" />
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
		<script language="javascript" type="text/javascript" src="javascript/RetainerMaster.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/Validations.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/popupcalender.js"></script>
		<script language="javascript" type="text/javascript"src="javascript/entertotab.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/datevalidation.js"></script>
		<LINK href="css/main.css" type="text/css" rel="stylesheet" />
		<script language="javascript" type="text/javascript">
		function notchar2(event)
    {
      var browser=navigator.appName;

   if(browser!="Microsoft Internet Explorer")
    { 
            if((event.which>=48 && event.which<=57)||(event.which==127)||(event.which==8)||(event.which==9))
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
           if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9))
            {
            return true;
            }
            else
            {
            return false;
            }
      }
      
     }
     
     function notchar3(event)
    {
      var browser=navigator.appName;

   if(browser!="Microsoft Internet Explorer")
    { 
            if((event.which>=46 && event.which<=57)||(event.which==127)||(event.which==8)||(event.which==9))
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
           if((event.keyCode>=46 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9))
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
<body onload ="loadXML('xml/errorMessage.xml')" onkeydown="javascript:return tabvalue(event);">
		<form id="Form1" method="post" runat="server">
			<table id="Table4" bordercolor="#000000" cellspacing="0"  cellpadding="0" width="632" align="center"
				border="1">
				<TBODY>
					<TR vAlign="middle">
						<TD style="width: 636px">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="633" align="center" bgColor="#7daae3"
								border="0">
								<TR>
									<TD class="btnlink" align="center">Retainer Comm. Slab</TD>
								</TR>
							</TABLE>
							<table id="table1">
								<tr>
									<td></td>
									<td></td>
									<td></td>
								</tr>
								<tr>
									<td></td>
									<td>
										<table style="WIDTH: 592px; HEIGHT: 80px">
											<tr>
												<td><asp:label id="lblfromdate" runat="server" CssClass="TextField"></asp:label></td>
												<td><asp:textbox id="txtfrom" runat="server" CssClass="btext1"  onkeypress="return notchar2(event);"    onpaste="return false;" MaxLength="10"></asp:textbox>
												</td>
												<td><asp:label id="lblstatus" runat="server" CssClass="TextField"></asp:label></td>
												<td><asp:dropdownlist id="drpcommon" runat="server" CssClass="dropdown">
														<asp:ListItem Value="0">--Select Comm. On--</asp:ListItem>
														<asp:ListItem Value="Gross">Gross</asp:ListItem>
														<asp:ListItem Value="Net">Net</asp:ListItem>
														</asp:dropdownlist></td>
											</tr>
											<tr>
												<td style="HEIGHT: 16px"><asp:label id="lbltodate" runat="server" CssClass="TextField"></asp:label></td>
												<td style="HEIGHT: 16px"><asp:textbox id="txtto" runat="server" CssClass="btext1" onpaste="return false;" onkeypress="return notchar2(event);" MaxLength="10" ></asp:textbox>
												</td>
												<td style="HEIGHT: 16px"><asp:label id="lblcircular" runat="server" CssClass="TextField"></asp:label></td>
												<td style="HEIGHT: 16px"><asp:textbox id="txtcommrate" runat="server" MaxLength="6" onkeypress="return notchar3(event);"
														CssClass="btext1" onpaste="return false;"></asp:textbox></td>
											</tr>
											<tr>
												<td style="HEIGHT: 16px"><asp:label id="lblagencytype" runat="server" 
                                                        CssClass="TextField"></asp:label></td>
												<td style="HEIGHT: 16px"><asp:DropDownList ID="drpagentyp" runat="server" CssClass="dropdown" Enabled="true" >
												<asp:ListItem Value="0">--Select--</asp:ListItem>
												
                            </asp:DropDownList>
												</td>
												<td style="HEIGHT: 16px">&nbsp;</td>
												<td style="HEIGHT: 16px">&nbsp;</td>
											</tr>
											<tr>
												<td></td>
												<td></td>
												<td></td>
												<td></td>
											</tr>
											<tr>
												<td></td>
												<td></td>
												<td></td>
												<td align="right"><asp:button id="btnSave" runat="server" CssClass="button1" OnClick="btnSubmit_Click" ></asp:button><asp:button id="btnclear" runat="server" CssClass="button1" ></asp:button></td>
											</tr>
										</table>
									</td>
									<td></td>
								</tr>
								<tr>
									<td></td>
									<td></td>
									<td></td>
									</tr>
									<div id="Divgrid1" style="OVERFLOW: auto" runat="server">
								<table id="Table2" align="center">
								<tr>
								<td align="center">
									
									<asp:datagrid id="DataGrid1" runat="server" CssClass="dtGrid" AllowSorting="false" AutoGenerateColumns="False" OnSortCommand="abc"
											Width="592px" OnItemDataBound="DataGrid1_ItemDataBound"  >
											<SelectedItemStyle BackColor="#046791"></SelectedItemStyle>
											<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd" BackColor="#7DAAE3"></HeaderStyle>
											<Columns>
												<asp:TemplateColumn>
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
											<asp:CheckBox ID="CheckBox1" CssClass="textfield1" Runat="server" />
										</ItemTemplate>
												</asp:TemplateColumn>
												
												<asp:BoundColumn  Visible="False" DataField="ENLN" ReadOnly="True" SortExpression="ENLN" HeaderText="Elno.">
												<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="FROM_DAYS" SortExpression="FROM_DAYS" HeaderText="From Days">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="TILL_DAYS" SortExpression="TILL_DAYS" HeaderText="Till Days">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn  DataField="COMM_ON"  HeaderText="COMM. ON">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="COMM_RATE" SortExpression="COMM_RATE" HeaderText="COMM. RATE">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
											
												<asp:BoundColumn DataField="COMM_TARGET_ID" Visible="false"  HeaderText="COMM_TARGET_ID">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												
													<asp:BoundColumn DataField="AGENCY_TYPE" Visible="true"  HeaderText="AGENCY_TYPE">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												
												
												<asp:TemplateColumn Visible="False" HeaderText="Update">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:TemplateColumn>
												<asp:TemplateColumn Visible="False" HeaderText="Delete">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:TemplateColumn>
												
											</Columns>
											<PagerStyle HorizontalAlign="Center"></PagerStyle>
										</asp:datagrid>
										</td>
				                  		</tr>
				                		</table>
				                		</div>
								<div id="Divgrid2" style="OVERFLOW: auto" runat="server">
								<table id="Table5" align="center">
								<tr>
								<td align="center">
									
									<asp:datagrid id="DataGrid2" runat="server" CssClass="dtGrid" AllowSorting="false" AutoGenerateColumns="False" OnSortCommand="abc"
											Width="592px">
											<SelectedItemStyle BackColor="#046791"></SelectedItemStyle>
											<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd" BackColor="#7DAAE3"></HeaderStyle>
											<Columns>
												
												<asp:BoundColumn Visible="False" DataField="ENLN" ReadOnly="True" SortExpression="ENLN" HeaderText="Elno.">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="FROM_DAYS" SortExpression="FROM_DAYS" HeaderText="From Days">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="TILL_DAYS" SortExpression="TILL_DAYS" HeaderText="Till Days">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn  DataField="COMM_ON"  HeaderText="COMM. ON">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="COMM_RATE" SortExpression="COMM_RATE" HeaderText="COMM. RATE">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="COMM_TARGET_ID" Visible="false"  HeaderText="COMM_TARGET_ID">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												
												
												
												
												<asp:BoundColumn DataField="AGENCY_TYPE" Visible="true"  HeaderText="AGENCY_TYPE">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												
													<asp:BoundColumn DataField="AGENCY_TYPE_CODE" Visible="false"  HeaderText="AGENCY_TYPE_CODE">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												
												
												
												<asp:TemplateColumn Visible="False" HeaderText="Update">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:TemplateColumn>
												<asp:TemplateColumn Visible="False" HeaderText="Delete">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:TemplateColumn>
												
											
												
											</Columns>
											<PagerStyle HorizontalAlign="Center"></PagerStyle>
										</asp:datagrid>
										</td>
				                  		</tr>
				                		</table>
			         					</div>
						</TD>
					</TR>
			         					
			         					<tr>
								<td align="center"></td>
								<td style ="display:none"><asp:TextBox ID="ttformdate" runat="server"></asp:TextBox></td>
                                <td style ="display:none"><asp:TextBox ID="tttodate" runat="server"></asp:TextBox></td>
							</tr>
			         					
					    			<tr>
									
									<td align="right"><asp:button id="btnclose" runat="server" CssClass="button1" OnClick="btnclose_Click" ></asp:button><asp:button id="btndelete" runat="server" CssClass="button1" ></asp:button></td>
								</tr>
								<tr>
									
									<td><INPUT id="hiddencompcode" type="hidden" size="1" name="hiddencompcode" runat="server" />
										<INPUT id="hiddenretcode" type="hidden" size="1" name="hiddenretcode" runat="server" />
										<INPUT id="hiddenuserid" type="hidden" size="9" name="hiddenuserid" runat="server" />
										<INPUT id="hiddendateformat" type="hidden" name="hiddendateformat" runat="server" />
										<INPUT id="hiddenshow" type="hidden" name="hiddendateformat" runat="server" />
										<INPUT id="hiddendelsau" type="hidden" name="hiddendateformat" runat="server" />
										<INPUT id="hiddenccode" type="hidden" name="hiddendateformat" runat="server" />
										<input id="hiddenenln" type="hidden" name="hiddenenln" runat="server"/>
										<input id="hiddenchkst" type="hidden" name="hiddenenln" runat="server" />
										<input id="hdntargetid" type="hidden" name="hiddenenln" runat="server" />
									</td>
								</tr>
				</TBODY>
			</TABLE>
		</form>
							<%--</table>--%>
			         					<%--</div>--%>	
	</body>
</html>
