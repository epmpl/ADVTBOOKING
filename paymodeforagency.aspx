<%@ Page Language="C#" AutoEventWireup="true" CodeFile="paymodeforagency.aspx.cs" Inherits="paymodeforagency" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Display Ad. Booking & Scheduling Agency Master PayMode</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<script language="javascript" type="text/javascript" src="javascript/contact.js"></script>
		<style type="text/css">.style1 { FONT-WEIGHT: bold; COLOR: #ffffff; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif }
	.style2 { COLOR: #ffffff }
		</style>
		<link href="css/main.css" type="text/css" rel="stylesheet" />
    
      
</head>
<body  >
    <form id="form1" runat="server">
     <table id="table4"  cellspacing="0" cellpadding="0" width="632" align="center"
				border="1">
				<tr valign="middle">
					<td align="center">
						<table id="table3" cellspacing="0" cellpadding="0" width="633" align="center" bgcolor="#7daae3"
							border="0">
							<tr>
								<td class="btnlink" align="center">Payment Mode</td>
							</tr>
						</table>
						<table id="table5" style="WIDTH: 358px; HEIGHT: 127px" cellspacing="0" cellpadding="0"
							width="358" align="center" border="0" >
							<tr>
								<td>
									<table id="table9" style="WIDTH: 368px; HEIGHT: 103px" cellspacing="0" cellpadding="0"
										width="368" align="center" border="0">
										<tr>
											<td style="WIDTH: 243px">
                                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                                </asp:ScriptManager>
                                            </td>
											<td></td>
										</tr>
										<tr>
											<td id="sub" style="DISPLAY:none;">
											<!--<asp:checkboxlist id="chklstSubmit" runat="server">
													<asp:ListItem Value="Cash">Cash</asp:ListItem>
													<asp:ListItem Value="Credit">Credit</asp:ListItem>
													<asp:ListItem Value="Bank">Bank</asp:ListItem>
												</asp:checkboxlist>--></td>
											<td id="updat" style="DISPLAY:none;">
											<!--<asp:checkboxlist id="chklstUpdate" runat="server">
													<asp:ListItem Value="Cash">Cash</asp:ListItem>
													<asp:ListItem Value="Credit">Credit</asp:ListItem>
													<asp:ListItem Value="Bank">Bank</asp:ListItem>
												</asp:checkboxlist>--></td>
										</tr>
										<tr>
											<td>
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <asp:CheckBoxList ID="chkforpay" runat="server" CssClass="TextField" align="center" >
                                                        </asp:CheckBoxList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
											<td  height="10"></td>
										</tr>
										<tr>
											<td id="sub1" style="DISPLAY: none" align="center"><asp:button id="btnSubmit" runat="server" Text="Submit" CssClass="button1"></asp:button></td>
											<td id="updat1" style="DISPLAY: none" align="center"><asp:button id="btnUpdate" runat="server" Text="Update" CssClass="button1"></asp:button></td>
										</tr>
										<tr>
											<td style="WIDTH: 242px">
											<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                <asp:Button ID="btnselect" runat="server" Text="Select" OnClick="btnselect_Click" CssClass="button1" />
                                                <asp:Button ID="updatepay" runat="server" Text="Update" OnClick="updatepay_Click" CssClass="button1" />
                                                </ContentTemplate>
                                                </asp:UpdatePanel>
                                                
                                                </td>
											<td></td>
										</tr>
                                        <tr>
                                            <td style="width: 242px">
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
									</table>
									<div style="OVERFLOW: auto"><input id="hiddencomcode" type="hidden" size="5" name="hiddencomcode" runat="server"  />
									<input id="hiddenuserid" type="hidden" size="4" name="hiddenuserid" runat="server" />
									<input id="hiddenagevcode" type="hidden" size="9" name="hiddenagevcode" runat="server" />
									<input id="hiddenagensubcode" type="hidden" size="6" name="hiddenagensubcode" runat="server" />
									<input id="hiddenshow" type="hidden" size="6" runat="server"/>
                                        <input id="hiddenpayvalue" type="hidden" size="6" runat="server"/></div>
								</td>
							</tr>
						</table>
						<table id="table6" cellspacing="0" cellpadding="0" width="634" align="center" bgcolor="#7daae3"
							border="0">
							<tr>
								<td align="center"></td>
							</tr>
						</table>
						<div></div>
					</td>
				</tr>
			</table>
    <div>
    
    </div>
    </form>
</body>
</html>
