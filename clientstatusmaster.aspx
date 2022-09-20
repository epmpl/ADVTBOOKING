<%@ Page Language="C#" AutoEventWireup="true" CodeFile="clientstatusmaster.aspx.cs" Inherits="clientstatusmaster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<HEAD>
		<title>Display Ad. Booking & Sheduling Client Master StatusDetails</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="javascript/popupcalender.js"></script>
		<script language="javascript" src="javascript/ClientMaster_popup.js"></script>
		<script language="javascript" src="javascript/Validations.js"></script>
		<script type="text/javascript" src="javascript/datevalidation.js"></script>
		<script language="javascript" src="javascript/datechkforcurrdate.js" type="text/javascript"></script>
		<style type="text/css">.style1 { FONT-WEIGHT: bold; COLOR: #ffffff; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif }
	.style2 { COLOR: #ffffff }
		</style>
		<LINK href="css/main.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		
		function datecurr(event)
{
if(browser!="Microsoft Internet Explorer")
 {
  if ((event.which>=48 && event.which<=57)||(event.which==47)||(event.which==11)||(event.which==8))
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
	</HEAD>
	<body style="TEXT-ALIGN: center" onkeydown="tabvalue('txtcircular')">
		<form id="Form1" style="TEXT-ALIGN: right" method="post" runat="server">
		
                       
            <table cellSpacing="0" cellPadding="0" width="660" align="center" border="1" borderColor="#000000">
				<tr>
					<td align="right" style="width: 668px">
						<table cellSpacing="0" cellPadding="0" width="608">
							<tr>
								<td align="left" class="btnlink" width="620" bgColor="#7daae3" style="height: 17px">
									<!--------------heading start----------------> Status Details 
									<!--------------heading end---------------></td>
							</tr>
							<TR>
								<td>
									<TABLE id="Table1" style="WIDTH: 664px; HEIGHT: 85px" cellSpacing="1" cellPadding="1" width="664"
										align="left" border="0">
										<TR>
											<TD align="left"><asp:label id="lbfrom" runat="server" CssClass="TextField"></asp:label></TD>
											<TD align="center"><asp:textbox onkeypress="return datecurr(event);" id="txtfrom" MaxLength="10" runat="server" CssClass="btext1"></asp:textbox>
												<SCRIPT language="javascript">
																		
			                           if (!document.layers) 
									     {
									    document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, Form1.txtfrom, \"mm/dd/yyyy\")' height=14 width=14> ")
									     }
																			
												</SCRIPT>
											</TD>
											<TD align="left"><asp:label id="lbstatus" runat="server" CssClass="TextField"></asp:label></TD>
											<TD align="right"><asp:dropdownlist id="drpstatus" runat="server" CssClass="dropdown">
												</asp:dropdownlist>
											</TD>
										</TR>
										<TR>
											<TD align="left"><asp:label id="lbto" runat="server" CssClass="TextField"></asp:label></TD>
											<TD align="center"><%--<asp:textbox onkeypress="return datecurr(event);" id="txtto" MaxLength="10" runat="server" CssClass="btext1"></asp:textbox>
												<SCRIPT language="javascript">
																		
			                           if (!document.layers) 
									     {
									    document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, Form1.txtto, \"mm/dd/yyyy\")' height=14 width=14> ")
									     }
																			
												</SCRIPT>--%>
												
												 <asp:TextBox ID="txtto" runat="server" CssClass="btext1" Enabled="False" onkeypress="return dateenter(event);"></asp:TextBox><img
                                                        src='Images/cal1.gif' id="Img2" onclick='popUpCalendar(this, Form1.txtto, "mm/dd/yyyy")'
                                                        onfocus="abc()" height="11" width="14" />
</td>
											</TD>
											<TD align="left">
												<asp:label id="lbcircularno" runat="server" CssClass="TextField"></asp:label></TD>
											<TD align="right">
												<asp:textbox id="txtcircular" onkeypress="return ClientisNumber(event);" runat="server" CssClass="btext1numeric" MaxLength="8"></asp:textbox></TD>
										</TR>
										
										
										
										
										<TR>
											<td height="10" align="left"><asp:label id="lblattachment3" runat="server" CssClass="TextField"></asp:label></td>
                                            <td align="left"><asp:ImageButton ID="attachment1" runat="server" CssClass="btnlinkImage" ToolTip="Attachment" ImageUrl="~/Images/index.jpeg" ></asp:ImageButton></td>
                                            
                                            
                                            <TD align="left">
												<asp:label id="lblremark" runat="server" CssClass="TextField"></asp:label></TD>
											<TD align="right">
												<asp:textbox id="txtremark"  runat="server" CssClass="btext1numeric" MaxLength="100"></asp:textbox></TD>
                                            
                                            
                                            
                                            
                                            
                                           
											<TD></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
											<TD></TD>
											
											
											 <td style="display:none">
                                                        
                                                         <asp:TextBox ID="txtdatetime" runat="server" CssClass="btext3" Enabled="False">Date/Time</asp:TextBox>
                                                       
                                                    </td>
											<TD align="right"><asp:button id="btnsubmit" runat="server" CssClass="button1" OnClick="btnsubmit_Click"></asp:button><asp:button id="btnclear" runat="server" CssClass="button1"></asp:button></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
											<TD></TD>
											<TD vAlign="middle" align="center"></TD>
										</TR>
									</TABLE>
								</td>
							</TR>
						</table>
						
						<div id="Divgrid1" style="OVERFLOW: auto; margin:0px 0px 0px 0px;  HEIGHT: 208px" runat="server">
								<table id="Table2" align="center">
								<tr> 
								<td align="center"><asp:datagrid id="DataGrid1" runat="server" CssClass="dtGrid" 
                                        AllowSorting="True" Width="664px"
								AutoGenerateColumns="False" onsortcommand="DataGrid1_SortCommand">
								<SelectedItemStyle BackColor="#046791"></SelectedItemStyle>
								<HeaderStyle Height="20px" CssClass="dtGridHd" BackColor="#7DAAE3"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn>
										<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle"></ItemStyle>
										<ItemTemplate>
											<asp:CheckBox ID="CheckBox1" CssClass="textfield1" Runat="server" />
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="status_name" SortExpression="status_name" HeaderText="Status">
										<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="From_date" SortExpression="From_date" HeaderText="From Date">
										<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="to_date" SortExpression="to_date" HeaderText="To Date">
										<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="stat_code" ReadOnly="True" HeaderText="Code" SortExpression="stat_code">
										<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Circular" SortExpression="Circular" HeaderText="Circular No.">
										<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="attachment" SortExpression="attachment" HeaderText="Attachment">
									<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
									<asp:TemplateColumn Visible="False" HeaderText="Delete">
										<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									</asp:TemplateColumn>
								</Columns>
							</asp:datagrid>
						</td>
						</tr>
					
                                                            
						</table>
							</div>
							<div id="Divgrid2" style="OVERFLOW: auto; margin:0px 0px 0px 0px; HEIGHT: 208px" runat="server">
										<table id="Table3" align="center">
											<tr>
						<td align="center"><asp:DataGrid ID="DataGrid2" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            CssClass="dtGrid" Width="664px">
                            <SelectedItemStyle BackColor="#046791" />
                            <HeaderStyle BackColor="#7DAAE3" CssClass="dtGridHd" ForeColor="White" Height="20px"
                                HorizontalAlign="Center" />
                            <Columns>
                                <asp:BoundColumn DataField="status_name" HeaderText="Status" SortExpression="status_name">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="from_date" DataFormatString="{0:d}" HeaderText="From Date"
                                    SortExpression="from_date">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="to_date" DataFormatString="{0:d}" HeaderText="To Date"
                                    SortExpression="to_date">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="stat_code" HeaderText="Code" ReadOnly="True" Visible="False" SortExpression="stat_code">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="circular" HeaderText="Circular No." SortExpression="circular">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="cust_status" HeaderText="status code" SortExpression="cust_status"
                                    Visible="False"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="attachment" SortExpression="attachment" HeaderText="Attachment">
                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="Update" Visible="False">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Delete" Visible="False">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateColumn>
                            </Columns>
                        </asp:DataGrid>
                        		</td>
											</tr>
											
										</table>
							        </div>
							            
<INPUT id="hiddenchk" type="hidden" name="hiddenchk" runat="server"/>
<input id="hiddenfdate" type="hidden" size="5" name="hiddendelsau" runat="server"/>
<input id="hiddentdate" type="hidden" size="5" name="hiddendelsau" runat="server"/>
<INPUT id="hiddencomcode" type="hidden" name="hiddencomcode" runat="server">
<INPUT id="hiddenuserid" type="hidden" name="hiddenuserid" runat="server">
<INPUT id="hiddencustcode" type="hidden" name="hiddenagevcode" runat="server">
<input id="hidattach1" type="hidden" name="hidattach1" runat="server"/>
<INPUT id="hiddendateformat" style="WIDTH: 51px; HEIGHT: 22px" type="hidden" size="3" name="hiddenDateFormat" runat="server"> 
<INPUT id="hiddenccode" style="WIDTH: 51px; HEIGHT: 22px" type="hidden" size="3" name="hiddenDateFormat" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:Button ID="btnclose" runat="server" CssClass="button1" /><asp:button id="btndelete" runat="server" CssClass="button1"></asp:button>
					</td>
				</TR>
			</table>
		</form>
	</body>
</HTML>
