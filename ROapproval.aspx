<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ROapproval.aspx.cs" Inherits="ROapproval" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>RO Approval</title>
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
    <script  type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
     <script language="javascript" src="javascript/ROapproval.js" type="text/javascript"></script>
     <script type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>
</head>
<body leftMargin="5" topmargin=0 id="bdy" onkeydown="javascript:return tabvalue(event);"  style="background-color:#f3f6fd;"><%--onload="javascript:return givebuttonpermission('PubCatRef');" onkeydown="javascript:return tabvalue(event ,'txtname');"--%>
    <form id="form1" runat="server">
    <div id="div1" style="position: absolute; top: 0px; left: 0px; border: none; display: none;
            z-index: 1; " >
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:ListBox ID="lstagency" Width="350px" Height="80px" runat="server" CssClass="btextlist">
                        </asp:ListBox></td>
                </tr>
            </table>
        </div>
        <div id="divclient" style="position: absolute; top: 0px; left: 0px; border: none;
            display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        
                                <asp:ListBox ID="lstclient" Width="350px" Height="65px" runat="server" CssClass="btextlist">
                                </asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divexec" style="position: absolute; top: 0px; left: 0px; border: none; display: none;
            z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        
                                <asp:ListBox ID="lstexec" Width="254px" Height="65px" runat="server" CssClass="btextlist">
                                </asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divapprove" style="position: absolute; top: 0px; left: 0px; border: none; display: none;
            z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td><asp:Label ID="Label1" runat="server" CssClass="TextField" Text="Remarks"></asp:Label></td>
                    <td><asp:ListBox id="lbremark" runat="server"   CssClass="btextlistqbcnew" SelectionMode="Multiple"></asp:ListBox></td>
                  </tr><tr><td></td><td>&nbsp;&nbsp;&nbsp;&nbsp;</td> <td><asp:Button id="Button1" runat="server" Text="Submit" CssClass="topbutton" Width="63px" Font-Size="XX-Small"
							BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px" /></td>
				</tr>
            </table>
        </div>
    <table id="OuterTable" width="1000"  border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="PubCatRef" ></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top" style="width: 184px"><%--<uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar>--%></td>
					<td valign="top">
						<table cellspacing="0" cellpadding="0" border="0" id="RightTable" class="RightTable">
							<tr valign="top">
								<%--<td><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
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
								</td>--%>
							</tr>
							
				   </table>
				 </td>
				</tr>
			 </table>
			 <table border="0" width="100%" cellpadding="0" cellspacing="0" style="width:auto;margin:15px 30px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><center><b>RO Approval</b></center></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
            <table  cellpadding="0" cellspacing="0" border="0" style="width:auto;margin:30px 300px;">
            <tr>
						<td><asp:label id="lbagency" runat="server" CssClass="TextField"></asp:label></td>
						<td><asp:TextBox ID="txtagency"  runat="server" CssClass="btext1" MaxLength="50"></asp:TextBox></td> 
				</tr>
				<tr>
						<td><asp:label id="lbclient" runat="server" CssClass="TextField"></asp:label></td>
						<td><asp:TextBox ID="txtclient"  runat="server" CssClass="btext1" MaxLength="50"></asp:TextBox></td> 
				</tr>
				<tr>
						<td><asp:label id="lbexecutive" runat="server" CssClass="TextField"></asp:label></td>
						<td><asp:TextBox ID="txtexecname"  runat="server" CssClass="btext1" MaxLength="50"></asp:TextBox></td>
						
						</tr>
						<tr>
						<td ><asp:Label ID="lblvfrm" runat="server" CssClass="TextField"></asp:Label></td>
                        <td ><asp:TextBox ID="txtvalidityfrom" runat="server" CssClass="btext1" Enabled="true" MaxLength="10" AutoPostBack="True"></asp:TextBox>
     
                      <img src='Images/cal1.gif'  onclick='popUpCalendar(this,form1.txtvalidityfrom,"mm/dd/yyyy")' height="14" width="14" >
			          </td>
			          </tr>
			          
		              <tr>
                      <td><asp:Label ID="lblvalidtill" runat ="server" CssClass="TextField" Align="right"></asp:Label></td>
                      <td> <asp:textbox id="txttilldate" runat="server" CssClass="btext1" Enabled="true" MaxLength="10" AutoPostBack="True"></asp:textbox>
       
                      <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txttilldate,"mm/dd/yyyy")' height="14" width="14" >
	
                      </td>
						
						
						
						
						 
						<td>&nbsp;&nbsp;&nbsp;&nbsp;</td> 
						<td><asp:Button id="btnSubmit" runat="server" CssClass="topbutton" Width="63px" Font-Size="XX-Small"
							BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px" OnClick="btnSubmit_Click" />
				        </td>
				</tr>
				</table>
				<table style="width:auto;margin:30px 140px;">
				<tr>
				<td> 
                    <asp:datagrid id="DataGrid2" runat="server" CssClass="dtGrid" Width="838px" OnPageIndexChanged="DataGrid2_PageIndexChanged"
														AutoGenerateColumns="False" AllowPaging="True" OnSelectedIndexChanged="DataGrid2_SelectedIndexChanged" OnItemDataBound="DataGrid2_ItemDataBound">
														<SelectedItemStyle BackColor="#046791" ></SelectedItemStyle>
														<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
														<Columns>
														<asp:BoundColumn DataField="cio_booking_id" HeaderText="Booking Id">
																<ItemStyle HorizontalAlign="Left" BackColor="White" BorderColor="#7DAAE3"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="AGENCY" HeaderText="Agency Name">
																<ItemStyle HorizontalAlign="Left" BackColor="White" BorderColor="#7DAAE3"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="CLIENT" HeaderText="Client">
																<ItemStyle HorizontalAlign="Left" BackColor="White" BorderColor="#7DAAE3"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="PACKAGE" HeaderText="Package">
																<ItemStyle HorizontalAlign="Left" BackColor="White" BorderColor="#7DAAE3"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="BOOKDATE" HeaderText="Booking Date">
																<ItemStyle HorizontalAlign="Left" BackColor="White" BorderColor="#7DAAE3"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="RO_NO" HeaderText="Ro No.">
																<ItemStyle HorizontalAlign="Left" BackColor="White" BorderColor="#7DAAE3"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="RODATE" HeaderText="Ro Date">
																<ItemStyle HorizontalAlign="Left" BackColor="White" BorderColor="#7DAAE3"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="EXECUTIVE" HeaderText="Executive">
																<ItemStyle HorizontalAlign="Left" BackColor="White" BorderColor="#7DAAE3"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="RETAINER" HeaderText="Retainer">
																<ItemStyle HorizontalAlign="Left" BackColor="White" BorderColor="#7DAAE3"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="DEVIATION" HeaderText="Deviation">
																<ItemStyle HorizontalAlign="Left" BackColor="White" BorderColor="#7DAAE3"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="Card_rate" HeaderText="Card Rate">
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
				<input id="hiddencompcode" type="hidden" size="5" name="hiddenregion" runat="server" />	
				<input id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server" />
				<input id="hiddenagency" type="hidden" size="1" name="inserts" runat="server" />
				<input id="hiddendateformat" type="hidden" size="5" name="hiddenregion" runat="server" />	
				
					
    </form>
</body>
</html>
