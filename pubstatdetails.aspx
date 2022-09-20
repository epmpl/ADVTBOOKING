<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false"CodeFile="pubstatdetails.aspx.cs" Inherits="pubstatdetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>Display Ad. Booking & Sheduling Publication Center Master Status Detail</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<script type="text/javascript"language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/datevalidation.js"></script>
		<script type="text/javascript"language="javascript" src="javascript/PubCatMast.js"></script>
	
		<script type="text/javascript" language="javascript" src="javascript/entertotab.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/permission.js"></script>
			
		<script language="javascript" type="text/javascript" src="javascript/Validations.js"></script>
		<script language="javascript" type ="text/javascript" src="javascript/entertotabpopup.js"></script>
		<script type="text/javascript" language="javascript">
	function dateenter(event)
{
if(browser!="Microsoft Internet Explorer")
 {
  if ((event.which>=48 && event.which<=57)||(event.which==47)||(event.which==11)||(event.which==8)||(event.which==0))
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
   if ((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==47)||(event.keyCode==11)||(event.which==0))
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
	<body onload ="loadXML('xml/errorMessage.xml')">
		<form id="Form1" method="post" runat="server" onkeydown="javascript:return tabvalue();">
			<table id="Table4" style="Z-INDEX: 101; LEFT: 24px; WIDTH: 400px; POSITION: absolute; TOP: 16px; HEIGHT: 280px"
				borderColor="#000000" cellspacing="0" cellpadding="0" width="285" align="center" border="1"ms_2d_layout="TRUE">
				<tr >
					<td valign=top>
						<table id="Table3"    cellspacing="0" cellpadding="0" style="WIDTH: 633px; HEIGHT: 15px" align="center" bgColor="#7daae3"	border="0">
							<tr>
								<td  class="btnlinksau" bgcolor="#7daae3" valign=top align="center" style="height: 19px ">Status Detail</td>
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
											<td style="width: 95px" align="left"><asp:Label id="lbFrom" runat="server" CssClass="TextField"></asp:Label></td>
											<td align="center"><asp:textbox onkeypress="return dateenter(event);" id="txtfrom" runat="server" CssClass="btext1" MaxLength="10"></asp:textbox>
												<script type="text/javascript"language="javascript">					
								if (!document.layers) 
							     {
								    document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, Form1.txtfrom, \"mm/dd/yyyy\")' height=14  width=14> ") 
								    }
												</script>
											</td>
											<td align="left"><asp:Label id="lbStaus" runat="server" CssClass="TextField"></asp:Label></td>
											<td align="right"><asp:dropdownlist id="drpstatus" runat="server" CssClass="dropdown">
													<asp:ListItem Value="0" Selected="True">----Select Status----</asp:ListItem>
													<asp:ListItem Value="Active">Active</asp:ListItem>
													<asp:ListItem Value="UnderNotice">Under Notice</asp:ListItem>
													<asp:ListItem Value="Banned">Banned</asp:ListItem>
													<asp:ListItem Value="NonActive">Non Active</asp:ListItem>
												</asp:dropdownlist></td>
										</tr>
										<tr>
											<td align="left"><asp:Label id="lbTO" runat="server" CssClass="TextField"></asp:Label></td>
											<td align="center"><asp:textbox onkeypress="return dateenter(event);" id="txtto" runat="server" CssClass="btext1" MaxLength="10"></asp:textbox>
												<script type="text/javascript" language="javascript">
										
									if (!document.layers) 
									    {
									    document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, Form1.txtto, \"mm/dd/yyyy\")' height=14 width=14> ") 
									    } 
												</script>
											</td>
											<td><asp:Label id="lbCircularNo" runat="server" CssClass="TextField"></asp:Label></td>
											<td align="right"><asp:textbox id="txtCircular" runat="server" onkeypress="return ClientisNumber(event)" CssClass="numerictext"  MaxLength="5"></asp:textbox></td>
										</tr>
										<tr>
											<td></td>
											<%--<td></td>
											<td></td>
											<td></td>--%>
										</tr>
										<tr>
											<td></td>
											<td></td>
											<td></td>
											<td align="right"> <asp:button id="btnsubmit" runat="server" CssClass="button1" OnClick="btnsubmit_Click"></asp:button><asp:Button ID="btnclear" runat="server" CssClass="button1" /></td>
										</tr>
										<tr>
											<td></td>
											<td></td>
											<td></td>
											<%--<td align="right"> <asp:button id="btnsubmit" runat="server" CssClass="button1" OnClick="btnsubmit_Click"></asp:button><asp:Button ID="btnclear" runat="server" CssClass="button1" /></td>--%>
                                                
										</tr>
									</table>
									<div id="Divgrid1" style="OVERFLOW: auto" runat="server">
										<table id="Table1" align="center">
											<tr>
												<td align="center"><asp:datagrid id="DataGrid1" runat="server" Width="584px" OnSortCommand="abc" CssClass="dtGrid" AutoGenerateColumns="False" AllowSorting="True" >
														<SelectedItemStyle BackColor="#046791"></SelectedItemStyle>
														<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd" BackColor="#7DAAE3"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn>
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle"></ItemStyle>
																<ItemTemplate>
																	<asp:CheckBox ID="CheckBox1" CssClass="textfield1" Runat="server" />
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="cent_status" SortExpression="cent_status" HeaderText="Status">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="FROM_DATE" DataFormatString="{0:d}" SortExpression="FROM_DATE" HeaderText="From Date">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="TO_DATE" SortExpression="TO_DATE" DataFormatString="{0:d}" HeaderText="To Date">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="STAT_CODE" ReadOnly="True" HeaderText="Code" SortExpression="STAT_CODE">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="Circular" SortExpression="Circular" HeaderText="Circular No" ReadOnly="True">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn Visible="False" HeaderText="Update">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:TemplateColumn>
															<asp:TemplateColumn Visible="False" HeaderText="Delete">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:TemplateColumn>
														</Columns>
													</asp:datagrid>
														
													</td>
													
													<%--<td style ="display:none"><asp:TextBox ID="ttformdate" runat="server"></asp:TextBox></td>
                                                    <td style ="display:none"><asp:TextBox ID="tttodate" runat="server"></asp:TextBox></td>--%>

											</table>
							</div>
							<div id="Divgrid2" style="OVERFLOW: auto" runat="server">
										<table id="Table2" align="center">
											<tr>
												<td align="center"><asp:datagrid id="DataGrid2" runat="server" Width="584px" CssClass="dtGrid"
														AutoGenerateColumns="False" OnSortCommand="abc">
														<SelectedItemStyle BackColor="#046791"></SelectedItemStyle>
														<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd" BackColor="#7DAAE3"></HeaderStyle>
														<Columns>
															<asp:BoundColumn DataField="cent_status" HeaderText="Status">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="from_date" DataFormatString="{0:d}" HeaderText="From Date">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="to_date" DataFormatString="{0:d}" HeaderText="To Date">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="stat_code" ReadOnly="True" HeaderText="Code">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="circular" HeaderText="Circular No">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn Visible="False" HeaderText="Update">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:TemplateColumn>
															<asp:TemplateColumn Visible="False" HeaderText="Delete">
																<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															</asp:TemplateColumn>
														</Columns>
													</asp:datagrid>
														</td>
											</tr>
											
										</table>
							        </div>
								</td>
							</tr>
							                <tr align="right">
												<td style="margin-left:580 px">
												    <asp:Button ID="btnclose" runat="server" CssClass="button1" OnClick="btnclose_Click1" />
                                                    <asp:Button ID="btndelete" runat="server" CssClass="button1" /></td>
											</tr>
						</table>
						<table id="Table6" style="WIDTH: 634px; HEIGHT: 19px" cellspacing="0" cellpadding="0" width="634"
							align="center" bgColor="#7daae3" border="0">
							<tr>
								<td align="center"></td>
								<td style ="display:none"><asp:TextBox ID="ttformdate" runat="server"></asp:TextBox></td>
                                <td style ="display:none"><asp:TextBox ID="tttodate" runat="server"></asp:TextBox></td>
							</tr>
							                <input id="hiddendateformat" type="hidden" name="hiddendateformat" runat="server"/>
													<input id="hiddenccode" type="hidden" size="10" name="hiddenccode" runat="server"/>
													<input id="hiddencompcode" type="hidden" size="5" name="hiddencomcode" runat="server"/>
													<input id="hiddenuserid" type="hidden" size="5" name="hiddenuserid" runat="server"/>
													<input id="hiddencentcode" type="hidden" size="5" name="hiddenagevcode" runat="server"/>
													<input id="Hiddenstatcode" type="hidden" size="5" name="hiddenagevcode" runat="server"/>
													<input id="hiddenshow" type="hidden" size="5" name="show" runat="server"/>
													<input id="hiddenchk" type="hidden" size="5" name="hide" runat="server"/>
													<input id="hiddendelsau" type="hidden" size="5" name="hiddendelsau" runat="server"/>
                            <input id="hiddenfdate" type="hidden" size="5" name="hiddendelsau" runat="server"/>
                            <input id="hiddentdate" type="hidden" size="5" name="hiddendelsau" runat="server"/></table>
					</td>
				</tr>
			</table>
			                                        
												
		</form>
	</body>
</html>
