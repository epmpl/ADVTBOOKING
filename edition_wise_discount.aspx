<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edition_wise_discount.aspx.cs" Inherits="edition_wise_discount" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Edititon Wise Discount</title>
   	<script type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>
	<script type="text/javascript" language="javascript" src="javascript/datevalidation.js"></script>
	<script type="text/javascript" language="javascript" src="javascript/Disc_master.js"></script>
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
								<td class="btnlink" align="center">Edititon Wise Discount</td>
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
											<td ><asp:DropDownList id="txtdistype" runat="server" CssClass="btext3"
													MaxLength="50">
													<asp:ListItem Value="0">----Select Type----</asp:ListItem>
				<asp:ListItem Value="F">Fixed</asp:ListItem>
				<asp:ListItem Value="P">Percentage</asp:ListItem>
													</asp:DropDownList></td>
                                            
                                            
                                            <td><asp:Label id="lbldiscount" runat="server" CssClass="TextField"></asp:Label></td>
											<td colspan="4"><asp:textbox id="txtdiscount" runat="server" CssClass="btext3"
													MaxLength="50"></asp:textbox></td>
                                            <td colspan="1">
                                            </td>
											</tr>
										<tr>
											<td><asp:Label id="lbdate" runat="server" CssClass="TextField"></asp:Label></td>
											<td align="left"><asp:TextBox  id="txtfrmedition" runat="server" CssClass="btext3"></asp:TextBox>					
                                       
											</td>
											
										
											<td><asp:Label id="lbaddate" runat="server" CssClass="TextField"></asp:Label></td>
											<td ><asp:TextBox ID="txttoedition" runat="server" CssClass="btext3"></asp:TextBox>                                        
												
                                            </td>
											</tr>
                                            
                                            
                                            <tr  style="display:none">
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
													        <asp:BoundColumn Visible="False" DataField="DISC_CODE" ReadOnly="True" HeaderText="DISC_CODE" >
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
															</asp:BoundColumn>
															
															<asp:BoundColumn Visible="False" DataField="COMP_CODE" ReadOnly="True" HeaderText="COMP_CODE" >
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
															</asp:BoundColumn>
															
															<asp:BoundColumn Visible="False" DataField="UNIT_CODE" ReadOnly="True" HeaderText="UNIT_CODE" >
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
															</asp:BoundColumn>
															
															<asp:BoundColumn Visible="False" DataField="CREATION_DATETIME" ReadOnly="True" HeaderText="CREATION_DATETIME" >
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
															</asp:BoundColumn>
															
															<asp:BoundColumn Visible="False" DataField="USERID" ReadOnly="True" HeaderText="USERID" >
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
															</asp:BoundColumn>
															
															<asp:BoundColumn Visible="False" DataField="UPDATED_DATETIME" ReadOnly="True" HeaderText="UPDATED_DATETIME" >
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
															</asp:BoundColumn>
															
															  <asp:BoundColumn Visible="False" DataField="UPDATEDBY" ReadOnly="True" HeaderText="UPDATEDBY" >
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
															</asp:BoundColumn>
															
															
															<asp:BoundColumn DataField="DISC_TYPE" HeaderText="DISC TYPE " SortExpression="DISC_TYPE">
																						<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
																					</asp:BoundColumn>
																					<asp:BoundColumn DataField="DISCOUNT" HeaderText="DISCOUNT" SortExpression="DISCOUNT">
																						<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                                            Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
																					</asp:BoundColumn>
																					<asp:BoundColumn DataField="FROM_EDITION" HeaderText="FROM EDITION" SortExpression="FROM_EDITION">
																						<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                                            Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
																					</asp:BoundColumn>
																					
																					
																						<asp:BoundColumn DataField="TO_EDITION" HeaderText="TO EDITION" SortExpression="TO_EDITION">
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
													<input id="hdnunit" type="hidden" size="1" name="htext" runat="server"/>
													<input id="hdndate" type="hidden" size="1" name="htext" runat="server"/>
												
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
													       <asp:BoundColumn Visible="False" DataField="DISC_CODE" ReadOnly="True" HeaderText="DISC_CODE" >
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
															</asp:BoundColumn>
															
															<asp:BoundColumn Visible="False" DataField="COMP_CODE" ReadOnly="True" HeaderText="COMP_CODE" >
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
															</asp:BoundColumn>
															
															<asp:BoundColumn Visible="False" DataField="UNIT_CODE" ReadOnly="True" HeaderText="UNIT_CODE" >
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
															</asp:BoundColumn>
															
															<asp:BoundColumn Visible="False" DataField="CREATION_DATETIME" ReadOnly="True" HeaderText="CREATION_DATETIME" >
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
															</asp:BoundColumn>
															
															<asp:BoundColumn Visible="False" DataField="USERID" ReadOnly="True" HeaderText="USERID" >
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
															</asp:BoundColumn>
															
															<asp:BoundColumn Visible="False" DataField="UPDATED_DATETIME" ReadOnly="True" HeaderText="UPDATED_DATETIME" >
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
															</asp:BoundColumn>
															
															  <asp:BoundColumn Visible="False" DataField="UPDATEDBY" ReadOnly="True" HeaderText="UPDATEDBY" >
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
															</asp:BoundColumn>
															
															<asp:BoundColumn DataField="DISC_TYPE" HeaderText="DISC TYPE " SortExpression="DISC_TYPE">
																						<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
																					</asp:BoundColumn>
																					
																					<asp:BoundColumn DataField="DISCOUNT" HeaderText="DISCOUNT" SortExpression="DISCOUNT">
																						<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                                            Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
																					</asp:BoundColumn>
																					
																					<asp:BoundColumn DataField="FROM_EDITION" HeaderText="FROM EDITION" SortExpression="FROM_EDITION">
																						<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                                            Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
																					</asp:BoundColumn>
																					
																					
																						<asp:BoundColumn DataField="TO_EDITION" HeaderText="TO EDITION" SortExpression="TO_EDITION">
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