<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClientPaymode.aspx.cs" Inherits="ClientPaymode" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<HEAD>
		<title>Display Ad. Booking & Sheduling Client Master Paymode</title>
		<script language="javascript" src="javascript/ClientMaster.js"></script>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="css/main.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onload="javascript:return tddisplay(show);">
		<form id="Form1" name="frmpaymode" method="post" runat="server">
			<table id="table4"  cellspacing="0" cellpadding="0" width="632"   align="center"
				border="1">
				<tr valign="middle">
					<td style="height: 184px">
						<table id="Table3" cellspacing="0" cellpadding="0" width="633" align="center" bgcolor="#7daae3"
							border="0">
							<tr>
								<td class="btnlink" align="center">Payment Mode</td>
							</tr>
						</table>
						<table id="Table5" style="WIDTH: 358px; HEIGHT: 127px" cellspacing="0" cellpadding="0"
							width="358" align="center" border="0" >
							<tr>
								<td>
									<table id="Table9" style="WIDTH: 368px; HEIGHT: 203px" cellSpacing="0" cellPadding="0"
										width="368" align="center" border="0">
										<tr>
											<td style="WIDTH: 243px"></td>
											<td></td>
										</tr>
										<tr>
										
											<td id="sub" style="DISPLAY: none">
											<div id="Div1" style="OVERFLOW: auto; WIDTH: 650px; HEIGHT: 170px" runat="server" bordercolor="#000000" cellspacing="0" cellpadding="0">
											<asp:CheckBoxList ID="rdolistsubmit" CssClass="btnradio" RepeatLayout="Table" RepeatDirection="Vertical" RepeatColumns="1" Runat="server"></asp:CheckBoxList></div></td>
											<td id="updat" style="DISPLAY: none">
											<div id="Div2" style="OVERFLOW: auto; WIDTH: 650px; HEIGHT: 170px" runat="server" bordercolor="#000000" cellspacing="0" cellpadding="0">
											<asp:CheckBoxList ID="rdolistupdate" RepeatLayout="Table" RepeatDirection="Vertical" RepeatColumns="1" Runat="server" CssClass="btnradio"></asp:CheckBoxList></div></td>
										</tr>
										<TR>
											<TD></TD>
											<TD height="10"></TD>
										</TR>
										<TR>
										    <td>
											<div id="sub1" style="DISPLAY: none"><asp:button id="btnSubmit" runat="server" Text="Submit" CssClass="button1" OnClick="btnSubmit_Click"></asp:button><asp:Button ID="btnclose1" Text="Close" runat="server" CssClass="button1" /></div>
											<div id="updat1" style="DISPLAY: none"><asp:button id="btnUpdate" runat="server" Text="Update" CssClass="button1" OnClick="btnUpdate_Click"></asp:button><asp:Button ID="btnclose" Text="Close" runat="server" CssClass="button1" /></div>
											
											</td>
										</TR>
										<TR>
											<TD style="WIDTH: 242px"></TD>
											<TD></TD>
										</TR>
									</TABLE>
									<DIV style="OVERFLOW: auto"><INPUT id="hiddencomcode" type="hidden" size="5" name="hiddencomcode" runat="server"><INPUT id="hiddenuserid" type="hidden" size="4" name="hiddenuserid" runat="server"><INPUT id="hiddenclientcode" type="hidden" size="1" name="hiddenclientcode" runat="server">
									<INPUT id="hiddenagensubcode" type="hidden" size="1" name="hiddenagensubcode" runat="server">
									<INPUT id="hiddenshow" type="hidden" size="9" name="hiddenclientcode" runat="server"></DIV>
											<INPUT id="hiddenval" type="hidden" name="hiddenval" runat="server">
								</TD>
							</TR>
							<tr>
							    <td align="left">
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
			</TABLE>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
		</form>
	</body>
</HTML>
