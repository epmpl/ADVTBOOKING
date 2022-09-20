<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RetainerStatusMaster.aspx.cs" Inherits="RetainerStatusMaster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>Display Ad. Booking & Sheduling Retainer Master Status Detail</title>
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
			
	function notchar2(event) {
	   
      var browser=navigator.appName;

   if(browser!="Microsoft Internet Explorer")
    {
        if ((event.which >= 48 && event.which <= 57) || (event.which == 127) || (event.which == 8) || (event.which == 9) || (event.which == 0))
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
     function datecurr(event) {

           
if(browser!="Microsoft Internet Explorer")
 {
     if ((event.which >= 48 && event.which <= 57) || (event.which == 47) || (event.which == 11) || (event.which == 9) || (event.which == 0)) {
    

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
	</head>
	<body onload ="loadXML('xml/errorMessage.xml')" >
		<form id="Form1" method="post" runat="server">
			<table id="Table4" bordercolor="#000000" cellspacing="0"  cellpadding="0" width="632" align="center"
				border="1">
				<TBODY>
					<TR vAlign="middle">
						<TD style="width: 636px">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="633" align="center" bgColor="#7daae3"
								border="0">
								<TR>
									<TD class="btnlink" align="center">Status Detail</TD>
								</TR>
							</TABLE>
							<table id="table1">
								<tr>
								</tr>
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
												<td><asp:textbox onkeypress="javascript:return datecurr(event);" MaxLength="10" id="txtfrom" runat="server" CssClass="btext1"  TabIndex="1"  onpaste="return false; "></asp:textbox>
													<SCRIPT language="javascript">					
								if (!document.layers) 
								{
									document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, Form1.txtfrom, \"mm/dd/yyyy\")' height=14  width=14>") 
								}
													</SCRIPT>
												</td>
												<td><asp:label id="lblstatus" runat="server" CssClass="TextField"></asp:label></td>
												<td><asp:dropdownlist TabIndex="2" id="drpstatus" runat="server" CssClass="dropdown">
														<asp:ListItem Value="0">--Select Status--</asp:ListItem>
														<asp:ListItem Value="Active">Active</asp:ListItem>
														<asp:ListItem Value="Under&#160;Notice">Under Notice</asp:ListItem>
														<asp:ListItem Value="Banned">Banned</asp:ListItem>
														<asp:ListItem Value="Not&#160;Active">Non Active</asp:ListItem>
													</asp:dropdownlist></td>
											</tr>
											<tr>
												<td style="HEIGHT: 16px"><asp:label id="lbltodate" runat="server" CssClass="TextField"></asp:label></td>
												<td style="HEIGHT: 16px"><asp:textbox  TabIndex="3" onkeypress="return datecurr(event);" MaxLength="10"  id="txtto" runat="server" CssClass="btext1" onpaste="return false;"></asp:textbox>
													<script language="javascript">					
								if (!document.layers) 
								{
									document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, Form1.txtto, \"mm/dd/yyyy\")' height=14  width=14>") 
								}
													</script>
												</td>
												<td style="HEIGHT: 16px"><asp:label id="lblcircular" runat="server" CssClass="TextField"></asp:label></td>
												<td style="HEIGHT: 16px"><asp:textbox TabIndex="4" id="txtcircularno" runat="server" MaxLength="6" onkeypress="return notchar2(event);"
														CssClass="btext1" onpaste="return false;"></asp:textbox></td>
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
												<td align="right"><asp:button   TabIndex="5" id="btnSubmit" runat="server" CssClass="button1" OnClick="btnSubmit_Click"></asp:button><asp:button TabIndex="6" id="btnclear" runat="server" CssClass="button1"  ></asp:button></td>
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
									
									<asp:datagrid id="DataGrid1" runat="server" CssClass="dtGrid" AllowSorting="True" AutoGenerateColumns="False" OnSortCommand="abc"
											Width="592px">
											<SelectedItemStyle BackColor="#046791"></SelectedItemStyle>
											<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd" BackColor="#7DAAE3"></HeaderStyle>
											<Columns>
												<asp:TemplateColumn>
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
											<asp:CheckBox ID="CheckBox1" CssClass="textfield1" Runat="server" />
										</ItemTemplate>
												</asp:TemplateColumn>
												
												<asp:BoundColumn DataField="cust_status" SortExpression="cust_status" HeaderText="Status">
												<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="FROM_DATE" SortExpression="FROM_DATE" HeaderText="From Date">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="TO_DATE" SortExpression="TO_DATE" HeaderText="To Date">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="STAT_CODE" ReadOnly="True" HeaderText="Code">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="circular_no" SortExpression="circular_no" HeaderText="Circular No">
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
									
									<asp:datagrid id="DataGrid2" runat="server" CssClass="dtGrid" AllowSorting="True" AutoGenerateColumns="False" OnSortCommand="abc"
											Width="592px">
											<SelectedItemStyle BackColor="#046791"></SelectedItemStyle>
											<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd" BackColor="#7DAAE3"></HeaderStyle>
											<Columns>
												<asp:BoundColumn DataField="cust_status" SortExpression="cust_status" HeaderText="Status">
										<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
												<asp:BoundColumn DataField="STATUS_NAME" SortExpression="STATUS_NAME" HeaderText="Status" Visible="False">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="FROM_DATE" SortExpression="FROM_DATE" HeaderText="From Date">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="TO_DATE" SortExpression="TO_DATE" HeaderText="To Date">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="STAT_CODE" ReadOnly="True" HeaderText="Code">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="circular_no" SortExpression="circular_no" HeaderText="Circular No">
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
									
									<td align="right"><asp:button id="btnclose" runat="server" CssClass="button1" OnClick="btnclose_Click"></asp:button><asp:button id="btndelete" runat="server" CssClass="button1" ></asp:button></td>
								</tr>
								<tr>
									
									<td><INPUT id="hiddencompcode" type="hidden" size="1" name="hiddencompcode" runat="server" />
										<INPUT id="hiddenretcode" type="hidden" size="1" name="hiddenretcode" runat="server" />
										<INPUT id="hiddenuserid" type="hidden" size="9" name="hiddenuserid" runat="server" />
										<INPUT id="hiddendateformat" type="hidden" name="hiddendateformat" runat="server" />
										<INPUT id="hiddenshow" type="hidden" name="hiddendateformat" runat="server" />
										<INPUT id="hiddendelsau" type="hidden" name="hiddendateformat" runat="server" />
										<INPUT id="hiddenccode" type="hidden" name="hiddendateformat" runat="server" />
										 <input id="hiddenfdate" type="hidden" size="5" name="hiddendelsau" runat="server"/>
                                         <input id="hiddentdate" type="hidden" size="5" name="hiddendelsau" runat="server"/>
									</td>
								</tr>
				</TBODY>
			</TABLE>
		</form>
							<%--</table>--%>
			         					<%--</div>--%>	
	</body>
</HTML>
