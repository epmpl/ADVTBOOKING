<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reportConfirm.aspx.cs" Inherits="reportConfirm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Report For QBC</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		<style type="text/css">.style1 { FONT-WEIGHT: bold; COLOR: #ffffff; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif }
	.style2 { COLOR: #ffffff }
		</style>
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<link href="css/booking.css" type="text/css" rel="stylesheet"/>
		<link href="css/report.css" type="text/css" rel="stylesheet"/>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
		<script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/rept.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/reportConfirm.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/datevalidation.js"></script>
		<style type="text/css">.style1 { FONT-WEIGHT: bold; FONT-SIZE: xx-large; COLOR: #ffffff }
	.style2 { COLOR: #ffffff }
	.style4 { FONT-WEIGHT: normal; FONT-SIZE: 14pt; COLOR: #d85414; FONT-FAMILY: Verdana }
	.style6 { FONT-SIZE: x-small }
	.style7 { FONT-WEIGHT: bold; COLOR: #6666ff }
		</style>
		<script language="javascript" type="text/javascript">
		function forfocus()
		{
		document.getElementById('Txtusernme').focus();
		}
		function maximize()
        {
        window.moveTo(0,0)            
        window.resizeTo(screen.availWidth, screen.availHeight)
         }
        maximize();
		</script>
</head>
<body onkeydown="javascript:return tabvalue();" onkeypress="eventcalling(event);" onload="document.getElementById('txtFromDate').focus();">
    <form id="Form1"  runat="server">
  
			<table width="1005" border="0" cellspacing="0" cellpadding="0" align="center" style="WIDTH: 1005px; HEIGHT: 50px">
				<tr>
					<td width="100%" bordercolor="#1"><img src="images/img_02A.jpg" width="1004" border="0" />
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    </td>
				</tr>
				<tr>
					<td width="100%" bordercolor="#1"><img src="images/top.jpg" width="1004" border="0" /></td>
				</tr>
				<tr>
					<td style="height: 505px"><table width="985" border="0" cellspacing="0" cellpadding="0" style="WIDTH: 985px; HEIGHT: 486px">
							<tr>
								<!---------left bar start--------->
								<td width="200" style="WIDTH: 200px"><img src="images/leftbar.jpg" style="WIDTH: 193px; HEIGHT: 483px" height="483" width="193" /></td>
								<!---------left bar end--------->
								<!---------middle start--------->
								<td valign="top" style="width: 78%">
								
								<table cellpadding="0" cellspacing="0" width="790" style="WIDTH: 790px; HEIGHT: 488px"
										borderColorDark="#000000" border="1">
										<tr>
											<td align="center">
											<table ><tr>
											<td><asp:Label ID="heading" runat ="server" CssClass="heading"></asp:Label></td></tr>
											</table>
											<br />
											
											<table width="0" border="0" cellspacing="0" cellpadding="0">
											
											
											
											<tr style="padding-top:5px">
													    <td>
                                                            <asp:Label ID="lblfilter" runat="server" CssClass="TextField"></asp:Label></td>
													    <td>
                                                            <asp:DropDownList ID="drpfilter" runat="server" CssClass="dropdown">
                                                                <asp:ListItem Value="0">Booked Date</asp:ListItem>
                                                                <asp:ListItem Value="1">Published Date</asp:ListItem>                                                                
                                                            </asp:DropDownList></td>
													</tr>
													<tr>
													
													</tr>
													<tr>
													    <td>
                                                            <asp:Label ID="lbFromDate" runat="server" Text="From Date" CssClass="TextField"></asp:Label></td>
													    <td>
                                                            <asp:TextBox ID="txtFromDate" runat="server" CssClass="btext1"></asp:TextBox>
                                                            
                                                        </td>
                                                        <td>
                                                        <script language="javascript" type="text/javascript">		
		                                                        if (!document.layers) 
								                                {
								                                    document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, Form1.txtFromDate, \"mm/dd/yyyy\")' height=14 width=14> ")
								                                }				
												            </script>
                                                        </td>
													</tr>
													<tr style="padding-top:5px">
													    <td>
                                                            <asp:Label ID="lbToDate" runat="server" Text="To Date" CssClass="TextField"></asp:Label></td>
													    <td>
                                                            <asp:TextBox ID="txtToDate" runat="server" CssClass="btext1"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <script language="javascript" type="text/javascript">		
		                                                        if (!document.layers) 
								                                {
								                                    document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, Form1.txtToDate, \"mm/dd/yyyy\")' height=14 width=14> ")
								                                }				
												            </script>    
                                                        </td>
													</tr>
													<tr style="padding-top:5px">
													    <td>
                                                            <asp:Label ID="lbStatus" runat="server" CssClass="TextField"></asp:Label></td>
													    <td>
                                                            <asp:DropDownList ID="drpStatus" runat="server" CssClass="dropdown">
                                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                <asp:ListItem Value="1">Confirm</asp:ListItem>
                                                                <asp:ListItem Value="2">Unconfirm</asp:ListItem>
                                                            </asp:DropDownList></td>
													</tr>
													<tr align="right">
														<td align="right" colspan="2" style="padding-top:10px">
                                                                <%--<asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:button id="BtnRun" CssClass="btntext" Runat="server" OnClick="BtnRun_Click" OnClientClick="javascript:return validate();"></asp:button>
                                                                    
                                                                    
                                                                    
                                                                <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                               
                                                            </td>
													</tr>
											</table>
													<table>
													
													
												</table>
												<table style="width: 223px" >
												<tr>
														<%--<td align="left" colSpan="2" style="width: 72px; height: 25px;">
															</td>--%>
															
															
                                                            <td style="height: 116px">
                                                                <asp:DataGrid ID="DataGrid1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                    CellPadding="0" CssClass="dtGrid" DESIGNTIMEDRAGDROP="775" Width="554px">
                                                                    <SelectedItemStyle Font-Names="Trebuchet MS" Font-Size="XX-Small" HorizontalAlign="Center"
                                                                        VerticalAlign="Middle" />
                                                                    <Columns>
                                                                        <asp:BoundColumn DataField="cio_booking_id" HeaderText="Booking Id" ReadOnly="True"
                                                                            SortExpression="cio_booking_id">
                                                                            <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                                Font-Underline="False" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                            <ItemStyle CssClass="dtGridtext" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="creation_datetime" DataFormatString="{0:d}" HeaderText="Date"
                                                                            ReadOnly="True" SortExpression="creation_datetime">
                                                                            <HeaderStyle ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                            <ItemStyle CssClass="dtGridtext" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="Agency_name" HeaderText="Agency" ReadOnly="True" SortExpression="Agency_name">
                                                                            <HeaderStyle ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                            <ItemStyle CssClass="dtGridtext" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="client_name" HeaderText="Client" ReadOnly="True" SortExpression="client_name">
                                                                            <HeaderStyle ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                            <ItemStyle CssClass="dtGridtext" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="RO_No" HeaderText="RO No." ReadOnly="True" SortExpression="RO_No">
                                                                            <HeaderStyle ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                            <ItemStyle CssClass="dtGridtext" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="RO_Date" HeaderText="RO Date" ReadOnly="True" SortExpression="RO_Date">
                                                                            <HeaderStyle ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                            <ItemStyle CssClass="dtGridtext" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="package_code" HeaderText="Package" ReadOnly="True" SortExpression="package_code"
                                                                            Visible="False">
                                                                            <HeaderStyle ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                            <ItemStyle CssClass="dtGridtext" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="Gross_amount" HeaderText="Amount" ReadOnly="True" SortExpression="Gross_amount"
                                                                            Visible="False">
                                                                            <HeaderStyle ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                            <ItemStyle CssClass="dtGridtext" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                        </asp:BoundColumn>
                                                                        <asp:TemplateColumn HeaderText="Update" Visible="False">
                                                                            <HeaderStyle ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn HeaderText="Delete" Visible="False">
                                                                            <HeaderStyle ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                        </asp:TemplateColumn>
                                                                    </Columns>
                                                                    <HeaderStyle BackColor="#7DAAE3" CssClass="dtGridHd" Height="20px" />
                                                                </asp:DataGrid></td>
                                                        </tr>
                                                        </table>
													</tr>
														</table>
                                                
												</td>
								<!---------middle end--------->
							</tr>
						</table>
                        <input id="hiddendateformat" type="hidden" runat="server" /></td>
                         <td><input id="hiddendateformat1" type="hidden" runat="server" /></td>
				</tr>
				
			</table>
		
			
			<input id="hiddenascdesc" type="hidden" runat="server" />
   <input id="hiddencioid" type="hidden" runat="server" />
   <td><input id="hiddenolddate" type="hidden" name="hiddenolddate" runat="server" /></td>

						
		
    </form>
</body>
</html>
