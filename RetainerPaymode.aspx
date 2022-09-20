<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RetainerPaymode.aspx.cs" Inherits="RetainerPaymode" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<HEAD>
		<title>Display Ad. Booking & Sheduling Retainer Master Payment Mode</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="javascript/RetainerMaster.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/prototype.js"></script>
		<LINK href="css/main.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body onload="javascript:return tddisplay(show);">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4"  borderColor="#000000" cellSpacing="0" cellPadding="0" width="570" align="center"
				border="1">
				<TBODY>
					<TR vAlign="middle">
						<TD>
							<TABLE id="Table3"  cellSpacing="0" cellPadding="0" width="723" align="center" bgColor="#7daae3"
								border="0">
								<TR>
									<TD class="btnlink" align="center">Payment Mode</TD>
								</TR>
							</TABLE>
							<TABLE id="Table1" style="WIDTH: 456px; HEIGHT: 176px">
								<tr>
								</tr>
								<tr>
								</tr>
								<tr>
								</tr>
								<tr>
									<td></td>
									<%--<td id="sub" style="DISPLAY: none"><asp:checkboxlist id="chklstSubmit" runat="server">
											<asp:ListItem Value="Cash">Cash</asp:ListItem>
											<asp:ListItem Value="Credit">Credit</asp:ListItem>
											<asp:ListItem Value="Bank">Bank</asp:ListItem>
										</asp:checkboxlist></td>--%>
									<%--<td id="updat" style="DISPLAY: none"><asp:checkboxlist id="chklstUpdate" runat="server">
											<asp:ListItem Value="Cash">Cash</asp:ListItem>
											<asp:ListItem Value="Credit">Credit</asp:ListItem>
											<asp:ListItem Value="Bank">Bank</asp:ListItem>
										</asp:checkboxlist></td>--%>
									<td></td>
								</tr>
								
								<TR>
											<TD id="sub" style="DISPLAY: none">
											<div id="Div1" style="OVERFLOW: auto; WIDTH: 650px; HEIGHT: 100px" runat="server" bordercolor="#000000" cellspacing="0" cellpadding="0">
											<asp:RadioButtonList ID="rdolistsubmit" RepeatLayout="Table" RepeatDirection="Vertical" CssClass="btnradio" RepeatColumns="1" Runat="server"></asp:RadioButtonList></div></TD>
											<TD id="updat" style="DISPLAY: none">
											<div id="Div2" style="OVERFLOW: auto; WIDTH: 650px; HEIGHT: 100px" runat="server" bordercolor="#000000" cellspacing="0" cellpadding="0">
											<asp:RadioButtonList ID="rdolistupdate" RepeatLayout="Table" RepeatDirection="Vertical" CssClass="btnradio" RepeatColumns="1" Runat="server"></asp:RadioButtonList></div></TD>
										</TR>
								
								
								<tr>
									<td align="right"><asp:Button id="btnclose" runat="server" CssClass="button1" Text="Close" OnClick="btnclose_Click" ></asp:button></td>
									<td id="sub1" style="DISPLAY: none"><asp:button id="btnSubmit" runat="server" CssClass="button1" OnClick="btnSubmit_Click" Text="Submit"></asp:button></td>
									<td id="updat1" style="DISPLAY: none"><asp:button id="btnUpdate" runat="server" CssClass="button1" Text="Update"></asp:button></td>
									<td></td>
								</tr>
								<tr>
								</tr>
								<tr>
									<td></td>
								</tr>
								<tr>
								</tr>
								<tr>
									<td></td>
									<td></td>
									<td><INPUT id="hiddencompcode" type="hidden" size="5" name="hiddencomcode" runat="server">
										<INPUT id="hiddenretcode" type="hidden" size="1" name="hiddenretcode" runat="server">
										<INPUT id="hiddenuserid" type="hidden" size="4" name="hiddenuserid" runat="server">
										 <INPUT id="hiddenshow" style="WIDTH: 26px; HEIGHT: 22px" type=hidden size=1  name=hiddenuserid runat="server" onserverchange="hiddenshow_ServerChange">
                                         <INPUT id="hiddenval" type="hidden" name="hiddenval" runat="server">
									</td>
								</tr>
							</TABLE>
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="634" align="center" bgColor="#7daae3"
							border="0">
							<TR>
								<TD align="center"></TD>
							</TR>
						</TABLE>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
			<asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
		</form>
	</body>
</HTML>

