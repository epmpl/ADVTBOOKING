<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogView.aspx.cs" Inherits="LogView" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>LogView</title>
     <script type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>
        <script type="text/javascript" language="javascript" src="javascript/datevalidation.js"></script>
        <script type="text/javascript" language="javascript" src="javascript/logview.js"></script>
        <script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
</head>
<body leftMargin="5" topmargin=0 id="bdy" onkeydown="javascript:return tabvalue(event);" style="background-color:#f3f6fd;"><%--onload="javascript:return givebuttonpermission('LogView');"--%>
    <form id="form1" method="post" runat="server">
    <table id="OuterTable" width="1000"  border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="PubCatRef" ></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<%--<td valign="top" style="width: 184px"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>--%>
					<td valign="top">
						<%--<table cellspacing="0" cellpadding="0" border="0" id="RightTable" class="RightTable">
							<tr valign="top">
								<td><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnSave" runat="server" CssClass="topbutton" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnModify" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnQuery" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnExecute" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnCancel" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnfirst" CssClass="topbutton" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnprevious" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnnext" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnlast" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnDelete" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnExit" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton>
								</td>
							</tr>
							
				   </table>--%>
				 </td>
				</tr>
			 </table>
			 <table border="0" width="100%" cellpadding="0" cellspacing="0" style="width:auto;margin:15px 30px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><center><b>LogView</b></center></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			 <table  cellpadding="0" cellspacing="0" border="0" style="width:auto;margin:30px 300px;">
				<tr height="16px">
				        <td><asp:label id="lbtblname" runat="server" CssClass="TextField" ></asp:label></td>
				        <td><asp:dropdownlist id="drptabname" runat="server" CssClass="dropdown"></asp:dropdownlist></td>
				</tr>
				<tr height="16px">
						<td><asp:label id="lbtrx" runat="server" CssClass="TextField"></asp:label></td>
						 <td><asp:dropdownlist id="drptrxtype" runat="server" CssClass="dropdown">
						 <asp:ListItem Value="0">--Transaction Type--</asp:ListItem>
						 <asp:ListItem Value="INS">INSERT</asp:ListItem>
						 <asp:ListItem Value="UPD">UPDATE</asp:ListItem>
						 <asp:ListItem Value="DEL">DELETE</asp:ListItem>
						 </asp:dropdownlist>
						 </td>
				</tr>
				<tr height="16px">
						<td><asp:label id="lbuser" runat="server" CssClass="TextField"></asp:label></td>
						 <td><asp:dropdownlist id="drpuser" runat="server" CssClass="dropdown"></asp:dropdownlist></td>
				</tr>
				<tr height="16px">
						<td><asp:label id="lbdate" runat="server" CssClass="TextField"></asp:label></td>
						<td><asp:TextBox ID="txtdate"  runat="server" CssClass="btext1" MaxLength="10" onkeypress="return dateenter(event);" onpaste="return false;"></asp:TextBox>
						<script language="javascript">
								if (!document.layers) 
								{
									document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtdate, \"mm/dd/yyyy\")' height=14 width=14 >")
								}					
						</script></td>
						<td>&nbsp;&nbsp;&nbsp;&nbsp;</td> 
						<td><asp:Button id="btnSubmit" runat="server" Text="Submit" CssClass="topbutton" Width="63px" Font-Size="XX-Small"
							BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px" OnClick="btnSubmit_Click" />
				        </td>
				</tr>
				<%--<tr height="16px"><tr></tr>
				<td></td><td></td>
				        
				</tr>--%>
				<tr>
				<table cellpadding="0" cellspacing="0"><tr><td style="background-color:ActiveBorder;width:950px; height:4px;"></td></tr></table>
				</tr>
			</table>
				
			<%-- <table  cellpadding="0" cellspacing="0" border="0" style="width:auto;margin:30px 300px;">
				<tr height="16px">
				<td><asp:label id="lbtblname1" runat="server" CssClass="TextField"></asp:label></td>
				<td><asp:TextBox ID="txttabname"  runat="server" CssClass="btext1" MaxLength="30" Enabled="false"></asp:TextBox></td> 
				
				<td><asp:label id="lbtrx1" runat="server" CssClass="TextField"></asp:label></td>
				<td><asp:TextBox ID="txttrx"  runat="server" CssClass="btext1" MaxLength="30" Enabled="false"></asp:TextBox></td> 
				</tr>
				<tr height="16px">
				<td><asp:label id="lbuser1" runat="server" CssClass="TextField"></asp:label></td>
				<td><asp:TextBox ID="txtuser"  runat="server" CssClass="btext1" MaxLength="30" Enabled="false"></asp:TextBox></td> 
				
				<td><asp:label id="lbtrxval" runat="server" CssClass="TextField"></asp:label></td>
				<td><asp:TextBox ID="txttrxval"  runat="server" CssClass="btext1" MaxLength="30" Enabled="false"></asp:TextBox></td> 
				</tr>
				<tr>
				<td><asp:label id="lbseq" runat="server" CssClass="TextField"></asp:label></td>
				<td><asp:TextBox ID="txtseq"  runat="server" CssClass="btext1" MaxLength="30" Enabled="false"></asp:TextBox></td> 
				</tr>
				</table>--%>
				<table style="width:auto;margin:30px 300px;">
				<tr>
				<td> <%--OnSortCommand="DataGrid2_SortCommand" --%>
                    <asp:datagrid id="DataGrid2" runat="server" CssClass="dtGrid" Width="538px"
														AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanged="DataGrid2_PageIndexChanged" PageSize="50" OnItemDataBound="DataGrid2_ItemDataBound"  >
														<SelectedItemStyle BackColor="#046791" ></SelectedItemStyle>
														<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
														<Columns>
															<asp:BoundColumn DataField="FIELD" HeaderText="FIELD NAME">
																<ItemStyle HorizontalAlign="Left" BackColor="White" BorderColor="#7DAAE3"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="OLD" HeaderText="OLD">
																<ItemStyle HorizontalAlign="Left" BackColor="White" BorderColor="#7DAAE3"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="NEW" HeaderText="NEW">
																<ItemStyle HorizontalAlign="Left" BackColor="White" BorderColor="#7DAAE3"></ItemStyle>
															</asp:BoundColumn>
														</Columns>
														<FooterStyle HorizontalAlign="Center" Height="20px" Font-Bold="True" />
                        <PagerStyle NextPageText="Next" PrevPageText="Prev" Font-Bold="True" BackColor="#7DAAE3" />
													</asp:datagrid>
				</td>
				</tr>
				
			</table>
				<input id="hiddencompcode" type="hidden" size="5" name="hiddenregion" runat="server" />	
				<input id="hiddendateformat" type="hidden" size="5" name="hiddenregion" runat="server" />
    </form>
</body>

</html>
