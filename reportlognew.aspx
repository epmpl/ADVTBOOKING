<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reportlognew.aspx.cs" Inherits="reportlognew" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Report Log</title>
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
		<script type="text/javascript"  language="javascript" src="javascript/reportlog.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/datevalidation.js"></script>
		<style type="text/css">.style1 { FONT-WEIGHT: bold; FONT-SIZE: xx-large; COLOR: #ffffff }
	        .style2 { COLOR: #ffffff }
	        .style4 { FONT-WEIGHT: normal; FONT-SIZE: 14pt; COLOR: #d85414; FONT-FAMILY: Verdana }
	        .style6 { FONT-SIZE: x-small }
	        .style7 { FONT-WEIGHT: bold; COLOR: #6666ff }
		</style>
</head>
<body onkeydown="tabvalue12(event,'drpForm');" onload="javascript:return givebuttonpermission('reportlognew');" style="background-color:#f3f6fd; margin:0px 0px 0px 0px;">
    <form id="Form1"  runat="server">
   <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
			<table border="0" cellspacing="0" cellpadding="0" style="WIDTH: 990px;">
				<tr>
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="State Master"></uc1:topbar></td>
				</tr>
				<tr>
				<td>
				<table border="0" cellpadding="0" cellspacing="0" width="100%" style="width:auto;margin:15px 40px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:167PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center><asp:Label ID="heading" runat ="server"></asp:Label></center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:700px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
				<table width="0" border="0" cellspacing="0" cellpadding="0" align="center">
													<tr>
													    <td>
                                                            <asp:Label ID="lbFromDate" runat="server" CssClass="TextField"></asp:Label></td>
													    <td>
                                                            <asp:TextBox ID="txtFromDate" runat="server" onpaste="return false;"  CssClass="btext1"></asp:TextBox>
                                                            
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
                                                            <asp:Label ID="lbToDate" runat="server" CssClass="TextField"></asp:Label></td>
													    <td>
                                                            <asp:TextBox ID="txtToDate" runat="server" onpaste="return false;"  CssClass="btext1"></asp:TextBox>
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
													    <td style="height: 23px">
                                                            <asp:Label ID="lbluser" runat="server" CssClass="TextField"></asp:Label></td>
													    <td style="height: 23px">
                                                            <asp:DropDownList ID="ue" runat="server" CssClass="dropdown">
                                                              
                                                            </asp:DropDownList></td>
													</tr>
													<tr style="padding-top:5px">
													    <td style="height: 23px">
                                                            <asp:Label ID="lbForm" runat="server" CssClass="TextField"></asp:Label></td>
													    <td style="height: 23px">
                                                            <asp:DropDownList ID="drpForm" runat="server" CssClass="dropdown">
                                                              
                                                            </asp:DropDownList></td>
													</tr>
													<tr style="padding-top:5px">
													    <td style="height: 23px">
                                                            <asp:Label ID="Label1" runat="server" CssClass="TextField"></asp:Label></td>
													    <td style="height: 23px">
													    <asp:TextBox id="txtbookid"  runat="server" CssClass="btext1" MaxLength="50"></asp:TextBox></td>
													    </tr>
													<tr align="right">
														<td align="right" colspan="2" style="padding-top:10px">
                                                                <%--<asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:button id="BtnRun" CssClass="topbutton" Runat="server" Width="63px" Font-Size="XX-Small" BackColor="Control"
										                                BorderStyle="Outset" BorderColor="DarkGray"  Height="24px" OnClick="BtnRun_Click1"></asp:button>
                                                                    <asp:button id="btnDelete" CssClass="topbutton" Width="63px" Runat="server"  Font-Size="XX-Small" BackColor="Control"
										                                BorderStyle="Outset" BorderColor="DarkGray"  Height="24px" OnClick="btnDelete_Click"></asp:button>
										                            <asp:button id="btnExit" CssClass="topbutton" Width="63px" Runat="server"  Font-Size="XX-Small" BackColor="Control"
										                                BorderStyle="Outset" BorderColor="DarkGray"  Height="24px"></asp:button>
                                                                    
                                                                    
                                                                <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                               
                                                            </td>
													</tr>
											</table>
				</td>
				</tr>
				</table>
				<table>
				<tr>
				<td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" AllowPaging="true" 
                     oninit="GridView1_Init" onitemcreated="GridView1_ItemCreated"  OnPageIndexChanging="GridView1_PageIndexChanging"
                       BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4"
                        GridLines="Horizontal">
                        <RowStyle BackColor="White" ForeColor="#333333" CssClass="TextField"/>
                        <Columns>
                            <asp:BoundField DataField="Date1" HeaderText="Date Time"  />
                            <asp:BoundField HeaderText="UserName" DataField="username" />
                            <asp:BoundField HeaderText="ProcessName" DataField="PROCESSNAME" />
                            <asp:BoundField HeaderText="Err Desription"  DataField="ERR_DESCRIPTION" />
                            <asp:BoundField HeaderText="Detail Process" DataField="OBJECT_PROCESS_ID" />
                            <asp:BoundField HeaderText="Descripton" DataField="DESCRIPTION" />
                            <asp:BoundField HeaderText="IP" DataField="ip" />
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#333333" />
                        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                    </asp:GridView>
				</td>
				</tr>
				
			</table>
		 <input id="hiddendateformat" type="hidden" runat="server" />
                         <input id="hiddendateformat1" type="hidden" runat="server" />
	

						
		
    <input id="danperm" type="hidden" size="2"/>
</form>
</body>
</html>